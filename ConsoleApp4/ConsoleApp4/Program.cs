using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPasswords = 0;
            int adjacentDigits = 1;
            bool decreasing = false;
            for (int i = 265275 ; i < 781584; i++)
            {
                string number = i.ToString();
                adjacentDigits = 1;
                decreasing = false;
                for (int j = 0; j < 5; j++)
                {
                    //check if two adjacent digits are the same (like 22 in 122345).
                    if (number[j] == number[j + 1])
                    {
                        adjacentDigits++;
                    }
                    else if(number[j] != number[j + 1] && adjacentDigits == 2)
                    {
                        break;
                    }
                    else
                    {
                        adjacentDigits = 1;
                    }
                }
                for (int j = 0; j < 5; j++)
                {
                    //Going from left to right, the digits never decrease; they only ever increase or stay the same (like 111123 or 135679).
                    if (number[j] > number[j + 1])
                    {
                        decreasing = true;
                        break;
                    }
                }
                if (decreasing == false && adjacentDigits == 2)
                {
                    numberOfPasswords++;
                }

            }

            System.Console.WriteLine(numberOfPasswords);
        }
    }
}
