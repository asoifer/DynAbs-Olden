using System;
using System.Collections.Generic;
using System.Text;

public partial class Graph
{
    //
    // Create a graph.  This is just another method for
    // creating the graph data structure. 
    // @param numvert the size of the graph
    //
    public static Graph createGraph(int numvert)
    {
        var graph = new Graph();

        graph.nodes = new Vertex[numvert];
        Vertex v = null;
        // the original C code creates them in reverse order 
        for (int i = numvert - 1; i >= 0; i--)
        {
            Vertex tmp = graph.nodes[i] = new Vertex(v, numvert);
            v = tmp;
        }

        graph.addEdges(numvert);

        return graph;
    }
}
