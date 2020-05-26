using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************String.Join***************");
            Console.WriteLine();
            int arrLength = 10;
            string[] array1 = new string[arrLength];

            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = "The Best C# Programmer in the World - Ben Perkins - " + i.ToString();
            }

            for (int i = 0; i < array1.Length; i++)
            {
                Console.WriteLine(array1[i]);
            }
            
            Console.WriteLine();

            string joinWithComma = string.Join(", ", array1.ToArray());

            Console.WriteLine(joinWithComma);
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine();
            Console.ReadLine();

            Console.WriteLine("**************String.Format***************");
            Console.WriteLine();
            string string1 = "I have {0} computers.";
            string Results = String.Format(string1, "10");

            Console.WriteLine(Results);
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine();
            Console.ReadLine();

            Console.WriteLine("**************String.InstanceOf***************");
            Console.WriteLine();
            string String1 = "The Best C# Programmer in the World - Ben Perkins";
            string findIt = "C#";
            if (String1.IndexOf(findIt) > -1)
            {
                Console.WriteLine("Found it");
            }
            else
            {
                Console.WriteLine("Did not find it");
            }
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine();
            Console.ReadLine();

            Console.WriteLine("**************String.Substring***************");
            Console.WriteLine();
            string oldString1 = "Ben Perkins";
            string newString1 = oldString1.Substring(4);

            Console.WriteLine("New String 1 is " + newString1);

            string newString2 = oldString1.Substring(0, 3);

            Console.WriteLine("New String 2 is " + newString2);

            string old = "Ben Perkins, The Best C# Programmer in the World";
            string newString = old.Substring(old.IndexOf("The"));

            Console.WriteLine("New String is " + newString);
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine();
            Console.ReadLine();


            Console.WriteLine("**************String.Equals***************");
            Console.WriteLine();
            string string7 = "C# Programming rocks!";

            if (string7.Equals("C# Programming rocks!"))
            {
                Console.WriteLine("C# Programming rocks!  I knew it all along");
            }
            else
            {
                Console.WriteLine("LiarLiarPantsOnFireException");
            }
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine();
            Console.ReadLine();


            Console.WriteLine("**************String.Remove***************");
            Console.WriteLine();
            string string8 = "The Best C# Programmer in the World";
            string string9 = string8.Remove(22);

            Console.WriteLine(string8 + " is now " + string9);

            Console.WriteLine();

            string string10 = "The Best C# Programmer in the World";
            string string11 = string10.Remove(9, 3);

            Console.WriteLine(string10 + " is now " + string11);
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine();
            Console.ReadLine();


            Console.WriteLine("**************String.Trim***************");
            Console.WriteLine();
            string oldString11 = "     The Best C# Programmer in the World     ";
            string newString11 = oldString11.Trim();


            Console.WriteLine("This string: " + oldString11);
            Console.WriteLine("Is now: " + newString11);
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine();
            Console.ReadLine();

            Console.WriteLine("**************String.Split***************");
            Console.WriteLine();
            string splitIt = "The,Best,C#,Programmer,in,the,World";
            List<string> splitList = splitIt.Split(new char[] { ',' }).ToList<string>();

            Console.WriteLine("This string: " + splitIt);
            Console.WriteLine();
            Console.WriteLine("Is now: ");
            for (int i = 0; i < splitList.Count; i++)
            {
                Console.WriteLine(splitList[i]);
            }
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine();
            Console.ReadLine();

            Console.WriteLine("**************String.Replace***************");
            Console.WriteLine();
            string oldString12 = "The Best Java Programmer in the World";
            string newString12 = oldString12.Replace("Java", "C#");


            Console.WriteLine("This string: " + oldString12);
            Console.WriteLine("Is now: " + newString12);
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}
