using System;
using System.Linq;

using System.Reflection;

using System.Linq.Expressions;

using static System.Console;

namespace LinqToReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.Load("Oracle.DataAccess");

            var ODPTypes = from type in assembly.GetTypes()
                              where type.IsPublic
                              from method in type.GetMethods()
                              where method.ReturnType.FullName != "System.String"
                              group method.ToString() by type.ToString();

            foreach (var ODPMethods in ODPTypes)
            {
                WriteLine("Type: {0}", ODPMethods.Key);
                foreach (var method in ODPMethods)
                {
                    WriteLine("    {0}", method);
                }
            }
            ReadLine();

            foreach (var odpTypes in assembly.GetTypes().Where(a => a.IsPublic))
            {
                WriteLine("Type: {0}", odpTypes.FullName);
                foreach (var odpMethods in odpTypes.GetMethods().Where(i => i.ReturnType.FullName != "System.String"))
                {                    
                    WriteLine("      {0}", odpMethods.ReturnType + " " + odpMethods.Name);
                }
            }

            ReadLine();
        }
    }
}
