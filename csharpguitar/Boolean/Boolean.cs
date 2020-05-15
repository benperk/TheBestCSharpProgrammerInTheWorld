using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace boolean
{
    class Program
    {
        static void Main(string[] args)
        {
            //***********************Integer******************
            int iTrue = 1;
            //bool boolValue = (iTrue == 1);
            bool boolValue = Convert.ToBoolean(1);

            if (boolValue)
            {
                Console.WriteLine("Integer - True");
            }
            else
            {
                Console.WriteLine("Integer - False");
            }


            //***********************Byte******************
            byte bTrue = 1;
            //bool boolValuB = (bTrue == 1);
            bool boolValueB = Convert.ToBoolean(bTrue);

            if (boolValueB)
            {
                Console.WriteLine("byte - True");
            }
            else
            {
                Console.WriteLine("byte - False");
            }

            //***********************Char******************
            char cTrue = 'N';
            //bool boolValueC = (cTrue == 'Y' ? true : false);
            //bool boolValueC = cTrue != 'N';
            bool boolValueC = !(cTrue == 'N');

            if (boolValueC)
            {
                Console.WriteLine("char - True");
            }
            else
            {
                Console.WriteLine("char - False");
            }

            //***********************String******************
            string sTrue = "true";
            //bool boolValueS = !(sTrue == "true");
            bool boolValueS = Convert.ToBoolean(sTrue);

            if (boolValueS)
            {
                Console.WriteLine("string - True");
            }
            else
            {
                Console.WriteLine("string - False");
            }
            
            Console.ReadLine();
        }
    }
}
