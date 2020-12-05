using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day5
    {
        public class BoardingPass
        {
            public string OriginalSeat { get; set; }
            public byte[] OriginalRow { get; set; }
            public byte[] OriginalColumn { get; set; }
            public int Row { get; set; }
            public int Column { get; set; }
            public int SeatId
            {
                get
                {
                    return (Row * 8) + Column;
                }
            }
        }

        public static List<BoardingPass> ReadBoardingPasses(List<string> input)
        {
            List<BoardingPass> boardingPasses = new List<BoardingPass>();

            return boardingPasses;
        }
 
        private static void Part1(List<string> input)
        {
        }

        private static void Part2(List<string> input)
        {
         
        }


        public static void Start(string readFile)
        {
            List<string> input = File.ReadAllLines(readFile).ToList();

            Part1(input);

            Part2(input);
        }
    }
}
