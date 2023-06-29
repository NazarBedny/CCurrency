using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCurrency.Model
{
    public  class Response<T>
    {
        public ObservableCollection<T> Coins { get; set; }
    }
}
