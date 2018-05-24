using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingZones2
{
    class ParkingZones
    {
        static void Main()
        {
            int numberZones = int.Parse(Console.ReadLine());
            List<Zone> ParkingZones = new List<Zone>();
            List<ParkingPlace> ParkingPlaces = new List<ParkingPlace>();
            for (int i = 0; i < numberZones; i++)
            {
                string[] token = Console.ReadLine().Split(new[] { ':', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Zone zone = new Zone();
                zone.Name = token[0];
                zone.X = int.Parse(token[1]);
                zone.Y = int.Parse(token[2]);
                zone.Width = int.Parse(token[3]);
                zone.Heigth = int.Parse(token[4]);
                zone.Price = double.Parse(token[5]);
                ParkingZones.Add(zone);
            }
            string[] input = Console.ReadLine().Split(';');
            for (int i = 0; i < input.Length; i++)
            {
                int[] token = input[i].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                ParkingPlace parkingPlace = new ParkingPlace();
                int x = token[0];
                int y = token[1];
                foreach (Zone zone in ParkingZones)
                {
                    if ((x >= zone.X) && (x <= zone.X + zone.Width) && (y >= zone.Y) && (y <= zone.Y + zone.Heigth))
                    {
                        parkingPlace.ZoneName = zone.Name;
                        parkingPlace.X = x;
                        parkingPlace.Y = y;
                        parkingPlace.Price = zone.Price;
                        ParkingPlaces.Add(parkingPlace);
                    }
                }
            }
            int[] token2 = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int storeX = token2[0];
            int storeY = token2[1];
            int time = int.Parse(Console.ReadLine());

            List<Path> Paths = new List<Path>();
            foreach (ParkingPlace parkingPlace in ParkingPlaces)
            {                
                Path path = new Path();
                path.ZoneName = parkingPlace.ZoneName;
                path.X = parkingPlace.X;
                path.Y = parkingPlace.Y;
                path.Length = (int)Math.Abs(parkingPlace.X - storeX) + (int)Math.Abs(parkingPlace.Y - storeY) - 1;
                path.Price = Math.Ceiling((path.Length * 2 * time) / 60.0) * parkingPlace.Price;
                Paths.Add(path);
            }            
            Path BestPath = Paths.OrderBy(p => p.Price).ThenBy(l => l.Length).First();
            Console.WriteLine("Zone Type: {0}; X: {1}; Y: {2}; Price: {3:F2}", BestPath.ZoneName, BestPath.X, BestPath.Y, BestPath.Price);
        }
    }

    class Zone
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }
        public double Price { get; set; }
    }

    class ParkingPlace
    {
        public string ZoneName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Price { get; set; }
    }

    class Path
    {
        public string ZoneName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public double Price { get; set; }       

    }
}