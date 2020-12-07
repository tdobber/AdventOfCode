using System;

namespace AdventOfCode._2018
{
    // IronPython 3 is not ready for use yet, so this can go back into the fridge... Ooooorr rewrite to c#...
    public static class Year2018
    {
        public static void StartDay(int day)
        {
            //var engine = Python.CreateEngine();
            //var script = $"..\\..\\..\\2018\\Day_DAY.py";

            switch (day)
            {
                //case 1:
                //    script = script.Replace("_DAY", "1");
                //    break;

                //case 2:
                //    Day2.Start();
                //    break;

                //case 3:
                //    Day3.Start();
                //    break;

                //case 4:
                //    Day4.Start();
                //    break;

                //case 5:
                //    Day5.Start();
                //    break;

                //case 6:
                //    Day6.Start();
                //    break;

                //case 7:
                //    Day7.Start();
                //    break;

                //case 8:
                //    Day8.Start();
                //    break;

                //case 9:
                //    Day9.Start();
                //    break;

                default:
                    Console.WriteLine("That day is not supported yet");
                    break;
            }

            //var source = engine.CreateScriptSourceFromString(script);

            //var engineIO = engine.Runtime.IO;
            //var errors = new MemoryStream();
            //engineIO.SetErrorOutput(errors, Encoding.Default);

            //var results = new MemoryStream();
            //engineIO.SetOutput(results, Encoding.Default);

            //var scope = engine.CreateScope();
            //source.Execute(scope);

            //string str(byte[] x) => Encoding.Default.GetString(x);
            //Console.WriteLine("Errors:");
            //Console.WriteLine(str(errors.ToArray()));
            //Console.WriteLine();
            //Console.WriteLine("Results:");
            //Console.WriteLine(str(results.ToArray()));
        }
    }
}
