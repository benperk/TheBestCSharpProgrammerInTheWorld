using System;
using static System.Console;

class Arrays
{
    public static void Main()
    {
        int[] singleDimensionalArray = new int[2];

        singleDimensionalArray[0] = 10101010;
        singleDimensionalArray[1] = 11011001;

        for (int i = 0; i < singleDimensionalArray.Length; i++)
        {
            WriteLine($"singleDimensionalArray value = {singleDimensionalArray[i]}");
        }

        int[,] multiDimensionalArray = new int[2, 2];

        multiDimensionalArray[0, 0] = 100;
        multiDimensionalArray[0, 1] = 101;
        multiDimensionalArray[1, 0] = 210;
        multiDimensionalArray[1, 1] = 211;

        WriteLine($"Length of multiDimensionalArray is {multiDimensionalArray.Length}");
        WriteLine($"Value of multiDimensionalArray[1, 0] is {multiDimensionalArray[1, 0]}");

        int[][] jaggedArray = new int[2][];

        jaggedArray[0] = new int[4];
        jaggedArray[1] = new int[7];

        jaggedArray[0][0] = 100;
        jaggedArray[0][1] = 200;
        jaggedArray[0][2] = 300;
        jaggedArray[0][3] = 400;

        jaggedArray[1][0] = 101;
        jaggedArray[1][1] = 201;
        jaggedArray[1][2] = 301;
        jaggedArray[1][3] = 401;
        jaggedArray[1][4] = 501;
        jaggedArray[1][5] = 601;
        jaggedArray[1][6] = 701;

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            WriteLine($"Length of jaggedArray row {i} is {jaggedArray[i].Length}");
        }

        ReadLine();
    }
}


