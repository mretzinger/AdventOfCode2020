using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Three
    {
        public void Run()
        {
            //char[,] data = Parse();
            //Console.WriteLine("Day 2 Problem 1 Answer: " + Day3Prob1());
            Console.WriteLine("Day 2 Problem 2 Answer: " + Day3Prob2());
        }

        public char[,] Parse()
        {
            string line;
            StreamReader file = new StreamReader("C:\\Users\\Margaret Landefeld\\MyProjects\\AdventOfCode\\Days\\Three\\Data.txt");

            int linelength = file.ReadLine().Count();
            int lineHeight = file.ReadToEnd().Replace("\n", "").Replace("\r", "").Count() / linelength;

            Console.WriteLine(lineHeight);

            char[,] inputArray = new char[lineHeight, linelength];
            //int charIndex = 1;
            int height = 0;

            while ((line = file.ReadLine()) != null)
            {
                int width = 0;

                foreach (char i in line)
                {
                    inputArray[height, width] = i;
                    width++;
                }
                height++;
            }

            return inputArray;
        }

        static private int Day3Prob1()//char[,] data)
        {
            //Day 3 answer 1 = 209
            int finalSum = 0;
            string line;
            StreamReader file = new StreamReader("C:\\Users\\Margaret Landefeld\\MyProjects\\AdventOfCode\\Days\\Three\\Data.txt");
            int charIndex = 0;
            int startRead = 0;

            while ((line = file.ReadLine()) != null)
            {
                if(startRead > 0)
                {
                    while (line.Length <= charIndex + 3)
                    {
                        line += line;
                        line.Replace("\n", "").Replace("\r", "").Remove(' ');
                    }
                    if (line[charIndex + 3] == '#')
                    {
                        finalSum++;
                    }
                    charIndex += 3;
                }
                startRead++;
                //Console.WriteLine(line);

                //int width = 0;
                //foreach (char i in line)
                //{
                //    inputArray[height, width] = i;
                //    width++;
                //}
                //height++;
            }

            return finalSum;
        }

        static private int Day3Prob2()//char[,] data)
        {
            //Day 3 answer 2 = 
            int finalSum = 1;
            string line;
            StreamReader file = new StreamReader("C:\\Users\\Margaret Landefeld\\MyProjects\\AdventOfCode\\Days\\Three\\Three.txt");

            //int charIndex = 0;
            int rowCount = 0;

            List<Slope> slopes = new List<Slope>();
            slopes.Add(new Slope() { SlopeIndex = 0, Right = 1, Down = 1, Sum = 0 });//58
            slopes.Add(new Slope() { SlopeIndex = 0, Right = 3, Down = 1, Sum = 0 });//209
            slopes.Add(new Slope() { SlopeIndex = 0, Right = 5, Down = 1, Sum = 0 });//58
            slopes.Add(new Slope() { SlopeIndex = 0, Right = 7, Down = 1, Sum = 0 });//64
            slopes.Add(new Slope() { SlopeIndex = 0, Right = 1, Down = 2, Sum = 0 });//27

            while ((line = file.ReadLine()) != null)// && rowCount < 15)
            {
                //always skip the first line
                if (rowCount == 0)
                {
                    rowCount++;
                    continue;
                }

                foreach (Slope slope in slopes)
                {
                    //Expands the width of the line if the index is out of bounds.
                    while (line.Length <= slope.SlopeIndex + slope.Right)
                    {
                        line += line;
                        line.Replace("\n", "").Replace("\r", "").Remove(' ');
                    }

                    if (rowCount % slope.Down == 0)
                    {
                        if (line[slope.SlopeIndex + slope.Right] == '#')
                        {
                            slope.Sum++;
                        }
                        slope.SlopeIndex += slope.Right;
                    }

                    //if (rowCount > 0)
                    //{
                    //    //Console.WriteLine(line);

                    //    //else
                    //    //{
                    //        if (line[slope.SlopeIndex + slope.Right] == '#')
                    //        {
                    //            slope.Sum++;
                    //        }
                    //    //}
                    //    slope.SlopeIndex += slope.Right;
                    //}

                }
                rowCount++;
            }

            foreach(var slope in slopes)
            {
                //232589280
                //1214915328
                //1574890240
                Console.WriteLine(slope.Sum);
                finalSum = finalSum * slope.Sum;
            }

            return finalSum;
        }
    }

    public class Slope
    {
        public int SlopeIndex { get; set; }
        public int Right { get; set; }
        public int Down { get; set; }
        public int Sum { get; set; }
    }
}
