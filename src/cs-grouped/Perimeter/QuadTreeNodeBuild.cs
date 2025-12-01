using System;

public abstract partial class QuadTreeNode
{
    //
    // Value used to determine the x-axis size of the image
    //
    public static int gcmp = 4194304;
    //
    // Value used to determine the y-axis size of the image
    //
    public static int lcmp = 1048576;

    //
    // Create an image which is represented using a QuadTreeNode.
    // @param size      size of image
    // @param center_x  x coordinate of center
    // @param center_y; y coordinate of center
    // @param parent    parent quad tree node
    // @param quadrant  the quadrant that the sub tree is in
    // @param levels    levels of the tree
    //
    public static QuadTreeNode createTree(int size, int center_x, int center_y, QuadTreeNode parent, Quadrant quadrant, int levels)
    {
        gcmp = (1 << levels) * 1024;
        lcmp = (1 << (levels - 1)) * 1024;
        return createTreeInternal(size, center_x, center_y, parent, quadrant, levels);
    }

    static QuadTreeNode createTreeInternal(int size, int center_x, int center_y, QuadTreeNode parent, Quadrant quadrant, int level)
    {
        QuadTreeNode node;

        int intersect = checkIntersect(center_x, center_y, size);
        size = size / 2;
        if (intersect == 0 && size < 512)
        {
            node = new WhiteNode(quadrant, parent);
        }
        else if (intersect == 2)
        {
            node = new BlackNode(quadrant, parent);
        }
        else
        {
            if (level == 0)
            {
                node = new BlackNode(quadrant, parent);
            }
            else
            {
                node = new GreyNode(quadrant, parent);
                QuadTreeNode sw = createTreeInternal(size, center_x - size, center_y - size, node, Quadrant.cSouthWest, level - 1);
                QuadTreeNode se = createTreeInternal(size, center_x + size, center_y - size, node, Quadrant.cSouthEast, level - 1);
                QuadTreeNode ne = createTreeInternal(size, center_x + size, center_y + size, node, Quadrant.cNorthEast, level - 1);
                QuadTreeNode nw = createTreeInternal(size, center_x - size, center_y + size, node, Quadrant.cNorthWest, level - 1);
                node.setChildren(nw, ne, sw, se);
            }
        }
        return node;
    }

    private static int checkIntersect(int center_x, int center_y, int size)
    {
        if (checkOutside(center_x + size, center_y + size) == 0 && checkOutside(center_x + size, center_y - size) == 0 && checkOutside(center_x - size, center_y - size) == 0 && checkOutside(center_x - size, center_y + size) == 0)
            return 2;

        int sum = checkOutside(center_x + size, center_y + size) + checkOutside(center_x + size, center_y - size) + checkOutside(center_x - size, center_y - size) + checkOutside(center_x - size, center_y + size);

        if ((sum == 4) || (sum == -4))
            return 0;

        return 1;
    }

    private static int checkOutside(int x, int y)
    {
        int euclid = x * x + y * y;
        if (euclid > gcmp)
            return 1;
        if (euclid < lcmp)
            return -1;
        return 0;
    }
}
