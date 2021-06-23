using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for GoalSaving.xaml
    /// </summary>
    public partial class GoalSaving : Window
    {
        //New global variables being declared.
        public static Expenses exp = new Expenses();
        public string goalname = "";
        public double goalAmount;
        public double monthlyNeeded;
        public int goalTime;
        public GoalSaving()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //capture values for saving goals
            goalname = txtSaveReason.Text;
            goalAmount = Convert.ToDouble(txtSaveAmount.Text);
            goalTime = Int32.Parse(txtSaveTime.Text)*12;

            monthlyNeeded = goalAmount / goalTime;
            this.Hide();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
