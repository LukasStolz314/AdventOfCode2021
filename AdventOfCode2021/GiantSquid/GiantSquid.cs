using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    //Challenge 4

    internal class GiantSquid : IChallenge<Int32, Int32>
    {
        String path = "./GiantSquid/GiantSquid.txt";

        public Int32 SolveFirst()
        {
            List<String> lines = System.IO.File.ReadAllLines(path).Where(x => x != String.Empty).ToList();
            List<Int32> rndNumbers = lines[0].Split(',').Select(x => Int32.Parse(x)).ToList();
            List<(Int32, bool)[,]> fields = new();

            for(int i = 1; i < lines.Count(); i += 5)
            {
                (Int32, bool)[,] field = new (Int32, bool)[5, 5];
                for(int j = 1; j < 6; j++)
                {
                    List<Int32> line = lines[j + i - 1].Split(" ").Where(x => x != String.Empty).Select(x => Int32.Parse(x)).ToList();                    
                    foreach(Int32 digit in line) field[j - 1, line.IndexOf(digit)] = (digit, false);
                }
                fields.Add(field);
            }

            (Int32, bool)[,] winningField = null;
            Int32 winningNumber = 0;
            foreach(Int32 number in rndNumbers)
            {
                foreach(var field in fields)
                    for(int k = 0; k < 5; k++)
                    {
                        Boolean isVertFull = true;
                        Boolean isHoriFull = true;
                        for(int l = 0; l < 5; l++)
                        {           
                            if(field[k, l].Item1 == number)
                                field[k, l].Item2 = true;
                            if(field[k, l].Item2 == false)
                                isVertFull = false;
                            if(field[l, k].Item2 == false)
                                isHoriFull = false;
                        }
                        if(isVertFull == true || isHoriFull == true)
                        {
                            winningField = field;
                            winningNumber = number;
                            break;
                        }
                    }
                    if(winningField != null)
                        break;
            }

            Int32 count = 0;
            for(int n = 0; n < 5; n++)
                for(int o = 0; o < 5; o++)
                    count += winningField[n, o].Item2 == false ? winningField[n, o].Item1 : 0;            

            return count * winningNumber;
        }

        public Int32 SolveSecond()
        {
            List<String> lines = System.IO.File.ReadAllLines(path).Where(x => x != String.Empty).ToList();
            List<Int32> rndNumbers = lines[0].Split(',').Select(x => Int32.Parse(x)).ToList();
            List<(Int32, bool)[,]> fields = new();

            for(int i = 1; i < lines.Count(); i += 5)
            {
                (Int32, bool)[,] field = new (Int32, bool)[5, 5];
                for(int j = 1; j < 6; j++)
                {
                    List<Int32> line = lines[j + i - 1].Split(" ").Where(x => x != String.Empty).Select(x => Int32.Parse(x)).ToList();                    
                    foreach(Int32 digit in line) field[j - 1, line.IndexOf(digit)] = (digit, false);
                }
                fields.Add(field);
            }

            List<(Int32, bool)[,]> lastFields = new List<(int, bool)[,]>(fields);
            ((Int32, bool)[,], Int32) loosing = (null, 0);
            foreach(Int32 number in rndNumbers)
            {
                foreach(var field in fields)
                    if(lastFields.Contains(field))
                        for(int k = 0; k < 5; k++)
                        {
                            Boolean isVertFull = true;
                            Boolean isHoriFull = true;
                            for(int l = 0; l < 5; l++)
                            {           
                                if(field[k, l].Item1 == number)
                                    field[k, l].Item2 = true;
                                if(field[k, l].Item2 == false)
                                    isVertFull = false;
                                if(field[l, k].Item2 == false)
                                    isHoriFull = false;
                            }
                            if(isVertFull == true || isHoriFull == true)
                            {
                                if(lastFields.Count() == 1) loosing = (lastFields.FirstOrDefault(), number);
                                lastFields.Remove(field);
                                break;
                            }
                        }
            }

            Int32 count = 0;
            for(int n = 0; n < 5; n++)
                for(int o = 0; o < 5; o++)
                    count += loosing.Item1[n, o].Item2 == false ? loosing.Item1[n, o].Item1 : 0;            

            return count * loosing.Item2;
        }
    }
}
