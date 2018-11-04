using System;

namespace WeightedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();
            graph.AddVertex(5);
            graph.AddVertex(7);
            graph.AddVertex(8);
            graph.AddEdge(5, 7, 0);
            graph.AddEdge(7, 8, 0);
            graph.DepthFirstTransversal(5, 8);
            Console.ReadKey();
        }
    }
}
