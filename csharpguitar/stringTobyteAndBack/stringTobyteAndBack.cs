using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stringTobyteAndBack
{
    class Program
    {
        static void Main(string[] args)
        {
            string aString = "The Best C# Programmer in the World-Ben Perkins";
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] byteArray = ascii.GetBytes(aString);

            Console.WriteLine("Converted '" + aString + "' to a byte[].");

            Encoding encoder = new ASCIIEncoding();
            string bString = encoder.GetString(byteArray);

            Console.WriteLine("Converted the byte[] back to '" + bString + "'.");

            Console.ReadLine();
        }
    }
}
