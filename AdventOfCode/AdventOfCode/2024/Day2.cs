namespace AdventOfCode._2024;

public class Day2 : IDaySolution
{
    public string Part1()
    {
        ReadInput(out var reportLines);
        
        var safeReportsCount = 0;
        foreach (var report in reportLines)
        {
            if (report.ElementAt(0) < report.ElementAt(1))
            {
                safeReportsCount = CheckIncreasing(report, safeReportsCount);
            }
            safeReportsCount = CheckDecreasing(report, safeReportsCount);
        }


        return safeReportsCount.ToString();
    }

    private static void ReadInput(out List<List<int>> reportLines)
    {
        reportLines = [];
        foreach (var line in File.ReadLines(@".\2024\Input\Day2.txt")) 
        {
            var report = line.Split(" ");
            var nums = report.Select(int.Parse).ToList();

            reportLines.Add(nums);
        }
    }

    private static int CheckDecreasing(List<int> report, int safeReportsCount)
    {
        int num = -1000;
        foreach (var number in report)
        {
            if (num is not -1000)
            {
                var diff = num - number;
                if(diff is < 1 or > 3)
                    return safeReportsCount;
            }
            num = number;
        }
        return safeReportsCount + 1;
    }

    private static int CheckIncreasing(List<int> report, int safeReportsCount)
    {
        int num = -1000;
        foreach (var number in report)
        {
            if (num is not -1000)
            {
                var diff = number - num;
                if (diff is < 1 or > 3)
                    return safeReportsCount;
            }
            num = number;
        }
        return safeReportsCount + 1;
    }

    public string Part2()
    {
        return "null";
    }
}