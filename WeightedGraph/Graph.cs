using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedGraph
{
    class Graph<T> where T : IComparable
    {
        List<Vertex<T>> vertices = new List<Vertex<T>>();
        public Graph(){}
        public void AddVertex(T x)
        {
            AddVertex(new Vertex<T>(x));
            
        }
        public void AddVertex(Vertex<T> x)
        {
            vertices.Add(x);
        }
        public bool RemoveVertex(T x)
        {
            return RemoveVertex(GetVertex(x));
        }
        public bool RemoveVertex(Vertex<T> x)
        {
            return vertices.Remove(x);
        }
        public void AddEdge(T x, T z, int distance = 0)
        {
            AddEdge(GetVertex(x), GetVertex(z), distance);
        }
        public void AddEdge(Vertex<T> x, Vertex<T> z, int distance = 0)
        {
            Edge<T> newEdgeX = new Edge<T>(x, z, distance);
            Edge<T> newEdgeZ = new Edge<T>(z, x, distance);
            bool foundZ = false;
            bool foundX = false;
            foreach(var item in x.edges)
            {
                if(item.Equals(z))
                {
                    foundZ = true;
                }
            }
            foreach (var item in z.edges)
            {
                if(item.Equals(x))
                {
                    foundX = true;
                }
            }
            if(!foundX)
            {
                x.edges.Add(newEdgeX);
            }
            if(!foundZ)
            {
                z.edges.Add(newEdgeZ);
            }
        }
        public bool RemoveEdge(T start, T end)
        {
            return RemoveEdge(GetVertex(start), GetVertex(end));
        }
        public bool RemoveEdge(Vertex<T> start, Vertex<T> end)
        {
            bool DeletedStart = false;
            bool DeletedEnd = false;
            foreach(var item in start.edges)
            {
                if(item.Equals(end))
                {
                    start.edges.Remove(item);
                    DeletedEnd = true;
                }
            }
            foreach (var item in end.edges)
            {
                if(item.Equals(start))
                {
                    end.edges.Remove(item);
                    DeletedStart = true;
                }
            }
            if(DeletedEnd || DeletedStart)
            {
                return true;
            }
            return false;
        }
        public Vertex<T> GetVertex(T val)
        {
            foreach (var item in vertices)
            {
                if(item.Value.Equals(val))
                {
                    return item;
                }
            }
            return null;
        }
        public void DepthFirstTransversal(T start, T end)
        {
            DepthFirstTransversal(start, end);
        }
        public IEnumerable<Vertex<T>> DepthFirstTransversal(Vertex<T> start, Vertex<T> end)
        {
            HashSet<Vertex<T>> VisistedNodes = new HashSet<Vertex<T>>();
            //create a structure to hold visited nodes (suggest HashSet)
            DFS(start);
            Console.Write(VisistedNodes.GetEnumerator());
            return VisistedNodes; //return the colletion we generated in the internal functions

            void DFS(Vertex<T> curr)
            {
                if (curr == end || curr.edges.Count == 0)
                {
                    return;
                }

                int cheap = 0;
                for (int i = 0; i < curr.edges.Count; i++)
                {
                    if(curr.edges[i].Distance < curr.edges[cheap].Distance && VisistedNodes.Contains(curr.edges[i].EndingVertex))
                    {
                        cheap = i;
                    }
                }
                VisistedNodes.Add(curr.edges[cheap].StartingVertex);
                DFS(curr.edges[cheap].EndingVertex);
                //add this to a collection
            }
    
        }
    }
}
