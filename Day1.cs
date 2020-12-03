using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public static class Day1
    {
        private static int Part1(List<int> input)
        {
            foreach (int i in input)
            {
                if (input.Contains(2020 - i))
                {
                    return i;
                }
            }

            return 0;
        }

        private static void Part2(List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = i + 1; j < input.Count; j++)
                {
                    int check = (2020 - input[i] - input[j]);
                    if (input.Contains(check))
                    {
                        Console.WriteLine($"The answer to part 1 is {input[i]} x {input[j]} x {check} = {input[i] * input[j] * check}");
                    }
                }
            }
        }


        public static void Start(string readFile)
        {
            List<string> input = File.ReadAllLines(readFile).ToList();
            List<int> intInput = input.Select(int.Parse).ToList();

            int result = Part1(intInput);
            Console.WriteLine($"The answer to part 1 is {result} x {(2020 - result)} = {result * (2020 - result)}");

            Part2(intInput);
        }
    }
}
