using System;
using System.Linq;
using static System.Console;

using System.Reflection;

namespace LinqToReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asmembly = Assembly.Load("Oracle.DataAccess");

            var ODPTypes = from type in asmembly.GetTypes()
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
        }
    }
}
