
using System;

//
// A Java implementation of the <tt>power</tt> Olden benchmark.
// The original algorithm is from the following paper:
// <p><cite>
// S. Lumetta, L. Murphy, X. Li, D. Culler, and I. Khalil.
// "Decentralized optimal power pricing: The development of a parallel
// program."  Supercomputing '93, 243-249
// </cite>
// <p/>
// Note - the number of customers is fixed at 10,000 for this
// benchmark.  We create a data structure that contains 1 root (the
// (power substation).  There are 10 main feeders from the root and
// each feeder branches to 20 lateral nodes.  Each lateral node is the
// head of a line of five branch nodes and each branch has 10
// customers.  In total, there are 10,000 customers (and 1201 internal
// nodes).
// <p/>
// The power pricing problems sets the price of each customer's power
// consumption so that the economic efficiency of the whole community
// is maximized.
//
public class Power
{
    //
    // The number of feeders off of the root
    //
    static int feeders = 0;
    //
    // The number of lateral nodes per feeder
    //
    static int laterals = 0;
    //
    // The number of branches per lateral
    //
    static int branches = 0;
    //
    // The number of leaves per branch
    //
    static int leaves = 0;
    //
    // Should we print the results as we run the benchmark
    //
    static bool printResults = false;
	//
    // Print information messages?
    //
    static bool printMsgs = false;

	//
	// The main routine which creates the power network and runs the simulation
	// @param args the command line args
	//
	public static void Main(String[] args)
	{
		// the input size is fixed, but the user may want the result printed
		parseCmdLine(args);

		// initial pass
		var start0 = System.DateTime.Now;
		Root r = Root.createRoot(feeders, laterals, branches, leaves);
		var end0 = System.DateTime.Now;
		
		var start1 = System.DateTime.Now;
		r.compute();
		r.nextIter(false, 0.7, 0.14);

		while(true)
		{
			r.compute();
			if (printResults)
				Console.WriteLine(r.ToString());

			if(r.reachedLimit())
				break;

			r.nextIter(printResults);
		}

		var end1 = System.DateTime.Now;
		
		if (printMsgs) 
		{
		  Console.WriteLine("Power build time " + (end0.Subtract(start0).TotalMilliseconds)/1000.0);
		  Console.WriteLine("Power compute time " + (end1.Subtract(start1).TotalMilliseconds)/1000.0);
		  Console.WriteLine("Power total time " + (end1.Subtract(start0).TotalMilliseconds)/1000.0);
		}
        var slicingVariable1 = r.D.P;
        var slicingVariable2 = r.D.Q;
        var slicingVariable3 = r.theta_I;
        var slicingVariable4 = r.theta_R;
        System.Console.WriteLine("Done!");
	}

	//
    //  Parse the command line options.
    // @param args the command line options.
    //
	private static void parseCmdLine(String[] args)
	{
		int i = 0;
		String arg;

		while(i < args.Length && args[i].StartsWith("-"))
		{
			arg = args[i++];
			if(arg.Equals("-h"))
			{
				usage();
			}
            else if (arg.Equals("-f"))
            {
                if (i < args.Length)
                    feeders = Int32.Parse(args[i++]);
                else
                    throw new Exception("-f the number of feeders off of the root");
            }
            else if (arg.Equals("-l"))
            {
                if (i < args.Length)
                    laterals = Int32.Parse(args[i++]);
                else
                    throw new Exception("-l the number of lateral nodes per feeder");
            }
            else if (arg.Equals("-b"))
            {
                if (i < args.Length)
                    branches = Int32.Parse(args[i++]);
                else
                    throw new Exception("-b the number of branches per lateral");
            }
            else if (arg.Equals("-e"))
            {
                if (i < args.Length)
                    leaves = Int32.Parse(args[i++]);
                else
                    throw new Exception("-e the number of leaves per branch");
            }
            else if(arg.Equals("-p"))
			{
				printResults = true;
			}
			else if (arg.Equals("-m")) 
		    {
				printMsgs = true;
		    }
		}
	}

	//
	// The usage routine which describes the program options.
	//
	private static void usage()
	{
		Console.WriteLine("usage: java Power -f <feeders> -l <laterals> -b <branches> -e <leaves> [-p] [-m] [-h]");
        Console.WriteLine("    -f the number of feeders off of the root");
        Console.WriteLine("    -l the number of lateral nodes per feeder");
        Console.WriteLine("    -b the number of branches per lateral");
        Console.WriteLine("    -e the number of leaves per branch");
        Console.WriteLine("    -p (print results)");
		Console.WriteLine("    -m (print informative messages)");
		Console.WriteLine("    -h (this message)");
		System.Environment.Exit(0);
	}
}
