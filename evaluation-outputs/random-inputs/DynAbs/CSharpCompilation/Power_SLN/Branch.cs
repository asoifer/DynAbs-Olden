using System;
public class Branch
{
private Demand D;

private double alpha ;

private double beta ;

private double R ;

private double X ;

private Branch nextBranch;

Leaf[] leaves;

public Branch(int num, int nleaves)
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(1,1069,1349);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,450,451);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,470,481);
this.alpha = 0.0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,500,510);
this.beta = 0.0;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,529,539);
this.R = 0.0001;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,558,569);
this.X = 0.00002;DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,675,685);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,771,777);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1112,1129);

D = f_1_1116_1128();

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1135,1225) || true) && (num <= 1)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1135,1225);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1152,1170);

nextBranch = null;
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1135,1225);
}

else

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1135,1225);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1183,1225);

nextBranch = f_1_1196_1224(num - 1, nleaves);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1135,1225);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1254,1281);

leaves = new Leaf[nleaves];
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1293,1298);
		for(int 
k = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1285,1345) || true) && (k < nleaves)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1313,1316)
,k++,DynAbs.Tracing.TraceSender.TraceExitCondition(1,1285,1345))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1285,1345);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1322,1345);

leaves[k] = f_1_1334_1344();
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1,61);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1,61);
}DynAbs.Tracing.TraceSender.TraceExitConstructor(1,1069,1349);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1069,1349);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1069,1349);
}
		}

public Demand compute(double theta_R, double theta_I, double pi_R, double pi_I)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(1,1676,2666);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1763,1826);

double 
new_pi_R = pi_R + alpha * (theta_R + (theta_I * X) / R)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1830,1892);

double 
new_pi_I = pi_I + beta * (theta_I + (theta_R * R) / X)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1898,1915);

Demand 
a1 = null
;

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1919,2008) || true) && (nextBranch != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,1919,2008);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,1946,2008);

a1 = f_1_1951_2007(nextBranch, theta_R, theta_I, new_pi_R, new_pi_I);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,1919,2008);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2065,2075);

f_1_2065_2074(
		// Initialize and pass the prices down the tree
		D);
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2087,2092);
		for(int 
i = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2079,2175) || true) && (i < f_1_2098_2111(leaves))
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2113,2116)
,++i,DynAbs.Tracing.TraceSender.TraceExitCondition(1,2079,2175))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2079,2175);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2122,2175);

f_1_2122_2174(			D, f_1_2134_2173((leaves[i]), new_pi_R, new_pi_I));
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(1,1,97);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(1,1,97);
}
if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2181,2224) || true) && (nextBranch != null)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(1,2181,2224);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2208,2224);

f_1_2208_2223(			D, a1);
DynAbs.Tracing.TraceSender.TraceExitCondition(1,2181,2224);
}
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2257,2282);

double 
a = R * R + X * X
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2286,2339);

double 
b = 2.0 * R * X * D.Q - 2.0 * X * X * D.P - R
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2343,2372);

double 
c = R * D.Q - X * D.P
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2376,2396);

c = c * c + R * D.P;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2400,2464);

double 
root = (-b - f_1_2420_2450(b * b - 4.0 * a * c)) / (2.0 * a)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2468,2503);

D.Q = D.Q + ((root - D.P) * X) / R;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2507,2518);

D.P = root;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2548,2566);

a = 2.0 * R * D.P;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2570,2588);

b = 2.0 * X * D.Q;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2592,2618);

alpha = a / (1.0 - a - b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2622,2647);

beta = b / (1.0 - a - b);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(1,2653,2662);

return D;
DynAbs.Tracing.TraceSender.TraceExitMethod(1,1676,2666);

Demand
f_1_1951_2007(Branch
this_param,double
theta_R,double
theta_I,double
pi_R,double
pi_I)
{
var return_v = this_param.compute( theta_R, theta_I, pi_R, pi_I);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1951, 2007);
return return_v;
}


int
f_1_2065_2074(Demand
this_param)
{
this_param.reset();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2065, 2074);
return 0;
}


int
f_1_2098_2111(Leaf[]
this_param)
{
var return_v = this_param.Length;
DynAbs.Tracing.TraceSender.TraceEndMemberAccess(1, 2098, 2111);
return return_v;
}


Demand
f_1_2134_2173(Leaf
this_param,double
pi_R,double
pi_I)
{
var return_v = this_param.compute( pi_R, pi_I);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2134, 2173);
return return_v;
}


int
f_1_2122_2174(Demand
this_param,Demand
frm)
{
this_param.increment( frm);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2122, 2174);
return 0;
}


int
f_1_2208_2223(Demand
this_param,Demand
frm)
{
this_param.increment( frm);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2208, 2223);
return 0;
}


double
f_1_2420_2450(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 2420, 2450);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(1,1676,2666);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,1676,2666);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Branch()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(1,340,2669);
DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(1,340,2669);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(1,340,2669);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(1,340,2669);

static Demand
f_1_1116_1128()
{
var return_v = new Demand();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1116, 1128);
return return_v;
}


static Branch
f_1_1196_1224(int
num,int
nleaves)
{
var return_v = new Branch( num, nleaves);
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1196, 1224);
return return_v;
}


static Leaf
f_1_1334_1344()
{
var return_v = new Leaf();
DynAbs.Tracing.TraceSender.TraceEndInvocation(1, 1334, 1344);
return return_v;
}

}
