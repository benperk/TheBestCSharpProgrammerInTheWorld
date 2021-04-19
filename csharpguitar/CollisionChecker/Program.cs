using System;
using System.Text.RegularExpressions;
using System.Linq;
using static System.Console;

namespace CollisionChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            //A host ID must be between 1 and 32 characters, contain only lowercase letters, numbers, and 
            //dashes, not start or end with a dash, and not contain consecutive dashes

            try
            {
                WriteLine("Enter a hostId: ");
                WriteLine();
                string hostId = ReadLine();
                WriteLine();
                while (hostId.Length > 0)
                {
                    if (LengthCheck(hostId))
                    {
                        WriteLine($"The hostId is {hostId.Length} characters long. The hostId must be between 1 and 32 characters.");
                    }
                    if (CaseCheck(hostId))
                    {
                        WriteLine($"The hostId must be lower case.");
                    }
                    if (SpecialCharacterCheck(hostId))
                    {
                        WriteLine($"Special characters are not allowed, only lowercase letters, numbers, and dashes are allowed.");
                    }
                    if (DashCheck(hostId))
                    {
                        WriteLine($"A dash '-' cannot be the first or last character.");
                    }
                    if (ConsecutiveDashes(hostId))
                    {
                        WriteLine($"Consecutive dashes '--' are not allowed.");
                    }

                    WriteLine($"RegexCheck returned: {IsHostIdCompliant(hostId)}");
                    WriteLine();
                    WriteLine("Enter a hostId or press enter to exit: ");
                    WriteLine();
                    hostId = ReadLine();
                    WriteLine();
                }
            }
            catch (Exception ex)
            {
                WriteLine($"This happened: {ex.Message}");
            }
        }

        public static bool LengthCheck(string hostId) => hostId.Length < 1 || hostId.Length > 32;
        public static bool CaseCheck(string hostId) => !hostId.Any(char.IsLower);
        public static bool SpecialCharacterCheck(string hostId) => hostId.Replace("-", "").Any(s => !char.IsLetterOrDigit(s));
        public static bool DashCheck(string hostId) => hostId.StartsWith("-") || hostId.EndsWith("-");
        public static bool ConsecutiveDashes(string hostId) => hostId.Contains("--");

        //You don't know where this failed, you just know it failed which doesn't allow good return messages
        //^         - anchor, start of the string
        //(?!-)     - first character is not a dash
        //(?!.*--)  - no consecutive dashes
        //[-0-9a-z] - allow a dash, no special characters, no upper case
        //{1,32}    - between 1 and 32 characters
        //(?<!-)    - last character is not a dash
        //$         - anchor, end of the string
        public static bool IsHostIdCompliant(string hostId) => Regex.IsMatch(hostId, @"^(?!-)(?!.*--)[-0-9a-z]{1,32}(?<!-)$");
    }
}
