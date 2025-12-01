using System;
using System.Collections.Generic;
using System.Text;

public partial class MST
{ 
    //
    // The method to compute the minimum spanning tree.
    // @param graph the graph data structure 
    // @param numvert the number of vertices in the graph
    // @return the minimum spanning tree cost
    //
    internal static int computeMST(Graph graph, int numvert)
    {
        int cost = 0;

        // Insert first node
        Vertex inserted = graph.firstNode();
        Vertex tmp = inserted.Next();
        MyVertexList = tmp;
        numvert--;

        // Annonunce insertion and find next one
        while (numvert != 0)
        {
            //System.out.println("numvert= " +numvert);
            BlueReturn br = doAllBlueRule(inserted);
            inserted = br.getVert();
            int dist = br.getDist();
            numvert--;
            cost += dist;
        }
        return cost;
    }

    private static BlueReturn BlueRule(Vertex inserted, Vertex vlist)
    {
        BlueReturn retval = new BlueReturn();

        if (vlist == null)
        {
            retval.setDist(999999);
            return retval;
        }

        Vertex prev = vlist;
        retval.setVert(vlist);
        retval.setDist(vlist.Mindist());
        Hashtable hash = vlist.Neighbors();
        object o = hash.get(inserted);
        if (o != null)
        {
            int dist = ((int)o);
            if (dist < retval.getDist())
            {
                vlist.setMindist(dist);
                retval.setDist(dist);
            }
        }
        else
            System.Console.WriteLine("Not found");

        int count = 0;
        // We are guaranteed that inserted is not first in list
        for (Vertex tmp = vlist.Next(); tmp != null; prev = tmp, tmp = tmp.Next())
        {
            count++;
            if (tmp == inserted)
            {
                Vertex next = tmp.Next();
                prev.SetNext(next);
            }
            else
            {
                hash = tmp.Neighbors();
                int dist2 = tmp.Mindist();
                o = hash.get(inserted);
                if (o != null)
                {
                    int dist = ((int)o);
                    if (dist < dist2)
                    {
                        tmp.setMindist(dist);
                        dist2 = dist;
                    }
                }
                else
                    System.Console.WriteLine("Not found");

                if (dist2 < retval.getDist())
                {
                    retval.setVert(tmp);
                    retval.setDist(dist2);
                }
            }
        }
        return retval;
    }

    private static Vertex MyVertexList = null;

    private static BlueReturn doAllBlueRule(Vertex inserted)
    {
        if (inserted == MyVertexList)
            MyVertexList = MyVertexList.Next();
        return BlueRule(inserted, MyVertexList);
    }
}