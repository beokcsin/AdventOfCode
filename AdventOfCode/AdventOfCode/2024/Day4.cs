namespace AdventOfCode._2024;

public class Day4 : IDaySolution
{
    public string Part1()
    {
        var sum = 0;

        ReadInput(out var inputLines);

        sum = CalculateHorizontal(sum, inputLines);
        sum = CalculateVertical(sum, inputLines);
        sum = CalculateDiagonally(sum, inputLines);

        return sum.ToString();
    }

    public string Part2()
    {
        ReadInput(out var inputLines);

        var sum = CalculatePart2(inputLines);

        return sum.ToString();
    }

    private static int CalculatePart2(List<string> inputLines)
    {
        var sum = 0;

        for (var i = 0; i < inputLines.Count - 2; i++)
        {
            for (var j = 0; j < inputLines[0].Length - 2; j++)
            {
                if (inputLines[i][j] == 'M' && inputLines[i][j + 2] == 'S' && inputLines[i + 1][j + 1] == 'A' &&
                    inputLines[i + 2][j] == 'M' && inputLines[i + 2][j + 2] == 'S')
                    sum++;
                if(inputLines[i][j] == 'S' && inputLines[i][j + 2] == 'M' && inputLines[i + 1][j + 1] == 'A' &&
                   inputLines[i + 2][j] == 'S' && inputLines[i + 2][j + 2] == 'M')
                    sum++;
                if(inputLines[i][j] == 'M' && inputLines[i][j + 2] == 'M' && inputLines[i + 1][j + 1] == 'A' &&
                   inputLines[i + 2][j] == 'S' && inputLines[i + 2][j + 2] == 'S')
                    sum++;
                if(inputLines[i][j] == 'S' && inputLines[i][j + 2] == 'S' && inputLines[i + 1][j + 1] == 'A' &&
                   inputLines[i + 2][j] == 'M' && inputLines[i + 2][j + 2] == 'M')
                    sum++;
            }
        }

        return sum;
    }

    private static int CalculateDiagonally(int sum, List<string> inputLines)
    {
        sum = GetXmasCountDiagonally(sum, inputLines);

        var inputLinesWithRowsReversed = new List<string>(inputLines.Select(x => new string(x.Reverse().ToArray())));
        sum = GetXmasCountDiagonally(sum, inputLinesWithRowsReversed);

        var reverseInputLines = new List<string>(inputLines);
        reverseInputLines.Reverse();
        sum = GetXmasCountDiagonally(sum, reverseInputLines);

        var reverseInputLinesWithRowsReversed = new List<string>(inputLines.Select(x => new string(x.Reverse().ToArray())));
        reverseInputLinesWithRowsReversed.Reverse();
        sum = GetXmasCountDiagonally(sum, reverseInputLinesWithRowsReversed);

        return sum;
    }

    private static int GetXmasCountDiagonally(int sum, List<string> inputLines)
    {
        for(var i = 0; i < inputLines.Count - 3; i++)
        {
            for (var j = 0; j < inputLines[i].Length - 3; j++)
            {
                if (inputLines[i][j] == 'X' && inputLines[i + 1][j + 1] == 'M' && inputLines[i + 2][j + 2] == 'A' &&
                    inputLines[i + 3][j + 3] == 'S')
                    sum++;
            }
        }

        return sum;
    }

    private static int CalculateVertical(int sum, List<string> inputLines)
    {
        sum = GetXmasCountVertically(sum, inputLines);

        var reverseInputLines = new List<string>(inputLines);
        reverseInputLines.Reverse();
        sum = GetXmasCountVertically(sum, reverseInputLines);

        return sum;
    }

    private static int GetXmasCountVertically(int sum, List<string> inputLines)
    {
        for (var i = 0; i < inputLines.Count - 3; i++)
        {
            for (var j = 0; j < inputLines[i].Length; j++)
            {
                if (inputLines[i][j] == 'X' && inputLines[i + 1][j] == 'M' && inputLines[i + 2][j] == 'A' && inputLines[i + 3][j] == 'S')
                    sum++;
            }
        }

        return sum;
    }

    private static int CalculateHorizontal(int sum, List<string> inputLines)
    {
        foreach (var line in inputLines)
        {
            sum = GetXmasCountHorizontally(sum, line);

            var reverseLine = new string(line.Reverse().ToArray());
            sum = GetXmasCountHorizontally(sum, reverseLine);
        }

        return sum;
    }

    private static int GetXmasCountHorizontally(int sum, string line)
    {
        for (var i = 0; i < line.Length - 3; i++)
        {
            if (line.Substring(i, 4) == "XMAS")
                sum++;
        }

        return sum;
    }

    private static void ReadInput(out List<string> inputLines)
    {
        inputLines = [];
        inputLines.AddRange(File.ReadLines(@".\2024\Input\Day4.txt"));
    }
}