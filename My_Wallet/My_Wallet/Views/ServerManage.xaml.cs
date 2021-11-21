using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;

namespace My_Wallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServerManage : ContentPage
    {
        public ServerManage()
        {
            InitializeComponent();
        }

        string settingDownloadName = "ServerDonwloadLink";
        string strLastBackup = "strLastBackup";
        protected override void OnAppearing()
        {

           lblRestoreLink.Text= Preferences.Get(settingDownloadName, string.Empty);
            lbllastBackup.Text = Preferences.Get(strLastBackup, string.Empty);



            base.OnAppearing();
        }
        private async void btnUpload_Clicked(object sender, EventArgs e)
        {
           


            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "My_Wallet.db3");

            var stream = File.Open(path, FileMode.Open);
            var deviceName = DeviceInfo.Name;

            var task = new FirebaseStorage("money-87a37.appspot.com",
                new FirebaseStorageOptions
                {
                    ThrowOnCancel = true
                })

                .Child(deviceName)
                .Child("My_Wallet.db3")
                .PutAsync(stream);

            task.Progress.ProgressChanged += (s, args) =>
            {
                progressBar.Progress = args.Percentage;
            };

          

            var downloadlink = await task;
            //downloadLink.Text = downloadlink;
            progressBar.Progress = 1;


            Preferences.Set(settingDownloadName, downloadlink);
            Preferences.Set(strLastBackup, DateTime.Now.ToString());
            lbllastBackup.Text = Preferences.Get(strLastBackup, string.Empty);

            



            #region Upload image to firebase
            ////var photo = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();

            ////if (photo == null)
            ////    return;

            //var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //var path = Path.Combine(documentsPath, "My_Wallet.db3");

            //string dbPath = "/storage/emulated/0/My_Wallet.db3";

            //System.IO.File.Copy(path, dbPath);


            //var task = new FirebaseStorage("money-87a37.appspot.com",
            //    new FirebaseStorageOptions
            //    {
            //        ThrowOnCancel = true
            //    })
            //    .Child("DidYouSubscribe")
            //    .Child("ToMyChannelYet")
            //    .Child("My_Wallet")
            //    .PutAsync(StringToStream(dbPath));

            //task.Progress.ProgressChanged += (s, args) =>
            //{
            //    progressBar.Progress = args.Percentage;
            //};

            //var downloadlink = await task;
            //downloadLink.Text = downloadlink;


            //txtnote.Text = path;

            #endregion

        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            Xamarin.Forms.DependencyService.Get<CL.ISQLiteDb>().Delete();

            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "My_Wallet.db3");


            System.IO.File.Delete(path);
            System.Environment.Exit(0);
        }

        WebClient client;
        void StartDonwload()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "My_Wallet.db3");
            System.IO.File.Delete(path);
            client = new WebClient();
            System.Threading.Thread thread = new System.Threading.Thread(() =>
            {
                Uri uri = new Uri(Preferences.Get(settingDownloadName, string.Empty));

                client.DownloadFileAsync(uri, path);
            });
            thread.Start();
            client.DownloadProgressChanged += Client_DownloadProgressChanged;

        }

       
        private  void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Dispatcher.BeginInvokeOnMainThread(new Action(() =>
            {

                double receive = double.Parse(e.BytesReceived.ToString());
                double total = double.Parse(e.TotalBytesToReceive.ToString());
                double precentage = receive / total * 100;


                progressBar.Progress = int.Parse(Math.Truncate(precentage / 100).ToString());
                //txtProgressDownload.Text = int.Parse(Math.Truncate(precentage).ToString()).ToString();

                if (progressBar.Progress == 1)
                {

                    Task.Run(async()=> { await this.DisplayToastAsync("BackUp Complete", 3000); });  
                }
            }));
        }

        private async void RestoreDB_Clicked(object sender, EventArgs e)
        {

            string result = await DisplayPromptAsync("Security", "What's Password?");

            // OK
            if (result != null)
            {
                if (result == Password)
                {
                    await this.DisplayToastAsync("Start BackUp", 3000);
                }
                else
                {
                    await this.DisplayToastAsync("Your Password is Incorrect", 3000);
                    return;
                }

            }
            else
            {
                await this.DisplayToastAsync("You Cancel", 3000);
                return;
            }


            StartDonwload();

           
        }

        string Password = "1200";
        private async void RestoreDBManual_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Security", "What's Password?");

            // OK
            if (result != null)
            {
                if (result == Password)
                {
                    string result2 = await DisplayPromptAsync("Restore Link", "Paste Here your Restore Link?");

                    // OK
                    if (result2 != null)
                    {
                        Preferences.Set(settingDownloadName, result2);

                    }
                    else
                    {
                        await this.DisplayToastAsync("You Cancel", 3000);
                        return;
                    }
                }
                else
                {
                    await this.DisplayToastAsync("Your Password is Incorrect", 3000);
                    return;
                }

            }
            else
            {
                await this.DisplayToastAsync("You Cancel", 3000);
                return;
            }
        }
    }
}