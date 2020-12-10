﻿using System;
using System.Diagnostics;
using AdventOfCode.Days;


namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            new Six().Run();

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);



        }
    }
}
