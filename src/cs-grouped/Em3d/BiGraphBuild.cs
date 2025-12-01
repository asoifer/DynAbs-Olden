using System;
using System.Collections.Generic;
using System.Text;

public partial class BiGraph
{
    /**
    * Create the bi graph that contains the linked list of
    * e and h nodes.
    * @param numNodes the number of nodes to create
    * @param numDegree the out-degree of each node
    * @param verbose should we print out runtime messages
    * @return the bi graph that we've created.
    **/
    public static BiGraph create(int numNodes, int numDegree, bool verbose)
    {
        // making nodes (we create a table)
        if (verbose)
            Console.WriteLine("making nodes (tables in orig. version)");
        var hTable = ENode.fillTable(numNodes, numDegree);
        var eTable = ENode.fillTable(numNodes, numDegree);

        // making neighbors
        if (verbose)
            Console.WriteLine("updating from and coeffs");
        var tNode = hTable[0];
        while (tNode != null)
        {
            tNode.makeUniqueNeighbors(eTable);
            tNode = tNode.next;
        }
        tNode = eTable[0];
        while (tNode != null)
        {
            tNode.makeUniqueNeighbors(hTable);
            tNode = tNode.next;
        }

        // Create the fromNodes and coeff field
        if (verbose)
            Console.WriteLine("filling from fields");

        tNode = hTable[0];
        while (tNode != null)
        {
            tNode.makeFromNodes();
            tNode = tNode.next;
        }
        tNode = eTable[0];
        while (tNode != null)
        {
            tNode.makeFromNodes();
            tNode = tNode.next;
        }

        // Update the fromNodes
        tNode = hTable[0];
        while (tNode != null)
        {
            tNode.updateFromNodes();
            tNode = tNode.next;
        }
        tNode = eTable[0];
        while (tNode != null)
        {
            tNode.updateFromNodes();
            tNode = tNode.next;
        }

        BiGraph g = new BiGraph(eTable[0], hTable[0]);
        return g;
    }
}
