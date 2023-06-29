using CCurrency.Model.CoinDetailedInfoSubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCurrency.Model
{
    public class CoinMarketModel
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double? CurrentPrice { get; set; }
        public double? MarketCap { get; set; }
        public double? MarketCapRank { get; set; }
        public double? TotalVolume { get; set; }
        public double? High24h { get; set; }
        public double? Low24h { get; set; }
        public double? PriceChange24h { get; set; }
        public double? PriceChangePercentage24h { get; set; }
        public double? MarketCapChange24h { get; set; }
        public double? MarketCapChangePercentage24h { get; set; }
        public double? CirculatingSupply { get; set; }
        public double? TotalSupply { get; set; }
        public double? Ath { get; set; }
        public double? AthChangePercentage { get; set; }
        public DateTime? AthDate { get; set; }
        public double? Atl { get; set; }
        public double? AtlChangePercentage { get; set; }
        public DateTime? AtlDate { get; set; }
        public double? Roi { get; set; }
        public string LastUpdated { get; set; }

        public string Trade_Url { get; set; }
        
       
    }
}
