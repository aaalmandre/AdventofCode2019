using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int opCode = 0;
            int opCodePosition = 0;
            List<int> program = new List<int>();
            List<int> programOriginal = new List<int>();

            int numberOfElements = 0;
            int sum = 0;
            string line;
            // Read the file and store it as a list of integers.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"d:\Andris\c#\input2.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] values = line.Split(',');

                foreach (string element in values)
                {
                    program.Add(int.Parse(element));
                    //write the input to console
                    //System.Console.WriteLine($"{element}, ");
                }
            }

            programOriginal.AddRange(program);

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    program.Clear();
                    program.AddRange(programOriginal);
                    //before running the program, replace position 1 with the value 12 and replace position 2 with the value 2.
                    program[1] = i;
                    program[2] = j;
                    opCodePosition = 0;
                    numberOfElements = program.Count();

                    do
                    {
                        opCode = program[opCodePosition];
                        switch (opCode)
                        {
                            case 99:
                                //System.Console.WriteLine("Opcode 99, program halts.");
                                opCodePosition = numberOfElements;
                                break;
                            case 1:
                                //System.Console.WriteLine($"Opcode 1, addition of position {program[opCodePosition + 1]} with position {program[opCodePosition + 2]} writing the result to position {program[opCodePosition + 3]}.");
                                program[program[opCodePosition + 3]] = program[program[opCodePosition + 1]] + program[program[opCodePosition + 2]];
                                //System.Console.WriteLine($" {program[program[opCodePosition + 1]]} + {program[program[opCodePosition + 2]]}");
                                break;
                            case 2:
                                //System.Console.WriteLine($"Opcode 2, multiplication of position {program[opCodePosition + 1]} with position {program[opCodePosition + 2]} writing the result to position {program[opCodePosition + 3]}.");
                                program[program[opCodePosition + 3]] = program[program[opCodePosition + 1]] * program[program[opCodePosition + 2]];
                                //System.Console.WriteLine($" {program[program[opCodePosition + 1]]} * {program[program[opCodePosition + 2]]}");
                                break;
                            default:
                                //System.Console.WriteLine("Unknown Opcode, program halts.");
                                opCodePosition = numberOfElements;
                                break;
                        }
                        opCodePosition = opCodePosition + 4;
                    } while (opCodePosition < numberOfElements);

                    if (program[0] == 19690720)
                    {
                        System.Console.WriteLine($"noun: {i}, verb: {j}");
                        return;
                    }
                    System.Console.WriteLine(program[0]);
                }

            }

            

            file.Close();
            //System.Console.WriteLine("Fuel required to launch: {0}", sum);
            // Suspend the screen.  
            System.Console.ReadLine();

        }
    }
}
