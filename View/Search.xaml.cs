using CCurrency.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CCurrency.View
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
      
        public Search()
        {
            InitializeComponent();
            DataContext = new SearchViewModel();
           
        }

        private void searchInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void coinList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void coinList_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void coinList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

      
    }
}
