using System;
using System.Numerics;
using System.Text.RegularExpressions;
class AOCDay3
{
    // a regular expression pattern for a five-letter word
    // that starts with "a" and ends with "e"  
    static string pattern = @"mul\((?<a>\d+),(?<b>\d+)\)|do\(\)|don\'t\(\)";
    string path = "C:\\Users\\jerem\\OneDrive\\Documents\\Advent2024\\advent2024\\AOCDay3\\input.txt";
    string puzzle;

    public AOCDay3()
    {
    }
    public void LoadData()
    {
        var line = File.ReadAllText(path);
        puzzle = line;
    }

    public void Part1()
    {
        int Total = 0;
        try
        {
            foreach (Match match in Regex.Matches(puzzle, pattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                int Num1 = int.Parse(match.Groups["a"].Value);
                int Num2 = int.Parse(match.Groups["b"].Value);
                Total += Num1 * Num2;
                Console.WriteLine("Total: {0}", Total);
            }
            Console.WriteLine("Total: {0}", Total);
        }
        catch (RegexMatchTimeoutException) { }
    }

    public void Part2()
    {
        int Total = 0;
        bool doIt = true;
        try
        {
            foreach (Match match in Regex.Matches(puzzle, pattern, RegexOptions.IgnoreCase))
            {
                switch (match.Value)
                {
                    case (@"do()"):
                        doIt = true;
                        break;
                    case (@"don't()"):
                        doIt = false;
                        break;
                    default:
                        if (doIt)
                        {
                            int Num1 = int.Parse(match.Groups["a"].Value);
                            int Num2 = int.Parse(match.Groups["b"].Value);
                            Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                            Total += Num1 * Num2;
                            Console.WriteLine("Total: {0}", Total);
                        }
                        break;
                }
            }
            Console.WriteLine("Total: {0}", Total);
        }
        catch (RegexMatchTimeoutException) { }
    }

    static void Main()
    {
        // create an instance of Regex class and
        //  pass the regular expression (i.e pattern)
        var AOC = new AOCDay3();
        AOC.LoadData();
        AOC.Part1();
        AOC.Part2();
    }
}