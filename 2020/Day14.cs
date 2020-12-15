using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2020
{
    public static class Day14
    {
        private static List<string> Input => InputHelper.GetInputListString(2020, 14).ToList();

        public class InitializationProgram
        {
            public Dictionary<long, long> Memory { get; set; } = new Dictionary<long, long>();
        }

        private static void Part1()
        {
            InitializationProgram program = new InitializationProgram();
            string mask = "";

            foreach(string line in Input)
            {
                string[] splitted = line.Split(" = ");
                if (splitted[0] == "mask")
                {
                    mask = splitted[1];
                }
                else
                {
                    Match match = Regex.Match(splitted[0], @"^mem\[(?<address>\d+)\]$");
                    long address = long.Parse(match.Groups["address"].Value);
                    string value = Convert.ToString(long.Parse(splitted[1]), 2).PadLeft(36, '0');
                    string newValue = "";

                    for (int i = 0; i < 36; i++)
                    {
                        if (mask[i] != 'X')
                        {
                            newValue += mask[i];
                        }
                        else
                        {
                            newValue += value[i];
                        }
                    }

                    if (!program.Memory.ContainsKey(address))
                    {
                        program.Memory.Add(address, Convert.ToInt64(newValue, 2));
                    }
                    else
                    {
                        program.Memory[address] = Convert.ToInt64(newValue, 2);
                    }
                }
            }

            Console.WriteLine($"The sum of all values left in memory after the program completes is {program.Memory.Sum(x => x.Value)}");
        }

        private static void Part2()
        {
            InitializationProgram program = new InitializationProgram();
            string mask = "";

            foreach (string line in Input)
            {
                string[] splitted = line.Split(" = ");
                if (splitted[0] == "mask")
                {
                    mask = splitted[1];
                }
                else
                {
                    Match match = Regex.Match(splitted[0], @"^mem\[(?<address>\d+)\]$");
                    long address = long.Parse(match.Groups["address"].Value);
                    string addressBit = Convert.ToString(address, 2).PadLeft(36, '0');
                    string value = Convert.ToString(long.Parse(splitted[1]), 2).PadLeft(36, '0');
                    string newAddress = "";

                    for (int i = 0; i < 36; i++)
                    {
                        switch (mask[i])
                        {
                            case '0':
                                break;

                            case '1':
                                newAddress += '1';
                                break;

                            case 'X':
                                newAddress += 'X';
                                break;
                        }
                    }

                    //if (!program.Memory.ContainsKey(address))
                    //{
                    //    program.Memory.Add(address, Convert.ToInt64(newValue, 2));
                    //}
                    //else
                    //{
                    //    program.Memory[address] = Convert.ToInt64(newValue, 2);
                    //}
                }
            }

            Console.WriteLine($"The sum of all values left in memory after the program completes is {program.Memory.Sum(x => x.Value)}");
        }

        public static void Start()
        {
            Part1();

            Part2();
        }
    }
}
