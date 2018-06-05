using System;
using System.Linq;

namespace CrossingFigures
{
    class CrossingFigures
    {
        static void Main()
        {
            int tests = int.Parse(Console.ReadLine());
            for (int i = 0; i < tests; i++)
            {
                string input1 = Console.ReadLine();
                string input2 = Console.ReadLine();
                Circle circle = new Circle();
                Rectangle rectangle = new Rectangle();
                if (input1.StartsWith("circle")) circle = CircleParse(input1);
                else rectangle = RectangleParse(input1);
                if (input2.StartsWith("circle")) circle = CircleParse(input2);
                else rectangle = RectangleParse(input2);
                if (circle.Center.X >= rectangle.PointA.X + circle.Radius - 0.01
                    && circle.Center.X <= rectangle.PointB.X - circle.Radius + 0.01
                    && circle.Center.Y >= rectangle.PointB.Y + circle.Radius - 0.01
                    && circle.Center.Y <= rectangle.PointA.Y - circle.Radius + 0.01)
                {
                    Console.WriteLine("Circle inside rectangle");
                }
                else if (Distance(circle.Center.X, circle.Center.Y, rectangle.PointA.X, rectangle.PointA.Y) < circle.Radius
                    && Distance(circle.Center.X, circle.Center.Y, rectangle.PointA.X, rectangle.PointB.Y) < circle.Radius
                    && Distance(circle.Center.X, circle.Center.Y, rectangle.PointB.X, rectangle.PointA.Y) < circle.Radius
                    && Distance(circle.Center.X, circle.Center.Y, rectangle.PointB.X, rectangle.PointB.Y) < circle.Radius)
                {
                    Console.WriteLine("Rectangle inside circle");
                }
                else if (circle.Center.X < rectangle.PointA.X - circle.Radius
                        || circle.Center.X > rectangle.PointB.X + circle.Radius
                        || circle.Center.Y > rectangle.PointA.Y + circle.Radius
                        || circle.Center.Y < rectangle.PointB.Y - circle.Radius)
                {
                    Console.WriteLine("Rectangle and circle do not cross");
                }
                else if ((circle.Center.X <= rectangle.PointA.X && circle.Center.X >= rectangle.PointA.X - circle.Radius && circle.Center.Y >= rectangle.PointA.Y && circle.Center.Y <= rectangle.PointA.Y + circle.Radius && Distance(circle.Center.X, circle.Center.Y, rectangle.PointA.X, rectangle.PointA.Y) > circle.Radius)                    
                        || (circle.Center.X <= rectangle.PointA.X && circle.Center.X >= rectangle.PointA.X - circle.Radius && circle.Center.Y <= rectangle.PointB.Y && circle.Center.Y <= rectangle.PointB.Y - circle.Radius && Distance(circle.Center.X, circle.Center.Y, rectangle.PointA.X, rectangle.PointB.Y) > circle.Radius)
                        || (circle.Center.X >= rectangle.PointB.X && circle.Center.X <= rectangle.PointB.X + circle.Radius && circle.Center.Y >= rectangle.PointA.Y && circle.Center.Y <= rectangle.PointA.Y + circle.Radius && Distance(circle.Center.X, circle.Center.Y, rectangle.PointB.X, rectangle.PointA.Y) > circle.Radius)
                        || (circle.Center.X >= rectangle.PointB.X && circle.Center.X <= rectangle.PointB.X + circle.Radius && circle.Center.Y <= rectangle.PointB.Y && circle.Center.Y >= rectangle.PointB.Y - circle.Radius && Distance(circle.Center.X, circle.Center.Y, rectangle.PointB.X, rectangle.PointB.Y) > circle.Radius))
                {
                    Console.WriteLine("Rectangle and circle do not cross");
                }
                else
                {
                    Console.WriteLine("Rectangle and circle cross");
                }
            }

        }

        static Circle CircleParse(string input)
        {
            Circle circle = new Circle();
            Point center = new Point();
            input = input.Replace("circle(", "");
            input = input.Replace(")", "");
            double[] token = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
            center.X = token[0];
            center.Y = token[1];
            circle.Center = center;
            circle.Radius = token[2];
            return circle;
        }

        static Rectangle RectangleParse(string input)
        {
            Rectangle rectangle = new Rectangle();
            Point pointA = new Point();
            Point pointB = new Point();
            input = input.Replace("rectangle(", "");
            input = input.Replace(")", "");
            double[] token = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
            pointA.X = token[0];
            pointA.Y = token[1];
            pointB.X = token[2];
            pointB.Y = token[3];
            rectangle.PointA = pointA;
            rectangle.PointB = pointB;
            return rectangle;
        }

        static double Distance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            return distance;
        }

    }

    class Rectangle
    {
        public Point PointA { get; set; }
        public Point PointB { get; set; }
    }

    class Circle
    {
        public Point Center { get; set; }
        public double Radius { get; set; }
    }

    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}