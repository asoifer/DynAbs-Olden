using System;

/**
 * A class that represents the irregular bipartite graph used in
 * EM3D.  The graph contains two linked structures that represent the
 * E nodes and the N nodes in the application.
 */
public partial class BiGraph
{
	/**
	 * Nodes that represent the electrical field.
	 */
	public ENode eNodes;
    /**
	 * Nodes that representhe the magnetic field.
	 */
    public ENode hNodes;

	/**
	 * Construct the bipartite graph.
	 * @param e the nodes representing the electric fields
	 * @param h the nodes representing the magnetic fields
	 */
	public BiGraph(ENode e, ENode h)
	{
		eNodes = e;
		hNodes = h;
	}

	/**
	 * Update the field values of e-nodes based on the values of
	 * neighboring h-nodes and vice-versa.
	 */
	public void compute()
	{
		var tNode = eNodes;
		while (tNode != null) 
		{
			tNode.computeNewValue();
			tNode = tNode.next;
		}
		tNode = hNodes;
		while (tNode != null) 
		{
			tNode.computeNewValue();
			tNode = tNode.next;
		}
	}

	/**
    * Override the toString method to print out the values of the e and h nodes.
    * @return a string contain the values of the e and h nodes.
    **/
	public string toString()
	{
		var retval = new System.Text.StringBuilder();
		var tNode = eNodes;
		while (tNode != null) 
		{
			retval.Append("E: " + tNode.toString() + "\n");
			tNode = tNode.next;
		}
		tNode = hNodes;
		while (tNode != null) 
		{
			retval.Append("H: " + tNode.toString() + "\n");
			tNode = tNode.next;
		}
		return retval.ToString();
	}
}
