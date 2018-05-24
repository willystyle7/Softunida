using System;

namespace SumTime
{
    class Program
    {
        static void Main()
        {
            string time1 = Console.ReadLine();
            string time2 = Console.ReadLine();
            int day1 = 0, day2 = 0, hour1 = 0, hour2 = 0, minute1 = 0, minute2 = 0;
            ParseTime(time1, ref day1, ref hour1, ref minute1);
            ParseTime(time2, ref day2, ref hour2, ref minute2);
            int minute = (minute1 + minute2) % 60;
            int hour = (hour1 + hour2 + (minute1 + minute2) / 60) % 24;
            int day = day1 + day2 + (hour1 + hour2 + (minute1 + minute2) / 60) / 24;
            Console.WriteLine("{0}{1}:{2:D2}", (day == 0 ? "" : day + "::"), hour, minute);
        }

        static void ParseTime(string time, ref int day, ref int hour, ref int minute)
        {
            string[] token = time.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (time.Contains("::"))
            {
                day = int.Parse(token[0]);
                hour = int.Parse(token[1]);
                minute = int.Parse(token[2]);
            }
            else
            {
                day = 0;
                hour = int.Parse(token[0]);
                minute = int.Parse(token[1]);
            }
            return;
        }
    }
}