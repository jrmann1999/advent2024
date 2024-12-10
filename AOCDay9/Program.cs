using System.Runtime.InteropServices;

class AOCDay9
{
    public string puzzle;
    private string FileName;
    public List<int> FileSystem;
    public AOCDay9()
    {
        puzzle = "";
        FileSystem = [];
        FileName = @"C:\Users\jerem\OneDrive\Documents\Advent2024\advent2024\AOCDay9\input.txt";
    }
    public AOCDay9(string path)
    {
        puzzle = "";
        FileSystem = [];
        FileName = path;
    }

    public void LoadData()
    {
        puzzle = File.ReadAllText(FileName);
    }

    public void Parse()
    {
        int i = 0;
        int FileCount = 0;
        Console.WriteLine("Puzzle Length: {0}", puzzle.TrimEnd().Length);
        foreach (char c in puzzle.TrimEnd())
        {
            if (i % 2 == 0)
            {
                // Even, we are reading File Blocks
                for (int j = 0; j < int.Parse(c.ToString()); j++)
                {
                    FileSystem.Add(FileCount);
                }
                FileCount++;
            }
            else
            {
                for (int j = 0; j < int.Parse(c.ToString()); j++)
                {
                    FileSystem.Add(-1);
                }
            }
            i++;
        }
    }
    private void DeFrag()
    {
        int end = FileSystem.Count - 1;
        int counter = 0;
        int[] NewFilesystem = FileSystem.ToArray();
        while (counter < NewFilesystem.Length - 1)
        {
            int ent = NewFilesystem[counter];
            if (ent == -1)
            {
                while (NewFilesystem[end] == -1)
                {
                    if (counter < end)
                    {
                        end--;
                    }
                    else
                    {
                        break;
                    }
                }
                (NewFilesystem[counter], NewFilesystem[end]) = (NewFilesystem[end], NewFilesystem[counter]);
            }
            counter++;
            end = FileSystem.Count - 1;
        }
        FileSystem = NewFilesystem.ToList();
    }
    private Int64 CalcCheckSum()
    {
        int counter = 0;
        Int64 Total = 0;
        foreach (int entry in FileSystem)
        {
            if (entry != -1)
            {
                Total += counter++ * entry;
                if (Total < 0)
                {
                    Console.WriteLine("Total: {0}, Counter: {1}", Total, counter - 1);
                    return 0;
                }
            }
        }
        return Total;
    }
    public Int64 Part1()
    {
        DeFrag();
        return CalcCheckSum();
    }

    public static void Main()
    {
        var AOC = new AOCDay9();
        AOC.LoadData();
        AOC.Parse();
        Int64 P1 = AOC.Part1();
        Console.WriteLine("Part1: {0}", P1);
    }
}
