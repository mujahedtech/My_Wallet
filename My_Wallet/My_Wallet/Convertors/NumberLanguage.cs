using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace My_Wallet.Convertors
{
    class NumberLanguage : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
           


            if (CL.DataValidation.IsDouble(value.ToString()))

                return ConvertAr(value.ToString());


            return value.ToString();
            // input is empty
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }




        string ConvertAr(string Numbers)
        {
            string Indata = Numbers;

            if (CL.PassingParameter.ArLanguage)
            {
                for (int n = 0; n < 10; n++)
                {
                    Indata = Indata.Replace(n.ToString(), NumberInAr(n.ToString()));
                }

            }




            return Regex.Replace(Indata, @"\s+", ""); ;

        }
        string NumberInAr(string Numbers)
        {
            string Indata = Numbers;




            switch (Indata)
            {
                case "0":
                    Indata = Indata.Replace("0", "٠");
                    break;
                case "1":
                    Indata = Indata.Replace("1", "١");
                    break;
                case "2":
                    Indata = Indata.Replace("2", "٢");
                    break;
                case "3":
                    Indata = Indata.Replace("3", "٣");
                    break;
                case "4":
                    Indata = Indata.Replace("4", "٤");
                    break;
                case "5":
                    Indata = Indata.Replace("5", "٥");
                    break;
                case "6":
                    Indata = Indata.Replace("6", "٦	");
                    break;
                case "7":
                    Indata = Indata.Replace("7", "٧	");
                    break;
                case "8":
                    Indata = Indata.Replace("8", "٨");
                    break;
                case "9":
                    Indata = Indata.Replace("9", "٩");
                    break;

            }

            return Indata;

        }
  
}
}
