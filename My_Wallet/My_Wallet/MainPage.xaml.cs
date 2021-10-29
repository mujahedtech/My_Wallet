using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace My_Wallet
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            gridtest.IsVisible = true;
            if (gridtest.Scale==0)
            {
                gridtest.ScaleTo(1, 1000, Easing.SpringIn);
               
                return;
            }
            gridtest.ScaleTo(0, 1000, Easing.SpringIn);

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.ManageAccounts());
           
        }
    }
}
