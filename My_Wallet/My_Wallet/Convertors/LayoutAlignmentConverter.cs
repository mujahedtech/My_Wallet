using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace My_Wallet.Convertors
{
    class LayoutAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string valueAsString = value.ToString();
                switch (valueAsString)
                {
                    case "Start":
                        {
                            return LayoutOptions.Start;
                        }
                    case "End":
                        {
                            return LayoutOptions.End;
                        }
                    default:
                        {
                            return LayoutOptions.StartAndExpand;
                        }
                }
            }
            else
            {
                return LayoutOptions.StartAndExpand;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
