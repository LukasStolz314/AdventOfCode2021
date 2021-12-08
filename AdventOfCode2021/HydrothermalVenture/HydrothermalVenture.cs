using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    //Challenge 5

    internal class HydrothermalVenture : IChallenge<Int32, Int32>
    {
        String path = "./HydrothermalVenture/HydrothermalVenture.txt";

        public Int32 SolveFirst()
        {
            //Friend flexed with his 2 line python code => So i did it in 1 :P
            List<((Int32, Int32), (Int32, Int32))> lines = System.IO.File.ReadAllLines(path).Select(x => x.Split(" -> ")).Select(x => ((Int32.Parse(x[0].Split(',')[0]), Int32.Parse(x[0].Split(',')[1])), (Int32.Parse(x[1].Split(',')[0]), Int32.Parse(x[1].Split(',')[1])))).ToList();

            List<(Int32, Int32)> allLinePoints = new();
            foreach(var line in lines)
            {
                    if(line.Item1.Item1 == line.Item2.Item1)
                        for(int i = 0; i <= Math.Max(line.Item1.Item2, line.Item2.Item2) - Math.Min(line.Item1.Item2, line.Item2.Item2); i++)
                            allLinePoints.Add((line.Item1.Item1, Math.Min(line.Item1.Item2, line.Item2.Item2) + i));
                    else if(line.Item1.Item2 == line.Item2.Item2)
                        for(int i = 0; i <= Math.Max(line.Item1.Item1, line.Item2.Item1) - Math.Min(line.Item1.Item1, line.Item2.Item1); i++)
                            allLinePoints.Add((Math.Min(line.Item1.Item1, line.Item2.Item1) + i, line.Item1.Item2));
            }

            Dictionary<(Int32, Int32), Int32> matchingPoints = new();
            foreach (var points in allLinePoints)
            {
                if(matchingPoints.ContainsKey(points))
                    matchingPoints[points]++;
                else
                    matchingPoints.Add(points, 1);
            }

            return matchingPoints.Where(x => x.Value > 1).Count();
        }

        public Int32 SolveSecond()
        { 
            List<String> lines = System.IO.File.ReadAllLines(path).ToList();

            return 0;
        }
    }
}
