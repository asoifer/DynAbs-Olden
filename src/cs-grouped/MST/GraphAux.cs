using System;
using System.Collections.Generic;
using System.Text;

public partial class Graph
{
    // parameters for the random number generater
    private const int CONST_m1 = 10000;
    private const int CONST_b = 31415821;

    private static int mult(int p, int q)
    {
        int p1;
        int p0;
        int q1;
        int q0;
        p1 = p / CONST_m1;
        p0 = p % CONST_m1;
        q1 = q / CONST_m1;
        q0 = q % CONST_m1;
        return (((p0 * q1 + p1 * q0) % CONST_m1) * CONST_m1 + p0 * q0);
    }

    private static int random(int seed)
    {
        return mult(seed, CONST_b) + 1;
    }
}
