using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace My_Wallet.Views
{

  
    public class TableAccountView
    {

        public int AccountID { get; set; }
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

           

            //BindingContext = this;

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


                var ItemSelected = tableAccountViews.Where(X => X.AccountName == SelectAccountName).FirstOrDefault();
                if (ItemSelected != null)
                {
                    
                       
                    int IndexItem = tableAccountViews.IndexOf(tableAccountViews.Where(X => X.AccountID == GetIDAccountType()).FirstOrDefault());
                    string  AccountTypeName= AccountsType.Where(i => i.TypeID == GetIDAccountType()).FirstOrDefault().TypeName;

                    tableAccountViews[IndexItem].AccountType = AccountTypeName;

                    tableAccountViews[IndexItem].AccountName = txtAccount.Content.ToString();


                    CL.PassingParameter._connection.UpdateAsync(new Tables.Accounts { AccountID= ItemSelected .AccountID,AccountColor= ItemSelected .AccountColor,AccountName= txtAccount.Content.ToString(),AccountType= GetIDAccountType() });
                    UserSelectAccountType = false;

                }
               else if(ItemSelected == null)
                {
                    string AccountName = txtAccount.Content.ToString();
                    if (AccountName.Length>0 )
                    {
                        if (GetIDAccountType() != 0)
                        {
                            Tables.Accounts item = new Tables.Accounts { AccountColor = "Dodgerblue", AccountName = txtAccount.Content.ToString(), AccountType = GetIDAccountType() };

                            TableAccountView itemview = new TableAccountView { AccountID = tableAccountViews.Count + 1, AccountColor = "Dodgerblue", AccountName = txtAccount.Content.ToString(), AccountType = AccountsType.Where(i => i.TypeID == GetIDAccountType()).FirstOrDefault().TypeName };

                            tableAccountViews.Add(itemview);
                            CL.PassingParameter._connection.InsertAsync(item);
                        }
                        
                    }
                   
                }

                CL.AnimationObject.EndAnimationFrame(FrameNewAccount);


            }

           


            return Value;
        }



        int GetIDAccountType()
        {
            int Value = 0;
            if (btnExpenseType.IsChecked)
            {
                Value = 1;
            }
            if (btnGroupType.IsChecked)
            {
                Value = 2;
            }
            if (btnStatementType.IsChecked)
            {
                Value = 3;
            }

            return Value;
        }


        public ObservableCollection<Tables.Accounts> tableAccounts = new ObservableCollection<Tables.Accounts>();
        public ObservableCollection<AccountType> AccountsType = new ObservableCollection<AccountType>();


        ObservableCollection<TableAccountView> tableAccountViews = new ObservableCollection<TableAccountView>();
        protected override async void OnAppearing()
        {

            #region Create table Type
            AccountsType.Add(new AccountType { TypeID = 1, TypeName = "Expense" });
            AccountsType.Add(new AccountType { TypeID = 2, TypeName = "Group" });
            AccountsType.Add(new AccountType { TypeID = 3, TypeName = "Statement" });

            #endregion




            var Accounts = await CL.PassingParameter._connection.Table<Tables.Accounts>().ToListAsync();

            var _UsersAccounts = new ObservableCollection<Tables.Accounts>(Accounts);





            var results = (from table1 in _UsersAccounts.AsEnumerable()
                           join table2 in AccountsType.AsEnumerable() on table1.AccountType equals table2.TypeID
                           select new TableAccountView
                           {

                               AccountID = table1.AccountID,
                               AccountName = table1.AccountName,
                               AccountColor = table1.AccountColor,
                               AccountType = table2.TypeName


                           });



            tableAccountViews = CL.ObjectConvertor.ConvertAccountList(results);

           


            AccountList.ItemsSource = tableAccountViews;


            base.OnAppearing();
        }

       

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

          
            RadioButton image = (RadioButton)sender;

            int AccountIndex = int.Parse(image.ClassId);
           
            if (UserSelectAccountType)
            {
                  UserSelectAccountType = true;
                tableAccountViews[tableAccountViews.IndexOf(tableAccountViews.Where(X => X.AccountID == AccountIndex).FirstOrDefault())].AccountType
                    =
                    AccountsType.Where(i => i.TypeID == AccountIndex).FirstOrDefault().TypeName ;



                CL.PassingParameter._connection.UpdateAsync(new Tables.Accounts { AccountID= tableAccountViews[tableAccountViews.IndexOf(tableAccountViews.Where(X => X.AccountID == AccountIndex).FirstOrDefault())].AccountID,AccountType= AccountIndex });
                UserSelectAccountType = false;
            }



        }

        bool UserSelectAccountType;

        private void DeleteAccount_Invoked(object sender, EventArgs e)
        {
            var button = (SwipeItemView)sender;
            var Check = button.CommandParameter as Tables.Accounts;

        
            //tableAccounts.Remove(Check);

            //AccountList.ItemsSource = tableAccounts;
        }

        private void btnNewAccount_Clicked(object sender, EventArgs e)
        {

            UserSelectAccountType = false;

            CL.AnimationObject.StartAnimationFrame(FrameNewAccount);

            txtAccount.Content = "Empty";


        }



        private void btnDelete_Clicked(object sender, EventArgs e)
        {

         
           
            
           
        }


        string SelectAccountName = "";
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var tapEventArgs = (TappedEventArgs)e;
            var parameter = (TableAccountView)tapEventArgs.Parameter;


            GridNewAccount.BindingContext = parameter;
            CL.AnimationObject.StartAnimationFrame(FrameNewAccount);


            

            var report = AccountsType.Where(i => i.TypeName == parameter.AccountType).ToList();



            SelectAccountName = parameter.AccountName;

            SelectAccountType(report.FirstOrDefault().TypeID);
        }




        //تم من خلالها تحديد نوع الحساب ليتم عند التعديل ما هو نوع الحساب الحالي
        void SelectAccountType(int TypeID)
        {
            btnExpenseType.IsChecked = false;
            btnGroupType.IsChecked = false;
            btnStatementType.IsChecked = false;

            UserSelectAccountType = false;

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

        private async void btnPinForChart_Invoked(object sender, EventArgs e)
        {
            var button = (SwipeItemView)sender;
            var Check = button.CommandParameter as TableAccountView;

            Preferences.Set(CL.PassingParameter.PinHomeScreenID, Check.AccountID.ToString());

            Xamarin.Forms.Application.Current.MainPage = new MainPage();


        }
    }
}