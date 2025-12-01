using System;
//
// A class that represents a graph data structure.
//
public partial class Graph
{
	//
  // List of vertices in the graph.
  //
	private Vertex[] nodes;

	// parameters for the random number generater
	private const int RANGE = 2048;

	//
    // Create a graph.
    // @param numvert the number of vertices in the graph
    //
	public Graph()
	{
		
	}

	//
    // Return the first node in the graph.
    // @return the first node in the graph.
    //
	public virtual Vertex firstNode()
	{
		return nodes[0];
	}

	//
    // Add edges to the graph.  Edges are added to/from every node
    // in the graph and a distance is computed for each of them.
    // @param numvert the number of nodes in the graph
    //
	private void addEdges(int numvert)
	{
		int count1 = 0;
		for (Vertex tmp = nodes[0]; tmp != null; tmp = tmp.Next())
		{
			Hashtable hash = tmp.Neighbors();
			for (int i = 0; i < numvert; i++)
			{
				if (i != count1)
				{
					int dist = computeDist(i, count1, numvert);
					hash.put(nodes[i], dist);
				}
			}
			count1++;
		}
	}

	//
    // Compute the distance between two edges.  A random number generator
    // is used to compute the distance.
    //
	private int computeDist(int i, int j, int numvert)
	{
		int less;
		int gt;
		if (i < j)
		{
			less = i;
			gt = j;
		}
		else
		{
			less = j;
			gt = i;
		}
		return (random(less * numvert + gt) % RANGE) + 1;
	}
}
