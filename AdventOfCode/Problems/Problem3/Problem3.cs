namespace AdventOfCode.Problems.Problem3;

using System;
using System.IO;
using AdventOfCode.Helpers;
using System.Text.RegularExpressions;


class Problem3
{
    public static void Solve()
    {
        var problemInput = File.ReadAllText(Helpers.GetProblemInputFilePath("3"));
        
        if (problemInput != "")
        {
            var muls = Regex.Matches(problemInput, @"mul\(\d{1,3}\,\d{1,3}\)").ToArray();
            var mulTotal = 0;
            foreach (var mul in muls)
            {
                var mulNums = Regex.Matches(mul.Value, @"\d{1,3}");
                mulTotal += int.Parse(mulNums[0].Value) * int.Parse(mulNums[1].Value);
            }
            Console.WriteLine(mulTotal);
        }
        else
        {
            Console.WriteLine("Empty Problem Input");
        }
    }

    public static void Solve2()
    {
        var problemInput = File.ReadAllText(Helpers.GetProblemInputFilePath("3"));
        
        if (problemInput != "")
        {
            var donts = problemInput.Split("don't()");
            var mulTotal = 0;

            for (int i = 0; i < donts.Length; i++)
            {
                var doString = "";
                if(i == 0 )
                {
                    doString = donts[0];
                }
                else
                {
                    var doStrings = donts[i].Split("do()", 2);
                    doString = doStrings.Length > 1 ? doStrings[1] : "";
                }

                var muls = Regex.Matches(doString, @"mul\(\d{1,3}\,\d{1,3}\)").ToArray();
                foreach (var mul in muls)
                {
                    var mulNums = Regex.Matches(mul.Value, @"\d{1,3}");
                    mulTotal += int.Parse(mulNums[0].Value) * int.Parse(mulNums[1].Value);
                }
            }
            

            Console.WriteLine(mulTotal);
        }
        else
        {
            Console.WriteLine("Empty Problem Input");
        }
    }
}