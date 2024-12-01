using AdventOfCode._2024;
using System.ComponentModel.DataAnnotations;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Select which days solution you would like to see (1-24): ");

        bool isLegit = false;
        while (isLegit is false)
        {
            try
            {
                _ = int.TryParse(Console.ReadLine(), out var day);

                IDaySolution solution = DaySolutionFactory.GetSolution(day);
                if(solution != null)
                {
                    Console.WriteLine("Solution for part 1:");
                    Console.WriteLine(solution.Part1());

                    Console.WriteLine("Solution for part 2:");
                    Console.WriteLine(solution.Part2());
                    isLegit = true;
                }
            }
            catch
            {
                Console.WriteLine("Please select a day, for which a solution exists!");
            }
        }
    }
}