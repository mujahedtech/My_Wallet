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

        public static ObservableCollection<TableAccountView> ConvertAccountList(System.Collections.IEnumerable original)
        {
            return new ObservableCollection<TableAccountView>(original.Cast<TableAccountView>());
        }



        public static ObservableCollection<TransactionsViewModel> ConvertTransactionList(System.Collections.IEnumerable original)
        {
            return new ObservableCollection<TransactionsViewModel>(original.Cast<TransactionsViewModel>());
        }

    }
}
