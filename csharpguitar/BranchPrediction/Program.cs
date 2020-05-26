using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;

namespace BranchPrediction
{
    public class Program
    {
        static void Main(string[] args)
        {
            const float MAX = 1000000000;
            double sum = 0;
            Random random = new Random();

            Console.WriteLine();

            Stopwatch stopwatchString = new Stopwatch();
            stopwatchString.Start();
            TimeSpan timespanString;

            //Always TRUE - 3.09
            for (int i = 0; i < MAX; i++) { if ((1 == 1)) { sum++; } }
            //Always FALSE - 2,84
            //for (int i = 0; i < MAX; i++) { if ((1 == 2)) { sum++; } }
            //TFTFTFTF - 3.81
            //for (int i = 0; i < MAX; i++) { if ((i % 2 == 0)) { sum++; } }
            //TFFTFFTFFTFFT - 5.54
            //for (int i = 0; i < MAX; i++) { if ((i % 3 == 0)) { sum++; } }
            //TFFFTFFFTFFFT - 3.79
            //for (int i = 0; i < MAX; i++) { if ((i % 4 == 0)) { sum++; } }
            //8F 8T 8F - 3.76
            //for (int i = 0; i < MAX; i++) { if ((i % 8 == 0)) { sum++; } }
            //16F 16T 16F - 3.90
            //for (int i = 0; i < MAX; i++) { if ((i % 16 == 0)) { sum++; } }
            //Random - 31.67
            //for (int i = 0; i < MAX; i++) { if ((i % random.Next(1, 1000) == 0)) { sum++; } }


            stopwatchString.Stop();
            timespanString = stopwatchString.Elapsed;

            Console.WriteLine("It took " + String.Format("{0:0}.{1:00}", timespanString.Seconds, timespanString.Milliseconds / 10) + " seconds to iterate " 
                             + sum + " times.");

            Console.ReadLine();

        }
    }
}
