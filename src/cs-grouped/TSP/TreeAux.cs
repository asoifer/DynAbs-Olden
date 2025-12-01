
using System;

public partial class Tree
{
    //*
    // Find Euclidean distance between this node and the specified node.
    // @param b the specified node
    // @return the Euclidean distance between two tree nodes.
    ///
    public double distance(Tree b)
    {
        return (Math.Sqrt((x - b.x) * (x - b.x) + (y - b.y) * (y - b.y)));
    }

    //*
    // Create a list of tree nodes.  Requires root to be the tail of the list.
    // Only fills in next field, not prev.
    // @return the linked list of nodes
    ///
    public Tree makeList()
    {
        Tree myleft;
        Tree myright;
        Tree tleft;
        Tree tright;
        Tree retval = this;

        // head of left list
        if (left != null)
            myleft = left.makeList();
        else
            myleft = null;

        // head of right list
        if (right != null)
            myright = right.makeList();
        else
            myright = null;

        if (myright != null)
        {
            retval = myright;
            right.next = this;
        }

        if (myleft != null)
        {
            retval = myleft;
            if (myright != null)
                left.next = myright;
            else
                left.next = this;
        }
        next = null;

        return retval;
    }

    //*
    // Reverse the linked list.  Assumes that there is a dummy "prev"
    // node at the beginning.
    ///
    public void reverse()
    {
        Tree prev = this.prev;
        prev.next = null;
        this.prev = null;
        Tree back = this;
        Tree tmp = this;
        // reverse the list for the other nodes
        Tree next;
        for (Tree t = this.next; t != null; back = t, t = next)
        {
            next = t.next;
            t.next = back;
            back.prev = t;
        }
        // reverse the list for this node
        tmp.next = prev;
        prev.prev = tmp;
    }

    //*
    // Print the list of cities to visit from the current node.  The
    // list is the result of computing the TSP problem.
    // The list for the root node (city) should contain every other node
    // (city).
    ///
    public void printVisitOrder()
    {
        Console.WriteLine("x = " + x + " y = " + y);
        for (Tree tmp = next; tmp != this; tmp = tmp.next)
            Console.WriteLine("x = " + tmp.x + " y = " + tmp.y);
    }
}
