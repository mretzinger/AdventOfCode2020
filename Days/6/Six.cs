using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Six
    {
        public void Run()
        {
            List<DeclarationResponses> data = Parse();
            Console.WriteLine("Day 6 Problem 1 Answer: " + Day6Prob1(data));
            //Console.WriteLine("Day 6 Problem 2 Answer: " + Day6Prob2(data));
        }


        public List<DeclarationResponses> Parse()
        {
            string line;
            List<DeclarationResponses> responses = new List<DeclarationResponses>();
            StreamReader file = new StreamReader("C:\\Users\\Margaret Landefeld\\MyProjects\\AdventOfCode\\Days\\6\\Data.txt");
            List<char> answers = new List<char>();
            List<Group> Groups = new List<Group>();
            Group group = new Group(responses);

            while ((line = file.ReadLine()) != null)
            {
                line = line.Trim();
                if (line == "")
                {

                    responses.Add(new DeclarationResponses(answers));
                    answers = new List<char>();
                    //group = new Group(responses);
                    //Groups.Add(group);

                    //Groups = new List<Group>();
                    continue;
                }

                foreach(char letter in line)
                {
                    //Problem 1
                    if (!answers.Contains(letter))
                    {
                        answers.Add(letter);
                    }

                    //Problem 2
                    //answers.Add(letter);
                }
            }

            responses.Add(new DeclarationResponses(answers));
            return responses;
        }

        private int Day6Prob1(List<DeclarationResponses> data)
        {
            //Day 6 answer 1 = 6291
            int finalSum = 0;

            foreach(var item in data)
            {
                finalSum += item.Answer.Count();
            }

            return finalSum;
        }

        private int Day6Prob2(List<DeclarationResponses> data)
        {
            //Day 6 Answer 2 = 

            int finalSum = 0;

            foreach (var item in data)
            {
                int countAll = 0;

                foreach(var row in item.Answer)
                {

                }
            }

            return finalSum;
        }
    }

    public class DeclarationResponses
    {
        public DeclarationResponses(List<char> data)
        {
            Answer = data;
        }

        public List<char> Answer { get; set; }
    }

    public class Group
    {
        public Group(List<DeclarationResponses> data)
        {
            Responses = data;
        }

        public List<DeclarationResponses> Responses { get; set; }
    }
}
