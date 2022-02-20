using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Database.Query;
using System.Reactive.Linq;
using Xamarin.CommunityToolkit.Extensions;

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
         bool LangSetting = new bool();
      
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


        string Password = "1200";
        private async void Button_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Security", "What's Password?");

            // OK
            if (result != null)
            {
                if (result == Password)
                {
                    await Navigation.PushModalAsync(new Views.Auth_Management());
                }
                else
                {
                    await this.DisplayToastAsync("Your Password is Incorrect", 3000);
                    return;
                }

            }
            else
            {
                await this.DisplayToastAsync("You Cancel", 3000);
                return;
            }
           
        }
    }
}