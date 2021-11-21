using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace My_Wallet.Views
{
    class TransactionsViewModel
    {
        public int IDTransaction { get; set; }
        public string AccountName { get; set; }
        public DateTime EnteredDate { get; set; }

        public double Amount { get; set; }

        public string Notes { get; set; }

        public string AccountColor { get; set; }



    }




    public class MonthNames 
    {

        public int MonthID { get; set; }
        public string MonthName { get; set; }

    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewAccounts : ContentPage
    {
        public ViewAccounts()
        {
            InitializeComponent();
        }




        List<MonthNames> MonthNames = new List<MonthNames>();
        public ObservableCollection<AccountType> AccountsType = new ObservableCollection<AccountType>();
        ObservableCollection<TransactionsViewModel> TransactionsViewModels = new ObservableCollection<TransactionsViewModel>();


        string TotalStr = "Sum Expense : ";
        void EmplementSum(double Sum)
        {
            string Currency = "USD";
            if (CL.PassingParameter.ArLanguage)
            {
                Currency = "د.أ";
                TotalStr = "مجموع المصاريف  : ";
            }
            //lblSum.Text = TotalStr + CL.PassingParameter.ConvertAr(Sum.ToString("0"))+" "+ Currency;

            lblSum.Text = TotalStr +CL.PassingParameter.ConvertAr(Sum.ToString("0")) + " " + Currency;

            
           
        }


        protected override async void OnAppearing()
        {
            #region Create table Type
            AccountsType.Add(new AccountType { TypeID = 1, TypeName = "Expense" });
            AccountsType.Add(new AccountType { TypeID = 2, TypeName = "Group" });
            AccountsType.Add(new AccountType { TypeID = 3, TypeName = "Statement" });

            #endregion




            #region Get list Transations


            var Accounts = await CL.PassingParameter._connection.Table<Tables.Accounts>().ToListAsync();

            var Transaction = await CL.PassingParameter._connection.Table<Tables.Transactions>().ToListAsync();

            TransactionList.ItemsSource = Accounts;



            EmplementSum(Transaction.Sum(i => i.Amount));



            var results = (from table1 in Transaction.AsEnumerable()
                           join table2 in Accounts.AsEnumerable() on table1.IDAccount equals table2.AccountID
                           select new TransactionsViewModel
                           {

                             IDTransaction= table1.IDTransaction,
                               EnteredDate= table1.EnteredDate,
                               Amount= table1.Amount,
                               Notes= table1.Notes,
                               AccountName=table2.AccountName,
                               AccountColor=table2.AccountColor
                               

                           });



            TransactionsViewModels = CL.ObjectConvertor.ConvertTransactionList(results);

            filter = TransactionsViewModels.ToList();


            TransactionList.ItemsSource = TransactionsViewModels;


            

            #endregion


            #region Create List account Name

            var resultsAccountType = (from table1 in Accounts.AsEnumerable()
                           join table2 in AccountsType.AsEnumerable() on table1.AccountType equals table2.TypeID
                           select new TableAccountView
                           {

                             AccountID= table1.AccountID,
                               AccountColor=table1.AccountColor,
                               AccountName=table1.AccountName,
                               AccountType=table2.TypeName

                           });

          


            AccountListSelector.ItemsSource = CL.ObjectConvertor.ConvertAccountList(resultsAccountType);





            #endregion




            #region Create months list
            if (CL.PassingParameter.ArLanguage)
            {
                MonthNames.Add(new MonthNames { MonthID = 1, MonthName = "كانون الثاني	" });
                MonthNames.Add(new MonthNames { MonthID = 2, MonthName = "شباط" });
                MonthNames.Add(new MonthNames { MonthID = 3, MonthName = "آذار" });
                MonthNames.Add(new MonthNames { MonthID = 4, MonthName = "نيسان" });
                MonthNames.Add(new MonthNames { MonthID = 5, MonthName = "أيار" });
                MonthNames.Add(new MonthNames { MonthID = 6, MonthName = "حزيران" });
                MonthNames.Add(new MonthNames { MonthID = 7, MonthName = "تموز" });
                MonthNames.Add(new MonthNames { MonthID = 8, MonthName = "آب" });
                MonthNames.Add(new MonthNames { MonthID = 9, MonthName = "أيلول" });
                MonthNames.Add(new MonthNames { MonthID = 10, MonthName = "تشرين الأول" });
                MonthNames.Add(new MonthNames { MonthID = 11, MonthName = "تشرين الثاني" });
                MonthNames.Add(new MonthNames { MonthID = 12, MonthName = "كانون الأول" });

                MonthListSelector.ItemsSource = MonthNames;
                return;
            }



            MonthNames.Add(new MonthNames { MonthID = 1, MonthName = "January" });
            MonthNames.Add(new MonthNames { MonthID = 2, MonthName = "February" });
            MonthNames.Add(new MonthNames { MonthID = 3, MonthName = "March" });
            MonthNames.Add(new MonthNames { MonthID = 4, MonthName = "April" });
            MonthNames.Add(new MonthNames { MonthID = 5, MonthName = "May" });
            MonthNames.Add(new MonthNames { MonthID = 6, MonthName = "June" });
            MonthNames.Add(new MonthNames { MonthID = 7, MonthName = "July" });
            MonthNames.Add(new MonthNames { MonthID = 8, MonthName = "August" });
            MonthNames.Add(new MonthNames { MonthID = 9, MonthName = "September" });
            MonthNames.Add(new MonthNames { MonthID = 10, MonthName = "October" });
            MonthNames.Add(new MonthNames { MonthID = 11, MonthName = "November" });
            MonthNames.Add(new MonthNames { MonthID = 12, MonthName = "December" });
            MonthListSelector.ItemsSource = MonthNames;


            #endregion


            base.OnAppearing();
        }







        //open filter view

        List<TransactionsViewModel> filter;
        private void StartFilter_Clicked(object sender, EventArgs e)
        {




            filter = TransactionsViewModels.ToList();
            if (FrameFilter.Height==0)
            {
                CL.AnimationObject.AnimationHeightFrame(FrameFilter);
                return;
            }

           
           if (lblAccountName.Text != null)
            {
                filter = filter.Where(i => i.AccountName == lblAccountName.Text).ToList();

               
                
            }
           else if (lblAccountName.Text == null)
            {
                filter = filter.Where(i => i.AccountName != "").ToList();

                

            }
            
            if (lblMonthName.Text != null)
            {
                
                DateTime StartDate = new DateTime(2021, SelectedMonth.MonthID, 1);
                DateTime EndDate = new DateTime(2021, SelectedMonth.MonthID, DateTime.DaysInMonth(2021,SelectedMonth.MonthID));


                filter = filter.Where(i => i.EnteredDate >= StartDate).ToList();
                filter = filter.Where(i => i.EnteredDate <= EndDate).ToList();

               

               
            }
           else if (lblMonthName.Text == null)
            {

              


                filter = filter.Where(i => i.EnteredDate != null).ToList();
               

               
            }

            filter = filter.OrderBy(i => i.EnteredDate).ToList();
            if (Asc == false)
            {
                filter = filter.OrderByDescending(i => i.EnteredDate).ToList();

            }
            TransactionList.ItemsSource = CL.ObjectConvertor.ConvertTransactionList(filter);

            EmplementSum(filter.Sum(i=>i.Amount));

            CL.AnimationObject.AnimationHeightFrame(FrameFilter);


        }


        //get name account of select view


        TableAccountView SelectAccount = new TableAccountView();
        private void AccountSelectedTap_Tapped(object sender, EventArgs e)
        {
            var tapEventArgs = (TappedEventArgs)e;
            SelectAccount = (TableAccountView)tapEventArgs.Parameter;

            
            lblAccountName.BindingContext = SelectAccount;

            CL.AnimationObject.AnimationHeightFrame(FrameAccountSelector);
        }



        //close filter view
        private void CLoseFilterView_Tapped(object sender, EventArgs e)
        {
            CL.AnimationObject.AnimationHeightFrame(FrameFilter);
        }


        //open account list to select account
        private void btnAccountSelect_Clicked(object sender, EventArgs e)
        {
            CL.AnimationObject.AnimationHeightFrame(FrameAccountSelector);
        }


        //open list month to select one
        private void btnMonthSelect_Clicked(object sender, EventArgs e)
        {
            CL.AnimationObject.AnimationHeightFrame(FrameMonthSelector);
        }



        MonthNames SelectedMonth = new MonthNames();
        private void MonthSelectedTap_Tapped(object sender, EventArgs e)
        {
            var tapEventArgs = (TappedEventArgs)e;
            SelectedMonth = (MonthNames)tapEventArgs.Parameter;


            lblMonthName.BindingContext = SelectedMonth;

            CL.AnimationObject.AnimationHeightFrame(FrameMonthSelector);
        }


        
        bool Asc = true;
        private async void btnSort_Clicked(object sender, EventArgs e)
        {
            ImageButton btnSort = (ImageButton)sender;



            if (Asc)
            {
                Asc = false;
                await btnSort.RotateTo(180, 500);
                filter = filter.OrderByDescending(i => i.EnteredDate).ToList();

            }
            else if (Asc == false)
            {
                filter = filter.OrderBy(i => i.EnteredDate).ToList();
               
                Asc = true;
                await btnSort.RotateTo(0, 500);
            }
           

            TransactionList.ItemsSource = CL.ObjectConvertor.ConvertTransactionList(filter);
        }

        private void SummaryReport_Clicked(object sender, EventArgs e)
        {
          var list=  filter.GroupBy(i => i.AccountName)
                                       .Select(g => new TransactionsViewModel
                                       {
                                           AccountName=g.Key,
                                           EnteredDate = g.FirstOrDefault().EnteredDate,
                                           AccountColor= g.FirstOrDefault().AccountColor,
                                           IDTransaction= g.FirstOrDefault().IDTransaction,
                                           Notes= g.FirstOrDefault().Notes,
                                           Amount = g.Select(l => l.Amount).Distinct().Sum()
                                       });


            TransactionList.ItemsSource = CL.ObjectConvertor.ConvertTransactionList(list);
        }

        private void ClearFilter_Clicked(object sender, EventArgs e)
        {
            Button image = (Button)sender;

            string AccountIndex = image.ClassId;
            switch (AccountIndex)
            {
                case "Account":
                    lblAccountName.BindingContext = new TableAccountView();
                    break;

                case "Month":
                    lblMonthName.BindingContext = new MonthNames() ;
                    break;

            }
        }

        private void MonthlyReport_Clicked(object sender, EventArgs e)
        {
            CultureInfo Lang = new CultureInfo("en-US");
            if (CL.PassingParameter.ArLanguage == true)
            {
                Lang = new CultureInfo("ar-Jo");
            }

            var q = from i in filter
                    group i by i.EnteredDate.ToString("MMMM", Lang) into grp
                    select new TransactionsViewModel { AccountName = grp.Key,AccountColor= grp.FirstOrDefault().AccountColor, Amount =double.Parse( grp.Sum(i => i.Amount).ToString("0").Replace(" ","")) };

            TransactionList.ItemsSource = CL.ObjectConvertor.ConvertTransactionList(q);
        }
    }
}