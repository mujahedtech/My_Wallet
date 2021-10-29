using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Wallet.CL
{
    public interface ISQLiteDb
    {


        SQLiteAsyncConnection GetConnection();

        void Delete();

    }
}
