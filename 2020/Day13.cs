using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020
{
    public static class Day13
    {
        private static List<string> Input => InputHelper.GetInputListString(2020, 13).ToList();

        private static void Part1()
        {

        }

        private static void Part2()
        {
            string[] bus = Input[1].Split(",");
            long time = 0;
            long inc = long.Parse(bus[0]);
            for (var i = 1; i < bus.Length; i++)
            {
                if (!bus[i].Equals("x"))
                {
                    int newTime = int.Parse(bus[i]);
                    while (true)
                    {
                        time += inc;
                        if ((time + i) % newTime == 0)
                        {
                            inc *= newTime;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"The earliest timestamp such that all of the listed bus IDs depart at offsets matching their positions in the list is {time}");
        }

        public static void Start()
        {
            Part1();

            Part2();
        }
    }
}
