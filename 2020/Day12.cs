using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020
{
    public static class Day12
    {
        private static List<string> Input => InputHelper.GetInputListString(2020, 12).ToList();

        public class Ship
        {
            public int PositionX { get; set; }
            public int PositionY { get; set; }
            public int FacingDirection { get; set; } = 90;

            public void Navigate()
            {
                foreach (string line in Input)
                {
                    char action = line[0];
                    int amount = int.Parse(line.Replace(action.ToString(), ""));

                    switch (action)
                    {
                        case 'N':
                            PositionY += amount;
                            break;

                        case 'E':
                            PositionX += amount;
                            break;

                        case 'S':
                            PositionY -= amount;
                            break;

                        case 'W':
                            PositionX -= amount;
                            break;

                        case 'L':
                            FacingDirection = (FacingDirection - amount) % 360;
                            break;

                        case 'R':
                            FacingDirection = (FacingDirection + amount) % 360;
                            break;

                        case 'F':
                            switch (FacingDirection)
                            {
                                case 0:
                                    PositionY += amount;
                                    break;

                                case 90:
                                case -270:
                                    PositionX += amount;
                                    break;

                                case 180:
                                case -180:
                                    PositionY -= amount;
                                    break;

                                case 270:
                                case -90:
                                    PositionX -= amount;
                                    break;

                                default:
                                    Console.WriteLine("Should not be an existing facing direction, debug please!");
                                    break;
                            }
                            break;

                        default:
                            Console.WriteLine("Should not happen, debug please!");
                            break;
                    }
                }
            }
        }

        private static int CalculateManhattanDistance(Ship ship)
        {
            return Math.Abs(ship.PositionX) + Math.Abs(ship.PositionY);
        }

        private static void Part1()
        {
            Ship ship = new Ship();
            ship.Navigate();
            Console.WriteLine($"The manhattan distance after the instructions is {CalculateManhattanDistance(ship)}");
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
