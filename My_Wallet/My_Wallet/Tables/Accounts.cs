using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace My_Wallet.Tables
{
    public class Accounts
    {
        [PrimaryKey][AutoIncrement]
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public int AccountType { get; set; }
        public string AccountColor { get; set; }
    }
}
