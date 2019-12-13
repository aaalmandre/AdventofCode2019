using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int sum = 0;
            int massOfModule = 0;
            int fuelReq = 0; 
            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"d:\Andris\c#\input.txt");
            while ((line = file.ReadLine()) != null)
            {
                counter++;
                massOfModule = Int32.Parse(line);
                System.Console.WriteLine(massOfModule);

                fuelReq = massOfModule / 3 - 2;
                sum = sum + fuelReq;
                do
                {
                    fuelReq = fuelReq / 3 - 2;
                    if (fuelReq < 0)
                    {
                        fuelReq = 0;
                    }
                    sum = sum + fuelReq;
                } while (fuelReq != 0);

            }

            file.Close();
            System.Console.WriteLine("Fuel required to launch: {0}", sum);
            // Suspend the screen.  
            System.Console.ReadLine();

        }
    }
}
