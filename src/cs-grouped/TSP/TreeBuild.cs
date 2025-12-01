
using System;

public partial class Tree
{
    //
    // static methods
    //

    // used by the random number generator
    private static double M_E2 = 7.3890560989306502274;
    private static double M_E3 = 20.08553692318766774179;
    private static double M_E6 = 403.42879349273512264299;
    private static double M_E12 = 162754.79141900392083592475;

    //*
    // Return an estimate of median of n values distributed in [min,max)
    // @param min the minimum value
    // @param max the maximum value
    // @param n
    // @return an estimate of median of n values distributed in [min,max)
    ///
    private static double median(double min, double max, int n)
    {
        // get random value in [0.0, 1.0)
        double t = RandomGenerator.NextDouble();

        double retval;
        if (t > 0.5)
            retval = Math.Log(1.0 - (2.0 * (M_E12 - 1.0) * (t - 0.5) / M_E12)) / 12.0;
        else
            retval = -Math.Log(1.0 - (2.0 * (M_E12 - 1.0) * t / M_E12)) / 12.0;

        // We now have something distributed on (-1.0,1.0)
        retval = (retval + 1.0) * (max - min) / 2.0;
        retval = retval + min;
        return retval;
    }

    //*
    // Get double uniformly distributed over [min,max)
    // @return double uniformily distributed over [min,max)
    ///
    private static double uniform(double min, double max)
    {
        // get random value between [0.0,1.0)
        double retval = RandomGenerator.NextDouble();
        retval = retval * (max - min);
        return retval + min;
    }

    //*
    // Builds a 2D tree of n nodes in specified range with dir as primary
    // axis (false for x, true for y)
    //
    // @param n     the size of the suTree to create
    // @param dir   the primary axis
    // @param min_x the minimum x coordinate
    // @param max_x the maximum x coordinate
    // @param min_y the minimum y coordinate
    // @param max_y the maximum y coordinate
    // @return a reference to the root of the suTree
    ///
    public static Tree buildTree(int n, bool dir, double min_x, double max_x, double min_y, double max_y)
    {
        if (n == 0)
            return null;

        Tree left;
        Tree right;
        double x;
        double y;
        if (dir)
        {
            dir = !dir;
            double med = median(min_x, max_x, n);
            left = buildTree(n / 2, dir, min_x, med, min_y, max_y);
            right = buildTree(n / 2, dir, med, max_x, min_y, max_y);
            x = med;
            y = uniform(min_y, max_y);
        }
        else
        {
            dir = !dir;
            double med = median(min_y, max_y, n);
            left = buildTree(n / 2, dir, min_x, max_x, min_y, med);
            right = buildTree(n / 2, dir, min_x, max_x, med, max_y);
            y = med;
            x = uniform(min_x, max_x);
        }
        return new Tree(n, x, y, left, right);
    }
}
