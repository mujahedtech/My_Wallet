using My_Wallet.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace My_Wallet.CL
{
    class ObjectConvertor 
    {

        public static ObservableCollection<object> ConvertObservableCollection(System.Collections.IEnumerable original)
        {
            return new ObservableCollection<object>(original.Cast<object>());
        }

    }
}
