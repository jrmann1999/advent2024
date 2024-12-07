using System.Numerics;
using System.Reflection.Metadata;

class AOCDay6
{
    private char[,] puzzle;
    private string FileName;

    public AOCDay6()
    {
        puzzle = new char[0, 0];
        FileName = @"input.txt";
    }
    public AOCDay6(string path)
    {
        puzzle = new char[0, 0];
        FileName = path;
    }
    public void LoadData()
    {
        var Data = File.ReadAllLines(FileName);
        var PuzzRows = Data.Length;
        var PuzzCols = Data[0].Length;
        puzzle = new char[PuzzRows, PuzzCols];
        var row = 0;
        foreach (var line in Data)
        {
            var col = 0;
            foreach (var c in line.TrimEnd())
            {
                puzzle[row, col] = c;
                col++;
            }
            row++;
        }
    }

    public Tuple<int, int> FindPos(char guard)
    {
        for (var row = 0; row < puzzle.GetLength(0); row++)
        {
            for (var col = 0; col < puzzle.GetLength(1); col++)
            {
                if (puzzle[row, col] == guard)
                {
                    return Tuple.Create(row, col);
                }
            }
        }
        return Tuple.Create(-1, -1);
    }

    private void MarkPuzzle(int col, int row)
    {
        puzzle[col,row] = 'X';
    }
    private void MoveGuard(Tuple<int, int> t)
    {
        // Guard currently occupies a space, total starts at 0
        char direction = puzzle[t.Item1,t.Item2];
        Tuple<int,int> _curPos = t;
        puzzle[t.Item1,t.Item2] = 'X';
        while (true)
        {
            switch (direction)
            {
                case '^':
                    //Moving Up, loop until hit # or go out of array boundary
                    //if out of boundary, guard has exited, return total
                    for (var i = _curPos.Item1; i >= 0; i--)
                    {
                        if (i - 1 < 0)
                        {
                            // Guard is leaving
                            return;
                        }
                        else if (puzzle[i - 1, _curPos.Item2] != '#')
                        {
                            // Guard is free to move
                            MarkPuzzle(i-1, _curPos.Item2);
                        }
                        else
                        { 
                            direction = '>';
                            _curPos = Tuple.Create(i, _curPos.Item2);
                            break;
                        }
                    }
                    break;
                case '>':
                    //Moving right, loop until hit # or go past row
                    //if past row, guard will exit, return total
                    for (var i = _curPos.Item2; i <= puzzle.GetLength(1); i++)
                    {
                        if (i + 1 == puzzle.GetLength(1))
                        {
                            // Guard is leaving
                            return;
                        }
                        else if (puzzle[_curPos.Item1, i+1] != '#')
                        {
                            // Guard is free to move
                            MarkPuzzle(_curPos.Item1, i+1);
                        }
                        else
                        {
                            direction = 'V';
                            _curPos = Tuple.Create(_curPos.Item1, i);
                            break;
                        }
                    }
                    break;
                case 'V':
                    //Moving down, loop until hit # or go past end of array
                    //if past array, guard will exit, return total
                    for(var i = _curPos.Item1; i <= puzzle.GetLength(0); i++)
                    {
                        if (i + 1 == puzzle.GetLength(0))
                        {
                            // Guard is leaving
                            return;
                        }
                        else if(puzzle[i+1, _curPos.Item2] != '#')
                        {
                            // Guard is free to move
                            MarkPuzzle(i+1, _curPos.Item2);
                        }
                        else
                        {
                            direction = '<';
                            _curPos = Tuple.Create(i, _curPos.Item2);
                            break;
                        }
                    }
                    break;
                case '<':
                    //Moving Left
                    for (var i = _curPos.Item2; i >= 0; i--)
                    {
                        if(i - 1 < 0)
                        {
                            //Guard is leaving
                            return;
                        }
                        else if(puzzle[_curPos.Item1, i - 1] != '#')
                        {
                            //Guard is free to move
                            MarkPuzzle(_curPos.Item1, i-1);
                        }
                        else
                        {
                            direction = '^';
                            _curPos = Tuple.Create(_curPos.Item1, i);
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void PrintPuzzle()
    {
        for (var row = 0; row < puzzle.GetLength(0); row++)
        {
            for (var col = 0; col < puzzle.GetLength(1); col++)
            {
                Console.Write(puzzle[row,col]);
            }
            Console.WriteLine();
        }
    }

    private int CountX()
    {
        int Total = 0;
        for (var row = 0; row < puzzle.GetLength(0); row++)
        {
            for (var col = 0; col < puzzle.GetLength(1); col++)
            {
                if(puzzle[row,col] == 'X') { Total++; }
            }
        }
        return Total;
    }

    public void Part1()
    {
        // Guard starts by moving up
        Tuple<int, int> t = FindPos('^');
        MoveGuard(t);
        Console.WriteLine("Guard Moved to {0} spaces", CountX());
    }

    public static void Main()
    {
        AOCDay6 aoc = new(@"C:\Users\jerem\Documents\advent2024\AOCDay6\input.txt");
        aoc.LoadData();
        //aoc.PrintPuzzle();
        aoc.Part1();
        //aoc.PrintPuzzle();
    }
}