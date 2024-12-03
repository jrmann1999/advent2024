using System.Runtime.CompilerServices;

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
        int diff = int.Parse(s[0]) - int.Parse(s[1]);
        string direction = "";
        if (diff == 0)
        {
            return 0;
        }
        else if (diff > 0)
        {
            direction = "more";

        }
        else
        {
            direction = "less";
        }
        for (int i = 0; i < s.Length; i++)
        {
            if (i == (s.Length - 1))
            {
                break;
            }
            var diff2 = int.Abs(int.Parse(s[i]) - int.Parse(s[i + 1]));
            if (diff2 < 1 | diff2 > 3)
            {
                return 0;
            }
            var comp = int.Parse(s[i]) - int.Parse(s[i + 1]);
            if (direction == "less")
            {
                if (comp > 0)
                {
                    return 0;
                }
            }
            else
            {
                if (comp < 0)
                {
                    return 0;
                }
            }
        }
        return 1;
    }

    public int Parse2(string[] s)
    {

        int diff = int.Parse(s[0]) - int.Parse(s[1]);
        string direction = "";
        if (diff == 0)
        {
            return 0;
        }
        else if (diff > 0)
        {
            direction = "more";

        }
        else
        {
            direction = "less";
        }
        for (int i = 0; i < s.Length; i++)
        {
            if (i == (s.Length - 1))
            {
                break;
            }
            var diff2 = int.Abs(int.Parse(s[i]) - int.Parse(s[i + 1]));
            if (diff2 < 1 | diff2 > 3)
            {
                return 0;
            }
            var comp = int.Parse(s[i]) - int.Parse(s[i + 1]);
            if (direction == "less")
            {
                if (comp > 0)
                {
                    return 0;
                }
            }
            else
            {
                if (comp < 0)
                {
                    return 0;
                }
            }
        }
        return 1;
    }

    public void Part1()
    {
        int Total = 0;
        foreach (var s in puzzle)
        {
            string[] sAry = s.Split();
            Total += Parse(sAry);
        }
        Console.WriteLine("Part1: " + Total);
    }

    public void Part2()
    {
        int Total = 0;
        foreach (var s in puzzle)
        {
            string[] sAry = s.Split();
            Total += Parse2(sAry);
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