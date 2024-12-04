// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Data;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

class AOCDay4
{
    private static readonly string path = @"C:\Users\jerem\OneDrive\Documents\Advent2024\advent2024\AOCDay4\input.txt";
    public Dictionary<int, char[]> puzzle;

    public AOCDay4()
    {
        puzzle = [];
    }
    public void LoadData()
    {
        string line = File.ReadAllText(path);
        int i = 0;
        foreach (string l in line.Split('\n'))
        {
            puzzle.Add(i++, l.TrimEnd().ToCharArray());
        }
    }

    public int Part1()
    {
        int Total = 0;
        for (int i = 0; i < puzzle.Keys.Count; i++)
        {
            for (int j = 0; j < puzzle[i].Length; j++)
            {
                //Console.Write(j);
                if (puzzle[i][j] == 'X')
                {
                    // We are at the top, cannot check up
                    if (i < 3)
                    {
                        // We are on the left edge, cannot check left
                        if (j < 3)
                        {
                            //right
                            if (puzzle[i][j + 1] == 'M' && puzzle[i][j + 2] == 'A' && puzzle[i][j + 3] == 'S') Total += 1;
                            //rightdown
                            if (puzzle[i + 1][j + 1] == 'M' && puzzle[i + 2][j + 2] == 'A' && puzzle[i + 3][j + 3] == 'S') Total += 1;
                            //down
                            if (puzzle[i + 1][j] == 'M' && puzzle[i + 2][j] == 'A' && puzzle[i + 3][j] == 'S') Total += 1;
                        }
                        // We are in the middle, can check both right and left
                        else if (j < puzzle[i].Length - 3)
                        {
                            //right
                            if (puzzle[i][j + 1] == 'M' && puzzle[i][j + 2] == 'A' && puzzle[i][j + 3] == 'S') Total += 1;
                            //rightdown
                            if (puzzle[i + 1][j + 1] == 'M' && puzzle[i + 2][j + 2] == 'A' && puzzle[i + 3][j + 3] == 'S') Total += 1;
                            //down
                            if (puzzle[i + 1][j] == 'M' && puzzle[i + 2][j] == 'A' && puzzle[i + 3][j] == 'S') Total += 1;
                            //leftdown
                            if (puzzle[i + 1][j - 1] == 'M' && puzzle[i + 2][j - 2] == 'A' && puzzle[i + 3][j - 3] == 'S') Total += 1;
                            //left
                            if (puzzle[i][j - 1] == 'M' && puzzle[i][j - 2] == 'A' && puzzle[i][j - 3] == 'S') Total += 1;
                        }
                        // We are on the right edge, cannot check right
                        else
                        {
                            //left
                            if (puzzle[i][j - 1] == 'M' && puzzle[i][j - 2] == 'A' && puzzle[i][j - 3] == 'S') Total += 1;
                            //leftdown
                            if (puzzle[i + 1][j - 1] == 'M' && puzzle[i + 2][j - 2] == 'A' && puzzle[i + 3][j - 3] == 'S') Total += 1;
                            //down
                            if (puzzle[i + 1][j] == 'M' && puzzle[i + 2][j] == 'A' && puzzle[i + 3][j] == 'S') Total += 1;
                        }
                    }
                    // We are in the middle, can check both up and down
                    else if (i < puzzle.Keys.Count - 3)
                    {
                        // We are within the left three columns, can only check right, up, and down
                        if (j < 3)
                        {
                            //right
                            if (puzzle[i][j + 1] == 'M' && puzzle[i][j + 2] == 'A' && puzzle[i][j + 3] == 'S') Total += 1;
                            //rightdown
                            if (puzzle[i + 1][j + 1] == 'M' && puzzle[i + 2][j + 2] == 'A' && puzzle[i + 3][j + 3] == 'S') Total += 1;
                            //down
                            if (puzzle[i + 1][j] == 'M' && puzzle[i + 2][j] == 'A' && puzzle[i + 3][j] == 'S') Total += 1;
                            //up
                            if (puzzle[i - 1][j] == 'M' && puzzle[i - 2][j] == 'A' && puzzle[i - 3][j] == 'S') Total += 1;
                            //rightup
                            if (puzzle[i - 1][j + 1] == 'M' && puzzle[i - 2][j + 2] == 'A' && puzzle[i - 3][j + 3] == 'S') Total += 1;
                        }
                        // We can check every direction
                        else if (j < puzzle[i].Length - 3)
                        {
                            //right
                            if (puzzle[i][j + 1] == 'M' && puzzle[i][j + 2] == 'A' && puzzle[i][j + 3] == 'S') Total += 1;
                            //rightdown
                            if (puzzle[i + 1][j + 1] == 'M' && puzzle[i + 2][j + 2] == 'A' && puzzle[i + 3][j + 3] == 'S') Total += 1;
                            //down
                            if (puzzle[i + 1][j] == 'M' && puzzle[i + 2][j] == 'A' && puzzle[i + 3][j] == 'S') Total += 1;
                            //leftdown
                            if (puzzle[i + 1][j - 1] == 'M' && puzzle[i + 2][j - 2] == 'A' && puzzle[i + 3][j - 3] == 'S') Total += 1;
                            //left
                            if (puzzle[i][j - 1] == 'M' && puzzle[i][j - 2] == 'A' && puzzle[i][j - 3] == 'S') Total += 1;
                            //leftup
                            if (puzzle[i - 1][j - 1] == 'M' && puzzle[i - 2][j - 2] == 'A' && puzzle[i - 3][j - 3] == 'S') Total += 1;
                            //up
                            if (puzzle[i - 1][j] == 'M' && puzzle[i - 2][j] == 'A' && puzzle[i - 3][j] == 'S') Total += 1;
                            //rightup
                            if (puzzle[i - 1][j + 1] == 'M' && puzzle[i - 2][j + 2] == 'A' && puzzle[i - 3][j + 3] == 'S') Total += 1;
                        }
                        // On Right side of puzzle, cannot check right
                        else
                        {
                            //up
                            if (puzzle[i - 1][j] == 'M' && puzzle[i - 2][j] == 'A' && puzzle[i - 3][j] == 'S') Total += 1;
                            //leftup
                            if (puzzle[i - 1][j - 1] == 'M' && puzzle[i - 2][j - 2] == 'A' && puzzle[i - 3][j - 3] == 'S') Total += 1;
                            //left
                            if (puzzle[i][j - 1] == 'M' && puzzle[i][j - 2] == 'A' && puzzle[i][j - 3] == 'S') Total += 1;
                            //leftdown
                            if (puzzle[i + 1][j - 1] == 'M' && puzzle[i + 2][j - 2] == 'A' && puzzle[i + 3][j - 3] == 'S') Total += 1;
                            //down
                            if (puzzle[i + 1][j] == 'M' && puzzle[i + 2][j] == 'A' && puzzle[i + 3][j] == 'S') Total += 1;
                        }
                    }
                    // We are at the bottom 3 rows, cannot check down 
                    else
                    {
                        // We are within the left three columns, cannot go left
                        if (j < 3)
                        {
                            //right
                            if (puzzle[i][j + 1] == 'M' && puzzle[i][j + 2] == 'A' && puzzle[i][j + 3] == 'S') Total += 1;
                            //rightup
                            if (puzzle[i - 1][j + 1] == 'M' && puzzle[i - 2][j + 2] == 'A' && puzzle[i - 3][j + 3] == 'S') Total += 1;
                            //up
                            if (puzzle[i - 1][j] == 'M' && puzzle[i - 2][j] == 'A' && puzzle[i - 3][j] == 'S') Total += 1;
                        }
                        // We can right, up, and left
                        else if (j < puzzle[i].Length - 3)
                        {
                            //right
                            if (puzzle[i][j + 1] == 'M' && puzzle[i][j + 2] == 'A' && puzzle[i][j + 3] == 'S') Total += 1;
                            //rightup
                            if (puzzle[i - 1][j + 1] == 'M' && puzzle[i - 2][j + 2] == 'A' && puzzle[i - 3][j + 3] == 'S') Total += 1;
                            //up
                            if (puzzle[i - 1][j] == 'M' && puzzle[i - 2][j] == 'A' && puzzle[i - 3][j] == 'S') Total += 1;
                            //leftup
                            if (puzzle[i - 1][j - 1] == 'M' && puzzle[i - 2][j - 2] == 'A' && puzzle[i - 3][j - 3] == 'S') Total += 1;
                            //left
                            if (puzzle[i][j - 1] == 'M' && puzzle[i][j - 2] == 'A' && puzzle[i][j - 3] == 'S') Total += 1;
                        }
                        // On Right side of puzzle, can only check left and up
                        else
                        {
                            //up
                            if (puzzle[i - 1][j] == 'M' && puzzle[i - 2][j] == 'A' && puzzle[i - 3][j] == 'S') Total += 1;
                            //leftup
                            if (puzzle[i - 1][j - 1] == 'M' && puzzle[i - 2][j - 2] == 'A' && puzzle[i - 3][j - 3] == 'S') Total += 1;
                            //left
                            if (puzzle[i][j - 1] == 'M' && puzzle[i][j - 2] == 'A' && puzzle[i][j - 3] == 'S') Total += 1;
                        }
                    }
                }
            }
        }
        return Total;
    }
    public int Part2()
    {
        int Total = 0;
        for (int i = 0; i < puzzle.Keys.Count; i++)
        {
            for (int j = 0; j < puzzle[i].Length; j++)
            {
                //Console.Write(j);
                if (puzzle[i][j] == 'A')
                {
                    // Check diagonals, ignore if we are in top and bottom rows, left and right columns 
                    if (j >= 1 && i >= 1 && j < puzzle[i].Length - 1 && i < puzzle.Keys.Count - 1)
                    {
                        //Check Diags
                        //M.S
                        //.A.
                        //M.S

                        //S.M
                        //.A.
                        //S.M
                        
                        //S.S
                        //.A.
                        //M.M
                        
                        //M.M
                        //.A.
                        //S.S
                        char topright = puzzle[i-1][j+1];
                        char topleft = puzzle[i-1][j-1];
                        char bottomright = puzzle[i+1][j+1];
                        char bottomleft = puzzle[i+1][j-1];

                        if (topleft == 'M' && bottomleft == 'M' && topright=='S' && bottomright == 'S') Total += 1;
                        if (topleft == 'S' && bottomleft == 'S' && topright=='M' && bottomright == 'M') Total += 1;
                        if (topleft == 'S' && bottomleft == 'M' && topright=='S' && bottomright == 'M') Total += 1;
                        if (topleft == 'M' && bottomleft == 'S' && topright=='M' && bottomright == 'S') Total += 1;

                    }
                }
            }

        }
        return Total;
    }
    public static void Main()
    {
        var AOC = new AOCDay4();
        int Total;
        AOC.LoadData();
        Total = AOC.Part1();
        Console.WriteLine(Total);
        Total = AOC.Part2();
        Console.WriteLine(Total);
    }
}