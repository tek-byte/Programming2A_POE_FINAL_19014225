using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Savings.xaml
    /// </summary>
    public partial class Savings : Window
    {
        public static Expenses exp = new Expenses();
        public static Homeloan home = new Homeloan();
        public static VehicleLoan veh = new VehicleLoan();

        public static Accommodation acom = new Accommodation(exp.MntIncome, exp.MntTax, exp.TotalExpenses, exp.TaxDone, exp.TotalSavings);
        public static Vehicle vehWin = new Vehicle(exp.MntIncome, exp.MntTax, exp.TotalExpenses, exp.TaxDone, exp.TotalSavings, home.FinalProp, home.HOMESTATUS1);
        public static GoalSaving gls = new GoalSaving();
        public delegate void SeventyFivePtr();
        public static string Display = "";

        public Savings(double Income, double Tax, double TotalExpenses, double AfterTax, double TotalSaved, double FinalProp, string Homeloan, double FinalVeh, string VehiclName)
        {
            InitializeComponent();
            exp.MntIncome = Income;
            exp.MntTax = Tax;
            exp.TotalExpenses = TotalExpenses;
            exp.TaxDone = AfterTax;
            exp.TotalSavings = TotalSaved;
            home.FinalProp = FinalProp;
            home.HOMESTATUS1 = Homeloan;
            veh.FinalVehicle = FinalVeh;
            veh.VehModelMake = VehiclName;
        }

        private void btnCalculateSavings_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                pbCalculation.Value++;
                Thread.Sleep(4);
                
            }

            SeventyFivePtr obj = new SeventyFivePtr(SeventyFivePercent);

            Display =
                "Your savings for this month are as follow:\n" +
                "-------------------------------------------------------------\n" +
                "Monthly Gross income:\t\t\tR " + exp.MntIncome + "\n" +
                "Income After Tax:\t\t\t\tR " + exp.TaxDone + "\n" +
                "-------------------------------------------------------------\n"+
                "TotalExpenses :\t\tR " + exp.TotalExpenses + "\n\n" +
                "Home Amount :\t\tR " + Math.Round(Convert.ToDecimal(home.FinalProp),2) + "\n" +
                "Homeloan Applicaple? :\t" + home.HOMESTATUS1 + "\n\n" +
                "Vehicle Name : \t\t"+ veh.VehModelMake + "\n"+
                "Vehicle Amount :\t\tR " + Math.Round(Convert.ToDecimal(veh.FinalVehicle),2) + "\n\n" +
                "Total Amount Left:\n" +
                "-------------------------------------------------------------\n" +
                "R " + Math.Round(Convert.ToDecimal(exp.TotalSavings),2) + "\n\n";

            txtFinalSavings.Text = Display;
            txtFinalSavings.Foreground = Brushes.Green;

            //Delegate called to calculate if expenses exceeds 75%
            obj.Invoke();
        }


        private void SeventyFivePercent()
        {
            decimal SeventyFive = Math.Round(Convert.ToDecimal(exp.MntIncome), 2) * 75 / 100;

            decimal LeadingExp = Math.Round(Convert.ToDecimal(exp.TotalExpenses), 2)
                                                + Math.Round(Convert.ToDecimal(home.PropRepayments), 2)
                                                + Math.Round(Convert.ToDecimal(veh.VehRepayments), 2);


            //Determines of expenses are more than 75% of income. If true messagebox is displayed.
            if (LeadingExp > SeventyFive)
            {
                MessageBox.Show("All expenses including Home loan and Vehicle Loan are exceeding 75% of you're Income. \n75% of Income: R " + SeventyFive + "\nLeading Expenses: R " + LeadingExp);
            }
            else
            {
                //Incase for testing you can view current seventyfive percent of Income.
            }


        }

        private void btnSavingGoal_Click(object sender, RoutedEventArgs e)
        {
            GoalSaving gls = new GoalSaving();
            gls.ShowDialog();
            
            // Adds to existing display all detail.

            txtFinalSavings.Text = Display +
                "\n"+
                "For Your Goal:\n" +
                "--------------------------------------------------------\n" +
                "Goal Reason:\t\t " + gls.goalname + "\n" +
                "Goal Save Period:\t\t " + gls.goalTime + " Months\n" +
                "Goal Amount :\t\t R " + gls.goalAmount + "\n\n" +
                "Amount to save:\t\t R " + Math.Round(Convert.ToDecimal(gls.monthlyNeeded), 2) + "\n"+
                "--------------------------------------------------------\n" +
                "Savings after Goal amount:\n" +
                "--------------------------------------------------------\n" +
                "R " + Math.Round(Convert.ToDecimal(exp.TotalSavings - gls.monthlyNeeded), 2) + "\n\n";

            txtFinalSavings.Foreground = Brushes.Green;

        }


        //////////////////////////////////////////////////__MORE CONTROLS__////////////////////////////////////
        
        private void txtFinalSavings_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void txtHomeAcm_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.ShowDialog();
        }

        private void txtBackSave_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            vehWin.ShowDialog();
        }

        private void txtExitSave_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
