using System;
using System.Runtime.InteropServices.WindowsRuntime;

public partial class Root
{
    //
    // Create the tree used by the power system optimization benchmark.
    // Each root contains <tt>nfeeders</tt> feeders which each contain
    // <tt>nlaterals</tt> lateral nodes, which each contain
    // <tt>nbranches</tt> branch nodes, which each contain <tt>nleafs</tt>
    // leaf nodes.
    //
    // @param nfeeders  the number of feeders off of the root
    // @param nlaterals the number of lateral nodes per feeder
    // @param nbranches the number of branches per lateral
    // @param nleaves   the number of leaves per branch
    //
    public static Root createRoot(int nfeeders, int nlaterals, int nbranches, int nleaves)
    {
        var root = new Root();
        root.D = new Demand();
        root.last = new Demand();

        root.feeders = new Lateral[nfeeders];
        for (int i = 0; i < nfeeders; i++)
        {
            root.feeders[i] = Lateral.createLateral(nlaterals, nbranches, nleaves);
        }
        return root;
    }
}
