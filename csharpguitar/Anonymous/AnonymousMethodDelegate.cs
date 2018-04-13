using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

delegate decimal CalculateCharge(decimal withdrawal);

class Withdrawal
{
    public string AccountOwnerName;
    public decimal withdrawal;
    public decimal charge;
    public CalculateCharge calculation;
}

class Program
{

    static decimal CalculateStandardCharge(decimal withdrawal)
    {
        return (withdrawal * .01m); //a charge of 1% is levied
    }

    public static void ServiceChargeCalculation(Withdrawal money)
    {
        money.charge = money.calculation(money.withdrawal);
    }

    static void Main(string[] args)
    {

        decimal riskFactor = .02m;

        CalculateCharge standard_charge = new CalculateCharge(CalculateStandardCharge);

        CalculateCharge highRisk_charge = delegate(decimal withdrawal) { return withdrawal * riskFactor; };

        // Let#s create some widrawls and populate them
        Withdrawal[] geld = new Withdrawal[3];

        for (int i = 0; i < 3; i++)
            geld[i] = new Withdrawal();

        geld[0].AccountOwnerName = "Mr Jones";
        geld[0].withdrawal = 20;
        geld[0].calculation = standard_charge;

        geld[1].AccountOwnerName = "Ms Rigby";
        geld[1].withdrawal = 200;
        geld[1].calculation = standard_charge;

        geld[2].AccountOwnerName = "Mr Smith";
        geld[2].withdrawal = 2000;
        geld[2].calculation = highRisk_charge;

        // Calculate the charge for all Withdrawals
        foreach (Withdrawal muenzen in geld)
            ServiceChargeCalculation(muenzen);

        // Display the details of all Employees
        foreach (Withdrawal muenzen in geld)
            DisplayCharges(muenzen);

        ReadLine();

    }

    public static void DisplayCharges(Withdrawal muenzen)
    {
        WriteLine(muenzen.AccountOwnerName);
        WriteLine(muenzen.withdrawal);
        WriteLine(muenzen.charge);
        WriteLine("********************");
    }
}