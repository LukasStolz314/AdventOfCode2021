using System;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = SolveChallenge<Int32, Int32>(new SonarSweep());

            String firstResult = "First Result: " + result.Item1;
            String secondResult = "SecondResult: " + result.Item2;           
            Console.WriteLine(firstResult + "\n" + secondResult);

            Console.ReadLine();
        }

        static (T, R) SolveChallenge<T, R> (IChallenge<T, R> challenge)
        {
            return (challenge.SolveFirst(), challenge.SolveSecond());
        }
    }
}
