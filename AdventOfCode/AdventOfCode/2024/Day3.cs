using System.Globalization;
using System.Text.RegularExpressions;
using static System.Text.RegularExpressions.Regex;

namespace AdventOfCode._2024;

public class Day3 : IDaySolution
{
    public string Part1()
    {
        var sum = 0;

        ReadInput(out var inputLines);
        foreach (var line in inputLines)
        {
            GetPossibleMulOperations(line, out var mulList);
            foreach (var mul in mulList)
            {
                var trim = mul.Trim();
                trim = trim.Remove(trim.Length - 1);
                trim = trim.Remove(0, 4);

                var nums = trim.Split(",");
                var num1 = int.Parse(nums[0]);
                var num2 = int.Parse(nums[1]);

                sum += num1 * num2;
            }
        }

        return sum.ToString();
    }

    public string Part2()
    {
        return "Not Implemented";
    }

    public static void ReadInput(out List<string> inputLines)
    {
        inputLines = [];
        inputLines.AddRange(File.ReadLines(@".\2024\Input\Day3.txt"));
    }

    public static void GetPossibleMulOperations(string line, out List<string> mulList)
    {
        mulList = [];
        var matches = Matches(line, @"mul\(\d{1,3},\d{1,3}\)");

        foreach (Match match in matches)
        {
            mulList.Add(match.Value);
        }
    }
}