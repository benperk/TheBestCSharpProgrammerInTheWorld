using System;
using System.Text;
using static System.Console;

using System.Collections.Generic;

namespace HexToBinaryToText
{
    class Program
    {
        static void Main(string[] args)
        {
            string hexValue = "54686973206973206120746578742066696C652074686174204920" +
                              "77616E7420746F2073686F7720696E207468652048657856696577" +
                              "20746162206F6620466964646C65722E20204A75737420666F7220" +
                              "66756E2E20486572652061726520736F6D65207370656369616C20" +
                              "636861726163746572732073657065726174656420627920612063" +
                              "6F6D6D6120C3A42C20C3B62C20C3BC2C20C39F";

            string[] hexArray = new string[154];  //hexValue.Length = 308 / 2 = 154
            int location = 0;
            for (int i = 0; i < hexValue.Length / 2; i++)
            {
                hexArray[i] = hexValue.Substring(location, 2);
                location = location + 2;
            }
            StringBuilder sbBinary = new StringBuilder();
            StringBuilder sbBinaryZero = new StringBuilder();
            var list = new List<Byte>();
            for (int i = 0; i < hexArray.Length; i++)
            {
                sbBinary.Append(Convert.ToString(Convert.ToInt32(hexArray[i], 16), 2)); //base 16 , 2 hex chars per ASCII character
                var bit = "0" + Convert.ToString(Convert.ToInt32(hexArray[i], 16), 2);
                sbBinaryZero.Append("0" + Convert.ToString(Convert.ToInt32(hexArray[i], 16), 2));
                list.Add(Convert.ToByte(bit, 2));
            }
            var text = Encoding.ASCII.GetString(list.ToArray());

            StringBuilder sbASCII = new StringBuilder();
            for (int i = 0; i < hexArray.Length; i++)
            {
                uint decoded = System.Convert.ToUInt32(hexArray[i], 16);
                char character = System.Convert.ToChar(decoded);
                sbASCII.Append(character);
            }
            WriteLine($"The HEX value of {hexValue}");
            WriteLine();
            WriteLine();
            WriteLine($"Has a '7-bit' binary value of {sbBinary}");
            WriteLine();
            WriteLine();
            WriteLine($"Has an '8-bit' binary value of {sbBinaryZero}");
            WriteLine();
            WriteLine();
            WriteLine($"And has a '7-bit' character value of:");
            WriteLine(sbASCII);
            WriteLine();
            WriteLine();
            WriteLine($"And has an '8-bit' character value of:");
            WriteLine(text);
            ReadLine();
        }
    }
}
