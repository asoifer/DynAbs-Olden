using System;

public partial class Edge
{
    //***************************************************************/
    //	Quad-edge manipulation primitives
    //***************************************************************/
    internal virtual void swapedge()
    {
        Edge a = oPrev();
        Edge syme = symmetric();
        Edge b = syme.oPrev();
        splice(a);
        syme.splice(b);
        Edge lnexttmp = a.lNext();
        splice(lnexttmp);
        lnexttmp = b.lNext();
        syme.splice(lnexttmp);
        Vertex a1 = a.dest();
        Vertex b1 = b.dest();
        setOrig(a1);
        setDest(b1);
    }

    internal virtual void splice(Edge b)
    {
        Edge alpha = oNext().rotate();
        Edge beta = b.oNext().rotate();
        Edge t1 = beta.oNext();
        Edge temp = alpha.oNext();
        alpha.setNext(t1);
        beta.setNext(temp);
        temp = oNext();
        t1 = b.oNext();
        b.setNext(temp);
        setNext(t1);
    }

    internal virtual bool valid(Edge basel)
    {
        Vertex t1 = basel.orig();
        Vertex t3 = basel.dest();
        Vertex t2 = dest();
        return t1.ccw(t2, t3);
    }

    internal virtual void deleteEdge()
    {
        Edge f = oPrev();
        splice(f);
        f = symmetric().oPrev();
        symmetric().splice(f);
    }

    internal static EdgePair doMerge(Edge ldo, Edge ldi, Edge rdi, Edge rdo)
    {
        while (true)
        {
            Vertex t3 = rdi.orig();
            Vertex t1 = ldi.orig();
            Vertex t2 = ldi.dest();

            while (t1.ccw(t2, t3))
            {
                ldi = ldi.lNext();

                t1 = ldi.orig();
                t2 = ldi.dest();
            }

            t2 = rdi.dest();

            if (t2.ccw(t3, t1))
            {
                rdi = rdi.rPrev();
            }
            else
                break;
        }

        Edge basel = rdi.symmetric().connectLeft(ldi);

        Edge lcand = basel.rPrev();
        Edge rcand = basel.oPrev();
        Vertex t1_1 = basel.orig();
        Vertex t2_1 = basel.dest();

        if (t1_1 == rdo.orig())
            rdo = basel;
        if (t2_1 == ldo.orig())
            ldo = basel.symmetric();

        while (true)
        {
            Edge t = lcand.oNext();
            if (t.valid(basel))
            {
                Vertex v4 = basel.orig();

                Vertex v1 = lcand.dest();
                Vertex v3 = lcand.orig();
                Vertex v2 = t.dest();
                while (v1.incircle(v2, v3, v4))
                {
                    lcand.deleteEdge();
                    lcand = t;

                    t = lcand.oNext();
                    v1 = lcand.dest();
                    v3 = lcand.orig();
                    v2 = t.dest();
                }
            }

            t = rcand.oPrev();
            if (t.valid(basel))
            {
                Vertex v4 = basel.dest();
                Vertex v1 = t.dest();
                Vertex v2 = rcand.dest();
                Vertex v3 = rcand.orig();
                while (v1.incircle(v2, v3, v4))
                {
                    rcand.deleteEdge();
                    rcand = t;
                    t = rcand.oPrev();
                    v2 = rcand.dest();
                    v3 = rcand.orig();
                    v1 = t.dest();
                }
            }

            bool lvalid = lcand.valid(basel);

            bool rvalid = rcand.valid(basel);
            if ((!lvalid) && (!rvalid))
            {
                return new EdgePair(ldo, rdo);
            }

            Vertex v1_1 = lcand.dest();
            Vertex v2_1 = lcand.orig();
            Vertex v3_1 = rcand.orig();
            Vertex v4_1 = rcand.dest();
            if (!lvalid || (rvalid && v1_1.incircle(v2_1, v3_1, v4_1)))
            {
                basel = rcand.connectLeft(basel.symmetric());
                rcand = basel.symmetric().lNext();
            }
            else
            {
                basel = lcand.connectRight(basel).symmetric();
                lcand = basel.rPrev();
            }
        }
    }
}
