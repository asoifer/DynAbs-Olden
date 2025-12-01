using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

//
// This class implements nodes (both E- and H-nodes) of the EM graph. Sets
// up random neighbors and propagates field values among neighbors.
//
public partial class ENode
{
    //
	// The value of the node.
	//
    public double value;
	//
   // The next node in the list.
   //
    public ENode next;
    //
	// Array of nodes to which we send our value.
	//
    public ENode[] toNodes;
    //
	// Array of nodes from which we receive values.
	//
    public ENode[] fromNodes;
    //
	// Coefficients on the fromNodes edges
	//
    public double[] coeffs;
    //
	// The number of fromNodes edges
	//
    public int fromCount;
    //
	// Used to create the fromEdges - keeps track of the number of edges that have
	// been added
	//
    public int fromLength;
	//
	// Nodes counter
	//
    static int counter = 0;

    //
    // Constructor for a node with given `degree'.   The value of the
    // node is initialized to a random value.
    //
    public ENode(int degree)
	{
		counter++;
        value = RandomGenerator.NextDouble(counter);
		// create empty array for holding toNodes
		toNodes = new ENode[degree];
		
		next = null;
		fromNodes = null;
		coeffs = null;
		fromCount = 0;
		fromLength = 0;
	}

	//
	// Get the new value of the current node based on its neighboring
	// from_nodes and coefficients.
	//
	public void computeNewValue()
	{
		for(int i = 0; i < fromCount; i++)
			value -= coeffs[i] * fromNodes[i].value;
	}

	//
    // Override the toString method to return the value of the node.
    // @return the value of the node.
    //
	public string toString()
	{
		return "value " + value + ", from_count " + fromCount;
	}
}
