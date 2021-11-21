using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace My_Wallet.Convertors
{
    class CurrencyConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            string Lang = "USD";
            if (CL.PassingParameter.ArLanguage == true)
            {
                Lang = "د.أ";
            }


            if (CL.DataValidation.IsDouble(value.ToString()))

                return Lang;


            return "";
            // input is empty
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
