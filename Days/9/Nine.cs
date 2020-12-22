using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Days
{
    public class Nine
    {
        public void Run()
        {
            string data = Parse();
            //Console.WriteLine("Day 9 Problem 1 Answer: " + Day9Prob1(data));
            //Console.WriteLine("Day 9 Problem 2 Answer: " + Day9Prob2(data));
        }

        public string Parse()
        {
            string line;
            StreamReader file = new StreamReader("C:\\Users\\Margaret Landefeld\\MyProjects\\AdventOfCode\\Days\\9\\Data.txt");
            List<Instruction> Instructions = new List<Instruction>();
            int rowCount = 1;

            while ((line = file.ReadLine()) != null)
            {

            }

            return "test";
        }

        public int Day9Prob1(string data)
        {
            return 0;
        }

        public int Day9Prob2(string data)
        {
            return 0;
        }

    }
}
