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
        private string accountnamelbl;
        public string AccountNamelbl
        {
            get
            {
                return accountnamelbl;
            }
            set
            {
                accountnamelbl = value;
                OnPropertyChanged(nameof(AccountNamelbl));
            }
        }
        private string expenselbl;
        public string Expenselbl
        {
            get
            {
                return expenselbl;
            }
            set
            {
                expenselbl = value;
                OnPropertyChanged(nameof(Expenselbl));
            }
        }
        private string grouplbl;
        public string Grouplbl
        {
            get
            {
                return grouplbl;
            }
            set
            {
                grouplbl = value;
                OnPropertyChanged(nameof(Grouplbl));
            }
        }
        private string accountstatementlbl;
        public string AccountStatementlbl
        {
            get
            {
                return accountstatementlbl;
            }
            set
            {
                accountstatementlbl = value;
                OnPropertyChanged(nameof(AccountStatementlbl));
            }
        }
        private string flowdirectionlbl;
        public string FlowDirectionlbl
        {
            get
            {
                return flowdirectionlbl;
            }
            set
            {
                flowdirectionlbl = value;
                OnPropertyChanged(nameof(FlowDirectionlbl));
            }
        }
        private string horizontaloptionslbl;
        public string HorizontalOptionslbl
        {
            get
            {
                return horizontaloptionslbl;
            }
            set
            {
                horizontaloptionslbl = value;
                OnPropertyChanged(nameof(HorizontalOptionslbl));
            }
        }








        bool ArLang = true;
        public AccountManage()
        {

            if (ArLang)
            {


                Headerlbl = "ادارة الحسابات";

                AccountNamelbl = "ادخل اسم الحساب";

                Expenselbl = "مصروف";

                Grouplbl = "مجموعة";

                AccountStatementlbl = "كشف حساب";

                FlowDirectionlbl = "RightToLeft";

                HorizontalOptionslbl = "End";

                return;
            }



            Headerlbl = "Account Manager";

            AccountNamelbl = "Enter Account Name :";

            Expenselbl = "Expense";

            Grouplbl = "Group";

            AccountStatementlbl = "Account Statement";

            FlowDirectionlbl = "LeftToRight";

            HorizontalOptionslbl = "Start";


        }
    }
}
