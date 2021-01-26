using System;
using System.IO;
using System.ServiceModel;
using System.Threading;
using System.Xml.Serialization;

namespace Quandl.API {
  public class QuandlService : ClientBase<QuandlAPI>, QuandlAPI {
    public StockData GetData(string identifier) {
      // without an api key, we're limited in requests per day
      //var data = Channel.GetData(identifier);

      // let's just deserialize given xml data
      StockData data = null;
      using (var fs = new FileStream($@"Data\{identifier}.xml", FileMode.Open, FileAccess.Read)) {
        var deserializer = new XmlSerializer(typeof(StockData));
        data = (StockData)deserializer.Deserialize(fs);
      }

      // and simulate the request duration
      var random = new Random();
      Thread.Sleep(random.Next(2000, 3000));

      return data;
    }
  }
}
