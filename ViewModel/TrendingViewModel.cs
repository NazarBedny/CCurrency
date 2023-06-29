using CCurrency.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Windows.Controls;
using System.Windows.Input;

namespace CCurrency.ViewModel
{
    public class TrendingViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CoinForSearch> cryptoCurrencies;
        public ObservableCollection<CoinForSearch> CryptoCurrencies
        {
            get { return cryptoCurrencies; }
            set
            {
                cryptoCurrencies = value;
                OnPropertyChanged(nameof(CryptoCurrencies));
            }
        }

        public TrendingViewModel()
        {

        }
        
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {       
            var selectedElement = ((ListBox)sender).SelectedItem;
        }
        
        public ICommand  Update
        {
            get
            {
                return new DelegateCommand((object sender) =>GetTrending());
            }
        }
         private void  GetTrending()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{Properties.Settings.Default.SearchUrl}";
                HttpResponseMessage response = client.GetAsync(url).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                Response<CoinForSearch> coins = JsonConvert.DeserializeObject<Response<CoinForSearch>>(data);
                CryptoCurrencies = new ObservableCollection<CoinForSearch>(coins.Coins.Take(10));
                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
