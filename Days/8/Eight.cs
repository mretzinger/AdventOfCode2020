using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Eight
    {
        public void Run()
        {
            List<Instruction> data = Parse();
            //Console.WriteLine(data);
            Console.WriteLine("Day 8 Problem 1 Answer: " + Day8Prob1(data));
            //Console.WriteLine("Day 8 Problem 2 Answer: " + Day8Prob2(data));
        }

        public List<Instruction> Parse()
        {
            string line;
            StreamReader file = new StreamReader("C:\\Users\\Margaret Landefeld\\MyProjects\\AdventOfCode\\Days\\8\\Data.txt");
            List<Instruction> Instructions = new List<Instruction>();
            int rowCount = 1;

            while ((line = file.ReadLine()) != null)
            {
                Instruction newLine = new Instruction();
                newLine.Line = line;
                newLine.RowId = rowCount;
                Instructions.Add(newLine);
                rowCount++;
            }

            return Instructions;
        }

        public int Day8Prob1(List<Instruction> data)
        {
            int acc = 0;
            int currentRow = 1;
            int nextRowCount = 0;
            List<int> usedInstructions = new List<int>();

            while(!usedInstructions.Contains(currentRow))
            {
                foreach (var item in data)
                {
                    if (item.Line.Split(' ')[0] == "nop")
                    {
                        nextRowCount++;
                        continue;
                    }
                    else if (item.Line.Split(' ')[0] == "jmp")
                    {
                        if (item.Line.Split(' ')[1].Contains("+"))
                        {
                            nextRowCount += int.Parse(item.Line.Split('+')[1]);
                        }
                        else if (item.Line.Split(' ')[1].Contains("-"))
                        {
                            nextRowCount += int.Parse(item.Line.Split(' ')[1]);
                        }

                        break;
                    }
                    else if (item.Line.Split(' ')[0] == "acc")
                    {
                        nextRowCount++;
                        acc += item.Line.Split(' ')[1].Contains("+") ? int.Parse(item.Line.Split('+')[1]) : int.Parse(item.Line.Split(' ')[1]);
                    }

                    usedInstructions.Add(item.RowId);
                    currentRow = item.RowId;
                    if(item == data.Last())
                    {
                        break;
                    }
                }
            }

            return acc;
        }

        public string Day8Prob2(string data)
        {
            return "test";
        }
    }

    public class Instruction {
        public string Line { get; set; }
        public int RowId { get; set; }
    }
}
