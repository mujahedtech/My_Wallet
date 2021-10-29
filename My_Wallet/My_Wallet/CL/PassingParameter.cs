using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Wallet.CL
{
   public class PassingParameter
    {
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


    }
}
