using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Seven
    {
        public void Run()
        {
            List<Node> data = Parse();
            //List<Group> data = Parse();
            //Console.WriteLine("Day 7 Problem 1 Answer: " + Day7Prob1(data));
            //Console.WriteLine("Day 7 Problem 2 Answer: " + Day7Prob2(data));
        }


        public List<Node> Parse()
        {
            string line;
            List<DeclarationResponses> responses = new List<DeclarationResponses>();
            StreamReader file = new StreamReader("C:\\Users\\Margaret Landefeld\\MyProjects\\AdventOfCode\\Days\\6\\Data.txt");
            List<Node> Nodes = new List<Node>();


            while ((line = file.ReadLine()) != null)
            {
                string color = line.Split(' ')[2];
                Node node = new Node(color);
                node.Color = line.Split(' ')[2];
                var children = new Dictionary<string, int>();
                //form children
                //check if already exists in parent
                foreach(var child in children)
                {
                    node.Children.Add(new Node(child.Key, child.Value));
                }
            }

            return Nodes;
        }

        public string Day7Prob1(string data)
        {

            return data;
        }

        public string Day7Prob2(string data)
        {
            return data;
        }
    }

    //Two types of graph traversal. DFS - depth first search and BFS - breath first search.

    public class Node
    {
        public Node(string color, int number)
        {
            Color = color;
            Number = number;
        }

        public Node(string color)
        {
            Color = color;
        }

        public List<Node> Parent { get; set; }
        public List<Node> Children { get; set; }
        public string Color { get; set; }
        public int? Number { get; set; }
        public bool IsParent { get; set; }
    }

    //public class Bag
    //{
    //    public List<Bag> ChildBags {get;set;}
    //    public string Color { get; set; }
    //    public int Number { get; set; }

    //}
}
