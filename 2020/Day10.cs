using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020
{
    public static class Day10
    {
        private static List<int> Input => InputHelper.GetInputListInt(2020, 10).ToList();

        private static int CheckPossibilities(List<int> oneDiffRange)
        {
            int possibilities = 0;

            // size 3 = 2
            // size 4 = 4
            // size 5 = 7
            // size 6 = 12?
            // size 7 = ??

            return possibilities;
        }

        private static void Part1()
        {
            List<int> adapters = new List<int> { 0, Input.Max() + 3 };
            adapters.AddRange(Input);
            adapters.Sort();

            int joltDiff1 = 0;
            int joltDiff3 = 0;

            for (int i = 0; i < adapters.Count - 1; i++)
            {
                if (adapters[i + 1] - adapters[i] == 1)
                {
                    joltDiff1++;
                }
                else if (adapters[i + 1] - adapters[i] == 3)
                {
                    joltDiff3++;
                }
                else if (adapters[i + 1] - adapters[i] > 3)
                {
                    break;
                }
            }

            Console.WriteLine($"One jolt differences {joltDiff1} times 3 jolt differences {joltDiff3} is {joltDiff1 * joltDiff3}");
        }

        private static void Part2()
        {
            List<int> adapters = new List<int> { 0, Input.Max() + 3};
            adapters.AddRange(Input);
            adapters.Sort();

            long possibilities = 1;
            int forwardIndex = 1;

            // input count + 1 is the same size (and 1 lower) than the original adapters size plus the 2 new ones
            for (int i = 0; i < adapters.Count - 1; i++)
            {
                //if (i + 3 == adapters.Count || i + 2 == adapters.Count || adapters[i + 1] - adapters[i] == 0)
                //{
                //    break;
                //}
                //else if (adapters[i + 1] - adapters[i] < 3)
                //{
                //    if (adapters[i + 2] - adapters[i] <= 3)
                //    {
                //        possibilities++;
                //    }

                //    if (adapters[i + 3] - adapters[i] == 3)
                //    {
                //        possibilities++;
                //    }

                //    //possibilities++;
                //}
                //else if (adapters[i + 1] - adapters[i] == 3)
                //{
                //    continue;
                //}
                //else if (adapters[i + 3] - adapters[i] == 3)
                //{
                //    possibilities *= 4;
                //    i += 2;
                //}
                //else if (adapters[i + 2] - adapters[i] <= 3)
                //{
                //    possibilities *= 2;
                //    i++;
                //}

                while(adapters[i + forwardIndex] - adapters[i] == forwardIndex)
                {
                    forwardIndex++;
                }

                List<int> oneDiffRange = new List<int>();
                if (forwardIndex > 2)
                {
                    oneDiffRange = adapters.ToArray()[i..(i + forwardIndex)].ToList();
                }

                possibilities *= CheckPossibilities(oneDiffRange);
                i += forwardIndex - 1;
                forwardIndex = 1;
            }

            Console.WriteLine($"The amount of distinct ways to arrange the adapters is {possibilities}");
        }

        public static void Start()
        {
            Part1();

            Part2();
        }
    }
}
