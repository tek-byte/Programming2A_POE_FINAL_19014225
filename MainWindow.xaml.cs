using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _19014225_Prog6211_POE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Expenses exp = new Expenses();           //Calls the Expense Class.
        public static Homeloan home = new Homeloan();         //Calls the Homeloan Class.
        public static VehicleLoan veh = new VehicleLoan();   //Calls the Vehicleloan Class.

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCaptureExpenses_Click(object sender, RoutedEventArgs e)
        {
            CaptureExpenses();
        }
        
        private void CaptureExpenses()
        {
            try
            {
                exp.MntIncome = Int32.Parse(txtIncome.Text);
                //txtSavings.Text = Convert.ToString(ex.MntIncome);

                exp.MntTax = Int32.Parse(txtTax.Text);
                //txtTaxIncome.Text = Convert.ToString(ex.MntIncome - ex.MntTax);

                exp.TaxDone = exp.MntIncome - exp.MntTax;          //calculates monthly income after tax.

                //Expenses are stored in a 1D Array.
                exp.expenses[0] = Int32.Parse(txtGroceries.Text);
                exp.expenses[1] = Int32.Parse(txtWaterLights.Text);
                exp.expenses[2] = Int32.Parse(txtTravel.Text);
                exp.expenses[3] = Int32.Parse(txtPhone.Text);
                exp.expenses[4] = Int32.Parse(txtOther.Text);



                for (int x = 0; x < exp.expenses.Length; x++)
                {
                    //Accumulates the expense totals.
                    exp.TotalExpenses = exp.TotalExpenses + exp.ExpensesArray[x];
                }


                exp.TotalSavings = exp.TaxDone - exp.TotalExpenses;    //calculates total money left.
                                                                       //txtExpenseTotal.Text = Convert.ToString(ex.TotalExpenses);

                //Push variables through to accommodation class
                Accommodation acm = new Accommodation(
                    exp.MntIncome,
                    exp.MntTax,
                    exp.TotalExpenses,
                    exp.TaxDone,
                    exp.TotalSavings);

                this.Hide();
                acm.ShowDialog();
            }
            catch (Exception Ev)
            {
                //Error is displayed with a message box to inform user of what mistake was made when data was entered.

                MessageBox.Show(Ev.Message + "\nPlease ensure all fields are entered!");
            }
        }

        private void txtExitHome_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
