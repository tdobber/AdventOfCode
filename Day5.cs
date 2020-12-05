using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day5
    {
        public class BoardingPass
        {
            public byte Row { get; set; }
            public byte Column { get; set; }
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

            foreach(string line in input)
            {
                string binaryLine = line.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1');

                boardingPasses.Add(new BoardingPass
                {
                    Row = Convert.ToByte(binaryLine[0..7], 2),
                    Column = Convert.ToByte(binaryLine[7..10], 2)
                });
            }

            return boardingPasses;
        }
 
        private static void Part1(List<string> input)
        {
            List<BoardingPass> boardingPasses = ReadBoardingPasses(input);

            Console.WriteLine($"The highest seat id is {boardingPasses.Max(pass => pass.SeatId)}.");
        }

        private static void Part2(List<string> input)
        {
            List<BoardingPass> boardingPasses = ReadBoardingPasses(input);

            BoardingPass boardingPass = boardingPasses.Where(pass => !boardingPasses.Any(plusOne => plusOne.SeatId == pass.SeatId + 1) &&
                                                                boardingPasses.Any(plusTwo => plusTwo.SeatId == pass.SeatId + 2)).FirstOrDefault();
            Console.WriteLine($"The id of your seat is {boardingPass.SeatId + 1}.");
        }


        public static void Start(string readFile)
        {
            List<string> input = File.ReadAllLines(readFile).ToList();

            Part1(input);

            Part2(input);
        }
    }
}
