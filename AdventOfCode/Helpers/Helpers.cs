namespace AdventOfCode.Helpers;

using System;
using System.IO;
using System.Linq;

public class Helpers
{
    public static List<List<string>>? FileTo2dArray(string filePath, string separator = ",", bool colsToRows = false)
    {
        var fileContent = new List<List<string>>();
        try
        {
            if (colsToRows)
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    string[]? currLine = null;
                    currLine = separator == "" ? line.Select(c => c.ToString()).ToArray() : line.Split(separator).ToArray();
                    for (int i = 0; i < currLine.Length; i++)
                    {
                        if (i >= fileContent.Count)
                        {
                            fileContent.Add(new List<string>());
                        }
                        fileContent[i].Add(currLine[i]);
                    }
                }
            }
            else
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    fileContent.Add(separator == "" ? line.Select(c => c.ToString()).ToList() : line.Split(separator).ToList());
                }
            }
            return fileContent;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public static string GetProjectFilePath()
    {
       return AppDomain.CurrentDomain.BaseDirectory + @"../../../";
    }

    public static string GetProblemInputFilePath(string problemNum = "1")
    {
        return GetProjectFilePath() + "Problems/Problem" + problemNum + "/Problem" + problemNum + ".txt";
    }
}