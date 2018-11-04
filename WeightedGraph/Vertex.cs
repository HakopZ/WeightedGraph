using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedGraph
{
    class Vertex<T> where T : IComparable
    {
        public T Value { get; set; }
        public List<Edge<T>> edges = new List<Edge<T>>();
        public bool Visited { get; set; }
        public Vertex(T value, bool visited = false)
        {
            Value = value;
            Visited = visited;
        }
    }
}
