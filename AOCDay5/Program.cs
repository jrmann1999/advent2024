using System.Runtime.InteropServices;

class AOCDay5
{
    private Dictionary<string, int[]> Map;
    private static readonly string path = @"C:\Users\jerem\OneDrive\Documents\Advent2024\advent2024\AOCDay5\inputsmall.txt";
    private string[] Data;
    public void LoadData()
    {
        Data = File.ReadAllLines(path);
        bool isPuzzle = false;
        int i = 0;
        foreach (string line in Data)
        {
            if('\n'.Equals(line))
            {
                // Map is done, start filling the puzzle entity
                isPuzzle = true;
            }
            if(!isPuzzle)
            {

            }
            else
            {
                // Build Map
                string k;
                int v;
                k = line.TrimEnd().Split('|')[0];
                v = int.Parse(line.TrimEnd().Split('|')[1]);

                if (Map.Keys.Contains(k))
                {
                    Map[k].Append(v);
                }
                else
                {
                    Map.Add(k, [v]);
                }
            }
        }
    }
    static void Main()
    {

    }
}
