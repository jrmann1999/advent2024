
class AOCDay10
{
    public string[] puzzle;
    private string FileName;
    public AOCDay10()
    {
        puzzle = [];
        FileName = @"C:\Users\jerem\OneDrive\Documents\Advent2024\advent2024\AOCDay10\input.txt";
    }
    public AOCDay10(string path)
    {
        puzzle = [];
        FileName = path;
    }

    public void LoadData()
    {
        puzzle = File.ReadAllLines(FileName);
    }

    public int Part1()
    {
        Queue<List<int>> queue = [];
        int ends = 0;

        for (int y = 0; y < puzzle.Length; y++)
        {
            for (int x = 0; x < puzzle[0].Length; x++)
            {
                if (puzzle[y][x] == '0')
                {
                    List<int> start = [0, x, y];
                    queue.Enqueue(start);

                    List<(int, int)> endPoints = [];

                    while (queue.TryDequeue(out List<int> item))
                    {
                        var num = item[0];
                        var (a, b) = (item[1], item[2]);

                        if (num == 9)
                        {
                            endPoints.Add((a, b));
                            continue;
                        }
                        //Check N
                        if (b - 1 >= 0)
                        {
                            if (puzzle[b - 1][a] == num + 1 + '0')
                            {
                                queue.Enqueue([num + 1, a, b - 1]);
                            }
                        }
                        //Check E
                        if (a + 1 < puzzle[0].Length)
                        {
                            if (puzzle[b][a + 1] == num + 1 + '0')
                            {
                                queue.Enqueue([num + 1, a + 1, b]);
                            }
                        }
                        //Check S
                        if (b + 1 < puzzle.Length)
                        {
                            if (puzzle[b + 1][a] == num + 1 + '0')
                            {
                                queue.Enqueue([num + 1, a, b + 1]);
                            }
                        }
                        //Check W
                        if (a - 1 >= 0)
                        {
                            if (puzzle[b][a - 1] == num + 1 + '0')
                            {
                                queue.Enqueue([num + 1, a - 1, b]);
                            }
                        }
                    }
                    ends += endPoints.Distinct().Count();
                }
            }
        }
        return ends;
    }
    public int Part2()
    {
        Queue<List<int>> queue = [];
        int ends = 0;

        for (int y = 0; y < puzzle.Length; y++)
        {
            for (int x = 0; x < puzzle[0].Length; x++)
            {
                if (puzzle[y][x] == '0')
                {
                    List<int> start = [0, x, y];
                    queue.Enqueue(start);

                    List<(int, int)> endPoints = [];

                    while (queue.TryDequeue(out List<int> item))
                    {
                        var num = item[0];
                        var (a, b) = (item[1], item[2]);

                        if (num == 9)
                        {
                            endPoints.Add((a, b));
                            continue;
                        }
                        //Check N
                        if (b - 1 >= 0)
                        {
                            if (puzzle[b - 1][a] == num + 1 + '0')
                            {
                                queue.Enqueue([num + 1, a, b - 1]);
                            }
                        }
                        //Check E
                        if (a + 1 < puzzle[0].Length)
                        {
                            if (puzzle[b][a + 1] == num + 1 + '0')
                            {
                                queue.Enqueue([num + 1, a + 1, b]);
                            }
                        }
                        //Check S
                        if (b + 1 < puzzle.Length)
                        {
                            if (puzzle[b + 1][a] == num + 1 + '0')
                            {
                                queue.Enqueue([num + 1, a, b + 1]);
                            }
                        }
                        //Check W
                        if (a - 1 >= 0)
                        {
                            if (puzzle[b][a - 1] == num + 1 + '0')
                            {
                                queue.Enqueue([num + 1, a - 1, b]);
                            }
                        }
                    }
                    ends += endPoints.Count();
                }
            }
        }
        return ends;
    }

    public static void Main()
    {
        var aoc = new AOCDay10();
        aoc.LoadData();
        Console.WriteLine(aoc.Part1());
        Console.WriteLine(aoc.Part2());
    }

}