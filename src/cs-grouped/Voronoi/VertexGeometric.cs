using System;
using System.Collections.Generic;
using System.Text;

public partial class Vertex
{
    //**************************************************************/
    //	Geometric primitives
    //***************************************************************/
    internal virtual bool incircle(Vertex b, Vertex c, Vertex d)
    // incircle, as in the Guibas-Stolfi paper. */
    {
        double adx;
        double ady;
        double bdx;
        double bdy;
        double cdx;
        double cdy;
        double dx;
        double dy;
        double anorm;
        double bnorm;
        double cnorm;
        double dnorm;
        double dret;
        Vertex loc_a;
        Vertex loc_b;
        Vertex loc_c;
        Vertex loc_d;

        int donedx;
        int donedy;
        int donednorm;
        loc_d = d;
        dx = loc_d.X();
        dy = loc_d.Y();
        dnorm = loc_d.Norm();
        loc_a = this;
        adx = loc_a.X() - dx;
        ady = loc_a.Y() - dy;
        anorm = loc_a.Norm();
        loc_b = b;
        bdx = loc_b.X() - dx;
        bdy = loc_b.Y() - dy;
        bnorm = loc_b.Norm();
        loc_c = c;
        cdx = loc_c.X() - dx;
        cdy = loc_c.Y() - dy;
        cnorm = loc_c.Norm();
        dret = (anorm - dnorm) * (bdx * cdy - bdy * cdx);
        dret += (bnorm - dnorm) * (cdx * ady - cdy * adx);
        dret += (cnorm - dnorm) * (adx * bdy - ady * bdx);
        return ((0.0 < dret) ? true : false);
    }

    internal virtual bool ccw(Vertex b, Vertex c)
    // TRUE iff this, B, C form a counterclockwise oriented triangle */
    {
        double dret;
        double xa;
        double ya;
        double xb;
        double yb;
        double xc;
        double yc;
        Vertex loc_a;
        Vertex loc_b;
        Vertex loc_c;

        int donexa;
        int doneya;
        int donexb;
        int doneyb;
        int donexc;
        int doneyc;

        loc_a = this;
        xa = loc_a.X();
        ya = loc_a.Y();
        loc_b = b;
        xb = loc_b.X();
        yb = loc_b.Y();
        loc_c = c;
        xc = loc_c.X();
        yc = loc_c.Y();
        dret = (xa - xc) * (yb - yc) - (xb - xc) * (ya - yc);
        return ((dret > 0.0) ? true : false);
    }
}
