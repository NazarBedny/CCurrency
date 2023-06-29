using CCurrency.View;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CCurrency.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private const int transaprencyDelay = 40;
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
        private Page search;
        public Page Search
        {
            get { return search; }
            set
            {
                search = value;
                OnPropertyChanged(nameof(Search));
            }
        }

        private Page Trending;

        private Page coinInfo;
        public Page CoinInfo
        {
            get { return coinInfo; }
            set
            {
                coinInfo = value;
                OnPropertyChanged(nameof(CoinInfo));
            }
        }

        public MainViewModel()
        {

            Trending = new Trending();
            Search = new Search();

            CurrentPage = Trending;


            FrameOpacity = 1;


        }

        public ICommand HomeClickCommand
        {
            get
            {
                return new DelegateCommand((object sender) => Click(Trending));
            }
        }
        public ICommand SearchClickCommand
        {
            get
            {
                return new DelegateCommand((object sender) => Click(Search));
            }
        }

        public async void Click(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(transaprencyDelay);
                }
                CurrentPage = page;
                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(transaprencyDelay);
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
