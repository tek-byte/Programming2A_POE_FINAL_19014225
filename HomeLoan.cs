using System;
using System.Collections.Generic;
using System.Text;

namespace _19014225_Prog6211_POE
{
    public class Homeloan
    {
        //Declare variables needed for calculating the homeloan.

        public double rentalAmount;
        public double propPrice;
        public double propDep;
        public int interest;
        public int propmonthsRepay;
        public string HOMESTATUS;

        public double propRepayments;
        public double finalProp;

        //Getters and Setters.
        public double PropPrice { get => propPrice; set => propPrice = value; }
        public double PropDep { get => propDep; set => propDep = value; }
        public int Interest { get => interest; set => interest = value; }
        public int PropMonthsRepay { get => propmonthsRepay; set => propmonthsRepay = value; }
        public double PropRepayments { get => propRepayments; set => propRepayments = value; }
        public double RentalAmount { get => rentalAmount; set => rentalAmount = value; }
        public string HOMESTATUS1 { get => HOMESTATUS; set => HOMESTATUS = value; }
        public double FinalProp { get => finalProp; set => finalProp = value; }
    }
}
