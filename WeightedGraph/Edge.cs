using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedGraph
{
    class Edge<T> where T : IComparable
    {
        public Vertex<T> StartingVertex { get; set; }
        public Vertex<T> EndingVertex { get; set; }
        public int Distance { get; set; }
        public bool IsVisited { get; set; }

        public Edge(Vertex<T> startingvertex, Vertex<T> endVertex, int distance, bool visited = false)
        {
            StartingVertex = startingvertex;
            EndingVertex = endVertex;
            Distance = distance;
            IsVisited = visited;
        }
    }
}
