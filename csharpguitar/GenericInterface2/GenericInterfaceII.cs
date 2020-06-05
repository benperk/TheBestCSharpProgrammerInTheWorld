using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericInterface
{
    class Program
    {
        public class GuitarBase
        {
            public string Builder { get; set; }
            public DateTime GetBuildDate()
            {
                return DateTime.Now;
            }
        }

        public class GuitarBaseExtended : GuitarBase
        {
            public int Cost { get; set; }
            public int GetSoldFor()
            {
                Random random = new Random();
                int RandomNumber = random.Next(2, 5);

                return RandomNumber * Cost;
            }
        }

        public class GuitarBaseOptional
        {
            public int NumberOfStrings { get; set; }
        }

        public interface IGuitar<T> where T : GuitarBase
        {
            string Name { get; set; }
            string GetType(T t);
        }

        public class ElectricGuitar : GuitarBaseExtended, IGuitar<ElectricGuitar>
        {
            public string Name { get; set; }
            public string GetType(ElectricGuitar t)
            {
                return "The electric guitar is: " + t.Name;
            }
        }

        public class ClassicalGuitar : GuitarBaseExtended, IGuitar<ClassicalGuitar>
        {
            public string Name { get; set; }
            public string GetType(ClassicalGuitar t)
            {
                return "The classical guitar is: " + t.Name;
            }
        }

        //public class SteelGuitar : GuitarBaseOptional, IGuitar<SteelGuitar>
        //{
        //    public string Name { get; set; }
        //    public string GetType(ClassicalGuitar t)
        //    {
        //        return "The classical guitar is: " + t.Name;
        //    }
        //}

        static void Main(string[] args)
        {
            ElectricGuitar eGuitar = new ElectricGuitar();
            eGuitar.Name = "Model 5";
            Console.WriteLine(eGuitar.GetType(eGuitar));
            eGuitar.Builder = "Charvel";
            Console.WriteLine("The builder is :" + eGuitar.Builder);
            Console.WriteLine("It was built on :" + eGuitar.GetBuildDate());
            eGuitar.Cost = 800;
            Console.WriteLine("It sold for :" + eGuitar.GetSoldFor().ToString());
            Console.WriteLine();

            ClassicalGuitar cGuitar = new ClassicalGuitar();
            cGuitar.Name = "C132S";
            Console.WriteLine(cGuitar.GetType(cGuitar));
            cGuitar.Builder = "Takamine";
            Console.WriteLine("The builder is :" + cGuitar.Builder);
            Console.WriteLine("It was built on :" + cGuitar.GetBuildDate());
            cGuitar.Cost = 350;
            Console.WriteLine("It sold for :" + cGuitar.GetSoldFor().ToString());

            Console.ReadLine();

        }
    }
}
