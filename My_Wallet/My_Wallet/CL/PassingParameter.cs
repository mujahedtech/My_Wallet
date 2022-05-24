using My_Wallet.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace My_Wallet.CL
{
   public class PassingParameter
    {

       public static List<TransactionsViewModel> MonthSummaryList { get; set;  }


        public static string CreateRandomColor()
        {
            var random = new Random();
            var color = String.Format("#{0:X6}", random.Next(0x1000000)); // = "#A197B9"

            return color;
        }

        public static Color GetReadableForeColor(Color c)
        {
            return (((c.R + c.B + c.G) / 3) > 128) ? Color.Black : Color.White;
        }

        public static string PinHomeScreenID = "PinHomeScreenID";

        public static string LangStr = "LangStr";
        public static bool FirstLoad { get; set; } = true;
        public static bool ArLanguage { get; set; } = true; 

        static SQLiteAsyncConnection connection;
        public static SQLiteAsyncConnection _connection
        {
            get
            {
                return connection;
            }
            set
            {
                connection = value;
            }
        }



       public static string ConvertAr(string Numbers)
        {
            string Indata = Numbers;

            if (CL.PassingParameter.ArLanguage)
            {
                for (int n = 0; n < 10; n++)
                {
                    Indata = Indata.Replace(n.ToString(), NumberInAr(n.ToString()));
                }

            }


            

            return Regex.Replace(Indata, @"\s+", "") ;

        }


       static string NumberInAr(string Numbers)
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


        public static bool Isdouble(string input)
        {
            double test = 0;
            return double.TryParse(input, out test);
        }


    }
}
