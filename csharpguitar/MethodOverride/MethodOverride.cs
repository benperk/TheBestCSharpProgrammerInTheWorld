using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodOverride
{
    class Program
    {
        public class Class3<T>
        {
            public virtual T MethodToReturnSomethingGeneric(T item)
            {
                return item;
            }
        }

        public class Class4<T> : Class3<T>
        {
            public override T MethodToReturnSomethingGeneric(T item)
            {
                return item;
            }
        }

        public class Class1
        {
            public virtual List<string> MethodToReturnSomething()
            {
                List<string> list = new List<string>();
                list.Add("Class1 String");
                return list;
            }
        }

        //C# doesn't (yet) support covariant return types
        //Override a method and return a different type

        public class Class2 : Class1
        {
            //public override List<int> MethodToReturnSomething()
            public override List<string> MethodToReturnSomething()
            {
                List<string> list = new List<string>();
                list.Add("Class2 String");

                List<int> intList = new List<int>();
                intList.Add(100);

                return list;
                //return intList;
            }
        }

        static void Main(string[] args)
        {
            Class2 cl2 = new Class2();
            List<string> list2 = cl2.MethodToReturnSomething();
            Console.WriteLine(list2[0]);
            Console.WriteLine();

            //Class1 cl1 = new Class2();
            //List<string> list1 = cl1.MethodToReturnSomething();

            //Console.WriteLine(list1[0]);
            //Console.WriteLine();

            Class1 cl3 = new Class1();
            List<string> list3 = cl3.MethodToReturnSomething();
            Console.WriteLine(list3[0]);
            Console.WriteLine();

            Class3<int> cl4 = new Class3<int>();
            Console.WriteLine("Class3 int: " + cl4.MethodToReturnSomethingGeneric(100).ToString());
            Console.WriteLine();

            Class3<string> cl5 = new Class3<string>();
            Console.WriteLine("Class3 string: " + cl5.MethodToReturnSomethingGeneric("C# Rocks!").ToString());
            Console.WriteLine();

            Class4<int> cl6 = new Class4<int>();
            Console.WriteLine("Class4 int: " + cl6.MethodToReturnSomethingGeneric(100).ToString());
            Console.WriteLine();

            Class4<string> cl7 = new Class4<string>();
            Console.WriteLine("Class4 string: " + cl7.MethodToReturnSomethingGeneric("C# Rocks...hard!").ToString());
            Console.WriteLine();

            Console.ReadLine();

        }
    }
}
