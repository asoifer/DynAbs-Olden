


//
// A class that represents a voronoi diagram.  The diagram is represnted
// as a binary tree of points.
//
public partial class Vertex : Vec2
{
	//
    // The left child of the tree that represents the voronoi diagram.
    //
	internal Vertex left;

	//
    // The right child of the tree that represents the voronoi diagram.
    //
	internal Vertex right;

	public Vertex()
	{
	}

	public Vertex(double x, double y)
		: base(x, y)
	{
		left = null;
		right = null;
	}

	public virtual void setLeft(Vertex l)
	{
		left = l;
	}

	public virtual void setRight(Vertex r)
	{
		right = r;
	}

	public virtual Vertex getLeft()
	{
		return left;
	}

	public virtual Vertex getRight()
	{
		return right;
	}

	// 
   // Builds delaunay triangulation.
   //
	internal virtual Edge buildDelaunayTriangulation(Vertex extra)
	{
		EdgePair retVal = buildDelaunay(extra);
		return retVal.getLeft();
	}

	//
    // Recursive delaunay triangulation procedure
    // Contains modifications for axis-switching division.
    //
	internal virtual EdgePair buildDelaunay(Vertex extra)
	{
		EdgePair retval = null;
		if (getRight() != null && getLeft() != null)
		{
			// more than three elements; do recursion
			Vertex minx = getLow();
			Vertex maxx = extra;
			
			EdgePair delright = getRight().buildDelaunay(extra);
			EdgePair delleft = getLeft().buildDelaunay(this);
			
			retval = Edge.doMerge(delleft.getLeft(), delleft.getRight(), delright.getLeft(), delright.getRight());
			
			Edge ldo = retval.getLeft();
			while (ldo.orig() != minx)
			{
				ldo = ldo.rPrev();
			}
			Edge rdo = retval.getRight();
			while (rdo.orig() != maxx)
			{
				rdo = rdo.lPrev();
			}
			
			retval = new EdgePair(ldo, rdo);
			
		}
		else if (getLeft() == null)
		{			
			// two points
			Edge a = Edge.makeEdge(this, extra);
			retval = new EdgePair(a, a.symmetric());
		}
		else
		{
			// left, !right  three points
			// 3 cases: triangles of 2 orientations, and 3 points on a line. */
			Vertex s1 = getLeft();
			Vertex s2 = this;
			Vertex s3 = extra;
			Edge a = Edge.makeEdge(s1, s2);
			Edge b = Edge.makeEdge(s2, s3);
			a.symmetric().splice(b);
			Edge c = b.connectLeft(a);
			if (s1.ccw(s3, s2))
			{
				retval = new EdgePair(c.symmetric(), c);
			}
			else
			{
				retval = new EdgePair(a, b.symmetric());
				if (s1.ccw(s2, s3))
					c.deleteEdge();
			}
		}
		return retval;
	}

	//
    // Print the tree
    //
	internal virtual void print()
	{
		Vertex tleft;
		Vertex tright;
		
		System.Console.WriteLine("X=" + X() + " Y=" + Y());
		if (left == null)
			System.Console.WriteLine("NULL");
		else
			left.print();
		if (right == null)
			System.Console.WriteLine("NULL");
		else
			right.print();
	}

	//
    // Traverse down the left child to the end
    //
	internal virtual Vertex getLow()
	{
		Vertex temp;
		Vertex tree = this;
		
		while ((temp = tree.getLeft()) != null)
			tree = temp;
		return tree;
	}
}
