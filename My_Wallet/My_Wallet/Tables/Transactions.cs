using SQLite;
using System;
namespace My_Wallet.Tables
{
  public  class Transactions
    {
        [PrimaryKey][AutoIncrement]
        public int IDTransaction { get; set; }
        public int IDAccount { get; set; }
        public DateTime EnteredDate { get; set; }

        public double Amount { get; set; }

        public string Notes { get; set; }


    }
}
