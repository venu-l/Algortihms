﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.ShortestPath;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;

namespace QuickGraphExplorations
{
    using System.IO;

    using QuickGraph.Algorithms.Observers;
    using QuickGraph.Graphviz;

    class Program
    {
        static void Main(string[] args)
        {
            PrepareMSRDataset();
        }

        /// <summary>
        /// http://graphs.grevian.org/example
        /// http://www.tonyballantyne.com/graphs.html
        /// </summary>
        static void PrepareMyGraph()
        {

            #region Graph
            string directedGraph = @"digraph G {
0 ;
1 ;
2 ;
3 ;
4 ;
5 ;
6 ;
7 ;
8 ;
9 ;
0 -> 1 [];
0 -> 3 [];
1 -> 0 [];
1 -> 2 [];
1 -> 4 [];
2 -> 1 [];
2 -> 5 [];
2 -> 9 [];
3 -> 4 [];
3 -> 6 [];
4 -> 3 [];
4 -> 5 [];
4 -> 7 [];
5 -> 8 [];
5 -> 9 [];
6 -> 3 [];
6 -> 7 [];
7 -> 6 [];
7 -> 8 [];
8 -> 5 [];
8 -> 7 [];
8 -> 9 [];
9 -> 5 [];
}";
            #endregion

            string output = "GraphRepresentation";
            File.WriteAllText(output, directedGraph);

            // assumes dot.exe is on the path:
            var dotargs = string.Format(@"{0} -Tjpg -O", output);
            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Graphviz2.38\bin\dot.exe", dotargs);
        }

        static void PrepareGitHubExample()
        {
            AdjacencyGraph<string, Edge<string>> graph = new AdjacencyGraph<string, Edge<string>>(true);

            // Add some vertices to the graph
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");
            graph.AddVertex("G");
            graph.AddVertex("H");
            graph.AddVertex("I");
            graph.AddVertex("J");

            // Create the edges
            Edge<string> a_b = new Edge<string>("A", "B");
            Edge<string> a_d = new Edge<string>("A", "D");
            Edge<string> b_a = new Edge<string>("B", "A");
            Edge<string> b_c = new Edge<string>("B", "C");
            Edge<string> b_e = new Edge<string>("B", "E");
            Edge<string> c_b = new Edge<string>("C", "B");
            Edge<string> c_f = new Edge<string>("C", "F");
            Edge<string> c_j = new Edge<string>("C", "J");
            Edge<string> d_e = new Edge<string>("D", "E");
            Edge<string> d_g = new Edge<string>("D", "G");
            Edge<string> e_d = new Edge<string>("E", "D");
            Edge<string> e_f = new Edge<string>("E", "F");
            Edge<string> e_h = new Edge<string>("E", "H");
            Edge<string> f_i = new Edge<string>("F", "I");
            Edge<string> f_j = new Edge<string>("F", "J");
            Edge<string> g_d = new Edge<string>("G", "D");
            Edge<string> g_h = new Edge<string>("G", "H");
            Edge<string> h_g = new Edge<string>("H", "G");
            Edge<string> h_i = new Edge<string>("H", "I");
            Edge<string> i_f = new Edge<string>("I", "F");
            Edge<string> i_j = new Edge<string>("I", "J");
            Edge<string> i_h = new Edge<string>("I", "H");
            Edge<string> j_f = new Edge<string>("J", "F");

            // Add the edges
            graph.AddEdge(a_b);
            graph.AddEdge(a_d);
            graph.AddEdge(b_a);
            graph.AddEdge(b_c);
            graph.AddEdge(b_e);
            graph.AddEdge(c_b);
            graph.AddEdge(c_f);
            graph.AddEdge(c_j);
            graph.AddEdge(d_e);
            graph.AddEdge(d_g);
            graph.AddEdge(e_d);
            graph.AddEdge(e_f);
            graph.AddEdge(e_h);
            graph.AddEdge(f_i);
            graph.AddEdge(f_j);
            graph.AddEdge(g_d);
            graph.AddEdge(g_h);
            graph.AddEdge(h_g);
            graph.AddEdge(h_i);
            graph.AddEdge(i_f);
            graph.AddEdge(i_h);
            graph.AddEdge(i_j);
            graph.AddEdge(j_f);

            // Define some weights to the edges
            Dictionary<Edge<string>, double> edgeCost = new Dictionary<Edge<string>, double>(graph.EdgeCount);
            edgeCost.Add(a_b, 4);
            edgeCost.Add(a_d, 1);
            edgeCost.Add(b_a, 74);
            edgeCost.Add(b_c, 2);
            edgeCost.Add(b_e, 12);
            edgeCost.Add(c_b, 12);
            edgeCost.Add(c_f, 74);
            edgeCost.Add(c_j, 12);
            edgeCost.Add(d_e, 32);
            edgeCost.Add(d_g, 22);
            edgeCost.Add(e_d, 66);
            edgeCost.Add(e_f, 76);
            edgeCost.Add(e_h, 33);
            edgeCost.Add(f_i, 11);
            edgeCost.Add(f_j, 21);
            edgeCost.Add(g_d, 12);
            edgeCost.Add(g_h, 10);
            edgeCost.Add(h_g, 2);
            edgeCost.Add(h_i, 72);
            edgeCost.Add(i_f, 31);
            edgeCost.Add(i_h, 18);
            edgeCost.Add(i_j, 7);
            edgeCost.Add(j_f, 8);

            Func<Edge<string>, double> edgeCostFunction = e => edgeCost[e]; // constant cost

            Func<Edge<string>, double> distObserverFunction = e => 1;

            // We want to use Dijkstra on this graph
            DijkstraShortestPathAlgorithm<string, Edge<string>> dijkstra = new DijkstraShortestPathAlgorithm<string, Edge<string>>(graph, edgeCostFunction);

            // attach a distance observer to give us the shortest path distances
            VertexDistanceRecorderObserver<string, Edge<string>> distObserver = new VertexDistanceRecorderObserver<string, Edge<string>>(distObserverFunction);
            distObserver.Attach(dijkstra);

            // Attach a Vertex Predecessor Recorder Observer to give us the paths
            VertexPredecessorRecorderObserver<string, Edge<string>> predecessorObserver = new VertexPredecessorRecorderObserver<string, Edge<string>>();
            predecessorObserver.Attach(dijkstra);

            // Run the algorithm with A set to be the source
            dijkstra.Compute("A");

            foreach (KeyValuePair<string, double> kvp in distObserver.Distances)
                Console.WriteLine("Distance from root to node {0} is {1}", kvp.Key, kvp.Value);

            foreach (KeyValuePair<string, Edge<string>> kvp in predecessorObserver.VertexPredecessors)
                Console.WriteLine("If you want to get to {0} you have to enter through the in edge {1}", kvp.Key, kvp.Value);

            // Remember to detach the observers
            // distObserver.Detach(dijkstra);
            // predecessorObserver.Detach(dijkstra);

            // Visualize the Graph
            var graphviz = new GraphvizAlgorithm<string, Edge<string>>(graph);
            graphviz.ImageType = GraphvizImageType.Jpeg;

            // render
            string outputString = graphviz.Generate();
            string output = graphviz.Generate(new FileDotEngine(), "MyGraph");
        }


        static void PrepareMSRDataset()
        {
            AdjacencyGraph<string, Edge<string>> graph = new AdjacencyGraph<string, Edge<string>>(true);
            // Dictionary<Edge<string>, double> edgeCost = new Dictionary<Edge<string>, double>();

            string filePath = @"D:\Debug\ConceptGraph\data-concept\data-concept-instance-relations.txt";
            string line;
            int count = 0;
            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null && count++ <= 20000)
                {
                    string[] tokens = line.Split(new char[] { '\t' });

                    // Add vertices to the graph
                    graph.AddVertex(tokens[0]);
                    graph.AddVertex(tokens[1]);

                    // Create the edges
                    Edge<string> a_b = new Edge<string>(tokens[0], tokens[1]);

                    // Add the edges
                    graph.AddEdge(a_b);
                    
                    // Define weights to the edge
                    // edgeCost.Add(a_b, double.Parse(tokens[2]));
                }
            }


            /*
            
            Func<Edge<string>, double> edgeCostFunction = e => edgeCost[e]; // constant cost
            Func<Edge<string>, double> distObserverFunction = e => 1;

            // We want to use Dijkstra on this graph
            DijkstraShortestPathAlgorithm<string, Edge<string>> dijkstra = new DijkstraShortestPathAlgorithm<string, Edge<string>>(graph, edgeCostFunction);

            // attach a distance observer to give us the shortest path distances
            VertexDistanceRecorderObserver<string, Edge<string>> distObserver = new VertexDistanceRecorderObserver<string, Edge<string>>(distObserverFunction);
            distObserver.Attach(dijkstra);

            // Attach a Vertex Predecessor Recorder Observer to give us the paths
            VertexPredecessorRecorderObserver<string, Edge<string>> predecessorObserver = new VertexPredecessorRecorderObserver<string, Edge<string>>();
            predecessorObserver.Attach(dijkstra);

            // Run the algorithm with A set to be the source
            dijkstra.Compute("A");

            foreach (KeyValuePair<string, double> kvp in distObserver.Distances)
                Console.WriteLine("Distance from root to node {0} is {1}", kvp.Key, kvp.Value);

            foreach (KeyValuePair<string, Edge<string>> kvp in predecessorObserver.VertexPredecessors)
                Console.WriteLine("If you want to get to {0} you have to enter through the in edge {1}", kvp.Key, kvp.Value);

            // Remember to detach the observers
            distObserver.Detach(dijkstra);
            predecessorObserver.Detach(dijkstra);
            
             */

            // Visualize the Graph
            var graphviz = new GraphvizAlgorithm<string, Edge<string>>(graph);
            graphviz.ImageType = GraphvizImageType.Jpeg;

            // render
            string outputString = graphviz.Generate();
            string output = graphviz.Generate(new FileDotEngine(), "MSRConcepts");
        }

        public sealed class FileDotEngine : IDotEngine
        {
            public string Run(GraphvizImageType imageType, string dot, string outputFileName)
            {
                string output = outputFileName;
                File.WriteAllText(output, dot);

                // assumes dot.exe is on the path:
                var dotargs = string.Format(@"{0} -Tjpg -O", output);
                System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Graphviz2.38\bin\dot.exe", dotargs);

                return output;
            }
        }
    }
}
