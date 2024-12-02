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
                if(CheckIncreasing(report))
                    safeReportsCount++;
            }
            if(CheckDecreasing(report))
                safeReportsCount++;
        }

        return safeReportsCount.ToString();
    }

    public string Part2()
    {
        ReadInput(out var reportLines);

        var safeReportsCount = 0;
        foreach (var report in reportLines)
        {
            if (report.ElementAt(0) < report.ElementAt(1))
            {
                if(CheckIncreasingWithDampening(report))
                    safeReportsCount++;
            }
            else
            {
                if (CheckDecreasingWithDampening(report))
                    safeReportsCount++;
            }
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

    private static bool CheckDecreasingWithDampening(List<int> report)
    {
        if (!CheckDecreasing(report))
        {
            var newReports = report.Select(num => new List<int>(report)).ToList();
            for (var i = 0; i < newReports.Count; i++)
            {
                var modifiedReport = newReports.ElementAt(i);
                modifiedReport.RemoveAt(i);
                if (modifiedReport.ElementAt(0) < modifiedReport.ElementAt(1))
                {
                    if (CheckIncreasing(modifiedReport))
                        return true;
                }
                else
                {
                    if (CheckDecreasing(modifiedReport))
                        return true;
                }
            }
        }

        return CheckDecreasing(report);
    }

    private static bool CheckIncreasingWithDampening(List<int> report)
    {
        if (!CheckIncreasing(report))
        {
            var newReports = report.Select(num => new List<int>(report)).ToList();
            for (var i = 0; i < newReports.Count; i++)
            {
                var modifiedReport = newReports.ElementAt(i);
                modifiedReport.RemoveAt(i);
                if (modifiedReport.ElementAt(0) < modifiedReport.ElementAt(1))
                {
                    if (CheckIncreasing(modifiedReport))
                        return true;
                }
                else
                {
                    if (CheckDecreasing(modifiedReport))
                        return true;
                }
            }
        }

        return CheckIncreasing(report);
    }

    private static bool CheckDecreasing(List<int> report)
    {
        var num = -1000;
        foreach (var number in report)
        {
            if (num is not -1000)
            {
                var diff = num - number;
                if(diff is < 1 or > 3)
                    return false;
            }
            num = number;
        }
        return true;
    }

    private static bool CheckIncreasing(List<int> report)
    {
        var num = -1000;
        foreach (var number in report)
        {
            if (num is not -1000)
            {
                var diff = number - num;
                if (diff is < 1 or > 3)
                    return false;
            }
            num = number;
        }
        return true;
    }
}