using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Two
    {
        public void Run()
        {
            List<PasswordInfo> passwords = Parse();
            Console.WriteLine("Day 2 Problem 1 Answer: " + Day2Prob1(passwords));
            Console.WriteLine("Day 2 Problem 2 Answer: " + Day2Prob2(passwords));
        }

        public List<PasswordInfo> Parse()
        {
            string line;
            List<PasswordInfo> passwordInfos = new List<PasswordInfo>();
            StreamReader file = new StreamReader("C:\\Users\\Margaret Landefeld\\MyProjects\\AdventOfCode\\Days\\Two\\Data.txt");

            while ((line = file.ReadLine()) != null)
            {
                PasswordInfo pwInfo = new PasswordInfo();
                pwInfo.lowLimit = int.Parse(line.Split('-')[0]);
                pwInfo.highLimit = int.Parse(line.Split('-')[1].Split(' ')[0]);
                pwInfo.letter = line.Split(' ')[1].ToCharArray()[0];
                pwInfo.password = line.Split(':')[1].Trim();
                passwordInfos.Add(pwInfo);
            }

            return passwordInfos;
        }

        static private int Day2Prob1(List<PasswordInfo> passwords)
        {
            //Day 2 answer 1 = 434
            int finalSum = 0;
            foreach (var item in passwords)
            {
                int charSum = 0;
                foreach (char c in item.password)
                {
                    if (c == item.letter)
                    {
                        charSum += 1;
                    }
                }

                if (charSum <= item.highLimit && charSum >= item.lowLimit)
                {
                    finalSum += 1;
                }
            }

            return finalSum;
        }

        static private int Day2Prob2(List<PasswordInfo> passwords)
        {
            int finalSum = 0;

            //Day 2 Answer 2 = 509
            foreach (var item in passwords)
            {
                if (item.password[item.lowLimit - 1] == item.letter ^ item.password[item.highLimit - 1] == item.letter)
                {
                    finalSum += 1;
                }
            }

            return finalSum;
        }
    }

    public class PasswordInfo
    {
        public int lowLimit { get; set; }
        public int highLimit { get; set; }
        public char letter { get; set; }
        public string password { get; set; }
    }
}
