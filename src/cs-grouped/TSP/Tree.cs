
using System;

//*
// A class that represents a node in a binary tree.  Each node represents
// a city in the TSP benchmark.
///
public partial class Tree
{
    //*
	// The number of nodes (cities) in this suTree
	///
    public int sz;
    //*
	// The coordinates that this node represents
	///
    public double x;
    public double y;

    //*
	// Left child of the tree
	///
    public Tree left;
    //*
	// Right child of tree
	///
    public Tree right;
    //*
	// The next pointer in a linked list of nodes in the suTree.  The list
	// contains the order of the cities to visit.
	///
    public Tree next;
	//*
	// The previous pointer in a linked list of nodes in the suTree. The list
	// contains the order of the cities to visit.
	///
	public Tree prev;

	//*
	// Construct a Tree node (a city) with the specified size
	// @param size  the number of nodes in the (sub)tree
	// @param x     the x coordinate of the city
	// @param y     the y coordinate of the city
	// @param left  the left suTree
	// @param right the right suTree
	///
	public Tree(int size, double x, double y, Tree l, Tree r)
	{
		sz = size;
		this.x = x;
		this.y = y;
		left = l;
		right = r;
		next = null;
		prev = null;
	}

	//*
	// Use closest-point heuristic from Cormen, Leiserson, and Rivest.
	// @return a
	///
	public Tree conquer()
	{
		// create the list of nodes
		Tree t = makeList();

		// Create initial cycle
		Tree cycle = t;
		t = t.next;
		cycle.next = cycle;
		cycle.prev = cycle;

		// Loop over remaining points
		Tree donext;
		for (; t != null; t = donext) 
		{
			donext = t.next; // value won't be around later */
			Tree min = cycle;
			double mindist = t.distance(cycle);
			for(Tree tmp = cycle.next; tmp != cycle; tmp = tmp.next)
			{
				double test = tmp.distance(t);
				if(test < mindist)
				{
					mindist = test;
					min = tmp;
				}
			}

			Tree next = min.next;
			Tree prev = min.prev;

			double mintonext = min.distance(next);
			double mintoprev = min.distance(prev);
			double ttonext = t.distance(next);
			double ttoprev = t.distance(prev);

			if((ttoprev - mintoprev) < (ttonext - mintonext))
			{
				// insert between min and prev */
				prev.next = t;
				t.next = min;
				t.prev = prev;
				min.prev = t;
			}
			else
			{
				next.prev = t;
				t.next = next;
				min.next = t;
				t.prev = min;
			}
		}

		return cycle;
	}

	//*
	// Merge two cycles as per Karp.
	// @param a a suTree with one cycle
	// @param b a suTree with the other cycle
	///
	public Tree merge(Tree a, Tree b)
	{
		// Compute location for first cycle
		Tree min = a;
		double mindist = distance(a);
		Tree tmp = a;
		for(a = a.next; a != tmp; a = a.next)
		{
			double temp_test = distance(a);
			if(temp_test < mindist)
			{
				mindist = temp_test;
				min = a;
			}
		}

		Tree next = min.next;
		Tree prev = min.prev;
		double mintonext = min.distance(next);
		double mintoprev = min.distance(prev);
		double ttonext = distance(next);
		double ttoprev = distance(prev);

		Tree p1;
		Tree n1;
		double tton1;
		double ttop1;
		if((ttoprev - mintoprev) < (ttonext - mintonext))
		{
			// would insert between min and prev
			p1 = prev;
			n1 = min;
			tton1 = mindist;
			ttop1 = ttoprev;
		}
		else
		{
			// would insert between min and next
			p1 = min;
			n1 = next;
			ttop1 = mindist;
			tton1 = ttonext;
		}

		// Compute location for second cycle
		min = b;
		mindist = distance(b);
		tmp = b;
		for(b = b.next; b != tmp; b = b.next)
		{
			double temp_test = distance(b);
			if(temp_test < mindist)
			{
				mindist = temp_test;
				min = b;
			}
		}

		next = min.next;
		prev = min.prev;
		mintonext = min.distance(next);
		mintoprev = min.distance(prev);
		ttonext = this.distance(next);
		ttoprev = this.distance(prev);

		Tree p2;
		Tree n2;
		double tton2;
		double ttop2;
		if((ttoprev - mintoprev) < (ttonext - mintonext))
		{
			// would insert between min and prev
			p2 = prev;
			n2 = min;
			tton2 = mindist;
			ttop2 = ttoprev;
		}
		else
		{
			// would insert between min andn ext
			p2 = min;
			n2 = next;
			ttop2 = mindist;
			tton2 = ttonext;
		}

		// Now we have 4 choices to complete:
		// 1:t,p1 t,p2 n1,n2
		// 2:t,p1 t,n2 n1,p2
		// 3:t,n1 t,p2 p1,n2
		// 4:t,n1 t,n2 p1,p2
		double n1ton2 = n1.distance(n2);
		double n1top2 = n1.distance(p2);
		double p1ton2 = p1.distance(n2);
		double p1top2 = p1.distance(p2);

		mindist = ttop1 + ttop2 + n1ton2;
		int choice = 1;

		double test = ttop1 + tton2 + n1top2;
		if(test < mindist)
		{
			choice = 2;
			mindist = test;
		}

		test = tton1 + ttop2 + p1ton2;
		if(test < mindist)
		{
			choice = 3;
			mindist = test;
		}

		test = tton1 + tton2 + p1top2;
		if(test < mindist)
			choice = 4;

		switch (choice)
		{
			case 1:
				// 1:p1,this this,p2 n2,n1 -- reverse 2!
				n2.reverse();
				p1.next = this;
				this.prev = p1;
				this.next = p2;
				p2.prev = this;
				n2.next = n1;
				n1.prev = n2;
				break;
			case 2:
				// 2:p1,this this,n2 p2,n1 -- OK
				p1.next = this;
				this.prev = p1;
				this.next = n2;
				n2.prev = this;
				p2.next = n1;
				n1.prev = p2;
				break;
			case 3:
				// 3:p2,this this,n1 p1,n2 -- OK
				p2.next = this;
				this.prev = p2;
				this.next = n1;
				n1.prev = this;
				p1.next = n2;
				n2.prev = p1;
				break;
			case 4:
				// 4:n1,this this,n2 p2,p1 -- reverse 1!
				n1.reverse();
				n1.next = this;
				this.prev = n1;
				this.next = n2;
				n2.prev = this;
				p2.next = p1;
				p1.prev = p2;
				break;
		}
		return this;
	}

	//*
	// Compute TSP for the tree t. Use conquer for problems <= sz
	// @param sz the cutoff point for using conquer vs. merge
	///
	public Tree tsp(int sz)
	{
		if(this.sz <= sz)
			return conquer();

		Tree leftval = left.tsp(sz);
		Tree rightval = right.tsp(sz);

		return merge(leftval, rightval);
	}
}
