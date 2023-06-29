
using CCurrency.Model;
using CCurrency.Model.CoinDetailedInfoSubModels;
using GalaSoft.MvvmLight.Ioc;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace CCurrency.ViewModel
{
    public class CoinInfoViewModel : INotifyPropertyChanged
    {

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
        private CoinDetailedInfo detailedInfo;
        public CoinDetailedInfo DetailedInfo
        {
            get { return detailedInfo; }
            set
            {
                detailedInfo = value;
                OnPropertyChanged(nameof(DetailedInfo.Name));

            }
        }
        public CoinInfoViewModel()
        {
        }
        [PreferredConstructor]
        public CoinInfoViewModel(CoinDetailedInfo coinDetailedInfo)
        {
            DetailedInfo = coinDetailedInfo;
        }

        public ICommand OpenWebSiteCommand
        {
            get
            {
                return new DelegateCommand((object sender) => OpenWebSite());
            }
        }
        private void OpenWebSite()
        {
            System.Diagnostics.Process.Start(DetailedInfo.links.homepage.First());
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
            if (parameter is Ticker clickedItem)
            {
                var SelectedTicker = clickedItem;
                System.Diagnostics.Process.Start(SelectedTicker.trade_url);
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
