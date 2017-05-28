using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace Generator
{
    class Program
    {
        static void Main()
        {
            Write("X: ");
            int x = Int32.Parse(ReadLine());
            Write("Y: ");
            int y = Int32.Parse(ReadLine());
            Write("How many generations?");
            int count = Int32.Parse(ReadLine());
            int[,] thisGen = new int[x, y];
            int[,] nextGen = new int[x, y];
            Array[] aoa = new Array[100];
            firstGen(x, y, ref thisGen, ref nextGen);
            compile(x, y, ref thisGen, ref nextGen, count, ref aoa);
            string ans = "";
            while (ans != "end")
            {
                try
                {
                    WriteLine("Which iteration would you like to see? Or, type \"end\" to end");
                    ans = ReadLine();
                    //int[,] tempArray = aoa[Int32.Parse(ans)];
                    visualize(x, y, aoa[Int32.Parse(ans)]);//the line that SEEMS to work
                }
                catch (Exception e)
                {
                    WriteLine("Oops, invalid entry");
                }
            }
        }
        //currently no issue
        public static void firstGen(int x, int y, ref int[,] thisGen, ref int[,] nextGen)
        {
            Random rnd = new Random();
            for (int i = 0; i < thisGen.GetLength(0); i++)
            {
                for (int j = 0; j < thisGen.GetLength(1); j++)
                {
                    if (rnd.Next(0, 4) == 0)
                        thisGen[i, j] = 0;
                    else
                        thisGen[i, j] = 1;
                }
            }
        }

        //no issue
        public static void Generate(int x, int y, ref int[,] thisGen, ref int[,] nextGen)//returns thisGen int[,] array
        {
            for (int i = 0; i < x; i++)//X(rows)
            {
                for (int j = 0; j < y; j++)//Y(columns)
                {
                    int nCount = neighCount(i, j, thisGen);
                    int temp = rule1(i, j, nCount);
                    temp = rule2(i, j, nCount);
                    temp = rule3(i, j, nCount);
                    nextGen[i, j] = temp;
                }
            }
            thisGen = nextGen;
        }

        //currently no issue
        public static void compile(int x, int y, ref int[,] thisGen, ref int[,] nextGen, int count, ref Array[] aoa)
        {
            int iteration = 0;
            while (count != 0)
            {
                Generate(x, y, ref thisGen, ref nextGen);
                aoa[iteration] = thisGen;
                count -= 1;
                iteration += 1;
            }
        }

        //The problematic method...
        public static void visualize(int x, int y, Array aoa)
        {
            int[,] tempArray = new int[x, y];
            tempArray = aoa;//tempArray is an int[,] array and aoa SHOULD be the int[,] array I extracted from 
                            //Array[] aoa in line 32. Array[] aoa is an array of int[,]. In addition to missing
                            //a cast it seems that I didn't extract a 2d array but only an 1d. Maybe "Array aoa"
                            //in parameters should be int[,] aoa, but that breaks even more things...
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (tempArray[i, j] == 1)
                        Write(1 + " ");
                    else
                        Write(0 + " ");
                }
                WriteLine();
            }
        }

        //----------------------------------------
        //EVERYTHING BELOW ISN'T RELEVANT TO ISSUE
        //----------------------------------------
        public static int neighCount(int x, int y, int[,] thisGen)//Counts neighbors
        {
            int neighbors = 0;
            try
            {
                if (thisGen[x - 1, y + 1] == 1)
                    neighbors += 1;
            }
            catch (Exception e) { }
            try
            {
                if (thisGen[x, y + 1] == 1)
                    neighbors += 1;
            }
            catch (Exception e) { }
            try
            {
                if (thisGen[x + 1, y + 1] == 1)
                    neighbors += 1;
            }
            catch (Exception e) { }
            try
            {
                if (thisGen[x - 1, y] == 1)
                    neighbors += 1;
            }
            catch (Exception e) { }
            try
            {
                if (thisGen[x + 1, y] == 1)
                    neighbors += 1;
            }
            catch (Exception e) { }
            try
            {
                if (thisGen[x + 1, y] == 1)
                    neighbors += 1;
            }
            catch (Exception e) { }
            try
            {
                if (thisGen[x - 1, y - 1] == 1)
                    neighbors += 1;
            }
            catch (Exception e) { }
            try
            {
                if (thisGen[x + 1, y - 1] == 1)
                    neighbors += 1;
            }
            catch (Exception e) { }
            return neighbors;
        }
        //***************************** 
        public static int rule1(int x, int y, int neighCount)//rule 1: 3 neigh on, turns on
        {
            if (neighCount == 3)
                return 1;
            else
                return 0;
        }
        public static int rule2(int x, int y, int neighCount)//rule 2: less than 2 neigh on, dies
        {
            if (neighCount < 2)
                return 0;
            else
                return 1;
        }
        public static int rule3(int x, int y, int neighCount)//rule 3: more than 3 neigh, dies
        {
            if (neighCount > 3)
                return 0;
            else
                return 1;
        }
        static void lines()
        {
            for (int i = 0; i < 10; i++)
                WriteLine();
        }
    }
}
