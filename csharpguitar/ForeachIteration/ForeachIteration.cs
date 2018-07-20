using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using static System.Console;

namespace ForEachFor
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfStrings = new List<string>(LoadSomeStrings());

            foreach (string item in listOfStrings)
            {
                WriteLine($"{item}. --foreach--");

                if (item.EndsWith("10"))
                {
                    //item = "Can't modify members in foreach iteration variable";
                    WriteLine("Can't do anything but read the value.");
                }                
            }

            ReadLine();  // Wait for response from user

            for (int i = 0; i < listOfStrings.Count; i++)
            {
                if (listOfStrings[i].EndsWith("10"))
                {
                    //Can modify members in for loop";
                    listOfStrings[i] = $"Modifed string number {i.ToString()}";
                }

                WriteLine(listOfStrings[i] + ". --for--");
            }

            ReadLine();  // Wait for response from user

        }

        public static List<string> LoadSomeStrings()
        {
            List<string> list = new List<string>();

            for (int i = 0; i < 20; i++)
            {
                list.Add($"Added string number {i.ToString()}");
            }

            return list;
        }
    }
}
