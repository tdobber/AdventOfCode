using System;
using System.IO;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which day would you like to run?");
            int dayToRun = Convert.ToInt16(Console.ReadLine());

            string cwd = Directory.GetCurrentDirectory();
            string readFile;

            if (cwd.EndsWith('9'))
                readFile = "Inputs//";
            else
                readFile = "..//..//..//Inputs//";

            switch (dayToRun)
            {
                case 1:
                    Day1.Start(readFile);
                    break;

                case 2:
                    Day2.Start(readFile);
                    break;

                default:
                    Console.WriteLine("That day is not supported yet");
                    break;
            }
        }
    }
}
