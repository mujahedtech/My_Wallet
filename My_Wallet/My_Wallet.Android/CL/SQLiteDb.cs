using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using My_Wallet.CL;
using My_Wallet.Droid.CL;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace My_Wallet.Droid.CL
{
    class SQLiteDb : My_Wallet.CL.ISQLiteDb
    {
        public void Delete()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "My_Wallet.db3");

            System.IO.File.Delete(path);
        }

        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "My_Wallet.db3");


            return new SQLiteAsyncConnection(path);
        }
    }
}