using System;

public partial class Lateral
{
    //
    // Create all the lateral nodes for a single root node.
    // @param num       the child number of the lateral wrt the root
    // @param nbranches the number of branch nodes per lateral.
    // @param nleaves   the number of leaf nodes per branch.
    //
    public static Lateral createLateral(int num, int nbranches, int nleaves)
    {
        var lateral = new Lateral();
        lateral.D = new Demand();

        // create a linked list of the lateral nodes
        if (num <= 1)
            lateral.next_lateral = null;
        else
            lateral.next_lateral = Lateral.createLateral(num - 1, nbranches, nleaves);

        // create the branch nodes
        lateral.branch = Branch.createBranch(nbranches, nleaves);

        return lateral;
    }
}
