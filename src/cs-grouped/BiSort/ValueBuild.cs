using System;
using System.Collections.Generic;
using System.Text;

public partial class Value
{
    // These are used by the Olden benchmark random no. generator
    private static int CONST_m1 = 10000;
    private static int CONST_b = 31415821;

    //*
    // Create a random tree of value to be sorted using the bitonic sorting algorithm.
    //
    // @param size the number of values to create.
    // @param seed a random number generator seed value
    // @return the root of the (sub) tree.
    ///
    public static Value createTree(int size, int seed)
    {
        if (size > 1)
        {
            seed = random(seed);
            int next_val = seed % RANGE;

            Value retval = new Value(next_val);
            retval.left = createTree(size / 2, seed);
            retval.right = createTree(size / 2, skiprand(seed, size + 1));
            return retval;
        }
        else
            return null;
    }

    //*
    // A random generator.  The original Olden benchmark uses its
    // own random generator.  We use the same one in the Java version.
    // @return the next random number in the sequence.
    ///
    private static int mult(int p, int q)
    {
        int p1 = p / CONST_m1;
        int p0 = p % CONST_m1;
        int q1 = q / CONST_m1;
        int q0 = q % CONST_m1;
        return (((p0 * q1 + p1 * q0) % CONST_m1) * CONST_m1 + p0 * q0);
    }

    //
    // A routine to skip the next <i>n</i> random numbers.
    // @param seed the current random no. seed
    // @param n    the number of numbers to skip
    //
    private static int skiprand(int seed, int n)
    {
        for (; n != 0; n--)
            seed = random(seed);
        return seed;
    }

    //
    // Return a random number based upon the seed value.
    // @param seed the random number seed value
    // @return a random number based upon the seed value.
    //
    public static int random(int seed)
    {
        int tmp = mult(seed, CONST_b) + 1;
        return tmp;
    }
}
