using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace My_Wallet.Views
{

    public class NumPad 
    {
        public int ID { get; set; }
        public string Header { get; set; }


    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterExpense : ContentPage
    {



        protected override bool OnBackButtonPressed()
        {
            bool Value = true;

            if (FrameNotes.IsVisible == false)
            {
                Value = base.OnBackButtonPressed();
            }

            if (FrameNotes.IsVisible == true)
            {
                CL.AnimationObject.EndAnimationFrame(FrameNotes);

            }

            return Value;
        }

        public Command TouchCommand { get; }

        public Command TouchLong { get; }


        public EnterExpense()
        {
            InitializeComponent();

            TouchCommand = new Command(() => LastClear());

            TouchLong = new Command(() =>


          Clear()

            ) ;

            BindingContext = this;
        }
        void LastClear()
        {
            if (Amount.Length > 0) txtAmount.Text = Amount= Amount.Remove(Amount.Length - 1);
        }
        void Clear()
        {
            Amount = "";
            txtAmount.Text = Amount;
        }

        List<NumPad> NumPadView = new List<NumPad>();




        List<Tables.Accounts> Accounts;
        List<Tables.Transactions> Transaction;

         void PrepairAccount(bool Distinct=false)
        {

            IEnumerable<TransactionsViewModel> AccountList;

          
            var results = from table1 in Transaction.AsEnumerable()
                           join table2 in Accounts.AsEnumerable() on table1.IDAccount equals table2.AccountID
                           select new TransactionsViewModel
                           {

                               IDTransaction = table1.IDTransaction,
                               EnteredDate = table1.EnteredDate,
                               Amount = table1.Amount,
                               Notes = table1.Notes,
                               AccountName = table2.AccountName,
                               AccountColor = table2.AccountColor,
                               AccountType = table2.AccountType


                           };

            if (Distinct == false)
            {
                AccountList=results;
            }

            var DistinctAccount = results.GroupBy(i => i.AccountName)
                                       .Select(g => new TransactionsViewModel
                                       {

                                           AccountName = g.Key,
                                           AccountColor = g.FirstOrDefault().AccountColor,
                                           Amount = g.Select(l => l.Amount).Sum()
                                       });


            

        }

        protected override async void OnAppearing()
        {
            Accounts = await CL.PassingParameter._connection.Table<Tables.Accounts>().ToListAsync();

            Transaction = await CL.PassingParameter._connection.Table<Tables.Transactions>().ToListAsync();


            //PrepairAccount();

            AccountList.ItemsSource = Accounts;






            NumPadView.Add(new NumPad { ID = 1, Header = "1" });
            NumPadView.Add(new NumPad { ID = 1, Header = "2" });
            NumPadView.Add(new NumPad { ID = 1, Header = "3" });
            NumPadView.Add(new NumPad { ID = 1, Header = "4" });
            NumPadView.Add(new NumPad { ID = 1, Header = "5" });
            NumPadView.Add(new NumPad { ID = 1, Header = "6" });
            NumPadView.Add(new NumPad { ID = 1, Header = "7" });
            NumPadView.Add(new NumPad { ID = 1, Header = "8" });
            NumPadView.Add(new NumPad { ID = 1, Header = "9" });
            NumPadView.Add(new NumPad { ID = 1, Header = "." });
            NumPadView.Add(new NumPad { ID = 1, Header = "0" });
            NumPadView.Add(new NumPad { ID = 1, Header = "Ok" });



            NumPadList.ItemsSource = NumPadView;



            base.OnAppearing();
        }

        string SelectAccount="";

        int IdAccount = new int();
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var tapEventArgs = (TappedEventArgs)e;
            var parameter = (Tables.Accounts)tapEventArgs.Parameter;

            SelectAccount = parameter.AccountName;
            IdAccount = parameter.AccountID;

            txtAccount.Text = SelectAccount;
               
        }






        string Amount = "";

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var tapEventArgs = (TappedEventArgs)e;
            var parameter = (NumPad)tapEventArgs.Parameter;

          


            if (Amount.Length>=0)
            {
                if (parameter.Header==".")
                {
                    if (Amount.Contains("."))
                    {
                        return;
                    }
                }
                if (parameter.Header == "Ok")
                {

                    if (CL.DataValidation.IsDouble(Amount))
                    {
                        if (SelectAccount.Length>0)
                        {
                            CL.AnimationObject.StartAnimationFrame(FrameNotes);
                            txtNote.Content = "Empty";
                            return;
                        }
                       
                    }
                    return;

                }

                Amount += parameter.Header;
                txtAmount.Text = Amount;
            }


        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            
        }

        private void DeleteAccount_Invoked(object sender, EventArgs e)
        {
            if (AccountList.IsVisible)
            {
                AccountList.IsVisible = false;
                return;
            }
            AccountList.IsVisible = true;
        }

        private void NameCloseNote_Invoked(object sender, EventArgs e)
        {
            CL.AnimationObject.EndAnimationFrame(FrameNotes);

            if (CL.DataValidation.IsDouble(Amount))
            {

                var item = new Tables.Transactions { IDAccount = IdAccount, Amount = double.Parse(Amount), EnteredDate = txtSelectedDate.Date, Notes = txtNote.Content.ToString() };

                CL.PassingParameter._connection.InsertAsync(item);

                Amount = "";
                txtAmount.Text = Amount;
                txtAccount.Text = "";

                txtNote.Content = "Empty";
                SelectAccount = "";

            }
           

        }
    }
}