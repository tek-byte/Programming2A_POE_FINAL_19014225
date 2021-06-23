using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Vehicle.xaml
    /// </summary>
    public partial class Vehicle : Window
    {
        public static VehicleLoan veh = new VehicleLoan();
        public static Expenses exp = new Expenses();
        public static Homeloan home = new Homeloan();
        public static Accommodation acomWin = new Accommodation(exp.MntIncome, exp.MntTax, exp.TotalExpenses, exp.TaxDone, exp.TotalSavings);


        //public static Savings savWin = new Savings();


        public Vehicle(double Income, double Tax, double TotalExpenses, double AfterTax, double TotalSaved, double FinalProp, string Homeloan)
        {
            //Updates new values recieved.

            InitializeComponent();
            exp.MntIncome = Income;
            exp.MntTax = Tax;
            exp.TotalExpenses = TotalExpenses;
            exp.TaxDone = AfterTax;
            exp.TotalSavings = TotalSaved;
            home.FinalProp = FinalProp;
            home.HOMESTATUS1 = Homeloan;
        }

        private void txtCaptureVehicle_Click(object sender, RoutedEventArgs e)
        {
            try //Error handling is implemented.
            {

                ////////////_VEHICLE DETAILS_///////////

                if (rbYes.IsChecked == true)
                {
                    CalculateVehicle();
                    veh.FinalVehicle = veh.vehRepayments;
                }
                else if (rbNo.IsChecked == true)
                {
                    veh.FinalVehicle = 0;
                }

                //MessageBox.Show("All details captured successfully!");

                //Push updated values through to Savings class
                Savings save = new Savings(
                exp.MntIncome,
                exp.MntTax,
                exp.TotalExpenses,
                exp.TaxDone,
                exp.TotalSavings,
                home.FinalProp,
                home.HOMESTATUS1,
                veh.FinalVehicle,
                veh.VehModelMake);
                this.Hide();        //Hides current window
                save.ShowDialog();      //Opens new next Window.
            }
            catch (Exception Ex)
            {
                //Error is displayed with a message box to inform user of what mistake was made when data was entered.
                MessageBox.Show(Ex.Message);
                MessageBox.Show("Please ensure all fields are entered as numeric!");
            }

        }
        private void CalculateVehicle()
        {
            //Saves values captured.

            veh.VehModelMake = txtVehModel.Text;
            veh.VehAmount = Int32.Parse(txtVehPrice.Text);
            veh.VehTotalDep = Int32.Parse(txtVehDep.Text);
            veh.VehInterest = Int32.Parse(txtVehInterest.Text);
            veh.VehInsPrem = Int32.Parse(txtVehInsurance.Text);

            DetermineVehicle();
        }

        private void DetermineVehicle()
        {
            //Hire purchase formula obtained from: https://www.siyavula.com/read/maths/grade-10/finance-and-growth/09-finance-and-growth-03

            decimal VehPrincipal, VehInterestRate, VehTimePeriod, VehAmount;
            double VehMonthly;

            VehPrincipal = (Math.Round(Convert.ToDecimal(veh.VehAmount), 2) - Math.Round(Convert.ToDecimal(veh.VehTotalDep), 2));
            VehInterestRate = (Math.Round(Convert.ToDecimal(veh.VehInterest), 2) / 100);
            VehTimePeriod = 5;

            //Formula is implemented: A = P(1+in)
            //P = Property Price - Deposit
            //i = Interest Rate
            //n = montly payments

            VehAmount = VehPrincipal * (1 + (VehInterestRate * VehTimePeriod));

            // Monthly Repayment amount  : A / total montly payments.

            VehMonthly = Convert.ToDouble(VehAmount / 60);
            VehMonthly = VehMonthly + veh.VehInsPrem;
            veh.VehRepayments = VehMonthly;

            exp.TotalSavings = exp.TotalSavings - Convert.ToDouble(veh.VehRepayments);

            //VEHICLESTATUS();
        }


        //////////////////////////////////////////////////__MORE CONTROLS__////////////////////////////////////

        private void txtHomeAcm_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.ShowDialog();
        }

        private void txtHomeVeh_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.ShowDialog();
        }

        private void txtBackVeh_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            acomWin.ShowDialog();
        }

        private void rbNo_Checked(object sender, RoutedEventArgs e)
        {
            this.txtVehModel.Background = Brushes.Transparent;
            this.txtVehPrice.Background = Brushes.Transparent;
            this.txtVehInterest.Background = Brushes.Transparent;
            this.txtVehDep.Background = Brushes.Transparent;
            this.txtVehInsurance.Background = Brushes.Transparent;

        }

        private void rbYes_Checked(object sender, RoutedEventArgs e)
        {
            this.txtVehModel.Background = Brushes.White;
            this.txtVehPrice.Background = Brushes.White;
            this.txtVehInterest.Background = Brushes.White;
            this.txtVehDep.Background = Brushes.White;
            this.txtVehInsurance.Background = Brushes.White;
        }

        private void txtExitVeh_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
