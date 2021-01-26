using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace Quandl.API {
  [DataContract]
  public class StockData {
    [DataMember(IsRequired = false)]
    public string source_code { get; set; }

    [DataMember(IsRequired = false)]
    public string code { get; set; }

    [DataMember(IsRequired = false)]
    public string name { get; set; }

    [DataMember(IsRequired = false)]
    public string urlize_name { get; set; }

    [DataMember(IsRequired = false)]
    public string description { get; set; }

    [DataMember(IsRequired = false)]
    public string updated_at { get; set; }

    [DataMember(IsRequired = false)]
    public string frequency { get; set; }

    [DataMember(IsRequired = false)]
    public string from_date { get; set; }

    [DataMember(IsRequired = false)]
    public string to_date { get; set; }

    [DataMember(IsRequired = false)]
    public string[] column_names { get; set; }

    [DataMember(Name = "private", IsRequired = false)]
    public bool @private { get; set; }

    [DataMember(IsRequired = false)]
    public string type { get; set; }

    [DataMember(IsRequired = false)]
    public string errors { get; set; }

    [DataMember(IsRequired = false)]
    public string[][] data { get; set; }

    private double ParseDouble(string str) {
      double value;
      return double.TryParse(str, NumberStyles.Number, CultureInfo.InvariantCulture, out value) ? value : double.NaN;
    }

    public List<StockValue> GetValues() {
      return data.Select(entry => new StockValue() {
        Date = DateTime.Parse(entry[0], CultureInfo.InvariantCulture),
        Open = ParseDouble(entry[1]),
        High = ParseDouble(entry[2]),
        Low = ParseDouble(entry[3]),
        Close = ParseDouble(entry[4]),
        Volume = ParseDouble(entry[5]),
      }).OrderBy(stockValue => stockValue.Date).ToList();;
    }
  }
}
