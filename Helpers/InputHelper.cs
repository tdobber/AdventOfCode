using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Helpers
{
    public static class InputHelper
    {
        public static List<string> GetInputListString(int year, int day)
        {
            if (File.Exists($"..\\..\\..\\{year}\\Inputs\\Day{day}.txt")) {
                return File.ReadAllLines($"..\\..\\..\\{year}\\Inputs\\Day{day}.txt").ToList();
            }
            else
            {
                return File.ReadAllLines($"../../../{year}/Inputs/Day{day}.txt").ToList();
            }
        }
        
        public static List<int> GetInputListInt(int year, int day) =>
            File.ReadAllLines($"..\\..\\..\\{year}\\Inputs\\Day{day}.txt").Select(int.Parse).ToList();
        
        public static List<long> GetInputListLong(int year, int day) =>
            File.ReadAllLines($"..\\..\\..\\{year}\\Inputs\\Day{day}.txt").Select(long.Parse).ToList();

        public static string GetInputString(int year, int day) =>
            File.ReadAllText($"..\\..\\..\\{year}\\Inputs\\Day{day}.txt");
    }
}
