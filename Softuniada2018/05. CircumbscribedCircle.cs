using System;

namespace CircumbscribedCircle
{
    class CircumbscribedCircle
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputCircle = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] inputTriangle = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                Point point = new Point();
                Circle circle = new Circle();
                point.X = double.Parse(inputCircle[1]);
                point.Y = double.Parse(inputCircle[2]);
                circle.Radius = double.Parse(inputCircle[3]);
                circle.Center = point;
                Point pointA = new Point();
                Point pointB = new Point();
                Point pointC = new Point();
                Triangle triangle = new Triangle();
                pointA.X = double.Parse(inputTriangle[1]);
                pointA.Y = double.Parse(inputTriangle[2]);
                pointB.X = double.Parse(inputTriangle[3]);
                pointB.Y = double.Parse(inputTriangle[4]);
                pointC.X = double.Parse(inputTriangle[5]);
                pointC.Y = double.Parse(inputTriangle[6]);
                triangle.PointA = pointA;
                triangle.PointB = pointB;
                triangle.PointC = pointC;
                Console.WriteLine("The circle is {0}circumscribed and the center is {1}.", IsCircumbscribed(circle, triangle) ? "" : "not ", IsInside(point, triangle) ? "inside" : "outside");
            }
        }

        static bool IsCircumbscribed(Circle circle, Triangle triangle)
        {
            bool isCircumbscribed = false;
            if (Math.Abs(Distance(circle.Center, triangle.PointA) - circle.Radius) < 0.01
                && Math.Abs(Distance(circle.Center, triangle.PointB) - circle.Radius) < 0.01
                && Math.Abs(Distance(circle.Center, triangle.PointC) - circle.Radius) < 0.01)
            {
                isCircumbscribed = true;
            }
            return isCircumbscribed;
        }

        static bool IsInside(Point point, Triangle triangle)
        {            
            bool isInside = false;
            bool b1, b2, b3;
            b1 = sign(point, triangle.PointA, triangle.PointB) < 0.0f;
            b2 = sign(point, triangle.PointB, triangle.PointC) < 0.0f;
            b3 = sign(point, triangle.PointC, triangle.PointA) < 0.0f;
            isInside = ((b1 == b2) && (b2 == b3));
            return isInside;
        }

        static double sign(Point point, Point point1, Point point2)
        {
            return (point.X - point2.X) * (point1.Y - point2.Y) - (point1.X - point2.X) * (point.Y - point2.Y);
        }

        static double Distance(Point point1, Point point2)
        {
            double distance = 0;
            distance = Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y));
            return distance;
        }

    }

    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

    }

    class Circle
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

    }

    class Triangle
    {
        public Point PointA { get; set; }
        public Point PointB { get; set; }
        public Point PointC { get; set; }
    }

}
