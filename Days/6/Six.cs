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
            //List<DeclarationResponses> data = Parse();
            List<Group> data = Parse();
            //Console.WriteLine("Day 6 Problem 1 Answer: " + Day6Prob1(data));
            Console.WriteLine("Day 6 Problem 2 Answer: " + Day6Prob2(data));
        }


        public List<Group> Parse()
        {
            string line;
            List<DeclarationResponses> responses = new List<DeclarationResponses>();
            StreamReader file = new StreamReader("C:\\Users\\Margaret Landefeld\\MyProjects\\AdventOfCode\\Days\\6\\Data.txt");
            List<Group> Groups = new List<Group>();
            Group group = new Group(responses);

            while ((line = file.ReadLine()) != null)
            {
                line = line.Trim();
                if (line == "")
                {
                    group = new Group(responses);
                    Groups.Add(group);
                    //answers = new List<char>();
                    responses = new List<DeclarationResponses>();
                    continue;
                }

                List<char> answers = new List<char>();

                foreach (char letter in line)
                {
                    //Problem 1
                    //if (!answers.Contains(letter))
                    //{
                    //    answers.Add(letter);
                    //}

                    //Problem 2
                    answers.Add(letter);
                }
                responses.Add(new DeclarationResponses(answers));
            }

            Groups.Add(new Group(responses));
            return Groups;
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

        private int Day6Prob2(List<Group> data)
        {
            //Day 6 Answer 2 = 3052

            int finalSum = 0;

            foreach (Group group in data)
            {
                Dictionary<string, int> answers = new Dictionary<string, int>();

                foreach (var row in group.Responses)
                {
                    foreach(char letter in row.Answer)
                    {
                        if(!answers.ContainsKey(letter.ToString()))
                        {
                            answers.Add(letter.ToString(), 1);
                        }
                        else
                        {
                            answers[letter.ToString()] += 1;
                        }
                    }
                }

                foreach(var answer in answers)
                {
                    finalSum = answer.Value == group.Responses.Count() ? finalSum + 1 : finalSum;
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
