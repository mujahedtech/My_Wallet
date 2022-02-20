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

namespace My_Wallet.Views
{
    public class Orders
    {
        public Guid IDOrder { get; set; }
        public string OrderName { get; set; }

        public DateTime DateTimeOrder { get; set; }

        public string DeviceID { get; set; }



    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Auth_Management : ContentPage
    {

        Firebase.Database.FirebaseClient firebaseclient = new Firebase.Database.FirebaseClient("https://khiratserv-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public ObservableCollection<Orders> OrdersList { get; set; } = new ObservableCollection<Orders>();
        public Auth_Management()
        {
            InitializeComponent();

            BindingContext = this;


            var collection = firebaseclient.Child(nameof(Orders)).AsObservable<Orders>().Subscribe((dbevent) =>
            {
                if (dbevent.Object != null)
                {
                    OrdersList.Add(dbevent.Object);



                }
            });
        }

        private void btnOpenAuth_Clicked(object sender, EventArgs e)
        {
            var deviceName = DeviceInfo.Manufacturer + " " + DeviceInfo.Model + " " + DeviceInfo.Platform.ToString() + " " + DeviceInfo.Version.ToString();
            firebaseclient.Child(nameof(Orders)).PostAsync(new Orders { IDOrder = Guid.NewGuid(), OrderName = "Open", DateTimeOrder = DateTime.Now, DeviceID = deviceName });
        }



        private void btnOrders_Clicked(object sender, EventArgs e)
        {
            var deviceName = DeviceInfo.Manufacturer + " " + DeviceInfo.Model + " " + DeviceInfo.Platform.ToString() + " " + DeviceInfo.Version.ToString();


            firebaseclient.Child(nameof(Orders)).PostAsync(new Orders { IDOrder = Guid.NewGuid(), OrderName = txtOrder.Content.ToString(), DateTimeOrder = DateTime.Now, DeviceID = deviceName });

            txtOrder.Content = "";
        }
    }
}