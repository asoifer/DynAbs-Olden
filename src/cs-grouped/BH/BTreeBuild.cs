using System;
using System.Collections.Generic;
using System.Text;

public partial class BTree
{
    //
    // Create the testdata used in the benchmark
    // @param nbody the number of bodies to create
    //
    public void createTestData(int nbody)
    {
        MathVector cmr = new MathVector();
        MathVector cmv = new MathVector();

        Body head = new Body();
        Body prev = head;

        double rsc = 3.0 * 3.1415 / 16.0;
        double vsc = Math.Sqrt(1.0 / rsc);
        double seed = 123.0;

        for (int i = 0; i < nbody; i++)
        {
            Body p = new Body();
            prev.setNext(p);
            prev = p;
            p.mass = 1.0 / (double)nbody;

            seed = BH.myRand(seed);
            double t1 = BH.xRand(0.0, 0.999, seed);
            t1 = Math.Pow(t1, (-2.0 / 3.0)) - 1.0;
            double r = 1.0 / Math.Sqrt(t1);

            double coeff = 4.0;
            for (int k = 0; k < MathVector.NDIM; k++)
            {
                seed = BH.myRand(seed);
                r = BH.xRand(0.0, 0.999, seed);
                p.pos.setValue(k, coeff * r);
            }

            cmr.addition(p.pos);

            double x = 0.0;
            double y = 0.0;
            do
            {
                seed = BH.myRand(seed);
                x = BH.xRand(0.0, 1.0, seed);
                seed = BH.myRand(seed);
                y = BH.xRand(0.0, 0.1, seed);
            } while (y > x * x * Math.Pow(1.0 - x * x, 3.5));

            double v = Math.Sqrt(2.0) * x / Math.Pow(1.0 + r * r, 0.25);

            double rad = vsc * v;
            double rsq = 0.0;
            do
            {
                for (var k = 0; k < MathVector.NDIM; k++)
                {
                    seed = BH.myRand(seed);
                    p.vel.setValue(k, BH.xRand(-1.0, 1.0, seed));
                }
                rsq = p.vel.dotProduct();
            } while (rsq > 1.0);
            double rsc1 = rad / Math.Sqrt(rsq);
            p.vel.multScalar1(rsc1);
            cmv.addition(p.vel);
        }

        // mark end of list
        prev.setNext(null);
        // toss the dummy node at the beginning and set a reference to the first element
        bodyTab = head.getNext();

        cmr.divScalar((double)nbody);
        cmv.divScalar((double)nbody);

        prev = null;

        Body current = bodyTab;
        while (current != null)
        {
            current.pos.subtraction1(cmr);
            current.vel.subtraction1(cmv);
            current.setProcNext(prev);
            prev = current;
            current = current.getNext();
        }

        // set the reference to the last element
        bodyTabRev = prev;
    }
}
