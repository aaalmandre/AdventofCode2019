using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int opCode = 0;
            string opCodeString;
            int parameter1mode;
            int parameter2mode;
            int parameter3mode;
            int value1 = 0;
            int value2 = 0;
            int opCodePosition = 0;
            System.Collections.Generic.List<int> program = new System.Collections.Generic.List<int>();
            System.Collections.Generic.List<int> programOriginal = new System.Collections.Generic.List<int>();

            int numberOfElements = 0;
            string line;
            int input;
            // Read the file and store it as a list of integers.  
            System.IO.StreamReader file = new System.IO.StreamReader("input.txt");
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

            program.Clear();
            program.AddRange(programOriginal);
            opCodePosition = 0;
            numberOfElements = program.Count;

            do
            {
                opCode = program[opCodePosition];
                opCodeString = Convert.ToString(opCode);
                if(opCodeString.Length == 1)
                {
                    parameter3mode = 0;
                    parameter2mode = 0;
                    parameter1mode = 0;
                    //only opcode
                }
                else if(opCodeString.Length == 2)
                {
                    parameter3mode = 0;
                    parameter2mode = 0;
                    parameter1mode = 0;
                    //only opcode
                }
                else if(opCodeString.Length == 3)
                {
                    parameter3mode = 0;
                    parameter2mode = 0;
                    parameter1mode = 1;
                    opCodeString = $"{opCodeString[1]}{opCodeString[2]}";
                    opCode = Convert.ToInt32(Convert.ToString(opCodeString));
                }
                else if(opCodeString.Length == 4)
                {
                    parameter3mode = 0;
                    parameter2mode = Convert.ToInt32(Convert.ToString(opCodeString[0]));
                    parameter1mode = Convert.ToInt32(Convert.ToString(opCodeString[1]));
                    opCodeString = $"{opCodeString[2]}{opCodeString[3]}";
                    opCode = Convert.ToInt32(Convert.ToString(opCodeString));
                }
                else
                {
                    parameter3mode = 1;
                    parameter2mode = Convert.ToInt32(Convert.ToString(opCodeString[1]));
                    parameter1mode = Convert.ToInt32(Convert.ToString(opCodeString[2]));
                    opCodeString = $"{opCodeString[3]}{opCodeString[4]}";
                    opCode = Convert.ToInt32(Convert.ToString(opCodeString));
                }

                if(opCode == 1 || opCode == 2 || opCode == 5 || opCode == 6 || opCode == 7 || opCode == 8)
                {
                    if(parameter1mode == 1 )//immeadiate mode
                    {
                        value1 = program[opCodePosition + 1];
                    }
                    else //position mode
                    {
                        value1 = program[program[opCodePosition + 1]];
                    }
                    if(parameter2mode == 1 )//immeadiate mode
                    {
                        value2 = program[opCodePosition + 2];
                    }
                    else //position mode
                    {
                        value2 = program[program[opCodePosition + 2]];
                    }
                }

                
                switch (opCode)
                {
                    case 99:
                        //System.Console.WriteLine("Opcode 99, program halts.");
                        opCodePosition = numberOfElements;
                        break;
                    case 1:
                        //System.Console.WriteLine($"Opcode 1, addition of position {program[opCodePosition + 1]} with position {program[opCodePosition + 2]} writing the result to position {program[opCodePosition + 3]}.");
                        program[program[opCodePosition + 3]] = value1 + value2;
                        opCodePosition = opCodePosition + 4;
                        //System.Console.WriteLine($" {program[program[opCodePosition + 1]]} + {program[program[opCodePosition + 2]]}");
                        break;
                    case 2:
                        //System.Console.WriteLine($"Opcode 2, multiplication of position {program[opCodePosition + 1]} with position {program[opCodePosition + 2]} writing the result to position {program[opCodePosition + 3]}.");
                        program[program[opCodePosition + 3]] = value1 * value2;
                        opCodePosition = opCodePosition + 4;
                        //System.Console.WriteLine($" {program[program[opCodePosition + 1]]} * {program[program[opCodePosition + 2]]}");
                        break;
                    case 3:
                        //Opcode 3 takes a single integer as input and saves it to the position given by its only parameter. For example, the instruction 3,50 would take an input value and store it at address 50.
                        input = Convert.ToInt32(Console.ReadLine());
                        program[program[opCodePosition + 1]] = input;
                        opCodePosition = opCodePosition + 2;
                        break;
                    case 4:
                        if(parameter1mode == 1 )//immeadiate mode
                        {
                            value1 = program[opCodePosition + 1];
                        }
                        else //position mode
                        {
                            value1 = program[program[opCodePosition + 1]];
                        }
                        //Opcode 4 outputs the value of its only parameter. For example, the instruction 4,50 would output the value at address 50.
                        Console.WriteLine($"{value1}");
                        opCodePosition = opCodePosition + 2;
                        break;
                    case 5:
                        if(value1 != 0)
                        {
                            opCodePosition = value2;
                        }
                        else
                        {
                            opCodePosition = opCodePosition + 3;
                        }
                        break;
                    case 6:
                        if(value1 == 0)
                        {
                            opCodePosition = value2;                            
                        }
                        else
                        {
                            opCodePosition = opCodePosition + 3;
                        }
                        break;
                    case 7:
                        if(value1 < value2)
                        {
                            program[program[opCodePosition + 3]] = 1;
                        }
                        else
                        {
                            program[program[opCodePosition + 3]] = 0;
                        }
                        opCodePosition = opCodePosition + 4;
                        break;
                    case 8:
                        if(value1 == value2)
                        {
                            program[program[opCodePosition + 3]] = 1;
                        }
                        else
                        {
                            program[program[opCodePosition + 3]] = 0;
                        }
                        opCodePosition = opCodePosition + 4;
                        break;
                    default:
                        //System.Console.WriteLine("Unknown Opcode, program halts.");
                        opCodePosition = numberOfElements;
                        break;
                }
            } while (opCodePosition < numberOfElements);


            

            file.Close();
            //System.Console.WriteLine("Fuel required to launch: {0}", sum);
            // Suspend the screen.  
            System.Console.ReadLine();
        }
    }
}
