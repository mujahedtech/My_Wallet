using System;
using System.Collections.Generic;
using System.Text;

namespace My_Wallet.CL
{
    class DataValidation
    {

        public static bool IsDouble(string input)
        {
            double test;
            return double.TryParse(input, out test);
        }


        public static bool IsDate(string input)
        {
            DateTime test;
            return DateTime.TryParse(input, out test);
        }
        public static bool IsBool(string input)
        {
            bool test;
            return bool.TryParse(input, out test);
        }
    }
}
