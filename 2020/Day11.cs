using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020
{
    public static class Day11
    {
        private static List<string> Input => InputHelper.GetInputListString(2020, 11).ToList();

        public class SeatMap
        {
            public char[,] Seats { get; set; }
        }

        private static SeatMap LoadSeatMap()
        {
            SeatMap map = new SeatMap();
            map.Seats = new char[Input.Count, Input[0].Length];

            for(int i = 0; i < Input.Count; i++)
            {
                for (int j = 0; j < Input[i].Length; j++)
                {
                    map.Seats[i, j] = Input[i][j];
                }
            }

            return map;
        }

        private static void Part1()
        {
            SeatMap map = LoadSeatMap();
            return;
        }

        private static void Part2()
        {

        }

        public static void Start()
        {
            Part1();

            Part2();
        }
    }
}
