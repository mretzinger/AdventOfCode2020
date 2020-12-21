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
            //Console.WriteLine("Day 8 Problem 1 Answer: " + Day8Prob1(data));
            Console.WriteLine("Day 8 Problem 2 Answer: " + Day8Prob2(data));
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
                if(line.Contains("acc"))
                {
                    newLine.Type = "acc";
                }
                else if(line.Contains("nop"))
                {
                    newLine.Type = "nop";
                }
                else if (line.Contains("jmp"))
                {
                    newLine.Type = "jmp";
                }

                if (line.Split(' ')[1].Contains("+"))
                {
                    newLine.Number = int.Parse(line.Split('+')[1]);
                }
                else if (line.Split(' ')[1].Contains("-"))
                {
                    newLine.Number = int.Parse(line.Split(' ')[1]);
                }

                Instructions.Add(newLine);
                rowCount++;
            }

            Instruction[] instructionArray = Instructions.ToArray();

            return instructionArray;
        }

        public int RunGameBoy(Instruction[] data)
        {
            int acc = 0;
            int row = 0;

            while (true)
            {
                if (row == data.Length)
                {
                    break;
                }
                if (data[row].Used == true)
                {
                    throw new GameBoyException(acc);
                }
                data[row].Used = true;
                if (data[row].Type == "nop")
                {
                    row++;
                }
                else if (data[row].Type == "jmp")
                {
                    row += data[row].Number;
                }
                else if (data[row].Type == "acc")
                {
                    acc += data[row].Number;
                    row++;
                }
            }

            return acc;
        }



        public int Day8Prob1(Instruction[] data)
        {
            try {
                return RunGameBoy(data);
            } catch(GameBoyException e)
            {
                return e.accValue;
            }
        }

        public int Day8Prob2(Instruction[] data)
        {
            int rowId = 0; 

            foreach (Instruction instruction in data)
            {
                Instruction[] cloned = data.Select(x => x.DeepCopy()).ToArray();    

                if (instruction.Type == "nop")
                {
                    cloned[rowId].Type = "jmp";
                } else if(instruction.Type == "jmp")
                {
                    cloned[rowId].Type = "nop";
                }

                try
                {
                    return RunGameBoy(cloned);
                } catch (GameBoyException e)
                {
                    rowId++;
                    continue;
                }
            }
            return 0;
        }
    }

    public class Instruction {
        public string Line { get; set; }
        public int RowId { get; set; }
        public string Type { get; set; }
        public bool Used { get; set; }

        public int Number { get; set; }

        public Instruction DeepCopy()
        {
            return new Instruction { Line = Line, RowId = RowId, Type = Type, Used = Used, Number = Number };
        }
    }

    public class GameBoyException : Exception { 

        public GameBoyException(int value)
        {
            accValue = value;
        }

        public int accValue { get; set; }
    }

}
