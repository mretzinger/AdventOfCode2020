using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using AdventOfCode.Days;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            new Four().Run();

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
