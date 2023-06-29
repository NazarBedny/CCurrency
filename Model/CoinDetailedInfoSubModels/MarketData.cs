using CCurrency.Model.CoinDetailedInfoSubModels;

namespace CCurrency.Model
{
    public class MarketData
    {
        public CurrentPrice current_price { get; set; }
        public decimal price_change_percentage_24h { get; set; }
        public TotalVolume total_volume { get; set; }
    }
}