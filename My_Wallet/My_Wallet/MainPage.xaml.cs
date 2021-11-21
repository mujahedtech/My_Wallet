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

          
        }



       
        async void CreateFuelReport()
        {
            List<ChartEntry> entries = new List<ChartEntry>();

            ObservableCollection<TransactionsViewModel> TransactionsViewModels = new ObservableCollection<TransactionsViewModel>();

            var Accounts = await CL.PassingParameter._connection.Table<Tables.Accounts>().ToListAsync();

            var Transaction = await CL.PassingParameter._connection.Table<Tables.Transactions>().ToListAsync();

            int PinAccountIndex = 0;
            if (CL.DataValidation.IsDouble(Preferences.Get(CL.PassingParameter.PinHomeScreenID, string.Empty)))
            {
                PinAccountIndex =int.Parse( Preferences.Get(CL.PassingParameter.PinHomeScreenID, string.Empty));
                lblPinAccountName.Text = Accounts.Where(i => i.AccountID == PinAccountIndex).FirstOrDefault().AccountName;

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
       


            for (int i = 0; i < Monthreport.Count; i++)
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
            chartViewBar.Chart = new BarChart { Entries = entries, LabelTextSize = 30, ValueLabelOrientation = Orientation.Horizontal, LabelOrientation = Orientation.Horizontal};
            //chartViewBar.Chart = new RadialGaugeChart { Entries = entries, LabelTextSize = 30,  };

        }


      

        protected override  void OnAppearing()
        {
           

            CreateFuelReport();

            StartAnimation(btnAccountReport);
            StartAnimation(btnAccounts);
            StartAnimation(btnDatabaseManage);
            StartAnimation(btnNewexpense);
            StartAnimation(btnSettings);


            StartAnimationFrame(FrameHeader);


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

        private async void StartAnimationFrame(Frame button)
        {
            while (true)
            {

                await Task.Delay(10000);

                uint timeout = 2000;

                button.RotationY = 0;

                await button.RotateYTo(-360, timeout, Easing.Linear);

                button.RotationY = 0;


            }
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
    }
}
