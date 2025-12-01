using System;

public partial class Vertex
{
    //
    // Seed value used during tree creation.
    //
    internal static int seed = 1023;

    //
    // Generate a voronoi diagram
    //
    internal static Vertex createPoints(int n, MyDouble curmax, int i)
    {
        if (n < 1)
        {
            return null;
        }

        Vertex cur = new Vertex();

        Vertex right = Vertex.createPoints(n / 2, curmax, i);
        i -= n / 2;
        cur.x = curmax.value * System.Math.Exp(System.Math.Log(Vertex.drand()) / i);
        cur.y = Vertex.drand();
        cur.norm = cur.x * cur.x + cur.y * cur.y;
        cur.right = right;
        curmax.value = cur.X();
        Vertex left = Vertex.createPoints(n / 2, curmax, i - 1);

        cur.left = left;
        return cur;
    }

    //
    // A routine used by the random number generator
    //
    internal static int mult(int p, int q)
    {
        int p1;
        int p0;
        int q1;
        int q0;
        int CONST_m1 = 10000;

        p1 = p / CONST_m1;
        p0 = p % CONST_m1;
        q1 = q / CONST_m1;
        q0 = q % CONST_m1;
        return (((p0 * q1 + p1 * q0) % CONST_m1) * CONST_m1 + p0 * q0);
    }

    //
    // Generate the nth random number
    //
    internal static int skiprand(int seed, int n)
    {
        for (; n != 0; n--)
            seed = random(seed);
        return seed;
    }

    internal static int random(int seed)
    {
        int CONST_b = 31415821;

        seed = mult(seed, CONST_b) + 1;
        return seed;
    }

    internal static double drand()
    {
        double retval = ((double)(Vertex.seed = Vertex.random(Vertex.seed))) / (double)2147483647;
        return retval;
    }
}
