using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace My_Wallet.Views
{

    public class TableAccounts 
    {

        public string AccountID { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string AccountColor { get; set; }



    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageAccounts : ContentPage
    {
        public ManageAccounts()
        {
            InitializeComponent();
        }

       public ObservableCollection<TableAccounts> tableAccounts = new ObservableCollection<TableAccounts>();
        protected override void OnAppearing()
        {
          

            tableAccounts.Add(new TableAccounts { AccountID = "1", AccountName = "car Supplies", AccountType = "Expense", AccountColor = "#808000" });
            tableAccounts.Add(new TableAccounts { AccountID = "2", AccountName = "foods", AccountType = "Expense", AccountColor = "#008080" });
            tableAccounts.Add(new TableAccounts { AccountID = "3", AccountName = "sweets", AccountType = "Expense", AccountColor = "#008080" });
            tableAccounts.Add(new TableAccounts { AccountID = "4", AccountName = "Fuel", AccountType = "Expense", AccountColor = "#D3212D" });
            tableAccounts.Add(new TableAccounts { AccountID = "5", AccountName = "Shawarma", AccountType = "Expense", AccountColor = "#808080" });
            tableAccounts.Add(new TableAccounts { AccountID = "6", AccountName = "Citroen Loan", AccountType = "Expense", AccountColor = "#2E5894" });
            tableAccounts.Add(new TableAccounts { AccountID = "7", AccountName = "Oil Engine Motor", AccountType = "Expense", AccountColor = "#808000" });
            tableAccounts.Add(new TableAccounts { AccountID = "8", AccountName = "KFC", AccountType = "Expense", AccountColor = "#808080" });
            tableAccounts.Add(new TableAccounts { AccountID = "9", AccountName = "Citroen Repair", AccountType = "Expense", AccountColor = "#006A4E" });
            tableAccounts.Add(new TableAccounts { AccountID = "10", AccountName = "family", AccountType = "Expense", AccountColor = "#808080" });
            tableAccounts.Add(new TableAccounts { AccountID = "11", AccountName = "Citroen Radiator", AccountType = "Expense", AccountColor = "#B0BF1A" });
            tableAccounts.Add(new TableAccounts { AccountID = "12", AccountName = "fuel 95", AccountType = "Expense", AccountColor = "#AB274F" });
            tableAccounts.Add(new TableAccounts { AccountID = "13", AccountName = "Sahar 600 Refund", AccountType = "Expense", AccountColor = "#808080" });
            tableAccounts.Add(new TableAccounts { AccountID = "14", AccountName = "Eid Cash", AccountType = "Expense", AccountColor = "#008000" });
            tableAccounts.Add(new TableAccounts { AccountID = "15", AccountName = "refill zain cash", AccountType = "Expense", AccountColor = "#007AA5" });
            tableAccounts.Add(new TableAccounts { AccountID = "16", AccountName = "Cleaner Fuel", AccountType = "Expense", AccountColor = "#008000" });
            tableAccounts.Add(new TableAccounts { AccountID = "17", AccountName = "Clothes", AccountType = "Expense", AccountColor = "#800000" });
            tableAccounts.Add(new TableAccounts { AccountID = "18", AccountName = "petty cash", AccountType = "Expense", AccountColor = "DodgerBlue" });
            tableAccounts.Add(new TableAccounts { AccountID = "19", AccountName = "Citroen Registration", AccountType = "Account", AccountColor = "#007FFF" });
            tableAccounts.Add(new TableAccounts { AccountID = "20", AccountName = "Hosaam Xaml", AccountType = "Account", AccountColor = "#008080" });




            AccountList.ItemsSource = tableAccounts;


            base.OnAppearing();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("654654","545","Ok");
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            //if (RadioButton1.IsChecked==true)
            //{
            //    RadioButton1.IsChecked = false;
            //    DisplayAlert("654654", "545", "Ok");
            //}
            
        }

        private void DeleteAccount_Invoked(object sender, EventArgs e)
        {
            var button = (SwipeItemView)sender;
            var Check = button.CommandParameter as TableAccounts;

        
            tableAccounts.Remove(Check);

            AccountList.ItemsSource = tableAccounts;
        }

        private void btnNewAccount_Clicked(object sender, EventArgs e)
        {
            

        }

        
        private void btnDelete_Clicked(object sender, EventArgs e)
        {

         
           
            
           
        }
    }
}