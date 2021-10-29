using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace My_Wallet.Language
{
    class AccountManage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string flowdirection;
        public string FlowDirection
        {
            get
            {
                return flowdirection;
            }
            set
            {
                flowdirection = value;
                OnPropertyChanged(nameof(FlowDirection));
            }
        }


        private string headerlbl;
        public string Headerlbl
        {
            get
            {
                return headerlbl;
            }
            set
            {
                headerlbl = value;
                OnPropertyChanged(nameof(Headerlbl));
            }
        }
        private string mujahedlbl;
        public string Mujahedlbl
        {
            get
            {
                return mujahedlbl;
            }
            set
            {
                mujahedlbl = value;
                OnPropertyChanged(nameof(Mujahedlbl));
            }
        }




        bool ArLang = true;
        public AccountManage()
        {

            if (ArLang)
            {


                Headerlbl = "ادارة الحسابات";

                return;
            }



            Headerlbl = "Account Manager";


        }
    }
}
