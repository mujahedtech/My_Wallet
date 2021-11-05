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
        public int AccountType { get; set; }
        public string AccountColor { get; set; }



    }
    public class TableAccountView
    {

        public string AccountID { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string AccountColor { get; set; }



    }

    public class AccountType
    {

        public int TypeID { get; set; }
        public string TypeName { get; set; }
       



    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageAccounts : ContentPage
    {
        public ManageAccounts()
        {
            InitializeComponent();
        }


        protected override bool OnBackButtonPressed()
        {
            bool Value = true;

            if (FrameNewAccount.IsVisible == false)
            {
                Value = base.OnBackButtonPressed();
            }

            if (FrameNewAccount.IsVisible==true)
            {
                CL.AnimationObject.EndAnimationFrame(FrameNewAccount);
            }

           


            return Value;
        }

        public ObservableCollection<TableAccounts> tableAccounts = new ObservableCollection<TableAccounts>();
        public ObservableCollection<AccountType> AccountsType = new ObservableCollection<AccountType>();
        protected override void OnAppearing()
        {

            #region Create table Type
            AccountsType.Add(new AccountType { TypeID = 1, TypeName = "Expense" });
            AccountsType.Add(new AccountType { TypeID = 2, TypeName = "Group" });
            AccountsType.Add(new AccountType { TypeID = 3, TypeName = "Statement" });

            #endregion






          


            #region Create Table Account

            tableAccounts.Add(new TableAccounts { AccountID = "1", AccountType = 1, AccountColor = "#808000", AccountName = "car Supplies" });
            tableAccounts.Add(new TableAccounts { AccountID = "2", AccountType = 1, AccountColor = "#008080", AccountName = "foods" });
            tableAccounts.Add(new TableAccounts { AccountID = "3", AccountType = 1, AccountColor = "#008080", AccountName = "sweets" });
            tableAccounts.Add(new TableAccounts { AccountID = "4", AccountType = 1, AccountColor = "#D3212D", AccountName = "Fuel" });
            tableAccounts.Add(new TableAccounts { AccountID = "5", AccountType = 1, AccountColor = "#808080", AccountName = "Shawarma" });
            tableAccounts.Add(new TableAccounts { AccountID = "6", AccountType = 1, AccountColor = "#2E5894", AccountName = "Citroen Loan" });
            tableAccounts.Add(new TableAccounts { AccountID = "7", AccountType = 1, AccountColor = "#808000", AccountName = "Oil Engine Motor" });
            tableAccounts.Add(new TableAccounts { AccountID = "8", AccountType = 1, AccountColor = "#808080", AccountName = "KFC" });
            tableAccounts.Add(new TableAccounts { AccountID = "9", AccountType = 1, AccountColor = "#006A4E", AccountName = "Citroen Repair" });
            tableAccounts.Add(new TableAccounts { AccountID = "10", AccountType = 1, AccountColor = "#808080", AccountName = "family" });
            tableAccounts.Add(new TableAccounts { AccountID = "11", AccountType = 1, AccountColor = "#B0BF1A", AccountName = "Citroen Radiator" });
            tableAccounts.Add(new TableAccounts { AccountID = "12", AccountType = 1, AccountColor = "#AB274F", AccountName = "fuel 95" });
            tableAccounts.Add(new TableAccounts { AccountID = "13", AccountType = 1, AccountColor = "#808080", AccountName = "Sahar 600 Refund" });
            tableAccounts.Add(new TableAccounts { AccountID = "14", AccountType = 1, AccountColor = "#008000", AccountName = "Eid Cash" });
            tableAccounts.Add(new TableAccounts { AccountID = "15", AccountType = 1, AccountColor = "#007AA5", AccountName = "refill zain cash" });
            tableAccounts.Add(new TableAccounts { AccountID = "16", AccountType = 1, AccountColor = "#008000", AccountName = "Cleaner Fuel" });
            tableAccounts.Add(new TableAccounts { AccountID = "17", AccountType = 1, AccountColor = "#800000", AccountName = "Clothes" });
            tableAccounts.Add(new TableAccounts { AccountID = "18", AccountType = 1, AccountColor = "#800000", AccountName = "petty cash" });
            tableAccounts.Add(new TableAccounts { AccountID = "19", AccountType = 2, AccountColor = "#007FFF", AccountName = "Citroen Registration " });
            tableAccounts.Add(new TableAccounts { AccountID = "20", AccountType = 2, AccountColor = "#008080", AccountName = "Hosaam Xaml", });


           



            var results = (from table1 in tableAccounts.AsEnumerable()
                          join table2 in AccountsType.AsEnumerable() on table1.AccountType equals table2.TypeID
                          select new TableAccountView
                          {

                              AccountID= table1.AccountID,
                              AccountName=table1.AccountName,
                              AccountColor=table1.AccountColor,
                              AccountType=table2.TypeName


                          });



            
            

            #endregion





            AccountList.ItemsSource = CL.ObjectConvertor.ConvertObservableCollection(results);


            base.OnAppearing();
        }

       

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
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

        private  void btnNewAccount_Clicked(object sender, EventArgs e)
        {
           

        }

        
        private void btnDelete_Clicked(object sender, EventArgs e)
        {

         
           
            
           
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var tapEventArgs = (TappedEventArgs)e;
            var parameter = (TableAccountView)tapEventArgs.Parameter;


            GridNewAccount.BindingContext = parameter;
            CL.AnimationObject.StartAnimationFrame(FrameNewAccount);


            

            var report = AccountsType.Where(i => i.TypeName == parameter.AccountType).ToList();
          

            SelectAccountType(report.FirstOrDefault().TypeID);
        }




        //تم من خلالها تحديد نوع الحساب ليتم عند التعديل ما هو نوع الحساب الحالي
        void SelectAccountType(int TypeID)
        {
            btnExpenseType.IsChecked = false;
            btnGroupType.IsChecked = false;
            btnStatementType.IsChecked = false;

            switch (TypeID)
            {
                case 1:
                    btnExpenseType.IsChecked = true;
                    break;
                case 2:
                    btnGroupType.IsChecked = true;
                    break;
                case 3:
                    btnStatementType.IsChecked = true;
                    break;




            }

        }


        
    }
}