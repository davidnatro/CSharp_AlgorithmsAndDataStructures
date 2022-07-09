namespace Graphs;

class Graphs
{
    private static void Main()
    {
        BFS bfs = new BFS();
        bfs.Fill();
        var result = bfs.Run();
        
        Console.Write("BFS: ");
        Console.WriteLine(result.flag ? $"User {result.user.Name} has the flag" : "User wasn't found!");
    }
}