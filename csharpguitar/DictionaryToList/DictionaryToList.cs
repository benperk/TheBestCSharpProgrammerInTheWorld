using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryToList
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> coolDictionary = new Dictionary<string, string>();

            coolDictionary.Add("Telecaster", "FENDER");
            coolDictionary.Add("Stratocaster", "FENDER");
            coolDictionary.Add("Model 5", "CHARVEL");
            coolDictionary.Add("C132S", "TAKAMINE");
            coolDictionary.Add("Model 4", "CHARVEL");

            Console.WriteLine();
            Console.WriteLine("List of Builder and Model from dictionary:");
            Console.WriteLine();
            foreach (var info in coolDictionary)
            {
                Console.WriteLine("The builder of " + info.Key + " is " + info.Value);
            }

            List<string> guitarBuilder = coolDictionary.Values.ToList<string>();
            List<string> guitarModel = coolDictionary.Keys.ToList<string>();

            Console.WriteLine("List of builders from list:");
            Console.WriteLine();
            foreach (var builder in guitarBuilder)
            {
                Console.WriteLine(builder);
            }

            Console.WriteLine();
            Console.WriteLine("List of models from list");
            Console.WriteLine();
            foreach (var model in guitarModel)
            {
                Console.WriteLine(model);
            }

            Console.ReadLine();

        }
    }
}
