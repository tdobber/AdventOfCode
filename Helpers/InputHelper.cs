using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Helpers
{
    public static class InputHelper
    {
        public static List<string> GetInputListString(int year, int day) =>
            File.ReadAllLines($"..\\..\\..\\{year}\\Inputs\\Day{day}.txt").ToList();
        
        public static List<int> GetInputListInt(int year, int day) =>
            File.ReadAllLines($"..\\..\\..\\{year}\\Inputs\\Day{day}.txt").Select(int.Parse).ToList();

        public static string GetInputString(int year, int day) =>
            File.ReadAllText($"..\\..\\..\\{year}\\Inputs\\Day{day}.txt");
    }
}
