using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    //Challenge 1

    internal class SonarSweep : IChallenge<Int32, Int32>
    {
        String path = "./SonarSweep/SonarSweep.txt";

        public Int32 SolveFirst()
        {
            List<String> depths = System.IO.File.ReadAllLines(path).ToList();

            Int32 counter = 0;
            Int32 previous = Int32.MaxValue;

            foreach(String depth in depths)
            {
                if (Int32.Parse(depth) > previous)
                    counter++;
                previous = Int32.Parse(depth);
            }

            return counter;
        }

        public Int32 SolveSecond()
        {
            String[] input = System.IO.File.ReadAllLines(path);
            Int32[] depths = new Int32[input.Length];
            for (Int32 i = 0; i < input.Length; i++)
                depths[i] = Int32.Parse(input[i]);

            Int32 counter = 0;

            for (Int32 i = 0; i < depths.Length - 3; i++)
            {
                Int32 firstSum = depths[i] + depths[i + 1] + depths[i + 2];
                Int32 secondSum = depths[i+1] + depths[i + 2] + depths[i + 3];
                if (secondSum > firstSum)
                    counter++;
            }

            return counter;
        }
    }
}
