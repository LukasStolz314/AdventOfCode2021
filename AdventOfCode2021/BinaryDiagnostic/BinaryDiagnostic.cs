using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    //Challenge 3

    internal class BinaryDiagnostic : IChallenge<Int32, Int32>
    {
        String path = "./BinaryDiagnostic/BinaryDiagnostic.txt";

        public Int32 SolveFirst()
        {
            List<String> lines = System.IO.File.ReadAllLines(path).ToList();

            Int32[] gammaArr = new Int32[lines[0].Length];
            Int32[] epsArr = new Int32[lines[0].Length];            

            foreach (String line in lines)                
                for (int j = 0; j < line.Length; j++)
                {
                    gammaArr[j] += (line[j] == '1') ? 1 : -1;
                    epsArr[j] += (line[j] == '0') ? 1 : -1;
                }

            Int32 gamma = 0;
            Int32 epsilon = 0;
            for (int k = gammaArr.Length - 1; k >= 0; k--)
            {
                gamma += gammaArr.ElementAt(k) > 0 ? (Int32)Math.Pow(2, gammaArr.Length - (k+1)) : 0;
                epsilon += epsArr.ElementAt(k) > 0 ? (Int32)Math.Pow(2, gammaArr.Length - (k + 1)) : 0;
            }

            return gamma * epsilon;
        }

        public Int32 SolveSecond()
        {
            return 0;
        }
    }
}
