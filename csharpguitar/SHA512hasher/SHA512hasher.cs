using System;
using System.Security.Cryptography;
using System.Text;
using static System.Console;

namespace Security
{
    class SHA512hasher
    {
        public static string hashSHA512(string unhashedValue)
        {
            SHA512 shaM = new SHA512Managed();
            byte[] hash = shaM.ComputeHash(Encoding.ASCII.GetBytes(unhashedValue));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }

        public static bool Validate(string enteredValue, string hashedValue)
        {
            if (hashSHA512(enteredValue) == hashedValue) return true;

            return false;
        }

        static void Main(string[] args)
        {
            Write("Enter something to hash with SHA 512: ");
            string notHashed = ReadLine();

            string Hashed = hashSHA512(notHashed);

            WriteLine(" ");
            WriteLine("SHA encrypted value is: {0}", Hashed);
            WriteLine(" ");
            Write("Enter what you just encrypted: ");
            notHashed = ReadLine().ToString();
            WriteLine(" ");
            if (Validate(notHashed, Hashed))
            {
                WriteLine("The 2 values you entered are a match!");
            }
            else
            {
                WriteLine("The 2 values you entered are not a match!");
            }

            ReadLine();
        }
    }
}
