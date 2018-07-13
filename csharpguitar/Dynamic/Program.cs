using System;
using static System.Console;
using static System.Convert;

namespace dynamic
{
    public class dynamicClass
    {
        public int AddOne(int originalValue)
        {
            return originalValue + 1;
        }

        public int TripleIt(int originalValue)
        {
            return originalValue * 3;
        }
    }

    class Program
    {
        public static void showSimpleExample()
        {
            Write("Enter a value to add 1 to: ");
            int addOneToIt = ToInt32(ReadLine());
            WriteLine("");

            //Compiler determines the type (in this case it is of type dynamicClass)...at compile time
            var dynamicVar = new dynamicClass();

            WriteLine($"{addOneToIt} + 1 = {dynamicVar.AddOne(addOneToIt)}");
            WriteLine("");

            Write("Enter a value to triple: ");
            int tripleIt = ToInt32(ReadLine());
            WriteLine("");

            dynamic dynamicDynamic = new dynamicClass();

            try
            {
                //The CanAddAnythingHere() does not exist, but the program will compile.
                dynamicDynamic.CanAddAnythingHere();
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                WriteLine("");
                WriteLine("Using a try/catch we can continue using the correct method, the answer is: ");
                WriteLine("");
            }

            WriteLine($"{tripleIt} x 3 = {dynamicDynamic.TripleIt(tripleIt)}");
            ReadLine();
        }

        static void Main(string[] args)
        {
            showSimpleExample();

            double sx = 11.34F;
            int ix = 1;
            double vy = sx + ix;
            Write(vy);
            ReadLine();

            double x = 11.34F;
            int y = 1;
            var z = x + y;
            Write(z);
            ReadLine();
        }
    }
}
