using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace My_Wallet.Views
{

    public class CalculateVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public double? Required { get; set; }
        public double? AddCash { get; set; }
        public double? TotalExpense { get; set; }


        public double? _50 { get; set; }
        public double? _20 { get; set; }
        public double? _10 { get; set; }
        public double? _5 { get; set; }
        public double? _1 { get; set; }



        public double Count_50 { get { return _50.HasValue? _50.Value / 50:0; } }
        public double Count_20 { get { return _20.HasValue ? _20.Value / 20 : 0; } }
        public double Count_10 { get { return _10.HasValue ? _10.Value / 10 : 0; } }
        public double Count_5 { get { return _5.HasValue ? _5.Value / 5 : 0; } }
        public double Count_1 { get { return _1.HasValue ? _1.Value / 1 : 0; } }

        public Color NetCashColor { get { return NetCash > 0 ? Color.Red : Color.Green; } }

        public double TotalCash
        {
            get
            {
                double Value = 0;

                if (_50.HasValue) Value += _50.Value;
                if (_20.HasValue) Value += _20.Value;
                if (_10.HasValue) Value += _10.Value;
                if (_5.HasValue) Value += _5.Value;
                if (_1.HasValue) Value += _1.Value;

                return Value; 
            }
        }

        public double TotalRequired
        {
            get
            {
                double Value = 0;

                if (Required.HasValue) Value += Required.Value;
                if (AddCash.HasValue) Value += AddCash.Value;
                if (TotalExpense.HasValue) Value -= TotalExpense.Value;
                return Value;
            }
        }

        public double NetCash { get { return TotalRequired - TotalCash; } }


    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {

        CalculateVM VM = new CalculateVM();
        public Calculator()
        {
            InitializeComponent();

            BindingContext = VM;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton image = (ImageButton)sender;
            switch (image.ClassId)
            {
                case "50":
                    VM._50 = 50* VM._50;
                    break;
                case "20":
                    VM._20 = 20 * VM._20;
                    break;
                case "10":
                    VM._10 = 10 * VM._10;
                    break;
                case "5":
                    VM._5 = 5 * VM._5;
                    break;
                case "1":
                    VM._1 = 1 * VM._1;
                    break;
            }

        }

        private void ViewExpense_Clicked(object sender, EventArgs e)
        {
            GridExpense.IsVisible = true;
        }

        private void btnCalcualteExpense_Clicked(object sender, EventArgs e)
        {
            GridExpense.IsVisible = false;

            VM.TotalExpense = Evaluate(txtExpenseStr.Text);
        }


        static double Evaluate(string expression)
        {
            var loDataTable = new System.Data.DataTable();
            var loDataColumn = new System.Data.DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)(loDataTable.Rows[0]["Eval"]);
        }
    }
}