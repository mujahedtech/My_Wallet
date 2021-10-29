using My_Wallet.CL;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace My_Wallet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.ManageAccounts();

            


            Device.SetFlags(new[] { "Shapes_Experimental", "Brush_Experimental", "RadioButton_Experimental", "SwipeView_Experimental" });

            CL.PassingParameter._connection = Xamarin.Forms.DependencyService.Get<ISQLiteDb>().GetConnection();

            CreateTables();

        }

        async void CreateTables()
        {



            //await CL.PassingParameter._connection.CreateTableAsync<Tables.UsersAccounts>();
            //await CL.PassingParameter._connection.CreateTableAsync<Tables.DoctorInfo>();

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
