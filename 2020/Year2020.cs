﻿using System;

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
                
                case 9:
                    Day9.Start();
                    break;

                case 10:
                    Day10.Start();
                    break;

                case 11:
                    Day11.Start();
                    break;

                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                default:
                    Console.WriteLine("That day is not supported yet");
                    break;
            }
        }
    }
}
