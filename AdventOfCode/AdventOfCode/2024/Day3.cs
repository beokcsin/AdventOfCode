using System.Globalization;
using System.Reflection.Metadata.Ecma335;
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
            sum = CalculateMulSum(mulList, sum);
        }

        return sum.ToString();
    }

    public string Part2()
    {
        var sum = 0;
        var enabled = true;

        ReadInput(out var inputLines);
        foreach (var line in inputLines)
        {
            enabled = GetPossibleMulOperationsWithDoAndDont(line, enabled, out var mulList);
            sum = CalculateMulSum(mulList, sum);
        }

        return sum.ToString();
    }

    private static bool GetPossibleMulOperationsWithDoAndDont(string line, bool enabled, out List<string> mulList)
    {
        mulList = [];
        var matches = Matches(line, @"mul\((\d{1,3},\d{1,3})\)|do\(\)|don't\(\)");

        foreach (Match match in matches)
        {
            switch (match.Value)
            {
                case "do()":
                    enabled = true;
                    break;
                case "don't()":
                    enabled = false;
                    break;
                default:
                    if (enabled)
                        mulList.Add(match.Value);
                    break;
            }
        }
        return enabled;
    }

    private static int CalculateMulSum(List<string> mulList, int sum)
    {
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

        return sum;
    }

    private static void ReadInput(out List<string> inputLines)
    {
        inputLines = [];
        inputLines.AddRange(File.ReadLines(@".\2024\Input\Day3.txt"));
    }

    private static void GetPossibleMulOperations(string line, out List<string> mulList)
    {
        mulList = [];
        var matches = Matches(line, @"mul\(\d{1,3},\d{1,3}\)");

        foreach (Match match in matches)
        {
            mulList.Add(match.Value);
        }
    }
}