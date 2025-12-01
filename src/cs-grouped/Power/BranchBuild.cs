using System;

public partial class Branch
{
    //
    // Create all the branch nodes for a single lateral node.
    // Also, create the customers supported by this branch node
    //
    // @param num     a counter to limit the branch nodes created for the lateral node
    // @param nleaves the nubmer of leafs to create per branch
    //
    public static Branch createBranch(int num, int nleaves)
    {
        var branch = new Branch();
        branch.D = new Demand();

        if (num <= 1)
            branch.nextBranch = null;
        else
            branch.nextBranch = Branch.createBranch(num - 1, nleaves);

        // fill in children
        branch.leaves = new Leaf[nleaves];
        for (int k = 0; k < nleaves; k++)
            branch.leaves[k] = Leaf.createLeaf();

        return branch;
    }
}
