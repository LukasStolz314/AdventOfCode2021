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
            List<String> oxygenList = System.IO.File.ReadAllLines(path).ToList();
            List<String> scrubberList = new(oxygenList);

            Int32 bitLength = oxygenList.FirstOrDefault().Length;
            Int32 oxygen = 0;
            Int32 scrubber = 0;            
            for(int i = 0; i < bitLength; i++)
            {
                Int32 oxcounter = 0;
                Int32 sccounter = 0;
                foreach(var value in oxygenList)
                    oxcounter += value[i] == '1' ? 1 : -1;
                foreach(var value in scrubberList)
                    sccounter += value[i] == '1' ? 1 : -1;
                
                oxygenList.RemoveAll(x => x[i] == (oxcounter >= 0 ? '0' : '1'));
                scrubberList.RemoveAll(x => x[i] == (sccounter >= 0 ? '1' : '0'));

                if(oxygenList.Count() == 1)
                    oxygen = Convert.ToInt32(oxygenList.FirstOrDefault(), 2);
                if(scrubberList.Count() == 1)
                    scrubber = Convert.ToInt32(scrubberList.FirstOrDefault(), 2);
            }

            return oxygen * scrubber;
        }
    }
}
