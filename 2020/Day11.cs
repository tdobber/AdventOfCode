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
            public char[,] OldSeats { get; set; }
            public int SizeX { get; set; }
            public int SizeY { get; set; }
            public int Rounds { get; set; } = 0;

            public void ProcessRound()
            {
                while (Rounds != 5)
                {
                    CopyArraysAndCheck();
                    for (int i = 0; i < SizeY; i++)
                    {
                        for (int j = 0; j < SizeX; j++)
                        {
                            switch(OldSeats[i, j])
                            {
                                case 'L':
                                    if (CheckEmptySeats(i, j))
                                    {
                                        Seats[i, j] = '#';
                                    }
                                    break;

                                case '#':
                                    if (CheckOccupiedSeats(i, j))
                                    {
                                        Seats[i, j] = 'L';
                                    }
                                    break;

                                case '.':
                                    break;

                                default:
                                    Console.WriteLine("Should not happen, debug...");
                                    break;
                            }
                        }
                    }

                    Rounds++;
                }

                return;
            }

            public bool CopyArraysAndCheck()
            {
                if (OldSeats == null)
                {
                    OldSeats = new char[SizeY, SizeX];
                }

                bool same = true;

                for (int i = 0; i < SizeY; i++)
                {
                    for (int j = 0; j < SizeX; j++)
                    {
                        if (OldSeats[i, j] != Seats[i, j])
                        {
                            OldSeats[i, j] = Seats[i, j];
                            same = false;
                        }
                    }
                }

                return same;
            }

            private bool CheckEmptySeats(int originalI, int originalJ)
            {
                for (int i = originalI - 1; i <= originalI + 1; i++)
                {
                    if (i < 0 || i >= SizeY)
                    {
                        continue;
                    }
                    else
                    {
                        for (int j = originalJ - 1; j <= originalJ + 1; j++)
                        {
                            if (j < 0 || j >= SizeX)
                            {
                                continue;
                            }
                            else if (OldSeats[i, j] == '#')
                            {
                                return false;
                            }
                        }
                    }
                }

                return true;
            }

            private bool CheckOccupiedSeats(int originalI, int originalJ)
            {
                for (int counter = -4; counter <= 4; counter++)
                {
                    if (originalI + counter < 0 || originalJ + counter < 0 || originalI + counter >= SizeY || originalJ + counter >= SizeX || originalI - counter < 0 || originalI - counter >= SizeY)
                    {
                        continue;
                    }
                    // y-axis
                    else if (OldSeats[originalI + counter, originalJ] != '#' ||
                        // x-axis
                        OldSeats[originalI, originalJ + counter] != '#' ||
                        // Top left to bottom right
                        OldSeats[originalI + counter, originalJ + counter] != '#' ||
                        // Bottom left to top right
                        OldSeats[originalI - counter, originalJ + counter] != '#')
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private static SeatMap LoadSeatMap(int sizeY, int sizeX)
        {
            SeatMap map = new SeatMap();
            map.SizeX = sizeX;
            map.SizeY = sizeY;
            map.Seats = new char[sizeY, sizeX];

            for(int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    map.Seats[i, j] = Input[i][j];
                }
            }

            return map;
        }

        private static void Part1()
        {
            SeatMap map = LoadSeatMap(Input.Count, Input[0].Length);

            map.ProcessRound();
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
