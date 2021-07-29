using CPpanelV4.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;

namespace CPpanelV4
{

    class CoinResponse
    {
        //public Data data { get; set; }

        //public void BdJson(IEnumerable<Coin> dbCoins, object state)
        //{
        //    string url = "http://api.coincap.io/v2/assets";
        //    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        //    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //    string response;
        //    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
        //    {
        //        response = streamReader.ReadToEnd();
        //    }
        //    //CoinResponse coinResponse = JsonConvert.DeserializeObject<CoinResponse>(response);
        //    DeCoin deCoin = JsonConvert.DeserializeObject<DeCoin>(response);


        //    foreach (var i1 in dbCoins) // сделать таймер
        //    {
        //        foreach (var i2 in deCoin.data)
        //        {
        //            if (i2.name == i1.Title)
        //            {
        //                float tmp = float.Parse(i2.priceUsd, CultureInfo.InvariantCulture.NumberFormat);
        //                i1.FactPrice = (tmp * i1.Count).ToString();

        //                float tmp2 = float.Parse(i1.Price.ToString());
        //                i1.DiffPrice = ((tmp - tmp2) / 100).ToString(); // Если число положительное, то цвет зеленый, отрицательное - красный.


        //                break;
        //            }
        //        }
        //    }





        //}




    }
}