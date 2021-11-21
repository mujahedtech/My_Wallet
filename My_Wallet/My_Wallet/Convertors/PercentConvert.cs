using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace My_Wallet.Convertors
{
    class PercentConvert : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            double Percent = 0;
            if (CL.DataValidation.IsDouble(value.ToString()))
            {
                Percent = double.Parse(value.ToString()) * 100;
            }


            return Percent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
