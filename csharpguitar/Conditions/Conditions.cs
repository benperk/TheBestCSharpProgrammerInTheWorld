using System;
using static System.Console;

public class Conditions
{
    public static void Main(string[] args)
    {
        //add some logic to access a database to confirm you have ample funds
        //change the value to TRUE if we want to deliver the dinero
        bool amountApproved = false;  

        Write("Please enter amount to withdraw: ");

        string enteredValue = ReadLine();

        if (enteredValue.Length > 0 && amountApproved)  
        {
            WriteLine("The amount entered: {0}, will be dispersed.", enteredValue);
        }
        else
        {
            WriteLine("Sorry, the amount {0} exceeds your available credit.", enteredValue);
        }

        ReadLine();
    } 

}
