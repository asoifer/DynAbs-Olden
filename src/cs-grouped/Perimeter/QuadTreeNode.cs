
//
// A class representing a node in the quad tree.
//
public abstract partial class QuadTreeNode
{
	//
	// The quadrant that this node represents (i.e., northwest, northeast,
	// southwest, or southeast).
	//
	public Quadrant quadrant;
	//
	// Node that represents the northwest quadrant of the image
	//
	public QuadTreeNode nw;
	//
	// Node that represents the northeast quadrant of the image
	//
	public QuadTreeNode ne;
	//
	// Node that represents the southwest quadrant of the image
	//
	public QuadTreeNode sw;
	//
	// Node that represents the southeast quadrant of the image
	//
	public QuadTreeNode se;
	//
	// Node that represents the parent quadrant of the image
	//
	public QuadTreeNode parent;

	// enumeration for direction
	public static int NORTH = 0;
	public static int EAST = 1;
	public static int SOUTH = 2;
	public static int WEST = 3;

	//
	// Create a leaf node in the Quad Tree.
	//
	// @param childType if there's a parent, the type of child this node represents
	// @param parent    the parent quad tree node
	//
	public QuadTreeNode(Quadrant quad, QuadTreeNode parent)
		: this(quad, null, null, null, null, parent)
	{ 
	}

	//
	// Create a node in the quad tree.
	//
	// @param childType if there's a parent, the type of child
	// @param nw        the node represent the northwest quadrant
	// @param ne        the node represent the northeast quadrant
	// @param sw        the node represent the southwest quadrant
	// @param se        the node represent the southeast quadrant
	//
	private QuadTreeNode(Quadrant quad, QuadTreeNode nw, QuadTreeNode ne, QuadTreeNode sw, QuadTreeNode se, QuadTreeNode parent)
	{
		this.quadrant = quad;
		this.nw = nw;
		this.ne = ne;
		this.sw = sw;
		this.se = se;
		this.parent = parent;
	}

	//
	// Set the children of the quad tree node.
	//
	// @param nw the node represent the northwest quadrant
	// @param ne the node represent the northeast quadrant
	// @param sw the node represent the southwest quadrant
	// @param se the node represent the southeast quadrant
	//
	public void setChildren(QuadTreeNode nw, QuadTreeNode ne, QuadTreeNode sw, QuadTreeNode se)
	{
		this.nw = nw;
		this.ne = ne;
		this.sw = sw;
		this.se = se;
	}

	//
	// Return the node representing the north west quadrant.
	// @return the node representing the north west quadrant.
	//
	public QuadTreeNode getNorthWest()
	{
		return nw;
	}
	//
	// Return the node representing the north east quadrant.
	// @return the node representing the north east quadrant.
	//
	public QuadTreeNode getNorthEast()
	{
		return ne;
	}
	//
	// Return the node representing the south west quadrant.
	// @return the node representing the south west quadrant.
	//
	public QuadTreeNode getSouthWest()
	{
		return sw;
	}
	//
	// Return the node representing the south east quadrant.
	// @return the node representing the south east quadrant.
	//
	public QuadTreeNode getSouthEast()
	{
		return se;
	}

	//
	// Compute the total perimeter of a binary image that is represented
	// as a quadtree using Samet's algorithm.
	//
	// @param size the size of the image that this node represents (size X size).
	// @return the size of the perimeter of the image.
	//
	abstract public int perimeter(int size);

	//
	// Sum the perimeter of all white leaves in the two specified
	// quadrants of the sub quad tree rooted at this node.
	//
	// @param quad1 the first specified quadrant
	// @param quad2 the second specified quadrant
	// @param size  the size of the image represented by this node.
	// @return the perimeter of the adjacent nodes
	//
	abstract public int sumAdjacent(Quadrant quad1, Quadrant quad2, int size);

	//
	// Return the neighbor of this node in the given direction which is
	// greater than or equal in size to this node.  If the node doesn't
	// exist, then a grey node of equal size is returned.  Otherwise,
	// the node is adjacent to the border of the image and null is
	// returned.
	//
	// @param dir the direction of the neighbor
	// @return the appropriate neighbor based upon the direction, or null
	//
	public QuadTreeNode gtEqualAdjNeighbor(int dir)
	{
		QuadTreeNode q;
		if(parent != null && quadrant.adjacent(dir))
		{
			q = parent.gtEqualAdjNeighbor(dir);
		}
		else
		{
			q = parent;
		}

		if(q != null && q is GreyNode)
		{
			return quadrant.reflect(dir).child(q);
		}
		else
		{
			return q;
		}
	}

	//
	// Count the number of leaves in the quad tree.
	// @return the number of leaves in the quad tree.
	//
	public int countTree()
	{
		if(nw == null && ne == null && sw == null && se == null)
		{
			return 1;
		}
		else
		{
			return sw.countTree() + se.countTree() + ne.countTree() + nw.countTree();
		}
	}
	
	public override string ToString() 
	{ 
		return this.GetType().Name + " " + quadrant.GetType().Name; 
	}
}
