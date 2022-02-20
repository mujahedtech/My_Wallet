using Microcharts;
using My_Wallet.Views;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace My_Wallet
{
    public partial class MainPage : ContentPage
    {

      
        public MainPage()
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




        async void CreateMainReport(int Year=0)
        {
            if (Year==0)
            {
                Year = DateTime.Now.Year;
            }
            List<ChartEntry> entries = new List<ChartEntry>();

            ObservableCollection<TransactionsViewModel> TransactionsViewModels = new ObservableCollection<TransactionsViewModel>();

            var Accounts = await CL.PassingParameter._connection.Table<Tables.Accounts>().ToListAsync();

            var Transaction = await CL.PassingParameter._connection.Table<Tables.Transactions>().ToListAsync();



            //Just First Time
            int PinAccountIndex = 0;
            if (CL.DataValidation.IsDouble(Preferences.Get(CL.PassingParameter.PinHomeScreenID, string.Empty)))
            {
                PinAccountIndex =int.Parse( Preferences.Get(CL.PassingParameter.PinHomeScreenID, string.Empty));
                lblPinAccountName.Text = Accounts.Where(i => i.AccountID == PinAccountIndex ).FirstOrDefault().AccountName;

                //lblPinAccountName.BackgroundColor = Color.FromHex(CL.PassingParameter.CreateRandomColor());

                lblPinAccountName.TextColor =Color.FromHex(CL.PassingParameter.CreateRandomColor());

            }

            




            Transaction = Transaction.Where(i => i.IDAccount == PinAccountIndex).ToList();

            var results = (from table1 in Transaction.AsEnumerable()
                           join table2 in Accounts.AsEnumerable() on table1.IDAccount equals table2.AccountID
                           select new TransactionsViewModel
                           {

                               IDTransaction = table1.IDTransaction,
                               EnteredDate = table1.EnteredDate,
                               Amount = table1.Amount,
                               Notes = table1.Notes,
                               AccountName = table2.AccountName,
                               AccountColor = table2.AccountColor


                           });

            results = results.Where(i => i.EnteredDate.Year == Year);

            TransactionsViewModels = CL.ObjectConvertor.ConvertTransactionList(results);

            

           var filter = TransactionsViewModels.ToList();


            CultureInfo Lang = new CultureInfo("en-US");
            if (CL.PassingParameter.ArLanguage == true)
            {
                Lang = new CultureInfo("ar-Jo");
            }

            var q = from i in filter
                    group i by i.EnteredDate.ToString("MM") into grp
                    select new TransactionsViewModel { AccountName = grp.Key, AccountColor = grp.FirstOrDefault().AccountColor, Amount = double.Parse(grp.Sum(i => i.Amount).ToString("0").Replace(" ", "")) };


            q=q.OrderByDescending(i => i.EnteredDate).ToList();

            var Monthreport = CL.ObjectConvertor.ConvertTransactionList(q);


            int ChartNumberView = Monthreport.Count;

            //if (ChartNumberView>8)
            //{
            //    ChartNumberView = 12;
            //}

            for (int i = 0; i < ChartNumberView; i++)
            {
                string Color =CL.PassingParameter. CreateRandomColor();
                entries.Add(new ChartEntry(int.Parse(Monthreport[i].Amount.ToString("0")))
                {
                    Label = Monthreport[i].AccountName,
                    ValueLabel = Monthreport[i].Amount.ToString("0$"),
                    Color = SKColor.Parse(Color),
                    TextColor= SKColor.Parse(Color),
                    ValueLabelColor= SKColor.Parse(Color)
                });
            }


            //chartViewBar.Chart = new DonutChart { Entries = entries, ValueLabelOrientation = Orientation.Horizontal, LabelTextSize = 30 };
            chartViewBar.Chart = new LineChart { Entries = entries, LabelTextSize = 30, ValueLabelOrientation = Orientation.Horizontal, LabelOrientation = Orientation.Horizontal};
            //chartViewBar.Chart = new RadialGaugeChart { Entries = entries, LabelTextSize = 30,  };

            FirstRun = true;

        }


      

        protected override  void OnAppearing()
        {


            CreateMainReport();

            StartAnimationButton(btnAccountReport, "D");
            StartAnimationButton(btnAccounts,"L");
            StartAnimationButton(btnDatabaseManage, "L");
            StartAnimationButton(btnNewexpense, "R");
            StartAnimationButton(btnSettings, "R");


            //StartAnimationFrame(lblPinAccountName);
            //StartAnimati/*o*/nButton(btnAccountReport);


            //StartAnimationChart();




            base.OnAppearing();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
           
           
        }

        private async void StartAnimationChart()
        {
            while (true)
            {

                await Task.Delay(10000);

                uint timeout = 2000;

                chartViewBar.RotationX = 0;

                await chartViewBar.RotateXTo(-360, timeout, Easing.Linear);


                chartViewBar.RotationX = 0;


            }
        }

        private async void StartAnimation(Button button)
        {
            while (true)
            {

                await Task.Delay(10000);

                uint timeout = 2000;

                button.RotationX = 0;

                await button.RotateXTo(-360, timeout, Easing.Linear);
               


                await button.FadeTo(.7, 1000);
                await button.FadeTo(1, 1000);

              

                button.RotationX = 0;
                 

            }
        }

        private async void StartAnimationFrame(Label button)
        {
            while (true)
            {

                await Task.Delay(10000);

                //uint timeout = 2000;

                //button.RotationY = 0;

                //await button.RotateYTo(-360, timeout, Easing.Linear);

                //button.RotationY = 0;

                await button.ScaleTo(1.5, 1000, Easing.Linear);
                await button.ScaleTo(1, 1000, Easing.Linear);


            }
        }

        private async void StartAnimationButton(Button button,string Direction)
        {
            //while (true)
            //{
            //    int timeout = 10000;
            //    uint During = 1000;

            //    if (Direction=="R")
            //    {
            //        await Task.Delay(timeout);

            //        await button.FadeTo(.7, 1000);
            //        await button.FadeTo(1, 1000);

            //        await button.TranslateTo(100, 0, During, Easing.BounceOut);
            //        await button.TranslateTo(0, 0);
            //    }
            //    if (Direction == "L")
            //    {
            //        await Task.Delay(timeout);

            //        await button.FadeTo(.7, 1000);
            //        await button.FadeTo(1, 1000);

            //        await button.TranslateTo(-100, 0, During, Easing.BounceOut);
            //        await button.TranslateTo(0, 0);
            //    }
            //    if (Direction == "D")
            //    {
            //        await Task.Delay(timeout);

            //        await button.FadeTo(.7, 1000);
            //        await button.FadeTo(1, 1000);

            //        await button.TranslateTo(0, 100, During, Easing.BounceOut);
            //        await button.TranslateTo(0, 0);
            //    }




            //}
        }



        private async void MainButtonClick(object sender, EventArgs e)
        {
            Button image = (Button)sender;

            
            int AccountIndex =int.Parse( image.ClassId);
            switch (AccountIndex)
            {
                case 0:
                    await Navigation.PushModalAsync(new Views.ManageAccounts());

                    break;

                case 1:
                    await Navigation.PushModalAsync(new Views.SettingPage());
                    break;
                case 2:
                    await Navigation.PushModalAsync(new Views.EnterExpense());
                    break;
                case 3:
                    await Navigation.PushModalAsync(new Views.ViewAccounts());
                    break;
                case 4:
                    await Navigation.PushModalAsync(new Views.ServerManage());
                    break;

            }
        }
        public bool FirstRun = false;
        private void MonthlyMainAccountReport(object sender, CheckedChangedEventArgs e)
        {
            if (FirstRun)
            {
                CreateMainReport(GetMontlyReportYear());
            }
           
        }
    }
}
