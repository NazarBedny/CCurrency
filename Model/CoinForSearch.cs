using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCurrency.Model
{
    public  class CoinForSearch
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Api_Symbol { get; set; }
        public string Symbol { get; set; }
        public int? Market_Cap_Rank { get; set; }
        public string Thumb { get; set; }
        public string Large { get; set; }

        public decimal Price_Btc { get; set; }

    }
}
