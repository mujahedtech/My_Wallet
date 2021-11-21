using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

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
        private string viewexpenseslbl;
        public string ViewExpenseslbl
        {
            get
            {
                return viewexpenseslbl;
            }
            set
            {
                viewexpenseslbl = value;
                OnPropertyChanged(nameof(ViewExpenseslbl));
            }
        }
        private string accountslbl;
        public string Accountslbl
        {
            get
            {
                return accountslbl;
            }
            set
            {
                accountslbl = value;
                OnPropertyChanged(nameof(Accountslbl));
            }
        }
        private string settingslbl;
        public string Settingslbl
        {
            get
            {
                return settingslbl;
            }
            set
            {
                settingslbl = value;
                OnPropertyChanged(nameof(Settingslbl));
            }
        }
        private string newexpenselbl;
        public string Newexpenselbl
        {
            get
            {
                return newexpenselbl;
            }
            set
            {
                newexpenselbl = value;
                OnPropertyChanged(nameof(Newexpenselbl));
            }
        }
        private string accountreportlbl;
        public string AccountReportlbl
        {
            get
            {
                return accountreportlbl;
            }
            set
            {
                accountreportlbl = value;
                OnPropertyChanged(nameof(AccountReportlbl));
            }
        }
       
        private string databasemanagelbl;
        public string DatabaseManagelbl
        {
            get
            {
                return databasemanagelbl;
            }
            set
            {
                databasemanagelbl = value;
                OnPropertyChanged(nameof(DatabaseManagelbl));
            }
        }
        private string pathbackuplbl;
        public string PathBackuplbl
        {
            get
            {
                return pathbackuplbl;
            }
            set
            {
                pathbackuplbl = value;
                OnPropertyChanged(nameof(PathBackuplbl));
            }
        }
        private string lastbackuplbl;
        public string LastBackuplbl
        {
            get
            {
                return lastbackuplbl;
            }
            set
            {
                lastbackuplbl = value;
                OnPropertyChanged(nameof(LastBackuplbl));
            }
        }
        private string restoredatabaselbl;
        public string Restoredatabaselbl
        {
            get
            {
                return restoredatabaselbl;
            }
            set
            {
                restoredatabaselbl = value;
                OnPropertyChanged(nameof(Restoredatabaselbl));
            }
        }
        private string enterrestorecodelbl;
        public string EnterRestoreCodelbl
        {
            get
            {
                return enterrestorecodelbl;
            }
            set
            {
                enterrestorecodelbl = value;
                OnPropertyChanged(nameof(EnterRestoreCodelbl));
            }
        }
        private string backupdatabaselbl;
        public string BackupDatabaselbl
        {
            get
            {
                return backupdatabaselbl;
            }
            set
            {
                backupdatabaselbl = value;
                OnPropertyChanged(nameof(BackupDatabaselbl));
            }
        }
        private string selectaccountlbl;
        public string SelectAccountlbl
        {
            get
            {
                return selectaccountlbl;
            }
            set
            {
                selectaccountlbl = value;
                OnPropertyChanged(nameof(SelectAccountlbl));
            }
        }
        private string selectmonthlbl;
        public string SelectMonthlbl
        {
            get
            {
                return selectmonthlbl;
            }
            set
            {
                selectmonthlbl = value;
                OnPropertyChanged(nameof(SelectMonthlbl));
            }
        }
        private string filterarealbl;
        public string FilterArealbl
        {
            get
            {
                return filterarealbl;
            }
            set
            {
                filterarealbl = value;
                OnPropertyChanged(nameof(FilterArealbl));
            }
        }
        private string sortarealbl;
        public string SortArealbl
        {
            get
            {
                return sortarealbl;
            }
            set
            {
                sortarealbl = value;
                OnPropertyChanged(nameof(SortArealbl));
            }
        }








        public AccountManage()
        {

            bool LangSetting = new bool();

            if (CL.DataValidation.IsBool(Preferences.Get(CL.PassingParameter.LangStr, string.Empty)))
            {
                LangSetting = bool.Parse(Preferences.Get(CL.PassingParameter.LangStr, string.Empty));
                CL.PassingParameter.ArLanguage = LangSetting;

            }



            if (CL.PassingParameter.ArLanguage)
            {


                Headerlbl = "ادارة الحسابات";

                AccountNamelbl = "ادخل اسم الحساب";

                Expenselbl = "مصروف";

                Grouplbl = "مجموعة";

                AccountStatementlbl = "كشف حساب";

                FlowDirectionlbl = "RightToLeft";

                HorizontalOptionslbl = "End";

                ViewExpenseslbl = "عرض المصاريف";

                Accountslbl = "الحسابات";

                Settingslbl = "الإعدادات";

                Newexpenselbl = "مصروف جديد";

                AccountReportlbl = "تقرير الحسابات";

                DatabaseManagelbl = "إدارة قاعدة البيانات";

                PathBackuplbl = "مسار النسخ الاحتياطي";

                LastBackuplbl = "النسخة الاحتياطية الاخيرة";

                Restoredatabaselbl = "استعادة قاعدة البيانات";

                EnterRestoreCodelbl = "أدخل رمز الاستعادة";

                BackupDatabaselbl = "قاعدة بيانات النسخ الاحتياطي";

                SelectAccountlbl = "اختر حساب";

                SelectMonthlbl = "اختر الشهر";

                FilterArealbl = "منطقة الفلتر";

                SortArealbl = "منطقة الترتيب";
                return;
            }



            Headerlbl = "Account Manager";

            AccountNamelbl = "Enter Account Name :";

            Expenselbl = "Expense";

            Grouplbl = "Group";

            AccountStatementlbl = "Account Statement";

            FlowDirectionlbl = "LeftToRight";

            HorizontalOptionslbl = "Start";

            ViewExpenseslbl = "View Expenses";

            Accountslbl = "Accounts";

            Settingslbl = "Settings";

            Newexpenselbl = "New Expense";

            AccountReportlbl = "Accounts Report";

            DatabaseManagelbl = "Database Manage";

            PathBackuplbl = "Path Backup";

            LastBackuplbl = "Last Backup";

            Restoredatabaselbl = "Restore Database";

            EnterRestoreCodelbl = "Enter Restore Code";

            BackupDatabaselbl = "Backup Database";

            SelectAccountlbl = "Select Account";

            SelectMonthlbl = "Select Month";

            FilterArealbl = "Filter Area";

            SortArealbl = "Sort Area";


        }
    }
}
