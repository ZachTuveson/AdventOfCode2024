namespace AdventOfCode.Problems.Problem4;

using System;
using System.IO;
using AdventOfCode.Helpers;

class Problem4
{
    private static readonly string[] SearchTerm = ["M", "A", "S"];
    public static void Solve()
    {
        var problemInput = Helpers.FileTo2dArray(Helpers.GetProblemInputFilePath("4"),"");
        
        if (problemInput != null)
        {
            var numMatches = 0;
            for (var i = 0; i < problemInput.Count; i++)
            {
                for (var j = 0; j < problemInput[i].Count; j++)
                {
                    if (problemInput[i][j] == SearchTerm[0])
                    {
                        numMatches += NumMatchesAtIdx(i, j, problemInput);
                    }
                }
            }
            Console.WriteLine(numMatches);
        }
        else
        {
            Console.WriteLine("Empty Problem Input");
        }
    }

    public static void Solve2()
    {
        var problemInput = Helpers.FileTo2dArray(Helpers.GetProblemInputFilePath("4"),"");
        
        if (problemInput != null)
        {
            var numMatches = 0;
            for (var i = 0; i < problemInput.Count; i++)
            {
                for (var j = 0; j < problemInput[i].Count; j++)
                {
                    if ((problemInput[i][j] == SearchTerm[0] || problemInput[i][j] == SearchTerm[^1]) && MatchAtIdx(i, j, problemInput))
                    {
                        Console.WriteLine("Match found at: " + i + ", " + j);
                        numMatches++;
                    }
                }
            }
            Console.WriteLine(numMatches);
        }
        else
        {
            Console.WriteLine("Empty Problem Input");
        }
    }

    private static bool MatchAtIdx(int i, int j, List<List<string>> problemInput)
    {
        var hasRdMatch = false;
        var hasLdMatch = false;
        var matchIdx = 0;

        //search right diagonal 
        while (i + matchIdx < problemInput.Count && j + matchIdx < problemInput[i + matchIdx].Count && matchIdx < SearchTerm.Length && SearchTerm[matchIdx] == problemInput[i + matchIdx][j + matchIdx])
        {
            matchIdx++;
        }
        if (matchIdx == SearchTerm.Length)
        {
            hasRdMatch = true;
        }
        
        //search right diagonal reverse
        matchIdx = 0;
        while (i + matchIdx < problemInput.Count && j + matchIdx < problemInput[i + matchIdx].Count && matchIdx < SearchTerm.Length && SearchTerm[^(matchIdx+1)] == problemInput[i + matchIdx][j + matchIdx])
        {
            matchIdx++;
        }
        if (matchIdx == SearchTerm.Length)
        {
            hasRdMatch = true;
        }
        
        //move j to left diagonal and check if it's out of bounds
        j += 2;
        if (j >= problemInput[i].Count)
        {
            return false;
        }
        
        //search left diagonal
        matchIdx = 0;
        while (i + matchIdx < problemInput.Count && j - matchIdx >= 0 && matchIdx < SearchTerm.Length && SearchTerm[matchIdx] == problemInput[i + matchIdx][j - matchIdx])
        {
            matchIdx++;
        }
        if (matchIdx == SearchTerm.Length)
        {
            hasLdMatch = true;
        }
        
        //search left diagonal reverse
        matchIdx = 0;
        while (i + matchIdx < problemInput.Count && j - matchIdx >= 0 && matchIdx < SearchTerm.Length && SearchTerm[^(matchIdx+1)] == problemInput[i + matchIdx][j - matchIdx])
        {
            matchIdx++;
        }
        if (matchIdx == SearchTerm.Length)
        {
            hasLdMatch = true;
        }
        return (hasRdMatch && hasLdMatch);
    }
    
    private static int NumMatchesAtIdx(int i, int j, List<List<string>> problemInput)
    {
        var numMatches = 0;
        var matchIdx = 0;
        
        //forwards
        while (j + matchIdx < problemInput[i].Count && matchIdx < SearchTerm.Length && SearchTerm[matchIdx] == problemInput[i][j + matchIdx])
        {
            matchIdx++;
        }
        if (matchIdx == SearchTerm.Length)
        {
            Console.WriteLine("Forwards match found at:" + i + "," + j);
            numMatches++;
        }
        
        //backwards
        matchIdx = 0;
        while (j - matchIdx >= 0 && matchIdx < SearchTerm.Length && SearchTerm[matchIdx] == problemInput[i][j - matchIdx])
        {
            matchIdx++;
        }
        if (matchIdx == SearchTerm.Length)
        {
            Console.WriteLine("Backwards match found at:" + i + "," + j);
            numMatches++;
        }

        //down
        matchIdx = 0;
        while (i + matchIdx < problemInput.Count && matchIdx < SearchTerm.Length && SearchTerm[matchIdx] == problemInput[i + matchIdx][j])
        {
            matchIdx++;
        }
        if (matchIdx == SearchTerm.Length)
        {
            Console.WriteLine("Down match found at:" + i + "," + j);
            numMatches++;
        }

        //up
        matchIdx = 0;
        while (i - matchIdx >= 0 && matchIdx < SearchTerm.Length && SearchTerm[matchIdx] == problemInput[i - matchIdx][j])
        {
            matchIdx++;
        }
        if (matchIdx == SearchTerm.Length)
        {
            Console.WriteLine("Up match found at:" + i + "," + j);
            numMatches++;
        }

        //up/left diagonal
        matchIdx = 0;
        while(i - matchIdx >= 0 && j - matchIdx >= 0 && matchIdx < SearchTerm.Length && SearchTerm[matchIdx] == problemInput[i - matchIdx][j - matchIdx])
        {
            matchIdx++;
        }
        if (matchIdx == SearchTerm.Length)
        {
            Console.WriteLine("Up/left diagonal match found at:" + i + "," + j);
            numMatches++;
        }

        //up/right diagonal
        matchIdx = 0;
        while(i - matchIdx >= 0 && j + matchIdx < problemInput.Count && matchIdx < SearchTerm.Length && SearchTerm[matchIdx] == problemInput[i - matchIdx][j + matchIdx])
        {
            matchIdx++;
        }
        if (matchIdx == SearchTerm.Length)
        {
            Console.WriteLine("Up/right diagonal match found at:" + i + "," + j);
            numMatches++;
        }
        
        //bottom/left diagonal
        matchIdx = 0;
        while(i + matchIdx < problemInput.Count && j - matchIdx >= 0 && matchIdx < SearchTerm.Length && SearchTerm[matchIdx] == problemInput[i + matchIdx][j - matchIdx])
        {
            matchIdx++;
        }
        if (matchIdx == SearchTerm.Length)
        {
            Console.WriteLine("Bottom/left diagonal match found at:" + i + "," + j);
            numMatches++;
        }

        //bottom/right diagonal
        matchIdx = 0;
        while(i + matchIdx < problemInput.Count && j + matchIdx < problemInput[i + matchIdx].Count && matchIdx < SearchTerm.Length && SearchTerm[matchIdx] == problemInput[i + matchIdx][j + matchIdx])
        {
            matchIdx++;
        }
        if (matchIdx == SearchTerm.Length)
        {
            Console.WriteLine("Bottom/right diagonal match found at:" + i + "," + j);
            numMatches++;
        }

        return numMatches;
    }
}