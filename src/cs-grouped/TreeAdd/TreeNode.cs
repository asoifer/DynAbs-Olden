using System;

//*
// A Tree node data structure.
//
public partial class TreeNode
{
	private int value = 0;
	private TreeNode left = null;
	private TreeNode right = null;

    //*
    // Create a node in the tree with a given value and two children.
    // @param v the node's value
    // @param l the left child.
    // @param r the right child.
    //
    public TreeNode(int v, TreeNode l, TreeNode r)
    {
        value = v;
        left = l;
        right = r;
    }

    //* 
    // Create a tree node given the two children.  The initial node
    // value is 1.
    //
    public TreeNode()
        : this(1, null, null)
    {
    }

    //*
    // Set the children of the tree
    // @param l the left child
    // @param r the right child
    //
    public virtual void setChildren(TreeNode l, TreeNode r)
    {
        left = l;
        right = r;
    }

    //*
    // Add the value of this node with the cumulative values
    // of the children of this node.
    // @return the cumulative value of this tree.
    //
    internal virtual int addTree()
	{
		int total = value;
		if (left != null)
			total += left.addTree();
		if (right != null)
			total += right.addTree();
		return total;
	}
}
