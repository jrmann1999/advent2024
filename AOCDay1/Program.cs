// See https://aka.ms/new-console-template for more information

using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.IO;
using System.Runtime.InteropServices.Swift;
using System.Security.Cryptography.X509Certificates;
using System.Text;

class AOCDay1
{
    List<int> left;
    List<int> right;
    string path = "C:\\Users\\jerem\\OneDrive\\Documents\\Advent2024\\advent2024\\AOCDay1\\input.txt";

    public AOCDay1()
    {
        left = new List<int>();
        right = new List<int>();
    }
    
    public void BuildList()
    {
        var lines = File.ReadLines(path);

        foreach (var line in lines)
        {
            left.Add(int.Parse(line.Split(null)[0]));
            right.Add(int.Parse(line.Split(null)[3]));
        }
    }
    public void Part1()
    {
        int[] leftA = left.ToArray();
        int[] rightA = right.ToArray();

        Array.Sort(leftA);
        Array.Sort(rightA);

        int TotalLen = 0;
        for (int i = 0; i < leftA.Length; i++)
        {
            TotalLen += int.Abs(leftA[i] - rightA[i]);
        }
        Console.WriteLine("Part1: " + TotalLen);
    }

    public void Part2()
    {
        int[] leftA = left.ToArray();
        int[] rightA = right.ToArray();
        int Total = 0;
        foreach (var leftB in leftA)
        { 
            Total +=  leftB * (rightA.Count(x => x == leftB));
        }
        Console.WriteLine("Part2: " + Total);
    }

    public static void Main()
    {
        var a = new AOCDay1();
        a.BuildList();
        a.Part1();
        a.Part2();
    }


}
