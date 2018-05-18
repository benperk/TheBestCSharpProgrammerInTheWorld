using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Linq.Expressions;

using static System.Console;

namespace ReflectionOrderBy
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.Load("SimpleClass");

            var SCTypes = from type in assembly.GetTypes().OrderBy(t => t.MetadataToken)
                          where type.IsPublic
                          from properties in type.GetProperties().OrderBy(p => p.MetadataToken)
                          group properties.ToString() by type.ToString();

            //var SCTypes = from type in assembly.GetTypes()
            //              where type.IsPublic
            //              from properties in type.GetProperties()
            //              group properties.ToString() by type.ToString();

            foreach (var SCMethods in SCTypes)
            {
                WriteLine("Type: {0}", SCMethods.Key);
                foreach (var method in SCMethods)
                {
                    WriteLine(" Property: {0}", method);
                }
            }

            ReadLine();
        }
    }
}
