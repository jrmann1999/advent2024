using System.Net;
using System.Numerics;
using System.Runtime.InteropServices;

class AOCDay5
{
    private Dictionary<string, List<int>> Map;
    private static readonly string path = @"C:\Users\jerem\OneDrive\Documents\Advent2024\advent2024\AOCDay5\inputsmall.txt";
    private List<string> puzzle;
    private List<string> invalidPuzzle;
    private string[] Data;
    public AOCDay5()
    {
        Map = new Dictionary<string, List<int>>();
        puzzle = new List<string>();
        invalidPuzzle = new List<string>();
    }
    public void LoadData()
    {
        Data = File.ReadAllLines(path);
        bool isPuzzle = false;
        foreach (string line in Data)
        {
            if ('\n'.Equals(line) || "".Equals(line))
            {
                // Map is done, start filling the puzzle entity
                isPuzzle = true;
                continue;
            }
            if (!isPuzzle)
            {
                // Build Map
                string k;
                int v;
                k = line.TrimEnd().Split('|')[0];
                v = int.Parse(line.TrimEnd().Split('|')[1]);

                if (Map.Keys.Contains(k))
                {
                    Map[k].Add(v);
                }
                else
                {
                    Map.Add(k, [v]);
                }
            }
            else
            {
                //Build Puzzle
                puzzle.Add(line);
            }
        }
    }

    private bool isGood(string s)
    {
        string[] puzAry = s.Split(',');
        for (int i = 0; i < puzAry.Length; i++)
        {
            foreach (string compare in puzAry[(i + 1)..])
            {
                if (!Map.Keys.Contains(puzAry[i]) && i < puzAry.Length - 1)
                {
                    
                    invalidPuzzle.Add(s);
                    return false;
                }
                else if (!Map[puzAry[i]].Contains(int.Parse(compare)))
                {
                    invalidPuzzle.Add(s);
                    return false;
                }
            }
        }
        return true;
    }

    public int Part1()
    {
        int Total = 0;
        bool isValid = true;
        foreach (string puz in puzzle)
        { 
            if (isGood(puz))
            {
                //Console.WriteLine(puz);
                string[] puzAry = puz.Split(',');
                decimal d = puzAry.Length / 2;
                int Half = int.Parse(Math.Ceiling(d).ToString());
                Total += int.Parse(puzAry[Half]);
            }
        }
        return Total;
    }

    public int Part2()
    {
       return 0;
    }
    static void Main()
    {
        var AOC = new AOCDay5();
        AOC.LoadData();
        Console.WriteLine("Part1: {0}", AOC.Part1());
        Console.WriteLine("Part2: {0}", AOC.Part2());
    }
}
