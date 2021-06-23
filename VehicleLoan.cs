using System;
using System.Collections.Generic;
using System.Text;

namespace _19014225_Prog6211_POE
{
    public class VehicleLoan
    {

        //Declare variables needed for caputuring and storing expenses

        public string vehModelMake;
        public double vehAmount;
        public double vehTotalDep;
        public double vehInterest;
        public double vehInsPrem;
        public int vehmonthsRepay;
        public double vehRepayments;
        public double finalVehicle;


        //Getters and Setters.
        public double[] expenses = new double[5];

        public string VehModelMake { get => vehModelMake; set => vehModelMake = value; }
        public double VehAmount { get => vehAmount; set => vehAmount = value; }
        public double VehTotalDep { get => vehTotalDep; set => vehTotalDep = value; }
        public double VehInterest { get => vehInterest; set => vehInterest = value; }
        public double VehInsPrem { get => vehInsPrem; set => vehInsPrem = value; }
        public double VehRepayments { get => vehRepayments; set => vehRepayments = value; }
        public int VehmonthsRepay { get => vehmonthsRepay; set => vehmonthsRepay = value; }
        public double FinalVehicle { get => finalVehicle; set => finalVehicle = value; }
    }
}
