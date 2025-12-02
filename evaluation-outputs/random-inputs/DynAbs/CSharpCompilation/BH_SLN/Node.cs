using System;
public abstract class Node
{
public double mass;

public MathVector pos;

public static int IMAX ;

public static double EPS ;

public Node()
		{
			try
{DynAbs.Tracing.TraceSender.TraceEnterConstructor(7,439,535);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,186,190);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,248,251);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,460,470);

mass = -1;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,508,531);

pos = f_7_514_530();
DynAbs.Tracing.TraceSender.TraceExitConstructor(7,439,535);
}catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,439,535);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,439,535);
}
		}

public abstract Cell loadTree(Body p, MathVector xpic, int l, BTree root);

public abstract double hackcofm();

public abstract HG walkSubTree(double dsq, HG hg);

public static int oldSubindex(MathVector ic, int l)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterStaticMethod(7,709,917);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,768,778);

int 
i = 0
;
try {DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,790,795);
		for(int 
k = 0
; (DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,782,900) || true) && (k < MathVector.NDIM)
; DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,818,821)
,k++,DynAbs.Tracing.TraceSender.TraceExitCondition(7,782,900))

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,782,900);

if((DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,832,895) || true) && (((int)f_7_841_852(ic, k)& l) != 0)
)

{DynAbs.Tracing.TraceSender.TraceEnterCondition(7,832,895);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,869,895);

i += Cell.NSUB >> (k + 1);
DynAbs.Tracing.TraceSender.TraceExitCondition(7,832,895);
}
}
}catch(System.Exception) { DynAbs.Tracing.TraceSender.TraceExitLoopByException(7,1,119);
 throw; }finally{DynAbs.Tracing.TraceSender.TraceExitLoop(7,1,119);
}DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,904,913);

return i;
DynAbs.Tracing.TraceSender.TraceExitStaticMethod(7,709,917);

double
f_7_841_852(MathVector
this_param,int
i)
{
var return_v = this_param.value( i);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 841, 852);
return return_v;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,709,917);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,709,917);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public override string ToString()
		{
			try
	  {
DynAbs.Tracing.TraceSender.TraceEnterMethod(7,1039,1114);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1082,1108);

return DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (mass).ToString(),7,1089,1093)+ " : " + DynAbs.Tracing.TraceSender.TraceInvocationWrapper(() => (pos).ToString(),7,1104,1107);
DynAbs.Tracing.TraceSender.TraceExitMethod(7,1039,1114);
	  }
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,1039,1114);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,1039,1114);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

public HG gravSub(HG hg)
		{
			try
	{
DynAbs.Tracing.TraceSender.TraceEnterMethod(7,1186,1521);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1218,1251);

MathVector 
dr = f_7_1234_1250()
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1255,1285);

f_7_1255_1284(		dr, pos, hg.pos0);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1291,1335);

double 
drsq = f_7_1305_1320(dr)+ (EPS * EPS)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1339,1370);

double 
drabs = f_7_1354_1369(drsq)
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1376,1403);

double 
phii = mass / drabs
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1407,1423);

hg.phi0 -= phii;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1427,1453);

double 
mor3 = phii / drsq
;
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1457,1478);

f_7_1457_1477(		dr, mor3);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1482,1503);

f_7_1482_1502(		hg.acc0, dr);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,1507,1517);

return hg;
DynAbs.Tracing.TraceSender.TraceExitMethod(7,1186,1521);

MathVector
f_7_1234_1250()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 1234, 1250);
return return_v;
}


int
f_7_1255_1284(MathVector
this_param,MathVector
u,MathVector
v)
{
this_param.subtraction2( u, v);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 1255, 1284);
return 0;
}


double
f_7_1305_1320(MathVector
this_param)
{
var return_v = this_param.dotProduct();
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 1305, 1320);
return return_v;
}


double
f_7_1354_1369(double
d)
{
var return_v = Math.Sqrt( d);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 1354, 1369);
return return_v;
}


int
f_7_1457_1477(MathVector
this_param,double
s)
{
this_param.multScalar1( s);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 1457, 1477);
return 0;
}


int
f_7_1482_1502(MathVector
this_param,MathVector
u)
{
this_param.addition( u);
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 1482, 1502);
return 0;
}

	}
catch
{
DynAbs.Tracing.TraceSender.TraceEnterFinalCatch(7,1186,1521);
throw;
}
finally
{
DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,1186,1521);
}
			throw new System.Exception("Slicer error: unreachable code");
		}

static Node()
{
DynAbs.Tracing.TraceSender.TraceEnterStaticConstructor(7,107,1524);
DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,305,322);
IMAX = 1073741824;DynAbs.Tracing.TraceSender.TraceSimpleStatement(7,384,394);
EPS = 0.05;DynAbs.Tracing.TraceSender.TraceExitStaticConstructor(7,107,1524);

DynAbs.Tracing.TraceSender.TraceEnterFinalFinally(7,107,1524);
}

		int ___ignore_me___=DynAbs.Tracing.TraceSender.TraceBeforeConstructor(7,107,1524);

static MathVector
f_7_514_530()
{
var return_v = new MathVector();
DynAbs.Tracing.TraceSender.TraceEndInvocation(7, 514, 530);
return return_v;
}

}
