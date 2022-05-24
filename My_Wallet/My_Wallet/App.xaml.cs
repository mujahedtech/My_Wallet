using My_Wallet.CL;
using System;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace My_Wallet
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();


            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);

            Device.SetFlags(new[] { "Shapes_Experimental", "Brush_Experimental", "RadioButton_Experimental", "SwipeView_Experimental" });

            CL.PassingParameter._connection = Xamarin.Forms.DependencyService.Get<ISQLiteDb>().GetConnection();

            CreateTables();

            bool LangSetting = new bool();

            if (CL.DataValidation.IsBool(Preferences.Get(CL.PassingParameter.LangStr, string.Empty)))
            {
                LangSetting = bool.Parse(Preferences.Get(CL.PassingParameter.LangStr, string.Empty));
                CL.PassingParameter.ArLanguage = LangSetting;

            }

        }

        async void CreateTables()
        {



            await CL.PassingParameter._connection.CreateTableAsync<Tables.Accounts>();
            await CL.PassingParameter._connection.CreateTableAsync<Tables.Transactions>();

            //await CL.PassingParameter._connection.CreateTableAsync<Tables.OrganizeDate>();
            //await CL.PassingParameter._connection.CreateTableAsync<Tables.PatientInfo>();
            //await CL.PassingParameter._connection.CreateTableAsync<Tables.AppointmentDates>();
            //await CL.PassingParameter._connection.CreateTableAsync<Tables.Drugs>();
            //await CL.PassingParameter._connection.CreateTableAsync<Tables.Examination>();

            //await CL.PassingParameter._connection.CreateTableAsync<Tables.PreviousDate>();
            //await CL.PassingParameter._connection.CreateTableAsync<Tables.ExaminationForPatient>();
            //await CL.PassingParameter._connection.CreateTableAsync<Tables.DrugForPatient>();
            //await CL.PassingParameter._connection.CreateTableAsync<Tables.ServicesProvide>();
            //await CL.PassingParameter._connection.CreateTableAsync<Tables.ServicesProvideForPatient>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
           
        }
    }
}
