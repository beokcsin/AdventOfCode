using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2024
{
    public class DaySolutionFactory
    {
        private static readonly Dictionary<int, Func<IDaySolution>> Solutions = new()
        {
            {1, () => new Day1() },
            {2, () => new Day2() },
            {3, () => new Day3() }
        };  

        public static IDaySolution? GetSolution(int day)
        {
            try
            {
                Solutions.TryGetValue(day, out var solution);
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
