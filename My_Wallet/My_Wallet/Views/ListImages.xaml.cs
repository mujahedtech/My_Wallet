using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace My_Wallet.Views
{
    public class ImageList
    {

        public int ID { get; set; }
        public string SourceImage { get; set; }

    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListImages : ContentPage
    {
        public ListImages()
        {
            InitializeComponent();

            
        }

        protected override void OnAppearing()
        {
            List<ImageList> ImageList = new List<ImageList>();

            ImageList.Add(new Views.ImageList { ID=1, SourceImage = "https://firebasestorage.googleapis.com/v0/b/khiratserv.appspot.com/o/DidYouSubscribe%2FToMyChannelYet%2Fdownload.jpeg?alt=media&token=50443632-ffc1-43dc-a294-0298fe2d7098" });
            ImageList.Add(new Views.ImageList { ID = 1, SourceImage = "https://firebasestorage.googleapis.com/v0/b/khiratserv.appspot.com/o/DidYouSubscribe%2FToMyChannelYet%2Fdownload.png?alt=media&token=cc618cda-9770-4f43-9808-04b0476d7ab7" });
            ImageList.Add(new Views.ImageList { ID = 1, SourceImage = "https://firebasestorage.googleapis.com/v0/b/khiratserv.appspot.com/o/DidYouSubscribe%2FToMyChannelYet%2Fimages.png?alt=media&token=47147eed-01d5-4506-8765-723aaf482a9e" });

            TransactionList.ItemsSource = ImageList;

            base.OnAppearing();
        }
    }
}