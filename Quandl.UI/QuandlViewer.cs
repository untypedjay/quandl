using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Quandl.API;

namespace Quandl.UI
{
    public partial class QuandlViewer : Form
    {

        private QuandlService service;
        private readonly string[] names = { "MSFT", "AAPL", "GOOG" };
        private const int INTERVAL = 200;

        public QuandlViewer()
        {
            InitializeComponent();
            service = new QuandlService();
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            //SequentialImplementation();
            TaskImplementation();
            //await AsyncImplementation();
        }

        #region Sequential Implementation
        private void SequentialImplementation()
        {
            List<Series> seriesList = new List<Series>();

            foreach (var name in names)
            {
                StockData sd = RetrieveStockData(name);
                List<StockValue> values = sd.GetValues();
                seriesList.Add(GetSeries(values, name));
                seriesList.Add(GetTrend(values, name));
            }

            DisplayData(seriesList);
            SaveImage("chart");
        }

        private StockData RetrieveStockData(string name)
        {
            return service.GetData(name);
        }

        private Task<StockData> RetrieveStockDataAsync(string name)
        {
            return Task.Factory.StartNew<StockData>(() => RetrieveStockData(name));
        }

        private Series GetSeries(List<StockValue> stockValues, string name)
        {
            Series series = new Series(name);
            series.ChartType = SeriesChartType.FastLine;

            int j = 1;
            for (int i = stockValues.Count - INTERVAL; i < stockValues.Count; i++)
            {
                series.Points.Add(new DataPoint(j, stockValues[i].Close));
                j++;
            }
            return series;
        }

        private Series GetTrend(List<StockValue> stockValues, string name)
        {
            double k, d;
            Series series = new Series(name + " Trend");
            series.ChartType = SeriesChartType.FastLine;

            var vals = stockValues.Skip(stockValues.Count() - INTERVAL).Select(x => x.Close).ToArray();
            LinearLeastSquaresFitting.Calculate(vals, out k, out d);

            for (int i = 1; i <= INTERVAL; i++)
            {
                series.Points.Add(new DataPoint(i, k * i + d));
            }
            return series;
        }
        #endregion

        #region Parallel Implementations
        private void TaskImplementation()
        {
            var tasks = names.Select(name => RetrieveStockDataAsync(name)
                .ContinueWith(t => t.Result.GetValues())
                .ContinueWith(t =>
                {
                    var values = t.Result;
                    var series = GetSeries(values, name);
                    var trend = GetTrend(values, name);
                    return new[] { series, trend };
                })
            );

            Task.WhenAll(tasks).ContinueWith(t =>
            {
                DisplayData(t.Result.SelectMany(x => x).ToList());
                SaveImage("chart_tasks");
            });
        }

        private async Task AsyncImplementation()
        {
            // TODO
        }
        #endregion

        #region Helpers
        private void DisplayData(List<Series> seriesList)
        {
            if (InvokeRequired) Invoke((Action<List<Series>>)DisplayData, seriesList);
            else
            {
                chart.Series.Clear();
                foreach (Series series in seriesList)
                {
                    chart.Series.Add(series);
                }
            }
        }

        private void SaveImage(string fileName)
        {
            if (InvokeRequired) Invoke((Action<string>)SaveImage, fileName);
            else
            {
                chart.SaveImage(fileName + ".jpg", ChartImageFormat.Jpeg);
            }
        }
        #endregion
    }
}
