using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;

class AOCDay2
{
    List<string> puzzle;
    string path = "C:\\Users\\jerem\\OneDrive\\Documents\\Advent2024\\advent2024\\AOCDay2\\input.txt";

    public AOCDay2()
    {
        puzzle = new List<string>();
    }
    public void LoadData()
    {
        var lines = File.ReadLines(path);
        foreach (var line in lines)
        {
            puzzle.Add(line);
        }
    }

    public int Parse(string[] s)
    {
        string direction = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (i == (s.Length - 1))
            {
                break;
            }
            int comp = int.Parse(s[i]) - int.Parse(s[i + 1]);
            if (i == 0)
            {

                if (comp == 0)
                {
                    return i;
                }
                else if (comp > 0)
                {
                    direction = "more";
                }
                else
                {
                    direction = "less";
                }
            }
            if (int.Abs(comp) < 1 | int.Abs(comp) > 3)
            {
                return i;
            }
            if (direction == "less")
            {
                if (comp > 0)
                {
                    return i;
                }
            }
            else
            {
                if (comp < 0)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    public int Parse2(string[] s)
    {
        int res = Parse(s);
        string[] news;
        if (res == -1)
        {
            return -1;
        }
        else
        {
            Console.WriteLine("Res: {0}", res);
            if (Parse(s[1..]) == -1) { return -1; }
            if (Parse(s[..^1]) == -1) { return -1; }

            string[] s1 = s[..res];
            string[] s2 = s[(res + 1)..];
            news = s1.Concat(s2).ToArray();
        }
        if (Parse(news) == -1) 
        { 
            return -1;
        }
        else
        {
            return res;
        }
    }

public void Part1()
{
    int Total = 0;
    foreach (var s in puzzle)
    {
        string[] sAry = s.Split();
        int res = Parse(sAry);
        Total += (res == -1 ? 1 : 0);
        if (res == -1)
        {
            Console.WriteLine("Valid: {0}", String.Join(' ', sAry));
        }
        else
        {
            Console.WriteLine("InValid: {0} on {1}", String.Join(' ', sAry), res);
        }
    }
    Console.WriteLine("Part1: " + Total);
}

public void Part2()
{
    int Total = 0;
    foreach (var s in puzzle)
    {
        string[] sAry = s.Split();
        int res = Parse2(sAry);
        Total += (res == -1 ? 1 : 0);
        if (res == -1)
        {
            //Console.WriteLine("Valid: {0}", String.Join(' ', sAry));
        }
        else
        {
            Console.WriteLine("InValid: {0} on {1}", String.Join(' ', sAry), res);
        }
    }
    Console.WriteLine("Part2: " + Total);
}

public static void Main()
{
    var AOC = new AOCDay2();
    AOC.LoadData();
    AOC.Part1();
    AOC.Part2();
}
}