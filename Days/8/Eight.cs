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
            Instruction[] data = Parse();
            Console.WriteLine("Day 8 Problem 1 Answer: " + Day8Prob1(data));
            //Console.WriteLine("Day 8 Problem 2 Answer: " + Day8Prob2(data));
        }

        public Instruction[] Parse()
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

            Instruction[] instructionArray = Instructions.ToArray();

            return instructionArray;
        }

        public int Day8Prob1(Instruction[] data)
        {
            int acc = 0;
            int row = 0;

            while (true)
            {
                if(data[row].Used == true)
                {
                    break;
                }
                data[row].Used = true;
                if (data[row].Line.Split(' ')[0] == "nop")
                {
                    row++;
                }
                else if (data[row].Line.Split(' ')[0] == "jmp")
                {
                    if (data[row].Line.Split(' ')[1].Contains("+"))
                    {
                        row += int.Parse(data[row].Line.Split('+')[1]);
                    }
                    else if (data[row].Line.Split(' ')[1].Contains("-"))
                    {
                        row += int.Parse(data[row].Line.Split(' ')[1]);
                    }
                }
                else if (data[row].Line.Split(' ')[0] == "acc")
                {
                    acc += data[row].Line.Split(' ')[1].Contains("+") ? 
                        int.Parse(data[row].Line.Split('+')[1]) : 
                        int.Parse(data[row].Line.Split(' ')[1]);
                    row++;
                }
            }

            return acc;
        }

        public string Day8Prob2(Instruction[] data)
        {
            return "test";
        }
    }

    public class Instruction {
        public string Line { get; set; }
        public int RowId { get; set; }
        public bool Used { get; set; }
    }
}
