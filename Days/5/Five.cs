using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days
{
    public class Five
    {
        public void Run()
        {
            Console.WriteLine("Day 5 Problem 1 Answer: " + Day5Prob1());
            //Console.WriteLine("Day 5 Problem 2 Answer: " + Day5Prob2());
        }

        public int GetRowNumber(string row)
        {
            int rowNum = 0;
            int front = 0;
            int back = 128;

            foreach (char letter in row.Take(7))
            {
                if(letter == 'F')
                {
                    back = back - ((back - front) / 2);
                }
                else
                {
                    front = front + ((back - front) / 2);
                }
            }

            if(row[6] == 'F')
            {
                rowNum = front;
            } else
            {
                rowNum = back - 1;
            }

            return rowNum; 
        }

        public int GetColumnNumber(string row)
        {
            int colNum = 0;
            int left = 0;
            int right = 8;

            foreach (char letter in row.Skip(7).Take(3))
            {
                if (letter == 'L')
                {
                    right = right - ((right - left) / 2);
                }
                else
                {
                    left = left + ((right - left) / 2);
                }
            }

            if (row[9] == 'L')
            {
                colNum = left;
            }
            else
            {
                colNum = right - 1;
            }

            return colNum;
        }


        private int Day5Prob1()
        {
            //Day 5 answer 1 = 978
            string line;
            StreamReader file = new StreamReader("C:\\Users\\Margaret Landefeld\\MyProjects\\AdventOfCode\\Days\\5\\Data.txt");

            int highestID = 1;

            while ((line = file.ReadLine()) != null)
            {
                int row = GetRowNumber(line);
                int column = GetColumnNumber(line);
                int seatID = (row * 8) + column;

                if (seatID > highestID)
                {
                    highestID = seatID;
                }
            }

            return highestID;
        }

        static private int Day5Prob2()
        {
            //Day 5 Answer 2 = 
            int finalSum = 0;


            return finalSum;
        }
    }
}
