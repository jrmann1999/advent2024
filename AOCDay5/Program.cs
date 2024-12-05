using System.Net;
using System.Numerics;
using System.Runtime.InteropServices;

class AOCDay5
{
    private Dictionary<string, List<int>> Map;
    private static readonly string path = @"C:\Users\jerem\OneDrive\Documents\Advent2024\advent2024\AOCDay5\input.txt";
    private List<string> puzzle;
    private List<string> invalidPuzzle;
    private string[] Data;
    public AOCDay5()
    {
        Map = [];
        puzzle = [];
        invalidPuzzle = [];
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

                if (Map.ContainsKey(k))
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
                if (!Map.ContainsKey(puzAry[i]) && i < puzAry.Length - 1)
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
        int Total = 0;
        foreach(string puz in invalidPuzzle)
        {
            List<string> newAry = [];
            string[] puzAry = puz.Split(',');
            for(int i = puzAry.Length - 1; i >= 0; i--)
            {
                if(i == puzAry.Length - 1)
                {
                    newAry.Add(puzAry[i]);
                }
                else
                {
                    List<string> prevAry = new List<string>(newAry);
                    foreach (string entry in prevAry)
                    {
                        if (Map.ContainsKey(puzAry[i]) && Map[puzAry[i]].Contains(int.Parse(entry)))
                        {
                            newAry.Insert(0, puzAry[i]);
                            break;
                        }
                    }
                    if(!newAry.Contains(puzAry[i]))
                    {
                        newAry.Add(puzAry[i]);
                    }
                }
            }
            Console.WriteLine("Puz: {0}; NewPuz: {1}", puz, String.Join(',', newAry));
            decimal d = Convert.ToDecimal(newAry.Count / 2.0);
            int Half = int.Parse(Math.Ceiling(d).ToString());
            Total += int.Parse(newAry[Half]);
        }
       return Total;
    }
    static void Main()
    {
        var AOC = new AOCDay5();
        AOC.LoadData();
        Console.WriteLine("Part1: {0}", AOC.Part1());
        Console.WriteLine("Part2: {0}", AOC.Part2());
    }
}
