using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCurrency.Model
{
    public class Item
    {
        public string Id { get; set; }
        public int Coin_Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Market_Cap_Rank { get; set; }
        public string Thumb { get; set; }
        public string Small { get; set; }
        public string Large { get; set; }
        public string Slug { get; set; }
        public decimal Price_Btc { get; set; }
        public int Score { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
