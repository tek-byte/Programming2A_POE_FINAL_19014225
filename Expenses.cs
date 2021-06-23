using System;
using System.Collections.Generic;
using System.Text;

namespace _19014225_Prog6211_POE
{
    public class Expenses
    {
        //Declare variables needed for caputuring and storing expenses

        public double mntIncome;
        public double mntTax;
        public double totalSavings;
        public double taxDone;
        public double totalExpenses;


        //Getters and Setters.


        public double[] expenses = new double[5];

        public double MntIncome { get => mntIncome; set => mntIncome = value; }
        public double MntTax { get => mntTax; set => mntTax = value; }
        public double TotalSavings { get => totalSavings; set => totalSavings = value; }
        public double TaxDone { get => taxDone; set => taxDone = value; }
        public double TotalExpenses { get => totalExpenses; set => totalExpenses = value; }

        public double[]ExpensesArray { get => expenses; set => expenses = value; }

    }
}
