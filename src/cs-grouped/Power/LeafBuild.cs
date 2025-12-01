using System;

public partial class Leaf
{
    public static Leaf createLeaf()
    {
        var leaf = new Leaf();
        leaf.D = new Demand(1.0, 1.0);
        return leaf;
    }
}
