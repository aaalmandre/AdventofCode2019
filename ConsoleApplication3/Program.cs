using System;
using System.Linq;
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
            List<Point> intersections = new List<Point>();
            Point intersectionPoint;

            int manhattanDistance = int.MaxValue;
            int wire1Steps = 0;
            int wire2Steps = 0;
            int fewestSteps = int.MaxValue;

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

            for(int i = 1; i < wire1.Count(); i++)
            {
                wire2Steps = 0;
                for(int j = 1; j < wire2.Count(); j++)
                {
                    intersectionPoint = segmentIntersection.GetIntersection(wire1[i - 1], wire1[i], wire2[j - 1], wire2[j]);
                    if (intersectionPoint.x != 0 && intersectionPoint.y != 0)
                    {
                        intersections.Add(intersectionPoint);
                        if (wire1Steps + (Math.Abs(intersectionPoint.x - wire1[i - 1].x) + Math.Abs(intersectionPoint.y - wire1[i - 1].y)) +
                            wire2Steps + (Math.Abs(intersectionPoint.x - wire2[j - 1].x) + Math.Abs(intersectionPoint.y - wire2[j - 1].y)) < fewestSteps)
                        {
                            fewestSteps = wire1Steps + (Math.Abs(intersectionPoint.x - wire1[i - 1].x) + Math.Abs(intersectionPoint.y - wire1[i - 1].y)) +
                                          wire2Steps + (Math.Abs(intersectionPoint.x - wire2[j - 1].x) + Math.Abs(intersectionPoint.y - wire2[j - 1].y));
                        }
                    }
                    wire2Steps += Math.Abs(wire2[j].x - wire2[j - 1].x) + Math.Abs(wire2[j].y - wire2[j - 1].y);
                }
                wire1Steps += Math.Abs(wire1[i].x - wire1[i - 1].x) + Math.Abs(wire1[i].y - wire1[i - 1].y);
            }

            foreach (Point point in intersections)
            {
                System.Console.WriteLine($"{point.x}, {point.y}");
            }

            foreach (Point point in intersections)
            {
                int distance = Math.Abs(point.x) + Math.Abs(point.y);
                if (distance < manhattanDistance)
                {
                    manhattanDistance = distance;
                }
            }

            System.Console.WriteLine(manhattanDistance);
            System.Console.WriteLine(fewestSteps);

            file.Close();
            //System.Console.WriteLine("Fuel required to launch: {0}", sum);
            // Suspend the screen.  
            System.Console.ReadLine();
        }
    }
}
