using CCurrency.Model;
using CCurrency.Model.CoinDetailedInfoSubModels;
using CCurrency.View;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CCurrency.ViewModel
{
    public class SearchViewModel : INotifyPropertyChanged
    {

        private CoinInfoViewModel coinInfoViewModel;
        public event PropertyChangedEventHandler PropertyChanged;


        private ObservableCollection<CoinForSearch> searchResult;
        public ObservableCollection<CoinForSearch> SearchResult
        {
            get { return searchResult; }
            set
            {
                searchResult = value;
                OnPropertyChanged(nameof(SearchResult));
            }
        }


        private CoinDetailedInfo coinDetailedInfo;
        public CoinDetailedInfo CoinDetailedInfo
        {
            get { return coinDetailedInfo; }
            set
            {
                coinDetailedInfo = value;
                OnPropertyChanged(nameof(CoinDetailedInfo.Name));

            }
        }

        private CoinForSearch selectedcoin;
        public CoinForSearch SelectedCoin
        {
            get { return selectedcoin; }
            set
            {
                selectedcoin = value;
                OnPropertyChanged(nameof(SelectedCoin));
            }
        }
        public string searchTerm;
        public string SearchTerm
        {
            get { return searchTerm; }
            set
            {
                searchTerm = value;
                OnPropertyChanged(nameof(SearchTerm));

            }
        }

        private Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        private double frameOpacity;
        public double FrameOpacity
        {
            get { return frameOpacity; }
            set
            {
                frameOpacity = value;
                OnPropertyChanged(nameof(FrameOpacity));
            }
        }


        private Visibility frameVisibility;
        public Visibility FrameVisibility
        {
            get { return frameVisibility; }
            set
            {
                frameVisibility = value;
                OnPropertyChanged(nameof(FrameVisibility));
            }
        }

        private Visibility findButtonVisibility;
        public Visibility FindButtonVisibility
        {
            get { return findButtonVisibility; }
            set
            {
                findButtonVisibility = value;
                OnPropertyChanged(nameof(FindButtonVisibility));
            }
        }

        public ICommand CloseСommand
        {
            get
            {
                return new DelegateCommand((object sender) => Close());
            }
        }
        private void Close()
        {
            FrameVisibility = Visibility.Hidden;
            FindButtonVisibility = Visibility.Visible;
        }

        public SearchViewModel()
        {

        }
        public ICommand SearchCommand
        {
            get
            {
                return new DelegateCommand((object sender) => Search());
            }
        }

        private void Search()
        {

            using (HttpClient client = new HttpClient())
            {
                string url = $"{Properties.Settings.Default.SearchUrl}{SearchTerm}";
                HttpResponseMessage response = client.GetAsync(url).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                Response<CoinForSearch> coinSearchResponse = JsonConvert.DeserializeObject<Response<CoinForSearch>>(data);

                SearchResult = new ObservableCollection<CoinForSearch>(coinSearchResponse.Coins);

            }
        }
        public ICommand ListBoxDoubleClickCommand
        {
            get
            {
                return new DelegateCommand(ListBoxDoubleClick_Executed);

            }
        }

        private void ListBoxDoubleClick_Executed(object parameter)
        {
            if (parameter is CoinForSearch clickedItem)
            {
                FindButtonVisibility = Visibility.Hidden;
                FrameVisibility = Visibility.Visible;
                
                SelectedCoin = clickedItem;

                GetInfo(SelectedCoin);
                coinInfoViewModel = new CoinInfoViewModel(CoinDetailedInfo);
                NavigateToCoinInfo();
                FrameOpacity = 1;
            }

        }
        private void NavigateToCoinInfo()
        {
            CoinInfo coininfo = new CoinInfo();
            CurrentPage = coininfo;
            coininfo.DataContext = new CoinInfoViewModel(CoinDetailedInfo);
        }
        private void GetInfo(CoinForSearch coinForSearch)
        {

            using (HttpClient client = new HttpClient())
            {
                string url = $"{Properties.Settings.Default.SearchIDUrl}{coinForSearch.Id}";
                HttpResponseMessage response = client.GetAsync(url).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                CoinDetailedInfo infoAboutCoin = JsonConvert.DeserializeObject<CoinDetailedInfo>(data);

                CoinDetailedInfo = infoAboutCoin;
                DefectedTickerCheck();
            }

        }
        private void DefectedTickerCheck()
        {
            foreach (Ticker ticker in CoinDetailedInfo.tickers)
            {
                if (ticker.Base.Length>10)
                {
                    CoinDetailedInfo.tickers.Remove(ticker);
                }
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}





