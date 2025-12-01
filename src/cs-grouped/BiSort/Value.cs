
//
// A class that represents a value to be sorted by the <tt>BiSort</tt>
// algorithm.  We represents a values as a node in a binary tree.
///
public partial class Value
{
	public int value;
	public Value left;
	public Value right;

	public static bool FORWARD = false;
	public static bool BACKWARD = true;

	public static int RANGE = 100;

	//*
	// Constructor for a node representing a value in the bitonic sort tree.
	// @param v the integer value which is the sort key
	///
	public Value(int v)
	{
		value = v;
		left = null;
		right = null;
	}

	//*
	// Perform a bitonic sort based upon the Bilardi and Nicolau algorithm.
	//
	// @param spr_val   the "spare" value in the algorithm.
	// @param direction the direction of the sort (forward or backward)
	// @return the new "spare" value.
	///
	public int bisort(int spr_val, bool direction)
	{
		if(left == null)
		{
			if((value > spr_val) ^ direction)
			{
				int tmpval = spr_val;
				spr_val = value;
				value = tmpval;
			}
		}
		else
		{
			int val = value;
			value = left.bisort(val, direction);
			bool ndir = !direction;
			spr_val = right.bisort(spr_val, ndir);
			spr_val = bimerge(spr_val, direction);
		}
		return spr_val;
	}

	//*
	// Perform the merge part of the bitonic sort.  The merge part does
	// the actualy sorting.
	// @param spr_val   the "spare" value in the algorithm.
	// @param direction the direction of the sort (forward or backward)
	// @return the new "spare" value
	///
	public int bimerge(int spr_val, bool direction)
	{
		int rv = value;
		Value pl = left;
		Value pr = right;

		bool rightexchange = (rv > spr_val) ^ direction;
		if(rightexchange)
		{
			value = spr_val;
			spr_val = rv;
		}

		while(pl != null)
		{
			int lv = pl.value;
			Value pll = pl.left;
			Value plr = pl.right;
			rv = pr.value;
			Value prl = pr.left;
			Value prr = pr.right;

			bool elementexchange = (lv > rv) ^ direction;
			if(rightexchange)
			{
				if(elementexchange)
				{
					pl.swapValRight(pr);
					pl = pll;
					pr = prl;
				}
				else
				{
					pl = plr;
					pr = prr;
				}
			}
			else
			{
				if(elementexchange)
				{
					pl.swapValLeft(pr);
					pl = plr;
					pr = prr;
				}
				else
				{
					pl = pll;
					pr = prl;
				}
			}
		}

		if(left != null)
		{
			value = left.bimerge(value, direction);
			spr_val = right.bimerge(spr_val, direction);
		}
		return spr_val;
	}
}
