using System.Reflection.Metadata;

class AOCDay6
{
    private char[,] puzzle;
    private string FileName;

    public AOCDay6()
    {
        puzzle = new char[0,0];
        FileName = @"input.txt";
    }
    public AOCDay6(string path)
    {
        puzzle = new char[0,0];
        FileName = path;
    }
    public void LoadData()
    {
        var Data = File.ReadAllLines(FileName);
        var PuzzRows = Data.Length;
        var PuzzCols = Data[0].Length;
        puzzle = new char[PuzzRows,PuzzCols];
        var row = 0;
        foreach (var line in Data)
        {
            var col = 0;
            foreach (var c in line)
            {
                puzzle[row,col] = c;
                col++;
            }
            row++;
        }
    }
    public static void Main()
    {
        AOCDay6 aoc = new(@"C:\Users\jerem\Documents\advent2024\AOCDay6\inputsmall.txt");
        aoc.LoadData();
    }
}