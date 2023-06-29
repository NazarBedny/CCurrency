using CCurrency.Model.CoinDetailedInfoSubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCurrency.Model
{
    public  class CoinDetailedInfo
    {

        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Asset_Platform_Id { get; set; }           
        public double? MarketCap { get; set; }
        public double? MarketCapRank { get; set; }         
        public List<string> Categories { get; set; }
       
        public MarketData Market_Data { get; set; }
        public Description description { get; set; }
        public  Links links { get; set; }
        
        public List<Ticker> tickers { get; set; }

    }
}
