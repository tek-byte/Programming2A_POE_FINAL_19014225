using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _19014225_Prog6211_POE
{
    /// <summary>
    /// Interaction logic for Accommodation.xaml
    /// </summary>
    /// 
    public partial class Accommodation : Window
    {
        public static Homeloan home = new Homeloan();
        public static Expenses exp = new Expenses();
        

        public Accommodation(double Income, double Tax, double TotalExpenses, double AfterTax, double TotalSaved)
        {
            InitializeComponent();
            exp.MntIncome = Income;
            exp.MntTax = Tax;
            exp.TotalExpenses = TotalExpenses;
            exp.TaxDone = AfterTax;
            exp.TotalSavings = TotalSaved;
        }

        private void btnSubmitHome_Click(object sender, RoutedEventArgs e)
        {
            try //Error handling is implemented.
            {

                ////////////_HOME DETAILS_///////////

                if (rbRent.IsChecked == true)
                {
                    //Stores the rental amount as monthly accommodation amount.
                    CalculateHomeRental();
                    home.FinalProp = home.RentalAmount;
                    home.HOMESTATUS1 = "-";
                }
                else if (rbBuy.IsChecked == true)
                {
                    //Calculated the Homaloan.
                    CalculateHomeLoan();
                    home.FinalProp = home.PropRepayments;
                }
                //MessageBox.Show("All details captured successfully!");

                this.Hide();
                Vehicle vh = new Vehicle(
                    exp.MntIncome,
                    exp.MntTax,
                    exp.TotalExpenses,
                    exp.TaxDone,
                    exp.TotalSavings,
                    home.FinalProp,
                    home.HOMESTATUS1);

                vh.ShowDialog();
            }
            catch (Exception Ex)
            {
                //Error is displayed with a message box to inform user of what mistake was made when data was entered.
                MessageBox.Show(Ex.Message);
                MessageBox.Show("Please ensure all fields are entered as numeric!");
            }

        }
        private void CalculateHomeRental()
        {
            home.RentalAmount = Int32.Parse(txtRent.Text);
            exp.TotalSavings = exp.TotalSavings - home.RentalAmount;
        }

        private void CalculateHomeLoan()
        {
            home.PropPrice = Int32.Parse(txtPropPrice.Text);
            home.PropDep = Int32.Parse(txtPropDep.Text);
            home.Interest = Int32.Parse(txtPropInterest.Text);
            home.PropMonthsRepay = Int32.Parse(txtPropRepay.Text);

            //Determine what the monlthy repayments are.
            DetermineHomeLoan();
        }

        private void DetermineHomeLoan()
        {
            //Hire purchase formula obtained from: https://www.siyavula.com/read/maths/grade-10/finance-and-growth/09-finance-and-growth-03

            decimal PropPrincipal, PropInterestRate, PropTimePeriod, PropAmount;
            double PropMonthly;

            PropPrincipal = (Math.Round(Convert.ToDecimal(home.PropPrice), 2) - Math.Round(Convert.ToDecimal(home.PropDep), 2));
            PropInterestRate = (Math.Round(Convert.ToDecimal(home.Interest), 2) / 100);
            PropTimePeriod = (Math.Round(Convert.ToDecimal(home.PropMonthsRepay), 2) / 12);

            //Formula is implemented: A = P(1+in)
            //P = Property Price - Deposit
            //i = Interest Rate
            //n = montly payments

            PropAmount = PropPrincipal * (1 + (PropInterestRate * PropTimePeriod));

            // Monthly Repayment amount  : A / total montly payments.

            PropMonthly = Convert.ToDouble(PropAmount / home.PropMonthsRepay);
            home.PropRepayments = PropMonthly;
            exp.TotalSavings = exp.TotalSavings - Convert.ToDouble(home.PropRepayments);

            HOMELOANSTATUS();
        }

        private void HOMELOANSTATUS()
        {
            //////////////////////////////////////////////////////////////////////

            //This Method check to see if homeloan exeeeds a third of monthly income.

            double thirdofIncome = exp.MntIncome / 3;
            if (home.PropRepayments > thirdofIncome)
            {
                MessageBox.Show("Unfortunately you do not qualify for a homeloan as your the monthly repayment amount will exceed a third of you're gross income." +
                    "\n*************************************" +
                "\nMonthly Income : R " + exp.MntIncome +
                "\nMonthly RepayAmount : R " + home.PropRepayments +
                "\nThird of Income : R " + Math.Round(Convert.ToDecimal(thirdofIncome), 2));

                home.HOMESTATUS1 = "NO";
            }
            else
            {
                MessageBox.Show("Congratulations! you do qualify for a homeloan since the monthly repayment does not exceed a third of you're gross income." +
                    "\n*************************************" +
                "\nMonthly Income : R " + exp.MntIncome +
                "\nMonthly RepayAmount : R " + home.PropRepayments +
                "\nThird of Income : R " + Math.Round(Convert.ToDecimal(thirdofIncome), 2));

                home.HOMESTATUS1 = "YES";
            }
            
        }

        //////////////////////////////////////////////////__MORE CONTROLS__////////////////////////////////////
        ///
        private void txtBackAcm_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.ShowDialog();

        }

        private void txtHomeAcm_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.ShowDialog();
        }

        private void rbRent_Checked(object sender, RoutedEventArgs e)
        {
            this.txtPropPrice.Background = Brushes.Transparent;
            this.txtPropDep.Background = Brushes.Transparent;
            this.txtPropInterest.Background = Brushes.Transparent;
            this.txtPropRepay.Background = Brushes.Transparent;

            this.txtRent.Background = Brushes.White;
        }

        private void rbBuy_Checked(object sender, RoutedEventArgs e)
        {
            this.txtRent.Background = Brushes.Transparent;

            this.txtPropPrice.Background = Brushes.White;
            this.txtPropDep.Background = Brushes.White;
            this.txtPropInterest.Background = Brushes.White;
            this.txtPropRepay.Background = Brushes.White;
        }

        private void txtExitAcom_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
