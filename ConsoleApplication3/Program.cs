using System;
using System.Collections.Generic;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the file and store it as a list of integers.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"./../../../input.txt");

            string line1;
            string line2;
            int lastPointPosInWire = 0;

            List<Point> wire1 = new List<Point>();
            List<Point> wire2 = new List<Point>();

            wire1.Add(new Point());
            wire2.Add(new Point());

            line1 = file.ReadLine();
            //System.Console.WriteLine(line1);
            string[] values = line1.Split(',');

            foreach (string element in values)
            {
                switch (element[0])
                {
                    case 'R':
                        wire1.Add(new Point(wire1[lastPointPosInWire].x + int.Parse(element.Substring(1)), wire1[lastPointPosInWire].y));
                        break;
                    case 'L':
                        wire1.Add(new Point(wire1[lastPointPosInWire].x - int.Parse(element.Substring(1)), wire1[lastPointPosInWire].y));
                        break;
                    case 'U':
                        wire1.Add(new Point(wire1[lastPointPosInWire].x, wire1[lastPointPosInWire].y + int.Parse(element.Substring(1))));
                        break;
                    case 'D':
                        wire1.Add(new Point(wire1[lastPointPosInWire].x, wire1[lastPointPosInWire].y - int.Parse(element.Substring(1))));
                        break;
                    default:
                        break;
                }
                lastPointPosInWire++;
                //write the input to console
                //System.Console.WriteLine($"{element}, ");
            }

            /*foreach (Point point in wire1)
            {
                System.Console.WriteLine($"{point.x}, {point.y}");
            }*/

            line2 = file.ReadLine();
            values = line2.Split(',');

            lastPointPosInWire = 0;

            foreach (string element in values)
            {
                switch (element[0])
                {
                    case 'R':
                        wire2.Add(new Point(wire2[lastPointPosInWire].x + int.Parse(element.Substring(1)), wire2[lastPointPosInWire].y));
                        break;
                    case 'L':
                        wire2.Add(new Point(wire2[lastPointPosInWire].x - int.Parse(element.Substring(1)), wire2[lastPointPosInWire].y));
                        break;
                    case 'U':
                        wire2.Add(new Point(wire2[lastPointPosInWire].x, wire2[lastPointPosInWire].y + int.Parse(element.Substring(1))));
                        break;
                    case 'D':
                        wire2.Add(new Point(wire2[lastPointPosInWire].x, wire2[lastPointPosInWire].y - int.Parse(element.Substring(1))));
                        break;
                    default:
                        break;
                }
                lastPointPosInWire++;
                //write the input to console
                //System.Console.WriteLine($"{element}, ");
            }

            /*foreach (Point point in wire2)
            {
                System.Console.WriteLine($"{point.x}, {point.y}");
            }*/




            file.Close();
            //System.Console.WriteLine("Fuel required to launch: {0}", sum);
            // Suspend the screen.  
            System.Console.ReadLine();
        }
    }
}
