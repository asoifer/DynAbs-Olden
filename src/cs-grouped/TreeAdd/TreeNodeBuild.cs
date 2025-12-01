
public partial class TreeNode
{
    //*
    // Create a tree with the given number of levels.
    // @param levels the number of levels in the tree
    //
    public static TreeNode createTree(int levels)
    {
        if (levels == 0)
        {
            return null;
        }
        else
        {
            TreeNode n = new TreeNode();
            n.left = createTree(levels - 1);
            n.right = createTree(levels - 1);
            return n;
        }
    }
}
