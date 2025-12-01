using System;
using System.Collections.Generic;
using System.Text;

public partial class ENode
{
    //
    // Create the linked list of E or H nodes.  We create a table which is used
    // later to create links among the nodes.
    // @param size   the no. of nodes to create
    // @param degree the out degree of each node
    // @return a table containing all the nodes.
    //
    public static ENode[] fillTable(int size, int degree)
    {
        ENode[] table = new ENode[size];

        ENode prevNode = new ENode(degree);
        table[0] = prevNode;
        for (int i = 1; i < size; i++)
        {
            ENode curNode = new ENode(degree);
            table[i] = curNode;
            prevNode.next = curNode;
            prevNode = curNode;
        }
        return table;
    }

    //
    // Create unique `degree' neighbors from the nodes given in nodeTable.
    // We do this by selecting a random node from the give nodeTable to
    // be neighbor. If this neighbor has been previously selected, then
    // a different random neighbor is chosen.
    // @param nodeTable the list of nodes to choose from.
    //
    public void makeUniqueNeighbors(ENode[] nodeTable)
    {
        for (int filled = 0; filled < toNodes.Length; filled++)
        {
            int k;
            ENode otherNode = null;

            do
            {
                // generate a random number in the correct range
                int index = RandomGenerator.Next(filled+1);
                if (index < 0)
                    index = -index;
                index = index % nodeTable.Length;

                // find a node with the random index in the given table
                otherNode = nodeTable[index];

                for (k = 0; k < filled; k++)
                {
                    if (otherNode == toNodes[filled])
                        break;
                }
            } while (k < filled);

            // other node is definitely unique among "filled" toNodes
            toNodes[filled] = otherNode;

            // update fromCount for the other node
            otherNode.fromCount = otherNode.fromCount + 1;
        }
    }

    //
    // Allocate the right number of FromNodes for this node. This
    // step can only happen once we know the right number of from nodes
    // to allocate. Can be done after unique neighbors are created and known.
    // <p/>
    // It also initializes random coefficients on the edges.
    //
    public void makeFromNodes()
    {
        fromNodes = new ENode[fromCount]; // nodes fill be filled in later
        coeffs = new double[fromCount];
    }

    //
    // Fill in the fromNode field in "other" nodes which are pointed to
    // by this node.
    //
    public void updateFromNodes()
    {
        for (int i = 0; i < this.toNodes.Length; ++i)
        {
            ENode otherNode = this.toNodes[i];
            int count = otherNode.fromLength++;
            otherNode.fromNodes[count] = this;
            otherNode.coeffs[count] = RandomGenerator.NextDouble(i+1);
        }
    }
}
