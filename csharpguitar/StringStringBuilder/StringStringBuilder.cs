using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using static System.Console;

namespace StringStringBUilder
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine();

            Stopwatch stopwatchString = new Stopwatch();
            stopwatchString.Start();
            TimeSpan timespanString;

            int Iterations = 100000;
            string PrimaryString = "How Fast am I";
            string ConcatenateString = null;

            for (int x = 0; x < Iterations; x++)
            {
                ConcatenateString += PrimaryString;
            }

            stopwatchString.Stop();
            timespanString = stopwatchString.Elapsed;

            //Console.WriteLine("It took " + String.Format("{0:00}.{0:00}", timespanString.Seconds, timespanString.Milliseconds / 10) + " seconds to iterate " 
            //                             + Iterations.ToString() + " times.  System.String");

            WriteLine("It took " + String.Format("{0:00}.{0:00}", timespanString.Minutes, timespanString.Seconds) + " minutes to iterate "
                                         + Iterations.ToString() + " times.  System.String");

            ReadLine();

            Stopwatch stopwatchStringBuilder = new Stopwatch();
            stopwatchStringBuilder.Start();
            TimeSpan timespanStringBuilder;

            StringBuilder sb = new StringBuilder(PrimaryString);

            for (int x = 0; x < Iterations; x++)
            {
                sb.Append(PrimaryString);
            }

            stopwatchStringBuilder.Stop();
            timespanStringBuilder = stopwatchStringBuilder.Elapsed;

            WriteLine("It took " + String.Format("{0:00}.{1:00}", timespanStringBuilder.Seconds, timespanStringBuilder.Milliseconds / 10) + " to iterate "
                                         + Iterations.ToString() + " times.  StringBuilder");

            ReadLine();
        }
    }
}
