using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2024
{
    public class DaySolutionFactory
    {
        private static readonly Dictionary<int, Func<IDaySolution>> solutions = new()
        {
            {1, () => new Day1() },
            {2, () => new Day2() }
        };  

        public static IDaySolution? GetSolution(int day)
        {
            try
            {
                solutions.TryGetValue(day, out var solution);
                return solution();
            }
            catch 
            {
                Console.WriteLine("Please select a valid value!");
            }
            return null;
        }
    }
}
