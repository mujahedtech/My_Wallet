using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace My_Wallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
        }


        //متغير من اجل حفظ اعدادات اللغة
      
        protected override void OnAppearing()
        {
            //Accounts= await CL.PassingParameter._connection.Table<Tables.Accounts>().ToListAsync();
            CL.PassingParameter.FirstLoad = true;


            bool LangSetting = new bool();

            if (CL.DataValidation.IsBool(Preferences.Get(CL.PassingParameter.LangStr, string.Empty)))
            {
                LangSetting = bool.Parse(Preferences.Get(CL.PassingParameter.LangStr, string.Empty));
                CL.PassingParameter.ArLanguage = LangSetting;
               
            }
        


         txtNote.Text = "Current Language is : "+Environment.NewLine+ (LangSetting?"Arabic":"English");

            CL.PassingParameter.FirstLoad = false;

            base.OnAppearing();
        }


        private void LanguagesChanged(object sender, CheckedChangedEventArgs e)
        {
            if (CL.PassingParameter.FirstLoad==false)
            {
                RadioButton image = (RadioButton)sender;

                int AccountIndex = int.Parse(image.ClassId);
                switch (AccountIndex)
                {
                    case 1:
                        Preferences.Set(CL.PassingParameter.LangStr, true.ToString());
                        break;

                    case 2:
                        Preferences.Set(CL.PassingParameter.LangStr, false.ToString());
                        break;

                }
            }

            Xamarin.Forms.Application.Current.MainPage = new MainPage();


        }




        public ObservableCollection<Tables.Accounts> tableAccounts = new ObservableCollection<Tables.Accounts>(); 
        


       
        private async void Button_Clicked(object sender, EventArgs e)
        {
            #region Create Table Account

            tableAccounts.Add(new Tables.Accounts { AccountID = 1, AccountType = 1, AccountColor = "#808000", AccountName = "car Supplies" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 2, AccountType = 1, AccountColor = "#008080", AccountName = "foods" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 3, AccountType = 1, AccountColor = "#008080", AccountName = "sweets" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 4, AccountType = 1, AccountColor = "#D3212D", AccountName = "Fuel" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 5, AccountType = 1, AccountColor = "#808080", AccountName = "Shawarma" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 6, AccountType = 1, AccountColor = "#2E5894", AccountName = "Citroen Loan" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 7, AccountType = 1, AccountColor = "#808000", AccountName = "Oil Engine Motor" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 8, AccountType = 1, AccountColor = "#808080", AccountName = "KFC" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 9, AccountType = 1, AccountColor = "#006A4E", AccountName = "Citroen Repair" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 10, AccountType = 1, AccountColor = "#808080", AccountName = "family" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 11, AccountType = 1, AccountColor = "#B0BF1A", AccountName = "Citroen Radiator" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 12, AccountType = 1, AccountColor = "#AB274F", AccountName = "fuel 95" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 13, AccountType = 1, AccountColor = "#808080", AccountName = "Sahar 600 Refund" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 14, AccountType = 1, AccountColor = "#008000", AccountName = "Eid Cash" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 15, AccountType = 1, AccountColor = "#007AA5", AccountName = "refill zain cash" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 16, AccountType = 1, AccountColor = "#008000", AccountName = "Cleaner Fuel" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 17, AccountType = 1, AccountColor = "#800000", AccountName = "Clothes" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 18, AccountType = 1, AccountColor = "#800000", AccountName = "petty cash" });
            tableAccounts.Add(new Tables.Accounts { AccountID = 19, AccountType = 2, AccountColor = "#007FFF", AccountName = "Citroen Registration " });
            tableAccounts.Add(new Tables.Accounts { AccountID = 20, AccountType = 2, AccountColor = "#008080", AccountName = "Hosaam Xaml", });



            await CL.PassingParameter._connection.DeleteAllAsync<Tables.Accounts>();


            await CL.PassingParameter._connection.InsertAllAsync(tableAccounts);


         





            #endregion
        }
        public List<Tables.Transactions> Transactions;


        List<Tables.Accounts> Accounts;
        private async void Button_Clicked_1(object sender, EventArgs e)
        {




            await CL.PassingParameter._connection.DeleteAllAsync<Tables.Transactions>();


            Transactions = new List<Tables.Transactions>();




            #region Create Transaction from firebase

            if (Accounts.Where(i => i.AccountName == "car Supplies").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "car Supplies").FirstOrDefault().AccountID, Amount = double.Parse("7"), EnteredDate = DateTime.Parse("2021-02-02T22:10:45.793493"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("1"), EnteredDate = DateTime.Parse("2021-02-02T22:11:06.095841"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "sweets").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "sweets").FirstOrDefault().AccountID, Amount = double.Parse("1"), EnteredDate = DateTime.Parse("2021-02-03T18:02:57.014547"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Shawarma").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Shawarma").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-02-03T18:05:11.850789"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("30"), EnteredDate = DateTime.Parse("2021-02-04T17:15:24.029942"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("0.7"), EnteredDate = DateTime.Parse("2021-02-06T22:12:31.578566"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-02-09T10:06:15.028493"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Oil Engine Motor").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Oil Engine Motor").FirstOrDefault().AccountID, Amount = double.Parse("17.5"), EnteredDate = DateTime.Parse("2021-02-11T20:07:24.952109"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Shawarma").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Shawarma").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-02-12T12:57:55.823547"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-02-12T18:59:24.039623"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "KFC").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "KFC").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-02-16T11:56:25.813386"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("120"), EnteredDate = DateTime.Parse("2021-02-16T11:56:53.948293"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Loan").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Loan").FirstOrDefault().AccountID, Amount = double.Parse("200"), EnteredDate = DateTime.Parse("2021-02-16T11:57:21.081341"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("15"), EnteredDate = DateTime.Parse("2021-02-16T21:01:48.364044"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("1"), EnteredDate = DateTime.Parse("2021-02-16T21:01:53.502182"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("0.5"), EnteredDate = DateTime.Parse("2021-02-20T18:41:11.280658"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Shawarma").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Shawarma").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-02-23T22:01:19.229577"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("25"), EnteredDate = DateTime.Parse("2021-02-24T18:08:50.008731"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-02-27T21:50:25.74229"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("1"), EnteredDate = DateTime.Parse("2021-02-27T21:50:30.238341"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Shawarma").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Shawarma").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-03-02T22:11:04.552977"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("27"), EnteredDate = DateTime.Parse("2021-03-05T09:20:23.639501"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "family").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "family").FirstOrDefault().AccountID, Amount = double.Parse("8"), EnteredDate = DateTime.Parse("2021-03-05T09:20:50.373721"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Radiator").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Radiator").FirstOrDefault().AccountID, Amount = double.Parse("40"), EnteredDate = DateTime.Parse("2021-03-09T21:40:56.633291"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-03-11T19:40:06.555838"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "sweets").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "sweets").FirstOrDefault().AccountID, Amount = double.Parse("15"), EnteredDate = DateTime.Parse("2021-03-11T19:40:12.691938"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Shawarma").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Shawarma").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-03-11T19:40:19.250905"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "family").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "family").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-03-11T19:40:24.565326"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Shawarma").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Shawarma").FirstOrDefault().AccountID, Amount = double.Parse("1"), EnteredDate = DateTime.Parse("2021-03-13T17:27:43.312132"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "family").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "family").FirstOrDefault().AccountID, Amount = double.Parse("2"), EnteredDate = DateTime.Parse("2021-03-13T17:27:47.972268"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("230"), EnteredDate = DateTime.Parse("2021-03-15T17:32:05.442318"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "family").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "family").FirstOrDefault().AccountID, Amount = double.Parse("5"), EnteredDate = DateTime.Parse("2021-03-15T17:32:09.195974"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-03-19T16:20:28.896053"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-03-25T16:50:05.539666"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Oil Engine Motor").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Oil Engine Motor").FirstOrDefault().AccountID, Amount = double.Parse("15"), EnteredDate = DateTime.Parse("2021-03-29T23:48:44.96093"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-04-04T17:15:24.456186"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Loan").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Loan").FirstOrDefault().AccountID, Amount = double.Parse("200"), EnteredDate = DateTime.Parse("2021-04-06T22:35:36.276356"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "family").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "family").FirstOrDefault().AccountID, Amount = double.Parse("15"), EnteredDate = DateTime.Parse("2021-04-09T03:34:33.241908"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("15"), EnteredDate = DateTime.Parse("2021-04-13T08:03:50.631357"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Shawarma").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Shawarma").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-04-13T08:03:53.88948"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("15"), EnteredDate = DateTime.Parse("2021-04-19T08:04:26.507289"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "car Supplies").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "car Supplies").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-04-20T08:13:59.452424"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-04-29T01:28:55.123529"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("58"), EnteredDate = DateTime.Parse("2021-04-29T01:29:07.542853"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-05-05T17:05:47.050295"), Notes = "بنزيين" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Loan").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Loan").FirstOrDefault().AccountID, Amount = double.Parse("200"), EnteredDate = DateTime.Parse("2021-05-06T16:41:43.810432"), Notes = "دفعة 3 شهر واصل 600" });
            }
            if (Accounts.Where(i => i.AccountName == "fuel 95").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "fuel 95").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-05-09T16:54:09.447312"), Notes = "بنزين " });
            }
            if (Accounts.Where(i => i.AccountName == "Sahar 600 Refund").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Sahar 600 Refund").FirstOrDefault().AccountID, Amount = double.Parse("25"), EnteredDate = DateTime.Parse("2021-05-10T11:52:01.559733"), Notes = "شهر 3" });
            }
            if (Accounts.Where(i => i.AccountName == "Sahar 600 Refund").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Sahar 600 Refund").FirstOrDefault().AccountID, Amount = double.Parse("25"), EnteredDate = DateTime.Parse("2021-05-10T11:52:24.25747"), Notes = "شهر 4" });
            }
            if (Accounts.Where(i => i.AccountName == "Sahar 600 Refund").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Sahar 600 Refund").FirstOrDefault().AccountID, Amount = double.Parse("25"), EnteredDate = DateTime.Parse("2021-05-10T11:52:35.061059"), Notes = "شهر 5" });
            }
            if (Accounts.Where(i => i.AccountName == "Eid Cash").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Eid Cash").FirstOrDefault().AccountID, Amount = double.Parse("60"), EnteredDate = DateTime.Parse("2021-05-14T12:01:45.914749"), Notes = "10 مجدولين\n10 راما\n20 ماما\n20 روان" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-05-17T18:02:10.00471"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "refill zain cash").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "refill zain cash").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-05-19T00:28:12.721665"), Notes = "شحن بطاقة" });
            }
            if (Accounts.Where(i => i.AccountName == "family").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "family").FirstOrDefault().AccountID, Amount = double.Parse("8"), EnteredDate = DateTime.Parse("2021-05-19T00:28:26.906779"), Notes = "امي شحن بطاقة 8 دينار" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("15"), EnteredDate = DateTime.Parse("2021-05-23T21:53:16.060049"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "KFC").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "KFC").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-05-23T21:53:36.615748"), Notes = "وجبة بروستد جريل هاوس" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-05-26T21:29:25.639555"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "fuel 95").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "fuel 95").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-06-02T08:26:22.798283"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Cleaner Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Cleaner Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-06-02T08:27:02.319702"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-06-07T17:38:52.915228"), Notes = "طلعة اربد تصليح قشاط" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("13"), EnteredDate = DateTime.Parse("2021-06-07T17:39:10.978432"), Notes = "سعر قشاط و أجور تركيب" });
            }
            if (Accounts.Where(i => i.AccountName == "Shawarma").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Shawarma").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-06-07T17:39:28.443016"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Shawarma").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Shawarma").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-06-07T17:39:48.201656"), Notes = "غداء طلعة اربد " });
            }
            if (Accounts.Where(i => i.AccountName == "Clothes").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Clothes").FirstOrDefault().AccountID, Amount = double.Parse("40"), EnteredDate = DateTime.Parse("2021-06-07T17:41:07.322701"), Notes = "شراء أحذية عدد 3" });
            }
            if (Accounts.Where(i => i.AccountName == "Clothes").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Clothes").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-06-07T17:41:45.369171"), Notes = "بنطول كتان عدد 2" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Loan").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Loan").FirstOrDefault().AccountID, Amount = double.Parse("400"), EnteredDate = DateTime.Parse("2021-06-07T17:42:53.274704"), Notes = "دفعه عن شهر 5 و جمعية " });
            }
            if (Accounts.Where(i => i.AccountName == "Sahar 600 Refund").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Sahar 600 Refund").FirstOrDefault().AccountID, Amount = double.Parse("25"), EnteredDate = DateTime.Parse("2021-06-09T12:34:27.398907"), Notes = "دفعه جمعية " });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-06-12T16:44:57.25857"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("5"), EnteredDate = DateTime.Parse("2021-06-12T16:45:54.163052"), Notes = "بابريكا عدد 3\nعلبة جبنة\nخبز توست\nعلبة حمص" });
            }
            if (Accounts.Where(i => i.AccountName == "petty cash").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "petty cash").FirstOrDefault().AccountID, Amount = double.Parse("9"), EnteredDate = DateTime.Parse("2021-06-12T16:46:50.952442"), Notes = "خط 0790931724 إعادة اشتراك بعد فصل كلي" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-06-14T16:53:02.16449"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-06-18T00:05:22.793586"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-06-22T12:56:31.375153"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-06-23T15:56:23.01255"), Notes = "شراء اسلاك تشريك سيارة" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("15"), EnteredDate = DateTime.Parse("2021-06-24T16:54:30.330308"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Sahar 600 Refund").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Sahar 600 Refund").FirstOrDefault().AccountID, Amount = double.Parse("25"), EnteredDate = DateTime.Parse("2021-07-05T15:22:06.251537"), Notes = "عن شهر 6" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Loan").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Loan").FirstOrDefault().AccountID, Amount = double.Parse("200"), EnteredDate = DateTime.Parse("2021-07-05T20:53:06.403169"), Notes = "دفعه شهر 6\nو 40 دينار من امي تسكير عجز من خلال سحوباتها" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("15"), EnteredDate = DateTime.Parse("2021-07-08T17:21:50.22504"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("25"), EnteredDate = DateTime.Parse("2021-07-09T16:05:42.481699"), Notes = "طلعة ع روان" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("50"), EnteredDate = DateTime.Parse("2021-07-18T09:36:34.66283"), Notes = "دنمو جديد" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("5"), EnteredDate = DateTime.Parse("2021-07-18T09:37:02.468747"), Notes = "شحن غاز" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("15"), EnteredDate = DateTime.Parse("2021-07-18T09:37:36.655081"), Notes = "تغير صحن مياه اماني لماتور " });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-07-18T09:39:42.699037"), Notes = "بنزين طلعة تصليح" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-07-18T09:40:05.701392"), Notes = "بنزين ترويحة" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("25"), EnteredDate = DateTime.Parse("2021-07-18T09:40:28.525447"), Notes = "تعبئة بنزين لغاية العيد" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-07-20T21:00:38.259148"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Eid Cash").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Eid Cash").FirstOrDefault().AccountID, Amount = double.Parse("40"), EnteredDate = DateTime.Parse("2021-07-22T13:26:10.364906"), Notes = "10 مجد\n10 راما\n10 امي\n10 روان" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("7"), EnteredDate = DateTime.Parse("2021-07-26T23:47:24.376281"), Notes = "طلعة اربد جيوب" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Registration").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Registration").FirstOrDefault().AccountID, Amount = double.Parse("81"), EnteredDate = DateTime.Parse("2021-07-29T00:17:08.878948"), Notes = "رسوم تأمين " });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Registration").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Registration").FirstOrDefault().AccountID, Amount = double.Parse("83"), EnteredDate = DateTime.Parse("2021-07-29T00:17:22.093353"), Notes = "رسوم ترخيص" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Registration").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Registration").FirstOrDefault().AccountID, Amount = double.Parse("35"), EnteredDate = DateTime.Parse("2021-07-29T00:17:29.151083"), Notes = "مخالفات" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-07-30T23:04:12.065229"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("1"), EnteredDate = DateTime.Parse("2021-08-01T18:30:30.375383"), Notes = "بنشر" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("1.5"), EnteredDate = DateTime.Parse("2021-08-01T18:30:54.433852"), Notes = "2 فلافل سوبر\n1 ميرندا\n1 كيك" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-08-02T08:06:23.404748"), Notes = "بنزين" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("1.2"), EnteredDate = DateTime.Parse("2021-08-03T22:11:15.276698"), Notes = "ساندوش فلافل و نقانق" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("1"), EnteredDate = DateTime.Parse("2021-08-03T22:11:24.647584"), Notes = "شغلات زاكية" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-08-05T16:45:02.492399"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Loan").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Loan").FirstOrDefault().AccountID, Amount = double.Parse("200"), EnteredDate = DateTime.Parse("2021-08-07T17:24:02.323727"), Notes = "دفعه شهر 7 /2021" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-08-08T17:08:48.504523"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-08-10T19:57:23.877372"), Notes = "بنزين طلعة اربد تصليح" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("50"), EnteredDate = DateTime.Parse("2021-08-10T19:57:46.897909"), Notes = "شراء طرمبة بنزين" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("25"), EnteredDate = DateTime.Parse("2021-08-10T19:58:03.645491"), Notes = "شراء كبك دعسة" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-08-10T19:58:17.886644"), Notes = "تعبئة بنزين فحص طرمبة" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-08-10T19:58:30.360194"), Notes = "شاورما دبل" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-08-11T08:16:52.181108"), Notes = "بنزبن" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-08-12T16:29:15.606056"), Notes = "شاوروما" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-08-15T21:05:55.172462"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "family").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "family").FirstOrDefault().AccountID, Amount = double.Parse("15"), EnteredDate = DateTime.Parse("2021-08-16T22:25:14.613668"), Notes = "مصاريف غداء للبيت" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-08-17T08:41:34.563964"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("5"), EnteredDate = DateTime.Parse("2021-08-19T23:33:06.188491"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "family").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "family").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-08-21T08:48:40.051374"), Notes = "غداء للبيت " });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-08-21T17:10:25.065811"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("11"), EnteredDate = DateTime.Parse("2021-08-25T21:24:09.636309"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-09-01T21:09:12.746935"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("0.5"), EnteredDate = DateTime.Parse("2021-09-02T17:37:07.770009"), Notes = "ساندوش فلافل" });
            }
            if (Accounts.Where(i => i.AccountName == "Sahar 600 Refund").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Sahar 600 Refund").FirstOrDefault().AccountID, Amount = double.Parse("25"), EnteredDate = DateTime.Parse("2021-08-03T08:02:35.193256"), Notes = "دفعه شهر 7" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-09-04T17:17:06.829425"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("1"), EnteredDate = DateTime.Parse("2021-09-05T17:11:40.129866"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-09-06T21:37:31.456828"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "foods").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "foods").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-09-08T17:59:18.979563"), Notes = "ساندوش فلافل و مكسرات" });
            }
            if (Accounts.Where(i => i.AccountName == "Sahar 600 Refund").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Sahar 600 Refund").FirstOrDefault().AccountID, Amount = double.Parse("25"), EnteredDate = DateTime.Parse("2021-09-11T09:49:53.657286"), Notes = "جمعية شهر 8-2021" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-09-13T20:18:38.955436"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-09-15T21:06:26.088313"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("350"), EnteredDate = DateTime.Parse("2021-09-21T19:04:11.779231"), Notes = "تصليح جير" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("15"), EnteredDate = DateTime.Parse("2021-09-21T19:04:21.725599"), Notes = "فراوين جير" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("20"), EnteredDate = DateTime.Parse("2021-09-21T19:04:27.694506"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-09-28T07:32:55.400642"), Notes = "بنزين طلعة اربد تصليح جير" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-09-28T07:33:05.54645"), Notes = "تعبئة عادية" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-09-29T19:45:03.642633"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Hosaam Xaml").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Hosaam Xaml").FirstOrDefault().AccountID, Amount = double.Parse("110"), EnteredDate = DateTime.Parse("2021-10-03T22:25:08.030564"), Notes = "110 دولار حوالة - 78 دينار" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-10-05T17:36:30.458767"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-10-06T21:10:50.900723"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("15"), EnteredDate = DateTime.Parse("2021-10-07T19:06:39.603694"), Notes = "غيار زيت" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("18"), EnteredDate = DateTime.Parse("2021-10-07T19:07:06.811579"), Notes = "تظليل" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("3"), EnteredDate = DateTime.Parse("2021-10-07T19:07:17.548385"), Notes = "غسيل" });
            }
            if (Accounts.Where(i => i.AccountName == "Hosaam Xaml").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Hosaam Xaml").FirstOrDefault().AccountID, Amount = double.Parse("200"), EnteredDate = DateTime.Parse("2021-10-09T10:32:11.003792"), Notes = "200 دولار - 135 دينار" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-10-09T18:50:56.981627"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Sahar 600 Refund").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Sahar 600 Refund").FirstOrDefault().AccountID, Amount = double.Parse("25"), EnteredDate = DateTime.Parse("2021-10-10T14:07:32.876019"), Notes = "جمعية عن شهر 9" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Loan").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Loan").FirstOrDefault().AccountID, Amount = double.Parse("300"), EnteredDate = DateTime.Parse("2021-10-11T14:19:23.113177"), Notes = "دفعه" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-10-12T17:15:26.022218"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-10-16T17:19:50.442969"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("15"), EnteredDate = DateTime.Parse("2021-10-19T13:02:33.569391"), Notes = "طلعة تصليح" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Repair").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Repair").FirstOrDefault().AccountID, Amount = double.Parse("90"), EnteredDate = DateTime.Parse("2021-10-19T13:02:55.395296"), Notes = "حستس أكسجين و بواجي و كويل" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-10-19T13:03:06.217587"), Notes = "ترويحة من عمان " });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-10-23T17:10:51.650735"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("5"), EnteredDate = DateTime.Parse("2021-10-27T17:15:26.953081"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-10-30T07:46:56.07984"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("10"), EnteredDate = DateTime.Parse("2021-11-02T17:28:46.219733"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Fuel").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Fuel").FirstOrDefault().AccountID, Amount = double.Parse("29"), EnteredDate = DateTime.Parse("2021-11-06T20:29:53.349826"), Notes = "Empty" });
            }
            if (Accounts.Where(i => i.AccountName == "Citroen Loan").ToList().Count > 0)
            {
                Transactions.Add(new Tables.Transactions { IDAccount = Accounts.Where(i => i.AccountName == "Citroen Loan").FirstOrDefault().AccountID, Amount = double.Parse("200"), EnteredDate = DateTime.Parse("2021-11-07T22:07:18.530827"), Notes = "دفعه عن شهر 11" });
            }

            #endregion





            await CL.PassingParameter._connection.InsertAllAsync(Transactions);
        }
    }
}