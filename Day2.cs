using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class PasswordEntry
    {
        public int LeftNumber { get; set; }
        public int RightNumber { get; set; }
        public char Letter { get; set; }
        public string Password { get; set; }
    }

    public static class Day2
    {
        private static PasswordEntry MatchPassword(string password)
        {
            Match match = Regex.Match(password, @"^(?<minimum>\d+)-(?<maximum>\d+)\s+(?<letter>\w):\s+(?<password>\w+)");

            if (match.Success)
            {
                return new PasswordEntry
                {
                    LeftNumber = int.Parse(match.Groups["minimum"].Value),
                    RightNumber = int.Parse(match.Groups["maximum"].Value),
                    Letter = char.Parse(match.Groups["letter"].Value),
                    Password = match.Groups["password"].Value,
                };
            }

            return null;
        }

        private static void Part1(List<string> input)
        {
            int valid = 0;
            foreach (string passwordEntry in input)
            {
                PasswordEntry entry = MatchPassword(passwordEntry);

                if (entry != null)
                {
                    int count = entry.Password.Count(x => x == entry.Letter);
                    if (entry.LeftNumber <= count && count <= entry.RightNumber)
                    {
                        valid++;
                    }
                }
                else
                {
                    Console.WriteLine("Should not happen... Debug please!");
                }
            }

            Console.WriteLine($"The amount of valid passwords for part 1 is {valid}.");
        }

        private static void Part2(List<string> input)
        {
            int valid = 0;
            foreach (string passwordEntry in input)
            {
                PasswordEntry entry = MatchPassword(passwordEntry);
                if (entry != null)
                {
                    if (entry.Password[entry.LeftNumber - 1] == entry.Letter ^ entry.Password[entry.RightNumber - 1] == entry.Letter)
                    {
                        valid++;
                    }
                }
                else
                {
                    Console.WriteLine("Should not happen... Debug please!");
                }
            }

            Console.WriteLine($"The amount of valid passwords for part 2 is {valid}.");
        }


        public static void Start(string readFile)
        {
            List<string> input = File.ReadAllLines(readFile).ToList();
            //List<string> input = new List<string> { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };
            Part1(input);

            Part2(input);
        }
    }
}
