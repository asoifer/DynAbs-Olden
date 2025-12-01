
//
// An abstract class that represents a quadrant in the image.
// The quadrants specify the NW, NE, SW, and SE parts of the
// image.
//
public abstract class Quadrant
{
	static Quadrant _cNorthWest = new NorthWest();
	static Quadrant _cNorthEast = new NorthEast();
	static Quadrant _cSouthWest = new SouthWest();
	static Quadrant _cSouthEast = new SouthEast();

    public static Quadrant cNorthWest 
	{ 
		get 
		{ 
			return _cNorthWest; 
		} 
		set 
		{ 
			_cNorthWest = value; 
		} 
	}
    public static Quadrant cNorthEast
    {
        get
        {
            return _cNorthEast;
        }
        set
        {
            _cNorthEast = value;
        }
    }
    public static Quadrant cSouthWest
    {
        get
        {
            return _cSouthWest;
        }
        set
        {
            _cSouthWest = value;
        }
    }
    public static Quadrant cSouthEast
    {
        get
        {
            return _cSouthEast;
        }
        set
        {
            _cSouthEast = value;
        }
    }

    //
    // Return true iff this quadrant is adjacent to the boundary
    // of an image in the given direction.
    // @param direction the image boundary
    // @return true if the quadrant is adjacent, false otherwise.
    //
    abstract public bool adjacent(int direction);
	//
	// Return the quadrant of a block of equal size that is
	// adjacent to the given side of this quadrant.
	// @param direction the image boundary
	// @return the reflected quadrant
	//
	abstract public Quadrant reflect(int direction);
	//
	// Return the child that represents this quadrant of the given
	// node.
	// @param node the node that we want the child from.
	// @return the child node representing this quadrant
	//
	abstract public QuadTreeNode child(QuadTreeNode node);
}
