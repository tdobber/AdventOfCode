using AdventOfCode._2018;
using AdventOfCode._2019;
using AdventOfCode._2020;
using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What would you like to run? (Example: 3-19 for day 3 of 2019, 8 for the current year day 8)");

            string[] input = Console.ReadLine().Split("-");
            int dayToRun = Convert.ToInt16(input[0]);
            int yearToRun = input.Length > 1 ? Convert.ToInt16(input[1]) : 0;

            switch (yearToRun)
            {
                case 18:
                case 2018:
                    Year2018.StartDay(dayToRun);
                    break;

                case 19:
                case 2019:
                    Year2019.StartDay(dayToRun);
                    break;

                default:
                    Year2020.StartDay(dayToRun);
                        break;
            }
        }
    }
}
