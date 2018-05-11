using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListAddRange
{
    class Program
    {
        public static List<string> First = new List<string>();
        public static List<string> Second = new List<string>();

        public static void PopulateFirstList(string code)
        {
            First.Add(code);
        }

        public static void PopulateSecondList(string code)
        {
            Second.Add(code);
        }

        static void Main(string[] args)
        {
            PopulateFirstList("USD");
            PopulateFirstList("EUR");
            PopulateFirstList("CHF");
            PopulateFirstList("INR");
            PopulateFirstList("GBP");
            PopulateFirstList("CAD");
            PopulateFirstList("PKR");
            PopulateFirstList("TRY");
            PopulateFirstList("RUB");
            PopulateFirstList("AED");

            PopulateSecondList("NZD");
            PopulateSecondList("BRL");
            PopulateSecondList("SEK");
            PopulateSecondList("EUR");
            PopulateSecondList("VND");
            PopulateSecondList("ILS");
            PopulateSecondList("ISK");
            PopulateSecondList("CNY");
            PopulateSecondList("PLN");
            PopulateSecondList("UAH");

            First.AddRange(Second);
        }
    }
}
