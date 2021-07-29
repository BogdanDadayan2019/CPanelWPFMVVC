using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPpanelV4.Model
{
    class DeCoin
    {
        public List<Data> data;
        public string timestamp;
    }

    public class Data
    {
        public string name { get; set; }
        public string priceUsd { get; set; }
        public string symbol { get; set; }
    }

}
