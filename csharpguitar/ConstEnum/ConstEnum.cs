using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConstEnum
{
    public class Constants
    {
        public const string SERVER_NAME = "WOODPECKER";
        public const int SERVER_TYPE = (int)ServerType.Web;
        public const float PURCHASE_PRICE = 5995.75F;
    }

    public enum ServerType { Database, Web, Mail, Proxy, Batch, Application }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The name of the server is: " + Constants.SERVER_NAME);

            if (Constants.SERVER_TYPE == (int)ServerType.Web)
            {
                Console.WriteLine();
                Console.WriteLine("The type of the server is Web");
            }

            Console.WriteLine();
            Console.WriteLine("It had a cost of " + Constants.PURCHASE_PRICE);

            Console.ReadLine();

        }
    }
}
