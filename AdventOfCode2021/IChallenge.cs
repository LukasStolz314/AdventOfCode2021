using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public interface IChallenge<FirstRType, SecondRType>
    {
        public FirstRType SolveFirst();
        public SecondRType SolveSecond();
    }
}
