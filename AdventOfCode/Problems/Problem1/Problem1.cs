namespace AdventOfCode.Problems.Problem1;

using System;
using System.IO;
using AdventOfCode.Helpers;

class Problem1
{
    public static void Solve()
    {
        var problemInput = Helpers.FileTo2dArray(Helpers.GetProblemInputFilePath("1"),"   " , true);
        if (problemInput != null)
        {
            problemInput[0].Sort((a, b) => int.Parse(a).CompareTo(int.Parse(b)));
            problemInput[1].Sort((a, b) => int.Parse(a).CompareTo(int.Parse(b)));
            var diffCount = 0;
            
            for (int i = 0; i < problemInput[0].Count; i++)
            {
                diffCount += Math.Abs(int.Parse(problemInput[0][i]) - int.Parse(problemInput[1][i]));
            }
            Console.WriteLine(diffCount);
        }
        else
        {
            Console.WriteLine("Empty Problem Input");
        }
    }

    public static void Solve2()
    {
        var problemInput = Helpers.FileTo2dArray(Helpers.GetProblemInputFilePath("1"),"   " , true);
        if (problemInput != null)
        {
            var similarityScore = 0;
            for (int i = 0; i < problemInput[0].Count; i++)
            {
                similarityScore += problemInput[1].Count(c => c == problemInput[0][i]) * int.Parse(problemInput[0][i]);
            }
            Console.WriteLine(similarityScore);
        }
        else
        {
            Console.WriteLine("Empty Problem Input");
        }
    }
}