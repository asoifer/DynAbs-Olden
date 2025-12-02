
using System;
public class Power
{
static int feeders ;

static int laterals ;

static int branches ;

static int leaves ;

static bool printResults ;

static bool printMsgs ;

public static void Main(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(5,1657,2783);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1775,1794);

f_5_1775_1793(args);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1819,1852);

var 
start0 = System.DateTime.Now
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1856,1911);

Root 
r = f_5_1865_1910(feeders, laterals, branches, leaves)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1915,1946);

var 
end0 = System.DateTime.Now
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1954,1987);

var 
start1 = System.DateTime.Now
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1991,2003);

f_5_1991_2002(		r);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2007,2036);

f_5_2007_2035(		r, false, 0.7, 0.14);
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2042,2211) || true) && (true)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2042,2211);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2063,2075);

f_5_2063_2074(			r);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2080,2135) || true) && (printResults)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2080,2135);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2103,2135);

f_5_2103_2134(f_5_2121_2133(r));
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2080,2135);
}

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2142,2174) || true) && (f_5_2145_2161(r))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2142,2174);
DynAbs.Tracing.TraceSender.TraceBreak(5,2168,2174);

break;
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2142,2174);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2181,2206);

f_5_2181_2205(
			r, printResults);
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2042,2211);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(5,2042,2211);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(5,2042,2211);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2217,2248);

var 
end1 = System.DateTime.Now
;

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2256,2571) || true) && (printMsgs)
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2256,2571);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2282,2372);

f_5_2282_2371("Power build time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((end0.Subtract(start0).TotalMilliseconds)/1000.0).ToString(),5,2322,2370));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2378,2470);

f_5_2378_2469("Power compute time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((end1.Subtract(start1).TotalMilliseconds)/1000.0).ToString(),5,2420,2468));
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2476,2566);

f_5_2476_2565("Power total time " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => ((end1.Subtract(start0).TotalMilliseconds)/1000.0).ToString(),5,2516,2564));
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2256,2571);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2581,2610);

var 
slicingVariable1 = r.D.P
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2620,2649);

var 
slicingVariable2 = r.D.Q
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2659,2692);

var 
slicingVariable3 = r.theta_I
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2702,2735);

var 
slicingVariable4 = r.theta_R
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2745,2779);

f_5_2745_2778("Done!");
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(5,1657,2783);

int
f_5_1775_1793(string[]
args)
{
parseCmdLine( args);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1775, 1793);
return 0;
}


Root
f_5_1865_1910(int
nfeeders,int
nlaterals,int
nbranches,int
nleaves)
{
var return_v = new Root( nfeeders, nlaterals, nbranches, nleaves);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1865, 1910);
return return_v;
}


int
f_5_1991_2002(Root
this_param)
{
this_param.compute();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 1991, 2002);
return 0;
}


int
f_5_2007_2035(Root
this_param,bool
verbose,double
new_theta_R,double
new_theta_I)
{
this_param.nextIter( verbose, new_theta_R, new_theta_I);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2007, 2035);
return 0;
}


int
f_5_2063_2074(Root
this_param)
{
this_param.compute();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2063, 2074);
return 0;
}


string
f_5_2121_2133(Root
this_param)
{
var return_v = this_param.ToString();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2121, 2133);
return return_v;
}


int
f_5_2103_2134(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2103, 2134);
return 0;
}


bool
f_5_2145_2161(Root
this_param)
{
var return_v = this_param.reachedLimit();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2145, 2161);
return return_v;
}


int
f_5_2181_2205(Root
this_param,bool
verbose)
{
this_param.nextIter( verbose);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2181, 2205);
return 0;
}


int
f_5_2282_2371(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2282, 2371);
return 0;
}


int
f_5_2378_2469(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2378, 2469);
return 0;
}


int
f_5_2476_2565(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2476, 2565);
return 0;
}


int
f_5_2745_2778(string
value)
{
System.Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2745, 2778);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,1657,2783);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,1657,2783);
}
		}

private static void parseCmdLine(String[] args)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(5,2888,4336);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2943,2953);

int 
i = 0
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2957,2968);

String 
arg
=default(String);
try {
while((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,2974,4332) || true) && (i < f_5_2984_2995(args)&&(DynAbs.Tracing.TraceSender.Expression_True(5, 2980, 3022)&&f_5_2999_3022(args[i], "-")))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,2974,4332);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3033,3049);

arg = args[i++];

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3054,4327) || true) && (f_5_3057_3073(arg, "-h"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3054,4327);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3086,3094);

f_5_3086_3093();
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3054,4327);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3054,4327);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3119,4327) || true) && (f_5_3123_3139(arg, "-f"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3119,4327);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3173,3356) || true) && (i < f_5_3181_3192(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3173,3356);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3215,3248);

feeders = f_5_3225_3247(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3173,3356);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3173,3356);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3292,3356);

throw f_5_3298_3355("-f the number of feeders off of the root");
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3173,3356);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3119,4327);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3119,4327);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3390,4327) || true) && (f_5_3394_3410(arg, "-l"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3390,4327);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3444,3629) || true) && (i < f_5_3452_3463(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3444,3629);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3486,3520);

laterals = f_5_3497_3519(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3444,3629);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3444,3629);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3564,3629);

throw f_5_3570_3628("-l the number of lateral nodes per feeder");
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3444,3629);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3390,4327);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3390,4327);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3663,4327) || true) && (f_5_3667_3683(arg, "-b"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3663,4327);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3717,3898) || true) && (i < f_5_3725_3736(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3717,3898);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3759,3793);

branches = f_5_3770_3792(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3717,3898);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3717,3898);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3837,3898);

throw f_5_3843_3897("-b the number of branches per lateral");
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3717,3898);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3663,4327);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3663,4327);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3932,4327) || true) && (f_5_3936_3952(arg, "-e"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3932,4327);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,3986,4162) || true) && (i < f_5_3994_4005(args))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3986,4162);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4028,4060);

leaves = f_5_4037_4059(args[i++]);
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3986,4162);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3986,4162);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4104,4162);

throw f_5_4110_4161("-e the number of leaves per branch");
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3986,4162);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3932,4327);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,3932,4327);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4196,4327) || true) && (f_5_4199_4215(arg, "-p"))
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,4196,4327);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4228,4248);

printResults = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(5,4196,4327);
}

else 
{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,4196,4327);

if ((DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4264,4327) || true) && (f_5_4268_4284(arg, "-m"))
) 

{DynAbs.Tracing.TraceSender.TraceEnterCondition(5,4264,4327);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4301,4318);

printMsgs = true;
DynAbs.Tracing.TraceSender.TraceExitCondition(5,4264,4327);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,4196,4327);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3932,4327);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3663,4327);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3390,4327);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3119,4327);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,3054,4327);
}
DynAbs.Tracing.TraceSender.TraceExitCondition(5,2974,4332);
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(5,2974,4332);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(5,2974,4332);
}DynAbs.Tracing.TraceSender.TraceExitStaticMethod(5,2888,4336);

int
f_5_2984_2995(string[]
this_param)
{
var return_v = this_param.Length ;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 2984, 2995);
return return_v;
}


bool
f_5_2999_3022(string
this_param,string
value)
{
var return_v = this_param.StartsWith( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 2999, 3022);
return return_v;
}


bool
f_5_3057_3073(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3057, 3073);
return return_v;
}


int
f_5_3086_3093()
{
usage();
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3086, 3093);
return 0;
}


bool
f_5_3123_3139(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3123, 3139);
return return_v;
}


int
f_5_3181_3192(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 3181, 3192);
return return_v;
}


int
f_5_3225_3247(string
s)
{
var return_v = Int32.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3225, 3247);
return return_v;
}


System.Exception
f_5_3298_3355(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3298, 3355);
return return_v;
}


bool
f_5_3394_3410(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3394, 3410);
return return_v;
}


int
f_5_3452_3463(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 3452, 3463);
return return_v;
}


int
f_5_3497_3519(string
s)
{
var return_v = Int32.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3497, 3519);
return return_v;
}


System.Exception
f_5_3570_3628(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3570, 3628);
return return_v;
}


bool
f_5_3667_3683(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3667, 3683);
return return_v;
}


int
f_5_3725_3736(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 3725, 3736);
return return_v;
}


int
f_5_3770_3792(string
s)
{
var return_v = Int32.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3770, 3792);
return return_v;
}


System.Exception
f_5_3843_3897(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3843, 3897);
return return_v;
}


bool
f_5_3936_3952(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 3936, 3952);
return return_v;
}


int
f_5_3994_4005(string[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(5, 3994, 4005);
return return_v;
}


int
f_5_4037_4059(string
s)
{
var return_v = Int32.Parse( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4037, 4059);
return return_v;
}


System.Exception
f_5_4110_4161(string
message)
{
var return_v = new System.Exception( message);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4110, 4161);
return return_v;
}


bool
f_5_4199_4215(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4199, 4215);
return return_v;
}


bool
f_5_4268_4284(string
this_param,string
value)
{
var return_v = this_param.Equals( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4268, 4284);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,2888,4336);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,2888,4336);
}
		}

private static void usage()
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(5,4411,5046);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4446,4553);

f_5_4446_4552("usage: java Power -f <feeders> -l <laterals> -b <branches> -e <leaves> [-p] [-m] [-h]");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4563,4629);

f_5_4563_4628("    -f the number of feeders off of the root");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4639,4706);

f_5_4639_4705("    -l the number of lateral nodes per feeder");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4716,4779);

f_5_4716_4778("    -b the number of branches per lateral");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4789,4849);

f_5_4789_4848("    -e the number of leaves per branch");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4859,4903);

f_5_4859_4902("    -p (print results)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4907,4964);

f_5_4907_4963("    -m (print informative messages)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,4968,5011);

f_5_4968_5010("    -h (this message)");
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,5015,5042);

f_5_5015_5041(0);
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(5,4411,5046);

int
f_5_4446_4552(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4446, 4552);
return 0;
}


int
f_5_4563_4628(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4563, 4628);
return 0;
}


int
f_5_4639_4705(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4639, 4705);
return 0;
}


int
f_5_4716_4778(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4716, 4778);
return 0;
}


int
f_5_4789_4848(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4789, 4848);
return 0;
}


int
f_5_4859_4902(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4859, 4902);
return 0;
}


int
f_5_4907_4963(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4907, 4963);
return 0;
}


int
f_5_4968_5010(string
value)
{
Console.WriteLine( value);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 4968, 5010);
return 0;
}


int
f_5_5015_5041(int
exitCode)
{
System.Environment.Exit( exitCode);
DynAbs.Tracing.TraceSender.TraceEndInvocation(5, 5015, 5041);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(5,4411,5046);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,4411,5046);
}
		}

public Power()
{
DynAbs.Tracing.TraceSender.TraceEnterConstructor(5,947,5049);
DynAbs.Tracing.TraceSender.TraceExitConstructor(5,947,5049);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,947,5049);
}


static Power()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(5,947,5049);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1047,1058);
feeders = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1139,1151);
laterals = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1228,1240);
branches = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1314,1324);
leaves = 0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1419,1439);
printResults = false;DynAbs.Tracing.TraceSender.TraceSimpleStatement(5,1507,1524);
printMsgs = false;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(5,947,5049);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(5,947,5049);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(5,947,5049);
}
