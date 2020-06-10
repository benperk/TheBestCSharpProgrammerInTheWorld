using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionSearch
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> pList = new List<Person>() 
            { 
                new Person() { Id = 0, Name = "Jens", Age = 20 },
                new Person() { Id = 1, Name = "Wolfgang", Age = 30 },
                new Person() { Id = 2, Name = "Albert", Age = 22 },
                new Person() { Id = 3, Name = "Andrea", Age = 19 },
                new Person() { Id = 4, Name = "Donna", Age = 23 },
                new Person() { Id = 5, Name = "Mary", Age = 32 },
                new Person() { Id = 6, Name = "Rick", Age = 14 },
                new Person() { Id = 7, Name = "Charles", Age = 34 },
                new Person() { Id = 8, Name = "RB", Age = 55 },
                new Person() { Id = 9, Name = "Todd", Age = 31 },
                new Person() { Id = 9, Name = "Todd2", Age = 31 }
            };

            Console.Write("Enter an Id to search for: ");
            int Identity = Convert.ToInt32(Console.ReadLine());

            Person p = pList.Find(delegate(Person _p)
            {
                if (_p.Id == Identity)
                {
                    Console.WriteLine("The person with Id = " + Identity.ToString() +
                                      " is " + _p.Name +
                                      " and is " + _p.Age.ToString() +
                                      " years old.");
                    return true;
                }

                return false;
            });

            Console.ReadLine();
        }
    }
}
