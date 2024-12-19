namespace AdventOfCode.Problems.Problem2;

using System;
using System.IO;
using AdventOfCode.Helpers;

class Problem2
{
    public static void Solve()
    {
        var problemInput = Helpers.FileTo2dArray(Helpers.GetProblemInputFilePath("2")," ");
        
        if (problemInput != null)
        {
            var numSafe = 0;

            foreach (var report in problemInput)
            {
                var isSafe = true;
                var increasing = int.Parse(report[0]) - int.Parse(report[1]) < 0;
                for (var i = 1; i < report.Count; i++)
                {
                    var diff = int.Parse(report[i - 1]) - int.Parse(report[i]);
                    if (increasing != diff < 0)
                    {
                        isSafe = false;
                    }
                    if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                    {
                        isSafe = false;
                    }
                }

                if (isSafe)
                {
                    numSafe++;
                }
            }
            Console.WriteLine(numSafe);
        }
        else
        {
            Console.WriteLine("Empty Problem Input");
        }
    }

    public static void Solve2()
    {
        var problemInput = Helpers.FileTo2dArray(Helpers.GetProblemInputFilePath("2")," ");
        
        if (problemInput != null)
        {
            var numSafe = 0;

            foreach (var report in problemInput)
            {
                var isSafe = IsSafe(report);
                if (!isSafe)
                {
                    for (var i = 0; i < report.Count; i++)
                    {
                        var reportCopy = report.ToList();
                        reportCopy.RemoveAt(i);
                        isSafe = IsSafe(reportCopy);
                        if (isSafe)
                        {
                            break;
                        }
                    }
                }

                if (isSafe)
                {
                    numSafe++;
                }
            }
            Console.WriteLine(numSafe);
        }
        else
        {
            Console.WriteLine("Empty Problem Input");
        }
    }

    private static bool IsSafe(List<string> report)
    {
        var isSafe = true;
        var increasing = int.Parse(report[0]) - int.Parse(report[1]) < 0;
        for (var i = 1; i < report.Count; i++)
        {
            var diff = int.Parse(report[i - 1]) - int.Parse(report[i]);
            if (increasing != diff < 0)
            {
                isSafe = false;
            }
            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
            {
                isSafe = false;
            }
        }
        return isSafe;
    }
}