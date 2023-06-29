using CCurrency.Model.CoinDetailedInfoSubModels.TickerSubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCurrency.Model.CoinDetailedInfoSubModels
{
    public   class Ticker
    {
        public string Base { get; set; }
        public string target { get; set; }
        public Market market { get; set; }
        public double last { get; set; }
        public double volume { get; set; }

        public ConvertedVolume converted_volume { get; set; }
        public string trade_url { get; set; }


    }
}
