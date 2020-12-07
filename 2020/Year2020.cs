using System;

namespace AdventOfCode._2020
{
    public static class Year2020
    {
        public static void StartDay(int day)
        {
            switch (day)
            {
                case 1:
                    Day1.Start();
                    break;

                case 2:
                    Day2.Start();
                    break;

                case 3:
                    Day3.Start();
                    break;

                case 4:
                    Day4.Start();
                    break;

                case 5:
                    Day5.Start();
                    break;

                case 6:
                    Day6.Start();
                    break;

                case 7:
                    Day7.Start();
                    break;

                case 8:
                    Day8.Start();
                    break;

                default:
                    Console.WriteLine("That day is not supported yet");
                    break;
            }
        }
    }
}
