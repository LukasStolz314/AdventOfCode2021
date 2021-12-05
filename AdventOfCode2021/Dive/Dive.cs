using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    internal class Dive : IChallenge<Int32, Int32>
    {
        String path = "./Dive/Dive.txt";

        public Int32 SolveFirst()
        {
            List<String> moves = System.IO.File.ReadAllLines(path).ToList();

            Int32 horizontal = 0;
            Int32 depth = 0;

            foreach (String move in moves)
            {
                String[] action = move.Split(" ");
                if (action[0] == "forward")
                    horizontal += Int32.Parse(action[1]);
                else if(action[0] == "down") 
                    depth += Int32.Parse(action[1]);
                else 
                    depth -= Int32.Parse(action[1]);
            }

            return horizontal * depth;
        }

        public Int32 SolveSecond()
        { 
            List<String> moves = System.IO.File.ReadAllLines(path).ToList();

            Int32 horizontal = 0;
            Int32 depth = 0;
            Int32 aim = 0;

            foreach (String move in moves)
            {
                String[] action = move.Split(" ");
                if (action[0] == "forward")
                {
                    horizontal += Int32.Parse(action[1]);
                    depth += (aim * Int32.Parse(action[1]));
                }
                else if(action[0] == "down") 
                    aim += Int32.Parse(action[1]);
                else 
                    aim -= Int32.Parse(action[1]);
            }

            return horizontal * depth;
        }
    }
}
