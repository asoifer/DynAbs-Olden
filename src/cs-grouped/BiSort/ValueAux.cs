using System;
using System.Collections.Generic;
using System.Text;

public partial class Value
{
    //
    // Swap the values and the right subtrees.
    // @param n the other subtree involved in the swap.
    ///
    public void swapValRight(Value n)
    {
        int tmpv = n.value;
        Value tmpr = n.right;

        n.value = value;
        n.right = right;

        value = tmpv;
        right = tmpr;
    }

    //
    // Swap the values and the left subtrees.
    // @param n the other subtree involved in the swap.
    ///
    public void swapValLeft(Value n)
    {
        int tmpv = n.value;
        Value tmpl = n.left;

        n.value = value;
        n.left = left;

        value = tmpv;
        left = tmpl;
    }

    //
    // Print out the nodes in the binary tree in infix order.
    //
    public void inOrder()
    {
        if (left != null)
            left.inOrder();
        System.Console.Write(value + " ");
        if (right != null)
            right.inOrder();
    }
}
