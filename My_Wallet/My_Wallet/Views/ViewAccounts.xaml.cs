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
   public class TransactionsViewModel
    {
        public int IDTransaction { get; set; }
        public string AccountName { get; set; }
        public DateTime EnteredDate { get; set; }

        public double Amount { get; set; }

        public string Notes { get; set; }

        public string AccountColor { get; set; }

        public int AccountType { get; set; }

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

            SetMonthlyYear();
        }


        //>الة يتم من خلال تحديد ما هي السنة الحالية من اجل ان تكون محددة عن طلب تقرير شهري لكل سنة
        void SetMonthlyYear()
        {
            switch (DateTime.Now.Year)
            {
                case 2021:
                    MonthlyYear2021.IsChecked = true;
                    break;
                case 2022:
                    MonthlyYear2022.IsChecked = true;
                    break;
                case 2023:
                    MonthlyYear2023.IsChecked = true;
                    break;
                case 2024:
                    MonthlyYear2024.IsChecked = true;
                    break;

            }

        }


        //دالة من خلال يتم تحديد ما هي السنة التي يجب عمل تقرير شهري لها
        int GetMontlyReportYear()
        {

            int Value = 0;


            if (MonthlyYear2021.IsChecked == true)
            {
                Value = 2021;
            }
           else if (MonthlyYear2022.IsChecked == true)
            {
                Value = 2022;
            }
            else if (MonthlyYear2023.IsChecked == true)
            {
                Value = 2023;
            }
            else if (MonthlyYear2024.IsChecked == true)
            {
                Value = 2024;
            }

            return Value;

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

           



            EmplementSum(Transaction.Sum(i => i.Amount));



            var results = from table1 in Transaction.AsEnumerable()
                           join table2 in Accounts.AsEnumerable() on table1.IDAccount equals table2.AccountID
                           select new TransactionsViewModel
                           {

                             IDTransaction= table1.IDTransaction,
                               EnteredDate= table1.EnteredDate,
                               Amount= table1.Amount,
                               Notes= table1.Notes,
                               AccountName=table2.AccountName,
                               AccountColor=table2.AccountColor,
                               AccountType= table2.AccountType


                           };



            TransactionsViewModels = CL.ObjectConvertor.ConvertTransactionList(results);

            filter = TransactionsViewModels.ToList();


            DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));



            var CurrentMonth = results.ToList();

            CurrentMonth = CurrentMonth.Where(i => i.EnteredDate >= StartDate).ToList() ;
            CurrentMonth = CurrentMonth.Where(i => i.EnteredDate <= EndDate).ToList() ;

            EmplementSum(CurrentMonth.Sum(i => i.Amount));


            TransactionList.ItemsSource = CurrentMonth;

           


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


            CL.PassingParameter.MonthSummaryList = null;


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

                filter = filter.Where(i => i.EnteredDate.Year == GetMontlyReportYear()).ToList();



            }
            
            if (lblMonthName.Text != null)
            {
                
                DateTime StartDate = new DateTime(GetMontlyReportYear(), SelectedMonth.MonthID, 1);
                DateTime EndDate = new DateTime(GetMontlyReportYear(), SelectedMonth.MonthID, DateTime.DaysInMonth(GetMontlyReportYear(), SelectedMonth.MonthID));


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
                if (SortDate.IsChecked)
                {
                    filter = filter.OrderByDescending(i => i.EnteredDate).ToList();
                   
                }
                else if (SortAmount.IsChecked)
                {
                    filter = filter.OrderByDescending(i => i.Amount).ToList();
                }
                   
                

            }
            else if (Asc == false)
            {
                if (SortDate.IsChecked)
                {
                    filter = filter.OrderBy(i => i.EnteredDate).ToList(); 
                   
                }
               else if (SortAmount.IsChecked)
                {
                    filter = filter.OrderBy(i => i.Amount).ToList();

                }


                Asc = true;
                await btnSort.RotateTo(0, 500);
            }
           

            TransactionList.ItemsSource = CL.ObjectConvertor.ConvertTransactionList(filter);
        }




       IEnumerable<TransactionsViewModel> SummaryList ;
        private void SummaryReport_Clicked(object sender, EventArgs e)
        {
           

           
           

             SummaryList =  filter.GroupBy(i => i.AccountName)
                                       .Select(g => new TransactionsViewModel
                                       {

                                           AccountName=g.Key,
                                           AccountColor= g.FirstOrDefault().AccountColor,
                                           Amount = g.Select(l => l.Amount).Sum(),EnteredDate = new DateTime(GetMontlyReportYear(), 1, 1)
                                       });


            if (SortAmount.IsChecked)
            {
                if (Asc)
                {

                    SummaryList = SummaryList.OrderBy(i => i.Amount).ToList();

                }
                else if (Asc == false)
                {

                    SummaryList = SummaryList.OrderByDescending(i => i.Amount).ToList();

                }

            }




            TransactionList.ItemsSource = CL.ObjectConvertor.ConvertTransactionList(SummaryList);

            EmplementSum(CL.ObjectConvertor.ConvertTransactionList(SummaryList).Sum(i => i.Amount));

            SummaryListIn = SummaryList;

           
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

            var filterJustExpenses = filter.Where(i => i.AccountType == 1 && i.EnteredDate.Year==GetMontlyReportYear()).ToList();

            var q = from i in filterJustExpenses
                    group i by i.EnteredDate.ToString("MMMM", Lang) into grp
                    select new TransactionsViewModel 
                    { 
                        AccountName = grp.Key,
                        AccountColor= grp.FirstOrDefault().AccountColor, 
                        Amount =double.Parse( grp.Sum(i => i.Amount).ToString("0").Replace(" ","")),
                        EnteredDate = new DateTime(GetMontlyReportYear(), 1, 1)
                    };

            var ReportChart = from i in filterJustExpenses
                              group i by i.EnteredDate.ToString("MM", Lang) into grp
                    select new TransactionsViewModel
                    { 
                        AccountName = grp.Key, 
                        AccountColor = grp.FirstOrDefault().AccountColor,
                        Amount = double.Parse(grp.Sum(i => i.Amount).ToString("0").Replace(" ", "")) ,EnteredDate=new DateTime(GetMontlyReportYear(), 1,1)
                    };


            CL.PassingParameter.MonthSummaryList = ReportChart.ToList();


            TransactionList.ItemsSource = CL.ObjectConvertor.ConvertTransactionList(q);

            EmplementSum(CL.ObjectConvertor.ConvertTransactionList(q).Sum(i => i.Amount));

           

        }



        void ChangeSpanLayout(int SpanNumber)
        {

            var grid = new GridItemsLayout(ItemsLayoutOrientation.Vertical)
            {
                Span = SpanNumber,
            };
            TransactionList.SetValue(CollectionView.ItemsLayoutProperty, grid);
           
        }


        int SpanNumber = 1;
        private void btnLayout_Clicked(object sender, EventArgs e)
        {
            if (SpanNumber > 0)
            {
               
                ChangeSpanLayout(SpanNumber);
                if (SpanNumber >= 3)
                {
                    SpanNumber = 1;
                    return;
                }


                SpanNumber++;

            }
        }

        IEnumerable<TransactionsViewModel> SummaryListIn;
        private void SwipeItemView_Invoked(object sender, EventArgs e)
        {
            var button = (SwipeItemView)sender;
            var Check = button.CommandParameter as TransactionsViewModel;

            if (SummaryListIn!=null)
            {
                SummaryListIn = SummaryListIn.Where(i => i.AccountName != Check.AccountName);

                TransactionList.ItemsSource = CL.ObjectConvertor.ConvertTransactionList(SummaryListIn);

                EmplementSum(CL.ObjectConvertor.ConvertTransactionList(SummaryListIn).Sum(i => i.Amount));

               
            }

           
        }

        private void FiltlerViewallAccount_Clicked(object sender, EventArgs e)
        {
            filter = filter.Where(i => i.AccountName != "").ToList();

            filter = filter.Where(i => i.EnteredDate != null).ToList();
            TransactionList.ItemsSource = CL.ObjectConvertor.ConvertTransactionList(filter);

            EmplementSum(filter.Sum(i => i.Amount));

            CL.AnimationObject.AnimationHeightFrame(FrameFilter);
        }

        private void CustomDateInquery_Clicked(object sender, EventArgs e)
        {

            var CustomDate = filter;

            CustomDate = CustomDate.Where(i => i.EnteredDate >= CustomDateFrom.Date).ToList();
            CustomDate = CustomDate.Where(i => i.EnteredDate <= CustomDateTo.Date).ToList();


            if (lblAccountName.Text != null)
            {
                CustomDate = CustomDate.Where(i => i.AccountName == lblAccountName.Text).ToList();



            }




            CustomDate = CustomDate.Where(i => i.EnteredDate != null).ToList();

            CustomDate = CustomDate.OrderBy(i => i.EnteredDate).ToList();
            if (Asc == false)
            {
                CustomDate = CustomDate.OrderByDescending(i => i.EnteredDate).ToList();

            }


            TransactionList.ItemsSource = CL.ObjectConvertor.ConvertTransactionList(CustomDate);

            EmplementSum(CustomDate.Sum(i => i.Amount));

            CL.AnimationObject.AnimationHeightFrame(FrameFilter);






        }






    }
}