using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericInterface
{
    class Program
    {
        public interface IGuitar<T>
        {
            string Name { get; set; }
            string GetBodyStyle(T t);
        }

        public class ElectricGuitar : IGuitar<ElectricGuitar>
        {
            public string Name { get; set; }
            public string GetBodyStyle(ElectricGuitar t)
            {
                return "The electric guitar is: " + t.Name;
            }
        }

        public class ClassicalGuitar : IGuitar<ClassicalGuitar>
        {
            public string Name { get; set; }
            public string GetBodyStyle(ClassicalGuitar t)
            {
                return "The classical guitar is: " + t.Name;
            }
        }

        static void Main(string[] args)
        {
            ElectricGuitar eGuitar = new ElectricGuitar();
            eGuitar.Name = "Charvel Model 5";
            Console.WriteLine(eGuitar.GetBodyStyle(eGuitar));

            ClassicalGuitar cGuitar = new ClassicalGuitar();
            cGuitar.Name = "Takamine C132S";
            Console.WriteLine(cGuitar.GetBodyStyle(cGuitar));

            Console.ReadLine();

        }
    }
}
