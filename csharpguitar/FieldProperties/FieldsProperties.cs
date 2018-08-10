using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Field
{
    class Program
    {
        public class InstanceCustomer
        {
            public InstanceCustomer(string name) { Name = name; }

            //Property
            public string Name { get; set; }

            //Insatnce Field
            public string name = "<default value>";
        }

        public class StaticCustomer
        {
            public StaticCustomer(string name){ Name = name; }

            //Property
            public string Name { get; set; }

            //Static Field (not a good idea...)
            public static string name = "<default value>";

            public static string GetStaticName(StaticCustomer sCustomer)
            {
                return name;
            }
        }

        static void Main(string[] args)
        {
            InstanceCustomer iCustomer1 = new InstanceCustomer("John");
            InstanceCustomer iCustomer2 = new InstanceCustomer("Yolanda");

            WriteLine($"Instance Customer 1 : {iCustomer1.Name} created.");
            WriteLine($"Instance Customer 2 : {iCustomer2.Name} created.");
            WriteLine();            

            StaticCustomer sCustomer1 = new StaticCustomer("Juan");
            StaticCustomer sCustomer2 = new StaticCustomer("Chantel");

            WriteLine($"Static Customer 1 : {sCustomer1.Name} created.");
            WriteLine($"Static Customer 2 : {sCustomer2.Name} created.");
            WriteLine();

            //Modify instance field (name) of Instance Customer 1 - no change to Customer 2
            iCustomer1.name = "John Insatnce";
            WriteLine($"Instance Customer 1 : {iCustomer1.name} modified.");
            WriteLine($"Instance Customer 2 : {iCustomer2.name} not modified.");
            WriteLine(); 

            //Modify static field (name) of Static Customer 1 - value changed for both (not generally wanted)
            StaticCustomer.name = "Fred";
            WriteLine($"Static Customer 1 : {StaticCustomer.GetStaticName(sCustomer1)} modified.");
            WriteLine($"Static Customer 2 : {StaticCustomer.GetStaticName(sCustomer2)} not modified, but changed.");
            WriteLine();

            ReadLine();
        }
    }
}
