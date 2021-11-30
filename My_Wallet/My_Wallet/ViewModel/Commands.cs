using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace My_Wallet.ViewModel
{
    class Commands
    {
        public INavigation Navigation { get; set; }
        public Command TouchLong { get; }


        public Commands()
        {

            Navigation = Application.Current.MainPage.Navigation;

            TouchLong = new Command(() =>

            Mujahed()


               );

        }



        async void Mujahed()
        {
            if (CL.PassingParameter.MonthSummaryList!=null)
            {
                ContentPage m = new ContentPage();

                Grid grid = new Grid();

                m.BackgroundColor = Color.White;
                grid.BackgroundColor = Color.White;

                grid.Children.Add(CreateReport());

                m.Padding = 4;

                m.Content = grid;

                await Navigation.PushModalAsync(m);
            }

           

            else if (CL.PassingParameter.MonthSummaryList == null)
            {
                string Error = "Prepare Monthly Report First";

                if (CL.PassingParameter.ArLanguage == true)
                {
                    Error = "قم بتجهيز التقرير الشهري اولا";
                }
                await Application.Current.MainPage.DisplayToastAsync(Error, 1000);
            } 



        }


        ChartView CreateReport()
        {
            List<ChartEntry> entries = new List<ChartEntry>();

            var Monthreport = CL.PassingParameter.MonthSummaryList;

            for (int i = 0; i < Monthreport.Count; i++)
            {
                string Color = CL.PassingParameter.CreateRandomColor();
                entries.Add(new ChartEntry(int.Parse(Monthreport[i].Amount.ToString("0")))
                {
                    Label = Monthreport[i].AccountName,
                    ValueLabel = Monthreport[i].Amount.ToString("0$"),
                    Color = SKColor.Parse(Color),
                    TextColor = SKColor.Parse(Color),
                    ValueLabelColor = SKColor.Parse(Color)
                });
            }

            ChartView chartView = new ChartView();
            chartView.Chart = new LineChart { Entries = entries, LabelTextSize = 30, ValueLabelOrientation = Orientation.Horizontal, LabelOrientation = Orientation.Horizontal };

            return chartView;
        }




    }
}
