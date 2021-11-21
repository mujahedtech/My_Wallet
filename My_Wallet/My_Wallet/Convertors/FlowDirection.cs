using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace My_Wallet.Convertors
{
    class FlowDirection : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null)
            {



                string valueAsString = value.ToString();
                switch (valueAsString)
                {
                    case "LeftToRight":
                        {
                            return Xamarin.Forms.FlowDirection.LeftToRight;
                        }
                    case "RightToLeft":
                        {
                            return Xamarin.Forms.FlowDirection.RightToLeft;
                        }

                }
            }

            return "";

           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
