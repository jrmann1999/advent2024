// See https://aka.ms/new-console-template for more information
class AOCDay4
{
    public static void Main()
    {
        char[,] a = new char[,] { { 'a', 'b', 'c', 'd' } , {'e', 'f', 'g', 'h'}};
        Console.WriteLine(a.GetLength(0));
        Console.WriteLine(a.GetLength(1));
    }
}