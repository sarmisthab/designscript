﻿using System;
using NUnit.Framework;
using ProtoTestFx;

namespace ProtoTest.DebugTests
{
    [TestFixture]
    public class RunEqualityTests
    {
        [Test]
        [Category("Debugger")]
        public void DebugEQTestStepInVsStepOver_IDE618_01()
        {
            String src =
                @" 
class test
{
    def foo()
    {
        return = 0;
    }
}
x = { 1, 2 };
y = test.test();
x[y.foo()] = 3;
a = x;
 ";
            DebugTestFx.CompareDebugAndRunResults(src);
        }

        [Test]
        [Category("Debugger")]
        public void DebugEQTestStepInVsStepOver_IDE618_02()
        {
            String src =
                @" 
class test{
    
    constructor test()
    {
    }
    def foo()
    {
        return = { 1, 2 };
    }
}
a = test.test();
t = a.foo()[0];
 ";
            DebugTestFx.CompareDebugAndRunResults(src);
        }

        [Test]
        [Category("Debugger")]
        public void DebugEQTestStepInVsStepOver_IDE618_03()
        {
            String src =
                @" 
class test
{
    def foo(y : int[])
    {
        return = y;
    }
}
x = { };
y = test.test();
a = y.foo({ 0, 1 });
x[y.foo({ 0, 1 })] = 3;
z = x;
 ";
            DebugTestFx.CompareDebugAndRunResults(src);
        }

        [Test]
        [Category("Debugger")]
        public void DebugEQTestStepInVsStepOver_IDE618_04()
        {
            String src =
                @" 
class A
{
    a : var;
    constructor A(i : int)
    {
        a = i;
    }
    def foo(b)
    {
        return = a * b;
    }
}
def power(a)
{
    return = a * a;
}

a = A.A(-1);
b = A.A(0);
c = A.A(2);
x1 = a.a < a.foo(2) ? a.a : a.foo(2);
x2 = a.a >= a.foo(2) ? a.a : a.foo(2);
x3 = a.foo(power(3)) < power(b.foo(3)) ? a.foo(power(3)) : power(b.foo(3));
x4 = a.foo(power(3)) >= power(b.foo(3)) ? a.foo(power(3)) : power(b.foo(3));
 ";
            DebugTestFx.CompareDebugAndRunResults(src);
        }

        [Test]
        [Category("Debugger")]
        public void DebugEQTestStepInVsStepOver_IDE618_05()
        {
            String src =
                @" 
class MyPoint
{
        X : double;
        Y : double;
        Z : double;
                                
    constructor MyPoint (x : double, y : double, z : double)
    {
                X = x;
                Y = y;
                Z = z;
    }
                
                
        def Get_X : double()
        {
                return = X;
        }
                
        def Get_Y : double()
        {
                return = Y;
        }
        def Get_Z : double()
        {
                return = Z;
        }
}
        
def GetPointValue : double (pt : MyPoint)
{
        return = pt.Get_X() + pt.Get_Y()+ pt.Get_Z(); 
}
        
p = MyPoint.MyPoint (10.0, 20.0, 30.0);
val = GetPointValue(p);
 ";
            DebugTestFx.CompareDebugAndRunResults(src);
        }

        [Test]
        [Category("Debugger")]
        public void DebugEQTestStepInVsStepOver_IDE618_06()
        {
            String src =
                @" 
class MyPoint
        {
                X : double;
                Y : double;
                Z : double;
        constructor MyPoint (x : double, y : double, z : double)
        {
                        X = x;
                        Y = y;
                        Z = z;
        }
                def Get_X : double()
                {
                        return = X;
                }
                def Get_Y : double()
                {
                        return = Y;
                }
                def Get_Z : double()
                {
                        return = Z;
                }
    }
        def GetPointValue : double (pt : MyPoint)
        {
                return = pt.Get_X() + pt.Get_Y() + pt.Get_Z(); 
        }
        myNewPoint = MyPoint.MyPoint (1.0, 10.1, 200.2);
        myPointValue = GetPointValue(myNewPoint);
 ";
            DebugTestFx.CompareDebugAndRunResults(src);
        }

        [Test]
        [Category("Debugger")]
        public void DebugEQTestStepInVsStepOver_IDE618_07()
        {
            String src =
                @" 
class Tuple4
    
{
    X : var;
    Y : var;
    Z : var;
    H : var;
    
    constructor ByCoordinates4(coordinates : double[])
    {
        X = coordinates[0];
        Y = coordinates[1];
        Z = coordinates[2];
        H = coordinates[3];
    }
    public def Equals : bool(other : Tuple4)
    {
        return = X == other.X &&
            Y == other.Y &&
            Z == other.Z &&
            H == other.H;
    }
}
class Transform
{
    public C0 : Tuple4;
    public C1 : Tuple4;
    public C2 : Tuple4;
    public C3 : Tuple4;
    
    public constructor ByData(data : double[][])
    {
        C0 = Tuple4.ByCoordinates4(data[0]);
        C1 = Tuple4.ByCoordinates4(data[1]);
        C2 = Tuple4.ByCoordinates4(data[2]);
        C3 = Tuple4.ByCoordinates4(data[3]);
    }
    def Equals : bool(other : Transform)
    {
        return = C0.Equals(other.C0) &&
            C1.Equals(other.C1) &&
            C2.Equals(other.C2) &&
            C3.Equals(other.C3);
    }
}
data1 = { { 1.0, 0, 0, 0 },
    { 0.0, 1, 0, 0 },
    { 0.0, 0, 1, 0 },
    { 0.0, 0, 0, 1 }
};
data2 = { { 1.0, 0, 0, 0 },
    { 1.0, 1, 0, 0 },
    { 0.0, 0, 1, 0 },
    { 0.0, 0, 0, 1 }
};
xform1 = Transform.ByData(data1);
xform2 = Transform.ByData(data2);
areEqual1 = xform1.Equals(xform1);
areEqual2 = xform1.Equals(xform2);
 ";
            DebugTestFx.CompareDebugAndRunResults(src);
        }

        [Test]
        [Category("Debugger")]
        public void DebugEQTestStepInVsStepOver_IDE481_01()
        {
            String src =
                @" 
class A
{
    x;
    static s_dispose = 0;

    constructor A(i)
    {
        x = i;
    }

    def _Dispose()
    {
        s_dispose = s_dispose + 1;
        return = null;
    }

    def foo()
    {
        return = null;
    }
}

class B
{
    def CreateA(i)
    {
        return = A.A(i);
    }
}

b = B.B();
r = b.CreateA(0..2).foo();
t = A.s_dispose;
 ";
            DebugTestFx.CompareDebugAndRunResults(src);
        }

        [Test]
        [Category("Debugger")]
        public void DebugEQTestArrayAssignUserType()
        {
            String src =
                @" class B
{
       value : int;
    constructor B (b : int)
    {
       value = b;
    }
}
arr = { B.B(1), B.B(2), B.B(3), B.B(4) };
 ";

            DebugTestFx.CompareDebugAndRunResults(src);

        }

        [Test]
        [Category("Debugger")]
        public void DebugEQTestEqualityR1()
        {
            String src =
                @" a = 4;";

            DebugTestFx.CompareDebugAndRunResults(src);

        }

        [Test]
        [Category("Debugger")]
        public void DebugEQTestEqualityImpR1()
        {
            String src =
                @" a = 0; [Imperative] {
a = 4;
}
";
            DebugTestFx.CompareDebugAndRunResults(src);

        }

        [Test]
        [Category("Debugger")]
        public void DebugEQTestEquality0001()
        {
            String src =
                @"[Imperative]
{
	f0 = 5 > 6;
    f1 = (5 > 6);

    f2 = 5 >= 6;
    f3 = (5 >= 6);    


    t0 = 5 == 5;
    t1 = (5 == 5);

    t2 = 5 < 6;
    t3 = (5 < 6);
    
    t4 = 5 <= 6;
    t5 = (5 <= 6);

    t6 = 5 <= 5;
    t7 = (5 <= 5);

}
";
            DebugTestFx.CompareDebugAndRunResults(src);

        }



        [Test]
        public void DebugEQBIM01_SomeNulls()
        {
            String code =
                @"
a = {null,20,30,null,{10,0},0,5,2};
b = {1,2,3};
e = {3,20,30,4,{null,0},0,5,2};
c = SomeNulls(a);
d = SomeNulls(b);
f = SomeNulls(e);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQBIM02_CountTrue()
        {
            String code =
                @"a = {true,true,true,false,{true,false},true,{false,false,{true,{false},true,true,false}}};
b = {true,true,true,false,true,true};
c = {true,true,true,true,true,true,true};
w = CountTrue(a);
x = CountTrue(b);
y = CountTrue(c);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQBIM03_CountFalse()
        {
            String code =
                @"a = {true,true,true,false,{true,false},true,{false,false,{true,{false},true,true,false}}};
b = {true,true,true,false,true,true};
c = {true,true,true,true,true,true,true};
e = CountFalse(a);
f = CountFalse(b);
g = CountFalse(c);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "AllFalse() & AllTrue()"
        public void DebugEQBIM04_AllFalse_AllTrue()
        {
            String code =
                @"
a = {true};
b = {false,false,{false,{false,{false,false,{false},false}}},false};
c = {true,true,true,true,{true,true},true,{true,true,{true, true,{true},true,true,true}}};
d = AllTrue(a);
e = AllTrue(b);
f = AllTrue(c);
g = AllFalse(a);
h = AllFalse(b);
i = AllFalse(c);
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "IsHomogeneous()"
        public void DebugEQBIM05_IsHomogeneous()
        {
            String code =
                @"a = {1,2,3,4,5};
b = {false, true, false};
c = {{1},{1.0,2.0}};
d = {null,1,2,3};
e = {};
ca = IsHomogeneous(a);
cb = IsHomogeneous(b);
cc = IsHomogeneous(c);
cd = IsHomogeneous(d);
ce = IsHomogeneous(e);
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "Sum() & Average()"
        public void DebugEQBIM06_SumAverage()
        {
            String code =
                @"
b = {1,2,{3,4,{5,{6,{7},8,{9,10},11}},12,13,14,{15}},16};
c = {1.2,2.2,{3.2,4.2,{5.2,{6.2,{7.2},8.2,{9.2,10.2},11.2}},12.2,13.2,14.2,{15.2}},16.2};
x = Average(b);
y = Sum(b);
z = Average(c);
s = Sum(c);
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        //Test "SomeTrue() & SomeFalse()"
        public void DebugEQBIM07_SomeTrue_SomeFalse()
        {
            String code =
                @"a = {true,true,true,{false,false,{true, true,{false},true,true,false}}};
b = {true,true,{true,true,true,{true,{true},true},true},true};
c = {true, false, false};
p = SomeTrue(a);
q = SomeTrue(b);
r = SomeTrue(c);
s = SomeFalse(a);
t = SomeFalse(b);
u = SomeFalse(c);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "Remove() & RemoveDuplicate()"
        public void DebugEQBIM08_Remove_RemoveDuplicate()
        {
            String code =
                @"a = {null,20,30,null,20,15,true,true,5,false};
b = {1,2,3,4,9,4,2,5,6,7,8,7,1,0,2};
rda = RemoveDuplicates(a);
rdb = RemoveDuplicates(b);
ra = Remove(a,3);
rb = Remove(b,2);
p = rda[3];
q = rdb[4];
x = ra[3];
y = rb[2];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "RemoveNulls()"
        public void DebugEQBIM09_RemoveNulls()
        {
            String code =
                @"a = {1,{6,null,7,{null,null}},7,null,2};
b = {null,{null,{null,{null},null},null},null};
p = RemoveNulls(a);
q = RemoveNulls(b);
x = p[3];
y = p[1][1];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "RemoveIfNot()"
        public void DebugEQBIM10_RemoveIfNot()
        {
            String code =
                @"a = {""This is "",""a very complex "",""array"",1,2.0,3,false,4.0,5,6.0,true,{2,3.1415926},null,false,'c'};
b = RemoveIfNot(a, ""int"");
c = RemoveIfNot(a, ""double"");
d = RemoveIfNot(a, ""bool"");
e = RemoveIfNot(a, ""array"");
q = b[0];
r = c[0];
s = d[0];
t = e[0][0];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "Reverse()"
        public void DebugEQBIM11_Reverse()
        {
            String code =
                @"a = {1,{{1},{3.1415}},null,1.0,12.3};
b = {1,2,{3}};
p = Reverse(a);
q = Reverse(b);
x = p[0];
y = q[0][0];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "Contains()"
        public void DebugEQBIM12_Contains()
        {
            String code =
                @"a = {1,{{1},{3.1415}},null,1.0,12.3};
b = {1,2,{3}};
x = {{1},{3.1415}};
r = Contains(a, 3.0);
s = Contains(a, x);
t = Contains(a, null);
u = Contains(b, b);
v = Contains(b, {3});
w = Contains(b, 3);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "IndexOf()"
        public void DebugEQBIM13_IndexOf()
        {
            String code =
                @"a = {1,{{1},{3.1415}},null,1.0,12,3};
b = {1,2,{3}};
c = {1,2,{3}};
d = {{1},{3.1415}};
r = IndexOf(a, d);
s = IndexOf(a, 1);
t = IndexOf(a, null);
u = IndexOf(b, {3});
v = IndexOf(b, 3);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "Sort()"
        public void DebugEQBIM14_Sort()
        {
            String code =
                @"a = {1,3,5,7,9,8,6,4,2,0};
b = {1.3,2,0.8,2,null,2,2.0,2,null};
x = Sort(a);
x1 = Sort(a,true);
x2 = Sort(a,false);
y = Sort(b);
p = x[0];
p1 = x1[0];
p2 = x2[0];
q = x[9];
s = y[0];
t = y[7];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "SortIndexByValue()"
        public void DebugEQBIM15_SortIndexByValue()
        {
            String code =
                @"a = {1,3,5,7,9,8,6,4,2,0};
b = {1.3,2,0.8,2,null,2,2.0,2,null};
x = SortIndexByValue(a);
x1 = SortIndexByValue(a,true);
x2 = SortIndexByValue(a,false);
y = SortIndexByValue(b);
p = x[0];
p1 = x1[0];
p2 = x2[0];
q = x[9];
s = y[0];
t = y[7];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "Insert()"
        public void DebugEQBIM16_Insert()
        {
            String code =
                @"a = {false,2,3.1415926,null,{false}};
b = 1;
c = {1};
d = {};
e = {{1},2,3.0};
p = Insert(a,b,1);
q = Insert(a,c,1);
r = Insert(a,d,0);
s = Insert(a,e,5);
u = p[1];
v = q[1][0];
w = r[1][0];
x = s[5][0][0];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "SetDifference(), SetUnion() & SetIntersection()"
        public void DebugEQBIM17_SetDifference_SetUnion_SetIntersection()
        {
            String code =
                @"a = {false,15,6.0,15,false,null,15.0};
b = {10,20,false,12,21,6.0,15,null,8.2};
c = SetDifference(a,b);
d = SetDifference(b,a);
e = SetIntersection(a,b);
f = SetUnion(a,b);
p = c[0];
q = d[1];
r = e[1];
s = f[1];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "Reorder"
        public void DebugEQBIM18_Reorder()
        {
            String code =
                @"a = {1,4,3,8.0,2.0,0};
b = {2,1,0,3,4};
c = Reorder(a,b);
p = c[0];
q = c[1];
r = c[2];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "IsUniformDepth"
        public void DebugEQBIM19_IsUniformDepth()
        {
            String code =
                @"a = {};
b = {1,2,3};
c = {{1},{2,3}};
d = {1,{2},{{3}}};
p = IsUniformDepth(a);
q = IsUniformDepth(b);
r = IsUniformDepth(c);
s = IsUniformDepth(d);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "NormailizeDepth"
        public void DebugEQBIM20_NormalizeDepth()
        {
            String code =
                @"a = {{1,{2,3,4,{5}}}};
p = NormalizeDepth(a,1);
q = NormalizeDepth(a,2);
r = NormalizeDepth(a,4);
s = NormalizeDepth(a);
w = p[0];
x = q[0][0];
y = r[0][0][0][0];
z = s[0][0][0][0];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "Map & MapTo"
        public void DebugEQBIM21_Map_MapTo()
        {
            String code =
                @"a = Map(80.0, 120.0, 100.0);
b = MapTo(0.0, 100.0 ,25.0, 80.0, 90.0);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "Transpose"
        public void DebugEQBIM22_Transpose()
        {
            String code =
                @"a = {{1,2,3},{1,2},{1,2,3,4,5,6,7}};
p = Transpose(a);
q = Transpose(p);
x = p[6][0];
y = q[0][6];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "LoadCSV"
        public void DebugEQBIM23_LoadCSV()
        {
            String code =
                @"a = ""CSVTestCase\test1.csv"";
b = LoadCSV(a);
c = LoadCSV(a, false);
d = LoadCSV(a, true);
x = b[0][2];
y = c[0][2];
z = d[0][2];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "Count"
        public void DebugEQBIM24_Count()
        {
            String code =
                @"a = {1, 2, 3, 4};
b = { { 1, { 2, 3, 4, { 5 } } } };
c = { { 2, null }, 1, ""str"", { 2, { 3, 4 } } };
x = Count(a);
y = Count(b);
z = Count(c);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "Rank"
        public void DebugEQBIM25_Rank()
        {
            String code =
                @"a = { { 1 }, 2, 3, 4 };
b = { ""good"", { { null } }, { 1, { 2, 3, 4, { 5, { ""good"" }, { null } } } } };
c = { { null }, { 2, ""good"" }, 1, null, { 2, { 3, 4 } } };
x = Rank(a);
y = Rank(b);
z = Rank(c);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "Flatten"
        public void DebugEQBIM26_Flatten()
        {
            String code =
                @"a = {1, 2, 3, 4};
b = { ""good"", { 1, { 2, 3, 4, { 5 } } } };
c = { null, { 2, ""good""}, 1, null, { 2, { 3, 4 } } };
q = Flatten(a);
p = Flatten(b);
r = Flatten(c);
x = q[0];
y = p[2];
z = r[4];
s = p[0];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        //Test "CountTrue/CountFalse/Average/Sum/RemoveDuplicate"
        public void DebugEQBIM27_Conversion_Resolution_Cases()
        {
            String code =
                @"a = {null,20,30,null,{10,0},true,{false,0,{true,{false},5,2,false}}};
b = {1,2,{3,4,9},4,2,5,{6,7,{8}},7,1,0,2};
x = CountTrue(a);
y = CountFalse(a);
z = AllTrue(a);
w = AllFalse(a);
p = SomeTrue(a);
q = SomeTrue(a);
r = Sum(true);
s = Sum(null);
t = RemoveDuplicates(b);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestMethometicalFunction()
        {
            String code =
                @"import(""math.dll"");
a = -9.30281;
b = 20.036;
x1 = Math.Abs(a);
y1 = Math.Abs(b);
x2 = Math.Ceiling(a);
y2 = Math.Ceiling(b);
x3 = Math.Exp(1.3);
y3 = Math.Exp(b);
x4 = Math.Floor(a);
y4 = Math.Floor(b);
x5 = Math.Log(x1, 2);
y5 = Math.Log(b, 2);
x6 = Math.Log10(x1);
y6 = Math.Log10(b);
x7 = Math.Min(a, b);
y7 = Math.Max(a, b);
x9 = Math.Sqrt(x1);
y9 = Math.Sqrt(b);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestTrigonometricFunction()
        {
            String code =
                @"import(""math.dll"");
a = -0.5;
b = 0.5;
c = 45;
d = -45;
e = 2.90;
f = 1.90;
x1 = Math.Acos(a);
y1 = Math.Asin(a);
z1 = Math.Atan(a);
r1 = Math.Atan2(e, f);
x2 = Math.Acos(b);
y2 = Math.Asin(b);
z2 = Math.Atan(b);
x3 = Math.Sin(c);
y3 = Math.Cos(c);
z3 = Math.Tan(c);
r3 = Math.Tanh(c);
x4 = Math.Sin(d);
y4 = Math.Cos(d);
z4 = Math.Tan(d);
r4 = Math.Tanh(d);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }



        [Test]
        public void DebugEQInheritanceTest01()
        {
            String code =
                @"

	class RigidBody
	{
        id : var;
        velocity : var;

        constructor RigidBody(objID : int, vel : double)
        {
            id = objID;
            velocity = vel;
        }

        def GetVelocity : double(drag : int)
        {
            return = velocity * drag;
        }
    }

    class Particle extends RigidBody
	{
        lifetime : var;

        constructor Particle(objID : int, vel : double, life : double)
        {
            id = objID;
            velocity = vel;
            lifetime = life;
        }
    }
 
 
    // TODO Jun: Fix defect, allow statements (or maybe just preprocs?) before a class decl

    // Define some constants
    kRigidBodyID    = 0; 
    kParticleID     = 1;

    kGravityCoeff   = 9.8;

       
    //================================
    // Simulate physical object 1
    //================================

    // Construct a base rigid body
    rb = RigidBody.RigidBody(kRigidBodyID, kGravityCoeff);
    rbVelocity = rb.GetVelocity(2);


    
    //================================
    // Simulate physical object 2
    //================================
    
    // Construct a particle that inherits from a rigid body
    kLifetime = 0.25;
    p = Particle.Particle(kParticleID, kGravityCoeff, kLifetime);
    lt = p.lifetime;
    particleVelocity = rb.GetVelocity(4);


";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQInheritanceTest02()
        {
            String code =
                @"
class A
{
    id : var;
    constructor A(pId : int)
    {
        loc = 20;
        id = pId;
    }
}

class B extends A
{
    constructor B(pId : int)
    {
        id = pId;
    }
}

a = B.B(1);
i = a.id;

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQInheritanceTest03()
        {
            String code =
                @"

class Geometry
{
    id: var;
}

class Point extends Geometry
{
    _x : var;
    constructor ByCoordinates(xx : double)
    {
        _x = xx;
    }
}
    
class Circle extends Geometry
{
    _cp : var;
    constructor ByCenterPointRadius()
    {
        _cp = Point.ByCoordinates(100.0);
    }
}
    
[Associative]
{
    c = Circle.ByCenterPointRadius();
    cp = c._cp;
    x = cp._x;

}


";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQInheritanceTest04()
        {
            String code =
                @"

class Geometry
{
    id : var;
}

class Curve extends Geometry
{}

class Point extends Geometry
{
    _x : var;
    _y : var;
    _z : var;
    
    constructor ByCoordinates(xx : double, yy : double, zz : double)
    {
        _x = xx;
        _y = yy;
        _z = zz;
    }
}
    
class Circle extends Curve
{
    _cp : var;
    constructor ByCenterPointRadius()
    {
        _cp = Point.ByCoordinates(10.0,20.0,30.0);
    }
    
    def get_CenterPoint : Point ()
    {        
        return = _cp;
    }
}
    
[Associative]
{
    c = Circle.ByCenterPointRadius();
    pt = c.get_CenterPoint();
    x = pt._x;
}

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }



        [Test]
        public void DebugEQSimpleCtorResolution01()
        {
            String code =
                @"
	class f
	{
		fx : var;
		fy : var;
		constructor f()
		{
			fx = 123;
			fy = 345;
		}
	}

// Construct class 'f'
	cf = f.f();
	x = cf.fx;
	y = cf.fy;

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQSimpleCtorResolution02()
        {
            String code =
                @"
	class f
	{
		fx : var;
		fy : var;
		constructor f()
		{
			fx = 123;
			fy = 345;
		}

        constructor f(x : int, y : int)
        {
            fx = x;
            fy = y;
        }
	}

    // Construct class 'f'
	cf = f.f();
	x = cf.fx;
	y = cf.fy;

    cy = f.f(1,2);
    x2 = cy.fx;
    y2 = cy.fy;

";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQSimpleCtorResolution03()
        {
            String code =
                @"

	class vector2D
	{
		mx : var;
		my : var;
		

		constructor vector2D(px : int, py : int)
		{
			mx = px; 
			my = py; 
		}


        def scale : int()
		{
			mx = mx * 2; 
			my = my * 2; 
            return = 0;
		}

        def scale : int(s: int)
		{
			mx = mx * s; 
			my = my * s; 
            return = 0;
		}

	}


	p = vector2D.vector2D(10,40);
	x = p.mx;
	y = p.my;
    
	n = p.scale();
	n = p.scale(10);


";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQSimpleCtorResolution04()
        {
            String code =
                @"
class Sample
{
    mx : var;
    constructor Create()
    {}
        
    constructor Create(intval : int)
    {}
        
    constructor Create(doubleval : double)
    {
        mx = doubleval;
    }
        
    constructor Create(intval : int, doubleval : double)
    {}
}
    
//    default ctor
s1 = Sample.Create();
    
//    ctor with int
s2 = Sample.Create(1);
    
//    ctor with double
s3 = Sample.Create(1.0);
    
//    ctor with int and double
s4 = Sample.Create(1, 1.0);

d = s3.mx;

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQTestMethodOverload1()
        {
            string code =
                @"
                class A
                {
	                def execute(a : A)
	                {
		                return = 1;
	                }
                }

                class B extends A
                {
	                def execute(b : B)
	                {
		                return = 2;
	                }
                }

                a = A.A();
                b = B.B();
                val = b.execute(a);
                ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestMethodOverload2()
        {
            string code =
                @"
                class A
                {
	                def execute(a : A)
	                {
		                return = 1;
	                }
                }

                class B extends A
                {
	                def execute(b : B)
	                {
		                return = 2;
	                }
                }

                class C extends A
                {
                }

                b = B.B();
                c = C.C();
                val = b.execute(c);
                ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestMethodOverload3()
        {
            string code =
                @"
                class A
                {
	                def execute(a : A)
	                {
		                return = 1;
	                }
                }

                class B extends A
                {
	                def execute(b : B)
	                {
		                return = 2;
	                }
                }

                class C extends A
                {
                }

                c = C.C();
                val = c.execute(c);
                ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestMethodOverload4()
        {
            string code =
                @"
                class A
                {
	                def execute(a : A)
	                {
		                return = 1;
	                }
                }

                class B extends A
                {
	                def execute(b : B)
	                {
		                return = 2;
	                }
                }

                class C extends B
                {
                }

                c = C.C();
                val = c.execute(c);
                ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestMethodResolutionOverInheritance()
        {
            string code =
                @"
                class A
                {
	                def execute(a : A)
	                {
		                return = 1;
	                }
                }

                class B extends A
                {
                }

                class C extends B
                {
                }

                c = C.C();
                val = c.execute(c);
                ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestMethodOverlaodAndArrayInput1()
        {
            string code =
                @"
                class A
                {
                    def execute(a : A)
                    { 
                        return = -1; 
                    }
                }

                class B extends A
                {
                    def execute(arr : B[])
                    {
                        return = 2;
                    }
                }

                b = B.B();
                arr = {B.B(), B.B(), B.B()};
                val = b.execute(arr);
                ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestMethodOverlaodAndArrayInput2()
        {
            string code =
                @"
                class A
                {
                    def execute(a : A)
                    { 
                        return = -1; 
                    }
                }

                class B extends A
                {
                    def execute(arr : B[])
                    {
                        return = 2;
                    }
                }

                class C extends B
                {
                }

                b = B.B();
                arr = {C.C(), B.B(), C.C()};
                val = b.execute(arr);
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestMethodOverlaodAndArrayInput3()
        {
            string code =
                @"
                class A
                {
                }

                class B extends A
                {
                    def execute(b : B)
                    { 
                        return = -1; 
                    }

                    def execute(arr : B[])
                    {
                        return = 2;
                    }
                }

                class C extends B
                {
                }

                b = B.B();
                arr = {C.C(), B.B(), C.C()};
                val = b.execute(arr);
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestMethodOverlaodAndArrayInput4()
        {
            string code =
                @"
                class A
                {
                }

                class B extends A
                {
                    static def execute(b : B)
                    { 
                        return = -1; 
                    }

                    def execute(arr : B[])
                    {
                        return = 2;
                    }
                }

                class C extends B
                {
                }

                arr = {C.C(), B.B(), C.C()};
                val = B.execute(arr);
                val1 = val[0];
                val2 = val[1];
                val3 = val[2];
                ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }



        [Test]
        public void DebugEQTestMethodOverlaodAndArrayInput4Min()
        {
            string code =
                @"
                class A
                {
                }

                class B extends A
                {
                    static def execute(b : B)
                    { 
                        return = -1; 
                    }

                    def execute(arr : B[])
                    {
                        return = 2;
                    }
                }

                arr = {B.B(), B.B()};
                val = B.execute(arr);
                val1 = val[0];
                val2 = val[1];
                ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Method Resolution")]
        public void DebugEQTestStaticDispatchOnArray()
        {
            //Recorded as defect: DNL-1467146


            string code =
                @"class A
{
static def execute(b : A)
{ 
return = 100; 
}
}

arr = {A.A()};
v = A.execute(arr);
val = v[0];
                ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Method Resolution")]
        [Category("Escalate")]
        public void DebugEQTestStaticDispatchOnEmptyArray()
        {
            string code =
                @"class A
{
static def execute(b : A)
{ 
return = 100; 
}
}

arr = {};
v = A.execute(arr);
val = v[0];
                ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestMethodOverlaodAndArrayInput5()
        {
            string code =
                @"
                class A
                {}

                class B extends A
                {
                    def execute(b : B)
                    { 
                        return = -1; 
                    }

                    static def execute(arr : B[])
                    {
                        return = 2;
                    }
                }

                class C extends B
                {}

                class D extends B
                {}

                arr = {C.C(), D.D(), C.C()};
                val = B.execute(arr);
                ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestMethodOverlaodAndArrayInput6()
        {
            string code =
                @"
                class A
                {
                    def execute(a : A)
                    { 
                        return = -1; 
                    }
                }

                class B extends A
                {
                    static def execute(arr : B[], i : int)
                    {
                        return = 2;
                    }
                }

                class C extends B
                {
                }

                arr = {C.C(), B.B(), C.C()};
                val = B.execute(arr, 1);
                ";


            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestMethodWithArrayInput1()
        {
            string code =
                @"
                            class A
                            {
                            }

                            class B extends A
                            {
                            }

                            def Test(arr : A[])
                            {
                                    return = 123;
                            }

                            a = {B.B(), B.B(), B.B()};
                            val = Test(a);
                            ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestMethodWithArrayInput2()
        {
            string code =
                @"
                            class A
                            {
                            }

                            class B extends A
                            {
                            }

                            def Test(arr : A[])
                            {
                                    return = 123;
                            }

                            a = {B.B(), A.A(), B.B()};
                            val = Test(a);
                            ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Method Resolution")]
        public void DebugEQTestMethodWithArrayInputOverload()
        {
            string code =
                @"
                            class A
                            {
	                            def foo(x : double)
                                { return = 1; }

                                def foo(x : double[]) 
	                            { return = 2; }

	                            def foo(x : double[][]) 
	                            { return = 3; }
                            }

                            arr = 1..20..2;
                            val = A.A().foo(arr);
                            ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Method Resolution")]
        public void DebugEQTestMethodWithArrayInputOverloadDirectType()
        {
            string code =
                @"
                            class A
                            {
	                            def foo(x : int)
                                { return = 1; }

                                def foo(x : int[]) 
	                            { return = 2; }

	                            def foo(x : int[][]) 
	                            { return = 3; }
                            }

                            arr = 1..20..2;
                            val = A.A().foo(arr);
                            ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestMethodWithOverrides()
        {
            string code =
                @"
                            class A
                            {
	                            def foo(x : double)
                                { return = 1; }

                            }

                            class B extends A
                            {
                                def foo(x : double)
                                { return = 2; }
                            }

                            
                            a = A.A();
                            val1 = a.foo(0.0);
                            
                          //  b = B.B();
                            
                          //  val2 =b.foo(0.0);

                            ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestOverridenMethod()
        {
            string code =
                @"
                            class A
                            {
	                            def foo(x : double)
                                { return = 1; }

                            }

                            class B extends A
                            {
                                def foo(x : double)
                                { return = 2; }
                            }

                            
                          //  a = A.A();
                          //  val1 = a.foo(0.0);
                            
                          b = B.B();
                            
                          val2 =b.foo(0.0);

                            ";
            DebugTestFx.CompareDebugAndRunResults(code);


        }



        [Test]
        public void DebugEQTestAssignment01_002()
        {

            String code =
                @"[Associative]
{
	foo = 5;
}
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestNull01_002()
        {

            String code =
                @"
[Associative]
{
	x = null;
    y = x;

    a = null;
    b = a + 2;
    c = 2 + a * x;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestNull02_002()
        {

            String code =
                @"

[Associative]
{
    def foo : int ( a : int )
    {
        b = a + 1;
    }
	 
    c = foo(1);	
}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestFunctions01()
        {
            String code =
                @"[Associative]
{

    def mult : int( s : int )	
	{
		return = s * 2;
	}

    test = mult(5);
    test2 = mult(2);
    test3 = mult(mult(5));

}
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQTestFunctions02()
        {
            String code =
                @"        
[Associative]
{ 
    def test2 : int(b : int)
    {
        return = b;
    }
                
    def test : int(a : int)
    {
        return = a + test2(5);
    }
               
    temp = test(2);
}
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        public void DebugEQTestFunctionsOverload01()
        {
            String code =
                @"[Associative]
{

    def m1 : int( s : int )	
	{
		return = s * 2;
	}

    def m1 : int( s: int, y : int )
    {
        return = s * y;
    }

    test1 = m1(5);
    test2 = m1(5, 10);


}
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestFunctionsOverload02()
        {
            String code =
                @"[Associative]
{
    def f : int( p1 : int )
    {
	    x = p1 * 10;
	    return = x;
    }

    def f : int( p1 : int, p2 : int )
    {
	    return = p1 + p2;
    }

    a = 2;
    b = 20;

    // Pasing variables to function overloads
    i = f(a + 10);
    j = f(a, b);
}   
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestFunctionsOverload03()
        {
            String code =
                @"class A
            {
	            b : int;
	            
	            def foo(a : int)
	            {
		            b = 1;
		            return = a;
	            }

	            def foo(a : int[])
	            {
                    b = 2;
		            return = a;
	            }
            }

            x = A.A();

            c = {1,2,3,4};
            d = x.foo(c);
            y = x.b;

            e = x.foo({5,6,7,8});
            z = x.b;            
            ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestDynamicDispatch01()
        {
            String code =
                @"
    class A
    {
        x:int;
        constructor A(i)
        {
            x = i;
        }
    }
    
    def foo(a:A)
    {
        return = a.x;
    }

    def foo(x:int)
    {
        return = x;
    }

    def ding(x:int)
    {
        return = (x < 0) ? 2 * x : A.A(x);
    }

    t1 = foo(ding(-1));
    t2 = foo(ding(2));
    arr = {1, 2};
    arr[1] = A.A(100);
    t3 = foo(arr[1]);    
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestClasses01()
        {
            String code =
                @"
	class f
	{
		fx : var;
		fy : var;
		constructor f()
		{
			fx = 123;
			fy = 345;
		}
	}

	
	class g
	{
		gx : var;
		gy : var;
		constructor g()
		{
			// Construct a class within a class
			gx = f.f();
			gy = 678;
		}
	}

	// Construct class 'g'
	cg = g.g();

	// Resolution assignment
	cg.gx.fx = 10001;
	somevar = cg.gx.fx;

	// Construct class 'f'
	cf = f.f();
	cf.fx = 888888;
	cf.fy = 999999;

	// Re-assign an instance of class 'gx' in class 'cg' with new class 'cf'
	cg.gx = cf;

	another = cg.gx.fx;
	cf2 = cg.gx;
	xx = cf2.fx;
	yy = cf2.fy;

";

            DebugTestFx.CompareDebugAndRunResults(code);


        }

        [Test]
        public void DebugEQTestClasses02()
        {
            String code =
                @"
	class vector2D
	{
		mx : var;
		my : var;
		
		constructor vector2D(px : int, py : int)
		{
			mx = px; 

			// Copy mx to my with px's value
			my = mx; 
		}
	}

	v1 = vector2D.vector2D(100,20);
	x = v1.mx;
	y = v1.my;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestClasses03()
        {
            String code =
                @"
    class A
    {
        x : var;

        constructor A()
        {
            x = 0;
        }

	    def Get : int()
        {
            return = 10;
        }
    }

    class B extends A
    {
        constructor B()
        {
        }
    }

    p = B.B();
    x = p.Get();

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestClasses04()
        {
            String code =
                @"
    class A
    {
        x : var;

        constructor A()
        {
            x = 1;
        }

	    def Get : int()
        {
            return = 10;
        }
    }

    
    class B extends A
    {
        constructor B()
        {
            x = 2;
        }
    }

    ptrA = A.A();
    ax = ptrA.x;

    ptrB = B.B();
    bx = ptrB.x;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestClasses05()
        {
            String code =
                @"  
    def sum : double (p : double)
    {
           return = p + 10.0;
    }

    class Obj
    {
        val : var;
		mx : var;
		my : var;
		mz : var;


        constructor Obj(xx : double, yy : double, zz : double)
        {
            mx = xx;
            my = yy;
            mz = zz;
            val = sum(zz);
        }
    }

    p = Obj.Obj(0.0, 1.0, 2.0);
    x = p.val;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestClasses06()
        {
            String code =
                @"  
class Point
{
    mx : var;
    my : var;
    mz : var;
    constructor ByCoordinates(x : int, y : int, z : int)
    {
        mx = x;
        my = y;
        mz = z;
    }
}

class BSplineCurve
{
    mpts : var[];
    constructor ByPoints(ptsOnCurve : Point[])
    {
        mpts = ptsOnCurve;
    }
}


pt1 = Point.ByCoordinates(1,2,3);
pt2 = Point.ByCoordinates(4,5,6);
pt3 = Point.ByCoordinates(7,8,9);
pt4 = Point.ByCoordinates(10,11,12);
pt5 = Point.ByCoordinates(15,16,17);

pts = {pt1, pt2, pt3, pt4, pt5};

p = BSplineCurve.ByPoints(pts);

a1 = p.mpts[0].mx;
a2 = p.mpts[1].my;
a3 = p.mpts[2].mz;
a4 = p.mpts[3].mx;
a5 = p.mpts[4].my;


";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestClasses07()
        {
            String code =
                @"  

class vector2D
{
	mx : var[];
	constructor vector2D()
	{
		mx = {10,20}; 
	}

    def ModifyMe : int()
    {
        mx[1] = 64;
        return = mx[1];
    }
}

p = vector2D.vector2D();
x = p.ModifyMe();


";
            DebugTestFx.CompareDebugAndRunResults(code);
        }



        [Test]
        public void DebugEQTestClassFunction01()
        {
            String code =
                @"
	class complex
	{
		mx : var;
		my : var;
		constructor complex(px : int, py : int)
		{
			mx = px; 
			my = py; 
		}
		def scale : int(s : int)
		{
			mx = mx * s; 
			my = my * s; 
			return = 0;
		}
	}

	p = complex.complex(8,16);
	i = p.mx;
	j = p.my;

	// Calling a member function of class complex that mutates its properties 
	k1 = p.scale(2); 

	// Scale 'p' further
	k2 = p.scale(10); 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestClassFunction02()
        {
            String code =
                @"
    class Obj
    {
        val : var;

	    def sum : int (p : int)
        {
            return = p + 10;
        }

        constructor Obj()
        {
            val = sum(2);
        }
    }

    p = Obj.Obj();
    x = p.val;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }



        [Test]
        public void DebugEQTestClassFunction03()
        {
            String code =
                @"
	class Vector
	{
		mx : var;
		my : var;
		
		def init : int ()
		{
            my = 522;  
            return = 22;
		}
		
		constructor Vector(x : int)
		{
			mx = x;
            aa = init(); // A local function called within the constructor
		}
	}

	a = Vector.Vector(1);
	b = a.mx;
    c = a.my;
    d = a.init();

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestClassFunction04()
        {
            String code =
                @"
    class Sample
    {
        _val : var;
        
        constructor Sample()
        {
            _val = 5.0;
        }
        
        constructor Sample(val : double)
        {
            _val = val;
        }
        
        def get_Val : double ()
        {
            return = _val;
        }
    }
    
    def function1 : double (s : Sample )
    {
        return = s.get_Val();
    }
    
    s1 = Sample.Sample();
    s2 = Sample.Sample(100.0);
    
    one = function1(s1);
    two = function1(s2);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestClassFunction05()
        {
            String code =
                @"
class Point
{
    _x : var;
    _y : var;
    _z : var;
                                
    constructor Point(xx : double, yy : double, zz : double)
    {
        _x = xx;
        _y = yy;
        _z = zz;
    }
                                
    def get_X : double () 
    {
        return = _x;
    }
    def get_Y : double () 
    {
        return = _y;
    }
    def get_Z : double () 
    {
        return = _z;
    }

}
                
    
class Line 
                
{
    _sp : var;
    _ep : var;
                    
    constructor Line(startPoint : Point, endPoint : Point)
    {
        _sp = startPoint; 
        _ep = endPoint;
                    
    }

    def get_StartPoint : Point ()
    {                              
        return = _sp;
    }
                                                
    def get_EndPoint : Point () 
    {
        return = _ep;
    }          
}
                
pt1 = Point.Point(3.0,2.0,1.0);
pt2 = Point.Point(31.0,21.0,11.0);
  
myline = Line.Line(pt1, pt2);

v1 = myline._sp.get_X();
v2 = myline._sp._x;

v3 = myline.get_StartPoint().get_X();
v4 = myline.get_StartPoint().get_Y();
v5 = myline.get_StartPoint().get_Z();

v6 = myline.get_EndPoint().get_X();
v7 = myline.get_EndPoint().get_Y();
v8 = myline.get_EndPoint().get_Z();

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestClassFunction06()
        {
            String code =
                @"
class Point 
{
    mx : var;
    my : var;
    mz : var;
    constructor ByCoordinates(xx : double, yy : double, zz : double)
    {
    mx = xx;
    my = yy;
    mz = zz;
    }
}
    
class Circle
{
    _cp : var;
    
    constructor ByCenterPointRadius(centerPt : Point, rad : double)
    {
        _cp = centerPt;
    }
    
    def get_CenterPoint : Point ()
    {        
        return = _cp;
    }
        
}
    
[Associative]
{
    pt = Point.ByCoordinates(10.0,20.0,30.0);
    rad = 25.0;
    
    c = Circle.ByCenterPointRadius(pt, rad);
    
    d = c.get_CenterPoint();
    e = d.mx;
    f = d.my;
    g = d.mz;
}


";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestClassFunction07()
        {
            String code =
                @"
class MyPoint
{
	X : double;
	Y : double;
	Z : double;
                                
    constructor MyPoint (x : double, y : double, z : double)
    {
		X = x;
		Y = y;
		Z = z;
    }
		
		
	def Get_X : double()
	{
		return = X;
	}
		
	def Get_Y : double()
	{
		return = Y;
	}
	def Get_Z : double()
	{
		return = Z;
	}
}
	
def GetPointValue : double (pt : MyPoint)
{
	return = pt.Get_X() + pt.Get_Y()+ pt.Get_Z(); 
}
	
p = MyPoint.MyPoint (10.0, 20.0, 30.0);
val = GetPointValue(p);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestClassFunction08()
        {
            String code =
                @"
class Point
{
    _x : var;
    _y : var;
    _z : var;
                                
    constructor Point(xx : double, yy : double, zz : double)
    {
        _x = xx;
        _y = yy;
        _z = zz;
    }
                                
    def get_X : double () 
    {
        return = _x;
    }
    def get_Y : double () 
    {
        return = _y;
    }
    def get_Z : double () 
    {
        return = _z;
    }
}
                
    
class Line      
{
    _sp : var;
    _ep : var;
                    
    constructor Line(startPoint : Point, endPoint : Point)
    {
        _sp = startPoint; 
        _ep = endPoint;
                    
    }
    def get_StartPoint : Point ()
    {                              
        return = _sp;
    }
                                                
    def get_EndPoint : Point () 
    {
        return = _ep;
    }
               
               
               
}
                
pt1 = Point.Point(3.0,2.0,1.0);
pt2 = Point.Point(30.1, 20.1, 10.1);


l = Line.Line(pt1, pt2);
                
l_sp = l.get_StartPoint();
l_ep = l.get_EndPoint();

      
l_sp_x = l_sp.get_X();
l_ep_x = l_ep.get_X();

      
l_sp_y = l_sp.get_Y();
l_ep_y = l_ep.get_Y();

l_sp_z = l_sp.get_Z();
l_ep_z = l_ep.get_Z();

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestClassFunction09()
        {
            String code =
                @"

class MyPoint
{
	mX : double;
	mY : double;
	mZ : double;
                            
    constructor ByXY (x : double, y : double)
    {
		mX = x;
		mY = y;
		mZ = 0.0;
    }
		
	constructor ByYZ (y : double, z : double)
    {
		mX = 0.0;
		mY = y;
		mZ = z;
    }
}

    
p = MyPoint.ByYZ (100.0,200.0);
	
x = p.mX;	
y = p.mY;	
z = p.mZ;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestClassFunction10()
        {
            String code =
                @"
class A  
{   
    x : int;
    constructor Create(p : B)
    {
       x = p.a; 
    }
}
    
class B
{
    a : int;
    constructor Create(p : A)
    {
        a = p.x;
    }
}
    
aa = 2;


";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQTestClassFunction11()
        {
            String code =
                @"
class Point
{
    context : var;
    x : var;
    constructor Create(cs : CoordinateSystem, xx : double)
    {
        context= cs;
        x = xx;
    }
}

class CoordinateSystem
{
    origin : var;

    constructor Create(orig : Point)
    {
        origin = orig;
    }
}


cs = null;
p = Point.Create(cs, 10.0);
cs2 = CoordinateSystem.Create(p);
xval = cs2.origin.x;


";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestClassFunction12()
        {
            String code =
                @"

class Tuple4
{
    X : var;
    Y : var;
    Z : var;
    H : var;
    
    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)
    {
        X = xValue;
        Y = yValue;
        Z = zValue;
        H = hValue;        
    }
}

class Transform
{
    public C0 : var; 
    public C1 : var; 
    public C2 : var; 
    public C3 : var;     
    
    public constructor ByTuples(t0 : Tuple4, t1 : Tuple4, t2 : Tuple4, t3 : Tuple4)
    {
        C0 = t0;
        C1 = t1;
        C2 = t2;
        C3 = t3;
    }
    
    
    public def ApplyTransform : Tuple4 (t : Tuple4)
    {
        return = Tuple4.XYZH(0.0, 0.0, 0.0, 0.0);
    }
    
    
    public def NativeMultiply : Transform(other : Transform)
    {              
        tc0 = ApplyTransform(other.C0); // Test member functions having same local var names
        tc1 = ApplyTransform(other.C1);
        tc2 = ApplyTransform(other.C2);
        tc3 = ApplyTransform(other.C3);
        return = Transform.ByTuples(tc0, tc1, tc2, tc3);
    }
    
    public def NativePreMultiply : Transform (other : Transform)
    {     
        tc0 = other.ApplyTransform(C0); // Test member functions having same local var names
        tc1 = other.ApplyTransform(C1);
        tc2 = other.ApplyTransform(C2);
        tc3 = other.ApplyTransform(C3);
        return = Transform.ByTuples(tc0, tc1, tc2, tc3);
    }
}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestClassFunction13()
        {
            String code =
                @"

class Tuple4
{
    X : var;
    Y : var;
    Z : var;
    H : var;
    
    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)
    {
        X = xValue;
        Y = yValue;
        Z = zValue;
        H = hValue;        
    }

    constructor ByCoordinates4(coordinates : double[] )
    {
        X = coordinates[0];
        Y = coordinates[1];
        Z = coordinates[2];
        H = coordinates[3];    
    }

    
    public def Multiply : double (other : Tuple4)
    {
        //return = (X * other.X) + (Y * other.Y) + (Z * other.Z) + (H * other.H);
        return = 100.1;
    }
}


class Vector
{
    X : var;
    Y : var;
    Z : var;
    
    public constructor ByCoordinates(xx : double, yy : double, zz : double)
    {
        X = xx;
        Y = yy;
        Z = zz;
    }
}

class Transform
{
    public C0 : Tuple4; 
    public C1 : Tuple4; 
    public C2 : Tuple4; 
    public C3 : Tuple4;     
    

    public constructor ByData(data : double[][])
    {
        C0 = Tuple4.ByCoordinates4(data[0]);
        C1 = Tuple4.ByCoordinates4(data[1]);
        C2 = Tuple4.ByCoordinates4(data[2]);
        C3 = Tuple4.ByCoordinates4(data[3]);
    }
    
    public def ApplyTransform : Tuple4 (t : Tuple4)
    {
        tx = Tuple4.XYZH(C0.X, C1.X, C2.X, C3.X);
        return = t;
    }
    
    public def TransformVector : Vector (p: Vector)
    {    
        tpa = Tuple4.XYZH(p.X, p.Y, p.Z, 0.0);
        tpcv = ApplyTransform(tpa);
        return = Vector.ByCoordinates(tpcv.X, tpcv.Y, tpcv.Z);    
    }
}

data = {    
            {1.0, 0.0, 0.0, 0.0},
            {0.0, 1.0, 0.0, 0.0},
            {0.0, 0.0, 1.0, 0.0},
            {0.0, 0.0, 0.0, 1.0}
        };
        
xform = Transform.ByData(data);

vec111 = Vector.ByCoordinates(1.0,1.0,1.0);
tempTuple = Tuple4.XYZH(vec111.X, vec111.Y, vec111.Z, 0.0);
tempcv = xform.ApplyTransform(tempTuple);

x = tempcv.X;
y = tempcv.Y;
z = tempcv.Z;
h = tempcv.H;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        [Category("JunToFix")]
        public void DebugEQTestClassFunction14()
        {
            String code =
                @"

class TestClass
    
    {
    
    
    X: var;
    Y: var;
    
    constructor CreateByXY (x : double, y : double)
        {
        
        X = x;
        Y = y;

        
        }
    
    
    def AddByOne : TestClass ()
        {
        
        tempX = X;
        tempY = Y;
            
        temp = TestClass.CreateByXY(tempX + 1, tempY + 1);
        return = temp;
        }
        
   
    }
    
    
    myInstance = TestClass.CreateByXY(10.0, 10.0);
    myNewInstance = myInstance.AddByOne();

    x = myNewInstance.X;
    y = myNewInstance.Y;
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        public void DebugEQTestClassFunction15()
        {
            String code =
                @"

class Point
{
    x : var;
    y : var;
    z : var;
    
    constructor Create(xx : double, yy : double, zz : double)
    {
        x = xx;
        y = yy;
        z = zz;
    }
    
    def Offset : Point (delx : double, dely : double, delz : double)
    {
        return = Point.Create(x + delx, y + dely, z + delz);
    }
    
    def OffsetByArray : Point( deltas : double[] )
    {
        return = Offset(deltas[0], deltas[1], deltas[2]);
    }
}

[Associative]
{
    pt = Point.Create(10,10,10);

    a = {10.0,20.0,30.0};
    pt2 = pt.OffsetByArray(a);
    x = pt2.x;
    y = pt2.y;
    z = pt2.z;
}
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQTestClassFunction16()
        {
            String code =
                @"

class CoordinateSystem
{}

class Vector
{
    public GlobalCoordinates : var;
    public X : var;
    public Y : var;
    public Z : var;
    public Length : var;
    public Normalized : var;
    public ParentCoordinateSystem : var;
    public XLocal : var;
    public YLocal : var;
    public ZLocal : var;

    public constructor ByCoordinates(x : double, y : double, z : double)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    public constructor ByCoordinates(cs: CoordinateSystem, xLocal : double, yLocal : double, zLocal : double )
    {
        ParentCoordinateSystem = cs;
        XLocal = xLocal;
        YLocal = yLocal;
        ZLocal = zLocal;
    }

    public constructor ByCoordinateArray(coordinates : double[])
    {
        X = coordinates[0];
        Y = coordinates[1];
        Z = coordinates[2];    
    }

    public def Cross : Vector (otherVector : Vector)
    {
        return = Vector.ByCoordinates(
            Y*otherVector.Z - Z*otherVector.Y,
            Z*otherVector.X - X*otherVector.Z,
            X*otherVector.Y - Y*otherVector.X);
    }
}

";
            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        public void DebugEQTestClassFunction17()
        {
            String code =
                @"

class A
{
    constructor A() {}
    def foo() { return = 1; }
    def foo(i:int) { return = 10; }
}

class B
{
    constructor B() {}
    def foo() { return = 2; }
    def foo(i:int) { return = 20; }
}

p = B.B();
a = p.foo();
b = p.foo(1);
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQTestStaticProperty01()
        {
            string code =
                @"
class A
{
    static x:int;
    static def foo(i)
    {
        return = 2 * i;
    }
}

a = A.A();
a.x = 3;
t1 = a.x;

b = A.A();
t2 = b.x;
                ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestStaticProperty02()
        {
            string code =
                @"
class S
{
	public static a : int;
}

class C
{
    public x : int;
    constructor C()
    {
        S.a = 2;
    }
}


p = C.C();
b = S.a;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }



        [Test]
        [Category("Method Resolution")]
        public void DebugEQTestStaticFunction01()
        {
            string code =
                @"
                    class A
                    {
                        static x:int;
        
                        protected static def ding()
                        {
                            return = 3;
                        }
    
                        public static def dong()
                        {
                            return = 4;
                        }
                    }

                    class B extends A
                    {
                        public static def ding()
                        {
                            return = 5;
                        }

                        public def foo()
                        {
                            x1 = A.ding();
                            a = A.A();
                            x2 = a.ding();
                            x3 = ding();
                            return = x1 + x2 + x3;
                        }
                    }

                    a = A.A();
                    d1 = a.ding();
                    d2 = a.dong();
                    d3 = A.dong();

                    b = B.B();
                    f = b.foo();
                    d4 = b.ding();
                    d5 = B.ding();
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQTestStaticMethodResolution()
        {
            string code =
                @"
            class A
            {
	            b : int;
	            static z : int;

	            def foo(a : int)
	            {
		            b = 1;
		            return = a;
	            }

	            static def foo(a : int[])
	            {
		            z = 2;
		            return = 9;
	            }
            }

            x = A.A();
            c = {1,2,3,4};
            d = A.foo(c);

            y = x.b;
            v = x.z;
            w = A.z;";

            DebugTestFx.CompareDebugAndRunResults(code);
        }




        [Test]
        public void DebugEQTestArray001()
        {
            String code =
                @"[Associative]
{
	a = {1001,1002};

    x = a[0];
    y = a[1];

    a[0] = 23;

}";
            DebugTestFx.CompareDebugAndRunResults(code);


        }

        [Test]
        public void DebugEQTestArray002()
        {
            String code =
                @"
[Associative]
{ 
    def foo : int (a : int[])
    {           
        return = a[0];
    }
            
    arr = {100, 200};            
    b = foo(arr);
}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestArray003()
        {
            String code =
                @"
a = {0,1,2};
t = {10,11,12};

a[0] = t[0];
t[1] = a[1];


";
            DebugTestFx.CompareDebugAndRunResults(code);


        }

        [Test]
        public void DebugEQTestIndexingIntoArray01()
        {
            String code =
                @"
class A
{
    fx :var;
    constructor A(x : var)
    {
        fx = x;
    }
}

fa = A.A(10..12);
r1 = fa.fx;
r2 = fa[0].fx; // 10
r3 = fa.fx[0]; // 10


";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestIndexingIntoArray02()
        {
            String code =
                @"
x=[Imperative]
{
    def ding()
    {
        return = {{1,2,3}, {4,5,6}};
    }

    return = ding()[1][1];
}

class A
{
    a:int;
    constructor A(i:int)
    {
        a = i;
    }
}

def foo()
{
    return = {A.A(1), A.A(2), A.A(3)};
}

y = foo()[1].a;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestArrayOverIndexing01_002()
        {
            string code =
                @"
[Imperative]
{
    arr1 = {true, false};
    arr2 = {1, 2, 3};
    arr3 = {false, true};
    t = arr2[1][0];
}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestDynamicArray001_002()
        {
            String code =
                @"
a = {10,20};
a[2] = 100;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestDynamicArray002()
        {
            String code =
                @"
t = {};
t[0] = 100;
t[1] = 200;
t[2] = 300;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestDynamicArray003()
        {
            String code =
                @"
t = {};
t[0][0] = 1;
t[0][1] = 2;

a = t[0][0];
b = t[0][1];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestDynamicArray004()
        {
            String code =
                @"
t = {};

t[0][0] = 1;
t[0][1] = 2;
t[1][0] = 10;
t[1][1] = 20;

a = t[1][0];
b = t[1][1];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestDynamicArray005()
        {
            String code =
                @"
t = {0,{20,30}};
t[1][1] = {40,50};
a = t[1][1][0];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestDynamicArray006()
        {
            String code =
                @"
[Imperative]
{
    t = {};

    t[0][0] = 1;
    t[0][1] = 2;
    t[1][0] = 3;
    t[1][1] = 4;

    a = t[0][0];
    b = t[0][1];
    c = t[1][0];
    d = t[1][1];

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestDynamicArray007()
        {
            String code = @"
a[3] = 3;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestDynamicArray008()
        {
            String code = @"
a[0] = false;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestDynamicArray009()
        {
            String code = @"
a = false;
a[3] = 1;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestDynamicArray010()
        {
            String code = @"
a = false;
a[1][1] = {3};
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestDynamicArray011()
        {
            String code = @"
a[0] = 1;
a[0][1] = 2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestDynamicArray012()
        {
            String code = @"
a = 1;
a[-1] = 2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestDynamicArray013()
        {
            String code = @"
a = 1;
a[-3] = 2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestDynamicArray014()
        {
            String code = @"
a = {1, 2};
a[3] = 3;
a[-5] = 100;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestDynamicArray015()
        {
            String code = @"
a = 1;
a[-2][-1] = 3;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestDynamicArray016()
        {
            String code = @"
a = {{1, 2}, {3, 4}};
a[-3][-1] = 5;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestArrayIndexReplication01()
        {
            string code = @"
a = 1;
a[1..2] = 2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestArrayIndexReplication02()
        {
            string code = @"
a = {1, 2, 3};
b = a[1..2];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestTypeArrayAssign4()
        {
            string code = @"
a:int[] = {1, 2, 3};
a[0] = false;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestTypeArrayAssign5()
        {
            string code = @"
a = {false, 2, true};
b:int[] = a;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestTypeArrayAssign6()
        {
            string code = @"
a:int = 2;
a[1] = 3;;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQNestedBlocks001_002()
        {
            String code =
                @"[Associative]
{
    a = 4;
    b = a*2;
                
    [Imperative]
    {
        i=0;
        temp=1;
        //if(i<=a)
        //{
            //temp=temp+1;
        //}
    }
    a = 1;
}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Ignore]
        public void DebugEQBitwiseOp001_002()
        {
            String code =
                @"
                        [Associative]
                        {
	                        a = 2;
	                        b = 3;
                            c = a & b;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Ignore]
        public void DebugEQBitwiseOp002_002()
        {
            String code =
                @"
                        [Associative]
                        {
	                        a = 2;
	                        b = 3;
                            c = a | b;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Ignore]
        public void DebugEQBitwiseOp003_002()
        {
            String code =
                @"
                        [Associative]
                        {
	                        a = 2;
	                        b = ~a;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Ignore]
        public void DebugEQBitwiseOp004_002()
        {
            String code =
                @"
                        [Associative]
                        {
	                        a = true;
                            b = false;
	                        c = a^b;
                        }
                        ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQLogicalOp001_002()
        {
            String code =
                @"
                        [Associative]
                        {
	                        a = true;
	                        b = false;
                            c = 1;
                            d = a && b;
                            e = c && d;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQLogicalOp002_002()
        {
            String code =
                @"
                        [Associative]
                        {
	                        a = true;
	                        b = false;
                            c = 1;
                            d = a || b;
                            e = c || d;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQLogicalOp003_002()
        {
            String code =
                @"
                        [Associative]
                        {
	                        a = true;
	                        b = false;
                            c = !(a || !b);
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQDoubleOp_002()
        {
            String code =
                @"
                        [Associative]
                        {
	                        a = 1 + 2;
                            b = 2.0;
                            b = a + b; 
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQRangeExpr001_002()
        {
            String code =
                @"
                        [Associative]
                        {
	                        a = 1..5;
                            b = a[0];
	                        c = a[1];
	                        d = a[2];
	                        e = a[3]; 
                            f = a[4];
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQRangeExpr002_002()
        {
            String code =
                @"
                        [Associative]
                        {
	                        a = 1.5..5..1.1;
                            b = a[0];
	                        c = a[1];
	                        d = a[2];
	                        e = a[3];                             
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRangeExpr003_002()
        {
            String code =
                @"
                        [Associative]
                        {
	                        a = 15..10..-1.5;
                            b = a[0];
	                        c = a[1];
	                        d = a[2];
	                        e = a[3];                             
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRangeExpr004_002()
        {
            String code =
                @"
                        [Associative]
                        {
	                        a = 0..15..#5;
                            b = a[0];
	                        c = a[1];
	                        d = a[2];
	                        e = a[3]; 
                            f = a[4];                            
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRangeExpr005_002()
        {
            String code =
                @"
                        [Associative]
                        {
	                        a = 0..15..~4;
                            b = a[0];
	                        c = a[1];
	                        d = a[2];
	                        e = a[3];  
                            f = a[4];                           
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQFunctionWithinConstr001()
        {
            String code =
                @"                        
                        class Dummy
                        {
		                    x : var;
                            def init : bool ()
                            {       
			                    x = 5;
			                    return=false;
                            }
        
                            constructor Create()
                            {
                                dummy = init();			
                            }
                        }
                        [Associative]
                        {    
                            d = Dummy.Create();	
	                        a = d.x;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQInlineCondition001_002()
        {
            String code =
                @"
	                        a = 10;
                            b = 20;
                            c = a < b ? a : b;
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQInlineCondition002_002()
        {
            String code =
                @"	
	                        a = 10;
			                b = 20;
                            c = a > b ? a : a == b ? 0 : b; 
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQInlineCondition003_002()
        {
            String code =
                @"
a = {11,12,10};
t = 10;
b = a > t ? 2 : 1;

x = b[0];
y = b[1];
z = b[2];
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQInlineCondition004()
        {
            String code =
                @"
def f(i : int)
{
    return = i + 1;
}

def g()
{
    return = 1;
}


a = {10,0,10};
t = 1;
b = a > t ? f(10) : g();

x = b[0];
y = b[1];
z = b[2];
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Ignore]
        public void DebugEQPrePostFix001_002()
        {
            String code =
                @"
	                        a = 5;
                            b = ++a;
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Ignore]
        public void DebugEQPrePostFix002_002()
        {
            String code =
                @"
	                        a = 5;
                            b = a++;
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Ignore]
        public void DebugEQPrePostFix003_002()
        {
            String code =
                @"
	                        a = 5;			//a=5;
                            b = ++a;		//b =6; a =6;
                            a++;			//a=7;
                            c = a++;		//c = 7; a = 8;
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQModulo001_002()
        {
            String code =
                @"
                    a = 10 % 4; // 2
                    b = 5 % a; // 1
                    c = b + 11 % a * 3 - 4; // 0
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQModulo002_002()
        {
            String code =
                @"
                    a = 10 % 4; // 2
                    b = 5 % a; // 1
                    c = 11 % a == 2 ? 11 % 2 : 11 % 3; // 2
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQNegativeIndexOnCollection001_002()
        {
            String code =
                @"
                    a = {1, 2, 3, 4};
                    b = a[-2]; // 3
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQNegativeIndexOnCollection002_002()
        {
            String code =
                @"
                    a = { { 1, 2 }, { 3, 4 } };
                    b = a[-1][-2]; // 3
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQNegativeIndexOnCollection003_002()
        {
            String code =
                @"
                    class A
                    {
	                    x : var[];
	
	                    constructor A()
	                    {
		                    x = { B.B(), B.B(), B.B() };
	                    }
                    }

                    class B
                    {
	                    x : var[]..[];
	
	                    constructor B()
	                    {
		                    x = { { 1, 2 }, { 3, 4 },  { 5, 6 } };		
	                    }
                    }

                    a = { A.A(), A.A(), A.A() };

                    b = a[-2].x[-3].x[-2][-1]; // 4
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQPopListWithDimension_002()
        {
            String code =
                @"
                class A
                {
	                x : var;
	                y : var;
	                z : var[];
	
	                constructor A()
	                {
		                x = B.B(20, 30);
		                y = 10;
		                z = { B.B(40, 50), B.B(60, 70), B.B(80, 90) };
	                }
                }

                class B
                {
	                m : var;
	                n : var;
	
	                constructor B(_m : int, _n : int)
	                {
		                m = _m;
		                n = _n;
	                }
                }
	            a = A.A();
	            b = B.B(1, 2);
	            c = { B.B(-1, -2), B.B(-3, -4) };

	            a.z[-2] = b;
	            watch1 = a.z[-2].n; // 2

	            a.z[-2].m = 3;
	            watch2 = a.z[-2].m; // 3

	            a.x = b;
	            watch3 = a.x.m; // 3

	            a.z = c;
	            watch4 = a.z[-1].m; // -3
                ";


            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestUpdate01()
        {
            String code =
                @"
                    a = 1;
                    b = a;
                    a = 10;
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestUpdate03()
        {
            String code =
                @"
def f : int(p : int)
{
    a = 10;
    b = a;
    a = p;
    return = b;
}

x = 20;
y = f(x);
x = 40;
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestArrayUpdateRedefinition01()
        {
            String code =
                @"
a = 1;
c = 2;
b = a + 1;
b = c + 1;
a = 3;


                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestArrayUpdateRedefinition02()
        {
            String code =
                @"
                    a = 1;
                    a = a + 1;
                    a = 10;
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestArrayUpdate01()
        {
            String code =
                @"
a = {10,11,12};
t = 0;

i = a[t];
t = 2;

                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestFunctionUpdate01()
        {
            String code =
                @"
class C
{
    x : int;
    constructor C()
    {
        x = 1;
    }
}

def f(a : C)
{
    a.x = 10;
    return = 0;
}

p = C.C();
i = p.x;
t = f(p);
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestNoUpdate01()
        {
            String code =
                @"

class Line
{
    x : int;
    constructor Line(i : int)
    {
        x = i;
    }

    def Trim()
    {
        return = Line.Line(x - 1);       
    }
}

myline = Line.Line(10);
myline = myline.Trim();
myline = myline.Trim();
length = myline.x;


                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestPropertyUpdate01()
        {
            String code =
                @"
class A
{
    x : int;	
    constructor A()
    {
        x = 0;
    }
}

p = A.A();
a = p.x;
p.x = 2; 
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        // Comment Jun: Investigate how replicating setters have affected this update
        [Test]
        public void DebugEQTestPropertyUpdate02()
        {
            String code =
                @"
class A
{
    x : int;	
    constructor A()
    {
        x = 0;
    }
}

p = A.A();
b = 2;
p.x = b;
b = 10;
t = p.x;
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestPropertyUpdate03()
        {
            String code =
                @"
class A
{
    x : int;	
    constructor A()
    {
        x = 1;
    }
}

class B
{
    m : var;	
    constructor B()
    {
        m = A.A();
    }
}

p = B.B();
a = p.m.x;
p.m.x = 2;
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestPropertyUpdate04()
        {
            String code =
                @"
class A
{
    x : int;	
    constructor A()
    {
        x = 1;
    }
}

class B
{
    m : var;	
    constructor B()
    {
        m = A.A();
    }
}


p = B.B();
b = 2;
p.m.x = b;
b = 10;
t = p.m.x;
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestPropertyUpdate05()
        {
            String code =
                @"
class f
{
	x : var;
	y : var;

	constructor f()
	{
		x = 1;	
		y = 2;	
	}
}

p = f.f();
i = p.x;
p.y = 1000;
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }



        [Test]
        public void DebugEQTestPropertyUpdate06()
        {
            String code =
                @"

class C
{
    x :var;
    constructor C()
    {
        x = 10;
    }
}

p = C.C();
p.x = p.x + 1;
p.x = p.x + 1;

t = p.x;
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }




        [Test]
        public void DebugEQTestPropertyModificationInMethodUpdate01()
        {
            String code =
                @"
class C
{
    mx : var;
    constructor C ()
	{
	    mx = 1; 
	}

	def f()
	{
		mx = 10;
		return = 0; 
	}
}

p = C.C();
x = p.mx; 
a = p.f();
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestPropertyModificationInMethodUpdate02()
        {
            String code =
                @"
class C
{
    mx : var;
	my : var; 
    constructor C ()
	{
	    mx = 1; 
	    my = 2; 
	}

	def f()
	{
		mx = 10;
		my = 20;
		return = 0; 
	}
}

p = C.C();
x = p.mx; 
y = p.my; 
a = p.f();
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestXLangUpdate01()
        {
            String code =
                @"
[Associative]
{
    a = 1;
    b = a;
    [Imperative]
    {
        a = a + 1;
    }
}
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestXLangUpdate02()
        {
            String code =
                @"
[Associative]
{
    a = 1;
    b = a;
    a = 10;
    [Imperative]
    {
        a = a + 1;
    }
}
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestXLangUpdate03()
        {
            String code =
                @"

[Associative]
{
    a = 1;
    b = a;

    c = 100;
    d = c;

    [Imperative]
    {
        a = a + 1;
        c = 10;
    }
}
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestGCRefCount()
        {
            String code =
                @"

class point
{
    x : var;
    y : var;
    constructor point()
    {
        x = 10;
        y = 20;
    }

    def _Dispose : int()
    {
        x = 100;
        return = null;
    }
}

def f : int()
{
    p = point.point();
    p2 = p;
    return = p.x;
}

i = f();

n = point.point();
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestGCFFI001()
        {

            String code =
                @"
def foo : int()
{
	p = Point.ByCoordinates(10, 20, 30);
	p2 = Point.ByCoordinates(12, 22, 32);
	p3 = Point.ByCoordinates(14, 24, 34);
	return = 10;
}

p = Point.ByCoordinates(15, 25, 35);
x = p.X;
y = foo();
                ";

            code = string.Format("{0}\n{1}", "import(\"ProtoGeometry.dll\");", code);

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestGCRefCount002()
        {

            String code =
                @"
def CreatePoint : Point(x : int, y : int, z : int)
{
	return = Point.ByCoordinates(x, y, z);
}

def getx : double(p : Point)
{
	return = p.X;
}

p = CreatePoint(5, 6, 7);
x = getx(p);
                ";

            code = string.Format("{0}\n{1}", "import(\"ProtoGeometry.dll\");", code);

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestGlobalVariable()
        {
            String code =
                @"
                    gx = 100;

                    def f : int()
                    {
                        return = gx;
                    }

                    i = f();
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test, Ignore]
        [Category("Feature")]
        public void DebugEQTestTryCatch001_002()
        {
            string code =
                @"
                x = 1;
                y = 1;
                try
                {
                    x = 2;
                }
                catch(e:int)
                {
                    y = 2;
                }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }



        [Test]
        public void DebugEQTestTypeArrayAssign()
        {
            String code =
                @"
t:int[] = {1,2,3};

";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQTestTypeArrayAssign2()
        {
            String code =
                @"
t:int[];
t = {1,2,3};

";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQTestTypeArrayAssign3()
        {
            String code =
                @"
class A {
    t:int[];

    def foo() {
        t = {1,2,3};
        return = t;
    }
}

a = A.A();
b = a.foo();
ret = a.t;
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        public void DebugEQTestTypedAssignment01()
        {
            String code =
                @"
class A
{
    x:int;
    def foo()
    {
        x:double = 4.5;
        return = null;
    }
}

a = A.A();
t = a.foo();
x = a.x;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestTypedAssignment02()
        {
            string code =
                @" t1:int = 1;
t1 = 3.5;

t2:var = 2;
t2 = 4.3;

t3 = false;
t3 = 4.9;

t4 = 1;
t4:int = 3.9;
t4:var = 5.1;
t4 = 6.1;";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestTypedAssignment03()
        {
            string code =
                @" 
[Imperative]
{
    t1:int = 1;
    t1 = 3.5;

    t2:var = 2;
    t2 = 4.3;

    t3 = false;
    t3 = 4.9;

    t4 = 1;
    t4:int = 3.9;
    t4:var = 5.1;
    t4 = 6.1;
}";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestTypedAssignment04()
        {
            string code =
                @"
class A
{
    x:int = 1;
}
t:A = A.A();
r1 = t;
t = 3;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestTypedAssignment05()
        {
            string code =
                @"
class A
{
    x:int = 1;
    def foo()
    {
        p:int = 3;
        p = false;
        return = p;
    }
}
a = A.A();
r = a.foo();
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestTypedAssignment06()
        {
            string code =
                @"
x:int = 3.5;
x:bool;
y:int = 0;
y:bool;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Escalate")]
        [Category("ToFixJun")]
        public void DebugEQTestPropAssignWithReplication()
        {
            //Assert.Fail("DNL-1467241 Sprint25: rev 3420 : Property assignments using replication is not working");
            string code =
                @"class A
{
    x : int;
    t : int;
    constructor A( y)
    {
        x = y;
    }
}
 
a1 = { A.A(1), A.A(2) };
a1.t = 5;
testx = a1.x;

test = a1.t;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestPropAssignWithReplication02()
        {
            string code =
                @"class A 
{
    x : int;
    constructor A(i : int)
    {
        x = i;
    }
}

a = {A.A(10), A.A(20)};
a.x = 5;
t = a.x;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }




        [Test]
        public void DebugEQRedefineWithFunctions01()
        {
            String code =
                @"
def f(i : int)
{
    return = i + 1;
}

x = 1000;
x = f(x);
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        [Category("ToFixYuKe")]
        public void DebugEQRedefineWithFunctions02()
        {
            String code =
                @"
class C
{
    mx : var;
    constructor C(i : int)
    {
        mx = i + 1;
    }
}

p = 10;
p = C.C(p);
x = p.mx;

";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQRedefineWithFunctions03()
        {
            String code =
                @"
class C
{
    mx : var;
    constructor C()
    {
        mx = 10;
    }

    def f(a : int)
    {
        mx = a + 1;
        return = mx;
    }
}

x = 10;
p = C.C();
x = p.f(x);

";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        //TestCase from Mark//
        [Test]
        public void DebugEQRedefineWithFunctions04()
        {
            String code =
                @"def f1(i : int, k : int)
{
return = i + k;
}
def f2(i : int, k : int)
{
return = i - k;
}
x = 12;
y = 10;
x = f1(x, y) - f2(x, y); 
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRedefineWithFunctions05()
        {
            String code =
                @"
def f(i : int)
{
i = i * i;
return = i;
}
x = 2;
x = f(x + f(x));
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRedefineWithExpressionLists01()
        {
            String code =
                @"
a = 1;
a = {a, 2};
x = a[0];
y = a[1];
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRedefineWithExpressionLists02()
        {
            String code =
                @"

def f(i : int)
{
    return = i + 1;
}
a = 1;
a = {1, f(a)};
x = a[0];
y = a[1];
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        //Mark TestCases//
        [Test]
        [Category("ToFixJun")]
        public void DebugEQRedefineWithExpressionLists03()
        {
            String code =
                @"
def f(i : int)
{
    return = i + list[i];
}
list = {1, 2, 3, 4};
a = 1;
a = {f(f(a)), f(a)};
x = a[0];
y = a[1];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQRedefineWithExpressionLists04()
        {
            String code =
                @"
class C
{
    x : var[];
    constructor C()
    {
        x = {1, 2, 3, 4, 5, 6};
    }

    def f(a : int)
    {
        x = x[a] * x[a + 1];
        return = x;
    }
}
x = 2;
p = C.C();
x = p.f(x);
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount_BaseCase01()
        {
            string code = @"
class A
{}

[Associative]
{
    a = A.A();
    as = {a};
}";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount01_NoFunctionCall()
        {
            string code =
                @"
            class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
    def foo(b:B) 
    {
        return = null;

    }

    def bar(b:B[])
    {
        return = null;
    }

    static def ding(b:B)
    {
        return = null;
    }

    static def dong(b:B[])
    {
        return = null;
    }    
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

def foo(b:B)
{
    return = null;
}

def bar(b:B[])
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
b1 = B.B();
b2 = B.B();
b3 = B.B();
as = {a1, a2, a3};
bs = {b1, b2, b3};
a = A.A();
b = B.B();
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount02_FunctionNonArray()
        {
            string code =
                @"
            class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
    def foo(b:B) 
    {
        return = null;

    }

    def bar(b:B[])
    {
        return = null;
    }

    static def ding(b:B)
    {
        return = null;
    }

    static def dong(b:B[])
    {
        return = null;
    }    
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

def foo(b:B)
{
    return = null;
}

def bar(b:B[])
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
b1 = B.B();
b2 = B.B();
b3 = B.B();
as = {a1, a2, a3};
bs = {b1, b2, b3};
a = A.A();
b = B.B();
r = foo(b);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount03_FunctionReplication()
        {
            string code =
                @"
            class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
    def foo(b:B) 
    {
        return = null;

    }

    def bar(b:B[])
    {
        return = null;
    }

    static def ding(b:B)
    {
        return = null;
    }

    static def dong(b:B[])
    {
        return = null;
    }    
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
def foo(b:B)
{
    return = null;
}

def bar(b:B[])
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
b1 = B.B();
b2 = B.B();
b3 = B.B();
as = {a1, a2, a3};
bs = {b1, b2, b3};
a = A.A();
b = B.B();
r = foo(bs);

}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount04_FunctionArray()
        {
            string code =
                @"
            class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
    def foo(b:B) 
    {
        return = null;

    }

    def bar(b:B[])
    {
        return = null;
    }

    static def ding(b:B)
    {
        return = null;
    }

    static def dong(b:B[])
    {
        return = null;
    }    
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

def foo(b:B)
{
    return = null;
}

def bar(b:B[])
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
b1 = B.B();
b2 = B.B();
b3 = B.B();
as = {a1, a2, a3};
bs = {b1, b2, b3};
a = A.A();
b = B.B();

r = bar(bs);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount05_StaticFunctionNonArray()
        {
            string code =
                @"
            class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
    def foo(b:B) 
    {
        return = null;

    }

    def bar(b:B[])
    {
        return = null;
    }

    static def ding(b:B)
    {
        return = null;
    }

    static def dong(b:B[])
    {
        return = null;
    }    
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
def foo(b:B)
{
    return = null;
}

def bar(b:B[])
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
b1 = B.B();
b2 = B.B();
b3 = B.B();
as = {a1, a2, a3};
bs = {b1, b2, b3};
a = A.A();
b = B.B();

r = A.ding(b);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount06_StaticFunctionReplication()
        {
            string code =
                @"
            class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
    def foo(b:B) 
    {
        return = null;

    }

    def bar(b:B[])
    {
        return = null;
    }

    static def ding(b:B)
    {
        return = null;
    }

    static def dong(b:B[])
    {
        return = null;
    }    
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
def foo(b:B)
{
    return = null;
}

def bar(b:B[])
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
b1 = B.B();
b2 = B.B();
b3 = B.B();
as = {a1, a2, a3};
bs = {b1, b2, b3};
a = A.A();
b = B.B();

r = A.ding(bs);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount07_StaticFunctionArray()
        {
            string code =
                @"
            class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
    def foo(b:B) 
    {
        return = null;

    }

    def bar(b:B[])
    {
        return = null;
    }

    static def ding(b:B)
    {
        return = null;
    }

    static def dong(b:B[])
    {
        return = null;
    }    
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

def foo(b:B)
{
    return = null;
}

def bar(b:B[])
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
b1 = B.B();
b2 = B.B();
b3 = B.B();
as = {a1, a2, a3};
bs = {b1, b2, b3};
a = A.A();
b = B.B();

r = A.dong(bs);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount08_MemFunctionNonArray()
        {
            string code =
                @"
            class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
    def foo(b:B) 
    {
        return = null;

    }

    def bar(b:B[])
    {
        return = null;
    }

    static def ding(b:B)
    {
        return = null;
    }

    static def dong(b:B[])
    {
        return = null;
    }    
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

def foo(b:B)
{
    return = null;
}

def bar(b:B[])
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
b1 = B.B();
b2 = B.B();
b3 = B.B();
as = {a1, a2, a3};
bs = {b1, b2, b3};
a = A.A();
b = B.B();

r = a.foo(b);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount09_MemFunctionReplication()
        {
            string code =
                @"
            class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
    def foo(b:B) 
    {
        return = null;

    }

    def bar(b:B[])
    {
        return = null;
    }

    static def ding(b:B)
    {
        return = null;
    }

    static def dong(b:B[])
    {
        return = null;
    }    
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

def foo(b:B)
{
    return = null;
}

def bar(b:B[])
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
b1 = B.B();
b2 = B.B();
b3 = B.B();
as = {a1, a2, a3};
bs = {b1, b2, b3};
a = A.A();
b = B.B();

r = a.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount10_MemFunctionArray()
        {
            string code =
                @"
            class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
    def foo(b:B) 
    {
        return = null;

    }

    def bar(b:B[])
    {
        return = null;
    }

    static def ding(b:B)
    {
        return = null;
    }

    static def dong(b:B[])
    {
        return = null;
    }    
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

def foo(b:B)
{
    return = null;
}

def bar(b:B[])
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
b1 = B.B();
b2 = B.B();
b3 = B.B();
as = {a1, a2, a3};
bs = {b1, b2, b3};
a = A.A();
b = B.B();

r = a.bar(bs);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount11_ReplicationNonArray()
        {
            string code =
                @"
     class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
    def foo(b:B) 
    {
        return = null;

    }

    def bar(b:B[])
    {
        return = null;
    }

    static def ding(b:B)
    {
        return = null;
    }

    static def dong(b:B[])
    {
        return = null;
    }    
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}


def foo(b:B)
{
    return = null;
}

def bar(b:B[])
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
b1 = B.B();
b2 = B.B();
b3 = B.B();
as = {a1, a2, a3};
bs = {b1, b2, b3};
a = A.A();
b = B.B();

r = as.foo(b);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount12_ReplicationReplication()
        {
            string code =
                @"
     class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
    def foo(b:B) 
    {
        return = null;

    }

    def bar(b:B[])
    {
        return = null;
    }

    static def ding(b:B)
    {
        return = null;
    }

    static def dong(b:B[])
    {
        return = null;
    }    
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}


def foo(b:B)
{
    return = null;
}

def bar(b:B[])
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
b1 = B.B();
b2 = B.B();
b3 = B.B();
as = {a1, a2, a3};
bs = {b1, b2, b3};
a = A.A();
b = B.B();

r = as.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount13_ReplicationArray()
        {
            string code =
                @"
     class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
    def foo(b:B) 
    {
        return = null;

    }

    def bar(b:B[])
    {
        return = null;
    }

    static def ding(b:B)
    {
        return = null;
    }

    static def dong(b:B[])
    {
        return = null;
    }    
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}


def foo(b:B)
{
    return = null;
}

def bar(b:B[])
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
b1 = B.B();
b2 = B.B();
b3 = B.B();
as = {a1, a2, a3};
bs = {b1, b2, b3};
a = A.A();
b = B.B();

r = as.bar(bs);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount14_GlobalFunctionTwoArguments()
        {
            string code =
                @"
     class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}


def foo(a: A, b:B)
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
r = foo(as, bs);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount15_GlobalFunctionTwoArguments()
        {
            string code =
                @"
     class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}


def foo(a: A, b:B)
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b = B.B();
r = foo(as, b);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount16_GlobalFunctionTwoArguments()
        {
            string code =
                @"
   class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

def foo(a: A, b:B[])
{
    return = null;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
r = foo(as, bs);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount17_StaticFunctionTwoArguments()
        {
            string code =
                @"
   class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    static def ding(a:A, b:B)
    {
         return = null;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
r = A.ding(as, bs);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount18_StaticFunctionTwoArguments()
        {
            string code =
                @"
   class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    static def ding(a:A, b:B)
    {
         return = null;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b = B.B();
r = A.ding(as, b);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount19_StaticFunctionTwoArguments()
        {
            string code =
                @"
   class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    static def ding(a:A, b:B[])
    {
         return = null;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
r = A.ding(as, bs);
}
aDispose = A.count;
bDispose = B.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount20_MemberFunctionTwoArguments()
        {
            string code =
                @"
   class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo(b:B,c:C) 
    {
        return = null;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
a = A.A();
r = a.foo(bs, cs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount21_MemberFunctionTwoArguments()
        {
            string code =
                @"

   class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo(b:B,c:C) 
    {
        return = null;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

[Associative]
{
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
a = A.A();
r = a.foo(bs, c1);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount22_MemberFunctionTwoArguments()
        {
            string code =
                @"
   class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo(b:B,c:C[]) 
    {
        return = null;
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

[Associative]
{
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
a = A.A();
r = a.foo(bs, cs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount23_MemberFunctionTwoArguments()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo(b:B,c:C) 
    {
        return = null;
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
r = as.foo(bs, cs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount24_MemberFunctionTwoArguments()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
     def foo(b:B,c:C) 
    {
        return = null;
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
r = as.foo(bs, c1);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount25_MemberFunctionTwoArguments()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo(b:B,c:C[]) 
    {
        return = null;
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
r = as.foo(bs, cs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount26_GlobalFunctionReturnArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
def foo : B[] (b : B[])
{
    return = b;
}

[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount27_GlobalFunctionReturnArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

def foo : B[] (b : B)
{
    return = b;
}
[Associative]
{

a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount28_GlobalFunctionReturnArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

def foo : B (b : B)
{
    return = b;
}

[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount29_MemberFunctionReturnArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : B[] (b : B[])
    {
        return = b;
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = a1.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount30_MemberFunctionReturnArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : B[] (b : B)
    {
        return = b;
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = a1.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount31_MemberFunctionReturnArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : B (b : B)
    {
        return = b;
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = a1.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount32_StaticFunctionReturnArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    static def foo : B[] (b : B[])
    {
        return = b;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = A.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount33_StaticFunctionReturnArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    static def foo : B[] (b : B)
    {
        return = b;
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = A.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount34_StaticFunctionReturnArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    static def foo : B (b : B)
    {
        return = b;
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = A.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount35_StaticFunctionReturnObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    static def foo : B (b : B[])
    {
        return = b[0];
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = A.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount36_StaticFunctionReturnObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
     static def foo : B (b : B)
    {
        return = b;
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = A.foo(b1);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount37_MemberFunctionReturnObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
      def foo : B (b : B[])
    {
        return = b[0];
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = a1.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount38_MemberFunctionReturnObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : B (b : B)
    {
        return = b;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = a1.foo(b1);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount39_GlobalFunctionReturnObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
def foo : B (b : B[])
{
    return = b[0];
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount40_GlobalFunctionReturnObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
def foo : B (b : B)
{
    return = b;
}

[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = foo(b1);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount41_MemberFunctionReturnArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : B[] (b : B[])
    {
        return = b;
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = as.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount42_MemberFunctionReturnArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : B[] (b : B)
    {
        return = b;
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = as.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount43_MemberFunctionReturnArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : B (b : B)
    {
        return = b;
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = as.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount44_MemberFunctionReturnObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
      def foo : B (b : B[])
    {
        return = b[0];
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = as.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount45_MemberFunctionReturnObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : B (b : B)
    {
        return = b;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = as.foo(b1);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount46_GlobalFunctionReturnNewArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
def foo : A[] (b : B[])
{
    a = {A.A(),A.A(),A.A()};
    return = a;
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount47_GlobalFunctionReturnNewArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

def foo : A[] (b : B)
{
    a = A.A();
    return = a;
}
[Associative]
{

a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount48_GlobalFunctionReturnNewArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}

def foo : A (b : B)
{
    a = A.A();
    return = a;
}
def foo : B (b : B)
{
    return = b;
}

[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount49_MemberFunctionReturnNewArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : A[] (b : B[])
    {
        a = {A.A(),A.A(),A.A()};
        return = a;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = a1.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount50_MemberFunctionReturnNewArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : A[] (b : B)
    {
        a = A.A();
        return = a;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = a1.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount51_MemberFunctionReturnNewArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : A (b : B)
    {
        a = A.A();
        return = a;
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = a1.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount52_StaticFunctionReturnNewArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    static def foo : A[] (b : B[])
    {
        a = {A.A(),A.A(),A.A()};
        return = a;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = A.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount53_StaticFunctionReturnNewArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    static def foo : A[] (b : B)
    {
        a = A.A();
        return = a;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = A.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount54_StaticFunctionReturnNewArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    static def foo : A (b : B)
    {
        a = A.A();
        return = a;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = A.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount55_StaticFunctionReturnNewObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 

    static def foo : A (b : B[])
    {
        a = {A.A(),A.A(),A.A()};
        return = a[0];
    }

}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = A.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount56_StaticFunctionReturnNewObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    static def foo : A (b : B)
    {
        a = A.A();
        return = a;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = A.foo(b1);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount57_MemberFunctionReturnNewObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : A (b : B[])
    {
        a = {A.A(),A.A(),A.A()};
        return = a[0];
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = a1.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount58_MemberFunctionReturnNewObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : A (b : B)
    {
        a = A.A();
        return = a;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = a1.foo(b1);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount59_GlobalFunctionReturnNewObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
def foo : A (b : B[])
{
    a = {A.A(),A.A(),A.A()};
    return = a[0];
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount60_GlobalFunctionReturnNewObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
def foo : A (b : B)
{
    a = A.A();
    return = a;
}

[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = foo(b1);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount61_MemberFunctionReturnNewArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : A[] (b : B[])
    {
        a = {A.A(),A.A(),A.A()};
        return = a;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = as.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount62_MemberFunctionReturnNewArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : A[] (b : B)
    {
        a = A.A();
        return = a;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = as.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount63_MemberFunctionReturnNewArray()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : A (b : B)
    {
        a = A.A();
        return = a;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = as.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount64_MemberFunctionReturnNewObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : A (b : B[])
    {
        a = {A.A(),A.A(),A.A()};
        return = a[0];
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = as.foo(bs);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount65_MemberFunctionReturnNewObject()
        {
            string code =
                @"
  class A
{
    static count : var = 0;
    constructor A()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    } 
    def foo : A (b : B)
    {
        a = A.A();
        return = a;
    }
}

class B
{
    static count : var = 0;
    constructor B()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
class C
{
  static count : var = 0;
    constructor C()
    {
        count = count + 1;
    }

    def _Dispose : int()
    {
        count = count - 1;
        return = null;
    }
}
[Associative]
{
a1 = A.A();
a2 = A.A();
a3 = A.A();
as = {a1, a2, a3};
b1 = B.B();
b2 = B.B();
b3 = B.B();
bs = {b1, b2, b3};
c1 = C.C();
c2 = C.C();
c3 = C.C();
cs = {c1, c2, c3};
x = as.foo(b1);
}
aDispose = A.count;
bDispose = B.count;
cDispose = C.count;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount66_DID1467277()
        {
            string code =
                @"
class A
{
    x;
    static s_dispose = 0;

    constructor A(i)
    {
        x = i;
    }

    def _Dispose()
    {
        s_dispose = s_dispose + 1;
        return = null;
    }

    def foo()
    {
        return = null;
    }
}

class B
{
    def CreateA(i)
    {
        return = A.A(i);
    }
}

b = B.B();
r = b.CreateA(0..1).foo();
t = A.s_dispose;
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("DebuggerReferenceCount")]
        public void DebugEQTestReferenceCount67_DID1467277_02()
        {
            string code =
                @"
class A
{
    x;
    static s_dispose = 0;

    constructor A(i)
    {
        x = i;
    }

    def _Dispose()
    {
        s_dispose = s_dispose + 1;
        return = null;
    }

    def foo()
    {
        return = null;
    }
}

r = A.A(0..1).foo();

t = A.s_dispose;
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }




        [Test]
        public void DebugEQArrayConvTest()
        {
            String code =
                @"
def foo:int[]()
{
 return = {3.5}; 
}
a=foo();
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        public void DebugEQRedefConvTest()
        {
            String code =
                @"
class A
{
    x:int;
    def foo()
    {
        x:double = 3.5;  // x still is int, and 3.5 converted to 4
        return = x;
    }
}
a = A.A();
v=a.foo();
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRetArrayTest()
        {
            //DNL-1467221 Sprint 26 - Rev 3345 type conversion to array as return type does not get converted
            String code =
                @"
[Associative]
{ 
         def foo3 : int[] ( a : double )
         {
            return = a;
         }
         
        dummyArg = 1.5;
        
        b2 = foo3 ( dummyArg ); 
}
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("ToFixLuke")]
        public void DebugEQRetArrayTest2()
        {
            //DNL-1467221 Sprint 26 - Rev 3345 type conversion to array as return type does not get converted
            String code =
                @"
[Associative]
{ 
         def foo3 : double[] ( a : double )
         {
            return = a;
         }
         
        dummyArg = 1.5;
        
        b2 = foo3 ( dummyArg ); 
}
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        public void DebugEQStatementArrayTest()
        {
            //DNL-1467221 Sprint 26 - Rev 3345 type conversion to array as return type does not get converted
            String code =
                @"
[Associative]
{ 
a : int[] = 1.5;
}
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQStatementArrayTest2()
        {
            //DNL-1467221 Sprint 26 - Rev 3345 type conversion to array as return type does not get converted
            String code =
                @"
[Associative]
{ 
a : double[] = 1.5;
}
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        public void DebugEQRep1()
        {
            String code =
                @"
def foo()
{
 return = 3.5; 
}
a=foo();
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRep2()
        {
            String code =
                @"
def foo(i:int)
{
 return = 3.5; 
}
a=foo(3);
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRep3()
        {
            String code =
                @"
def foo(i:int)
{
 return = 3.5; 
}
a=foo({0, 1});
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRep4()
        {
            String code =
                @"
def foo(i:int)
{
 return = 3.5; 
}
a=foo({{0, 1}});
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRep5()
        {
            //Assert.Fail("DNL-1467183 Sprint24: rev 3163 : replication on nested array is outputting extra brackets in some cases");


            String code =
                @"
def foo(i:int)
{
 return = 3.5; 
}
a=foo({{0, 1}, 1});
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQMinimalStringTest()
        {


            String code =
                @"a = ""Callsite is an angry bird"";
b ="""";
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQSimpleUpCast()
        {

            String code =
                @"def foo(x:int[])
{
    return = x;
}
r = foo(1);";

            DebugTestFx.CompareDebugAndRunResults(code);



        }


        [Test]
        public void DebugEQTypedAssign()
        {

            String code =
                @"x : int = 2.3;";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestVarUpcast()
        {

            string code =
                @"x : var[] = 3;";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestVarDispatch()
        {

            string code =
                @"
def foo (x : var[])
{
return=x;

}

y = foo(3);
z = foo({3});";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestVarDispatchOnArrayStructure()
        {

            string code =
                @"
def foo (x : var[][])
{
return=x;

}

y = foo(3);
z = foo({3});";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestVarDispatchOnArrayStructure2()
        {

            string code =
                @"
def foo (x : var[][][])
{
return=x;

}

y = foo(3);
z = foo({3});
z2 = foo({{3}});
z3 = foo({{{3}}});

";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestVarReturnOnArrayStructure()
        {

            string code =
                @"
def foo : var[] (x)
{
return=x;

}

y = foo(3);
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestArbitraryRankArr()
        {

            string code =
                @"
a:int[] =  3 ;
b:int[]..[] =  3 ;

y:int[] = { 3 };
z:int[]..[] = { 3 };

";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestAssignFailDueToRank()
        {

            string code =
                @"
a:int = {3};

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }




        [Test]
        public void DebugEQTestAssignment01()
        {

            String code =
                @"[Imperative]
{
	foo = 5;
}
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestAssignment02()
        {

            String code =
                @"[Imperative]
{
	foo = 5;
    foo = 6;
}
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestNull01()
        {

            String code =
                @"[Imperative]
                {
                    i = 0;
                    aa = 0;
                    bb = 0;
                    if (i == null)
                    {
                        aa = i + 10;
                    }
        
                    j = 0;
                    if (j != null)
                    {
                        bb = i + 20;
                    }

                    a = 2;
                    b = null + 2;
                    c = b * 3; 
                }";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestNull02()
        {

            String code =
                @"[Imperative]
                {
                    a = b;
                }";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQFibonacci_recusion()
        {


            String code =
                @"[Imperative]
                            {
	                            def fibonacci : int( number : int)
	                            {
		                            if( number < 2)
		                            {
		                                return = 1;
		                            }
		                            return = fibonacci(number-1) + fibonacci(number -2);
		
	                            }

	                            fib10 = fibonacci(10);
                            }";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestFunction01()
        {

            String code =
                @"
[Imperative] 
{
	// An imperative function
	// Clamps 'i' between min and max ranges
	def clampRange : int(i : int, rangeMin : int, rangeMax : int)
	{
		clampedValue = i;
		if(i < rangeMin) 
		{
			clampedValue = rangeMin;
		}
		elseif( i > rangeMax ) 
		{
			clampedValue = rangeMax; 
		} 
		return = clampedValue;
	}

	a = clampRange(99, 10, 100);
}"
                ;

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestFunction02()
        {
            string code =
                @"[Imperative]
                    {
	                    def add:double( n1:int, n2:double )
	                    {
		                    return = n1 + n2;
	                    }

	                    test = add (3+1, 4.5 ) ;
                    }";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestFunction03()
        {
            string code =
                @"[Imperative]
                        {
	                        def fn2:int(a:int)
	                        {   
		                        if( a < 0 )
		                        {
			                        return = 0;
		                        }	
		                        return = 1;
	                        }

	                        x = fn2(4);
	                        temp2 = 56;

	                        if( fn2(4) == 1 )
	                        {
		                        temp2 = fn2 ( 5 );
	                        }
                        }";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQIfStatement01()
        {

            String code =
                @"[Imperative]
                        {
	                        a = 5;
	                        b = 0;
	                        if (a < 0)	
		                        b=2;
	                        b=1;
                        }";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQIfStatement02()
        {

            String code =
                @"[Imperative]
                        {
	                        a = 5;
	                        b = 0;
	                        if (a < 0)	
		                        b=2;
                            else
	                            b=1;
                        }";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQIfStatement03()
        {

            String code =
                @"[Imperative]
                        {
	                        a = 5;
	                        b = 0;
	                        if (a < 0)	
		                        b=2;
                            else if (a > 0)
	                            b=1;
                        }";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQIfStatement04()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = 2;
                            b = 0;
	                        if( a < 0 )
		                        b = 0;
	                        elseif ( a == 2 )
		                        b = 2;
	                        else
		                        b = 1;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQIfStatement05()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = true;
                            b = 0;
	                        if(a)
		                        b = 1;	                        
	                        else
		                        b = 2;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQIfStatement06()
        {

            String code =
                @"[Imperative]
                        {
	                        a = 1;
                            b = 0;
	                        if(a!=1); 
	                        else 
		                        b = 2; 
                        }";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQIfStatement07()
        {

            String code =
                @"[Imperative]
                        {
	                        a1=7.5;

	                        temp1=10;

	                        if(a1==7.5)	
		                        temp1=temp1+1;
	                        else
		                        temp1=temp1+2;

                        }";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQIfStatement08()
        {

            String code =
                @"[Imperative]
                          {
	                        a = 0;
	                        b = 0;
	                        if (a <= 0)	
                            {
		                        b = 2;
        
                                if (b == 0)
                                {
	                                b = 27;
                                }
                                else
                                    b = 28;
                            }
                            else 
                            {
                                if (a > 0)
                                {
	                                b = 1;
                                }
                            }
    
                        }";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQIfStatement09()
        {

            String code =
                @"[Imperative]
                    {
	                    a = 4;	
	
	                    if( a == 4 )
	                    {
		                    i = 0;
                        }

                        // The unbounded warning only occurs here
	                    a = i;

                        // At this point 'i' is already allocated and assigned null
	                    b = i; 
                    }";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQIfStatement10()
        {

            String code =
                @"
                    [Imperative]
                    {
                        a = 0;
                        if ( a == 0 )
                        {
                            b = 2;
                        }
                        c = a;
                    }
                    ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }



        [Test]
        public void DebugEQNestedBlocks001()
        {
            String code =
                @"[Imperative]
                        {
                            a = 4;
                            b = a*2;
                
                            [Associative]
                            {
                                i=0;
                                temp=1;
                            }
                            a = temp;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQNegativeFloat001()
        {
            String code =
                @"[Imperative]
                            {
	                            x = -2.5;
	                            y = -0.0;
                            }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQForLoop01()
        {
            String code =
                @"
                        [Imperative]
                        {
                            a = {10,20,30,40};
                            x = 0;
                            for (val in a)
                            {
                                x = x + val;
                            }
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQForLoop02()
        {
            String code =
                @"
                        [Imperative]
                        {
                            x = 0;
                            for (val in {100,200,300,400})
                            {
                                x = x + val;
                            }
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQForLoop03()
        {
            String code =
                @"
                        [Imperative]
                        {
                            x = 0;
                            for (val in {{100,101},{200,201},{300,301},{400,401}})
                            {
                                x = x + val[1];
                            }
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQForLoop04()
        {
            String code =
                @"
                        [Imperative]
                        {
                            x = 0;
                            for (val in 10)
                            {
                                x = x + val;
                            }
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQForLoop05()
        {
            String code =
                @"
                        [Imperative]
                        {
                            y = 0;
                            b = 11;
                            for (val in b)
                            {
                                y = y + val;
                            }
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Ignore]
        public void DebugEQBitwiseOp001()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = 2;
	                        b = 3;
                            c = a & b;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Ignore]
        public void DebugEQBitwiseOp002()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = 2;
	                        b = 3;
                            c = a | b;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Ignore]
        public void DebugEQBitwiseOp003()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = 2;
	                        b = ~a;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Ignore]
        public void DebugEQBitwiseOp004()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = true;
                            b = false;
	                        c = a^b;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQLogicalOp001()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = true;
	                        b = false;
                            c = 1;
                            d = a && b;
                            e = c && d;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQLogicalOp002()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = true;
	                        b = false;
                            c = 1;
                            d = a || b;
                            e = c || d;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQLogicalOp003()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = true;
	                        b = false;
                            c = 0;
                            
                            if ( a && b )
                                c = 1;
                            else
                                c = 2;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQLogicalOp004()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = true;
	                        b = false;
                            c = 0;
                            
                            if ( a || b )
                                c = 1;
                            else
                                c = 2;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQLogicalOp005()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = true;
                            c = 0;
                            
                            if ( !a )
                                c = 1;
                            else
                                c = 2;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQLogicalOp006()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = true;
	                        b = false;
                            c = !(a || !b);
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQLogicalOp007()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        i1 = 2.5;
	                        i2 = 3;
	                        temp = 2;
	                        if((i2==3)&&(i1==2.5))
		                        temp=temp+1;	  
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQLogicalOp008()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = null;
	                        b = 0;
	                        c = 0;
	                        d = 0;
	                        e = 0;
	
	                        if ( a == true)
		                        b = 1;
	                        if (a != false)
		                        c = 2;	
	                        if (null)
		                        d = 3;
	                        if (!null)
		                        e = 4;	
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQDoubleOp()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = 1 + 2;
                            b = 2.0;
                            b = a + b; 
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQRangeExpr001()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = 1..1.5..0.2;                           
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQRangeExpr002()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = 1.5..5..1.1;
                            b = a[0];
	                        c = a[1];
	                        d = a[2];
	                        e = a[3];                             
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRangeExpr003()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = 15..10..-1.5;
                            b = a[0];
	                        c = a[1];
	                        d = a[2];
	                        e = a[3];                             
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRangeExpr004()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = 0..15..#5;
                            b = a[0];
	                        c = a[1];
	                        d = a[2];
	                        e = a[3]; 
                            f = a[4];                            
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRangeExpr005()
        {
            String code =
                @"
                        [Imperative]
                        {
	                        a = 0..15..~4;
                            b = a[0];
	                        c = a[1];
	                        d = a[2];
	                        e = a[3];  
                            f = a[4];                           
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        public void DebugEQWhileStatement01()
        {
            String code =
                @"
                         [Imperative]
                        {
                            i = 1;
                            a = 3;
                            temp = 0;

                            if( a == 3 )             
                            {
                                while( i <= 4)
                                {
	                                if( i > 10 )
                                    { 
		                                temp = 4;
                                    }			  
	                                else 
                                    {
		                                i = i + 1;
                                    }
                                }
                            }
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQWhileStatement02()
        {
            String code =
                @"
                        [Imperative]
                        {
                            i = 1;
                            temp = 0;
                            while( i <= 2 )
                            {
                                a = 1;                     
                                i = i + 1;
                            }
                        }  
                        ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQRecurringDecimal01()
        {
            String code =
                @"
                        [Imperative]
                        {
                         a = 3.5;
                         b = -5.25;
                         c = a/b;
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQFactorial01()
        {
            String code =
                @"
                        [Imperative]
                        {	
	                        def fac : int( n : int )
	                        {
       	                        if(n == 0)                
	                                return = 1;                
                                return = n * fac (n-1 );
	                        }    
	                        val = fac(5);				
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQToleranceTest()
        {
            String code =
                @"
                        [Imperative]
                        {	
	                        a = 0.3; b = 0.1;  
	                        if (a-b < 0.2) { a = 0; }			
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQInlineCondition001()
        {
            String code =
                @"
                        [Imperative]
                        {	
	                        a = 10;
                            b = 20;
                            c = a < b ? a : b;			
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQInlineCondition002()
        {
            String code =
                @"
                        [Imperative]
                        {	
	                        a = 10;
			                b = 20;
                            c = a > b ? a : a == b ? 0 : b; 
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQInlineCondition003()
        {
            String code =
                @"
                        [Imperative]
                        {	
	                        a = 10;
                            b = 20;
                            c = (a > b ? a : b) > 15 ? a + (a > b ? a : b) : b + (a > b ? a : b); 
                        }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Ignore]
        public void DebugEQPrePostFix001()
        {
            String code =
                @"
                            [Imperative]
                            {
	                            a = 5;
                                b = ++a;
                            }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Ignore]
        public void DebugEQPrePostFix002()
        {
            String code =
                @"
                            [Imperative]
                            {
	                            a = 5;
                                b = a++;
                            }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Ignore]
        public void DebugEQPrePostFix003()
        {
            String code =
                @"
                            [Imperative]
                            {
	                            a = 5;			//a=5;
                                b = ++a;		//b =6; a =6;
                                a++;			//a=7;
                                c = a++;		//c = 7; a = 8;
                            }
                        ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQModulo001()
        {
            String code =
                @"  [Imperative]
                    {
                        a = 10 % 4; // 2
                        b = 5 % a; // 1
                        c = b + 11 % a * 3 - 4; // 0
                    }                
                    ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQModulo002()
        {
            String code =
                @"   [Imperative]
                    {
                        a = 10 % 4; // 2
                        b = 5 % a; // 1
                        c = 11 % a == 2 ? 11 % 2 : 11 % 3; // 2
                    }
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQNegativeIndexOnCollection001()
        {
            String code =
                @"  [Imperative]
                    {
                        a = {1, 2, 3, 4};
                        b = a[-2]; // 3
                    }
                    ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQNegativeIndexOnCollection002()
        {
            String code =
                @"  [Imperative]
                    {
                        a = { { 1, 2 }, { 3, 4 } };
                        b = a[-1][-2]; // 3
                    }
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQNegativeIndexOnCollection003()
        {
            String code =
                @"
                    class A
                    {
	                    x : var[];
	
	                    constructor A()
	                    {
		                    x = { B.B(), B.B(), B.B() };
	                    }
                    }

                    class B
                    {
	                    x : var[]..[];
	
	                    constructor B()
	                    {
		                    x = { { 1, 2 }, { 3, 4 },  { 5, 6 } };		
	                    }
                    }
                    [Imperative]
                    {
                        a = { A.A(), A.A(), A.A() };

                        b = a[-2].x[-3].x[-2][-1]; // 4 
                    }
                ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQPopListWithDimension()
        {
            String code =
                @"
                class A
                {
	                x : var;
	                y : var;
	                z : var[];
	
	                constructor A()
	                {
		                x = B.B(20, 30);
		                y = 10;
		                z = { B.B(40, 50), B.B(60, 70), B.B(80, 90) };
	                }
                }

                class B
                {
	                m : var;
	                n : var;
	
	                constructor B(_m : int, _n : int)
	                {
		                m = _m;
		                n = _n;
	                }
                }

                [Imperative]
                {
	                a = A.A();
	                b = B.B(1, 2);
	                c = { B.B(-1, -2), B.B(-3, -4) };

	                a.z[-2] = b;
	                watch1 = a.z[-2].n; // 2

	                a.z[-2].m = 3;
	                watch2 = a.z[-2].m; // 3

	                a.x = b;
	                watch3 = a.x.m; // 3

	                a.z = c;
	                watch4 = a.z[-1].m; // -3
                }
                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQTestArrayOverIndexing01()
        {
            string code =
                @"
[Imperative]
{
    arr1 = {true, false};
    arr2 = {1, 2, 3};
    arr3 = {false, true};
    t = arr2[1][0];
}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQTestDynamicArray001()
        {
            String code =
                @"
[Imperative]
{
    range = 1..10;
    local = {};
    c = 0;
    for(i in range)
    {
        local[c] = i + 1;
        c = c + 1;
    }
}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test, Ignore]
        public void DebugEQTestTryCatch001()
        {
            String code =
                @"
[Imperative]
{
    x = 1;
    // t2,y2,y3 shouldn't be changed!
    t2 = 1;
    y2 = 1;
    y3 = 1;

    try
    {
        y1 = 1;
        try
        {
            t1 = 100;
        }
        catch (e:var)
        {
            t2 = 200;
        }
        t3 = 300;
    }
    catch (e :int)
    {
        y2 = 2;
    }
    catch (e:boolean)
    {
        y3 = 3;
    }
    z = 2;
}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test, Ignore]
        public void DebugEQTestTryCatch002()
        {
            string code =
                @"
class MyException
{
    ex:int;

    constructor Create()
    {
        ex = 100;
    }
}

[Imperative]
{
   x = 1;
   y1 = 0;
   y2 = 0;
   y3 = 0;
   y4 = 0;
   y5 = 0;
   y6 = 0;
   
   try
   {
       y1 = 1;
       throw 1 + 2;
       y2 = 2;
   }
   catch (e:boolean)
   {
       y3 = 3;
   }
   catch (e:int)
   {
       y4 = 4;
   }

   try
   {
       y5 = 5;
       throw MyException.Create();
       y6 = 6;
   }
   catch (e:MyException)
   {
   }

   z = 5;
}
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }






        [Test]
        public void DebugEQEmbeddedTest001()
        {

            String code =
@"[Associative]
{
	x = 0;
    [Imperative]
    {
        x = x + 5;
    }
}
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        public void DebugEQEmbeddedTest002()
        {

            String code =
@"
[Associative]
{
	x = 
    { 
        0 => x@first;
    }

    [Imperative]
    {
        x = x + 5;
    }
}
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQEmbeddedTest003()
        {

            String code =
@"
[Associative]
{
	x = 
    {
        0 => x@first;
        +1 => x@second;
    }

    [Imperative]
    {
        x = x + 5;
    }
}
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }




        [Test]
        public void DebugEQEmbeddedTest006()
        {
            String code =
                @"

c = 0;
x = c > 5 ? 1 : 2;
[Imperative]
{
    c = 10;            
}
                ";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQLanguageBlockReturn01()
        {
            String code =
@"
[Associative]
{
    a = 4;
    b = a*2;
	
    x = [Imperative]
    {
        i=0;		
        return = i; 
    }
    a = x;
    temp = 5;
}
    
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQLanguageBlockReturn02()
        {
            String code =
@"
[Associative]
{
    def DoSomthing : int(p : int)
    {
        ret = p;       
        d = [Imperative]
        {
            local = 20;
            return = local;
        }
        return = ret * 100 + d;
    }
    a = DoSomthing(10);   
}
    
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQNestedBlockInFunction01()
        {
            String code =
@"

def f : int (p : int)
{
    loc = 32;
	s = [Imperative]
	{
        n = loc + p;
        return = n;
	}
	return = s;
}
a = f(16);	
    
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        public void DebugEQNestedBlockInFunction02()
        {
            String code =
@"

def clampRange : int(i : int, rangeMin : int, rangeMax : int)
{
    result = [Imperative]
    {
	    clampedValue = i;
	    if(i < rangeMin) 
	    {
		    clampedValue = rangeMin;
	    }
	    elseif( i > rangeMax ) 
	    {
		    clampedValue = rangeMax; 
	    } 
        return = clampedValue;
    }
	return = result;
}
a = clampRange(101, 10, 100);
    
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQAccessGlobalVariableInsideFunction()
        {
            string code = @"
                                arr = { 1, 2, 3 };
                                factor = 10;

                                def foo : int[]()
                                {
	                                f = factor;

	                                [Imperative]
	                                {
		                                ix = 0;
		                                for(i in arr)
		                                {
			                                arr[ix] = arr[ix] * factor * f;
			                                ix = ix + 1;
		                                }
	                                }

	                                return = arr;
                                }

                                w = foo();
                                w0 = w[0];
                                w1 = w[1];
                                w2 = w[2];
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }




        [Test]
        public void DebugEQT22_FunctionPointer_Update()
        {
            string code = @"
			class A
			{
			x;
			}

			def foo(x)
			{
			    return = 2 * x;
			}

			def bar(x, f)
			{
			    return = f(x);
			}

			x = 100;
			a = A.A();
			a.x = x;
			x = bar(x, foo);
			t = a.x;
			";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQT22_FunctionPointerArray()
        {
            string code = @"
			def foo(x)
			{
			    return = 2 * x;
			}

			fs = {foo, foo};
			r = fs[0](100);
			";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQT23_FunctionPointerAsReturnValue()
        {
            string code = @"
			def foo(x)
			{
			    return = 2 * x;
			}


			def bar(i)
			{
			    return = foo;
			}


			fs = bar(0..1);
			f = fs[0];
			r = f(100);
			";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQT24_FunctionPointerAsReturnValue2()
        {
            string code = @"
			def foo(x)
			{
			    return = 2 * x;
			}


			def bar:function[]()
			{
			    return = {foo, foo};
			}


			fs = bar();
			f = fs[0];
			r = f(100);
			";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQT25_FunctionPointerTypeConversion()
        {
            string code = @"
			def foo:int(x)
			{
			    return = 2 * x;
			}


			def bar:var[]()
			{
			    return = {foo, foo};
			}


			fs = bar();
			f = fs[0];
			r = f(100);
			";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQT26_NestedFunctionPointer()
        {
            string code = @"
			def foo(x)
			{
			    return = 2 * x;
			}

			def bar(x)
			{
			    return = 3 * x;
			}

			def ding(x, f1:var, f2:var)
			{
			    return = f1(f2(x));
			}

			x = 1;
			r = ding(x, foo, bar);
			x = 2;
			";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQT27_FunctionPointerDefaultParameter()
        {
            string code = @"
			def foo(x, y = 10, z = 100)
			{
			    return = x + y + z;
			}

			def bar(x, f)
			{
			    return = f(x);
			}

			r = bar(1, foo);
			";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQT28_FunctionPointerInInlineCond()
        {
            string code = @"
			def foo(x, y = 10, z = 100)
			{
			    return = x + y + z;
			}

			def bar(x, y = 2, z = 3)
			{
			    return = x * y * z;
			}

			def ding(i, f, b)
			{
			    return = (i > 0) ? f(i) : b(i);
			}

			r1 = ding(1, foo, bar);
			r2 = ding(-1, foo, bar);
			";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void T29_FunctionPointerInInlineCond()
        {
            string code = @"
			def foo(x, y = 10, z = 100)
			{
			    return = x + y + z;
			}

			def ding(i, f)
			{
			    return = (i > 0) ? f(i) : f;
			}

			r1 = ding(1, foo);
			r2 = ding(-1, 100);
			";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQT30_TypeConversion()
        {
            string code = @"
			def foo()
			{
			    return = null;
			}

			t1:int = foo;
			t2:int[] = foo;
			t3:char = foo;
			t4:string = foo;
			t5:bool = foo; 
			t6:function = foo;
			";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQT31_UsedAsMemberVariable()
        {
            string code = @"
			class A
			{
			    f;
			    x;
			    constructor A(_x, _f)
			    {
			        x = _x;
			        f = _f;
			    }

			    def update()
			    {
			        x = f(x);
			        return = null;
			    }
			}

			def foo(x)
			{
			    return = 2 * x;
			}

			def bar(x)
			{
			    return = 3 * x;
			}

			a = A.A(2, foo);
			r = a.update1();
			a.f = bar;
			r = a.x;
			";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        [Category("SmokeTest")]
        public void DebugEQSimpleOp()
        {

            String code =
@"[Associative]
{
	x = 5;
    test = x *2;
}
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQArraySimpleOp()
        {

            String code =
@"[Associative]
{
	foo = {5};
    test = 2 *foo;

}
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        [Category("SmokeTest")]
        public void DebugEQArraySimpleCall01()
        {

            String code =
@"[Associative]
{
    def mult : int( s : int )	
	{
		return = s * 2;
	}

    test = mult({5});

    

}
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQArraySimpleCall02()
        {

            String code =
@"
class Tuple4
{
    mx : var;

    constructor ByCoordinates3(arr : double[])
    {
        mx = arr[2];      
    }
}
    
a = {12.0,13.0,14.0};
t = Tuple4.ByCoordinates3(a);
x = t.mx;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        [Category("SmokeTest")]
        public void ArraySimpleCall03()
        {

            String code =
@"
class Tuple4
{
    mx : var;

    constructor ByCoordinates3(arr : double)
    {
        mx = arr;      
    }
}
    
a = {12.0,13.0,14.0};
t = Tuple4.ByCoordinates3(a);
x1 = t[0].mx;
x2 = t[1].mx;
x3 = t[2].mx;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQArraySimpleCall04()
        {

            String code =
@"
def f: int( a : int )
{
    return = a + 1;
}

list = {10,20,30,40};
x = f(list);
y = x[0] + x[1];

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQTestSimpleCallAssociative()
        {

            String code =
@"def fun : double() { return = 4.0; }

a = fun();
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        [Category("SmokeTest")]
        public void TestSimpleCallImperative()
        {

            String code =
@"def fun : double() { return = 4.0; }

[Imperative]
{

a = fun();
}";

            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        [Category("SmokeTest")]
        public void TestSimpleCallWithArgAssociative()
        {

            String code =
@"def fun : double(arg: double) { return = 4.0; }

a = fun(1.0);
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        [Category("SmokeTest")]
        public void DebugEQTest1D1CellArrayCallWithArgAssociative()
        {

            String code =
@"def fun : double(arg: double) { return = 4.0; }

a = fun({1.0});
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQTest1DDeepNestCellArrayCallWithArgAssociative()
        {

            String code =
@"def fun : double(arg: double) { return = 4.0; }

a = fun({{{{{{{{{1.0}}}}}}}}});
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        [Category("Replication")]
        public void DebugEQTest1D2DeepNestCellArrayCallWithArgAssociative()
        {

            String code =
@"def fun : double(arg: double) { return = 4.0; }

a = fun({{{{{{{{{1.0, 1.2}}}}}}}}});
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void Test1DnCellArrayCallWithArgAssociative()
        {

            String code =
@"def fun : double(arg: double) { return = 4.0; }

a = fun({1.0, 2.0, 3.0, 4.0});
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQTest2DnSquareCellArrayCallWithArgAssociative()
        {

            String code =
@"def fun : double(arg: double) { return = 4.0; }

a = fun({{1.0, 2.0, 3.0, 4.0}, {5.0, 6.0, 7.0, 8.0 }});
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQTest2DnJaggedCellArrayCallWithArgAssociative()
        {

            String code =
@"def fun : double(arg: double) { return = 4.0; }

a = fun({{1.0, 2.0, 3.0, 4.0}, {5.0, 6.0}});
";



            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        [Category("SmokeTest")]
        public void Test1D1DSimpleCallWithArgAssociative()
        {

            String code =
@"def fun : double(arg: double, arg2:double) { return = 4.0; }

a = fun(1.0, 2.0);
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }
        [Test]
        [Category("SmokeTest")]
        public void Test1D1D2CallWithArgAssociative()
        {

            String code =
@"def fun : double(arg: double, arg2:double) { return = 4.0; }

a = fun(1.0, {10.0, 20.0, 30.0, 40.0});
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }
        [Test]
        [Category("SmokeTest")]
        public void DebugEQTest1D1DCellArrayCallWithArgAssociative()
        {

            String code =
@"def fun : double(arg: double, arg2:double) { return = 4.0; }

a = fun({1.0}, {2.0});
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        [Category("Replication")]
        public void DebugEQTest2D2CellArrayCallWithArgAssociative()
        {

            String code =
@"def fun : double(arg: double) { return = 4.0; }

a = fun({{1.0}, {2.0}});
";

            DebugTestFx.CompareDebugAndRunResults(code);


        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQTestIncompatibleTypes()
        {
            String code =
@"def fun : double(arg: int) { return = 4; }

class A 
{
    x : int;
    constructor A(_x : int) { x = _i; }
}

v1 = A.A(0);
v2 = fun(4);

v3 = fun ({0, 1});
v4 = fun ({A.A(0), A.A(1)});


";

            DebugTestFx.CompareDebugAndRunResults(code);



        }



        [Test]
        [Category("SmokeTest")]
        public void DebugEQTestOverloadDispatchWithTypeConversion()
        {
            String code =
@"class TestDefect
{
        def foo(val : double)
        {
                return = val;
        }

        def foo(arr : double[])
        {
                return = -123;
        }

    def sqr(val : int)
        {
                return = val * val;
        }
}

test = TestDefect.TestDefect();
arr = 5..25;
s = test.foo(arr);


";

            DebugTestFx.CompareDebugAndRunResults(code);



        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT09_Defect_1456568_Replication_On_Operators()
        {
            String code =
@"xdata = {1, 2};
ydata = {3, 4};
z = xdata + ydata;
";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT09_Defect_1456568_Replication_On_Operators_2()
        {
            String code =
@"xdata = {1, 2};
ydata = {3, 4, 5};
z = xdata * ydata;
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT09_Defect_1456568_Replication_On_Operators_3()
        {
            String code =
@"xdata = {1, 2, 5, 7};
ydata = {3, 4};
z = xdata - ydata;
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT09_Defect_1456568_Replication_On_Operators_4()
        {
            String code =
@"
class A
{
}
a1 = A.A();
xdata = {null, 0, true, a1 };
ydata = {1,1,1,1};
z = xdata + ydata;
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT09_Defect_1456568_Replication_On_Operators_5()
        {
            String code =
@"
xdata = { { 1.5, 2 } , { 1, 2 } };
ydata = { { 3, 4 } , { 5, 6.0 } };
z = xdata + ydata;
x = z[0];
y = z[1];
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT09_Defect_1456568_Replication_On_Operators_6()
        {
            String code =
@"
class A
{
    c : var[];
    constructor A ( a : var[], b : var[] )
    {
        c = a + b;
    }
    def foo ( a : var[], b : var[] )
    {
        c = a - b ;
        return = c;
    }
}
a1 = A.A( xdata, ydata);
xdata = { 1, 2 };
ydata = { 3, 4 };
z1 = a1.c;
z2 = a1.foo ( xdata, ydata );
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        [Category("SmokeTest")]
        public void DebugEQT09_Defect_1456568_Replication_On_Operators_7()
        {
            String code =
@"
def foo ( a : var[], b : var[] )
{
    c = a / b ;
    return = c;
}

a1 = A.A( xdata, ydata);
xdata = { 1, 2 };
ydata = { 3, 4 };
z1 = foo ( xdata, ydata );
xdata = { 1.5, 2 };
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        [Category("SmokeTest")]
        public void DebugEQT57_Defect_1467004_Replication_With_Method_Overload()
        {
            String code =
                            @"
                            class TestDefect
                            {
                                def foo(val : double)
                                {
                                    return = val;
                                }

                                def foo(arr : double[])
                                {
                                    return = -123;
                                }

                            }
                            test = TestDefect.TestDefect();
                            arr = 5..25;
                            s = test.foo(arr); 
                            ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        public void DebugEQT57_Defect_1467004_Replication_With_Method_Overload_2()
        {
            String code =
                            @"
                                def foo(val : double)
                                {
                                    return = val;
                                }

                                def foo(arr : double[])
                                {
                                    return = -123;
                                }
                                arr = 5..25;
                                s = test.foo(arr); 
                            ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT57_Defect_1467004_Replication_With_Method_Overload_3()
        {
            String code =
                            @"
                                def foo(val : int[])
                                {
                                    return = 1;
                                }
                                def foo(val : double[])
                                {
                                    return = 2;
                                }
                                def foo(val : int)
                                {
                                    return = 3;
                                }

                                def foo(arr : double)
                                {
                                    return = 4;
                                }
                                arr = { 3, 0, 5.5, 3 } ;
                                s = foo(arr); 
                            ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT57_Defect_1467004_Replication_With_Method_Overload_4()
        {
            String code =
                            @"
                                class A
                                {
                                }

                                a1 = A.A();
                                def foo(val : int[])
                                {
                                    return = 1;
                                }
                                def foo(val : var)
                                {
                                    return = 2;
                                }
                                
                                arr = { 3, a1, 5 } ;
                                s = foo(arr); 
                            ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT57_Defect_1467004_Replication_With_Method_Overload_5()
        {
            String code =
                            @"
                                class A
                                {
                                    x : int;
                                }
                                class B extends A
                                {
                                    y : int;
                                }

                                a1 = A.A();
                                b1 = B.B();

                                def foo(val : A[])
                                {
                                    return = 1;
                                }
                                def foo(val : B[])
                                {
                                    return = 2;
                                }
                                def foo(val : A)
                                {
                                    return = 3;
                                }
                                def foo(val : B)
                                {
                                    return = 4;
                                }
                                
                                arr = { a1, b1 } ;
                                s = foo(arr); 
                            ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT57_Defect_1467004_Replication_With_Method_Overload_6()
        {
            String code =
                            @"
                                class A
                                {
                                    x : int;
                                }
                                class B extends A
                                {
                                    y : int;
                                }

                                a1 = A.A();
                                b1 = B.B();

                                def foo(val : A[])
                                {
                                    return = 1;
                                }
                                def foo(val : B[])
                                {
                                    return = 2;
                                }
                                def foo(val : var)
                                {
                                    return = 3;
                                }
                                def foo(val : var[])
                                {
                                    return = 4;
                                }
                                
                                arr = { a1, b1 } ;
                                s = foo(arr); 
                            ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT57_Defect_1467004_Replication_With_Method_Overload_7()
        {
            String code =
                            @"  def foo(val : int[])
                                {
                                    return = 1;
                                }
                                def foo(val : double[])
                                {
                                    return = 2;
                                }
                                def foo(val : int)
                                {
                                    return = 3;
                                }
                                def foo(val : double)
                                {
                                    return = 4;
                                }
                                
                                arr = { { 1, 2}, 1, 3.5, {3.5, 2.3}, {1, 2.5}, null } ;
                                s = foo(arr); 
                            ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT58_Defect_1456115_Replication_Over_Collections()
        {
            String code =
@"
[Associative]
{
    def foo : int ( a : int, b : int )
    {
        return = a + b;
    }

    x1 = { 1, 2, 3 };
    x2 = { 1, 2, 3 };

    y = foo ( x1, x2 );

}
                            ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT58_Defect_1456115_Replication_Over_Collections_2()
        {
            String code =
@"
def foo : double (arr1 : double[], arr2 : double[] )
{
return = arr1[0] + arr2[0];
}

arr = { {2.5,3}, {1.5,2} };
two = foo (arr, arr);
t1 = two[0];
t2 = two[1];

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT58_Defect_1456115_Replication_Over_Collections_3()
        {
            String code =
@"
[Associative]
{
    def foo : int ( a : int, b : int )
    {
        return = a + b;
    }

    x1 = { 1 };
    x2 = { 1, 2, 3 };

    y = foo ( x1, x2 );

}
                            ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT58_Defect_1456115_Replication_Over_Collections_4()
        {
            String code =
@"
[Associative]
{
    def foo : int ( a : int, b : int )
    {
        return = a + b;
    }

    x1 = { 1, 2.5, null };
    x2 = { 1 };

    y = foo ( x1, x2 );

}
                            ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT58_Defect_1456115_Replication_Over_Collections_5()
        {
            String code =
@"
[Associative]
{
    def foo : int ( a : int, b : int )
    {
        return = a + b;
    }

    x1 = { 1, 2.5, null };
    x2 =  1 ;

    y = foo ( x1, x2 );

}
                            ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT58_Defect_1456115_Replication_Over_Collections_6()
        {
            String code =
@"
[Associative]
{
    def foo : int ( a : int, b : int )
    {
        return = a + b;
    }

    x1 = 0;
    x2 =  { 1, 2.5, null };

    y = foo ( x1, x2 );

}
                            ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Update")]
        public void T58_Defect_1456115_Replication_Over_Collections_7()
        {
            String code =
@"
class A
{
    x : var;
    
    def foo : int ( a : int, b : int )
    {
        x = a + b;
        return = x;
    }
}
a1 = A.A();
test = a1.x;
x1 = { 3, 4 };
x2 =  { 1, null };
y = a1.foo( x1, x2 );
";



            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT59_Defect_1463351_Replication_Over_Unary_Operators()
        {
            String code =
@"
list1 = { true, false };
list2 = !list1; // { false, true }
                            ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT59_Defect_1463351_Replication_Over_Unary_Operators_2()
        {
            String code =
@"
list1 = { true, null, a1, 0, 0.0, 1.5, 0.5, -1 };
list2 = !list1;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT59_Defect_1463351_Replication_Over_Unary_Operators_3()
        {
            String code =
@"
list1 = { { true, null}, 0, 1 };
list2 = !list1;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT59_Defect_1463351_Replication_Over_Unary_Operators_4()
        {
            String code =
@"
class A
{
}
a1 = A.A();
b1 = { true, a1 };
b = !b1;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT60_Defect_1455247_Replication_Over_Class_Instances()
        {
            String code =
@"
class Point
{
x : var;
y : var;

constructor Create(xx : int, yy : int)
{
x = xx;
y = yy;
}
}

[Associative]
{
coords = {0,1,2,3,4,5,6,7,8,9};
pts = Point.Create(coords, coords);
y = Count ( pts );
}
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT60_Defect_1455247_Replication_Over_Class_Instances_2()
        {
            String code =
@"
class Point
{
x : var;
y : var;
z : var;

constructor Create(xx : double)
{
x = xx;
}
}

class Circle
{
centerPt : var;
radius : var;

constructor Create(cp : Point, rad : double)
{
centerPt = cp;
radius = rad;
}
}

[Associative]
{
coords = {0.0,1,2,3,4,5,6,7,8,9};
pts = Point.Create(coords);

circs = Circle.Create(pts, 5.0); 
c1 = Count ( circs );
}
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT60_Defect_1455247_Replication_Over_Class_Instances_3()
        {
            String code =
@"
class Point
{
    x : var;
    y : var;
    z : var;

    constructor Create(xx : double, yy: double, zz: double)
    {
        x = xx;
        y = yy;
        z = zz;
    }
}

x1 = { 0.0, 1 };
y1 = { 0, 2.0, 3 };
z1 = { 0, 1 };
pts = Point.Create(x1, y1, z1);
c1 = Count ( pts );

";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT60_Defect_1455247_Replication_Over_Class_Instances_4()
        {
            String code =
@"
class Point
{
    x : var;
    y : var;
    z : var;

    constructor Create(xx : double, yy: double, zz: double)
    {
        x = xx;
        y = yy;
        z = zz;
    }
}

x1 = { { 0.0, 1 } };
y1 = { 0, 2.0, 3 };
z1 = { 0, 1 };
pts = Point.Create(x1, y1, z1);
c1 = Count ( pts );

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT60_Defect_1455247_Replication_Over_Class_Instances_5()
        {
            String code =
@"
class Point
{
    x : var;
    y : var;
    z : var;

    constructor Create(xx : double, yy: double, zz: double)
    {
        x = xx;
        y = yy;
        z = zz;
    }
}

x1 = { 0, 0.0, 1  };
y1 = 3;
z1 = { 0, 1 };
pts = Point.Create(x1, y1, z1);
c1 = Count ( pts );

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("SmokeTest")]
        public void DebugEQT60_Defect_1455247_Replication_Over_Class_Instances_6()
        {
            String code =
@"
class Point
{
    x : var;
    y : var;    

    constructor Create(xx : double, yy: double)
    {
        x = xx;
        y = yy;
        
    }
}

x1 = { 0, 0.0, 1  };
y1 = 3;
pts = Point.Create(x1, y1);
c1 = Count ( pts );

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT61_Defect_1463338_Replication_CallSite_Assertion()
        {
            String code =
@"
class Point_2D
{
    x : int;
    y : int;

    constructor ValueCtor(x1 : int, y1 : int)
    {
    x = x1;
    y = y1;
    }

    def GetValue()
    {
        return = x * y;
    }
}

list1 = { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
list2 = { { 1, 2, 3, 4 }, { 1, 2, 3, 4 } };

list3 = Point_2D.ValueCtor(list1, list2);

list2_0_0 = list3[0][0].GetValue(); 

";


            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        [Category("Replication")]
        public void DebugEQT62_Defect_1467075_replication_on_nested_array()
        {
            String code =
@"def fun : double(arg: double) { return = 4.0; }
a = fun({{1.0}, {2.0}});";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test, Ignore]
        [Category("Replication")]
        public void DebugEQT63_Defect_1467177_replication_in_imperative()
        {
            // need to move this to post R1 project

            String code =
@"[Imperative]
{
    def foo( a )
    {
        a = a + 1;
        return = a;
    }

    c = { 1,2,3 };
    d = foo ( c ) ;
}";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT64_Defect_1456105_replication_on_function_with_no_arg_type()
        {
            String code =
@"[Associative]
{
    def foo( a )
    {
        a = a + 1;
        return = a;
    }

    c = { 1,2,3 };
    d = foo ( c ) ;
}";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT64_Defect_1456105_replication_on_function_with_no_arg_type_2()
        {
            String code =
@"def foo2 : double (arr : double)
{
return = 0;
}

arr1 = {1,2,3,4};
sum1 = foo2(arr1);";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT64_Defect_1456105_replication_on_function_with_no_arg_type_3()
        {
            String code =
@"def foo2  (x )
{
return = x + 1;
}
def foo  (x:double )
{
return = x + 1;
}
arr1 = {1,2.0,3,4};
sum1 = foo2(arr1);

arr2 = {1,2.0,3,4};
sum2 = foo(arr1);";

            DebugTestFx.CompareDebugAndRunResults(code);

        }




        [Test]
        [Category("Replication")]
        public void DebugEQT66_Defect_1467125_Replication_Method()
        {
            String code =
@"

a = {1,2};
b = { 10, 11 };
c = { { 1 }, { 2 } };
d = { {0 } };


def foo(x : var, y : var)
{
    return = x + y;
}

rab = foo(a, b);
rac = foo(a, c);
rad = foo(a, d);


";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT66_Defect_1467125_Replication_Method_2()
        {
            String code =
                    @"

                    a = {1,2};
                    b = { 10, 11 };
                    c = { { 1 }, { 2 } };
                    d = { {0 } };


                    rab = a*b;
                    rac = a*c;
                    rad = a*d;


                    ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        public void DebugEQTest()
        {
            String code =
                    @"

                    a = {1,2};
                    b = { {10} };

                    rab = a*b;



                    ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQArray_Ranks_Match_argumentdefinition_1467190()
        {

            String code =
            @"

              class B
              {
                    value : int;
                    constructor B (b : int)
                    {
                        value = b;
                    }
               }
               class A
               {
                     a1 : var;
                     constructor A ( b1 : int)
                     {                
                        a1 = b1;
                     } 
                     def foo( arr : B[])  
                     {  
                        return = arr.value;  
                     }
                } 
                arr = { B.B(1), B.B(2), B.B(3), B.B(4) }; 
                q = A.A( {6,7,8,9} );
                t = q.foo(arr);



            ";
            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        [Category("Replication")]
        public void DebugEQT66_Defect_1467198_Inline_Condition_With_Jagged_Array()
        {
            String code =
@"a = { 1, 2};
b = { {0,2}, 1};
x = a < b ? 1 : 0;";

            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        [Category("Replication")]
        public void DebugEQT67_Defect_1460965_Replication_On_Dot_Operator()
        {
            String code =
@"class A
{
    a : int;
    constructor A ( a1 : int )
    {
        a = a1;
    }
}

c1 = { A.A(1), A.A(2) };
c2 = c1.a; 
// Expected : { 1,2 }; Recieved : null";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT67_Defect_1460965_Replication_On_Dot_Operator_2()
        {
            String code =
@"class Point
{
    x : var;

    constructor Create(xx : int)
    {
        x = xx;
    }
}
[Associative]
{
    coords = {0,1,2,3,4,5,6,7,8,9};
    pts = Point.Create(coords);
    xs = pts.x;
}";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT67_Defect_1460965_Replication_On_Dot_Operator_3()
        {
            String code =
@"class MyPoint 
{ 
    X: var;
    Y: var;
    constructor CreateXY(x : double, y : double)
    {
        X = x;
        Y = y;
    } 

}
p2 = MyPoint.CreateXY(-20.0,-30.0).X;";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT67_Defect_1460965_Replication_On_Dot_Operator_4()
        {
            String code =
@"class MyPoint 
{ 
    X: var;
    Y: var;
    constructor CreateXY(x : double, y : double)
    {
        X = x;
        Y = y;
    } 

}
p2 = MyPoint.CreateXY(0..2,-30.0).X;";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT67_Defect_1460965_Replication_On_Dot_Operator_5()
        {
            String code =
@"class A
{
    X : var;
    constructor  A ( t1 : var )
    {
        X = t1;
    }
}
a1 = A.A(1);
b1 = A.A(2);
test = { a1, b1}.X ;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT67_Defect_1460965_Replication_On_Dot_Operator_6()
        {
            String code =
@"class A
{
    X : var[];
    constructor  A ( t1 : var[] )
    {
        X = t1;
    }
}
a1 = { A.A(1..2), A.A(2..3) };
test = a1.X ;
test2 = a1.X[0];
test3 = a1.X[1];
test4 = a1[0].X[0];
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT67_Defect_1460965_Replication_On_Dot_Operator_8()
        {
            String code =
@"class A
{
    X : var[];
    constructor  A ( t1 : var[] )
    {
        X = t1;
    }
}
a1 = { A.A(1..2), A.A(2..3) };
test = a1.X ;
test2 = a1.X[0];
test3 = a1.X[1];
test4 = a1[0].X[0][1];
";

            string error = "1467264 - Sprint25: rev 3548 : over indexing should yield null value";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        [Category("Replication")]
        public void DebugEQT67_Defect_1460965_Replication_On_Dot_Operator_10()
        {
            String code =
@"class A
{
    X : var[];
    constructor  A ( t1 : var[] )
    {
        X = t1;
    }
}
a1 = { A.A(1..2), A.A(2..3) };
test1 = a1.X;
test2 = a1.X[0];
test3 = a1.X[0][0];
";

            string error = "";// "1467266 - Sprint25: rev 3549 : Accessing array members is not giving the expected result";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT68_Defect_1460965_Replication_On_Dot_Operator_7()
        {
            String code =
@"class A 
{
    x : int;
    t : int;
    constructor A( y)
    {
        x = y;
    }
}

a1 = { A.A(1), A.A(2) };
a1.t = 5;
test = a1.t;
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQArrayConvertTest()
        {
            String code =
@"def foo : int (i : double)
{
    return=i;

}

    a = {2.0, 3.5};
    b = foo(a);


";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT68_Defect_1460965_Replication_On_Dot_Operator_8()
        {
            String code =
@"class A 
{
    x : int;    
    constructor A( y)
    {
        x = y;
    }
}
class B extends A 
{
    t : int;
    constructor B( y)
    {
        x = y;
        t = x + 1;
    }
}
a1 = { B.B(1), { A.A(2), B.B( 0..1) } };
test = a1.x; //expected :  { 1, { 2, { 0, 1 } } }
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT68_Defect_1460965_Replication_On_Dot_Operator_9()
        {
            String code =
@"class A 
{
    x : int;    
    constructor A( y)
    {
        x = y;
    }
}
class B extends A 
{
    t : int;
    constructor B( y)
    {
        x = y;
        t = x + 1;
    }
}
a1 = { B.B(1), { A.A(2), B.B( 0..1) } };
test = a1.x; //expected :  { 1, { 2, { 0, 1 } } }
a1.x = 5;// expected : test = { 5, { 5, { 5, 5} } }
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }


        [Test]
        [Category("Replication")]
        public void DebugEQT69_Replication_Across_Language_Blocks()
        {
            String code =
@"def foo ( p : double)
{
    return = p;
}
i = 0;
x = { };
[Imperative]
{
	while (i == 0)  
	{
		[Associative] 
		{
			x = foo ( { 1.0,2.0 } );
		}
		i = i + 1; 
	}
}
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT70_Defect_1467266()
        {
            String code =
@"class A
{
    X : var[];
    constructor  A ( t1 : var[] )
    {
        X = t1;
    }
}
class B 
{
    a : A[];
    constructor  B ( t1 : var[] )
    {
        a = { A.A(t1), A.A(t1) };        
    }
}
a1 = { B.B(1..2), B.B(2..3) };
test1 = a1.a.X;
test2 = a1.a.X[0];
test3 = a1.a.X[0][0];
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void T71_Defect_1467209()
        {
            String code =
@"class A
{
    X : var;
    constructor  A ( t1 : var )
    {
        X = t1;
    }
}
a1 = A.A(1);
b1 = A.A(2);
test = { a1, b1}.X ;
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT71_Defect_1467209_2()
        {
            String code =
@"class A
{
    X : var[];
    constructor  A ( t1 : var[] )
    {
        X = t1;
    }
}
a = { A.A(1..2), A.A(4..5) } ;
test1 = a.X;
test2 = a.X[0];
test3 = (a.X)[0];
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT71_Defect_1467209_3()
        {
            String code =
@"class A
{
    X : var[];
    constructor  A ( t1 : var[] )
    {
        X = t1;
    }
}
class B 
{
    a : A[];
    constructor  B ( t1 : var[] )
    {
        a = { A.A(t1), A.A(t1) };        
    }
}
t1 = {{ B.B(1..2), B.B(2..3) }.a}.X;
a1 = t1[0];

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT71_Defect_1467209_4()
        {
            String code =
@"class A
{
    X : var[];
    constructor  A ( t1 : var[] )
    {
        X = t1+1;
    }
}
class B 
{
    a : A[];
    b : var[];
    constructor  B ( t1 : var[] )
    {
       a = {A.A(t1), A.A(t1)};
            
    }
}
a1 = {{ B.B(1..2), B.B(2..3) }.a}.X[0];

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT72_Defect_1467169()
        {
            String code =
@"a = { 1, 2 } ;
i = 0..1; 
b = a[i] > 0? 1 : 0; 
";

            DebugTestFx.CompareDebugAndRunResults(code);


        }

        [Test]
        [Category("Replication")]
        public void DebugEQT72_Defect_1467169_2()
        {
            String code =
@"
class A
{
    a : int;
    constructor A ( x )
    {
        a = x;
    }
}
a = { 1, 2 } ;
i = 0..1; 
b = a[i] > 0? A.A(i) : 0;
test = b.a; 
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT72_Defect_1467169_3()
        {
            String code =
@"
class A
{
    a : int[];
    constructor A ( x:int[] )
    {
        a = x;
    }
}
a = { 1, 2 } ;
i = 0..1; 
b = a[i] > 0? A.A(a[i]) : 0;
test = b.a; 
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT72_Defect_1467169_4()
        {
            String code =
@"
a = { 1, 2 } ;
b = { 3, 4, 5};
test = b[0..1] + a[0..1]; 
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT72_Defect_1467169_5()
        {
            String code =
@"
def foo ( a : int[], b :int[] )
{
    return = Count(a) + Count(b);
}
a = { 1, 2 } ;
b = { 3, 4, 5};
test = foo (b[0..1], a[0..1]); 
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT72_Defect_1467169_6()
        {
            String code =
@"
def foo ( a : int[], b :int[] )
{
    return = Count(a) + Count(b);
}
a = { 1, 2 } ;
b = { {3, 4}, {5, 6}};
test = foo (b[0..1][0..1], a[0..1]); 
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT72_Defect_1467169_7()
        {
            String code =
@"
x = { };
x[1..2] = 2 ;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT73_Defect_1467069()
        {
            String code =
@"
a = {3,1,2,10};
x = {10,11,12,13,14,15};
x[a] = 2;
y = x;
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test, Ignore]
        [Category("Replication")]
        public void DebugEQT73_Defect_1467069_2()
        {
            String code =
@"
[Imperative]
{
    a = {3,1,2,10};
    x = {10,11,12,13,14,15};
    x[a] = 2;
    y = x;
}
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT73_Defect_1467069_3()
        {
            String code =
@"
a = {2, 5};
x = {10,11,12};
x[a] = {2,2};
y = x + 1;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT73_Defect_1467069_4()
        {
            String code =
@"
class A
{
    x : int[]..[];
    constructor A()
    {
        a = {3,1,2,10};
        x = {10,11,12,13,14,15};
        x[a] = 2;
    }
    def foo ()
    {
        x[-1..-3] = 0;
        return = x;
    }
}
a1 = A.A();
y1 = a1.x + 1;
y2 = a1.foo();
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test, Ignore]
        [Category("Replication")]
        public void DebugEQT74_Defect_1463465()
        {
            String code =
@"
[Imperative]
{

def even : int (a : int) 
{ 
if(( a % 2 ) > 0 )
return = a + 1; 
else 
return = a;

return = 0;
}


x = { 1, 2, 3 };
c = even(x);
}
";

            DebugTestFx.CompareDebugAndRunResults(code);


        }

        [Test]
        [Category("Replication")]
        public void DebugEQT74_Defect_1463465_2()
        {
            String code =
@"
def even : int (a : int) 
{ 
    return = [Imperative]
    {
        if(( a % 2 ) > 0 )
            return = a + 1; 
        else 
            return = a;
    }
}
x = { 1, 2, 3 };
c = even(x);
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT75_Defect_1467282()
        {
            String code =
@"
class A
{
    c : int;
    constructor A(a : int, b : int)
    {
        c = a + b;
    }
    
}

a = { 5, 6 };
b = { 0, 1 };

x = A.A(a<1>, b<2> ).c;
y = A.A(a, b).c;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT75_Defect_1467282_2()
        {
            String code =
@"
class A
{
    c : int;
    constructor A(a : int, b : int)
    {
        c = a + b;
    }
    
}

a = { {5, 6}, {5,6} };
b = { {0, 1}, {0,1} };

x = A.A(a<1><2>, b<3><4> ).c;
y = A.A(a, b).c;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void T75_Defect_1467282_3()
        {
            String code =
@"
def sum ( a : int, b : int)
{
    return = a + b;
}
a = { {5, 6}, {5,6} };
b = { {0, 1}, {0,1} };

test = sum(a<1><2>, b<3><4> );
//expected :   test = { { { { 5, 6 }, { 5, 6 } }, { { 6, 7 }, { 6, 7 } } }, { { { 5, 6 }, { 5, 6 } }, { { 6, 7 }, { 6, 7 } } } }
//recieved :   System.NotImplemented exception
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT75_Defect_1467282_4()
        {
            String code =
@"
a = { {5, 6}, {7, 8} };
x = b[{0..1}<1>][{0..1}<2>];
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT75_Defect_1467282_5()
        {
            String code =
@"
def sum(a, b)
{
    return = a + b;

}

class A
{
    X : var[];
    constructor A( x1 : var[] )
    {
        X = x1;
    }
}
a = { A.A(0..2), A.A(3..5) };
b = { A.A(0..2), A.A(3..5) };
test = a.X<1> + b.X<2>;
test2 = sum ( a.X<1>, b.X<2>);
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT76_Defect_1467254()
        {
            String code =
@"
class A
{ 
    public x : var ;   
    constructor A ()
    {
        x = 10;       
    }
    public def foo ()
    {
       return = x + 1;
    }        
}

a = A.A();
a1 = a.foo(); //expected 5, received 11
a.x = 4;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT76_Defect_1467254_2()
        {
            String code =
@"
class A
{ 
    public x : var ;   
    constructor A ()
    {
        x = 10;       
    }
    public def foo (p)
    {
       return = x + p;
    }        
}

a = A.A();
p = a.x;
a1 = a.foo(p); //expected 5, received 11
a.x = 4;
";

            DebugTestFx.CompareDebugAndRunResults(code);


        }

        [Test]
        [Category("Replication")]
        public void DebugEQT77_Defect_1467081()
        {
            String code =
@"
x = { 0,1,2 };
y = x [ {0,1} ];
z = x [ 1..3 ];
z2 = x [ -1..-3 ];
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT77_Defect_1467081_2()
        {
            String code =
@"
x = { {0,1,2}, {3,4} };
y = x [ {0,1} ][{0,1}];

";
            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT77_Defect_1467081_3()
        {
            String code =
                @"
                class A
                {
                    x;
                    y;
                    z;
                    z2;

                    constructor A()
                    {
                        x = { 0,1,2 };
                        y = x [ {0,1} ];
                        z = x [ 1..3 ];
                        z2 = x [ -1..-3 ];
                    }
                }
                a1 = A.A();
                x1 = a1.y;
                x2 = a1.z;
                x3 = a1.z2;

                ";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT78_Defect_1467125()
        {
            String code =
@"
a = {1, 2};
b = { {10} };
rab = a*b;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT78_Defect_1467125_2()
        {
            String code =
@"
a = {{1, 2}};
b = 10;
rab = a*b;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT78_Defect_1467125_3()
        {
            String code =
@"
a = 10;
b = {{1,2}};
rab = a*b;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT78_Defect_1467125_4()
        {
            String code =
@"
a = {{10}};
b = {{1,2}};
rab = a*b;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT78_Defect_1467125_5()
        {
            String code =
@"
a = {1, 2};
b = {3, 4, 5};
rab = a*b;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT78_Defect_1467125_6()
        {
            String code =
@"
a = {1, 2};
b = {{3, 4, 5}};
rab = a*b;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT79_Defect_1467096()
        {
            String code =
@"
a = {1, 2, 3};
i = 0..1;
b = !a[i];
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT79_Defect_1467096_2()
        {
            String code =
@"
a = {1, 2, 3};
i = 0..1;
b = -a[i];
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT79_Defect_1467096_3()
        {
            String code =
@"
class A
{
    a :int[];
    constructor A ()
    {
        a = { 1, 2, 3};
    }
}
a1 = A.A();
i = 0..1;
c = a1.a;
b = a1.a[i];
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT79_Defect_1467096_4()
        {
            String code =
@"
class A
{
    a :int[];
    constructor A ()
    {
        a = { 1, 2, 3};
    }
}
a1 = A.A();
i = 0..1;
c = a1.a;
b = a1.a[i];
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT80_Defect_1467297()
        {
            String code =
@"
class A
{
    a :int[];
    constructor A ()
    {
        a = { 1, 2, 3};
    }
}
a1 = A.A();
i = 0..1;
b = -a1.a[i];
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT80_Defect_1467297_2()
        {
            String code =
@"
class A
{
    a :int[];
    constructor A ()
    {
        a = { 1, 2, 3};
    }
}
a1 = A.A();
i = 0..1;
b = -a1.a[0];
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT80_Defect_1467297_3()
        {
            String code =
@"
class A
{
    a :int[];
    constructor A ()
    {
        a = { 1, 2, 3};
    }
}
a1 = A.A();
i = 0..1;
b = -a1.a;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT80_Defect_1467297_4()
        {
            String code =
@"
class A
{
    a :int;
    constructor A ()
    {
        a = 1;
    }
}
a1 = A.A();
b = -a1.a;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT80_Defect_1467297_5()
        {
            String code =
@"
class A
{
    a :int;
    constructor A ()
    {
        a = 1;
    }
}
b = -A.A().a;

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT80_Defect_1467297_6()
        {
            String code =
@"
class B
{
    b :int;
    constructor B ()
    {
        b = 1;
    }
}
class A
{
    a :int;
    constructor A ()
    {
        a = -B.B().b;
    }
}
b = -A.A().a;

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT80_Defect_1467297_7()
        {
            String code =
@"
class B
{
    b :int;
    constructor B ()
    {
        b = 1;
    }
}
class A
{
    a :int;
    constructor A ()
    {
        a = -B.B().b;
    }
}
b = {A.A(), A.A()}.a;

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        [Category("Replication")]
        public void DebugEQT80_Defect_1467297_8()
        {
            String code =
@"
class B
{
    b :int;
    constructor B ()
    {
        b = 1;
    }
}
class A
{
    a :int;
    constructor A ()
    {
        a = -B.B().b;
    }
}
b = {-A.A().a, A.A().a};

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        [Category("Replication")]
        public void DebugEQT81_Defect_1467298()
        {
            String code =
@"
def add(a:int,b:int)
{
   return = a + b;
}
a = {1, 2, 3};
b = {3, 4, 5};
c1 = add( a[0..1], b[1..2]);
c2 = add( a<1>, b<2>);
c3 = add( a[0..1]<1>, b[1..2]<2>); 
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT81_Defect_1467299()
        {
            String code =
@"
def add(a,b)
{
   return = a + b;
}
a = {1, 2, 3};
b = {3, 4, 5};
c1 = add( a<1>, b<2>); 
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT81_Defect_1467299_2()
        {
            String code =
@"
def add(a:var,b:var)
{
   return = a + b;
}
a = {1, 2, 3};
b = {3, 4, 5};
c1 = add( a<1>, b<2>); 
";

            DebugTestFx.CompareDebugAndRunResults(code);


        }

        [Test]
        [Category("Replication")]
        public void DebugEQT81_Defect_1467299_3()
        {
            String code =
@"
def add(a:int,b:int)
{
   return = a + b;
}
a = {1, 2, 3};
b = {3, 4, 5};
c1 = add( a<1>, b<2>); 
";

            DebugTestFx.CompareDebugAndRunResults(code);


        }

        [Test]
        [Category("Replication")]
        public void DebugEQT81_Defect_1467299_4()
        {
            String code =
@"
def add(a:double,b:int)
{
   return = a + b;
}
a = {1, 2, 3};
b = {3, 4, 5};
c1 = add( a<1>, b<2>); 
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT81_Defect_1467299_5()
        {
            String code =
@"
def add(a:double,b:double)
{
   return = a + b;
}
a = {1, 2, 3};
b = {3, 4, 5};
c1 = add( a<1>, b<2>); 
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT81_Defect_1467299_6()
        {
            String code =
@"
def add(a:double,b:double)
{
   return = a + b;
}
a = {1.0, 2.0, 3.0};
b = {3.0, 4.0, 5.0};
c1 = add( a<1>, b<2>); 
";

            DebugTestFx.CompareDebugAndRunResults(code);
        }

        [Test]
        [Category("Replication")]
        public void DebugEQT81_Defect_1467299_7()
        {
            String code =
@"
def add : int (a:double,b:double)
{
   return = a + b;
}
a = {1.0, 2.0, 3.0};
b = {3.0, 4.0, 5.0};
c1 = add( a<1>, b<2>); 
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT82_Defect_1467244()
        {
            String code =
@"
class A
{

static def execute(b : A)
 { 
  return = 100; 
 }
}

arr = {A.A(), null, 3};
v1 = A.execute(null);
v2 = A.execute(3);
v3 = A.execute(arr);
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT82_Defect_1467244_2()
        {
            String code =
@"
class A
{

static def execute(b : A)
 { 
  return = 100; 
 }
}

arr = {3,3,3};
v3 = A.execute(arr);
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT82_Defect_1467244_3()
        {
            String code =
@"
class A
{

static def execute(b : A)
 { 
  return = 100; 
 }
}

arr = {null, null};
v3 = A.execute(arr);
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT83_Defect_1467253()
        {
            String code =
@"
def foo ( a : int[] , b : int[])
{
    return = a + b;
}
def foo2 ( a : int,  b : int)
{
    return = foo ( { a,b}, {a,b} );
}

arr = {1, 2};

test = foo2 ( {arr, arr },  { arr, arr} );

";

            DebugTestFx.CompareDebugAndRunResults(code);


        }

        [Test]
        [Category("Replication")]
        public void DebugEQT84_Defect_1467313()
        {
            String code =
@"
def foo ( a : int[] , b : int[])
{
    return = a + b;
}
arr = {1, 2};
test = foo ( {arr, arr },  { arr, arr} );
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }
        [Test]
        [Category("Replication")]
        public void DebugEQT85_Defect_1467076()
        {
            String code =
                    @"
                    class A
                    {
                        def foo(x : double)
                    { return = 1; }
    
                    }

                    class B extends A
                    {
                        def foo(x : double)
                            { return = 2; }
                    }


                    a = A.A();
                    val1 = a.foo();
                    
                    ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT85_Defect_1467076_a()
        {
            String code =
                    @"
                    class A
                    {
                        def foo(x : double)
                    { return = 1; }
    
                    }

                    class B extends A
                    {
                        def foo(x : double)
                            { return = 2; }
                    }


                    a = A.A();
                    val1 = a.foo(0.0);
                    
                    ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT85_Defect_1467076_2()
        {
            String code =
                    @"
                    class A
                    {
                        def foo(x : double)
                    { return = 1; }
    
                    }

                    class B extends A
                    {
                        def foo(x : double)
                            { return = 2; }
                    }


                    a = A.A();
                    val1 = a.foo();
                    b = B.B();

                    val2 = b.foo();
                    ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT85_Defect_1467076_2b()
        {
            String code =
                    @"
                    class A
                    {
                        def foo(x : double)
                    { return = 1; }
    
                    }

                    class B extends A
                    {
                        def foo(x : double)
                            { return = 2; }
                    }


                    a = A.A();
                    val1 = a.foo(1.0);
                    b = B.B();

                    val2 = b.foo(1.0);
                    ";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT86_Defect_1467285()
        {
            String code =
@"
x = { };
x[1..2] = 2 ;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT86_Defect_1467285_2()
        {
            String code =
@"
class A
{
    x : var[]..[];
    constructor A()
    {
        x = { };
        x[1..2][1..2] = 2 ;
    }
}
x = A.A().x;

";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT86_Defect_1467285_3()
        {
            String code =
@"
x = { };
x[0..1][0..1][0..1] = 2 ;
y = x;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT86_Defect_1467285_4()
        {
            String code =
@"
x = { { { 0, 0}, {0,0} }, {{0,0}, {0,0}} };
x[0..1][0..1][0..1] = 2 ;
y = x;
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT87_Defect_1467284()
        {
            String code =
@"
class A
{
}
def foo ()
{
    return = 1.5;
}
a = A.A();
x = { { { 0.6, foo()}, {5.1,0.0} }, {{null,b}, {true,a}} };
x[0..1][0..1][0..1] = 2 ;
y = x;
test = x[0..1][0..1][0..1];
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT88_Defect_1467296()
        {
            String code =
@"
class A
{
    a :int[];
    constructor A ()
    {
        a = { 1, 2, 3};
    }
}
a1 = A.A();
i = 0..1;
c = a1.a;
b = A.A().a[i];
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT88_Defect_1467296_2()
        {
            String code =
@"
class B
{
    b :int[];
    constructor B ()
    {
        b = { 1, 2, 3,4};
    }
}
class A
{
    a :int[];
    constructor A (i: int[])
    {
        a = B.B().b[i];
    }
}
a1 = A.A();
i = 0..1;
b = A.A(i).a[i];
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT88_Defect_1467296_3()
        {
            String code =
@"
class B
{
    b :int[];
    constructor B ()
    {
        b = { 1, 2, 3,4};
    }
}
class A
{
    a :int[];
    constructor A (i: int[])
    {
        a = B.B().b[i];
    }
}
a1 = A.A();
i = 0..1;
b = { A.A(i).a[i], -A.A(i).a[i] };
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT88_Defect_1467296_4()
        {
            String code =
@"
class B
{
    b :int[];
    constructor B ()
    {
        b = { 1, 2, 3,4};
    }
}
class A
{
    a :int[];
    constructor A (i: int[])
    {
        a = B.B().b[i];
    }
}
a1 = A.A();
i = 0..1;
b = { A.A(i), A.A(i) }.a[i];
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT89_Defect_1467328()
        {
            String code =
@"
def sum (a:int , b :int)
{
    return = a + b;
}
x = sum ( (1..2)<1> , (3..4)<2>);

//expected : { { 4,5}, 5,6}}
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }

        [Test]
        [Category("Replication")]
        public void DebugEQT90_Defect_1467285()
        {
            String code =
@"
a = {1,2,3,4};
b = a;
a[0..1] = {1, 2};
//a[0..1]  = a[2..3];
";

            DebugTestFx.CompareDebugAndRunResults(code);

        }


        [Test]
        public void DebugEQBaseImportAssociative()
        {
            string code = @"
[Associative]

{

	a = 5;

	def twice : int (val: int)

	{

		return = val * 2;

	}

	b = twice(a);	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQBaseImportImperative()
        {
            string code = @"
[Imperative]

{

	a = 5;

	def twice : int (val: int)

	{

		return = val * 2;

	}

	b = twice(a);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQBaseImportWithVariableClassInstance()
        {
            string code = @"
import (""T009_BasicImport_TestClassInstanceMethod.ds"");

a = 5;

b = 2*a;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQCollection_Assignment_1()
        {
            string code = @"
[Imperative]

{

	a = { {1,2}, {3,4} };

	

	a[1] = {-1,-2,3};

	

	c = a[1][1];

	

	d = a[0];

	

	b = { 1, 2 };

	

	b[0] = {2,2};



	e = b[0];

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQCollection_Assignment_2()
        {
            string code = @"
def foo: int[]( a: int,b: int )

{

	return = { a,b };

}



	c = foo( 1, 2 );

	

[Imperative]

{

	d = foo( 3 , -4 );

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQCollection_Assignment_3()
        {
            string code = @"
def foo: int[]( a: int,b: int )

{

	return = { a+1,b-2 };

}



	c = foo( 1, 2 );

	

[Imperative]

{

	d = foo( 2+1 , -3-1 );

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQCollection_Assignment_4()
        {
            string code = @"
[Imperative]
{
	def collectioninc: int[]( a : int[] )
	{
		b = a;
		j = 0;


		for( i in b )
		{
			a[j] = a[j] + 1;
			j = j + 1;
		}
		return = a;
	}

		d = { 1,2,3 };
		c = collectioninc( d );
		a1 = c[0];
		a2 = c[1];
		a3 = c[2];
}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQCollection_Assignment_5()
        {
            string code = @"
def foo: int[] ( a : int[], b: int, c:int )

{

	a[b] = c;

	return = a;

}



d = { 1,2,2 };

b = foo( d,2,3 );



[Imperative]

{

	e = { -2,1,2 };

	c = foo( e,0,0 );

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQComments_1467117()
        {
            string code = @"
/*

/*

*/



a=5;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQComments_1467117_1()
        {
            string code = @"
/*

/*

*/

*/



a=1;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQComments_Basic()
        {
            string code = @"
/*

WCS=CoordinateSystem.Identity();

p2 = Point.ByCoordinates(0,0,0);

*/



a=5;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQComments_Negative()
        {
            string code = @"
/*

WCS=CoordinateSystem.Identity();

p2 = Point.ByCoordinates(0,0,0);

*/

/*

import(""ProtoGeometry.dll"");

WCS=CoordinateSystem.Identity();

p2 = Point.ByCoordinates(0,0,0);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQComments_Nested()
        {
            string code = @"
/*

WCS=CoordinateSystem.Identity();

/*

p2 = Point.ByCoordinates(0,0,0);

*/

*/



import(""ProtoGeometry.dll"");

WCS=CoordinateSystem.Identity();

p2 = Point.ByCoordinates(0,0,0);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQCompilationErrorExpected()
        {
            string code = @"
[Associative]

{

    a = 1

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQDNITest()
        {
            string code = @"


	class DNI

	{

		startx : int;

		constructor DNI( p1 : int)

		{

			startx = p1;

        }

	}



    external (""ProtoAcDcGeometry"") def getProtoGeometryLibrary : int ();	

    external native (""ProtoGeometryEntity"") def DC_DNI_Test : double (id : int);





    hostid1 = getProtoGeometryLibrary();

	x = DNI.DNI(12);

    y = DC_DNI_Test(x);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQDefect_Geo_Replication()
        {
            string code = @"
import(""ProtoGeometry.dll"");



WCS = CoordinateSystem.Identity();

// create initialPoints



diafac1 = 1;

h1 = 15;

hL1=10;

pt0 = Point.ByCartesianCoordinates(WCS,-5*diafac1,-5*diafac1,0);

pt1 = Point.ByCartesianCoordinates(WCS,5*diafac1,-5*diafac1,0);

pt2 = Point.ByCartesianCoordinates(WCS,5*diafac1,5*diafac1,0);

pt3 = Point.ByCartesianCoordinates(WCS,-5*diafac1,5*diafac1,0);



pt4 = Point.ByCartesianCoordinates(WCS,-5*diafac1,-5*diafac1,hL1);

pt5 = Point.ByCartesianCoordinates(WCS,5*diafac1,-5*diafac1,hL1);

pt6 = Point.ByCartesianCoordinates(WCS,5*diafac1,5*diafac1,hL1);

pt7 = Point.ByCartesianCoordinates(WCS,-5*diafac1,5*diafac1,hL1);



pt8 = Point.ByCartesianCoordinates(WCS,-15,-15,h1);

pt9 = Point.ByCartesianCoordinates(WCS,15,-15,h1);

pt10= Point.ByCartesianCoordinates(WCS,15,15,h1);

pt11 = Point.ByCartesianCoordinates(WCS,-15,15,h1);



pointGroup = {pt0,pt1,pt2,pt3,pt4,pt5,pt6,pt7,pt8,pt9,pt10,pt11};

facesIndices = {{0,1,5,4},{1,2,6,5},{2,3,7,6},{3,0,4,7},{4,5,9,8},{5,6,10,9},{6,7,11,10},{7,4,8,11}};

groupOfPointGroups =  { { pt0, pt1, pt2 }, { pt3, pt4, pt5 }, { pt6, pt7, pt8 }, { pt9, pt10, pt11 } };



simplePointGroup = {pt5, pt6, pt10, pt9};



// note: Polygon.ByVertices expects a 1D array of points.. so let`s test this 



controlPolyA = Polygon.ByVertices({pt0, pt1, pt5, pt4}); // OK with 1D collection



controlPolyB = Polygon.ByVertices(simplePointGroup); // OK with 1D collection



	controlPolyC = Polygon.ByVertices({{pt1, pt2, pt6, pt5},{pt2, pt3, pt7, pt6}}); // not OK with literal 2D collection

														// get compiler error `unable to locate mamaged object for given dsObject`



	controlPolyD = Polygon.ByVertices(pointGroup[3]);    // not OK with a 1D subcollection a a member indexed from a 2D collection

														// controlPolyD = null



	controlPolyE = Polygon.ByVertices(pointGroup[facesIndices]); // not OK with an array of indices

																// controlPolyE = null



controlPolyF = Polygon.ByVertices(groupOfPointGroups);



// result = foo({ controlPolyA, controlPolyB, controlPolyC, controlPolyD, controlPolyE });





/*def foo(x:Polygon)

{

	if (x!= null)

	{

	    return = true;

	}

	else return = false;

}*/





//a simple case

c=2 * {{1},{2}};
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQDemoSupportFiles()
        {
            string code = @"
class Point

{

	X : var;

	Y : var;

	Z : var;

	

    constructor ByCoordinates(x : double, y : double, z : double)

    {

	

		X = x;

		Y = y;

		Z = z;

    }

	

	def MidValue : double[]()

	{

		return = {X/2.0, Y/2.0, Z/2.0};

	}

}

class Tube

{

	

	StartPoint : var;

	EndPoint : var;

	Radius : var;

	id : var;

	

	constructor ByPointsRadius(startPt : Point, endPt : Point, rad : double)

	{

		StartPoint = startPt;

		EndPoint = endPt;

		Radius = rad;

	}

}

class Line

{

	StartPoint: Point;

	EndPoint: Point;



	constructor ByStartPointEndPoint (startPoint : Point, endPoint : Point)

	

	{

		StartPoint = startPoint;

		EndPoint = endPoint;

	}

}



//  function to scale arrays with some scaling factor

//  this is temp workaround till we get some good replication support

//

def Scale (arr : double[], scalingFactor : double)

{

    scaledArr = [Imperative]

    {

        counter = 0;

        for(val in arr)

        {

            arr[counter] = scalingFactor * val;

            counter = counter + 1;

        }

        return = arr;

    }

    return = scaledArr;

}



def Count : int(inputArray : var[])

{

	numberOfItemsInArray = [Imperative]

	{

		index = 0;

		for (item in inputArray)

		{

			index = index + 1;

		}

		

		return = index;

	}

	

	return = numberOfItemsInArray;

}





//  this generates a 10 by 10 matrix

def Create1DArray(numberOfItemInArray : int)

    {

        stepSize = 10.0/(numberOfItemInArray-1);

        return = 0.0..10.0..stepSize;

    }

	

def Create2DArray(rows : int, columns : int)

    {

   result = [Imperative]

       {

       temp = Create1DArray(rows);

       counter = 0;

       while( counter < rows)

       {

           temp[counter] = Create1DArray(columns); //Replace each row from a sington to a collection (columns)

           counter = counter + 1;

       }

       return = temp;

       }

    return = result;

}



//  this is drop in replacement for replication guides

//  equivalent to:

//

//      mat = row<1> * col<2>

//

def CollectionCartesianProduct(row : double[], col : double[])

{

    result = [Imperative]

    {

        mat = Create2DArray(Count(row),Count(col));

        xcounter = 0;

        for(val1 in row)

        {

            ycounter = 0;

            for(val2 in col)

            {

                mat[xcounter][ycounter] = val1 * val2;

                ycounter = ycounter + 1;

            }

            xcounter = xcounter + 1;

        }

        

        return = mat;

    }

    return = result;

}



// Zip on 2 dimensional array. 

def CollectionZipAddition(mat1 : double[][], mat2 : double[][])

{

    sum = [Imperative]

    {

		row = Count(mat1);

		column = Count(mat1[0]);

        matc = Create2DArray(row, column);

        

        xcounter = 0;        

        while(xcounter < row )

        {

            ycounter = 0;

            while(ycounter < column )

            {

                matc[xcounter][ycounter] = mat1[xcounter][ycounter] + mat2[xcounter][ycounter];

                ycounter = ycounter + 1;

            }

            xcounter = xcounter + 1;

        }

        

        return = matc;

    }

    

    return = sum;

}





def CreatePoints : Point[]..[] (xs : double[], ys : double[], zs : double[][])

{

    retVal = [Imperative]

    {

		row = Count(xs);

		column = Count(ys);

		pts = Create2DArray(row, column);

        //  now create 2d array of points

        //

        xidx = 0;

        for(x in xs)

        {

            yidx = 0;

            for(y in ys)

            {

                pts[xidx][yidx] = Point.ByCoordinates(x, y, zs[xidx][yidx]);

                yidx = yidx + 1;

            }

            xidx = xidx + 1;

        }

        

        return = pts;

    }

    

    return = retVal;

}



def GenerateRoofBase (pts : Point[][])

{

		

	

	roof = [Imperative]

	{



		radius = 0.03;

		

		row = Count(pts);

		column = Count(pts[0]);

		linesVertical = Create2DArray(row, column-1);

		

        xidx = 0;

        while(xidx <= row-1)

        {

            yidx = 0;

            while(yidx <= column-2)

            {

                linesVertical[xidx][yidx] = Tube.ByPointsRadius(pts[xidx][yidx],pts[xidx][yidx+1], radius);

                yidx = yidx + 1;

            }

            xidx = xidx + 1;

        }

		

		

		linesHorizontal = Create2DArray(row-1, column);

		xidx = 0;

        while(xidx <= row-2)

        {

            yidx = 0;

            while(yidx <= column-1)

            {

                linesHorizontal[xidx][yidx] = Tube.ByPointsRadius(pts[xidx][yidx],pts[xidx+1][yidx], radius);

                yidx = yidx + 1;

            }

            xidx = xidx + 1;

        }

		

		return = {linesHorizontal, linesVertical};

	}

	

	return = roof;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQDemo_SinWave_WithoutGeometry()
        {
            string code = @"
import (""DemoSupportFiles.ds"");

import(""math.dll"");



// dimensions of the roof in each direction

//

xSize = 2;//10;

ySize = 6;//30;



// number of Waves in each direction

//

xWaves = 1;

yWaves = 1;



// number of points per Wave in each direction\

//

xPointsPerWave = 2;//10;

yPointsPerWave = 2;//10;



// amplitudes of the frequencies (z dimension)

//

lowFrequencyAmpitude  = 1.0; // only ever a single low frequency wave

highFrequencyAmpitude = 0.75; // user controls the number and amplitude of high frequency waves 



// dimensions of the beams

//

radius = 0.1;

roofWallHeight    = 0.3; // not used

roofWallThickness = 0.1; // not used



// calculate how many 180 degree cycles we need for the Waves

//

x180ToUse = xWaves==1?xWaves:(xWaves*2)-1;

y180ToUse = yWaves==1?yWaves:(yWaves*2)-1;



// count of total number of points in each direction

//

xCount = xPointsPerWave*xWaves;

yCount = yPointsPerWave*yWaves;





highX = 180*x180ToUse;

highY = 180*y180ToUse;



def CreateRangeWithDefinedNumber (start : double, end : double, number: int)

{

	stepsize = (end - start)/(number-1);

	return = start..end..stepsize;



}





//highRangeX = 0.0..highX..#xCount;

//lowRangeX = 0.0..180.0..#xCount;

//highRangeY = 0.0..highY..#yCount;

//lowRangeY = 0.0..180.0..#yCount;



highRangeX = CreateRangeWithDefinedNumber(0.0, highX, xCount);

lowRangeX = CreateRangeWithDefinedNumber(0.0, 180.0, xCount);

highRangeY = CreateRangeWithDefinedNumber(0.0, highY, yCount);

lowRangeY = CreateRangeWithDefinedNumber(0.0, 180.0, yCount);





sinHighRangeX = Math.Sin(highRangeX);

sinHighRangeY = Math.Sin(highRangeY);





xHighFrequency = Scale(sinHighRangeX, highFrequencyAmpitude);

yHighFrequency = Scale(sinHighRangeY, highFrequencyAmpitude);



//equivalent to:

//  xLowFrequency  = sin(-5..185..#xCount)*lowFrequencyAmpitude;

//  yLowFrequency  = sin(-5..185..#yCount)*lowFrequencyAmpitude;

//

sinLowRangeX = Math.Sin(lowRangeX);

sinLowRangeY = Math.Sin(lowRangeY);

xLowFrequency = Scale(sinLowRangeX, lowFrequencyAmpitude);

yLowFrequency = Scale(sinLowRangeY, lowFrequencyAmpitude);





// lowAmpitude is the cartesian product of xLowFrequency multiplied by yLowFrequency

//  equivalent to:

//  lowAmplitude = xLowFrequency<1> * yLowFrequency<2>;

//

lowAmplitude = CollectionCartesianProduct(xLowFrequency, yLowFrequency);





// lowAmplitude is the cartesian product of xLowFrequency multiplied by yLowFrequency

//  equivalent to:

//  highAmplitude = xHighFrequency<1> * yHighFrequency<2>;

//

highAmplitude = CollectionCartesianProduct(xHighFrequency, yHighFrequency);



// Ampitude in y is the zipped collection of the high frequency + low frequency

//

//  equivalent to:

//  amplitude = highAmplitude + lowAmplitude;

//

amplitude = CollectionZipAddition(highAmplitude, lowAmplitude);





//  x = 0..xSize..#xCount; --> this evaluates to 10 elements

x = 0.0..xSize..#xCount;

y = 0.0..ySize..#yCount;  //  actually this evalutes to 30 but to keep life simple i am keeping it at 10

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQDisposeVerify()
        {
            string code = @"
// GC TEST CASE

class DisposeVerify

{

	public static x : int;

}



class A

{

    public x : int;

    constructor A()

    {

        this.x = 10;

    }

	public def _Dispose : int()

    {

        DisposeVerify.x = DisposeVerify.x + 1;

		return = 10;

    }

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQDynamicReferenceResolving_Complex_Case()
        {
            string code = @"
class A

{

}



class B extends A

{

	k : var;

	

	constructor B(){}

	constructor B(p:int)

	{

		k = C.C(p);

	}

	

	def foo1:int(m:int[], t : int = 4)

	{

		return = m[0] + t;

	}

}



class C

{

	m : var;

	constructor C(){}

	constructor C(p:int)

	{

		m = {p*1, p*2, p*3};

	}

}



def foo : A()

{

	return = B.B(1);

}



def foo2 : int(b:A)

{

	return = b.foo1(b.k.m); 	//warning. will try to find foo1 at runtime. If b happends to be of type B, then it will find foo1.

}



t = foo();	// Type is recognized as A, actual type is B

tm = t.k.m;	// k does not exist in A, unbound identifier warning; tm = {1, 2, 3}

testFoo1 = t.foo1(tm); // foo1 does not exist in A, function not found warning; testFoo1 = 5;



b1 = B.B(2);

testInFunction1 = foo2(b1); //testInFunction1 = 6;



b2 = B.B(3);

testInFunction2 = foo2(b2); //testInFunction2 = 7;



[Imperative]

{

	it = foo();	// Type is recognized as A, actual type is B

	itm = it.k.m;	// k does not exist in A, unbound identifier warning; tm = {1, 2, 3}

	itestFoo1 = it.foo1(itm); // foo1 does not exist in A, function not found warning; testFoo1 = 5;



	ib1 = B.B(2);

	itestInFunction1 = foo2(ib1); //testInFunction1 = 6;



	ib2 = B.B(3);

	itestInFunction2 = foo2(ib2); //testInFunction2 = 7;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQDynamicReference_FunctionCall()
        {
            string code = @"
class A

{

}



class B extends A

{	

	def foo1:int(t : int)

	{

		return = t;

	}

}



def foo : A()

{

	return = B.B();

}



t = foo();	// Type is recognized as A, actual type is B

testFoo1 = t.foo1(6); // foo1 does not exist in A, function not found warning; testFoo1 = 6;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQDynamicReference_FunctionCall_With_Default_Arg()
        {
            string code = @"
class A

{

}



class B extends A

{	

	def foo:int(t : int = 4)

	{

		return = t;

	}

}



def afoo : A()

{

	return = B.B();

}



t = afoo();	// Type is recognized as A, actual type is B

testFoo1 = t.foo(6); // foo1 does not exist in A, function not found warning; testFoo1 =6;

testFoo2 = t.foo(); // foo1 does not exist in A, function not found warning; testFoo2 =4;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQDynamicReference_Variable()
        {
            string code = @"
class A

{

}



class B extends A

{	

	k : var;

	constructor B(x : int)

	{

		k = x;

	}

}



def foo : A(x:int)

{

	return = B.B(x);

}



t = foo(3);

kk = t.k;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test, Ignore]
        public void DebugEQFibonacci()
        {
            string code = @"
[Imperative]

{

    def fibonacci_recursive:int(number : int)

    {

        if( number < 2)

        {

            return = 1;

        }

        return = fibonacci_recursive(number-1) + fibonacci_recursive(number -2);



    }

    

    def fibonacci_iterative:int(number : int)

    {

        one = 0;

        two = 1;

       counter = 1;

        

        while( counter <= number )

        {

            temp = one + two;

            one = two;

            two = temp;

            

            //    now increment the counter

            counter = counter + 1;

        }

        

        return = two;

    }



    fib10_r = fibonacci_recursive(20);

    fib10_i = fibonacci_iterative(20);

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQGarbageCollection_1467148()
        {
            string code = @"
class B

{

    value : int;

    constructor B (b : int)

    {

		 value = b;

    }

}

class A

{

    a1 : var;

    constructor A ( b1 : int)

    {                

         a1 = b1;

    } 

    def foo( arr : B[])  

    {  

         return = arr.value;  

    }

} 

arr = { B.B(1), B.B(2), B.B(3), B.B(4) }; 

q = A.A( {6,7,8,9} );

t = q.foo(arr);

n = Count(arr);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQGeometryLibForLanguageTesting__2_()
        {
            string code = @"
def count (array : var[])

{

    c1 = [Imperative]

    {

        c = 0;

	for ( i in array )

	{

		c = c + 1;

	}

	return  = c;	

    }

    return = c1;

}



class Vector

{

    X : double;

    Y : double;

    Z : double;

    

    constructor ByCoordinates( x : double, y : double, z : double )

    {

        X = x;

	Y = y;

	Z = z;

    }    

}



class Point

{

    X : double;

    Y : double;

    Z : double;

    

    constructor ByCartesianCoordinates( x : double, y : double, z : double )

    {

        X = x;

	Y = y;

	Z = z;

    }   

    

    def DistanceTo( p2:Point )

    {

        start_x = X - p2.X;

	return = start_x;

    }

    

    def DirectionTo( p2:Point )

    {

        start_x = X - p2.X;

	start_y = Y - p2.Y;

	start_z = Z - p2.Z;

	return = Vector.ByCoordinates( start_x, start_y, start_z );

    }

    

    def Project( v1:Vector, distance : double )

    {

        start_x = X - v1.X + distance;

	start_y = Y - v1.Y + distance;

	start_z = Z - v1.Z + distance;

	return = Point.ByCartesianCoordinates( start_x, start_y, start_z );

    }

}



class Line

{

    StartPoint : Point;

    EndPoint : Point;

        

    constructor ByStartPointEndPoint( p1 : Point, p2 :Point )

    {

        StartPoint = p1;

	EndPoint = p2;

    }

    

    def PointAtParameter(  v : double )

    {

        start_x = StartPoint.X * v;

	start_y = StartPoint.Y * v;

	start_z = StartPoint.Z * v;



	p1_temp = Point.ByCartesianCoordinates( start_x, start_y, start_z );

	

	return = p1_temp;

    }

    

    def Trim ( params : double[], retain : bool )

    {

        start_x = StartPoint.X * params[0];

	start_y = StartPoint.Y * params[0];

	start_z = StartPoint.Z * params[0];

	

	end_x = EndPoint.X * params[1];

	end_y = EndPoint.Y * params[1];

	end_z = EndPoint.Z * params[1];

	

	p1_temp = Point.ByCartesianCoordinates( start_x, start_y, start_z );

	p2_temp = Point.ByCartesianCoordinates( end_x, end_y, end_z );

	

	new_trimmed_line = Line.ByStartPointEndPoint( p1_temp, p2_temp );

	return = new_trimmed_line;

    }

    

    def Trim ( v : double )

    {

        x_temp = EndPoint.X * v;

	p2_temp = Point.ByCartesianCoordinates( x_temp, EndPoint.Y, EndPoint.Z );

	new_trimmed_line = Line.ByStartPointEndPoint(StartPoint, p2_temp );

	return = new_trimmed_line;

    }

    

    

}



class Solid

{

    StartPoint : Point;

    EndPoint : Point;       

    R1 : double;

    R2 : double;

    

    constructor Cone( p1 : Point, p2 :Point , r1 : double, r2 : double)

    {

        StartPoint = p1;

	EndPoint = p2;

	R1 = r1;

	R2 = r2;

    }   

}



class Tube

{

    StartPoint : Point;

    EndPoint : Point;        

    R1 : double;

    R2 : double;

    

    constructor ByStartPointEndPointRadius( p1 : Point, p2 :Point , r1 : double, r2 : double)

    {

        StartPoint = p1;

	EndPoint = p2;

	R1 = r1;

	R2 = r2;

    }   

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQGeometryLibForLanguageTesting__3_()
        {
            string code = @"
def count (array : var[])

{

    c1 = [Imperative]

    {

        c = 0;

	for ( i in array )

	{

		c = c + 1;

	}

	return  = c;	

    }

    return = c1;

}



class Vector

{

    X : double;

    Y : double;

    Z : double;

    

    constructor ByCoordinates( x : double, y : double, z : double )

    {

        X = x;

	Y = y;

	Z = z;

    }    

}



class Point

{

    X : double;

    Y : double;

    Z : double;

    

    constructor ByCartesianCoordinates( x : double, y : double, z : double )

    {

        X = x;

	Y = y;

	Z = z;

    }   

    

    def DistanceTo( p2:Point )

    {

        start_x = X - p2.X;

	return = start_x;

    }

    

    def DirectionTo( p2:Point )

    {

        start_x = X - p2.X;

	start_y = Y - p2.Y;

	start_z = Z - p2.Z;

	return = Vector.ByCoordinates( start_x, start_y, start_z );

    }

    

    def Project( v1:Vector, distance : double )

    {

        start_x = X - v1.X + distance;

	start_y = Y - v1.Y + distance;

	start_z = Z - v1.Z + distance;

	return = Point.ByCartesianCoordinates( start_x, start_y, start_z );

    }

    

    def Translate( x1 : double, y1 : double, z1 : double )

    {

    	return = Point.ByCartesianCoordinates( X + x1, Y + y1, Z + z1 );

    }

}



class Line extends BSplineCurve

{

    StartPoint : Point;

    EndPoint : Point;

    Color : double; 

    Length : double;

    

    constructor ByStartPointEndPoint( p1 : Point, p2 :Point )

    {

        StartPoint = p1;

	EndPoint = p2;

	Length  = p2.X - p1.X;

    }

    

    def PointAtParameter(  v : double )

    {

        start_x = StartPoint.X * v;

	start_y = StartPoint.Y * v;

	start_z = StartPoint.Z * v;



	p1_temp = Point.ByCartesianCoordinates( start_x, start_y, start_z );

	

	return = p1_temp;

    }

    

    def Trim ( params : double[], retain : bool )

    {

        start_x = StartPoint.X * params[0];

	start_y = StartPoint.Y * params[0];

	start_z = StartPoint.Z * params[0];

	

	end_x = EndPoint.X * params[1];

	end_y = EndPoint.Y * params[1];

	end_z = EndPoint.Z * params[1];

	

	p1_temp = Point.ByCartesianCoordinates( start_x, start_y, start_z );

	p2_temp = Point.ByCartesianCoordinates( end_x, end_y, end_z );

	

	new_trimmed_line = Line.ByStartPointEndPoint( p1_temp, p2_temp );

	return = new_trimmed_line;

    }

    

    def Trim ( v : double )

    {

        x_temp = EndPoint.X * v;

	p2_temp = Point.ByCartesianCoordinates( x_temp, EndPoint.Y, EndPoint.Z );

	new_trimmed_line = Line.ByStartPointEndPoint(StartPoint, p2_temp );

	return = new_trimmed_line;

    }

    

    def ExtrudeAsSurface( l1 : double, v1: Vector)

    {

        return = BSplineSurface.ByPoints( { { StartPoint, Point.ByCartesianCoordinates(l1,l1,l1)}, {EndPoint, Point.ByCartesianCoordinates(v1.X,v1.Y,v1.Z) } } );

    }

    

    

}



class Solid

{

    StartPoint : Point;

    EndPoint : Point;       

    R1 : double;

    R2 : double;

    

    constructor Cone( p1 : Point, p2 :Point , r1 : double, r2 : double)

    {

        StartPoint = p1;

	EndPoint = p2;

	R1 = r1;

	R2 = r2;

    }   

}



class Tube

{

    StartPoint : Point;

    EndPoint : Point;        

    R1 : double;

    R2 : double;

    

    constructor ByStartPointEndPointRadius( p1 : Point, p2 :Point , r1 : double, r2 : double)

    {

        StartPoint = p1;

	EndPoint = p2;

	R1 = r1;

	R2 = r2;

    }   

}



class BSplineSurface

{

    P1 : Point[]..[];

    

    constructor ByPoints( p1 : Point[]..[] )

    {

        P1 = p1;

    }

}



class BSplineCurve

{

    P1 : Point[];

    

    constructor ByPoints( p1 : Point[] )

    {

        P1 = p1;

    }   

    def Project(s1: BSplineSurface , v1 : Vector)

    {

        return = BSplineCurve.ByPoints( { s1.P1[0][0], s1.P1[1][1], Point.ByCartesianCoordinates ( v1.X, v1.Y, v1.Z ) } );

    }

}



class Circle extends BSplineCurve

{

    P : Point[];

    

    constructor ByPointsOnCurve( p1 : Point[] )

    {

        P = p1;

    }    

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQGeometryLibForLanguageTesting()
        {
            string code = @"
def count (array : var[])

{

    c1 = [Imperative]

    {

        c = 0;

	for ( i in array )

	{

		c = c + 1;

	}

	return  = c;	

    }

    return = c1;

}



class Vector

{

    X : double;

    Y : double;

    Z : double;

    

    constructor ByCoordinates( x : double, y : double, z : double )

    {

        X = x;

	Y = y;

	Z = z;

    }    

}



class Point

{

    X : double;

    Y : double;

    Z : double;

    

    constructor ByCartesianCoordinates( x : double, y : double, z : double )

    {

        X = x;

	Y = y;

	Z = z;

    }   

    

    def DistanceTo( p2:Point )

    {

        start_x = X - p2.X;

	return = start_x;

    }

    

    def DirectionTo( p2:Point )

    {

        start_x = X - p2.X;

	start_y = Y - p2.Y;

	start_z = Z - p2.Z;

	return = Vector.ByCoordinates( start_x, start_y, start_z );

    }

    

    def Project( v1:Vector, distance : double )

    {

        start_x = X - v1.X + distance;

	start_y = Y - v1.Y + distance;

	start_z = Z - v1.Z + distance;

	return = Point.ByCartesianCoordinates( start_x, start_y, start_z );

    }

    

    def Translate( x1 : double, y1 : double, z1 : double )

    {

    	return = Point.ByCartesianCoordinates( X + x1, Y + y1, Z + z1 );

    }

}



class Line extends BSplineCurve

{

    StartPoint : Point;

    EndPoint : Point;

    Color : double; 

    Length : double;

    

    constructor ByStartPointEndPoint( p1 : Point, p2 :Point )

    {

        StartPoint = p1;

	EndPoint = p2;

	Length  = 1;

    }

    

    def PointAtParameter(  v : double )

    {

        start_x = StartPoint.X * v;

	start_y = StartPoint.Y * v;

	start_z = StartPoint.Z * v;



	p1_temp = Point.ByCartesianCoordinates( start_x, start_y, start_z );

	

	return = p1_temp;

    }

    

    def Trim ( params : double[], retain : bool )

    {

        start_x = StartPoint.X * params[0];

	start_y = StartPoint.Y * params[0];

	start_z = StartPoint.Z * params[0];

	

	end_x = EndPoint.X * params[1];

	end_y = EndPoint.Y * params[1];

	end_z = EndPoint.Z * params[1];

	

	p1_temp = Point.ByCartesianCoordinates( start_x, start_y, start_z );

	p2_temp = Point.ByCartesianCoordinates( end_x, end_y, end_z );

	

	new_trimmed_line = Line.ByStartPointEndPoint( p1_temp, p2_temp );

	return = new_trimmed_line;

    }

    

    def Trim ( v : double )

    {

        x_temp = EndPoint.X * v;

	p2_temp = Point.ByCartesianCoordinates( x_temp, EndPoint.Y, EndPoint.Z );

	new_trimmed_line = Line.ByStartPointEndPoint(StartPoint, p2_temp );

	return = new_trimmed_line;

    }

    

    def ExtrudeAsSurface( l1 : double, v1: Vector)

    {

        return = BSplineSurface.ByPoints( { { StartPoint, Point.ByCartesianCoordinates(l1,l1,l1)}, {EndPoint, Point.ByCartesianCoordinates(v1.X,v1.Y,v1.Z) } } );

    }

    

    

}



class Solid

{

    StartPoint : Point;

    EndPoint : Point;       

    R1 : double;

    R2 : double;

    

    constructor Cone( p1 : Point, p2 :Point , r1 : double, r2 : double)

    {

        StartPoint = p1;

	EndPoint = p2;

	R1 = r1;

	R2 = r2;

    }   

}



class Tube

{

    StartPoint : Point;

    EndPoint : Point;        

    R1 : double;

    R2 : double;

    

    constructor ByStartPointEndPointRadius( p1 : Point, p2 :Point , r1 : double, r2 : double)

    {

        StartPoint = p1;

	EndPoint = p2;

	R1 = r1;

	R2 = r2;

    }   

}



class BSplineSurface

{

    P1 : Point[]..[];

    

    constructor ByPoints( p1 : Point[]..[] )

    {

        P1 = p1;

    }

}



class BSplineCurve

{

    P1 : Point[];

    

    constructor ByPoints( p1 : Point[] )

    {

        P1 = p1;

    }   

    def Project(s1: BSplineSurface , v1 : Vector)

    {

        return = BSplineCurve.ByPoints( { s1.P1[0][0], s1.P1[1][1], Point.ByCartesianCoordinates ( v1.X, v1.Y, v1.Z ) } );

    }

}



class Circle extends BSplineCurve

{

    P : Point[];

    

    constructor ByPointsOnCurve( p1 : Point[] )

    {

        P = p1;

    }    

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQImportTest001()
        {
            string code = @"
import(""import001.ds"");

import(""import002.ds"");



a = 10;

b = 20;



c = add(a, b);

d = mul(a, b);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQLineTest()
        {
            string code = @"
	

	external (""ProtoAcDcGeometry"") def getProtoGeometryLibrary : int ();

    class Point

    {

		

        mx : var;

        my : var;

        mz : var;

        id : var;



        external native (""ProtoGeometryEntity"") def DC_Point : int (x : double, y : double, z : double);

        

        constructor Point(xx : double, yy : double, zz : double)

        {

            mx = xx;

            my = yy;

            mz = zz;

            id = DC_Point(xx, yy, zz);

        }

    }



	hostid1 = getProtoGeometryLibrary();

	point1 = Point.Point(43.0314374592,94.2314010018,0.0550158535042);



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQLineTest1()
        {
            string code = @"
[Associative]

{	

	external (""ProtoAcDcGeometry"") def getProtoGeometryLibrary : int ();

    external native (""ProtoGeometryEntity"") def DC_Line : int (y : int, z : int);

	hostid1 = getProtoGeometryLibrary();

	lineid = DC_Line(2,3);



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQLineTest2()
        {
            string code = @"
	

	external (""ProtoAcDcGeometry"") def getProtoGeometryLibrary : int ();

    external native (""ProtoGeometryEntity"") def DC_Line : int (y : int, z : int);

    //id1 : int;

    //id2 : int;

    class Point

    {

		

        mx : var;

        my : var;

        mz : var;

        id : var;



        external native (""ProtoGeometryEntity"") def DC_Point : int (x : double, y : double, z : double);

        

        constructor Point(xx : double, yy : double, zz : double)

        {

            mx = xx;

            my = yy;

            mz = zz;

            id = DC_Point(xx, yy, zz);

        }

    }



	hostid1 = getProtoGeometryLibrary();

    point1 = Point.Point(43.0314374592,94.2314010018,0.0550158535042);

    point2 = Point.Point(43.0314374592,9.5,0.0550158535042);

    id1 = point1.id;

    id2 = point2.id;

    lineid2 = DC_Line(id1, id2);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQLineTest3()
        {
            string code = @"
	

	external (""ProtoAcDcGeometry"") def getProtoGeometryLibrary : int ();

    class Point

    {

		

        mx : var;

        my : var;

        mz : var;

        id : var;



        external native (""ProtoGeometryEntity"") def DC_Point : int (x : double, y : double, z : double);

        

        constructor Point(xx : double, yy : double, zz : double)

        {

            mx = xx;

            my = yy;

            mz = zz;

            id = DC_Point(xx, yy, zz);

        }

    }



    class Line

    {

		

        start : var;

        end : var;

        id : var;



        external native (""ProtoGeometryEntity"") def DC_Line : int (y : int, z : int);

        

        constructor Line(sp : int, ep : int)

        {

            start = sp;

            end = ep;

            id = DC_Line(sp, ep);

        }

    }



	hostid1 = getProtoGeometryLibrary();

    point1 = Point.Point.Point(43.0314374592,94.2314010018,0.0550158535042);

    point2 = PointPoint.Point(43.0314374592,9.5,0.0550158535042);

    line1 = Line.Line(point1.id, point2.id);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1452951()
        {
            string code = @"
[Associative]

{

	a = { 4,5 };

   

	[Imperative]

	{

	       //a = { 4,5 }; // works fine

		x = 0;

		for( y in a )

		{

			x = x + y;

		}

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454511()
        {
            string code = @"
[Imperative]

{

	x = 0;

	

	for ( i in b )

	{

		x = x + 1;

	}

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454692()
        {
            string code = @"
[Imperative]

{

	x = 0;

	b = 0..3; //{ 0, 1, 2, 3 }

	for( y in b )

	{

		x = y + x;

	}

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454692_2()
        {
            string code = @"
def length : int (pts : double[])

{

    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }

        

        return = counter;

    }

    return = numPts;

}

    

arr = 0.0..3.0;//{0.0,1.0,2.0,3.0};

num = length(arr);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454918_1()
        {
            string code = @"
[Associative] // expected 2.5

{

	 def Divide : double (a:int, b:int)

	 {

	  return = a/b;

	 }

	 d = Divide (5,2);

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454918_2()
        {
            string code = @"
[Associative] // expected error

{

	 def foo : int (a:double)

	 {

		  return = a;

	 }

	 d = foo (5.5);

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454918_3()
        {
            string code = @"
[Associative] // expected d = 5.0

{

	 def foo : double (a:double)

	 {

		  return = a;

	 }

	 d = foo (5.0);

} 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454918_4()
        {
            string code = @"
[Associative] // expected error

{

	 def foo : double (a:bool)

	 {

		  return = a;

	 }

	 d = foo (true);

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454918_5()
        {
            string code = @"
class A

{

	a : var;



	constructor CreateA ( a1 : int )

	{

		a = a1;

	}

	

}



[Associative] 

{

	 def foo : int (a : A)

	 {

             return = a;

	 }

	 a1 = A.CreateA(1);

	 d = foo (a1);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454918_6()
        {
            string code = @"
     def foo : double ()

	 {

		  return = 5;

	 }

	 d = foo ();

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454926()
        {
            string code = @"
[Imperative]

{	 

	 d1 = null;

	 d2 = 0.5;	 

	 result = d1 * d2; 

	 result2 = d1 + d2; 

 

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454966()
        {
            string code = @"
class A

{

	a : var;



	constructor CreateA ( a1 : int )

	{

		a = a1;

	}	

}



[Associative]

{	

	a1 = A.CreateA(1).a;	

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454966_10()
        {
            string code = @"
class A

{

a : var[];

constructor A ( b : int )

{

a = { b, b, b };

}



}

[Imperative]

{

	x = { 1, 2, 3 };

	//a1 = A.A( x ).a; // error here

	a2 = A.A( x );

	t1 = a2[0].a[0];

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454966_2()
        {
            string code = @"
class A

{

    a : var;

	constructor A ( i : int)

	{

	    a = i;

	}

}



def create:A( b )

{

    a = A.A(b);

	return = a;

}



x = create(3).a;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454966_3()
        {
            string code = @"
class A

{    

	a : var;    

	constructor A ( b : int )    

	{        

		a = { b, b, b };    

	}		

	

}



[Imperative]

{

	x = { 1, 2, 3 };

	a1 = A.A( x ).a;

	a2 = A.A( x );

	t1 = a2[0].a[0];

	t2 = a2[1].a[1];

	t3 = a2[2].a[2];

	a3 = a2[0].a[0] + a2[1].a[1] +a2[2].a[2];

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454966_4()
        {
            string code = @"
class Test

{

 A: double[];

       

  constructor Test (a : double[])

 {

  A = a;

 

 }



}





 value = Test.Test ({1.3,3.0,5.0});

 value2 = Test.Test (1.3);

 getval= value.A;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454966_5()
        {
            string code = @"
class Test

{

 A : double[];

       

  constructor Test (a : double[])

 {

  A = a;

 

 }



}





 value = Test.Test ({1.3,3.0,5.0});

 getval= value.A;

 getval2= value.A[0];

 b=1;

 getval3= value.A[b];

 b=2;

 getval4= value.A[b];

 b=-1;

 getval5= value.A[b];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454966_6()
        {
            string code = @"
class Test

{

 A : double;

       

  constructor Test (a : double)

 {

  A = a;

 

 }



};

 value = Test.Test (1.3);

def call:double(b:Test)

{



 getval= b.A;

 return= getval;

 }

c= call(value);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454966_7()
        {
            string code = @"
class Test

{

 A : double;

       

 constructor Test (a : double)

 {

  A = a;

 

 }



};

[Imperative]

{	



	d = { 1,2,3 };	

	val={0,0,0};

	j = 0;	

	for( i in d )	

	{		

	    val[j]=Test.Test(i).A;

	    j = j + 1;	



	}	

	a1 = val;	



	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454966_8()
        {
            string code = @"
class A

{ 

	x : int[];	

	

	constructor A ( i :int[])

	{

		x = i;

       	

	}

 

	public def foo ()

	{

	    return = x;

	}

}



class B

{ 

	public x : A[] ;	

	

	constructor B (i:A[])

	{

		x = i;

       

	}

 

	public def foo ()

	{

	    return = x;

	}	

	

}



x = { 1, 2, 3 };

y = { 4, 5, 6 };

a1 = A.A(x);

a2 = A.A(y);

b1 = B.B({a1,a2});

t1 = b1.x[0].x[1];





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454966_9()
        {
            string code = @"
class A

{

a:int;

constructor A ()

{



}

}

class B

{

public x : var ;



constructor B (i)

{

x = i;

}

}

a1 = A.A();

a2 = A.A();

a3 = {a1,a2};

b1 = B.B(a3);

b2=b1[0].x.a;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1454980()
        {
            string code = @"
import (""TestImport.ds"");

class Math

{

                //external (""ffi_library"") def dc_sqrt : double (val : double );

                //external (""ffi_library"") def dc_factorial : int (val : int );

           

                constructor GetInstance()

                {}

                

                def Sqrt : double ( val : double )

                {

                                return = dc_sqrt(val);

                }



                def Factorial : int ( val : int )

                {

                                return = dc_factorial(val); //issue is here. the below line will pass

                                //return = dc_factorial(10);

                }

}





                math = Math.GetInstance();

                result = math.Factorial(3);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1455158()
        {
            string code = @"


	class TestPoint

	{

        X : var;

        Y : var;

             

        constructor Create(xx : int, yy : int)

        {

			X = xx; 

            Y = yy;



        }            



        def Modify : TestPoint()

        {

            tempX = X + 1;

            tempY = Y + 1;

            return = TestPoint.Create(tempX, tempY);

        }            

	}

	



	



	pt1 = TestPoint.Create(1, 2);



	pt2 = pt1.Modify();

	x2 = pt2.X;

	y2 = pt2.Y;

	pt3 = pt2.Modify();



	x3 = pt3.X;

	y3 = pt3.Y;

	

	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1455276()
        {
            string code = @"
class Point

{

    x : var;

    y : var;

    z : var;

    

    public constructor Create(xx : double, yy : double, zz: double)

    {

        x = xx;

        y = yy;

        z = zz;

    }

    

    public def SquaredDistance : double (otherPt : Point)

    {

        //distx = (otherPt.x -x) * (otherPt.x -x);



        distx = (otherPt.x-x);

        distx = distx * distx;

   

        disty = otherPt.y -y;

        //disty = disty * disty;

        

        distz = otherPt.z -z;

        //distz = distz * distz;

                

        return = distx + disty + distz;

    }

}



pt1 = Point.Create(0,0,0);

pt2 = Point.Create(10.0, 0 ,0 );



dist = pt1.SquaredDistance(pt2);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1455283()
        {
            string code = @"
class MyPoint

    

    {

    

    X: double;

    Y: double;

    

    constructor CreateByXY(x : double, y : double)

        

        

        {

        X = x;

        Y = y;

        

        }   

    }

    

class MyNewPoint extends MyPoint

    {

    

    Z : double;

    

    constructor Create (x: double, y: double, z : double) : base.CreateByXY(x, y)

        {

         Z = z;

        }

    }

   

test = MyNewPoint.Create (10, 20, 30);

x = test.X;

y = test.Y;

z = test.Z;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1455283_1()
        {
            string code = @"
class B

{ 

	x3 : int ;

		

	constructor B () 

	{	

		x3 = 2;

	}

}



class A extends B

{ 

	x1 : int ;

	x2 : double;

	

	constructor A () : base.B ()

	{	

		x1 = 1; 

		x2 = 1.5;		

	}

}





a1 = A.A();

b1 = a1.x1;

b2 = a1.x2;

b3 = a1.x3;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1455291()
        {
            string code = @"
class CoordinateSystem

{}



class Vector

{

    public GlobalCoordinates : var;

    public X : var;

    public Y : var;

    public Z : var;

    public Length : var;

    public Normalized : var;

    public ParentCoordinateSystem : var;

    public XLocal : var;

    public YLocal : var;

    public ZLocal : var;



    public constructor ByCoordinates(x : double, y : double, z : double)

    {

        X = x;

        Y = y;

        Z = z;

    }

    

    public constructor ByCoordinates(cs: CoordinateSystem, xLocal : double, yLocal : double, zLocal : double )

    {

        ParentCoordinateSystem = cs;

        XLocal = xLocal;

        YLocal = yLocal;

        ZLocal = zLocal;

    }



    public constructor ByCoordinateArray(coordinates : double[])

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];    

    }



    public def Cross : Vector (otherVector : Vector)

    {

        return = Vector.ByCoordinates(

            Y*otherVector.Z - Z*otherVector.Y,

            Z*otherVector.X - X*otherVector.Z,

            X*otherVector.Y - Y*otherVector.X);

    }



}





    a = 5;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1455568()
        {
            string code = @"
class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    public def Multiply  (other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

}



C0 = Tuple4.XYZH(1.0,0,0,0);

C1 = Tuple4.XYZH(0,1.0,0,0);

C2 = Tuple4.XYZH(0,0,1.0,0);

C3 = Tuple4.XYZH(0,0,0,1.0);



t = Tuple4.XYZH(1,1,1,1);



tx = Tuple4.XYZH(C0.X, C1.X, C2.X, C3.X);

RX = tx.Multiply(t);



ty = Tuple4.XYZH(C0.Y, C1.Y, C2.Y, C3.Y);

RY = ty.Multiply(t);



tz = Tuple4.XYZH(C0.Z, C1.Z, C2.Z, C3.Z);

RZ = tz.Multiply(t);



th = Tuple4.XYZH(C0.H, C1.H, C2.H, C3.H);

RH = th.Multiply(t);

       

result1 =  Tuple4.XYZH(RX, RY, RZ, RH);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1455584()
        {
            string code = @"
class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double(other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 :double[] () 

    { 

        return = {X, Y, Z, H };

    }

    

    

}

cor1 = {10.0, 10.0, 10.0, 10.0};

cor2 = {10.0, 10.0, 10.0, 10.0};





tuple1 = Tuple4.ByCoordinates4 (cor1);

tuple1 = Tuple4.XYZH (1,1,1,1);

tuple2 = Tuple4.ByCoordinates4 (cor2);



result1 = tuple1.Coordinates4();

result2 = tuple2.Coordinates4();



multiply1 = tuple1.Multiply(tuple2);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1455618()
        {
            string code = @"
class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double (other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 : double[] () 

    { 

        return = {X, Y, Z, H };

    }

}



class Vector

{

    X : var;

    Y : var;

    Z : var;

    

    public constructor ByCoordinates(xx : double, yy : double, zz : double)

    {

        X = xx;

        Y = yy;

        Z = zz;

    }

}



class Transform

{

    public C0 : Tuple4; 

    public C1 : Tuple4; 

    public C2 : Tuple4; 

    public C3 : Tuple4;     

    

    public constructor ByTuples(C0Value : Tuple4, C1Value : Tuple4, C2Value : Tuple4, C3Value : Tuple4)

    {

        C0 = C0Value;

        C1 = C1Value;

        C2 = C2Value;

        C3 = C3Value;

    }



    public constructor ByData(data : double[][])

    {

        C0 = Tuple4.ByCoordinates4(data[0]);

        C1 = Tuple4.ByCoordinates4(data[1]);

        C2 = Tuple4.ByCoordinates4(data[2]);

        C3 = Tuple4.ByCoordinates4(data[3]);

    }

    

    public def ApplyTransform : Tuple4 (t : Tuple4)

    {

        //a = C0.X;

        tx = Tuple4.XYZH(C0.X, C1.X, C2.X, C3.X);

        RX = tx.Multiply(t);



        ty = Tuple4.XYZH(C0.Y, C1.Y, C2.Y, C3.Y);

        RY = ty.Multiply(t);



        tz = Tuple4.XYZH(C0.Z, C1.Z, C2.Z, C3.Z);

        RZ = tz.Multiply(t);



        th = Tuple4.XYZH(C0.H, C1.H, C2.H, C3.H);

        RH = th.Multiply(t);



        return = Tuple4.XYZH(RX, RY, RZ, RH);

    }

    

    public def TransformVector : Vector (p: Vector)

    {    

        tpa = Tuple4.XYZH(p.X, p.Y, p.Z, 0.0);

        tpcv = ApplyTransform(tpa);

        return = Vector.ByCoordinates(tpcv.X, tpcv.Y, tpcv.Z);    

    }

}



data = {    {1.0,0,0,0},

            {0.0,1,0,0},

            {0.0,0,1,0},

            {0.0,0,0,1}

        };

        

xform = Transform.ByData(data);

c0 = xform.C0;



c0_X = c0.X;

c0_Y = c0.Y;

c0_Z = c0.Z;

c0_H = c0.H;



vec111 = Vector.ByCoordinates(1,1,1);

tempTuple = Tuple4.XYZH(vec111.X, vec111.Y, vec111.Z, 0.0);

tempcv = xform.ApplyTransform(tempTuple);



x = tempcv.X;

y = tempcv.Y;

z = tempcv.Z;

h = tempcv.H;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1455621()
        {
            string code = @"
class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double (other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 : double[] () 

    { 

        return = {X, Y, Z, H };

    }

}

/*

t1 = Tuple4.XYZH(0,0,0,0);

t2 = Tuple4.XYZ(0,0,0);

t3 = Tuple4.ByCoordinates3({0.0,0,0});

t4 = Tuple4.ByCoordinates4({0.0,0,0,0});

mult = t1.Multiply(t2);



c3 = t3.Coordinates3();

c4 = t3.Coordinates4();

*/

class Vector

{

    X : var;

    Y : var;

    Z : var;

    

    public constructor ByCoordinates(xx : double, yy : double, zz : double)

    {

        X = xx;

        Y = yy;

        Z = zz;

    }

}



class Transform

{

    public C0 : Tuple4; 

    public C1 : Tuple4; 

    public C2 : Tuple4; 

    public C3 : Tuple4;     

    

    public constructor ByTuples(C0Value : Tuple4, C1Value : Tuple4, C2Value : Tuple4, C3Value : Tuple4)

    {

        C0 = C0Value;

        C1 = C1Value;

        C2 = C2Value;

        C3 = C3Value;

    }



    public constructor ByData(data : double[][])

    {

        C0 = Tuple4.ByCoordinates4(data[0]);

        C1 = Tuple4.ByCoordinates4(data[1]);

        C2 = Tuple4.ByCoordinates4(data[2]);

        C3 = Tuple4.ByCoordinates4(data[3]);

    }

    

    public def ApplyTransform : Tuple4 (t : Tuple4)

    {

        tx = Tuple4.XYZH(C0.X, C1.X, C2.X, C3.X);

        RX = tx.Multiply(t);



        ty = Tuple4.XYZH(C0.Y, C1.Y, C2.Y, C3.Y);

        RY = ty.Multiply(t);



        tz = Tuple4.XYZH(C0.Z, C1.Z, C2.Z, C3.Z);

        RZ = tz.Multiply(t);



        th = Tuple4.XYZH(C0.H, C1.H, C2.H, C3.H);

        RH = th.Multiply(t);

        

        return = Tuple4.XYZH(RX, RY, RZ, RH);

    }



    public def NativeMultiply : Transform(other : Transform)

    {              

        tc0 = ApplyTransform(other.C0);

        tc1 = ApplyTransform(other.C1);

        tc2 = ApplyTransform(other.C2);

        tc3 = ApplyTransform(other.C3);

        return = Transform.ByTuples(tc0, tc1, tc2, tc3);

    }

    

    public def NativePreMultiply : Transform (other : Transform)

    {     

        //  as we don't have this now let's do it longer way!        

        //return = other.NativeMultiply(this);

        //

        tc0 = other.ApplyTransform(C0);

        tc1 = other.ApplyTransform(C1);

        tc2 = other.ApplyTransform(C2);

        tc3 = other.ApplyTransform(C3);

        return = Transform.ByTuples(tc0, tc1, tc2, tc3);

    }



}



data = {    {1.0,0,0,0},

            {0.0,1,0,0},

            {0.0,0,1,0},

            {0.0,0,0,1}

        };

        

xform = Transform.ByData(data);

c0 = xform.C0;



c0_X = c0.X;

c0_Y = c0.Y;

c0_Z = c0.Z;

c0_H = c0.H;



vec111 = Vector.ByCoordinates(1,1,1);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1455643()
        {
            string code = @"
class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    

    constructor ByCoordinates4 (coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    public def Equals : bool (other : Tuple4)

    {

        return =   X == other.X &&

                   Y == other.Y &&

                   Z == other.Z &&

                   H == other.H;

    }

}



class Transform

{

    public C0 : Tuple4; 

    public C1 : Tuple4; 

    public C2 : Tuple4; 

    public C3 : Tuple4;     



    public constructor ByData(data : double[][])

    {

        C0 = Tuple4.ByCoordinates4(data[0]);

        C1 = Tuple4.ByCoordinates4(data[1]);

        C2 = Tuple4.ByCoordinates4(data[2]);

        C3 = Tuple4.ByCoordinates4(data[3]);

    }

   

   def Equals : bool (other : Transform )

   {

        return =C0.Equals(other.C0) &&

                C1.Equals(other.C1) &&

                C2.Equals(other.C2) &&

                C3.Equals(other.C3);

   }

}



data1 = {    {1.0,0,0,0},

            {0.0,1,0,0},

            {0.0,0,1,0},

            {0.0,0,0,1}

        };

        

data2 = {    {1.0,0,0,0},

    {1.0,1,0,0},

    {0.0,0,1,0},

    {0.0,0,0,1}

};

        

        

xform1 = Transform.ByData(data1);

xform2 = Transform.ByData(data2);

areEqual1 = xform1.Equals(xform1);

areEqual2 = xform1.Equals(xform2);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1455729()
        {
            string code = @"
def cos : double(val : double)

{

    return = val;

}



def sin : double ( val : double)

{

    return = val;

}



class Geometry

{

    private id : var;

}



class Plane extends Geometry

{}



class Curve extends Geometry

{}



class Surface extends Geometry

{}



class Solid extends Geometry

{}



class Color

{}



class CoordinateSystem extends Geometry

{}



class Vector

{}



class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double (other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 : double[] () 

    { 

        return = {X, Y, Z, H };

    }

}





class Point extends Geometry

{



    public color                    : var;    //= Color.Yellow;

    public XTranslation             : var; // double = 0;

    public YTranslation             : var; //double = 0;

    public ZTranslation             : var; //double = 0;

    public ParentCoordinateSystem   : var; //CoordinateSystem = CoordinateSystem.BaseCoordinateSystem;

    public GlobalCoordinates        : var; //= 0.0;

    public X                        : var; //double = GlobalCoordinates[0];

    public Y                        : var; //double = GlobalCoordinates[1];

    public Z                        : var; //double = GlobalCoordinates[2];

    public Radius                   : var; //double = 0.0;

    public Theta                    : var; //double = 0.0;

    public Height                   : var; //double = 0.0;

    public Phi                      : var; //double = 0.0;



    //  properties due to various AtParameter/Project constructors

    public MySurface                  : var;//Surface = null;

    public MyCurve                    : var;//Curve = null;

    public U                        : var; //double = null;

    public V                        : var;//double = null;

    public T                        : var;//double = null;

    public Distance                 : var;// double = null;

    public Direction                : var;//Vector = null;

    public MyPlane                    : var; //Plane = null;

    private bHostEntityCreated      : var;// = DC_Point_updateHostPoint(hostEntityID, {X, Y, Z});



    public def ComputeGlobalCoords : double[] (cs: CoordinateSystem, x : double, y : double, z : double)

    {

        /*localCoordsTuple = Tuple4.XYZ(x, y, z);

        globalCoordsTuple = cs.Matrix.ApplyTransform(localCoordsTuple);

        return = {globalCoordsTuple.X, globalCoordsTuple.Y, globalCoordsTuple.Z};*/

        return = {x, y, z};

    }



    private def init : bool ()

    {

        color                  =  null;

        XTranslation           =  0.0;

        YTranslation           =  0.0;

        ZTranslation           =  0.0;

        ParentCoordinateSystem =  null;

        GlobalCoordinates      =  null;

        X                      =  0.0;

        Y                      =  0.0;

        Z                      =  0.0;

        Radius                 =  0.0;

        Theta                  =  0.0;

        Height                 =  0.0;

        Phi                    =  0.0;

        

        MySurface                 =   null;

        MyCurve                   =   null;

        U                       = 0.0;

        V                       = 0.0;

        T                       = 0.0;

        Distance                = 0.0;

        Direction               = null;

        MyPlane                   = null;

        bHostEntityCreated      = false;

        

        // id is a private member in base class

        // id                      = null;

        

        return = true;

    }

    



    

    public constructor ByCylindricalCoordinates(cs : CoordinateSystem, radius : double, theta : double, height : double)

    {

        neglect = init();

        

        ParentCoordinateSystem = cs;

        Radius = radius;

        Theta = theta;

        Height = height;



        XTranslation = Radius*cos(Theta);

        YTranslation = Radius*sin(theta);

        ZTranslation = Height;

        //GlobalCoordinates = ComputeGlobalCoords(ParentCoordinateSystem, XTranslation, YTranslation, ZTranslation);



        X = GlobalCoordinates[0];

        Y = GlobalCoordinates[1];

        Z = GlobalCoordinates[2];

    }

}



a = 2;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1455738()
        {
            string code = @"
[Associative]

{

    a = 3;

    b = a * 2;

    a = 4;

}















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1455935()
        {
            string code = @"
[Imperative]

{

	def foo:int ( a : bool )

	{

		if(a)

			return = 1;



		else

			return = 0;

	}



	

	b = foo( 1 );

	c = foo( 1.5 );

	d = 0;

	if(1.5 == true ) 

	{

	    d = 3;

	}

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1456611()
        {
            string code = @"
class A

{

    a : var;

	constructor A ( i : int)

	{

	    a = i;

	}

}



def create( b )

{

    a = A.A(b);

	return = a;

}



x = create(3);

y = x.a;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1456611_2()
        {
            string code = @"
 



class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}

[Imperative]

{

    def length : int (pts : A[])

    {

        numPts = [Associative]

        {

            return = [Imperative]

            {

                counter = 0;

                for(pt in pts)

                {

                    counter = counter + 1;

                }        

                return = counter;

            }

        }

        return = numPts;

    }







    pt1 = A.A( 0 );

    pt2 = A.A( 10 );



    pts = {pt1, pt2};



    numpts = length(pts); // getting null

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1456611_3()
        {
            string code = @"
// function test -return class array, argument as class array 



class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}



def length : A[] (pts : A[])

{

    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }

    return = pts;

}





pt1 = A.A( 0 );

pt2 = A.A( 10 );



pts = {pt1, pt2};



numpts = length(pts); // getting null



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1456611_4()
        {
            string code = @"
//  function test return int , multiple arguments 

class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}



def length : int (pts : A[],num:int)

{



    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }



    return = num;

}





pt1 = A.A( 0 );

pt2 = A.A( 10 );



pts = {pt1, pt2};



numpts = length(pts,5); // getting null
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1456611_5()
        {
            string code = @"
// function test pass an item in hte array as argument , no return type specified

class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}

def length(pts : A[],num:int )

{



    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }



    return = num;

}

pt1 = A.A( 0 );

pt2 = A.A( 10 );

pts = {pt1, pt2};

a={1,2,3};

numpts = length(pts,a[0]);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1456611_6()
        {
            string code = @"
// function test pass an item in the array as argument , no return type specified

class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}

def length(pts : A[],num:int )

{



    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }



    return = null;

}

pt1 = A.A( 0 );

pt2 = A.A( 10 );

pts = {pt1, pt2};

a={1,2,3};

numpts = length(pts,a[0]);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1456611_7()
        {
            string code = @"
// no return type specified ad no return statement 

class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}

def length(pts : A[],num:int )

{



    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }



//    return = null;

}

pt1 = A.A( 0 );

pt2 = A.A( 10 );

pts = {pt1, pt2};

a={1,2,3};

numpts = length(pts,a[0]);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1456611_8()
        {
            string code = @"
// function test pass an item in the array as argument , no return type specified

class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}

def length :A[](pts : A[])

{

   

    return = pts;

}

def nested(pts:A[] )

{

    pt1 = A.A( 5 );

    pts2={pts,pt1};

    return =length(pts2);

}

gpt1 = A.A( 0 );

gpt2 = A.A( 10 );

gpts = {gpt1, gpt2};



a={1,2,3};

numpts = nested(gpts);

t1 = numpts[0][0].X;

t2 = numpts[0][1].X;

t3 = numpts[1][0].X;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1456611_9()
        {
            string code = @"
// test rank of return type 

class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}

def length :A[](pts : A[])

{

   

    return = pts;

}

def nested:A[][](pts:A[] )//return type 2 dimensional

{

    pt1 = A.A( 5 );

    pt2 = A.A( 5 );

  //  pts2={pts,{pt1,pt2}};

    return =length(pts); // returned array 1 dimensional

}

gpt1 = A.A( 0 );

gpt2 = A.A( 10 );

gpts = {gpt1, gpt2};



a={1,2,3};

res = nested(gpts);

numpts=res[0][0].X;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1456713()
        {
            string code = @"
a = 2.3;

b = a * 3;

c = 2.32;

d = c * 3;

e1=0.31;

f=3*e1;

g=1.1;

h=g*a;

i=0.99999;

j=2*i;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1456758()
        {
            string code = @"
a = true && true ? -1 : 1;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1456895()
        {
            string code = @"
class collection

{

                

                public a : int[];

                

                constructor create( b : int)

                {

                                a = { b , b};

                }

                

                def ret_col ( )

                {

                                return = a;

                }

}



[Associative]

{

                c1 = collection.create( 3 );

                d = c1.ret_col();

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1456895_2()
        {
            string code = @"
class collection{

                                

	public a : var[]..[];                                

	constructor create( b : int[]..[])                

	{

		a = b;                

	}                                

	def ret_col ( )                

	{

		return = a[0];                

	}



}



[Associative]

{                

    c = { 3, 3 };

	c1 = collection.create( c );                

	d = c1.ret_col();

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1456895_3()
        {
            string code = @"
class A

{

	Pts : var[];

	constructor A ( pts : double[] )

	{

	    Pts = pts;

	}

	def length ()

	{

		numPts = [Imperative]

		{

			counter = 0;

			for(pt in Pts)

			{

				counter = counter + 1;

			}

			

			return = counter;

		}

		return = numPts;

	}

}

    

arr = {0.0,1.0,2.0,3.0};

a1 = A.A(arr);

num = a1.length(); // expected 4, recieved 1
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1457023()
        {
            string code = @"
class Utils

{

    public def length : int (pts : double[])

    {

        numPts = [Imperative]

        {

            counter = 0;

            for(pt in pts)

            {

                counter = counter + 1;

            }

            

            return = counter;

        }

        return = numPts;

    }

    

    constructor Create()

    {}

}



utils = Utils.Create();



arr = {0.0,1.0,2.0,3.0};

num = utils.length(arr);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1457023_1()
        {
            string code = @"
class Utils

{

    C : double[];

	

	public def length : int ()

    {

        counter = 0;

		

		[Imperative]

        {          

            for(pt in C)

            {

                counter = counter + 1;

            }           

        }

        return = counter;

    }

    

    constructor Create(a : double[])

    {

		C = a;

	}

}



arr = { 0.0, 1.0, 2.0, 3.0 };

utils = Utils.Create(arr);

num = utils.length();

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1457023_2()
        {
            string code = @"
class A

{

    b : double[];

	

	constructor A (x : double[])

	{

		b = x;

	}

	

	def add_2:double[]( )

	{

		j = 0;

		x = [Imperative]

		{

			for ( i in b )

			{

				b[j] = b[j] + 1;

				j = j + 1 ;

			}

			return = b;

		}

		

		return = x;

	}

}





c = { 1.0, 2, 3 };

a1 = A.A( c );

b2 = a1.add_2( );
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1457023_3()
        {
            string code = @"
import ( ""testImport.ds"" );

class Vector

{

    //external (""libmath"") def dc_sqrt : double (val : double);

    public Length : var;

    

    private def init : bool ()

    {

        Length = null;

        return = true;        

    }

    

    X : var;

    Y : var;

    Z : var;

    

    public constructor ByCoordinates(x : double, y : double, z : double)

    {

        neglect = init();

        

        X = x;

        Y = y;

        Z = z;

    }

    

    public def GetLength ()

    {

        return = [Imperative]

        {

            if( Length == null )

            {

                Length = dc_sqrt(X*X + Y*Y + Z*Z);

            }

            return = Length;

        }

    }

    

}



vec =  Vector.ByCoordinates(3.0,4.0,0.0);

vec_len = vec.GetLength();

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1457023_4()
        {
            string code = @"
class A

{

	a : var[]..[];

	

	constructor create(i:int)

	{

		[Imperative]

		{

			if( i == 1 )

			{

				a = { { 1,2,3 } , { 4,5,6 } };

			}

			else

			{

			    a = { { 1,2,3 } , { 1,2,3 } };

			}

		}

	

	}

	

}



A1 = A.create(1);

a1 = A1.a[0][0];

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1457179()
        {
            string code = @"
import (""TestImport.ds"");

//external (""libmath"") def dc_sin : double (val : double);

def Sin : double (val : double)

{

    return = dc_sin(val);

}



result1 = Sin(90);

result2 = Sin(90.0);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1457862()
        {
            string code = @"
class point

{

		x : var;

		

		constructor point1(a : int[])

		{

			x = a;

		}

		

		def foo(a : int)

		{

			return = a;

		}

}



def foo1(a : int)

		{

			return = a;

		}

def foo2(a : int[])

		{

			return = a[2];

		}

[Imperative]

{



	//x1 = 1..4;

	x1 = { 1, 2, 3, 4 };

	a = point.point1(x1);

	a1 = a.x;

	a2 = a.foo(x1);	

	a3 = foo1(x1[0]);

	a4 = foo2(x1);



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1457885()
        {
            string code = @"
c = 5..7..#1;

a = 0.2..0.3..~0.2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1457903()
        {
            string code = @"
a = 1..7..#2.5;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458187()
        {
            string code = @"
//b=true;

  //              x = (b == 0) ? b : b+1;



def foo1 ( b  )

{

                x = (b == 0) ? b : b+1;

                return = x;



}



a=foo1(5.0);

b=foo1(5);

c=foo1(0);











";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458187_2()
        {
            string code = @"
def foo1 ( b )

{

x = (b == 0) ? b : b+1;

return = x;



}



a=foo1(true); 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458187_3()
        {
            string code = @"
def foo1 ( b )

{

x = (b == 0) ? b : b+1;

return = x;



}



a=foo1(null); 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458475()
        {
            string code = @"
a = { 1,2 };

b1 = a[-1];//b1=2
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458475_2()
        {
            string code = @"
a = { {1,2},{3,4,5}};

b1 = a[0][-1];// b1=2
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458561()
        {
            string code = @"
class A

{ 

	x1 : int[] = {10,20};

	constructor A () 

	{	

		

	}

}



a = A.A();

t1 = a.x1;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458567()
        {
            string code = @"
a = 1;

b = a[1];

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458785()
        {
            string code = @"
class A

{

    x : var;

	constructor A ()

	{

	    x = 1;

	}

	

	def foo ( i )

	{

		return = i;

	}

}

	

a1 = A.A();

a2 = a1.foo();

a3 = 2;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458785_2()
        {
            string code = @"
def foo ( i:int[])

{

return = i;

}



x =  1;

a1 = foo(x);

a2 = 3;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458785_3()
        {
            string code = @"
class A

{

    x : int;

	constructor A (i)

	{

	    x = i;

		y = 2;

	}	

}	

a1 = A.A(1);

x1 = a1.x;

y1 = a1.y;

z1 = 2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458785_4()
        {
            string code = @"
class A

{

    private x:int;



    constructor A()

    {

        x = 3;

    }

    def testPublic() 

    {

        x=x+2; // x= 5 

        return= x;

    }

     private def testprivate()

    {

        x=x-1;  

        return =x;

    }

    def testmethod() // to test calling private methods

    {

        a=testprivate();

        return=a;

    }

    

}

test1=A.A();

test2=z.x;// private member must not be exposed 

test3=test1.testPublic();

test4=test1.testprivate();// private method must not be exposed 

test5= test1.testmethod(); 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458915()
        {
            string code = @"
class A

{ 

	x : var = 0 ;	

	

	constructor A ()

	{

		 x = 1;     	

	}

	def foo ()

	{

	    return = x + 1;

	}	

}



class C extends A

{ 

	y : var ;	

	

	constructor C () : base.A()

	{

		 y = foo();

         	 

	}

	

}





c = C.C();

c1 = c.x;

c2 = c.y;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458915_2()
        {
            string code = @"
class CA

{

    x:int = 1;



    constructor CA()

    {

    }

}



class CB extends CA

{

    y:int = 2;



    constructor CB()

    {

    }

}



b = CB.CB();

t = b.x; // expected 1 here
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458915_3()
        {
            string code = @"


class A

{ 

	x : int = 5 ;

	

}

class B extends A

    {

    y : int = 5 ;

	

}

a1 = A.A();

x1 = a1.x;

b1 = B.B();

y1 = b1.x;

y2 = b1.y;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458916()
        {
            string code = @"
class A

{ 

	x : int = 5 ;

	

}



a1 = A.A();

x1 = a1.x;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458918_1()
        {
            string code = @"
class A

{ 

	public x : var ;	

	private y : var ;

	//protected z : var = 0 ;

	constructor A ()

	{

		   	

	}

	public def foo1 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	} 

	private def foo2 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	}	

}



a = A.A();

a1 = a.foo1(1);

a2 = a.foo2(1);

a.x = 4;

a.y = 5;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1458918_2()
        {
            string code = @"
class A

{

    private x:int;



    constructor A()

    {

        x = 3;

    }

    def testPublic() 

    {

        x=x+2; // x= 5 

        return= x;

    }

     private def testprivate()

    {

        x=x-1;  

        return =x;

    }

    def testmethod() // to test calling private methods

    {

        a=testprivate();

        return=a;

    }

    

}

test1=A.A();

//test2=test1.x;// private member must not be exposed 

test3=test1.testPublic();

//test4=test1.testprivate();// private method must not be exposed 

test5= test1.testmethod();



class B extends A

{

    

    constructor B()

    {

        x = 4;

     

    }

    def foo()

    {

        x=1;

       return = x;

    }

}

a=B.B();// x is private so would not be assigned any v

b=a.x;// private member must not be exposed 

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459171_1()
        {
            string code = @"
class Point

{

    X : double;

	Y : double;

	constructor ByCoordinates( x : double, y: double )

	{

	    X = x;

		Y = y;

			

	}

	

	def create( )	{

	    

		return = Point.ByCoordinates( X, Y );

		

	}	

}





p1 = Point.ByCoordinates( 5.0, 10.0);

t1 = p1.X;

t2 = p1.Y;



a1 = p1.create();

a2 = a1.X;

a3 = a1.Y;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459171_2()
        {
            string code = @"
[Imperative]

{



	def even : int (a : int) 

	{	

		if(( a % 2 ) > 0 )

			return = a + 1;

		

		else 

			return = a;

	}



	x = 1..3..1;

	y = 1..9..2;

	z = 11..19..2;



	c = even(x);

	d = even(x)..even(c)..(even(0)+0.5);

	e1 = even(y)..even(z)..1;

	f = even(e1[0])..even(e1[1]); 

	g = even(y)..even(z)..f[0][1]; 



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459175()
        {
            string code = @"
class Point

{

    X : double;

	Y : double;

	

	constructor ByCoordinates( x : double, y: double )

	{

	    X = x;

	    Y = y;

			

	}

	

}





p1 = Point.ByCoordinates( 5.0, 10.0);



a1 = p1.create(4.0,5.0);

a2 = a1.X; // expected null here!!

a3 = a1.Y; // expected null here!!

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459175_2()
        {
            string code = @"
class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}



def length : A (pts : A[])

{



    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }

    return = pts;

}





pt1 = A.A( 1 );

pt2 = A.A( 10 );



pts = {pt1, pt2};



numpts = length(pts);

test =numpts[0].X;

test2 =numpts[1].X;

	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459372()
        {
            string code = @"
collection = { 2, 2, 2 };

collection[1] = 3;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459512()
        {
            string code = @"
def length : int (pts : int[])

{

    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }

    return = numPts;

}

z=length({1,2});
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459584()
        {
            string code = @"
class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}



def length : A[] (pts : A[])

{



    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }

    return = pts;

}





pt1 = A.A( 0 );

pt2 = A.A( 10 );



pts = {pt1, pt2};



numpts = length(pts);

test=numpts[0].X;

test2= numpts[1].X;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459584_1()
        {
            string code = @"
//return type class and return an array of class-

class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}



def length : A[] (pts : A[])

{



    c1 = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }

    return = pts;

}





pt1 = A.A( 0 );

pt2 = A.A( 10 );



c1 = 0;

pts = {pt1, pt2};



numpts = length(pts); 

a=numpts[0].X;

b=numpts[1].X;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459584_2()
        {
            string code = @"
//return type class and return an array of class-

class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}



def length : A[] (pts : A[])

{



    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }

    return = pts[0];

}





pt1 = A.A( 0 );

pt2 = A.A( 10 );



pts = {pt1, pt2};



numpts = length(pts); 

a=numpts[0].X;

b=numpts[1].X;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459584_3()
        {
            string code = @"
//return type class and return a double

class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}



def length : A (pts : A[])

{



    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }

    return = 1.0;

}





pt1 = A.A( 0 );

pt2 = A.A( 10 );



pts = {pt1, pt2};



numpts = length(pts); 

a=numpts[0].X;

b=numpts[1].X;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459584_4()
        {
            string code = @"
//return type int and return a double

class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}



def length : int (pts : A[])

{



    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }

    return = 1.0;

}





pt1 = A.A( 0 );

pt2 = A.A( 10 );



pts = {pt1, pt2};



numpts = length(pts);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459584_5()
        {
            string code = @"
//return type int and return a double

class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}



def length : double (pts : A[])

{



    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }

    return = 1;

}





pt1 = A.A( 0 );

pt2 = A.A( 10 );



pts = {pt1, pt2};



numpts = length(pts); 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459584_6()
        {
            string code = @"
//no return type defined

class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}



def length  (pts : A[])

{



    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }

    return = pts;

}





pt1 = A.A( 0 );

pt2 = A.A( 10 );



pts = {pt1, pt2};



numpts = length(pts); 

test=numpts[0].X;

test2=numpts[1].X;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459584_7()
        {
            string code = @"
//no return type defined and return null

class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}



def length  (pts : A[])

{



    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }

    return = null;

}





pt1 = A.A( 0 );

pt2 = A.A( 10 );



pts = {pt1, pt2};



numpts = length(pts); 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459584_8()
        {
            string code = @"
//no return statement

class A

{

    X : int;

    

    

    constructor A(x : int)

    {

        X = x;        

    }

}



def length  (pts : A[])

{



    numPts = [Imperative]

    {

        counter = 0;

        for(pt in pts)

        {

            counter = counter + 1;

        }        

        return = counter;

    }

   // return = null;

}





pt1 = A.A( 0 );

pt2 = A.A( 10 );



pts = {pt1, pt2};



numpts = length(pts); 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459630()
        {
            string code = @"
def atan ( a : double ) = 0.5 * a;



class A

{



	theta  = atan(5.0) ;

        //theta : double = atan(5.0) ; => this works fine



	

}



a1 = A.A();
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459762()
        {
            string code = @"
class A 

{

    a : var;

	constructor A ( )

	{

	    a = 5;

	}

}



r1 = A.A();

r2 = r1+1;



// expected : r2 = null

// recieved : r2 = ptr: 1
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459900()
        {
            string code = @"
a:int = 1.3;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1459900_1()
        {
            string code = @"
def atan ( a : double ) = 0.5 * a;



class A

{



	theta:bool  = atan(5.0) ;

        //theta : double = atan(5.0) ; => this works fine



	

}



a1 = A.A();
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1462308()
        {
            string code = @"
import(TestData from ""ProtoTest.dll"");



f = TestData.IncrementByte(101); 

F = TestData.ToUpper(f);



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1467091()
        {
            string code = @"
def foo(x:int)

{

    return =  x + 1;

}



y1 = test.foo(2);

y2 = ding().foo(3);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1467094_1()
        {
            string code = @"
t = {};

x = t[3];

t[2] = 1;

y = t[3];

z = t[-1];

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1467094_2()
        {
            string code = @"
class A  

{

    x : var;

    constructor A ( y : var )

    {

        x = y;

    }

}

c = { A.A(0), A.A(1) };

p = {};

d = [Imperative]

{

    if(c[0].x == 0 )

    {

        c[0] = 0;

    p[0] = 0;

    }

    if(c[0].x == 0 )

    {

        p[1] = 1;

    }

    return = 0;

}

t1 = c[0];

t2 = c[1].x;

t3=p[0];

t4=p[1];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1467104()
        {
            string code = @"
class Point

{

    x : var;

    

    

    constructor Create(xx : double)

    {

        x = xx;

        

    }

}



pts = Point.Create( { 1, 2} );



aa = pts[null].x;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1467107()
        {
            string code = @"
def foo(x:int)

{

    return =  x + 1;

}



m=null;

y = m.foo(2);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1467117()
        {
            string code = @"
/*

/*

*/



a = 1;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQRegress_1467127()
        {
            string code = @"
i = 1..6..#10;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQSquareRoot()
        {
            string code = @"
[Imperative]

{

    def abs : double( val : double )

    {

        if( val < 0 )

        {

            return = -1 * val;

        }

        return = val;

    }

    

    //    this is famous as the first ever algo to evaluate

    //    square-root - also known as Babylonian algo

    //    developed by Heron and coded by Sarang :)

    //    

    def sqrt_heron : double ( val : double )

    {

        counter = 0;

        temp_cur = val / 2.0;

        temp_pre = temp_cur - 1.0;

        abs_diff = abs(temp_cur - temp_pre);

        tolerance = 0.00001;

        max_iterations = 100;

        

        while( abs_diff > tolerance && counter < max_iterations )

        {

            temp_pre = temp_cur;

            temp_cur = 0.5 * (temp_cur + val / temp_cur );

            

            abs_diff = abs(temp_cur - temp_pre);

            counter = counter + 1;

        }

        

        return = temp_cur;

    }

    

    def sqrt : double ( val : double )

    {

        return = sqrt_heron( val);

    }

    

    sqrt_10 = sqrt(10.0);

    sqrt_20 = sqrt(20.0);

 

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00001_Language_001_Variable_Expression_1()
        {
            string code = @"
A = 10;   	   	// assignment of single literal value

B = 2*A;   	   	// expression involving previously defined variables

A = A + 1; 	   	// expressions modifying an existing variable;

A = 15;		   	// redefine A, removing modifier

A = {1,2,3,4}; 		// redefine A as a collection

A = 1..10..2;  		// redefine A as a range expression (start..end..inc)

A = 1..10..~4; 		// redefine A as a range expression (start..end..approx_inc)

A = 1..10..#4; 		// redefine A as a range expression (start..end..no_of_incs)

A = A + 1; 		// modifying A as a range expression

A = 1..10..2;  		// redefine A as a range expression (start..end..inc)

B[1] = B[1] + 0.5; 	// modify a member of a collection [problem here]





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00002_Language_001a_array_test_4()
        {
            string code = @"
a=1;

b=2;

c=4;

collection = {a,b,c};

collection[1] = collection[1] + 0.5;

d = collection[1];

d = d + 0.1; // updates the result of accessing the collection

b = b + 0.1; // updates the source member of the collection



t1 = collection[0];

t2 = collection[1];

t3 = collection[2];



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00003_Language_001b_replication_expressions()
        {
            string code = @"
a = {1,0,-1};

b = {0, 5, 10};

zipped_sum = a + b; // {1, 5, 9}

cartesian_sum  = a<1> + b<2>;

// cartesian_sum =    {{1, 6, 11},

//        			   {0, 5, 10},

//        			   {-1, 4, 9}}

cartesian_sum  = a<2> + b<1>;



t1 = zipped_sum[0];

t2 = zipped_sum[1];

t3 = zipped_sum[2];



t4 = cartesian_sum[0][0];

t5 = cartesian_sum[1][0];

t6 = cartesian_sum[2][0];

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00004_Geometry_002_line_by_points_replication_simple()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");

//#include ""GeometryLibForLanguageTesting.ds""



startPt = Point.ByCartesianCoordinates( 1, 1, 0 );

endPt   = Point.ByCartesianCoordinates( 1, 5, 0 );

line_0  = Line.ByStartPointEndPoint( startPt, endPt ); 	// create line_0

line_0_StartPoint_X = line_0.StartPoint.X;



startPt = Point.ByCartesianCoordinates( (1..5..1), 1, 0 ); // with range expression

endPt   = Point.ByCartesianCoordinates( (1..5..1), 5, 0 ); // with range expression.. but line does not replicate



line_0  = Line.ByStartPointEndPoint( startPt<1>, endPt<2> ); 	// add replication guides <1> <2>

line_0  = Line.ByStartPointEndPoint( startPt, endPt ); 		// remove replication guides





t1 = line_0[0].StartPoint.X;

t2 = line_0[1].StartPoint.X;

t3 = line_0[2].StartPoint.X;

t4 = line_0[3].StartPoint.X;

t5 = line_0[4].StartPoint.X;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00005_Geometry_002_line_by_points_replication_simple_correction()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");

//#include ""GeometryLibForLanguageTesting.ds""



startPt = Point.ByCartesianCoordinates( 1, 1, 0 );

endPt   = Point.ByCartesianCoordinates( 1, 5, 0 );

line_0  = Line.ByStartPointEndPoint(startPt, endPt); 	// create line_0

line_0_StartPoint_X = line_0.StartPoint.X;





startPt = Point.ByCartesianCoordinates( (1..5..1), 1, 0 ); // with range expression

endPt   = Point.ByCartesianCoordinates( (1..5..1), 5, 0 ); // with range expression



line_0  = Line.ByStartPointEndPoint(startPt, endPt); 		// no replication guides

line_0  = Line.ByStartPointEndPoint(startPt<1>, endPt<1>); 	// add replication guides <1> <1>

line_0  = Line.ByStartPointEndPoint(startPt<1>, endPt<2>); 	// add replication guides <1> <2>

line_0  = Line.ByStartPointEndPoint(startPt<1>, endPt<1>); 	// add replication guides <1> <1>

line_0  = Line.ByStartPointEndPoint(startPt, endPt); 		// remove replication guides



t1 = line_0[0].StartPoint.X;

t2 = line_0[1].StartPoint.X;

t3 = line_0[2].StartPoint.X;

t4 = line_0[3].StartPoint.X;

t5 = line_0[4].StartPoint.X;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00006_Geometry_003_line_by_points_replication_array()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");

//#include ""GeometryLibForLanguageTesting.ds""



startPt = Point.ByCartesianCoordinates( 1, 1, 0 );

endPt   = Point.ByCartesianCoordinates( 1, 5, 5 );

line_0  = Line.ByStartPointEndPoint(startPt, endPt ); 	// create line_0

line_0_StartPoint_X = line_0.StartPoint.X;



startPt = Point.ByCartesianCoordinates( (1..5..1), 1, 0 ); // replicate in X

startPt = Point.ByCartesianCoordinates( (1..5..1), (1..5..1), 0 ); // replicate in X and Y

startPt = Point.ByCartesianCoordinates( (1..5..1)<1>, (1..5..1)<2>, 0 ); // replicate in X and Y with replication guides



line_0  = Line.ByStartPointEndPoint(startPt[2], endPt); // create line_0, select from startPt

startPt = Point.ByCartesianCoordinates( (1..5..1)<2>, (1..5..1)<1>, 0 ); // replicate in X and Y with replication guides



line_0  = Line.ByStartPointEndPoint(startPt, endPt); // create line_0, select from startPt



startPt = Point.ByCartesianCoordinates( (1..5..1), (1..5..1), 0 ); // replicate in X and Y with replication guides

startPt = Point.ByCartesianCoordinates( (1..5..1)<1>, (1..5..1)<1>, 0 ); // replicate in X and Y with replication guides

startPt = Point.ByCartesianCoordinates( (1..5..1)<1>, (1..5..1)<2>, 0 ); // replicate in X and Y with replication guides

startPt = Point.ByCartesianCoordinates( (1..8..1)<1>, (1..8..1)<2>, 0 ); // replicate in X and Y with replication guides

startPt = Point.ByCartesianCoordinates( (1..8..2)<1>, (1..8..2)<2>, 0 ); // replicate in X and Y with replication guides

startPt = Point.ByCartesianCoordinates( (1..5..1)<1>, (1..5..1)<2>, 0 ); // replicate in X and Y with replication guides



startPt = Point.ByCartesianCoordinates( 2, 1, 0 );







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00007_Geometry_004_circle_all_combinations()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");

import(""math.dll"");

//#include ""GeometryLibForLanguageTesting.ds""



//circlePoint = Point.ByCartesianCoordinates(10.0*cos(0..(360)..#21), 10.0*sin(0..(360)..#21), 0.0);

circlePoint = Point.ByCartesianCoordinates( 10.0 * Math.Cos(0..(360)..#4), 10.0 * Math.Sin(0..(360)..#4), 0.0);

lines = Line.ByStartPointEndPoint(circlePoint<1>,circlePoint<2>);

lines_StartPoint_X = lines.StartPoint.X; 



t1 = lines[0][0].StartPoint.X;

t2 = lines[1][0].StartPoint.X;

t3 = lines[2][0].StartPoint.X;

t4 = lines[3][0].StartPoint.X;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00008_Geometry_005_circle_adjacent_pairs_externalised()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");

//#include ""GeometryLibForLanguageTesting.ds""

import(""math.dll"");



//numPoints = 21;

numPoints = 5;

circlePoint = Point.ByCartesianCoordinates( 10.0*Math.Cos(0..(360)..#numPoints), 10.0*Math.Sin(0..(360)..#numPoints), 0.0 );

lines = Line.ByStartPointEndPoint( circlePoint[-1..(count(circlePoint)-2)..1], circlePoint[0..(count(circlePoint)-1)..1] ); 

lines_StartPoint_X = lines.StartPoint.X; 

//numPoints = 11;

numPoints = 3;



t1 = lines[0].StartPoint.X;

t2 = lines[1].StartPoint.X;

t3 = lines[2].StartPoint.X;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00009_Geometry_006_circle_all_unique_combinations()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");



def drawUniqueLines (points : Point[], start : int, end : int) = Line.ByStartPointEndPoint(points[(0..start..1)],points[end]); 



circlePoints = Point.ByCartesianCoordinates( 10..13, 4..7, 0.0 );

lines = drawUniqueLines(circlePoints, (1..(Count(circlePoints)-2)..1), (2..(Count(circlePoints)-1)..1));

lines_StartPoint_X = lines.StartPoint.X; 

t1 = lines[0][0].StartPoint.X;

t2 = lines[1][2].StartPoint.X;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00010_Geometry_007_specialPoint_2()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");

//#include ""GeometryLibForLanguageTesting.ds""

import(""math.dll"");





class MyPoint 

{

	// define general system of dependencies

	

	x : double = radius * Math.Cos(theta*180/180); // x dependent on theta and radius

	y : double = radius * Math.Sin(theta*180/180); // y dependent on theta and radius

	z : double = 0.0;

											

	theta  = Math.atan(y/x) * 180 / 180;		 	 // theta  dependent on x and y

	radius = Math.sqrt(x*x + y*y);				 // radius dependent on x and y

	

	inner  : Point = Point.ByCartesianCoordinates( x, y, z );	 // create inner point dependent on x and y

	

	public constructor ByXYcoordinates(xValue : double , yValue : double)

	{

		x = xValue; 			// assigning argument values to specific properties

		y = yValue; 			// overrides defaut graph and triggers remianing depenencies

									// we don't need to add in the statemenst to recompute theta and radius

									// this will happen 'automatically', because of the dependencies

									// defined in the body of the class

	}

		

	public constructor ByAngleRadius(thetaValue : double , radiusValue : double)

	{

		theta  = thetaValue;	// assigning argument values to specific properties

		radius = radiusValue; 	// overrides defaut graph and triggers remaining depenencies								// we don't need to add in the statemenst to recompute theta and radius

									// we don't need to add in the statemenst to recompute x and y

									// this will happen 'automatically', because of the dependencies

									// defined in the body of the class

	}

	

	// add 'incremental' modifiers

	

	def incrementX(this : MyPoint, xValue : double) = ByXYcoordinates(this.x + xValue, this.y);

	def incrementY(this : MyPoint, yValue : double) = ByXYcoordinates(this.x,this.y + yValue);

	def incrementTheta(this : MyPoint, thetaValue : double)  = ByAngleRadius(this.theta + thetaValue, this.radius );

	def incrementRadius(this : MyPoint, radiusValue : double)= ByAngleRadius(this.theta, this.radius + radiusValue );

}



a 		= MyPoint.ByXYcoordinates( 1.0, 1.0 );		// create an instance 'a' using one constructor

origin         = Point.ByCartesianCoordinates( 0, 0, 0 );  		// create a reference point

testLine       = Line.ByStartPointEndPoint(origin, a.inner);	// create a testLine (to see some results)

testLine_SP_X = testLine.StartPoint.X; 

aX 		= a.x;							// report the properties of 'a'

aY 		= a.y;

aTheta 	= a.theta;

aRadius        = a.radius;



a 		= MyPoint.ByAngleRadius(60.0, 1.0);			// switch to a different constructor [POINT updates]



//a		= a.visible(false); 

a 		= a.incrementX(0.2);					// apply different modifiers [POINT does not updates]

//a		= a.visible(false);

a 		= a.incrementY(-0.2);					// apply different modifiers [POINT does not updates]



a 		= MyPoint.ByAngleRadius(45.0, 0.75);			// redefine a (by using a constructor) [POINT updates]



//a		= a.visible(false);

a 		= a.incrementTheta(10.0);				// apply different modifiers [POINT does not updates]

//a		= a.visible(false);

a 		= a.incrementRadius(0.2); 				// [POINT does not updates]



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00011_Geometry_008_trim_then_tube_4()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");

//#include ""GeometryLibForLanguageTesting.ds""



myPoint = Point.ByCartesianCoordinates( (2..10..2)<1>, (2..10..2)<2>, 2 ); // create 2D point array

controlPoint_1 = Point.ByCartesianCoordinates( 5, 5, 5 ); 		// create control point

controlPoint_2 = Point.ByCartesianCoordinates( 5, 10, 5 ); 	// create control point

myLine = Line.ByStartPointEndPoint( myPoint[1], controlPoint_1 ); 	// select 1d array of points to create a 1D array lines

//myLine[2] = myLine[2].Trim({0.9, 0.1}, false); 	// trim one member of the array of points (modify a member of a collection)

myLine[2] = myLine[2].Trim( 0.5 );

//tubes   = Tube.ByStartPointEndPointRadius(myLine.StartPoint, myLine.EndPoint, 0.25, 0.125); // use the whole array of lines for tubing

//tubes   = Solid.Cone(myLine.StartPoint, myLine.EndPoint, 0.25, 0.125); // use the whole array of lines for tubing

tubes      = Solid.Cone(myLine.StartPoint, myLine.EndPoint, 0.25, 0.125);

controlPoint_1 = Point.ByCartesianCoordinates( 7, 7, 5 ); 		// move the control point, change gets propagated to lines, trim and tubes, 

//myLine[3] = myLine[3].Trim({0.9, 0.2}, false); 		// trim another member of the array of points (modify a member of a collection)

myLine[3] = myLine[3].Trim( 0.8); 	

controlPoint_1 = Point.ByCartesianCoordinates( 8, 7, 5 ); 		// move the control point, change gets propagated to lines, trim and tubes, 

t1 = tubes[0].EndPoint.X;

t2 = tubes[1].EndPoint.X;

t3 = tubes[2].EndPoint.X;

t4 = tubes[3].EndPoint.X;

t5 = tubes[4].EndPoint.X;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00012_Geometry_008a_alternative_method_invocations_1()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");

//#include ""GeometryLibForLanguageTesting.ds""



startRadius = 0.1;

endRadius	= 0.2;

startParam  = 0.2;

endParam    = 0.8;



// [1] regular method call [separate Line constructor, modifier, then Tube constructor to new variable]

start_0 = Point.ByCartesianCoordinates( 1, 1, 0 );

end_0   = Point.ByCartesianCoordinates( 1, 5, 0 );

line_0  = Line.ByStartPointEndPoint(start_0, end_0); 	// create line_0



line_0  = line_0.Trim({endParam, startParam}, false);

tube_0  = Tube.ByStartPointEndPointRadius(line_0.StartPoint, line_0.EndPoint, startRadius, endRadius);



// [2] method chain, with embedded point arguments

x_1 = 5;

line_1  = Line.ByStartPointEndPoint(Point.ByCartesianCoordinates( x_1, 1, 0 ), Point.ByCartesianCoordinates( 5, 5, 0 )).Trim({endParam, startParam}, false); 	// create line_1 method chain

x_1 = 7;



// [3] doubly embedded methods as arguments

x_2 = 10;

line_2  = Line.Trim(Line.ByStartPointEndPoint(Point.ByCartesianCoordinates( x_2, 1, 0 ), Point.ByCartesianCoordinates( 10, 5, 0 )),{endParam, startParam}, false); 	// create line_2 embedded method call

x_2 = 12; // cause an update



// [4] define a function as a compound operation

def TrimTube(line : Line, startParam: double | startParam > 0.0, endParam: double | endParam < 1.0, startRadius : double, endRadius : double)

{

	intermediateLine = line.Trim( {endParam, startParam}, false);

	return = Solid.Cone(intermediateLine.StartPoint, intermediateLine.EndPoint, startRadius, endRadius);

}



// [5] apply compound operation to create a new result (tube) variable, given existing input (line) variable

x_3 = 15;

line_3 = Line.ByStartPointEndPoint(Point.ByCartesianCoordinates( x_3 , 1, 0 ), Point.ByCartesianCoordinates( 15, 5, 0 ));

tube_3 = TrimTube(line_3, 0.2, 0.7, 0.3, 0.15); // apply operations

x_3 = 17;



// [6] apply compound operation to modify existing input (line) variable AND effectively change its type from Line to Tube

x_4 = 20; 

line_4 = Line.ByStartPointEndPoint(Point.ByCartesianCoordinates( x_4, 1, 0 ), Point.ByCartesianCoordinates( 20, 5, 0 ));

line_4 = TrimTube(line_4, 0.2, 0.7, 0.3, 0.15); // apply operations as modifier AND effectively change the type of line_4

otherPoint = Point.ByCartesianCoordinates( x_4+5, 10, 0 );

otherLine  = Line.ByStartPointEndPoint(otherPoint,line_4.StartPoint); // even though line_4 is now a tube, 

																 // we should be able to still refer 

																 // to a property of its previous state

																 // i.e. to its start point 

x_4 = 22; 



x1 = line_0.StartPoint.X;

x2 = line_1.StartPoint.X;

x3 = line_2.StartPoint.X;

x4 = line_3.StartPoint.X;

x5 = line_4.StartPoint.X;

x6 = otherLine.StartPoint.X;

x7 = tube_0.StartPoint.X;

x8 = tube_3.StartPoint.X;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00013_Geometry_009_nested_user_defined_feature_2b()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");

//#include ""GeometryLibForLanguageTesting.ds""



start    = Point.ByCartesianCoordinates( 2, 2, 0 );

end      = Point.ByCartesianCoordinates( 7, 7, 0 );

line     = Line.ByStartPointEndPoint(start, end);

midPoint = line.PointAtParameter(0.5);



// [2] create MyLine user define feature using sub classing and 'this' instance



class MyLine 

{

    InternalLine : Line;  		// user defined feature contains a line property

    MidPoint : Point;	// and a midPoint property

    public constructor ByStartPointEndPoint(start : Point, end : Point)

    {

		InternalLine = Line.ByStartPointEndPoint(start, end);

		MidPoint = InternalLine.PointAtParameter(0.5);

    }

 }



point_a  = Point.ByCartesianCoordinates( 30, 40, 0 );

point_b  = Point.ByCartesianCoordinates( 10, 10, 0 );

point_c  = Point.ByCartesianCoordinates( 50, 10, 0 );



// [3] use MyLine to construct model for MyTriangle user defined feature



side_a_b = MyLine.ByStartPointEndPoint( point_a, point_b );

side_b_c = MyLine.ByStartPointEndPoint( point_b, point_c );

side_c_a = MyLine.ByStartPointEndPoint( point_c, point_a );



// [4] ceate MyTriangle user defined feature

class MyTriangle

{

    Side_a_b : MyLine;

    Side_b_c : MyLine;

    Side_c_a : MyLine;



    // with a constructor

    constructor ByPoints(point_a : Point, point_b : Point, point_c : Point)

	{

		Side_a_b = MyLine.ByStartPointEndPoint( point_a, point_b );

		Side_b_c = MyLine.ByStartPointEndPoint( point_b, point_c );

		Side_c_a = MyLine.ByStartPointEndPoint( point_c, point_a );

	}    

}



// [5] Create initial three defining points.

point_1 = Point.ByCartesianCoordinates( 30, 80, 0 );

point_2 = Point.ByCartesianCoordinates( 10, 50, 0 );

point_3 = Point.ByCartesianCoordinates( 50, 50, 0 );



// [6] Create outer instance of MyTriangle from defining points.

triangle0000 = MyTriangle.ByPoints(point_1, point_2, point_3);



// [7] Create inner instance of MyTriangle from midPoints of sides of the outer instance of MyTriangle.

triangle0001 = MyTriangle.ByPoints(  triangle0000.Side_a_b.MidPoint,triangle0000.Side_b_c.MidPoint,triangle0000.Side_c_a.MidPoint);



// [8] Create inner instance of MyTriangle from midPoints of sides of the outer instance of MyTriangle.

triangle0002 = MyTriangle.ByPoints(  triangle0001.Side_a_b.MidPoint,triangle0001.Side_b_c.MidPoint,triangle0001.Side_c_a.MidPoint);





// [8] change the definition of the MyLine user define feature from 'composition' to 'sub classing' 

//     from an existing class (in this case from the Line class)

//     redefining MyTriangle should update all existing instances of MyTriangle



// [9] move point_1	 								 

point_1 = Point.ByCartesianCoordinates( 50, 80, 0 ); // points do not clean up from old position



point_1 = Point.ByCartesianCoordinates( 60, 90, 0 ); // when points are single values





// [10] replicate point_1 								 			 

point_1 = Point.ByCartesianCoordinates( (20..28..2), 80, 0 ); // points do clean up when going from single value to collection



point_1 = Point.ByCartesianCoordinates( (70..78..1), 80, 0 ); // points not do clean up when going from collection of one size to collection of another size

point_1 = Point.ByCartesianCoordinates( (20..28..2), 80, 0 ); // points not do clean up when going from collection of one size to collection of another size

point_1 = Point.ByCartesianCoordinates( (50..58..2), 80, 0 ); // points do clean up when going from collection of one size to collection of the same size



// [11] move point_1	 								 								 

point_1 = Point.ByCartesianCoordinates( 10, 80, 0 ); // points do clean up when going from collection to single value 

point_1 = Point.ByCartesianCoordinates( 20, 100, 0 ); // points do not clean up from old position when going from single value to single value 





x1 = triangle0000.Side_b_c.MidPoint.X;

x2 = triangle0001.Side_b_c.MidPoint.X;

x3 = triangle0002.Side_b_c.MidPoint.X;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00014_Geometry_010_nested_user_defined_feature_rand_2()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");

//#include ""GeometryLibForLanguageTesting.ds""



// [1] create initial model from which to make the MyLine user defined feature

start    = Point.ByCartesianCoordinates( 2, 2, 0 );

end      = Point.ByCartesianCoordinates( 7, 7, 0 );

line     = Line.ByStartPointEndPoint( start, end );

midPoint = line.PointAtParameter( 0.5 );



// [2] create MyLine user define feature using sub classing

								// and 'this' instance



class MyLine 

{

    line : Line;  		// user defined feature contains a line property

    midPoint : Point;	// and a midPoint property



    public constructor ByStartPointEndPoint(start : Point, end : Point)

    {

	line     = Line.ByStartPointEndPoint( start, end );

	//midPoint = line.PointAtParameter( rand(2, 8)*0.1 );

    	midPoint = line.PointAtParameter(0.5);

    }

 }



point_a  = Point.ByCartesianCoordinates( 30, 40, 0 );

point_b  = Point.ByCartesianCoordinates( 10, 10, 0 );

point_c  = Point.ByCartesianCoordinates( 50, 10, 0 );



// [3] use MyLine to construct model for MyTriangle user defined feature



side_a_b = MyLine.ByStartPointEndPoint( point_a, point_b );

side_b_c = MyLine.ByStartPointEndPoint( point_b, point_c );

side_c_a = MyLine.ByStartPointEndPoint( point_c, point_a );



// [4] ceate MyTriangle user defined feature

class MyTriangle

{

    side_a_b : MyLine;

    side_b_c : MyLine;

    side_c_a : MyLine;



    // with a constructor

    constructor ByPoints(point_a : Point, point_b : Point, point_c : Point)

    {

        side_a_b = MyLine.ByStartPointEndPoint( point_a, point_b );

        side_b_c = MyLine.ByStartPointEndPoint( point_b, point_c );

        side_c_a = MyLine.ByStartPointEndPoint(point_c, point_a );

    } 

}



// [5] Create initial three defining points.

point_1 = Point.ByCartesianCoordinates( 30, 80, 0 );

point_2 = Point.ByCartesianCoordinates( 10, 50, 0 );

point_3 = Point.ByCartesianCoordinates( 50, 50, 0 );



// [6] Create outer instance of MyTriangle from defining points.

MyTriangle0000 = MyTriangle.ByPoints( point_1, point_2, point_3 );



// [7] Create inner instance of MyTriangle from midPoints of sides of the outer instance of MyTriangle.

MyTriangle0001 = MyTriangle.ByPoints( MyTriangle0000.side_a_b.midPoint,

                                     MyTriangle0000.side_b_c.midPoint,

                                     MyTriangle0000.side_c_a.midPoint );

									 

// [8] Create inner instance of MyTriangle from midPoints of sides of the outer instance of MyTriangle.

MyTriangle0002 = MyTriangle.ByPoints(MyTriangle0001.side_a_b.midPoint,

                                     MyTriangle0001.side_b_c.midPoint,

                                     MyTriangle0001.side_c_a.midPoint);

									 

// [8] change the definition of the MyLine user define feature from 'composition' to 'sub classing' 

//     from an existing class (in this case from the Line class)

//     redefining MyTriangle should update all existing instances of MyTriangle



// [9] replicate point_1									 

point_1 = Point.ByCartesianCoordinates( (20..28..2), 80, 0 );



x1 = MyTriangle0001[0].side_a_b.midPoint.X;

x2 = MyTriangle0001[1].side_b_c.midPoint.X;

x3 = MyTriangle0001[2].side_c_a.midPoint.X;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00015_Geometry_011_nested_user_defined_feature_with_partial_class_1()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");

//#include ""GeometryLibForLanguageTesting.ds""



// [1] create initial model from which to make the MyLine user defined feature

start    = Point.ByCartesianCoordinates( 2, 2, 0 );

end      = Point.ByCartesianCoordinates( 7, 7, 0 );

line     = Line.ByStartPointEndPoint(start, end);

midPoint = line.PointAtParameter(0.5);



// [2] create MyLine user define feature using sub classing

								// and 'this' instance



class MyLine 

{

    InternalLine : Line;  	// user defined feature contains a line property

    MidPoint     : Point;	// and a midPoint property



    public constructor ByStartPointEndPoint(start : Point, end : Point)

    {

		InternalLine = Line.ByStartPointEndPoint(start, end);

		MidPoint 	 = InternalLine.PointAtParameter(0.5);

    }

 }



point_a  = Point.ByCartesianCoordinates( 30, 40, 0 );

point_b  = Point.ByCartesianCoordinates( 10, 10, 0 );

point_c  = Point.ByCartesianCoordinates( 50, 10, 0 );



// [3] use MyLine to construct model for MyTriangle user defined feature



side_a_b = MyLine.ByStartPointEndPoint(point_a, point_b);

side_b_c = MyLine.ByStartPointEndPoint(point_b, point_c);

side_c_a = MyLine.ByStartPointEndPoint(point_c, point_a);



partial class MyLine 

{

    public constructor ByStartPointEndPoint(start : Point, end : Point, t : double | (t<1.0 && t>0.0))

    {

		InternalLine = Line.ByStartPointEndPoint(start, end);

		MidPoint     = InternalLine.PointAtParameter(t);

    }

	

    public constructor ByStartPointEndPoint(start : Point, end : Point, t : double )

    {

		InternalLine = Line.ByStartPointEndPoint(start, end);

		MidPoint     = InternalLine.PointAtParameter(0.5);

    }

}



point_r = Point.ByCartesianCoordinates( 30, 80, 0 );

point_s = Point.ByCartesianCoordinates( 10, 50, 0 );

point_t = Point.ByCartesianCoordinates( 50, 50, 0 );



myT = 1.4;

side_r_s = MyLine.ByStartPointEndPoint( point_r, point_s,  myT );

side_s_t = MyLine.ByStartPointEndPoint( point_s, point_t, -0.1 );

side_t_r = MyLine.ByStartPointEndPoint( point_t, point_r,  0.25 );

myT = 0.6;



x1 = side_a_b.MidPoint.X;

x2 = side_b_c.MidPoint.X;

x3 = side_c_a.MidPoint.X;

x4 = side_r_s.MidPoint.X;

x5 = side_s_t.MidPoint.X;

x6 = side_t_r.MidPoint.X;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00016_Geometry_012_centroid_1()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");

//#include ""GeometryLibForLanguageTesting.ds""



// [1] create functions to calculate the centroid of a collection of points 



def sumCollection(arr : double[]) = sumCollectionInternal(arr, count(arr)-1);



def sumCollectionInternal(arr : double[], i : int | i > -1) = arr[i] + sumCollectionInternal(arr, i-1);



def sumCollectionInternal(arr : double[], i : int) = 0;



def average(arr : double[]) = sumCollection(arr) / count(arr);



def centroid(points : Point[]) = Point.ByCartesianCoordinates( average(points.X), average(points.Y),  average(points.Z) );



// [2] create some points

point_1 = Point.ByCartesianCoordinates( 30.0, 80.0, 0.0 );

point_2 = Point.ByCartesianCoordinates( 10.0, 50.0, 0.0 );

point_3 = Point.ByCartesianCoordinates( 50.0, 50.0, 0.0 );



// [3] create centrePoint



centrePoint = centroid( {point_1, point_2, point_3} );



// [4] test with lines



lineTest  = Line.ByStartPointEndPoint( centrePoint, { point_1, point_2, point_3 } );



// [5] move a point

point_1 = Point.ByCartesianCoordinates( 40.0, 80.0, 0.0 );



x1 = lineTest[2].EndPoint.X;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT00017_Geometry_015_Happy_Xmas_2()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");

//#include ""GeometryLibForLanguageTesting.ds""





def arrayWidth (array : Object[][])

{

    c1 = [Imperative]

    {

        c = 0;

	for ( i in array )

	{

		c = c + 1;

	}

	return  = c;	

    }

    return = c1;

}

//def arrayWidth(arr : Object[][]) = count(count(arr));

def arrayHeight(arr : Object[][]) = count(arr[0]);

def internalSample(points : Point[][], i : int, j : int) = {points[i-1][j-1], points[i][j-1], points[i][j], points[i-1][j]};

def sampleAdjacents(points : Point[][]) = internalSample(points, (1..(arrayWidth(points)-1))<2>, (1..(arrayHeight(points)-1))<1>);



//def internalSample(points : Point[][], i : int, j : int) = {points[i-1][j-1], points[i][j-1], points[i][j], points[i-1][j]};

//def arrayWidth(arr : Object[][]) = count(count(arr));

//def arrayHeight(arr : Object[][]) = count(arr[0]);



def UVpoint(p : Point[], U : double, V : double) // assumes an arry of 4 points

{

	//x = ((p[0].x * ((1.0-U) + (1.0-V)))+ (p[1].x * (U + (1.0-V))) + (p[2].x * (U+V)) + (p[3].x * ((1.0-U) + V)))/4.0;  

	//y = ((p[0].y * ((1.0-U) + (1.0-V)))+ (p[1].y * (U + (1.0-V))) + (p[2].y * (U+V)) + (p[3].y * ((1.0-U) + V)))/4.0;  

	//z = ((p[0].z * ((1.0-U) + (1.0-V)))+ (p[1].z * (U + (1.0-V))) + (p[2].z * (U+V)) + (p[3].z * ((1.0-U) + V)))/4.0;  

	//return = Point.ByCartesianCoordinates(WCS,x, y, z);

	

	xb = ((p[0].x * (1.0-U))+ (p[1].x * U));  

	yb = ((p[0].y * (1.0-U))+ (p[1].y * U));  

	zb = ((p[0].z * (1.0-U))+ (p[1].z * U)); 

	

	xt = ((p[3].x * (1.0-U))+ (p[2].x * U));  

	yt = ((p[3].y * (1.0-U))+ (p[2].y * U));  

	zt = ((p[3].z * (1.0-U))+ (p[2].z * U));  

	

	x  = ((xb * (1.0-V))+ (xt * V));  

	y  = ((yb * (1.0-V))+ (yt * V));  

	z  = ((zb * (1.0-V))+ (zt * V));  

	return = Point.ByCartesianCoordinates( x, y, z );

}

class Tubulor 

{

    primary : Tube;  	

    secondary : Tube;	// and a midPoint property



    public constructor ByPoint(character : string, p : Point[], startRadius: double, endRadius : double, secondaryFactor: double)

    {

		secondary = { Solid.Cone(p[0], p[2], startRadius*secondaryFactor, endRadius*secondaryFactor),

		Solid.Cone(p[1], p[3], startRadius*secondaryFactor, endRadius*secondaryFactor)};

    }

	

    public constructor ByPoint(character : string | character==""A"", p : Point[], startRadius: double, endRadius : double, secondaryFactor: double)

    {

		s = UVpoint(p, {0.2, 0.5, 0.8, 0.35, 0.65}, {0.2, 0.8, 0.2, 0.5, 0.5});



		primary   = { Solid.Cone(s[0], s[1], startRadius, endRadius),

					  Solid.Cone(s[1], s[2], startRadius, endRadius)};

					  

		secondary = { Solid.Cone(p[0], s[0], startRadius*secondaryFactor, endRadius*secondaryFactor),

					  Solid.Cone(s[3], s[4], startRadius*secondaryFactor, endRadius*secondaryFactor),

 					  Solid.Cone(s[2], p[1], startRadius*secondaryFactor, endRadius*secondaryFactor),

    				  Solid.Cone(p[2], s[1], startRadius*secondaryFactor, endRadius*secondaryFactor),

 					  Solid.Cone(s[1], p[3], startRadius*secondaryFactor, endRadius*secondaryFactor)};    

    }

	

    public constructor ByPoint(character : string | character==""X"", p : Point[], startRadius: double, endRadius : double, secondaryFactor: double)

    {

		s = UVpoint(p, {0.2, 0.8, 0.2, 0.8}, {0.2, 0.8, 0.8, 0.2});



		primary   = { Solid.Cone(s[0], s[1], startRadius, endRadius),

					  Solid.Cone(s[2], s[3], startRadius, endRadius)};

					  

		secondary = { Solid.Cone(p[0], s[0], startRadius*secondaryFactor, endRadius*secondaryFactor),

					  Solid.Cone(s[3], p[1], startRadius*secondaryFactor, endRadius*secondaryFactor),

    				  Solid.Cone(p[2], s[1], startRadius*secondaryFactor, endRadius*secondaryFactor),

 					  Solid.Cone(s[2], p[3], startRadius*secondaryFactor, endRadius*secondaryFactor)};    

    }

	

    public constructor ByPoint(character : string | character==""Y"", p : Point[], startRadius: double, endRadius : double, secondaryFactor: double)

    {

		s = UVpoint(p, {0.5, 0.5, 0.2, 0.8}, {0.2, 0.5, 0.8, 0.8});



		primary   = { Solid.Cone(s[0], s[1], startRadius, endRadius),

					  Solid.Cone(s[2], s[1], startRadius, endRadius),

					  Solid.Cone(s[3], s[1], startRadius, endRadius)};

					  

		secondary = { Solid.Cone(p[0], s[0], startRadius*secondaryFactor, endRadius*secondaryFactor),

					  Solid.Cone(s[0], p[1], startRadius*secondaryFactor, endRadius*secondaryFactor),

    				  Solid.Cone(p[2], s[3], startRadius*secondaryFactor, endRadius*secondaryFactor),

 					  Solid.Cone(s[2], p[3], startRadius*secondaryFactor, endRadius*secondaryFactor)};    

    }

	

    public constructor ByPoint(character : string | character==""M"", p : Point[], startRadius: double, endRadius : double, secondaryFactor: double)

    {

		s = UVpoint(p, {0.2, 0.3, 0.5, 0.7, 0.8}, {0.2, 0.8, 0.5, 0.8, 0.2});



		primary   = { Solid.Cone(s[0], s[1], startRadius, endRadius),

					  Solid.Cone(s[1], s[2], startRadius, endRadius),

					  Solid.Cone(s[2], s[3], startRadius, endRadius),

					  Solid.Cone(s[3], s[4], startRadius, endRadius)};

					  

		secondary = { Solid.Cone(p[0], s[0], startRadius*secondaryFactor, endRadius*secondaryFactor),

					  Solid.Cone(p[1], s[4], startRadius*secondaryFactor, endRadius*secondaryFactor),

    				  Solid.Cone(p[2], s[3], startRadius*secondaryFactor, endRadius*secondaryFactor),

 					  Solid.Cone(p[3], s[1], startRadius*secondaryFactor, endRadius*secondaryFactor)};    

    }

	

    public constructor ByPoint(character : string | character==""H"", p : Point[], startRadius: double, endRadius : double, secondaryFactor: double)

    {

		s = UVpoint(p, {0.3, 0.3, 0.3, 0.7, 0.7, 0.7}, {0.2, 0.8, 0.5, 0.5, 0.8, 0.2});



		primary   = { Solid.Cone(s[0], s[1], startRadius, endRadius),

					  Solid.Cone(s[4], s[5], startRadius, endRadius)};

					  

		secondary = { Solid.Cone(p[0], s[0], startRadius*secondaryFactor, endRadius*secondaryFactor),

					  Solid.Cone(p[1], s[5], startRadius*secondaryFactor, endRadius*secondaryFactor),

    				  Solid.Cone(s[2], s[3], startRadius*secondaryFactor, endRadius*secondaryFactor),

					  Solid.Cone(p[2], s[4], startRadius*secondaryFactor, endRadius*secondaryFactor),

 					  Solid.Cone(p[3], s[1], startRadius*secondaryFactor, endRadius*secondaryFactor)};    

    }

	

    public constructor ByPoint(character : string | character==""P"", p : Point[], startRadius: double, endRadius : double, secondaryFactor: double)

    {

		s = UVpoint(p, {0.3, 0.3, 0.5, 0.65, 0.7, 0.7, 0.65, 0.5, 0.3}, {0.2, 0.8, 0.8, 0.75, 0.7, 0.6, 0.55, 0.5, 0.5});



		primary   = { Solid.Cone(s[0..(count(s)-2)], s[1..(count(s)-1)], startRadius, endRadius)};

					  

		secondary = { Solid.Cone(p[0], s[0], startRadius*secondaryFactor, endRadius*secondaryFactor),

					  Solid.Cone(p[1], s[6], startRadius*secondaryFactor, endRadius*secondaryFactor),

    				  Solid.Cone(s[2], s[3], startRadius, endRadius),

					  Solid.Cone(p[2], s[3], startRadius*secondaryFactor, endRadius*secondaryFactor),

 					  Solid.Cone(p[3], s[1], startRadius*secondaryFactor, endRadius*secondaryFactor)};    

    }

	

    public constructor ByPoint(character : string | character==""S"", p : Point[], startRadius: double, endRadius : double, secondaryFactor: double)

    {

		s = UVpoint(p, {0.3, 0.5, 0.65, 0.7, 0.7, 0.65, 0.5, 0.35, 0.3, 0.3, 0.35, 0.5, 0.65}, 

					   {0.225, 0.2, 0.25, 0.3, 0.4, 0.45, 0.5, 0.55, 0.6, 0.7, 0.75, 0.8, 0.775});

		primary   = { Solid.Cone(s[0..(count(s)-2)], s[1..(count(s)-1)], startRadius, endRadius)};

					  

		secondary = { Solid.Cone(p[0], s[0], startRadius*secondaryFactor, endRadius*secondaryFactor),

					  Solid.Cone(p[1], s[3], startRadius*secondaryFactor, endRadius*secondaryFactor),

    				  Solid.Cone(s[0], s[12], startRadius*secondaryFactor, endRadius*secondaryFactor),

					  Solid.Cone(p[2], s[12], startRadius*secondaryFactor, endRadius*secondaryFactor),

 					  Solid.Cone(p[3], s[9], startRadius*secondaryFactor, endRadius*secondaryFactor)};    

    }

 }



xSize 			  =  7.0; 

ySize 			  =  4.0; 	

upVector 		  = Vector.ByCoordinates(0.0, 0.0, 1.0); // need up vector

groundPoints             = Point.ByCartesianCoordinates((0.0..xSize..1.0)<1>, (0.0..ySize..1.0)<2>, 0.0); 



xFocus 			  = 0.25;  // proportion within the array of points where the focal point will be located

yFocus 			  = 0.25;

heightControl 	  = 2.0;   // proportion that the roof point move up near the focus point

lateralControl	  = 0.5;   // proportion that the roof point move laterally away from the focus point

panelHeightFactor = 0.25;  // aspect ratio of the pyramid (hight as a function of base dimensions)

focalPoint        = Point.ByCartesianCoordinates( xSize * xFocus, ySize * yFocus, 0.0); 

// testLine		  = Line.ByStartPointEndPoint(groundPoints, focalPoint);

xFocus 			  = 0.5;   // proportion within the array of points where the focal point will be located

roofHeights 	  = focalPoint.DistanceTo(groundPoints);

horizontalVector  = focalPoint.DirectionTo(groundPoints<1><2>);

lateralPoints     = Point.Project(groundPoints<1><2>, horizontalVector<1><2>, lateralControl);

//testLine		  = Line.ByStartPointEndPoint(groundPoints, lateralPoints);

roofPoints 		  = Point.Project(lateralPoints<1><2>, upVector, heightControl/(roofHeights<1><2>+1));



text = {{"" "","" "","" "","" "","" "","" "","" ""},

        {"" "",""X"",""M"",""A"",""S"","" "","" ""},

		{"" "",""H"",""A"",""P"",""P"",""Y"","" ""},

		{"" "",""A"",""R"",""U"",""P"","" "","" ""}};

		

pointsForPolygons = sampleAdjacents(roofPoints); 

radius = 0.075;

factor = 0.5;

testTube = Tubulor.ByPoint(text, pointsForPolygons, radius, radius, factor);

x1 = testTube[0][1].secondary.StartPoint.X;

// testTube = Tubulor.ByPoint(""A"", pointsForPolygons[0][1], radius, radius, factor);

// testTube = Tubulor.ByPoint(""X"", pointsForPolygons[0][2], radius, radius, factor);

// testTube = Tubulor.ByPoint(""Y"", pointsForPolygons[0][3], radius, radius, factor);

// testTube = Tubulor.ByPoint(""M"", pointsForPolygons[0][4], radius, radius, factor);

// testTube = Tubulor.ByPoint(""H"", pointsForPolygons[2][1], radius, radius, factor);

// testTube = Tubulor.ByPoint(""P"", pointsForPolygons[2][2], radius, radius, factor);



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_Associative_Class_Property_Int()
        {
            string code = @"


	class Point

	{

        _x : int;

        _y : int;

        _z : int;

                                

        constructor Point(xx : int, yy : int, zz : int)

        {

			_x = xx;

            _y = yy;

            _z = zz;

        }

                                

        def get_X : int () 

        {

            return = _x;

        }



    }

	

	newPoint = Point.Point(1,2,3);

	

	xPoint = newPoint._x;

    yPoint = newPoint._y;            

    zPoint = newPoint._z;               









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_Associative_Function_DeclareAfterAssignment()
        {
            string code = @"
[Associative]

{



	a = 1;

	b = 10;

	

	sum = Sum (a, b);

	

	def Sum : int(a : int, b : int)

	{

	

	return = a + b;

	}

	

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_Associative_Function_Simple()
        {
            string code = @"
[Associative]

{

	def Sum : int(a : int, b : int)

	{

	

		return = a + b;

	}

	

	a = 1;

	b = 10;

	

	sum = Sum (a, b);

	

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_BasicImport_CurrentDirectory()
        {
            string code = @"
import (""basicImport.ds"");

a = {1.1,2.2};

b = 2;

c = Scale(a,b);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_FFI_MathLibrary_Sqrt_Trigonomatry()
        {
            string code = @"
class Math

{

                external (""ffi_library"") def dc_sqrt : double (val : double );

                external (""ffi_library"") def dc_sin  : double (val : double );

                external (""ffi_library"") def dc_cos  : double (val : double );

                external (""ffi_library"") def dc_tan  : double (val : double );

                external (""ffi_library"") def dc_asin : double (val : double );

                external (""ffi_library"") def dc_acos : double (val : double );

                external (""ffi_library"") def dc_atan : double (val : double );

                external (""ffi_library"") def dc_log  : double (val : double );

           

                constructor GetInstance()

                {}

                

                def Sqrt : double ( val : double )

                {

                                return = dc_sqrt(val);

                }



                def Sin : double ( val : double )

                {

                                return = dc_sin(val);

                }

                

                def Cos : double ( val : double )

                {

                                return = dc_cos(val);

                }

                

                def Tan : double ( val : double )

                {

                                return = dc_tan(val);

                }

                

                def ArcSin : double ( val : double )

                {

                                return = dc_asin(val);

                }

                

                def ArcCos : double ( val : double )

                {

                                return = dc_acos(val);

                }

                

                def ArcTan : double ( val : double )

                {

                                return = dc_atan(val);

                }

                

                def Log : double ( val : double )

                {

                                return = dc_log(val);

                }

}



[Associative]

{

                math = Math.GetInstance();

                

                sqrt_10 = math.Sqrt(10.0);

                log_100 = math.Log(100.0);

                

                angle = 30.0;

                sin_30 = math.Sin(angle);

                cos_30 = math.Cos(angle);

                tan_30 = math.Tan(angle);

                

                //            answer of each of these should be 30, 

                //            off course within tolerance of 1e-6

                asin_30 = math.ArcSin(sin_30);

                acos_30 = math.ArcCos(cos_30);

                atan_30 = math.ArcTan(tan_30);

                

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_Inline_Using_Function_Call__2_()
        {
            string code = @"


	def fo1 : int(a1 : int)

	{

		return = a1 * a1;

	}



	a	=	10;				

	b	=	20;

				

	smallest1   =   a	<   b   ?   a	:	b;

	largest1	=   a	>   b   ?   a	:	b;



	d = fo1(a);



	smallest2   =   (fo1(a))	<   (fo1(b))  ?   (fo1(a))	:	(fo1(a));	//100

	largest2	=   (fo1(a)) >   (fo1(b))  ?   (fo1(a))	:	(fo1(b)); //400













";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_Inline_Using_Function_Call()
        {
            string code = @"
[Imperative]

{

	def fo1 : int(a1 : int)

	{

		return = a1 * a1;

	}



	a	=	10;				

	b	=	20;

				

	smallest1   =   a	<   b   ?   a	:	b;

	largest1	=   a	>   b   ?   a	:	b;



	d = fo1(a);



	smallest2   =   (fo1(a))	<   (fo1(b))  ?   (fo1(a))	:	(fo1(a));	//100

	largest2	=   (fo1(a)) >   (fo1(b))  ?   (fo1(a))	:	(fo1(b)); //400

}













";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_LanguageBlockScope_AssociativeNestedAssociative()
        {
            string code = @"
[Associative]



{

	a = 10;

	b = true;

	c = 20.1;

	[Associative]	

	{

	

		a_inner = a;

		b_inner = b;

		c_inner = c;

	}



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_Language_specifier_invalid_1467065_1()
        {
            string code = @"
[associative]

{    a= 1;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_Language_specifier_invalid_1467065_2()
        {
            string code = @"
[imperative]

{    a= 1;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_SampleTest()
        {
            string code = @"
class Point

{

    x : var;

    y : var;

    z : var;



    constructor Point()

    {

        x = 10; y = 20; z = 30;

    }

}

[Imperative]

{

    p = Point.Point();

    y = p.x;

    arr = { 1, 2, 3, { 4, 5 }, 6.0, 7, { 8.0, 9 } };

    p.x = 20;

    arr = { arr, y };

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_Simple_Update()
        {
            string code = @"
a = 1;

b = a + 1;

a = 2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_SomeNulls_IfElse_01()
        {
            string code = @"
result =

[Imperative]

{

	arr1 = {1,null};

	arr2 = {1,2};

	if(SomeNulls(arr1))

	{

		arr2 = arr1;

	}

	return = SomeNulls(arr2);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_SomeNulls_IfElse_02()
        {
            string code = @"
result =

[Imperative]

{

	arr1 = {};

	arr2 = {1,2};

	if(SomeNulls(arr1))

	{

		arr2 = arr1;

	}

	return = SomeNulls(arr2);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_implicit_programming_Robert()
        {
            string code = @"
// no paradigm specified, so assume associative



// some associative code ....



a = 10;

b = a*2;

a = a +1; 	// expanded modifier, therefore the statement on line 7 is calculated after the statement on line 6 is excuted

c = 0;



//some imperative code ....

if (a>10) 	// implicit switch to imperative paradigm

{

	c = b; 	// so statements are treated in lexical order, therefore the statement on line 13

	b=b/2;	// is executed before the statement on line 14 [as would be expected]

}

else

{

	[Associative] 	// explicit switch to associative paradigm [overrides the imperative paradigm]

	{

		c = b;    	// c references the final state of b, therefore [because we are in an associative paradigm] 

		b = b*2;	// the statement on line 21 is executed before the statement on line 20

	}

}



// some more associative code ....



a = a + 2;	// I am assuming that this statement (on line 27) is executed after the if..else has been evaluated and executed, because...

			// effectively, when a imperative block is nested within an associative block, lexical order plays a role

			// in that the execution order is:

			//			the part of the associative graph before the imperative block

			//			the imperative block

			//			the part of the associative graph after the imperative block







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT001_implicit_programming_Robert_2()
        {
            string code = @"
// no paradigm specified, so assume associative



// some associative code ....



a = 10;

b = a*2;

a = a +1; 	// expanded modifier, therefore the statement on line 7 is calculated after the statement on line 6 is excuted

c = 0;



//some imperative code ....

[Imperative]

{

	if (a>10) 	// explicit switch to imperative paradigm

	{

		c = b; 	// so statements are treated in lexical order, therefore the statement on line 13

		b=b/2;	// is executed before the statement on line 14 [as would be expected]

	}

	else

	{

		[Associative] 	// explicit switch to associative paradigm [overrides the imperative paradigm]

		{

			c = b;    	// c references the final state of b, therefore [because we are in an associative paradigm] 

			b = b*2;	// the statement on line 21 is executed before the statement on line 20

		}

	}

}



// some more associative code ....



a = a + 2;	// I am assuming that this statement (on line 27) is executed after the if..else has been evaluated and executed, because...

			// effectively, when a imperative block is nested within an associative block, lexical order plays a role

			// in that the execution order is:

			//			the part of the associative graph before the imperative block

			//			the imperative block

			//			the part of the associative graph after the imperative block







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT002_Associative_Class_Property_Double()
        {
            string code = @"


	class Point

	{

        _x : double;

        _y : int;

        _z : int;

                                

        constructor Point(xx : double, yy : double, zz : double)

        {

			_x = xx;

            _y = yy;

            _z = zz;

        }

                                

        def get_X : double () 

        {

            return = _x;

        }



    }

	

	newPoint = Point.Point(1.1,2.2,3.3);

	

	xPoint = newPoint._x;

    yPoint = newPoint._y;            

    zPoint = newPoint._z;               









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT002_Associative_Function_SinglelineFunction()
        {
            string code = @"
[Associative]

{



	def singleLine : int(a:int, b:int) = 10;



	d = singleLine(1,3);

	



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT002_BasicImport_AbsoluteDirectory()
        {
            string code = @"
import (""..\..\..\Scripts\TD\MultiLanguage\Import\basicImport.ds"");

a = {1.1,2.2};

b = 2;

c = Scale(a,b);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT002_FFI_Matrix_Simple()
        {
            string code = @"
class Matrix

{

    id : var;

    rows : var;

    cols : var;

    

    external (""ffi_library"") def dc_create_matrix : int (rows : int, cols : int);

    external (""ffi_library"") def dc_delete_matrix : int (id : int);

    external (""ffi_library"") def dc_set_matrix_element : double( ptr : int, row : int, col : int, value : double);

    external (""ffi_library"") def dc_get_matrix_element : double( ptr : int, row : int, col : int);

    

    constructor Create(row : int, col : int)

    {

        rows = row;

        cols = col;

        id = dc_create_matrix(rows, cols);

    }



    def SetAt : double ( row: int, col : int, value : double)

    {

        dummy = dc_set_matrix_element(id, row, col, value);

        return = dummy;

    }

    

    def GetAt : double ( row : int, col : int )

    {

        //return = dc_get_matrix_element(id, row, col);

        return = 1.0;

    }

    

        def Delete : bool ()

    {

        id = dc_delete_matrix(id);

        return = false;

    }

    

}



[Associative]

{

    mat1 = Matrix.Create(4,4);

    

    val = 1.0;

    dummy1 = mat1.SetAt(0,0,val);

    dummy2 = mat1.SetAt(1,1,val);

    dummy3 = mat1.SetAt(2,2,val);

    dummy4 = mat1.SetAt(3,3,val);

    

    val_00 = mat1.GetAt(0,0);

    val_11 = mat1.GetAt(1,1);

    val_22 = mat1.GetAt(2,2);

    val_33 = mat1.GetAt(3,3);

    

    mat2 = mat1.Delete();

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT002_Inline_Using_Math_Lib_Functions__2_()
        {
            string code = @"
    class Math

	{

	    static def Sqrt ( a : var ) 

		{

		    return = a/2.0;

		}

	}

	

	def fo1 :int(a1 : int)

	{

		return = a1 * a1;

	}



	a	=	10;				

	b	=	20;

				

	smallest1   =   a	<   b   ?   a	:	b; //10

	largest1	=   a	>   b   ?   a	:	b; //20



	smallest2   =   Math.Sqrt(fo1(a))	<   Math.Sqrt(fo1(b))  ?   Math.Sqrt(fo1(a))	:	Math.Sqrt(fo1(a));	//50.0

	largest2	=   Math.Sqrt(fo1(a)) >   Math.Sqrt(fo1(b))  ?   Math.Sqrt(fo1(a))	:	Math.Sqrt(fo1(b)); //200.0













";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT002_Inline_Using_Math_Lib_Functions()
        {
            string code = @"
[Imperative]

{

	external (""libmath"") def dc_sqrt : double (val : double);

def sqrt : double (val : double)

{

     return = dc_sqrt(val);

}



def fo1 (a1 : int)  = a1 * a1 ;



a    =    10;                

b    =    20;

                   

smallest1   =   a  <   b   ?   a :    b; //10

largest1  =   a     >   b   ?   a :    b; //20



d = fo1(a);



smallest2   =   sqrt(fo1(a)) <   sqrt(fo1(b))  ?   sqrt(fo1(a))    :     sqrt(fo1(a)); //10.0

largest2  =   sqrt(fo1(a)) >   sqrt(fo1(b))  ?   sqrt(fo1(a))  :     sqrt(fo1(b)); //20.0



}













";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT002_LanguageBlockScope_ImperativeNestedImperaive()
        {
            string code = @"
[Imperative]

{

	a = 10;

	b = true;

	c = 20.1;

	[Imperative]	

	{

		a_inner = a;

		b_inner = b;

		c_inner = c;

	}



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT002_SomeNulls_ForLoop()
        {
            string code = @"
result = 

[Imperative]

{

	a = {1,3,5,7,{}};

	b = {null,null,true};

	c = {SomeNulls({1,null})};

	d = {a,b,c};

	j = 0;

	e = {};

	

	for(i in d)

	{

		

		e[j]= SomeNulls(i);

		j = j+1;

	}

	return  = e;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT002_Update_Collection()
        {
            string code = @"
a = 0..4..1;

b = a;

c = b[2];

a = 10..14..1;

b[2] = b[2] + 1;

a[2] = a[2] + 1;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT002_limits_to_replication_1_Robert()
        {
            string code = @"
a = 0..10..2; 

b = a>5? 0:1; 



[Imperative]

{

	c = a * 2; // replication within an imperative block [OK?]

	d = a > 5 ? 0:1; // in-line conditional.. operates on a collection [inside an imperative block, OK?]

	if( c[2] > 4 ) x = 10; // if statement evaluates a single term [OK]

	

	if( c > 4 ) // but... replication within a regular 'if..else' any support for this?

	{

		y = 1;

	}

	else

	{

		y = -1;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT003_Associative_Class_Property_Bool()
        {
            string code = @"


	class Point

	{

        _x : bool;

                                

        constructor Point(xx : bool)

        {

			_x = xx;



        }

                                

    }

	newPoint1 = Point.Point(true);

	newPoint2 = Point.Point(false);

	propPoint1 = newPoint1._x;

    propPoint2 = newPoint2._x;            

              









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT003_Associative_Function_MultilineFunction()
        {
            string code = @"
[Associative]

{



	def Divide : int(a:int, b:int)

	{

		return = a/b;

	}



	d = Divide (1,3);

	



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT003_BasicImport_ParentPath()
        {
            string code = @"
import (""../basicImport.ds"");

a = {1.1,2.2};

b = 2;

c = Scale(a,b);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT003_FFI_Tuple4_XYZH_Simple()
        {
            string code = @"
class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double(other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 :double[] () 

    { 

        return = {X, Y, Z, H };

    }

    

    

}





tuple1 = Tuple4.XYZH (-10.0, -20.0, -30.0, -40);

resultX = tuple1.X;

resultY = tuple1.Y;

resultZ = tuple1.Z;

resultH = tuple1.H;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT003_Inline_Using_Collection__2_()
        {
            string code = @"


	Passed = 1;

	Failed = 0;

	Einstein = 56;



	BenBarnes = 90;

	BenGoh = 5;

	Rameshwar = 80;

	Jun = 68;

	Roham = 50;



	Smartness = { BenBarnes, BenGoh, Jun, Rameshwar, Roham }; // { 1, 0, 1, 1, 0 }

	Results = Smartness > Einstein ? Passed : Failed;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT003_Inline_Using_Collection()
        {
            string code = @"
[Imperative]

{

	Passed = 1;

	Failed = 0;

	Einstein = 56;



	BenBarnes = 90;

	BenGoh = 5;

	Rameshwar = 80;

	Jun = 68;

	Roham = 50;



	Smartness = { BenBarnes, BenGoh, Jun, Rameshwar, Roham }; // { 1, 0, 1, 1, 0 }

	Results = Smartness > Einstein ? Passed : Failed;



	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT003_LanguageBlockScope_ImperativeNestedAssociative()
        {
            string code = @"
[Imperative]

{

	a = 10;

	b = true;

	c = 20.1;

	[Associative]	

	{

		a_inner = a;

		b_inner = b;

		c_inner = c;

	}



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT003_SomeNulls_WhileLoop()
        {
            string code = @"
result = 

[Imperative]

{

	a = {1,3,5,7,{}};

	b = {null,null,true};

	c = {{}};

	

	d = {a,b,c};

	

	i = 0;

	j = 0;

	e = {};

	

	while(i<Count(d))

	{

	

		e[j]= SomeNulls(d[i]);

		i = i+1;

		j = j+1;

	}

	return = e ;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT003_Update_In_Function_Call()
        {
            string code = @"
def foo1 ( a : int ) 

{

    return = a + 1;

}



def foo2 ( a : int[] ) 

{

    a[0] = a[1] + 1;

	return = a;

}



def foo3 ( a : int[] ) 

{

    b = a;

	b[0] = b[1] + 1;

	return = b;

}



a = 0..4..1;

b = a[0];

c = foo1(b);

d = foo2(a);

e1 = foo3(a);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT003_modifying_members_of_a_collection_abstract_1_Robert()
        {
            string code = @"
a = #{

	2 => a@init;

    +4;

    -3;                                

}

















































/*a =

	{

		{1,2,3,4};

		//{a[0], a[-1]} -5; // modify selected members [question: can we refer to 'a' in this way inside its own modifier block?]

		+10 // this modification applies to the whole collection

	}

	

b = a + 1; // use the complete 'a' collection 'downstream'

	

// option 2: embed the selective modification of members of a collection within the modifier block of that collection

//           using a right assign variable to identify the state of the cellection from which to select the members to modify



a =

	{

		{1,2,3,4} => a@initial; // identify the initial state to modify

		{a@initial[0], a@initial[-1] -5;  // modify selected members [question: can we refer to 'a@initial' in this way 

											// inside the modifier block where the right assigned variable was created?]

		+10 // this modification applies to the whole collection

	}

	

b = a + 1; // use the complete 'a' collection 'downstream'



// option 3: make an alias from members of a collection to be modified



a =

	{

		{1,2,3,4};

		+10 // this modification applies to the whole collection

	}



cornerA <=> {a[0], a[-1]}; // create alias from members of the 'a' collection



cornerA =

	{

		-5;  // alias applies to the final state of 'a'

	}

	

b = a + 1; // use the complete 'a' collection 'downstream'



	

// option 4: make an alias from a right assigned variable (defining an intermediate state of the original modifier block)



a =

	{

		{1,2,3,4} => a@initial; // identify the initial state to modify

		+10 // this modification applies to the whole collection

	}

	

// create an alias from right assigned variable (defining an intermediate state of the original modifier block)



cornerA <=> {a@initial[0], a@initial[-1]}; 



cornerA =

	{

		-5;  // alias applies to an intermediate state of 'a'

	}

	

b = a + 1; // use the complete 'a' collection 'downstream'



// option 5: direct 'long hand' modification of members of a collection



a =

	{

		{1,2,3,4} => a@initial; // identify the initial state to modify

		+10 // this modification applies to the whole collection

	}

	

// directly modify members of the collection



{a[0], a[-1]} = {a[0], a[-1]} -5;

	

b = a + 1; // use the complete 'a' collection 'downstream'



// option 6: semi-direct 'long hand' modification of members of a collection using an alias



a =

	{

		{1,2,3,4} => a@initial; // identify the initial state to modify

		+10 // this modification applies to the whole collection

	}

	

// create an alias from right assigned variable (defining an intermediate state of the original modifier block)



cornerA <=> {a@initial[0], a@initial[-1]}; 



cornerA = cornerA -5;  // alias applies to an intermediate state of 'a'

	

b = a + 1; // use the complete 'a' collection 'downstream'



*/
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT004_Associative_Class_Property_DefaultInitialization()
        {
            string code = @"


	class TestClass

	{

        _var : var;

		_int : int;

		_double : double;

		_bool : bool;

                                

        constructor TestClass ()

        {

        }       

    }

	newClass = TestClass.TestClass();



	defaultVar = newClass._var;

	defaultInt = newClass._int;

	defaultDouble = newClass._double;

	defaultBool = newClass._bool;









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT004_Associative_Function_SpecifyReturnType()
        {
            string code = @"
[Associative]

{

	def Divide : double (a:int, b:int)

	{

		return = a/b;

	}

	d = Divide (1,3);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT004_BasicImport_CurrentDirectoryWithDotAndSlash()
        {
            string code = @"
import ("".\basicImport.ds"");

a = {1.1,2.2};

b = 2;

c = Scale(a,b);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT004_FFI_Tuple4_XYZ_Simple_WithGetMethods()
        {
            string code = @"
class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double(other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 :double[] () 

    { 

        return = {X, Y, Z, H };

    }

    

    

}





tuple1 = Tuple4.XYZ (-10.0, -20.0, -30.0);

resultX = tuple1.get_X();

resultY = tuple1.get_Y();

resultZ = tuple1.get_Z();

resultH = tuple1.get_H();



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT004_Inline_Inside_Class_Constructor_and_replication()
        {
            string code = @"
class MyClass

{

    positive : var;

    constructor ByValue(value : int)

    {

        positive = value >= 0 ? true : false;

    }

}



number = 2;

sample = MyClass.ByValue(number);

values = sample.positive; // { true, false } 

number = { 3, -3 };











";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT004_LanguageBlockScope_AssociativeNestedImperative()
        {
            string code = @"
[Associative]

{

	a = 10;

	b = true;

	c = 20.1;

	[Imperative]	

	{

		a_inner = a;

		b_inner = b;

		c_inner = c;

	}

	





}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT004_SomeNulls_Function()
        {
            string code = @"
def foo(x:var[]..[])

{

	a = {};

	i = 0;

	[Imperative]

	{

		for(j in x)

		{

			if(SomeNulls(j))

			{

				a[i] = j;

				i = i+1;

			}

		}

	}

	return  = Count(a);

}



b = {



{null},

{1,2,3,{}},



{0}



};

result = foo(b);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT004_Update_In_Function_Call_2()
        {
            string code = @"
def foo1 ( a : int ) 

{

    return = a + 1;

}



def foo3 ( a : int[] ) 

{

    b = a;

	b[0] = b[1] + 1;

	return = b;

}



a = 0..4..1;

b = a[0];

c = foo1(b);

e1 = foo3(a);

a = 10..14..1;

a[1] = a[1] + 1;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT004_simple_order_1_Robert()
        {
            string code = @"
a1 = 10;        // =1

b1 = 20;        // =1



a2 = a1 + b1;   // =3

b2 = b1 + a2;   // =3



b  = b2 + 2;    // 5

a  = a2 + b;    // 6
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT005_Associative_Class_Property_Get_InternalClassFunction()
        {
            string code = @"


	class MyPoint

	{

		X : double;

		Y : double;

		Z : double;

                                

        constructor MyPoint (x : double, y : double, z : double)

        {

			X = x;

			Y = y;

			Z = z;

        } 

		

		def Get_X : double()

		{

			return = X;

		}

		

		def Get_Y : double()

		{

			return = Y;	

		}

		

		def Get_Z : double ()

		{

			return = Z;

		}

		

		def Sum : double ()

		{

			return = Get_X() + Get_Y() + Get_Z();

		}

    }

	

	myNewPoint = MyPoint.MyPoint (0.0, 1.2, 3.5);

	val = myNewPoint.Sum();









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT005_Associative_Function_SpecifyArgumentType()
        {
            string code = @"
[Associative]

{

	def myFunction : int (a:int, b:int)

	{

		return = a + b;

	}

	d1 = 1.12;

	d2 = 0.5;

	

	result = myFunction (d1, d2);

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT005_BasicImport_RelativePath()
        {
            string code = @"
import ("".\ExtraFolderToTestRelativePath\basicImport.ds"");

a = {1.1,2.2};

b = 2;

c = Scale(a,b);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT005_FFI_Tuple4_ByCoordinate3_Simple()
        {
            string code = @"
class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double(other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 :double[] () 

    { 

        return = {X, Y, Z, H };

    }

    

    

}

cor1 = {10.0, 11.0, 12.0, 13.0};







tuple1 = Tuple4.ByCoordinates3 (cor1);



result3 = tuple1.Coordinates3();

result4 = tuple1.Coordinates4();



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT005_Inline_Using_2_Collections_In_Condition__2_()
        {
            string code = @"


	a1 	=  1..3..1; 

	b1 	=  4..6..1; 



	a2 	=  1..3..1; 

	b2 	=  4..7..1; 



	a3 	=  1..4..1; 

	b3 	=  4..6..1; 



	c1 = a1 > b1 ? true : false; // { false, false, false }

	c2 = a2 > b2 ? true : false; // { false, false, false }

	c3 = a3 > b3 ? true : false; // { false, false, false, null }









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT005_Inline_Using_2_Collections_In_Condition()
        {
            string code = @"
[Imperative]

{

	a1 	=  1..3..1; 

	b1 	=  4..6..1; 



	a2 	=  1..3..1; 

	b2 	=  4..7..1; 



	a3 	=  1..4..1; 

	b3 	=  4..6..1; 



	c1 = a1 > b1 ? true : false; // { false, false, false }

	c2 = a2 > b2 ? true : false; // { false, false, false }

	c3 = a3 > b3 ? true : false; // { false, false, false, null }

}









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT005_LanguageBlockScope_DeepNested_IAI()
        {
            string code = @"
[Imperative]

{

	a = 10;

	b = true;

	c = 20.1;

	[Associative]	

	{

		a_inner1 = a;

		b_inner1 = b;

		c_inner1 = c;

		

		

		[Imperative]

		{

			a_inner2 = a;

			b_inner2 = b;

			c_inner2 = c;

			

		}

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT005_SomeNulls_Class()
        {
            string code = @"
class C

{

	a : var;

	constructor C(x:var[]..[])

	{

		a = SomeNulls(x);

	}

	

	def foo(y:var[]..[])

	{

		return = SomeNulls(y);

	}

}



l = {1, null, true,{}};

c = C.C(l);

m = c.a;

n = c.foo(l);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT005_Update_In_collection()
        {
            string code = @"
a=1;

b=2;

c=4;

collection = {a,b,c};

collection[1] = collection[1] + 0.5;

d = collection[1];

d = d + 0.1; // updates the result of accessing the collection

b = b + 0.1; // updates the source member of the collection
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT005_modifiers_with_right_assignments_Robert()
        {
            string code = @"
a = 

    {

        10     => @a1 ;  // =1

        + @b1  => @a2;   // =3

        + b ;            // 6 

    }            

    

b = 

    {

        20     => @b1;   // =1

        + @a2  => @b2 ;  // =3

        + 2 ;            // 5

    }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT006_Associative_Class_Property_UseInsideInternalClassFunction()
        {
            string code = @"


	class MyPoint

	{

		X : double;

		Y : double;

		Z : double;

                                

        constructor MyPoint (x : double, y : double, z : double)

        {

			X = x;

			Y = y;

			Z = z;

        } 

		

		def Sum : double ()

		{

			return = X + Y + Z;

		}

    }

	

	myNewPoint = MyPoint.MyPoint (0.0, 1.2, 3.5);

	val = myNewPoint.Sum();









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT006_Associative_Function_PassingNullAsArgument()
        {
            string code = @"
[Associative]

{

	def myFunction : double (a: double, b: double)

	{

		return = a + b;

	}

	d1 = null;

	d2 = 0.5;

	

	result = myFunction (d1, d2);

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT006_BasicImport_TestFunction()
        {
            string code = @"
import (""basicImport.ds"");

a = {1.1,2.2};

b = 2;

c = Scale(a,b);

d = Sin(30.0);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT006_FFI_Tuple4_ByCoordinate4_Simple()
        {
            string code = @"
class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double(other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 :double[] () 

    { 

        return = {X, Y, Z, H };

    }

    

    

}

cor1 = {10.0, 11.0, 12.0, 13.0};







tuple1 = Tuple4.ByCoordinates4 (cor1);



result3 = tuple1.Coordinates3();

result4 = tuple1.Coordinates4();



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT006_Inline_Using_Different_Sized_1_Dim_Collections__2_()
        {
            string code = @"


	a = 10 ;

	b = ((a - a / 2 * 2) > 0)? a : a+1 ; //11

	c = 5; 

	d = ((c - c / 2 * 2) > 0)? c : c+1 ; //5 

	e1 = ((b>(d-b+d))) ? d : (d+1); //5





	//inline conditional, returning different sized collections

	c1 = {1,2,3};

	c2 = {1,2};

	a1 = {1, 2, 3, 4};

	b1 = a1>3?true:a1; // expected : {1, 2, 3, true}

	b2 = a1>3?true:c1; // expected : {1, 2, 3}

	b3 = a1>3?c1:c2;   // expected : {1, 2}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT006_Inline_Using_Different_Sized_1_Dim_Collections()
        {
            string code = @"
[Imperative]

{

	a = 10 ;

	b = ((a - a / 2 * 2) > 0)? a : a+1 ; //11

	c = 5; 

	d = ((c - c / 2 * 2) > 0)? c : c+1 ; //5 

	e1 = ((b>(d-b+d))) ? d : (d+1); //5





	//inline conditional, returning different sized collections

	c1 = {1,2,3};

	c2 = {1,2};

	a1 = {1, 2, 3, 4};

	b1 = a1>3?true:a1; // expected : {1, 2, 3, true}

	b2 = a1>3?true:c1; // expected : {1, 2, 3}

	b3 = a1>3?c1:c2;   // expected : {1, 2}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT006_LanguageBlockScope_DeepNested_AIA()
        {
            string code = @"
[Associative]

{

	a = 10;

	b = true;

	c = 20.1;

	[Imperative]	

	{

		a_inner1 = a;

		b_inner1 = b;

		c_inner1 = c;

		

		

		[Associative]

		{

			a_inner2 = a;

			b_inner2 = b;

			c_inner2 = c;

			

		}

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT006_SomeNulls_Inline()
        {
            string code = @"
[Imperative]

{

a = {null,1};

b = {};

c = {1,2,3};



result = SomeNulls(c)?SomeNulls(b):SomeNulls(a);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT006_Update_In_Class()
        {
            string code = @"
class Point

{

    X : double;

	Y : double;

	Z : double;

	

	constructor ByCoordinates( x : double, y : double, z : double )

	{

	    X = x;

		Y = y;

		Z = z;		

	}

}



class Line

{

    P1 : Point;

	P2 : Point;

	

	constructor ByStartPointEndPoint( p1 : Point, p2 : Point )

	{

	    P1 = p1;

		P2 = p2;

	}

	

	def PointAtParameter (p : double )

	{

	

	    t1 = P1.X + ( p * (P2.X - P1.X) );

		return = Point.ByCoordinates( t1, P1.Y, P1.Z);

	    

	}

	

}





startPt = Point.ByCoordinates(1, 1, 0);

endPt   = Point.ByCoordinates(1, 5, 0);

line_0  = Line.ByStartPointEndPoint(startPt, endPt); 	// create line_0

j;

//startPt = Point.ByCartesianCoordinates((1..5..1), 1, 0); // with range expression

//endPt   = Point.ByCartesianCoordinates((1..5..1), 5, 0); // with range expression.. but line does not replicate

//line_0  = Line.ByStartPointEndPoint(startPt<1>, endPt<2>); 	// add replication guides <1> <2>

startPt2 = [Imperative]

{

    x2 = 1..5..1;

	p2 = 0..0..#5;

	c2 = 0;

	for (i in x2 )

	{

	    p2[c2] = Point.ByCoordinates(i, 1, 0);		

		c2 = c2 + 1;

	}

	return = p2;

}

endPt2 = [Imperative]

{

    x2 = 11..15..1;

	p2 = 0..0..#5;

	c2 = 0;

	for (i in x2 )

	{

	    p2[c2] = Point.ByCoordinates(i, 5, 0);		

		c2 = c2 + 1;

	}

	return = p2;

}

line_0 = [Imperative]

{    

	p2 = 0..0..#25;

	c2 = 0;

	for (i in startPt2 )

	{

	    for ( j in endPt2 )

		{

		    p2[c2] = Line.ByStartPointEndPoint(i, j);

			c2 = c2 + 1;

		}

			

	}

	return = p2;

}

x1_start = line_0[0].P1.X;

x1_end = line_0[0].P2.X;

x5_start = line_0[4].P1.X;

x5_end = line_0[4].P2.X;



//line_0  = Line.ByStartPointEndPoint(startPt, endPt); 		// remove replication guides

line_0 = [Imperative]

{    

	p2 = 0..0..#5;

	c2 = 0;

	for (i in startPt2 )

	{

	    p2[c2] = Line.ByStartPointEndPoint(startPt2[c2], endPt2[c2]);

		c2 = c2 + 1;

			

	}

	return = p2;

}



//startPt = Point.ByCoordinates(1, 1, 0); // go back to single line

//endPt   = Point.ByCoordinates(1, 5, 0);

//line_0  = Line.ByStartPointEndPoint(startPt, endPt); 	// create line_0 as a singleton again



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT006_grouped_1_Robert()
        {
            string code = @"
a1 = 10;        // =1

a2 = a1 + b1;   // =3

a  = a2 + b;    // 6    

    

b1 = 20;        // =1

b2 = b1 + a2;   // =3

b  = b2 + 2;    // 5
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT007_Associative_Class_Property_CallFromFunctionOutsideClass()
        {
            string code = @"


	class MyPoint

	{

		X : double;

		Y : double;

		Z : double;

                                

        constructor MyPoint (x : double, y : double, z : double)

        {

			X = x;

			Y = y;

			Z = z;

        }

		

		

		def Get_X : double()

		{

			return = X;

		}

		

		def Get_Y : double()

		{

			return = Y;

		}

		def Get_Z : double()

		{

			return = Z;

		}

    }

	

	def GetPointValue : double (pt : MyPoint)

	{

		return = pt.Get_X() + pt.Get_Y() + pt.Get_Z(); 

	}

	

	myNewPoint = MyPoint.MyPoint (1.0, 10.1, 200.2);

	myPointValue = GetPointValue(myNewPoint);









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT007_Associative_Function_NestedFunction()
        {
            string code = @"
[Associative]

{



	def ChildFunction : double (r1 : double)

	{

	return = r1;

	

	}

	def ParentFunction : double (r1 : double)

	{

		return = ChildFunction (r1)*2;

	}

	d1 = 1.05;

	

	result = ParentFunction (d1);

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT007_BasicImport_TestClassConstructorAndProperties()
        {
            string code = @"
import (""basicImport.ds"");

x = 10.1;

y = 20.2;

z = 30.3;



myPoint = Point.ByCoordinates(10.1, 20.2, 30.3);



myPointX = myPoint.X;

myPointY = myPoint.Y;

myPointZ = myPoint.Z;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT007_FFI_Tuple4_Multiply_Simple()
        {
            string code = @"
class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double(other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 :double[] () 

    { 

        return = {X, Y, Z, H };

    }

    

    

}

cor1 = {10.0, 10.0, 10.0, 10.0};

cor2 = {10.0, 10.0, 10.0, 10.0};





tuple1 = Tuple4.ByCoordinates4 (cor1);

tuple2 = Tuple4.ByCoordinates4 (cor2);



result1 = tuple1.Coordinates4();

result2 = tuple2.Coordinates4();



multiply = tuple1.Multiply(tuple2);





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT007_Inline_Using_Collections_And_Replication_CollectionFunctionCall__2_()
        {
            string code = @"


	def even : int(a : int)

	{

		return = a * 2;

	}

	a =1..10..1 ; //{1,2,3,4,5,6,7,8,9,10}

	i = 1..5; 

	b = ((a[i] % 2) > 0)? even(a[i]) : a ;  // { 1, 6, 3, 10, 5 }	

	c = ((a[0] % 2) > 0)? even(a[i]) : a ; // { 4, 6, 8, 10, 12 }

	d = ((a[-2] % 2) == 0)? even(a[i]) : a ; // { 1, 2,..10}

	e1 = (a[-2] == d[9])? 9 : a[1..2]; // { 2, 3 }









";
            // defect : DNL-1467619 Regression : Replication + InlineCondition yields different output in release and debug mode
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT007_Inline_Using_Collections_And_Replication_CollectionFunctionCall()
        {
            string code = @"
[Imperative]

{

	def even : int(a : int)

	{

		return = a * 2;

	}

	a =1..10..1 ; //{1,2,3,4,5,6,7,8,9,10}

	i = 1..5; 

	b = ((a[i] % 2) > 0)? even(a[i]) : a ;  // { 1, 6, 3, 10, 5 }	

	c = ((a[0] % 2) > 0)? even(a[i]) : a ; // { 4, 6, 8, `0, `2 }

	d = ((a[-2] % 2) == 0)? even(a[i]) : a ; // { 1, 2,..10}

	e1 = (a[-2] == d[9])? 9 : a[1..2]; // { 2, 3 }

}









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT007_LanguageBlockScope_AssociativeParallelImperative()
        {
            string code = @"
[Associative]

{

	a = 10;

	b = true;

	c = 20.1;

	

}



[Imperative]	

{

	aI = a;

	bI = b;

	cI = c;

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT007_SomeNulls_RangeExpression()
        {
            string code = @"
result =

[Imperative]

{

i = 0;

arr = {{1,1.2} , {null,0}, {true, false} };



a1 = 0;

a2 = 2;

d = 1;



a = a1..a2..d;



for(i in a)

{

	if(SomeNulls(arr[i])) 

	return = i;

	

}

return = -1;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT007_Update_In_Class()
        {
            string code = @"
def sin ( a : double ) = 0.5 * a;

def cos ( a : double ) = 0.5 * a;

def atan ( a : double ) = 0.5 * a;

def sqrt ( a : double ) = 0.5 * a;



class Point

{

    X : double;

	Y : double;

	Z : double;

	

	public constructor ByCartesianCoordinates( xValue : double , yValue : double, zValue : double )

    {

		X = xValue; 			

		Y = yValue;

		Z = zValue;

	}

}

class MyPoint 

{

	// define general system of dependencies

	

	x : double = radius * cos(theta*180/180); // x dependent on theta and radius

	y : double = radius * sin(theta*180/180); // y dependent on theta and radius

	z : double = 0.0;

											

	theta :double = 3.0;//atan(y/x) * 180 / 180;		 	 // theta  dependent on x and y

	radius :double = 4.0;//sqrt(x*x + y*y);				 // radius dependent on x and y

	

	inner  : Point = Point.ByCartesianCoordinates(x,y,z);	 // create inner point dependent on x and y

	

    public constructor ByXYcoordinates(xValue : double , yValue : double)

    {

		x = xValue; 			// assigning argument values to specific properties

		y = yValue; 			// overrides defaut graph and triggers remianing depenencies

								// we don't need to add in the statemenst to recompute theta and radius

								// this will happen 'automatically', because of the dependencies

								// defined in the body of the class

	}

	

	public constructor ByAngleRadius(thetaValue : double , radiusValue : double)

    {

		theta  = thetaValue;	// assigning argument values to specific properties

		radius = radiusValue; 	// overrides defaut graph and triggers remaining depenencies								// we don't need to add in the statemenst to recompute theta and radius

								// we don't need to add in the statemenst to recompute x and y

								// this will happen 'automatically', because of the dependencies

								// defined in the body of the class

	}

	

	// add 'incremental' modifiers

	

	def incrementX(this : MyPoint, xValue : double) = ByXYcoordinates(this.x + xValue, this.y);

	def incrementY(this : MyPoint, yValue : double) = ByXYcoordinates(this.x,this.y + yValue);

	def incrementTheta(this : MyPoint, thetaValue : double)  = ByAngleRadius(this.theta + thetaValue, this.radius );

	def incrementRadius(this : MyPoint, radiusValue : double)= ByAngleRadius(this.theta, this.radius + radiusValue );

}



a 		= MyPoint.ByXYcoordinates(1.0, 1.0);			// create an instance 'a' using one constructor







origin  = Point.ByCartesianCoordinates(WCS, 0,0,0);  				// create a reference point

testLine= Line.ByStartPointEndPoint(origin, a.inner);	// create a testLine (to see some results)

aX 		= a.x;											// report the properties of 'a'

aY 		= a.y;

aTheta 	= a.theta;

aRadius = a.radius;



a 		= MyPoint.ByAngleRadius(60.0, 1.0);				// switch to a different constructor [POINT updates]



//a		= a.visible(false); 

a 		= a.incrementX(0.2);							// apply different modifiers [POINT does not updates]

//a		= a.visible(false);

a 		= a.incrementY(-0.2);							// apply different modifiers [POINT does not updates]



a 		= MyPoint.ByAngleRadius(45.0, 0.75);			// redefine a (by using a constructor) [POINT updates]



//a		= a.visible(false);

a 		= a.incrementTheta(10.0);						// apply different modifiers [POINT does not updates]

//a		= a.visible(false);

a 		= a.incrementRadius(0.2); 						// [POINT does not updates]



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT007_surface_trimmed_with_modifier_and_named_states_Robert()
        {
            string code = @"
class BSplineSurface

{

    x : double;

	constructor ByControlVertices( a : double)

	{

	    x = a;

	}

	def Trim ( a1 : BSplineSurface, p1 : Point )

	{

	    temp = a1.x + p1.x;

		n1 = BSplineSurface.ByControlVertices( temp);

		return = n1;

	}

	def AtParameter ( x1 : double, y1 : double )

	{

	    temp = x + x1 + y1;

		n1 = Point.ByCartesianCoordinates ( temp );

		return = n1;

	}

}

class Point

{

    x : double;

	constructor ByCartesianCoordinates( a : double)

	{

	    x = a;

	}	

}

a = 1;

b = 2;

mySurface = 

    {

        BSplineSurface.ByControlVertices ( a ) => mySurface@initial ; // built with some 2D array of points

        Trim(cuttingSurface, samplePoint) ;

    }

    

cuttingSurface = BSplineSurface.ByControlVertices ( b ); // built with another 2D array of points

samplePoint    = mySurface@initial.AtParameter( 0.5, 0.5 );

test = mySurface.x; //expected : 4

// sample points is created using the first state of mySurface [mySurface@initial]

// and then it used in creating the second (and final) state of mySurface
";
            //Assert.Fail("");
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT008_Associative_Class_Property_CallFromAnotherExternalClass()
        {
            string code = @"
class MyVector

{

	X : double;

	Y : double;

						

	constructor MyVector (x : double, y : double)

	{

		X = x;

		Y = y;

	}



}



class MyPoint

{

	X : double;

	Y : double;

	Z : double;

	

	constructor MyPoint (direction : MyVector, z : double)

	{

		X = direction.X;

		Y = direction.Y;

		Z = z;

	}

}





XYDirection = MyVector.MyVector (1.3,20.5);

myPoint = MyPoint.MyPoint(XYDirection, 300.8);



xPosition = myPoint.X;

yPosition = myPoint.Y;

zPosition = myPoint.Z;

	









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT008_Associative_Function_DeclareVariableBeforeFunctionDeclaration()
        {
            string code = @"
[Associative]

{

    a = 1;

	b = 10;

	def Sum : int(a : int, b : int)

	{

	

		return = a + b;

	}

	

	sum = Sum (a, b);

	

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT008_BasicImport_TestClassConstructorAndProperties_UserDefinedClass()
        {
            string code = @"
import (""basicImport.ds"");

x1 = 10.1;

y1 = 20.2;

z1 = 30.3;

x2 = 110.1;

y2 = 120.2;

z2 = 130.3;



myPoint1 = Point.ByCoordinates(x1, y1, z1);

myPoint2 = Point.ByCoordinates(x2, y2, z2);



myLine = Line.ByStartPointEndPoint(myPoint1, myPoint2);



startPt = myLine.StartPoint;

endPt = myLine.EndPoint;



startPtX = startPt.X;

startPtY = startPt.Y;

startPtZ = startPt.Z;

endPtX = endPt.X;

endPtY = endPt.Y;

endPtZ = endPt.Z;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT008_FFI_Transform_ByDate_Simple()
        {
            string code = @"
class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double (other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 : double[] () 

    { 

        return = {X, Y, Z, H };

    }

}

class Vector

{

    X : var;

    Y : var;

    Z : var;

    

    public constructor ByCoordinates(xx : double, yy : double, zz : double)

    {

        X = xx;

        Y = yy;

        Z = zz;

    }

}



class Transform

{

    public C0 : Tuple4; 

    public C1 : Tuple4; 

    public C2 : Tuple4; 

    public C3 : Tuple4;     

    

    public constructor ByTuples(C0Value : Tuple4, C1Value : Tuple4, C2Value : Tuple4, C3Value : Tuple4)

    {

        C0 = C0Value;

        C1 = C1Value;

        C2 = C2Value;

        C3 = C3Value;

    }



    public constructor ByData(data : double[][])

    {

        C0 = Tuple4.ByCoordinates4(data[0]);

        C1 = Tuple4.ByCoordinates4(data[1]);

        C2 = Tuple4.ByCoordinates4(data[2]);

        C3 = Tuple4.ByCoordinates4(data[3]);

    }

    

    public def ApplyTransform : Tuple4 (t : Tuple4)

    {

        tx = Tuple4.XYZH(C0.X, C1.X, C2.X, C3.X);

        RX = tx.Multiply(t);



        ty = Tuple4.XYZH(C0.Y, C1.Y, C2.Y, C3.Y);

        RY = ty.Multiply(t);



        tz = Tuple4.XYZH(C0.Z, C1.Z, C2.Z, C3.Z);

        RZ = tz.Multiply(t);



        th = Tuple4.XYZH(C0.H, C1.H, C2.H, C3.H);

        RH = th.Multiply(t);

        

        return = Tuple4.XYZH(RX, RY, RZ, RH);

    }

    

    public def TransformVector : Vector (p: Vector)

    {    

        tpa = Tuple4.XYZH(p.X, p.Y, p.Z, 0.0);

        tpcv = ApplyTransform(tpa);

        return = Vector.ByCoordinates(tpcv.X, tpcv.Y, tpcv.Z);    

    }

}



data = {    {1.0,0.0,0.0,0.0},

            {0.0,1.0,0.0,0.0},

            {0.0,0.0,1.0,0.0},

            {0.0,0.0,0.0,1.0}

        };

        

xform = Transform.ByData(data);

c0 = xform.C0;

c1 = xform.C1;

c2 = xform.C2;

c3 = xform.C3;

c0_X = c0.X;

c0_Y = c0.Y;

c0_Z = c0.Z;

c0_H = c0.H;



c1_X = c1.X;

c1_Y = c1.Y;

c1_Z = c1.Z;

c1_H = c1.H;



c2_X = c2.X;

c2_Y = c2.Y;

c2_Z = c2.Z;

c2_H = c2.H;



c3_X = c3.X;

c3_Y = c3.Y;

c3_Z = c3.Z;

c3_H = c3.H;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT008_Inline_Returing_Different_Ranks__2_()
        {
            string code = @"


	a = { 0, 1, 2, 4};

	x = a > 1 ? 0 : {1,1}; // { 1, 1} ? 



	x_0 = x[0];

	x_1 = x[1];

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT008_Inline_Returing_Different_Ranks()
        {
            string code = @"
[Imperative]

{

	a = { 0, 1, 2, 4};

	x = a > 1 ? 0 : {1,1}; // { 1, 1} ? 



	x_0 = x[0];

	x_1 = x[1];

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT008_LanguageBlockScope_ImperativeParallelAssociative()
        {
            string code = @"
[Imperative]

{

	a = 10;

	b = true;

	c = 20.1;

}



[Associative]	

{

	aA = a;

	bA = b;

	cA = c;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT008_SomeNulls_Replication()
        {
            string code = @"
/*

[Imerative]

{

	a = 1..5;

	i = 0..3;

	x = a[i];

}

*/



a = {

{{null, 1},1},

{null},

{1,2,false}

};

i = 0..2;



j = 0;

[Imperative]

{

		if(SomeNulls(a[i]))

		{

			j = j+1;

		}

		

} 





//Note : the following works fine : 

/*

[Imperative]

{

	for ( x in  i) 

	{		

	    if(SomeNulls(a[x]))

	    {

                j = j+1;

	    }

	}

}

*/
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT008_Update_Of_Variables()
        {
            string code = @"
class A 

{

    a : var;

	constructor A ( )

	{

	    a = 5;

	}

}



a = 1;

b = a + 1;

a = 2;



t1 = { 1, 2 };

t2 = t1 [0] + 1;

t1 = 5.5;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT008_long_hand_surface_trim_Robert()
        {
            string code = @"
class BSplineSurface

{

    x : double;

	constructor ByControlVertices( a : double)

	{

	    x = a;

	}

	def Trim ( a1 : BSplineSurface, p1 : Point )

	{

	    temp = a1.x + p1.x;

		n1 = BSplineSurface.ByControlVertices( temp);

		return = n1;

	}

	def AtParameter ( x1 : double, y1 : double )

	{

	    temp = x + x1 + y1;

		n1 = Point.ByCartesianCoordinates ( temp );

		return = n1;

	}

}

class Point

{

    x : double;

	constructor ByCartesianCoordinates( a : double)

	{

	    x = a;

	}	

}

a = 1;

b = 2;



//initialSurface = BSplineSurface.ByControlVertices ( a ) => mySurface@initial // built with some 2D array of points

initialSurface = BSplineSurface.ByControlVertices ( a );



mySurface@initial = initialSurface;



cuttingSurface = BSplineSurface.ByControlVertices ( b );          // built with another 2D array of points



samplePoint    = mySurface@initial.AtParameter( 0.5, 0.5 );    // built using the initialSurface



trimmedSurface = initialSurface.Trim(cuttingSurface, samplePoint) ;  // now use the samplePoint in the triming

                                                                    // but create a new variable..trimmedSurface

test = trimmedSurface.x;

";
            //Assert.Fail("");
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT009_Associative_Class_Property_AssignInDifferentNamedConstructors()
        {
            string code = @"


	class MyPoint

	{

		X : double;

		Y : double;

		Z : double;

                            

        constructor ByXY (x : double, y : double)

        {

			X = x;

			Y = y;

			Z = 0.0;

        }

		

		constructor ByXZ (x : double, z : double)

        {

			X = x;

			Y = 0.0;

			Z = z;

        }

		

		constructor ByYZ (y : double, z : double)

        {

			X = 0.0;

			Y = y;

			Z = z;

        }

    }



    pt1 = MyPoint.ByXY (10.1, 200.2);

	pt2 = MyPoint.ByXZ (10.1, 3000.3);	

	pt3 = MyPoint.ByYZ (200.2,3000.3);

	

	xPt1 = pt1.X;

	yPt1 = pt1.Y;	

	zPt1 = pt1.Z;

	

	xPt2 = pt2.X;	

	yPt2 = pt2.Y;	

	zPt2 = pt2.Z;

	

	xPt3 = pt3.X;	

	yPt3 = pt3.Y;	

	zPt3 = pt3.Z;		









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT009_Associative_Function_DeclareVariableInsideFunction()
        {
            string code = @"
[Associative]

{



	def Foo : int(input : int)

	{

		multiply = 5;

		divide = 10;

	

		return = {input*multiply, input/divide};

	}

	

	input = 20;

	sum = Foo (input);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT009_BasicImport_TestClassInstanceMethod()
        {
            string code = @"
import (""basicImport.ds"");

x = 10.1;

y = 20.2;

z = 30.3;



myPoint = Point.ByCoordinates(10.1, 20.2, 30.3);



midValue = myPoint.MidValue();
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT009_FFI_Transform_ByTuples_Simple()
        {
            string code = @"
class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double (other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 : double[] () 

    { 

        return = {X, Y, Z, H };

    }

}

class Vector

{

    X : var;

    Y : var;

    Z : var;

    

    public constructor ByCoordinates(xx : double, yy : double, zz : double)

    {

        X = xx;

        Y = yy;

        Z = zz;

    }

}



class Transform

{

    public C0 : Tuple4; 

    public C1 : Tuple4; 

    public C2 : Tuple4; 

    public C3 : Tuple4;     

    

    public constructor ByTuples(C0Value : Tuple4, C1Value : Tuple4, C2Value : Tuple4, C3Value : Tuple4)

    {

        C0 = C0Value;

        C1 = C1Value;

        C2 = C2Value;

        C3 = C3Value;

    }



    public constructor ByData(data : double[][])

    {

        C0 = Tuple4.ByCoordinates4(data[0]);

        C1 = Tuple4.ByCoordinates4(data[1]);

        C2 = Tuple4.ByCoordinates4(data[2]);

        C3 = Tuple4.ByCoordinates4(data[3]);

    }

    

    public def ApplyTransform : Tuple4 (t : Tuple4)

    {

        tx = Tuple4.XYZH(C0.X, C1.X, C2.X, C3.X);

        RX = tx.Multiply(t);



        ty = Tuple4.XYZH(C0.Y, C1.Y, C2.Y, C3.Y);

        RY = ty.Multiply(t);



        tz = Tuple4.XYZH(C0.Z, C1.Z, C2.Z, C3.Z);

        RZ = tz.Multiply(t);



        th = Tuple4.XYZH(C0.H, C1.H, C2.H, C3.H);

        RH = th.Multiply(t);

        

        return = Tuple4.XYZH(RX, RY, RZ, RH);

    }

    

    public def TransformVector : Vector (p: Vector)

    {    

        tpa = Tuple4.XYZH(p.X, p.Y, p.Z, 0.0);

        tpcv = ApplyTransform(tpa);

        return = Vector.ByCoordinates(tpcv.X, tpcv.Y, tpcv.Z);    

    }

}



data = {    {1.0,0.0,0.0,0.0},

            {0.0,1.0,0.0,0.0},

            {0.0,0.0,1.0,0.0},

            {0.0,0.0,0.0,1.0}

        };

        



t0 = Tuple4.ByCoordinates4(data[0]);

t1 = Tuple4.ByCoordinates4(data[1]);

t2 = Tuple4.ByCoordinates4(data[2]);

t3 = Tuple4.ByCoordinates4(data[3]);



xform = Transform.ByTuples(t0, t1, t2, t3);

c0 = xform.C0;

c1 = xform.C1;

c2 = xform.C2;

c3 = xform.C3;

c0_X = c0.X;

c0_Y = c0.Y;

c0_Z = c0.Z;

c0_H = c0.H;



c1_X = c1.X;

c1_Y = c1.Y;

c1_Z = c1.Z;

c1_H = c1.H;



c2_X = c2.X;

c2_Y = c2.Y;

c2_Z = c2.Z;

c2_H = c2.H;



c3_X = c3.X;

c3_Y = c3.Y;

c3_Z = c3.Z;

c3_H = c3.H;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT009_Inline_Using_Function_Call_And_Collection_And_Replication__2_()
        {
            string code = @"


	def even(a : int)

	{

		return = a * 2;

	}



	def odd(a : int ) 

	{

	return = a* 2 + 1;

	}



	x = 1..3;



	a = ((even(5) > odd(3)))? even(5) : even(3); //10

	b = ((even(x) > odd(x+1)))?odd(x+1):even(x) ; // {2,4,6}

	c = odd(even(3)); // 13

	d = ((a > c))?even(odd(c)) : odd(even(c)); //53





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT009_Inline_Using_Function_Call_And_Collection_And_Replication()
        {
            string code = @"
[Imperative]

{

	def even(a : int)

	{

		return = a * 2;

	}



	def odd(a : int ) 

	{

	return = a* 2 + 1;

	}



	x = 1..3;



	a = ((even(5) > odd(3)))? even(5) : even(3); //10

	b = ((even(x) > odd(x+1)))?odd(x+1):even(x) ; // {2,4,6}

	c = odd(even(3)); // 13

	d = ((a > c))?even(odd(c)) : odd(even(c)); //53

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT009_LanguageBlockScope_UpdateVariableInNestedLanguageBlock_IA()
        {
            string code = @"
[Imperative]

{

	a = -10;

	b = false;

	c = -20.1;

	[Associative]	

	{

		a = 1.5;

		b = -4;

		c = false;

	}

	

	newA = a;

	newB = b;

	newC = c;



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT009_SomeNulls_DynamicArray()
        {
            string code = @"
result = 

[Imperative]

{



	a1 = {

	{{null},{}},

	{1,2,4},

	{@a,@b,@null},//{null,null,null}

	{null}

	};

	a2 = {};



	i = 0;

	j = 0; 

	while(i < Count(a1))

	{

		if(SomeNulls(a1[i]))

		{

			a2[j] = a1[i];

			j = j+1;

			

		}

		i = i+1;

	}

	return = Count(a2);

} 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT009_Update_Of_Undefined_Variables()
        {
            string code = @"
u1 = u2;

u2 = 3;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT009_modifier_test_1_Robert()
        {
            string code = @"
x = {10,20};

x[0] = x[0] +1;     // this works x = {11, 20}



// now let's try the same type of construct using the modifier block syntax

y = { 

        {50, 60} ;   // initial definition

         + 1 ;       // is this the correct syntax for modifying all members of a collection

         y[0] + 1 ;  // is this the correct syntax for modifying   a member  of a collection

    }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT010_Associative_Class_Constructor_Overloads()
        {
            string code = @"


	class MyPoint

	{

		X : double;

		Y : double;

		Z : double;

                            

        constructor Create (x : double, y : double, flag: bool)

        {

			X = x;

			Y = y;

			Z = 3000.1;

        }

		

		constructor Create (x : double, y : double)

        {

			X = x;

			Y = y;

			Z = 0.1;

        }



		

    }



    pt1 = MyPoint.Create (10.0,200.0);

	pt2 = MyPoint.Create (10.0,200.0, true);

	pt3 = MyPoint.Create (10.0,200.0, false);



	zPt1 = pt1.Z;

	zPt2 = pt2.Z;

	zPt3 = pt3.Z;

	









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT010_Associative_Function_PassAndReturnBooleanValue()
        {
            string code = @"
[Associative]

{



	def Foo : bool (input : bool)

	{



		return = input;

	}

	

	input = false;

	result1 = Foo (input);

	result2 = Foo (true);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT010_BaseImportWithVariableClassInstance_top()
        {
            string code = @"
import (""BaseImportWithVariableClassInstance.ds"");

c = a + b;

myPointX = myPoint.X;

arr = Scale(midValue, 4.0);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT010_Defect_1456751_execution_on_both_true_and_false_path_issue()
        {
            string code = @"


a = 0;

def foo ( )

{

    a = a + 1;

    return = a;

}



x = 1 > 2 ? foo() + 1 : foo() + 2;



	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT010_Defect_1456751_replication_issue()
        {
            string code = @"
[Imperative]

{

	a = { 0, 1, 2};

	b = { 3, 11 };

	c = 5;

	d = { 6, 7, 8, 9};

	e = { 10 };



	xx = 1 < a ? a : 5;

        yy = 0;

	if( 1 < a )

	    yy = a;

	else

	    yy = 5;

	x1 = a < 5 ? b : 5;

	t1 = x1[0];

	t2 = x1[1];

	c1 = 0;

	for (i in x1)

	{

		c1 = c1 + 1;

	}



	x2 = 5 > b ? b : 5;

	t3 = x2[0];

	t4 = x2[1];

	c2 = 0;

	for (i in x2)

	{

		c2 = c2 + 1;

	}



	x3 = b < d ? b : e;

	t5 = x3[0];

	c3 = 0;

	for (i in x3)

	{

		c3 = c3 + 1;

	}



	x4 = b > e ? d : { 0, 1};

	t7 = x4[0]; 

	c4 = 0;

	for (i in x4)

	{

		c4 = c4 + 1;

	}

}



/*

Expected : 

result1 = { 5, 5, 2 };

thisTest.Verification(mirror, ""xx"", result1, 1);





thisTest.Verification(mirror, ""t1"", 3, 1);

thisTest.Verification(mirror, ""t2"", 11, 1);

thisTest.Verification(mirror, ""c1"", 2, 1);



thisTest.Verification(mirror, ""t3"", 3, 1);

thisTest.Verification(mirror, ""t4"", 5, 1);

thisTest.Verification(mirror, ""c2"", 2, 1);



thisTest.Verification(mirror, ""t5"", 3, 1); 

thisTest.Verification(mirror, ""c3"", 1, 1);



thisTest.Verification(mirror, ""t7"", 0, 1);

thisTest.Verification(mirror, ""c4"", 1, 1);*/
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT010_FFI_Transform_ApplyTransform()
        {
            string code = @"
class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double (other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 : double[] () 

    { 

        return = {X, Y, Z, H };

    }

}

/*

t1 = Tuple4.XYZH(0,0,0,0);

t2 = Tuple4.XYZ(0,0,0);

t3 = Tuple4.ByCoordinates3({0.0,0,0});

t4 = Tuple4.ByCoordinates4({0.0,0,0,0});

mult = t1.Multiply(t2);



c3 = t3.Coordinates3();

c4 = t3.Coordinates4();

*/

class Vector

{

    X : var;

    Y : var;

    Z : var;

    

    public constructor ByCoordinates(xx : double, yy : double, zz : double)

    {

        X = xx;

        Y = yy;

        Z = zz;

    }

}



class Transform

{

    public C0 : Tuple4; 

    public C1 : Tuple4; 

    public C2 : Tuple4; 

    public C3 : Tuple4;     

    

    public constructor ByTuples(C0Value : Tuple4, C1Value : Tuple4, C2Value : Tuple4, C3Value : Tuple4)

    {

        C0 = C0Value;

        C1 = C1Value;

        C2 = C2Value;

        C3 = C3Value;

    }



    public constructor ByData(data : double[][])

    {

        C0 = Tuple4.ByCoordinates4(data[0]);

        C1 = Tuple4.ByCoordinates4(data[1]);

        C2 = Tuple4.ByCoordinates4(data[2]);

        C3 = Tuple4.ByCoordinates4(data[3]);

    }

    

    public def ApplyTransform : Tuple4 (t : Tuple4)

    {

        tx = Tuple4.XYZH(C0.X, C1.X, C2.X, C3.X);

        RX = tx.Multiply(t);



        ty = Tuple4.XYZH(C0.Y, C1.Y, C2.Y, C3.Y);

        RY = ty.Multiply(t);



        tz = Tuple4.XYZH(C0.Z, C1.Z, C2.Z, C3.Z);

        RZ = tz.Multiply(t);



        th = Tuple4.XYZH(C0.H, C1.H, C2.H, C3.H);

        RH = th.Multiply(t);

        

        return = Tuple4.XYZH(RX, RY, RZ, RH);

    }

	

    public def NativeMultiply : Transform(other : Transform)

    {              

        tc0 = ApplyTransform(other.C0);

        tc1 = ApplyTransform(other.C1);

        tc2 = ApplyTransform(other.C2);

        tc3 = ApplyTransform(other.C3);

        return = Transform.ByTuples(tc0, tc1, tc2, tc3);

    }

    

    public def NativePreMultiply : Transform (other : Transform)

    {     

        //  as we don't have this now let's do it longer way!        

        //return = other.NativeMultiply(this);

        //

        tc0 = other.ApplyTransform(C0);

        tc1 = other.ApplyTransform(C1);

        tc2 = other.ApplyTransform(C2);

        tc3 = other.ApplyTransform(C3);

        return = Transform.ByTuples(tc0, tc1, tc2, tc3);

    }

    

}



data = {    {2.0,0.0,0.0,0.0},

            {0.0,2.0,0.0,0.0},

            {0.0,0.0,2.0,0.0},

            {0.0,0.0,0.0,2.0}

        };

        

  

        

xform = Transform.ByData(data);



tuple = Tuple4.XYZH(0.1,2,4,1);



result = xform.ApplyTransform(tuple);

x = result.X;

y = result.Y;

z = result.Z;

h = result.H;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT010_Inline_Using_Literal_Values()
        {
            string code = @"
[Imperative]

{

	a = 1 > 2.5 ? false: 1;

	b = 0.55 == 1 ? true : false;

	c = (( 1 + 0.5 ) / 2 ) <= (200/10) ? (8/2) : (6/3);

	d = true ? true : false;

	e = false ? true : false;

	f = true == true ? 1 : 0.5;

	g = (1/3.0) > 0 ? (1/3.0) : (4/3);

	h = (1/3.0) < 0 ? (1/3.0) : (4/3);

}













";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT010_LanguageBlockScope_UpdateVariableInNestedLanguageBlock_AI()
        {
            string code = @"
[Associative]

{

	a = -10;

	b = false;

	c = -20.1;

	[Imperative]	

	{

		a = 1.5;

		b = -4;

		c = false;

	}

	

	newA = a;

	newB = b;

	newC = c;



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT010_SomeNulls_AssociativeImperative_01()
        {
            string code = @"
[Imperative]

{

	a = {1,2,null};

	b = {null, null};

	

	[Associative]

	{

		a = {1};

		b = a;

		m = SomeNulls(b);

		a = {1,null,{}};

		n = m;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test, Ignore]
        public void DebugEQT010_SomeNulls_AssociativeImperative_02()
        {
            string code = @"
[Imperative]

{

	a = {false};

	if(!SomeNulls(a))

	{

	[Associative]

	{

		

		b = a;

		a = {null};

		

		m = SomeNulls(b);//true,false

		[Imperative]

		{

			c = a;

			a = {2};

			n = SomeNulls(c);//true

		}

		

	}

	}else

	{

	m = false;

	n = false;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT010_SomeNulls_AssociativeImperative_03()
        {
            string code = @"


	

	a = {{}};

	b = a;

	

	m = SomeNulls(b);//false

	[Imperative]

	{

		c = a;

		a = {null,{}};

		m = SomeNulls(c);//false

	}

	a = {null};

	n = SomeNulls(b);//true;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT010_Update_Of_Singleton_To_Collection()
        {
            string code = @"
s1 = 3;

s2 = s1 -1;

s1 = { 3, 4 } ;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT010_imperative_if_inside_for_loop_1_Robert()
        {
            string code = @"
[Imperative]

{

	x = 0;

	

	for ( i in 1..10..2)

	{

		x = i;

		if(i>5) x = i*2; // tis is ignored

		// if(i<5) x = i*2; // this causes a crash

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT011_Associative_Class_Property_ExtendedClass()
        {
            string code = @"
class MyPoint

	{

		X : double;

		Y : double;

		Z : double;

                            

        constructor ByXYZ (x : double, y : double, z: double)

        {

			X = x;

			Y = y;

			Z = z;

        }

	

    }

	

	class MyExtendedPoint extends MyPoint

	{

		constructor ByX (x : double)	

		{

			X = x;

			Y = 20.2;

			Z = 300.3;

		}

	}



[Associative]

{



   

    pt1 = MyExtendedPoint.ByX (10.1);



	xPt1 = pt1.X;

	yPt1 = pt1.Y;

	zPt1 = pt1.Z;





}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT011_Associative_Function_FunctionWithoutArgument()
        {
            string code = @"
[Associative]

{



	def Foo1 : int ()

	{



		return = 5;

	}

	



	result1 = Foo1 ();

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT011_Cyclic_Dependency_From_Geometry()
        {
            string code = @"
import(""GeometryLibForLanguageTesting.ds"");



pt1a = Point.ByCartesianCoordinates( 0,0,0);

pt2a = Point.ByCartesianCoordinates( 5,0,0);



testBSNP = BSplineCurve.ByPoints({pt1a,pt2a});



testCurves = {testBSNP } ;//testArc, testCircle};



surfaceLine = Line.ByStartPointEndPoint(Point.ByCartesianCoordinates(-30,60,-30),Point.ByCartesianCoordinates(-30,-20,-30));

surfLength = 60;

surf = surfaceLine.ExtrudeAsSurface(surfLength,Vector.ByCoordinates(1.0, 0.0, 0.0));

projectVector = Vector.ByCoordinates(0,0,-1);

projectedCurve = testCurves.Project(surf,projectVector); //V0

test = projectedCurve.P1[0].X;

surfLength = 35; 

projectVector = Vector.ByCoordinates(5.0,0,-1);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT011_Defect_1467281_conditionals()
        {
            string code = @"
 x = 2 == { }; 

 y = {}==null;

 z = {{1}}=={1};

 z2 = {{1}}==1;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT011_Defect_ModifierStack()
        {
            string code = @"
a = 

{

	m =>a1;

	""n"" => a2;

	x + y =>a3;

	true => a4;

	&& 0 =>a5;	

}

result = {a1,a2,a3,a4,a5};

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT011_FFI_Transform_NativeMultiply()
        {
            string code = @"


class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double (other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 : double[] () 

    { 

        return = {X, Y, Z, H };

    }

}



class Vector

{

    X : var;

    Y : var;

    Z : var;

    

    public constructor ByCoordinates(xx : double, yy : double, zz : double)

    {

        X = xx;

        Y = yy;

        Z = zz;

    }

}



class Transform

{

    public C0 : Tuple4; 

    public C1 : Tuple4; 

    public C2 : Tuple4; 

    public C3 : Tuple4;     

    

    public constructor ByTuples(C0Value : Tuple4, C1Value : Tuple4, C2Value : Tuple4, C3Value : Tuple4)

    {

        C0 = C0Value;

        C1 = C1Value;

        C2 = C2Value;

        C3 = C3Value;

    }



    public constructor ByData(data : double[][])

    {

        C0 = Tuple4.ByCoordinates4(data[0]);

        C1 = Tuple4.ByCoordinates4(data[1]);

        C2 = Tuple4.ByCoordinates4(data[2]);

        C3 = Tuple4.ByCoordinates4(data[3]);

    }

    

    public def ApplyTransform : Tuple4 (t : Tuple4)

    {

        tx = Tuple4.XYZH(C0.X, C1.X, C2.X, C3.X);

        RX = tx.Multiply(t);



        ty = Tuple4.XYZH(C0.Y, C1.Y, C2.Y, C3.Y);

        RY = ty.Multiply(t);



        tz = Tuple4.XYZH(C0.Z, C1.Z, C2.Z, C3.Z);

        RZ = tz.Multiply(t);



        th = Tuple4.XYZH(C0.H, C1.H, C2.H, C3.H);

        RH = th.Multiply(t);

        

        return = Tuple4.XYZH(RX, RY, RZ, RH);

    }

	

    public def NativeMultiply : Transform(other : Transform)

    {              

        tc0 = ApplyTransform(other.C0);

        tc1 = ApplyTransform(other.C1);

        tc2 = ApplyTransform(other.C2);

        tc3 = ApplyTransform(other.C3);

        return = Transform.ByTuples(tc0, tc1, tc2, tc3);

    }

    

    public def NativePreMultiply : Transform (other : Transform)

    {     

        //  as we don't have this now let's do it longer way!        

        //return = other.NativeMultiply(this);

        //

        tc0 = other.ApplyTransform(C0);

        tc1 = other.ApplyTransform(C1);

        tc2 = other.ApplyTransform(C2);

        tc3 = other.ApplyTransform(C3);

        return = Transform.ByTuples(tc0, tc1, tc2, tc3);

    }

    

}



data1 = {    {2.0,0.0,0.0,0.0},

            {0.0,2.0,0.0,0.0},

            {0.0,0.0,2.0,0.0},

            {0.0,0.0,0.0,2.0}

        };

data2 = {    {0.0,3.0,0.0,0.0},

            {0.0,2.0,0.0,0.0},

            {1.0,0.0,2.0,0.0},

            {0.5,0.0,0.0,2.0}

        };        

  

        

xform1 = Transform.ByData(data1);

xform2 = Transform.ByData(data2);



result = xform1.NativeMultiply(xform2);

r0 = result.C0;

r1 = result.C1;

r2 = result.C2;

r3 = result.C3;

r0X = r0.X;

r0Y = r0.Y;

r0Z = r0.Z;

r0H = r0.H;

r1X = r1.X;

r1Y = r1.Y;

r1Z = r1.Z;

r1H = r1.H;

r2X = r2.X;

r2Y = r2.Y;

r2Z = r2.Z;

r2H = r2.H;

r3X = r3.X;

r3Y = r3.Y;

r3Z = r3.Z;

r3H = r3.H;









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT011_Inline_Using_Variables()
        {
            string code = @"
class A

{

    a : var;

	constructor A ( i : int)

	{

	    a = i;

	}

}

[Imperative]

{

	a = 1;

	b = 0.5;

	c = -1;

	d = true;

	f = null;

	g = false;

	h = A.A(1);

	i = h.a;

	

	x1 = a > b ? c : d;

	x2 = a <= b ? c : d;

	

	x3 = f == g ? h : i;

	x4 = f != g ? h : i;

    x5 = f != g ? h : h.a;	

	

	temp = x3.a;

}













";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT011_LanguageBlockScope_AssociativeParallelAssociative()
        {
            string code = @"
[Associative]

{

	a = 10;

	b = true;

	c = 20.1;

	

}



[Associative]	

{

	aA = a;

	bA = b;

	cA = c;

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT011_SomeNulls_ModifierStack()
        {
            string code = @"
arr = {1};



a = {

	arr => a1; //{1,null}

	SomeNulls(a1) => a2;//true

	!a2 => a3;//false

	

	m => a4;//{1,null}

	SomeNulls({a4}) => a5;//true

	}

	

	arr[1] = null ;

	m = arr;

	

	result = {a1,a2,a3,a4,a5};

	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT011_Update_Of_Variable_To_Null()
        {
            string code = @"
x = 1;

y = 2/x;

x = 0;



v1 = 2;

v2 = v1 * 3;

v1 = null;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT012_Associative_Class_Property_Var()
        {
            string code = @"


	class Point

	{

        _x : var;

        _y : var;

        _z : var;

                                

        constructor Create(xx : int, yy : double, zz : bool)

        {

			_x = xx;

            _y = yy;

            _z = zz;

        }

                                

	}

	newPoint = Point.Create(1, 2.0, true);

	

	xPoint = newPoint._x;

    yPoint = newPoint._y;            

    zPoint = newPoint._z;               









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT012_Associative_Function_MultipleFunctions()
        {
            string code = @"
[Associative]

{



	def Foo1 : int ()

	{



		return = 5;

	}

	

	

	def Foo2 : int ()

	{



		return = 6;

	}

	

	

	result1 = Foo1 ();

	result2 = Foo2 ();

	

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT012_BaseImportImperative()
        {
            string code = @"
import (""BaseImportImperative.ds"");

a = 1;

b = a;

[Associative]

{

	c = 3 * b;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT012_CountTrue_IfElse()
        {
            string code = @"
result =

[Imperative]

{

	arr1 = {true,{{{{true}}}},null};

	arr2 = {{true},{false},null};

	if(CountTrue(arr1) > 1)

	{

		arr2 = arr1;

	}

	return = CountTrue(arr2);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT012_FFI_Transform_NativePreMultiply()
        {
            string code = @"


class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double (other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 : double[] () 

    { 

        return = {X, Y, Z, H };

    }

}



class Vector

{

    X : var;

    Y : var;

    Z : var;

    

    public constructor ByCoordinates(xx : double, yy : double, zz : double)

    {

        X = xx;

        Y = yy;

        Z = zz;

    }

}



class Transform

{

    public C0 : Tuple4; 

    public C1 : Tuple4; 

    public C2 : Tuple4; 

    public C3 : Tuple4;     

    

    public constructor ByTuples(C0Value : Tuple4, C1Value : Tuple4, C2Value : Tuple4, C3Value : Tuple4)

    {

        C0 = C0Value;

        C1 = C1Value;

        C2 = C2Value;

        C3 = C3Value;

    }



    public constructor ByData(data : double[][])

    {

        C0 = Tuple4.ByCoordinates4(data[0]);

        C1 = Tuple4.ByCoordinates4(data[1]);

        C2 = Tuple4.ByCoordinates4(data[2]);

        C3 = Tuple4.ByCoordinates4(data[3]);

    }

    

    public def ApplyTransform : Tuple4 (t : Tuple4)

    {

        tx = Tuple4.XYZH(C0.X, C1.X, C2.X, C3.X);

        RX = tx.Multiply(t);



        ty = Tuple4.XYZH(C0.Y, C1.Y, C2.Y, C3.Y);

        RY = ty.Multiply(t);



        tz = Tuple4.XYZH(C0.Z, C1.Z, C2.Z, C3.Z);

        RZ = tz.Multiply(t);



        th = Tuple4.XYZH(C0.H, C1.H, C2.H, C3.H);

        RH = th.Multiply(t);

        

        return = Tuple4.XYZH(RX, RY, RZ, RH);

    }

	

    public def NativeMultiply : Transform(other : Transform)

    {              

        tc0 = ApplyTransform(other.C0);

        tc1 = ApplyTransform(other.C1);

        tc2 = ApplyTransform(other.C2);

        tc3 = ApplyTransform(other.C3);

        return = Transform.ByTuples(tc0, tc1, tc2, tc3);

    }

    

    public def NativePreMultiply : Transform (other : Transform)

    {     

        //  as we don't have this now let's do it longer way!        

        //return = other.NativeMultiply(this);

        //

        tc0 = other.ApplyTransform(C0);

        tc1 = other.ApplyTransform(C1);

        tc2 = other.ApplyTransform(C2);

        tc3 = other.ApplyTransform(C3);

        return = Transform.ByTuples(tc0, tc1, tc2, tc3);

    }

    

}



data1 = {    {2.0,0.0,0.0,0.0},

            {0.0,2.0,0.0,0.0},

            {0.0,0.0,2.0,0.0},

            {0.0,0.0,3.0,3.0}

        };

data2 = {    {0.0,3.0,0.0,0.0},

            {0.0,2.0,0.0,0.0},

            {1.0,0.0,2.0,0.0},

            {0.5,0.0,0.0,2.0}

        };        

  

        

xform1 = Transform.ByData(data1);

xform2 = Transform.ByData(data2);



result = xform1.NativePreMultiply(xform2);

r0 = result.C0;

r1 = result.C1;

r2 = result.C2;

r3 = result.C3;

r0X = r0.X;

r0Y = r0.Y;

r0Z = r0.Z;

r0H = r0.H;

r1X = r1.X;

r1Y = r1.Y;

r1Z = r1.Z;

r1H = r1.H;

r2X = r2.X;

r2Y = r2.Y;

r2Z = r2.Z;

r2H = r2.H;

r3X = r3.X;

r3Y = r3.Y;

r3Z = r3.Z;

r3H = r3.H;









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT012_Inline_Using_Fun_Calls()
        {
            string code = @"
class A

{

    a : var;

	constructor A ( i : int)

	{

	    a = i;

	}

}



def power ( a )

{

    return = a * a ;

}



a = power(1);

b = power(0.5);

c = -1;

d = true;

f = null;

g = false;

h = A.A(1);

i = h.a;



x1 = power(power(2)) > power(2) ? power(1) : power(0);

x2 = power(power(2)) < power(2) ? power(1) : power(0);

x3 = power(c) < b ? power(1) : power(0);

x4 = power(f) >= power(1) ? power(1) : power(0);

x5 = power(f) < power(1) ? power(1) : power(0);

x6 = power(i) >= power(h.a) ? power(1) : power(0);

x7 = power(f) >= power(i) ? power(1) : power(0);















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT012_LanguageBlockScope_ImperativeParallelImperative()
        {
            string code = @"
[Imperative]

{

	a = 10;

	b = true;

	c = 20.1;

	

}



[Imperative]	

{

	aI = a;

	bI = b;

	cI = c;

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT012_Update_Of_Variables_To_Bool()
        {
            string code = @"
p1 = 1;

p2 = p1 * 2;

p1 = false;



q1 = -3.5;

q2 = q1 * 2;

q1 = true;



s1 = 1.0;

s2 = s1 * 2;

s1 = false;



t1 = -1;

t2 = t1 * 2;

t1 = true;



r1 = 1;

r2 = r1 * 2;

r1 = true;







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT012_property_test_on_collections_2_Robert()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");



line1 = Line.ByStartPointEndPoint(Point.ByCartesianCoordinates(5.0 , 5.0, 0.0), Point.ByCartesianCoordinates(10.0 , 5.0, 0.0));



line2 = Line.ByStartPointEndPoint(Point.ByCartesianCoordinates(5.0 , {7.5, 10.0}, 0.0), Point.ByCartesianCoordinates(10.0 ,10.0, 0.0));





line1.Color = 0.0;

t1= line1.Color;



line2.Color = 1.0; // can't assign to a writable property if it is collection.. is this a replication issue?

t2= line2.Color;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT013_Associative_Class_Property_GetFromAnotherConstructorInSameClass()
        {
            string code = @"


	class TestPoint

	{

        _x : var;

        _y : var;

        _z : var;

                                

        constructor Create(xx : int, yy : int, zz : int)

        {

			_x = xx; 

            _y = yy;

            _z = zz;

        }

		

		constructor Modify(oldPoint : TestPoint)

		

		{

		

		    _x = oldPoint._x +1;

			_y = oldPoint._y +1;

			_z = oldPoint._z +1;

		

		

		}

                                

	}

	oldPoint = TestPoint.Create(1, 2, 3);

	newPoint = TestPoint.Modify(oldPoint);

	xPoint = newPoint._x;

    yPoint = newPoint._y;            

    zPoint = newPoint._z;               









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT013_Associative_Function_FunctionWithSameName_Negative()
        {
            string code = @"
[Associative]

{



	def Foo1 : int ()

	{



		return = 5;

	}

	

	

	

	def Foo1 : int ()

	{



		return = 6;

	}

	

	

	

	result2 = Foo2 ();

	

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT013_BaseImportImperative_Bottom()
        {
            string code = @"
a =10;

b = 2 * a; 

import (""BaseImportImperative.ds"");
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT013_CountTrue_ForLoop()
        {
            string code = @"
result = 

[Imperative]

{

	a = {1,3,5,7,{}};

	b = {null,null,{1,true}};

	c = {CountTrue({1,null})};

	

	d = {a,b,c};

	j = 0;

	e = {};

	

	for(i in d)

	{

		e[j]= CountTrue(i);

		j = j+1;

	}

	return  = e;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT013_FFI_Transform_TransformVector()
        {
            string code = @"


class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double (other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 : double[] () 

    { 

        return = {X, Y, Z, H };

    }

}

/*

t1 = Tuple4.XYZH(0,0,0,0);

t2 = Tuple4.XYZ(0,0,0);

t3 = Tuple4.ByCoordinates3({0.0,0,0});

t4 = Tuple4.ByCoordinates4({0.0,0,0,0});

mult = t1.Multiply(t2);



c3 = t3.Coordinates3();

c4 = t3.Coordinates4();

*/

class Vector

{

    X : var;

    Y : var;

    Z : var;

    

    public constructor ByCoordinates(xx : double, yy : double, zz : double)

    {

        X = xx;

        Y = yy;

        Z = zz;

    }

}



class Transform

{

    public C0 : Tuple4; 

    public C1 : Tuple4; 

    public C2 : Tuple4; 

    public C3 : Tuple4;     

    

    public constructor ByTuples(C0Value : Tuple4, C1Value : Tuple4, C2Value : Tuple4, C3Value : Tuple4)

    {

        C0 = C0Value;

        C1 = C1Value;

        C2 = C2Value;

        C3 = C3Value;

    }



    public constructor ByData(data : double[][])

    {

        C0 = Tuple4.ByCoordinates4(data[0]);

        C1 = Tuple4.ByCoordinates4(data[1]);

        C2 = Tuple4.ByCoordinates4(data[2]);

        C3 = Tuple4.ByCoordinates4(data[3]);

    }

    

    public def ApplyTransform : Tuple4 (t : Tuple4)

    {

        tx = Tuple4.XYZH(C0.X, C1.X, C2.X, C3.X);

        RX = tx.Multiply(t);



        ty = Tuple4.XYZH(C0.Y, C1.Y, C2.Y, C3.Y);

        RY = ty.Multiply(t);



        tz = Tuple4.XYZH(C0.Z, C1.Z, C2.Z, C3.Z);

        RZ = tz.Multiply(t);



        th = Tuple4.XYZH(C0.H, C1.H, C2.H, C3.H);

        RH = th.Multiply(t);

        

        return = Tuple4.XYZH(RX, RY, RZ, RH);

    }

    

    public def TransformVector : Vector (p: Vector)

    {    

        tpa = Tuple4.XYZH(p.X, p.Y, p.Z, 0.0);

        tpcv = ApplyTransform(tpa);

        return = Vector.ByCoordinates(tpcv.X, tpcv.Y, tpcv.Z);    

    }

    



    public def NativeMultiply : Transform(other : Transform)

    {              

        tc0 = ApplyTransform(other.C0);

        tc1 = ApplyTransform(other.C1);

        tc2 = ApplyTransform(other.C2);

        tc3 = ApplyTransform(other.C3);

        return = Transform.ByTuples(tc0, tc1, tc2, tc3);

    }

    

    public def NativePreMultiply : Transform (other : Transform)

    {     

        //  as we don't have this now let's do it longer way!        

        //return = other.NativeMultiply(this);

        //

        tc0 = other.ApplyTransform(C0);

        tc1 = other.ApplyTransform(C1);

        tc2 = other.ApplyTransform(C2);

        tc3 = other.ApplyTransform(C3);

        return = Transform.ByTuples(tc0, tc1, tc2, tc3);

    }

    

}



data = {    {1.0,0.0,0.0,0.0},

            {0.0,2.0,0.0,0.0},

            {0.0,0.0,3.0,0.0},

            {0.0,0.0,0.0,4.0}

        };

   

xform = Transform.ByData(data);

testVector = Vector.ByCoordinates (10, 20, 30);

resultVector = xform.TransformVector (testVector);



x = testVector.X;

y = testVector.Y;

z = testVector.Z;



resultx = resultVector.X;

resulty = resultVector.Y;

resultz = resultVector.Z;







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT013_Inline_Using_Class()
        {
            string code = @"
class A

{

    a : var;

	constructor A ( i : int)

	{

	    a = i;

	}

	

	def foo ( b )

	{

		return = a * b ;

	}

	

}





def power ( a )

{

    return = a * a ;

}





a = A.A(-1);

b = A.A(0);

c = A.A(2);



x1 = a.a < a.foo(2) ? a.a : a.foo(2);

x2 = a.a >= a.foo(2) ? a.a : a.foo(2);



x3 = a.foo(power(3)) < power(b.foo(3)) ? a.foo(power(3)) : power(b.foo(3));

x4 = a.foo(power(3)) >= power(b.foo(3)) ? a.foo(power(3)) : power(b.foo(3));















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT013_LanguageBlockScope_MultipleParallelLanguageBlocks_AIA()
        {
            string code = @"
[Associative]

{

	a = 10;

	b = true;

	c = 20.1;

	

}



[Imperative]	

{

	aI = a;

	bI = b;

	cI = c;

	

}



[Associative]	

{

	aA = a;

	bA = b;

	cA = c;

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT013_Update_Of_Variables_To_User_Defined_Class()
        {
            string code = @"
class A 

{

    a : var;

	constructor A ( )

	{

	    a = 5;

	}

}



r1 = 2.0;

r2 = r1+1;

r1 = A.A();



t1 = { 1, 2 };

t2 = t1 [0] + 1;

t1 = A.A();



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT013_nested_programming_blocks_1_Robert()
        {
            string code = @"
import (""GeometryLibForLanguageTesting.ds"");



controlPoint = Point.ByCartesianCoordinates(0, 7.5, 0);



internalLine   = null; // define some variables

pointOnCurve  = null;

testLine       = null;

totalLength = 0;

i = 5;



[Imperative]

{

	while ( i <= 7 )//(totalLength < 5.0 ) 

	{

		[Associative] // within that loop build an associative model

		{

			startPoint   = Point.ByCartesianCoordinates(i, 5, 0);

			endPoint     = Point.ByCartesianCoordinates(5, 10, 0);

			internalLine = Line.ByStartPointEndPoint(startPoint, endPoint);

			pointOnCurve = internalLine.PointAtParameter(0.2..0.8..0.2);



			[Imperative] // within the associative model start some imperative scripting

			{

				for (j in 0..(Count(pointOnCurve)-1)) // iterate over the points

				{

					if(j%2==0) // consider every alternate point

					{

						pointOnCurve[j] = pointOnCurve[j].Translate(1,1,1); // actual : ( 0,0,1) modify by translation

					}

				}

			}

			// continue with more assocative modelling

			

			testLine     = Line.ByStartPointEndPoint(controlPoint, pointOnCurve);

			totalLength  = totalLength + Sum (testLine.Length);

		}

		i = i + 1; // increment i

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT014_Associative_Class_Property_GetUsingMultipleReferencingWithSameName()
        {
            string code = @"


	class TestPoint

	{

        X : var;

        Y : var;

             

        constructor Create(xx : int, yy : int)

        {

			X = xx; 

            Y = yy;



        }                            

	}

	

	class TestLine

	{

        X : TestPoint;

        Y : TestPoint;

             

        constructor Create(startPt : TestPoint, endPoint : TestPoint)

        {

			X = startPt; 

            Y = endPoint;

        }                            

	}



	

	

	

	pt1 = TestPoint.Create(1, 2);

	pt2 = TestPoint.Create(3, 4);

	line1 = TestLine.Create(pt1,pt2);

    test1 = line1.X.X;

    test2 = line1.X.Y;    

    test3 = line1.Y.X;

    test4 = line1.Y.Y; 









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT014_Associative_Function_DuplicateVariableAndFunctionName_Negative()
        {
            string code = @"
[Associative]

{



	def Foo : int ()

	{



		return = 4;

	}



	Foo = 5;

	

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT014_BasicImport_BeforeImperative()
        {
            string code = @"
import (""basicImport.ds"");

[Imperative]

{

	myPoint = Point.ByCoordinates(10.1, 20.2, 30.3);



	midValue = myPoint.MidValue();

	

	arr =  Scale(midValue, 4.0);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT014_CountTrue_WhileLoop()
        {
            string code = @"
result = 

[Imperative]

{

	a = {1,3,5,7,{1}};//0

	b = {1,null,true};//1

	c = {{false}};//0

	

	d = {a,b,c};

	

	i = 0;

	j = 0;

	e = {};

	

	while(i<Count(d))

	{

		e[j]= CountTrue(d[i]);

		i = i+1;

		j = j+1;

	}

	return = e ;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT014_FFI_Transform_TransformPoint()
        {
            string code = @"




class Geometry

{

    private hostEntityID : var;

}







class Point extends Geometry

{

   

    public X                        : var; //double = GlobalCoordinates[0];

    public Y                        : var; //double = GlobalCoordinates[1];

    public Z                        : var; //double = GlobalCoordinates[2];







    private def init : bool ()

    {

       

        X                      =  0.0;

        Y                      =  0.0;

        Z                      =  0.0;

   

        return = true;

    }

    

   

	

	public constructor ByCoordinates(xTranslation : double, yTranslation : double, zTranslation : double)

    {

        neglect = init();



        X = xTranslation;

        Y = yTranslation;

        Z = zTranslation;



    }

}





class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double (other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 : double[] () 

    { 

        return = {X, Y, Z, H };

    }

}



class Vector

{

    X : var;

    Y : var;

    Z : var;

    

    public constructor ByCoordinates(xx : double, yy : double, zz : double)

    {

        X = xx;

        Y = yy;

        Z = zz;

    }

}



class Transform

{

    public C0 : Tuple4; 

    public C1 : Tuple4; 

    public C2 : Tuple4; 

    public C3 : Tuple4;     

    

    public constructor ByTuples(C0Value : Tuple4, C1Value : Tuple4, C2Value : Tuple4, C3Value : Tuple4)

    {

        C0 = C0Value;

        C1 = C1Value;

        C2 = C2Value;

        C3 = C3Value;

    }



    public constructor ByData(data : double[][])

    {

        C0 = Tuple4.ByCoordinates4(data[0]);

        C1 = Tuple4.ByCoordinates4(data[1]);

        C2 = Tuple4.ByCoordinates4(data[2]);

        C3 = Tuple4.ByCoordinates4(data[3]);

    }

    

    public def ApplyTransform : Tuple4 (t : Tuple4)

    {

        tx = Tuple4.XYZH(C0.X, C1.X, C2.X, C3.X);

        RX = tx.Multiply(t);



        ty = Tuple4.XYZH(C0.Y, C1.Y, C2.Y, C3.Y);

        RY = ty.Multiply(t);



        tz = Tuple4.XYZH(C0.Z, C1.Z, C2.Z, C3.Z);

        RZ = tz.Multiply(t);



        th = Tuple4.XYZH(C0.H, C1.H, C2.H, C3.H);

        RH = th.Multiply(t);

        

        return = Tuple4.XYZH(RX, RY, RZ, RH);

    }

    public def TransformPoint : Point (p: Point)

    {

        tpa = Tuple4.XYZH(p.X, p.Y, p.Z, 1.0);

        tpcv = ApplyTransform(tpa);

        return = Point.ByCoordinates(tpcv.X, tpcv.Y, tpcv.Z);	

    }

    public def NativeMultiply : Transform(other : Transform)

    {              

        tc0 = ApplyTransform(other.C0);

        tc1 = ApplyTransform(other.C1);

        tc2 = ApplyTransform(other.C2);

        tc3 = ApplyTransform(other.C3);

        return = Transform.ByTuples(tc0, tc1, tc2, tc3);

    }

    

    public def NativePreMultiply : Transform (other : Transform)

    {     

        //  as we don't have this now let's do it longer way!        

        //return = other.NativeMultiply(this);

        //

        tc0 = other.ApplyTransform(C0);

        tc1 = other.ApplyTransform(C1);

        tc2 = other.ApplyTransform(C2);

        tc3 = other.ApplyTransform(C3);

        return = Transform.ByTuples(tc0, tc1, tc2, tc3);

    }

    

  

}



data = {    {1.0,0.0,0.0,0.0},

            {0.0,2.0,0.0,0.0},

            {0.0,0.0,3.0,0.0},

            {0.0,0.0,0.0,4.0}

        };

        

xform = Transform.ByData(data);

testPoint = Point.ByCoordinates(10,20,30);

x = testPoint.X;

y = testPoint.Y;

z = testPoint.Z;



resultPoint = xform.TransformPoint(testPoint);



resultx = resultPoint.X;

resulty = resultPoint.Y;

resultz = resultPoint.Z;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT014_Inline_Using_Collections()
        {
            string code = @"
[Imperative]

{

	a = { 0, 1, 2};

	b = { 3, 11 };

	c = 5;

	d = { 6, 7, 8, 9};

	e = { 10 };



	x1 = a < 5 ? b : 5;

	t1 = x1[0];

	t2 = x1[1];

	c1 = 0;

	for (i in x1)

	{

		c1 = c1 + 1;

	}

	

	x2 = 5 > b ? b : 5;

	t3 = x2[0];

	t4 = x2[1];

	c2 = 0;

	for (i in x2)

	{

		c2 = c2 + 1;

	}

	

	x3 = b < d ? b : e;

	t5 = x3[0];

	c3 = 0;

	for (i in x3)

	{

		c3 = c3 + 1;

	}

	

	x4 = b > e ? d : { 0, 1};

	t7 = x4[0];	

	c4 = 0;

	for (i in x4)

	{

		c4 = c4 + 1;

	}

	

	

}

















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT014_LanguageBlockScope_MultipleParallelLanguageBlocks_IAI()
        {
            string code = @"
[Imperative]

{

	a = 10;

	b = true;

	c = 20.1;



}



[Associative]	

{

	aA = a;

	bA = b;

	cA = c;

	

}



[Imperative]	

{

	aI = a;

	bI = b;

	cI = c;

	

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT014_Update_Of_Class_Properties()
        {
            string code = @"
class A 

{

    a : var;

	constructor A ( x)

	{

	    a = x;

	}

}



x = 3;

a1 = A.A(x);

b1 = a1.a;

x = 4;

c1 = b1;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT015_Associative_Class_Property_SetInExternalFunction()
        {
            string code = @"
	class TestPoint

	{

        X : var;

        Y : var;

             

        constructor Create(xx : int, yy : int)

        {

			X = xx; 

            Y = yy;



        }            

       

	}

	



    def Modify : TestPoint(old : TestPoint)

    {

            old.X = 10;

            old.Y = 20;

            return = old;

    }     

	



	pt1 = TestPoint.Create(1, 2);



	pt2 = Modify(pt1);

	

	testX1 = pt1.X;

	testY1 = pt1.Y;

	

	



	

	





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT015_Associative_Function_UnmatchFunctionArgument_Negative()
        {
            string code = @"
[Associative]

{



	def Foo : int (a : int)

	{



		return = 5;

	}

	

	result = Foo(1,2); 

	

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT015_BasicImport_Middle()
        {
            string code = @"
a =10;

b = 2 * a; 

import (""BasicImport.ds"");

x = 10.1;

y = 20.2;

z = 30.3;



myPoint = Point.ByCoordinates(10.1, 20.2, 30.3);



midValue = myPoint.MidValue();

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT015_CountTrue_Function()
        {
            string code = @"
def foo(x:var[]..[])

{

	a = {};

	i = 0;

	[Imperative]

	{

		for(j in x)

		{

			a[i] = CountTrue(j);

			i = i+1;

		}

	}

	return  = a;

}



b = {



{null},//0

{1,2,3,{true}},//1



{0},//0

{true, true,1,true, null},//3

{x, null}//0



};

result = foo(b);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT015_FFI_Transform_Identity()
        {
            string code = @"




class Geometry

{

    private hostEntityID : var;

}







class Point extends Geometry

{

   

    public X                        : var; //double = GlobalCoordinates[0];

    public Y                        : var; //double = GlobalCoordinates[1];

    public Z                        : var; //double = GlobalCoordinates[2];







    private def init : bool ()

    {

       

        X                      =  0.0;

        Y                      =  0.0;

        Z                      =  0.0;

   

        return = true;

    }

    

   

	

	public constructor ByCoordinates(xTranslation : double, yTranslation : double, zTranslation : double)

    {

        neglect = init();



        X = xTranslation;

        Y = yTranslation;

        Z = zTranslation;



    }

	

   

   

   

}





class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double (other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 : double[] () 

    { 

        return = {X, Y, Z, H };

    }

}



class Vector

{

    X : var;

    Y : var;

    Z : var;

    

    public constructor ByCoordinates(xx : double, yy : double, zz : double)

    {

        X = xx;

        Y = yy;

        Z = zz;

    }

}



class Transform

{

    public C0 : Tuple4; 

    public C1 : Tuple4; 

    public C2 : Tuple4; 

    public C3 : Tuple4;     

    

    public constructor ByTuples(C0Value : Tuple4, C1Value : Tuple4, C2Value : Tuple4, C3Value : Tuple4)

    {

        C0 = C0Value;

        C1 = C1Value;

        C2 = C2Value;

        C3 = C3Value;

    }



    public constructor ByData(data : double[][])

    {

        C0 = Tuple4.ByCoordinates4(data[0]);

        C1 = Tuple4.ByCoordinates4(data[1]);

        C2 = Tuple4.ByCoordinates4(data[2]);

        C3 = Tuple4.ByCoordinates4(data[3]);

    }

    

   

    public constructor Identity()

	

	{  C0 = Tuple4.XYZH(1.0,0.0,0.0,0.0);

       C1 = Tuple4.XYZH(0.0,1.0,0.0,0.0);

       C2 = Tuple4.XYZH(0.0,0.0,1.0,0.0);

       C3 = Tuple4.XYZH(0.0,0.0,0.0,1.0);

     

     }

	

}



resultTransform = Transform.Identity();

r0 = resultTransform.C0;

r1 = resultTransform.C1;

r2 = resultTransform.C2;

r3 = resultTransform.C3;

r0X = r0.X;

r0Y = r0.Y;

r0Z = r0.Z;

r0H = r0.H;

r1X = r1.X;

r1Y = r1.Y;

r1Z = r1.Z;

r1H = r1.H;

r2X = r2.X;

r2Y = r2.Y;

r2Z = r2.Z;

r2H = r2.H;

r3X = r3.X;

r3Y = r3.Y;

r3Z = r3.Z;

r3H = r3.H;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT015_Inline_In_Class_Scope()
        {
            string code = @"
class A
{
    a : int;
	constructor A ( i : int)
	{
	    a = i < 0 ? i*i : i;
	}

	def foo1 ( b )
	{
		x = b == a ? b : b+a;
		return = x;
	}	
}

class B extends A
{
    b : int;
	constructor B ( i : int)
	{
	    a = i < 0 ? i*i : i;
		b = i;
	}

    def foo2 ( x )
	{
		y = b == a ? x+b : x+b+a;
		return = y;
	}
}

b1 = B.B(1);
b2 = B.B(-1);
x1 = b1.foo2(3);
x2 = b2.foo2(-3);
a1 = A.A(-4);
x3 = a1.foo1(3);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT015_LanguageBlockScope_ParallelInsideNestedBlock_AssociativeNested_II()
        {
            string code = @"
[Associative]

{

	a = 10;

	

	[Imperative]	

	{

		aI1 = a;

	}



	aA1 = a;

	

	[Imperative]	

	{

		aI2 = a;

	}

	

	aA2 = a;

}









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT015_Update_Of_Class_Properties()
        {
            string code = @"
class A 

{

    a : int[];

	constructor A ( x : int[])

	{

	    a = x;

	}

}



x = { 3, 4 } ;

a1 = A.A(x);

b1 = a1.a;

x[0] = x [0] + 1;

c1 = b1;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT016_Associative_Class_Property_SetInClassMethod()
        {
            string code = @"
	class TestPoint

	{

        X : var;

        Y : var;

             

        constructor Create(xx : int, yy : int)

        {

			X = xx; 

            Y = yy;



        }       

    def Modify : int()

    {

            X = 10;

            Y = 20;

			return = 10;

    }    		

       

	}



	pt1 = TestPoint.Create(1, 2);



	pt2 = pt1.Modify();

	

	testX1 = pt1.X;

	testY1 = pt1.Y;

	

	



	

	





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT016_Associative_Function_ModifyArgumentInsideFunctionDoesNotAffectItsValue()
        {
            string code = @"
[Associative]

{



	def Foo : int (a : int)

	{

		a = a + 1;

		return = a;

	}

	input = 3;

	result = Foo(input); 

	originalInput = input;

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT016_BaseImportAssociative()
        {
            string code = @"
import (""BaseImportAssociative.ds"");

a = 10;

b = 20;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT016_CountTrue_Class()
        {
            string code = @"
class C

{

	a : int;

	constructor C(x:var[]..[])

	{

		a = CountTrue(x);

	}

	

	def foo(y:var[]..[])

	{

		return = CountTrue(y)+ a;

	}

}



b = {1, null, true,{{true},false}};//2

c = C.C(b);

m = c.a;//2

n = c.foo(b);//4

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT016_FFI_Transform_GetTuples()
        {
            string code = @"




class Geometry

{

    private hostEntityID : var;

}







class Point extends Geometry

{

   

    public X                        : var; //double = GlobalCoordinates[0];

    public Y                        : var; //double = GlobalCoordinates[1];

    public Z                        : var; //double = GlobalCoordinates[2];







    private def init : bool ()

    {

       

        X                      =  0.0;

        Y                      =  0.0;

        Z                      =  0.0;

   

        return = true;

    }

    

   

	

	public constructor ByCoordinates(xTranslation : double, yTranslation : double, zTranslation : double)

    {

        neglect = init();



        X = xTranslation;

        Y = yTranslation;

        Z = zTranslation;



    }

	

   

   

   

}





class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double (other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 : double[] () 

    { 

        return = {X, Y, Z, H };

    }

}



class Vector

{

    X : var;

    Y : var;

    Z : var;

    

    public constructor ByCoordinates(xx : double, yy : double, zz : double)

    {

        X = xx;

        Y = yy;

        Z = zz;

    }

}



class Transform

{

    public C0 : Tuple4; 

    public C1 : Tuple4; 

    public C2 : Tuple4; 

    public C3 : Tuple4;     

    

    public constructor ByTuples(C0Value : Tuple4, C1Value : Tuple4, C2Value : Tuple4, C3Value : Tuple4)

    {

        C0 = C0Value;

        C1 = C1Value;

        C2 = C2Value;

        C3 = C3Value;

    }



    public constructor ByData(data : double[][])

    {

        C0 = Tuple4.ByCoordinates4(data[0]);

        C1 = Tuple4.ByCoordinates4(data[1]);

        C2 = Tuple4.ByCoordinates4(data[2]);

        C3 = Tuple4.ByCoordinates4(data[3]);

    }

    

   	

    public def GetTuples : Tuple4[]()

    {

        tupleDataC0 = C0;

        tupleDataC1 = C1;

        tupleDataC2 = C2;

        tupleDataC3 = C3;

        return = { tupleDataC0, tupleDataC1, tupleDataC2, tupleDataC3 };

    }

    public constructor Identity()

	

	{  C0 = Tuple4.XYZH(1.0,0.0,0.0,0.0);

       C1 = Tuple4.XYZH(0.0,1.0,0.0,0.0);

       C2 = Tuple4.XYZH(0.0,0.0,1.0,0.0);

       C3 = Tuple4.XYZH(0.0,0.0,0.0,1.0);

     

     }

	

}



resultTransform = Transform.Identity();

resultTuples = resultTransform.GetTuples();

r0 = resultTuples[0];

r1 = resultTuples[1];

r2 = resultTuples[2];

r3 = resultTuples[3];

r0X = r0.X;

r0Y = r0.Y;

r0Z = r0.Z;

r0H = r0.H;

r1X = r1.X;

r1Y = r1.Y;

r1Z = r1.Z;

r1H = r1.H;

r2X = r2.X;

r2Y = r2.Y;

r2Z = r2.Z;

r2H = r2.H;

r3X = r3.X;

r3Y = r3.Y;

r3Z = r3.Z;

r3H = r3.H;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT016_Inline_Using_Operators()
        {
            string code = @"
def foo (a:int )

{

	 return = a;   

}

a = 1+2 > 3*4 ? 5-9 : 10/2;

b = a > -a ? 1 : 0;

c = 2> 1 && 4>3 ? 1 : 0;

d = 1 == 1 || (1 == 0) ? 1 : 0;

e1 = a > b && c > d ? 1 : 0;

f = a <= b || c <= d ? 1 : 0;

g = foo({ 1, 2 }) > 3+ foo({4,5,6}) ?  1 : 3+ foo({4,5,6});

i = {1,3} > 2 ? 1: 0;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT016_LanguageBlockScope_ParallelInsideNestedBlock_ImperativeNested_AA()
        {
            string code = @"
[Imperative]

{

	a = 10;

	[Associative]	

	{

		aA1 = a;

	}



	aI1 = a;

	

	[Associative]	

	{

		aA2 = a;

	}

	aI2 = a;

}









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT016_Update_Of_Variable_Types()
        {
            string code = @"
class A 

{

    a : int;

	constructor A ( x : int)

	{

	    a = x;

	}

}



x = { 3, 4 } ;

y = x[0] + 1;

x =  { 3.5, 4.5 } ;

x =  { A.A(1).a, A.A(2).a } ;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT017_Associative_Class_Property_SetInExternalClassMethod()
        {
            string code = @"
	class TestPoint

	{

        X : var;

        Y : var;

             

        constructor Create(xx : int, yy : int)

        {

			X = xx; 

            Y = yy;



        }       

    def Modify : int()

    {

            X = 10;

            Y = 20;

			return = 10;

    }    		

       

	}

	

	class ExternalClass

	{

	

		constructor Create()

		

		{

			test = 1;

		}

		

		def Modify : int (origin : TestPoint)

		{

		

		origin.X = 10;

		origin.Y = 20;

		return = 5;

		

		}

	}

	pt1 = TestPoint.Create(1, 2);



	dummy = ExternalClass.Create();

	

	result = dummy.Modify(pt1);

	

	testX1 = pt1.X;

	testY1 = pt1.Y;

	

	



	

	





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT017_Associative_Function_CallingAFunctionBeforeItsDeclaration()
        {
            string code = @"
[Associative]

{

	def Level1 : int (a : int)

	{



		return = Level2(a+1);

	}

	

	def Level2 : int (a : int)

	{



		return = a + 1;

	}





	input = 3;

	result = Level1(input);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT017_BaseImportWithVariableClassInstance_Associativity()
        {
            string code = @"
import (""BaseImportWithVariableClassInstance.ds"");

c = a + b;

a = 10;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT017_CountTrue_Inline()
        {
            string code = @"
[Imperative]

{

def foo(x:var[]..[])

{

	if(CountTrue(x) > 0)

		return = true;

	return = false;

}

a = {null,1};//0

b = {null,20,30,null,{10,0},true,{false,0,{true,{false},5,2,false}}};//2

c = {1,2,foo(b)};



result = CountTrue(c) > 0 ? CountTrue(a):CountTrue(b);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT017_FFI_Transform_GetData()
        {
            string code = @"




class Geometry

{

    private hostEntityID : var;

}







class Point extends Geometry

{

   

    public X                        : var; //double = GlobalCoordinates[0];

    public Y                        : var; //double = GlobalCoordinates[1];

    public Z                        : var; //double = GlobalCoordinates[2];







    private def init : bool ()

    {

       

        X                      =  0.0;

        Y                      =  0.0;

        Z                      =  0.0;

   

        return = true;

    }

    

   

	

	public constructor ByCoordinates(xTranslation : double, yTranslation : double, zTranslation : double)

    {

        neglect = init();



        X = xTranslation;

        Y = yTranslation;

        Z = zTranslation;



    }

	

   

   

   

}





class Tuple4

{

    X : var;

    Y : var;

    Z : var;

    H : var;

    

    constructor XYZH(xValue : double, yValue : double, zValue : double, hValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = hValue;        

    }

    

    constructor XYZ(xValue : double, yValue : double, zValue : double)

    {

        X = xValue;

        Y = yValue;

        Z = zValue;

        H = 1.0;        

    }



    constructor ByCoordinates3(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = 1.0;        

    }



    constructor ByCoordinates4(coordinates : double[] )

    {

        X = coordinates[0];

        Y = coordinates[1];

        Z = coordinates[2];

        H = coordinates[3];    

    }

    

    def get_X : double () 

    {

        return = X;

    }

    

    def get_Y : double () 

    {

        return = Y;

    }

    

    def get_Z : double () 

    {

        return = Z;

    }

    

    def get_H : double () 

    {

        return = H;

    }



    

    public def Multiply : double (other : Tuple4)

    {

        return = X * other.X + Y * other.Y + Z * other.Z + H * other.H;

    }

    

    public def Coordinates3 : double[] ()

    { 

        return = {X, Y, Z };

    }

    

    public def Coordinates4 : double[] () 

    { 

        return = {X, Y, Z, H };

    }

}



class Vector

{

    X : var;

    Y : var;

    Z : var;

    

    public constructor ByCoordinates(xx : double, yy : double, zz : double)

    {

        X = xx;

        Y = yy;

        Z = zz;

    }

}



class Transform

{

    public C0 : Tuple4; 

    public C1 : Tuple4; 

    public C2 : Tuple4; 

    public C3 : Tuple4;     

    

    public constructor ByTuples(C0Value : Tuple4, C1Value : Tuple4, C2Value : Tuple4, C3Value : Tuple4)

    {

        C0 = C0Value;

        C1 = C1Value;

        C2 = C2Value;

        C3 = C3Value;

    }



    public constructor ByData(data : double[][])

    {

        C0 = Tuple4.ByCoordinates4(data[0]);

        C1 = Tuple4.ByCoordinates4(data[1]);

        C2 = Tuple4.ByCoordinates4(data[2]);

        C3 = Tuple4.ByCoordinates4(data[3]);

    }

    

   	

    public def GetData()

	{

		t0 = C0;

		t1 = C1;

		t2 = C2;

		t3 = C3;

		temp = 	{	{t0.X, t0.Y, t0.Z, t0.H},

					{t1.X, t1.Y, t1.Z, t1.H},

					{t2.X, t2.Y, t2.Z, t2.H},

					{t3.X, t3.Y, t3.Z, t3.H}

				};

		return = temp;

	}

    public constructor Identity()

	

	{  C0 = Tuple4.XYZH(1.0,0.0,0.0,0.0);

       C1 = Tuple4.XYZH(0.0,1.0,0.0,0.0);

       C2 = Tuple4.XYZH(0.0,0.0,1.0,0.0);

       C3 = Tuple4.XYZH(0.0,0.0,0.0,1.0);

     

     }

	

}



resultTransform = Transform.Identity();

resultData = resultTransform.GetData();

result0 = resultData[0];

result1 = resultData[1];

result2 = resultData[2];

result3 = resultData[3];

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT017_Inline_In_Function_Scope()
        {
            string code = @"
def foo1 ( b )

{

	return = b == 0 ? b : b+1;

	

}



def foo2 ( x )

{

	y = [Imperative]

	{

	    if(x > 0)

		{

		   return = x >=foo1(x) ? x : foo1(x);

		}

		return = x >=2 ? x : 2;

	}

	x1 = y == 0 ? 0 : y;

	return = y + x1;

}



a1 = foo1(4);

a2 = foo2(3);



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT017_LanguageBlockScope_AssociativeNestedAssociative_Function()
        {
            string code = @"
[Associative]

{

	def foo : int(a : int, b : int)

	{

		return = a + b;

	}

	[Associative]	

	{

	    x = 10;

	    y = 20;

	    z = foo (x, y);

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT017_Update_Of_Class_Instances()
        {
            string code = @"
class Point

{

    X : double;

		

    public constructor ByCoordinates( xValue : double  )

    {

	X = xValue; 			

    }

}

class Line

{

    P1 : Point;

    P2 : Point;

		

    public constructor ByStartPointEndPoint( p1 : Point, p2:Point  )

    {

	P1 = p1;

	P2 = p2;		

    }

}

class MyPoint 

{

    // define general system of dependencies

    x : double = 1; 

    y : double = 2;	

    inner  : Point = Point.ByCoordinates(0);	 // create inner point dependent on x and y

	

    public constructor ByXYcoordinates(xValue : double )

    {

	x = xValue; 			

	inner = Point.ByCoordinates(x);

    }

	

    public constructor ByAngleRadius(y1 : double)

    {

	y = y1;	

	inner = Point.ByCoordinates(y);

    }

	

    // add 'incremental' modifiers

    def incrementX(xValue : double) = ByXYcoordinates(x + xValue);

    def incrementY(yValue : double) = ByAngleRadius(y + yValue);	

}



a 	 = MyPoint.ByXYcoordinates(1.0);                // create an instance 'a' using one constructor

origin   = Point.ByCoordinates(0);  	                // create a reference point

testLine = Line.ByStartPointEndPoint(origin, a.inner);	// create a testLine (to see some results)

aX 	 = a.x;						// report the properties of 'a'

aY 	 = a.y;

aP 	 = a.inner;



// test update

a 	 = MyPoint.ByAngleRadius(2.5);		      	    

a 	 = a.incrementX(3.0);							   

a 	 = MyPoint.ByAngleRadius(5.0);					        





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT018_Associative_Class_Constructor_WithSameNameAndArgument_Negative()
        {
            string code = @"
class TestClass

    {

    X: var;

    Y: var;

    constructor Create(x : double, y : double)

        {

        X = x;

        Y = y;

        }

    constructor Create(x : double, y : double)

        {

        X = x;

        Y = y;

        }

    }

    test = TestClass.Create (10.0, 11.0);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT018_CountTrue_RangeExpression_01()
        {
            string code = @"
result = 

[Imperative]

{

	a1 = {1,true, null};//1

	a2 = 8;

	a3 = {2,{true,{true,1}},{false,x, true}};//3

	a = CountTrue(a1)..a2..CountTrue(a3);//{1,4,7}

	

	return = CountTrue(a);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT018_CountTrue_RangeExpression_02()
        {
            string code = @"
result = 

[Imperative]

{

	a1 = {1,true, null};//1

	a2 = 8;

	a3 = {2,{true,{true,1}},{false,x, true}};//3

	a = CountTrue(a1)..a2..~CountTrue(a3);//{}



	return = CountTrue(a);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT018_CountTrue_RangeExpression_03()
        {
            string code = @"
result = 

[Imperative]

{

	a1 = {1,true, null};//1

	a2 = 8;

	a3 = {2,{true,{true,1}},{false,x, true}};//3

	a = {1.0,4.0,7.0};

	//a = CountTrue(a1)..a2..#CountTrue(a3);//{}



	return = CountTrue(a);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT018_FFI_Math_Trigonometric_Hyperbolic()
        {
            string code = @"
class Math

{

				external (""ffi_library"") def dc_sec:double(deg:double);

				external (""ffi_library"") def dc_csc:double(deg:double);

				external (""ffi_library"") def dc_cot:double(deg:double);

				external (""ffi_library"") def dc_asec:double(deg:double);

				external (""ffi_library"") def dc_acsc:double(deg:double);

				external (""ffi_library"") def dc_acot:double(deg:double);	

				external (""ffi_library"") def dc_cosh : double (val : double);

				external (""ffi_library"") def dc_sinh : double (val : double);

				external (""ffi_library"") def dc_tanh : double (val : double);			

				external (""ffi_library"") def dc_csch : double (val : double);

				external (""ffi_library"") def dc_sech : double (val : double);

				external (""ffi_library"") def dc_coth : double (val : double);					

           

                constructor GetInstance()

                {}              

                			

                def Sec : double ( val : double )

                {

                                return = dc_sec(val);

                }

                

                def Csc : double ( val : double )

                {

                                return = dc_csc(val);

                }

                

                def Cot : double ( val : double )

                {

                                return = dc_cot(val);

                }

				

                def ArcSec : double ( val : double )

                {

                                return = dc_asec(val);

                }

                

                def ArcCsc : double ( val : double )

                {

                                return = dc_acsc(val);

                }

                

                def ArcCot : double ( val : double )

                {

                                return = dc_acot(val);

                }

				

				def Sinh : double ( val : double )

                {

                                return = dc_sinh(val);

                }

                

                def Cosh : double ( val : double )

                {

                                return = dc_cosh(val);

                }

                

                def Tanh : double ( val : double )

                {

                                return = dc_tanh(val);

                }

				

				def Sech : double ( val : double )

                {

                                return = dc_sech(val);

                }

                

                def Csch : double ( val : double )

                {

                                return = dc_csch(val);

                }

                

                def Coth : double ( val : double )

                {

                                return = dc_coth(val);

                }

}



[Associative]

{

                math = Math.GetInstance();

				//trigonometric

                angle = 30.0;

                sec_30 = math.Sec(angle);

                csc_30 = math.Csc(angle);

                cot_30 = math.Cot(angle);

                asec_30 = math.ArcSec(sec_30);

                acsc_30 = math.ArcCsc(csc_30);

                acot_30 = math.ArcCot(cot_30);

				//hyperbolic

				sinh_1 = math.Sinh(1.0);

				cosh_1 = math.Cosh(1.0);

				tanh_1 = math.Tanh(1.0);				

				sech_1 = math.Sech(1.0);

				csch_1 = math.Csch(1.0);

				coth_1 = math.Coth(1.0);     

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Ignore]
        [Test]
        public void DebugEQT018_Inline_Using_Recursion()
        {
            string code = @"
def factorial : int (num : int)

{

    return = num < 2 ? 1 : num * factorial(num-1);

}







fac = factorial(10);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        [Ignore]
        public void DebugEQT018_LanguageBlockScope_ImperativeNestedImperaive_Function()
        {
            string code = @"
[Imperative]

{

	def foo : int(a : int, b : int)

	{

		return = a + b;

	}

		[Imperative]	

	{

	x = 10;

	y = 20;

	z = foo (x, y);

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT018_MultipleImport()
        {
            string code = @"
import (""basicImport1.ds"");

import (""basicImport2.ds"");



myPoint = Point.ByCoordinates(10.1, 20.2, 30.3);

z = myPoint.Z;

midValue = myPoint.MidValue();

arr = Scale(midValue, 4.0);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT018_Update_Inside_Class_Constructor()
        {
            string code = @"
class Point

{

    X : double;

    Y : double;

    

    public constructor ByXCoordinates( xValue : double  )

    {

	X = xValue;

	Y = X + 1;

	X = X + 1;        	

    }

    

    def addandIncr()

    {

        X = X + 1;

	Y = X + 1;

	X = X + 1;

	return = X + Y;

    }

}

p1 = Point.ByXCoordinates( 1 );

x1 = p1.X;

y1 = p1.Y;

z = p1.addandIncr();





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT018_Update_Inside_Class_Constructor_2()
        {
            string code = @"
class Point

{

    X : double;

    Y  =  X + 1;

    

    public constructor ByXCoordinates( xValue : double  )

    {

	X = xValue;

	X = X + 1;        	

    }

    

    def addandIncr()

    {

        X = X + 1;

	X = X + 1;

	return = X + Y;

    }

}

p1 = Point.ByXCoordinates( 1 );

x1 = p1.X;

y1 = p1.Y;

z = p1.addandIncr();





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT019_Associative_Class_Constructor_Overloads_WithSameNameAndDifferentArgumentNumber()
        {
            string code = @"
class TestClass

    {

    X: var;

    Y: var;

    constructor Create(x : double, y : double)

        {

        X = x + 10;

        Y = y + 10;

        }

    constructor Create(x : double, y : double, z: double)

        {

        X = x + 100;

        Y = y + 100;

        }

    }

    test1 = TestClass.Create (1.0, 2.0);

	test2 = TestClass.Create (1.0, 2.0,3.0);

	

	

	x1 = test1.X;

	y1 = test1.Y;

	x2 = test2.X;

	y2 = test2.Y;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT019_CountTrue_Replication()
        {
            string code = @"


def foo(x:int)

{

	return = x +1;

}



a = {true,{true},1};//2

b = {null};

c = {{{true}}};//1

d = {{true},{false,{true,true}}};//3



arr = {CountTrue(a),CountTrue(b),CountTrue(c),CountTrue(d)};



result = foo(arr);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT019_Defect_1456758()
        {
            string code = @"
b = true;

a1 = b && true ? -1 : 1;

[Imperative]

{

	a2 = b && true ? -1 : 1;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT019_FFI_Math_Others()
        {
            string code = @"
class Math

{

                external (""ffi_library"") def dc_ceil : double (val : double);

				external (""ffi_library"") def dc_floor : double (val : double);

				external (""ffi_library"") def dc_abs : double (val : double);

				external (""ffi_library"") def dc_pow : double (val1 : double, val2 : double);

				external (""ffi_library"") def dc_exp : double (val : double);

				external (""ffi_library"") def dc_factorial : int (val : int); //overflow problem. int is too small

				external (""ffi_library"") def dc_sum_range_step_size : double (val1 : double, val2 : double, step: double);

				external (""ffi_library"") def dc_sum_range_step_num : double (val1 : double, val2 : double, stepNum: int);

				external (""ffi_library"") def dc_sign : int (val : double);

				external (""ffi_library"") def dc_log10 : double (val : double);

				external (""ffi_library"") def dc_logbase: double (val : double, logbase : double);

				external (""ffi_library"") def dc_max : double (val1 : double, val2 : double);

				external (""ffi_library"") def dc_min : double (val1 : double, val2 : double);

				external (""ffi_library"") def dc_round : double (val : double, decimals: int);

				

                constructor GetInstance()

                {}

                

                def Ceil : double ( val : double )

                {

                                return = dc_ceil(val);

                }



                def Floor : double ( val : double )

                {

                                return = dc_floor(val);

                }

				

				def Abs : double ( val : double )

                {

                                return = dc_abs(val);

                }

                

                def Pow : double ( val1 : double, val2 : double )

                {

                                return = dc_pow(val1, val2);

                }

                

                def Exp : double ( val : double )

                {

                                return = dc_exp(val);

                }

				

				def Factorial : int ( val : int )

                {

                                return = dc_factorial(val);

                }

				

				def SumRangeStepSize : double (val1 : double, val2 : double, step: double)

                {

                                return = dc_sum_range_step_size(val1, val2, step);

                }

				

				def SumRangeStepNum : double (val1 : double, val2 : double, stepNum: int)

                {

                                return = dc_sum_range_step_num(val1, val2, stepNum);

                }

				

				def Sign : int ( val : double )

                {

                                return = dc_sign(val);

                }



                def Log10 : double ( val : double )

                {

                                return = dc_log10(val);

                }

				

				def LogBase : double (val : double, logbase : double)

                {

                                return = dc_logbase(val, logbase);

                }

                

                def Max : double ( val1 : double, val2 : double )

                {

                                return = dc_max(val1, val2);

                }

				

				def Min : double ( val1 : double, val2 : double )

                {

                                return = dc_min(val1, val2);

                }

                

                def Round : double (val : double, decimals: int)

                {

                                return = dc_round(val, decimals);

                }

}



[Associative]

{

                math = Math.GetInstance();

				ceil_5d5 = math.Ceil(5.5);

				floor_5d5 = math.Floor(5.5);

				abs_5 = math.Abs(5.0);

				abs_neg5 = math.Abs(-5.0);

				pow_3p4 = math.Pow(3.0, 4.0);	

				exp_3 = math.Exp(3.0);

				fact_10 = math.Factorial(10);

				sum_1t100s11 = math.SumRangeStepSize(1.0,100.0,11.0);

				sum_1t100sn11 = math.SumRangeStepNum(1.0,100.0,11);

				val = 8.8234893405;

				sign_pos = math.Sign(val);

				//sign_neg = math.Sign(-val); //wrong answer, sign_neg = 4294967295, should be -1

				sign_zero = math.Sign(0.0);

				log10_val = math.Log10(val);

				logbase_val_5 = math.LogBase(val, 5.0);

				max_10 = math.Max(val, 10.0);

				min_Neg2 = math.Min(val, -2.0);

				round_val_5 = math.Round(val, 5);

				round_negval_5 = math.Round(-val, 5); 

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT019_LanguageBlockScope_ImperativeNestedAssociative_Function()
        {
            string code = @"
[Imperative]

{

	def foo : int(a : int, b : int)

	{

		return = a - b;

	}

	[Associative]	

	{

	x = 20;

	y = 10;

	z = foo (x, y);

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT019_MultipleImport_ClashFunctionClassRedifinition()
        {
            string code = @"
import (""basicImport.ds"");

import (""basicImport2.ds"");



myPoint = Point.ByCoordinates(10.1, 20.2, 30.3);

z = myPoint.Z;

midValue = myPoint.MidValue();

arr = Scale(midValue, 4.0);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT019_Update_General()
        {
            string code = @"
X = 1;

Y = X + 1;

X = X + 1;



X = X + 1;

//Y = X + 1;

//X  = X + 1;



test = X + Y;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_Arithmatic_List_And_List_Different_Length()
        {
            string code = @"
list1 = { 1, 4, 7, 2};

list2 = { 5, 8, 3, 6, 7, 9 };



list3 = list1 + list2; // { 6, 12, 10, 8 }

list4 = list1 - list2; // { -4, -4, 4, -4}

list5 = list1 * list2; // { 5, 32, 21, 12 }

list6 = list2 / list1; // { 5, 2, 0, 3 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_BasicGlobalFunction()
        {
            string code = @"
def foo:int(x:int)

{

	return = x;

}



a = foo;

b = foo(3); //b=3;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_Class_In_Various_Scopes()
        {
            string code = @"
class Dummy

{ 

	x : var;  

	constructor Dummy () 

	{	

		x = 2;	 

	}

}



obj1 = [Imperative]

{

	a = Dummy.Dummy();

	a1 = a.x;

	return = a;

}



getX1 = obj1.x;	



obj2 = [Associative]

{

	b = Dummy.Dummy();

	b1 = b.x;

	return = b1;

}



getX2 = obj2.x;	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_Function_In_Assoc_Scope()
        {
            string code = @"
[Associative]

{

    def foo : int( a:int )

    {

	   return = a * 10;

	}

	

    a = foo( 2 );

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_NegativeSyntax_Negative()
        {
            string code = @"
[Imperative]

{

    i = 0;

    temp = 1;

    while ( i < 5 ]

	{

	    temp=temp+1;

        i=i+1;

    }

}	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_SimpleRangeExpression()
        {
            string code = @"
[Imperative]

{

	a = 1..-6..-2;

	a1 = 2..6..~2.5; 

	a2 = 0.8..1..0.2; 

	a3 = 0.7..1..0.3; 

	a4 = 0.6..1..0.4; 

	a5 = 0.8..1..0.1; 

	a6 = 1..1.1..0.1; 

	a7 = 9..10..1; 

	a8 = 9..10..0.1;

	a9 = 0..1..0.1; 

	a10 = 0.1..1..0.1;

	a11 = 0.5..1..0.1;

	a12 = 0.4..1..0.1;

	a13 = 0.3..1..0.1;

	a14 = 0.2..1..0.1;

	a17 = (0.5)..(0.25)..(-0.25);

	

}











";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_Simple_1D_Collection_Assignment()
        {
            string code = @"
[Imperative]

{

	a = { {1,2}, {3,4} };

	

	a[1] = {-1,-2,3};

	

	c = a[1][1];

	

	d = a[0];

	

	b = { 1, 2 };

	

	b[0] = {2,2};



	e = b[0];

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_Simple_Assignment_Slicing()
        {
            string code = @"
def foo ( a , b )

{

	return = { a , b };

}

[Imperative]

{

{a , b} = foo ( 1 , 2 );

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_String_IfElse_1()
        {
            string code = @"
a = ""word"";

b = ""word "";



result = 

[Imperative]

{

	if(a==b)

	{

		return = true;

	}

	else return = false;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_String_IfElse_2()
        {
            string code = @"
a = ""w ord"";

b = ""word"";



result = 

[Imperative]

{

	if (a ==b) return = true;

	else return = false;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_String_IfElse_3()
        {
            string code = @"
a = "" "";

b = """";



result = 

[Imperative]

{

	if (a ==b) return = true;

	else return = false;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_String_IfElse_4()
        {
            string code = @"
a = ""a"";

b = ""a"";



result = 

[Imperative]

{

	if (a ==b) return = true;

	else return = false;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_String_IfElse_5()
        {
            string code = @"
a = ""  "";//3 whiteSpace

b = ""	"";//tab



result = 

[Imperative]

{

	if (a ==b) return = true;

	else return = false;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_String_IfElse_6()
        {
            string code = @"
a = """";

b = "" "";



result = 

[Imperative]

{

	if (a ==null && b!=null) return = true;

	else return = false;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_String_IfElse_7()
        {
            string code = @"
a = ""a"";



result = 

[Imperative]

{

	if (a ==true||a == false) return = true;

	else return = false;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_TestAllPassCondition()
        {
            string code = @"
[Imperative]

{

 a1 = 2 ;

 a2 = -1;

 a3 = 101;

 a4 = 0;

 

 b1 = 1.0;

 b2 = 0.0;

 b3 = 0.1;

 b4 = -101.99;

 b5 = 10.0009;

 

 c1 = { 0, 1, 2, 3};

 c2 = { 1, 0.2};

 c3 = { 0, 1.4, true };

 c4 = {{0,1}, {2,3 } };

 

 x = {0, 0, 0, 0};

 if(a1 == 2 ) // pass condition

 {

     x[0] = 1;

 }  

 if(a2 <= -1 )  // pass condition

 {

     x[1] = 1;

 }

 if(a3 >= 101 )  // pass condition

 {

     x[2] = 1;

 }

 if(a4 == 0 )  // pass condition

 {

     x[3] = 1;

 }

 

 

 y = {0, 0, 0, 0, 0};

 if(b1 == 1.0 ) // pass condition

 {

     y[0] = 1;

 }  

 if(b2 <= 0.0 )  // pass condition

 {

     y[1] = 1;

 }

 if(b3 >= 0.1 )  // pass condition

 {

     y[2] = 1;

 }

 if(b4 == -101.99 )  // pass condition

 {

     y[3] = 1;

 }

 if(b5 == 10.0009 )  // pass condition

 {

     y[4] = 1;

 }

 

 

 z = {0, 0, 0, 0};

 if(c1[0] == 0 ) // pass condition

 {

     z[0] = 1;

 }  

 if(c2[1] <= 0.2 )  // pass condition

 {

     z[1] = 1;

 }

 if(c3[2] == true )  // pass condition

 {

     z[2] = 1;

 }

  if(c4[0][0] == 0 )  // pass condition

 {

     z[3] = 1;

 }

 

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_TestGCArray()
        {
            string code = @"
import(""DisposeVerify.ds"");



[Imperative]

{

DisposeVerify.x = 1;

arr = { A.A(), A.A(), A.A() };

arr = 3;

v1 = DisposeVerify.x; // 4



a1 = A.A();

arr = { a1, A.A() };

arr = 3;

v2 = DisposeVerify.x; // 5



def foo : int(a : A[])

{

    return = 10;

}

a2 = A.A();

a = foo( { a1, a2 });

a2 = A.A();

v3 = DisposeVerify.x; // 6

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_TestImpInsideImp()
        {
            string code = @"
[Imperative]

{

    x = 5;

    [Imperative]

    {

        y = 5;

    }

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_TestNegativeSyntax_Negative()
        {
            string code = @"
[Imperative]

{

	a = { 4, 5, 3 };

	x = 0;

 

	for { y in a }

	{

	    x = x + 1;

    }

} 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_TestVariousTypes()
        {
            string code = @"
class A

{

    i : int;

	constructor A ( a : int)

	{

	     x : int  = 2;

		 i = x + a ;

	}

	

	def foo : int ( )

	{

	    x : int = 2;

		t3 = x + i;

        return  = t3;		

	}

	

}



def foo : int ( a : int )

{

    x : int = 2;

	return = x + a ;

}



[Imperative]

{

    i : int = 5;

    d : double = 5.2;

    isTrue : bool = true;

    isFalse :bool = false;

	x = foo(1);

	a1 = A.A(1);

	b1 = a1.foo();

	x1:int = 2.3;

	y:double = 2;

    

}



[Associative]

{

    i : int = 5;

    d : double = 5.2;

    isTrue : bool = true;

    isFalse :bool = false;

	x = foo(1);

	a1 = A.A(1);

	b1 = a1.foo();

	x1:int = 2.3;

	y:double = 2;

    

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_Update_Variable_Across_Language_Scope()
        {
            string code = @"
[Associative]

{

    a = 0;

	d = a + 1;

    [Imperative]

    {

		b = 2 + a;

		a = 1.5;

		

    }

	c = 2;

}
*/
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT01_WhileBreakContinue()
        {
            string code = @"
[Imperative]

{

    x = 0;

    y = 0;



    while (true) 

    {

        x = x + 1;

        if (x > 10)

            break;

        

        if ((x == 1) || (x == 3) || (x == 5) || (x == 7) || (x == 9))

            continue;

        

        y = y + 1;

    }

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT020_Associative_Class_Constructor_Overloads_WithSameNameAndDifferentArgumenType()
        {
            string code = @"
class TestClass

    {

    X: var;

    Y: var;

    constructor Create(x : double, y : double)

        {

        X = x + 10;

        Y = y + 10;

        }

    constructor Create(x : bool, y : bool)

        {

        X = 100;

        Y = 100;

        }

    }

    test1 = TestClass.Create (1.0, 2.0);

	test2 = TestClass.Create (true, false);

	

	

	x1 = test1.X;

	y1 = test1.Y;

	x2 = test2.X;

	y2 = test2.Y;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT020_CountTrue_DynamicArray()
        {
            string code = @"
result = 

[Imperative]

{



	a1 = {

	{{true},{}},

	{@a,2,{false}},

	{@a,@b,@null},//{null,null,null}

	{null}

	};

	a2 = {};



	i = 0;

	j = 0; 

	while(i < CountTrue(a1))

	{

		if(CountTrue(a1[i])>0)

		{

			a2[j] = a1[i];

			j = j+1;

			

		}

		i = i+1;

	}

	return = CountTrue(a2);

} 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT020_LanguageBlockScope_AssociativeNestedImperative_Function()
        {
            string code = @"
[Associative]

{

	def foo : int(a : int, b : int)

	{

		return = a - b;

	}

	[Imperative]	

	{

	x = 20;

	y = 10;

	z = foo (x, y);

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT020_MultipleImport_WithSameFunctionName()
        {
            string code = @"
import (""basicImport1.ds"");

import (""basicImport3.ds"");



arr = { 1.0, 2.0, 3.0 };

a1 = Scale( arr, 4.0 );

b = a * 2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT020_Nested_And_With_Range_Expr()
        {
            string code = @"


a1 =  1 > 2 ? true : 2 > 1 ? 2 : 1;

a2 =  1 > 2 ? true : 0..3;

b = {0,1,2,3};

a3 = 1 > 2 ? true : b;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT020_Update_Inside_Class_Constructor()
        {
            string code = @"
class Point

{

    X : double;

    Y : double;

    

    public constructor ByXCoordinates( xValue : double  )

    {

	X = xValue;

	Y = X + 1;

	X = X + 1;        	

    }

    

    def addandIncr()

    {

        X = X + 1;

	Y = X + 1;

	X = X + 1;

	return = X + Y;

    }

}

a = 0;

p1 = Point.ByXCoordinates( a );

x1 = p1.X;

y1 = p1.Y;

z = p1.addandIncr();

a = a + 1;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT020_Vector_ByCoordinates()
        {
            string code = @"
import (Vector from ""ProtoGeometry.dll"");



	vec =  Vector.ByCoordinates(3.0,4.0,0.0); 

	vec_X = vec.get_X(); 



	vec_Y = vec.get_Y();

	vec_Z = vec.get_Z();

	

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT021_Associative_Class_Constructor_UsingUserDefinedClassAsArgument()
        {
            string code = @"
class MyClass

    

{     

    X: var;

    Y: var;

    constructor Create(x : double, y : double)

        {

        X = x + 10;

        Y = y + 10;

        }  

}



class TestClass

    {

    X: var;

    Y: var;

    constructor Create(test : MyClass)

        {

        X = test.X + 10;

        Y = test.Y + 10;

        }



    }

    test1 = MyClass.Create (1.0, 2.0);

	test2 = TestClass.Create (test1);

	

	

	x2 = test2.X;

	y2 = test2.Y;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT021_CountTrue_ModifierStack()
        {
            string code = @"
x = {true, 0,{1},false,x,null,{true}};

m = 2.56;

a = {

	CountTrue(x) => a1; //2

	CountTrue(x[6]) => a2;//1

	CountTrue(x[CountTrue(x)]);//0

	m => a4;

	CountTrue({a4}) => a5;//0

	}

	x = {};

	result = {a1,a2,a3,a4,a5};

	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT021_Defect_1457354()
        {
            string code = @"
import (""c:\wrongPath\test.ds"");



a = 1;

b = a * 2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT021_Defect_1457354_2()
        {
            string code = @"
import (""basicImport"");



a = 1;

b = a * 2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT021_Defect_1457354_3()
        {
            string code = @"
import (""basicImport12.ds"");



a = 1;

b = a * 2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT021_Defect_1467166_array_comparison_issue()
        {
            string code = @"
[Imperative] 

{

    a = { 0, 1, 2}; 

    xx = a < 1 ? 1 : 0;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT021_LanguageBlockScope_DeepNested_IAI_Function()
        {
            string code = @"
[Imperative]

{

	def foo : int(a : int, b : int)

	{

		return = a - b;

	}

	[Associative]	

	{

		x_1 = 20;

		y_1 = 10;

		z_1 = foo (x_1, y_1);

	

	

	[Imperative]

		{

			x_2 = 100;

			y_2 = 100;

			z_2 = foo (x_2, y_2);

			

		}

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT021_Update_Inside_Class_Constructor()
        {
            string code = @"
def foo ( x )

{

    return = x + 1;

}

class Point

{

    X : double;

    Y : double;

    

    public constructor ByXCoordinates( xValue : double  )

    {

	X = xValue;

	Y = foo (X );

	X = X + 1;        	

    }

    

    def addandIncr()

    {

        X = X + 1;

	Y = foo ( X );

	X = X + 1;

	return = X + Y;

    }

}

a = 0;

p1 = Point.ByXCoordinates( a );

x1 = p1.X;

y1 = p1.Y;

z = p1.addandIncr();

a = a + 1;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT021_Vector_ByCoordinates()
        {
            string code = @"
import (Vector from ""ProtoGeometry.dll"");





	vec =  Vector.ByCoordinates(3.0,4.0,0.0,true); 

	vec_X = vec.get_X();

	vec_Y = vec.get_Y();

	vec_Z = vec.get_Z();



	vec_Normalised=vec.Normalize();



	vec2 =  Vector.ByCoordinates(3.0,4.0,0.0,false);



	

	vec2 =  Vector.ByCoordinates(3.0,4.0,0.0,false);

	vec2_X = vec2.get_X();

	vec2_Y = vec2.get_Y();

	vec2_Z = vec2.get_Z();

	vec_len = vec2.GetLength();



	vec1 =  Vector.ByCoordinates(3.0,4.0,0.0,null); 



	vec4 =  Vector.ByCoordinateArrayN({3.0,4.0,0.0});

	vec4_coord={vec4.get_X(),vec4.get_Y(),vec4.get_Z()};

	vec5 =  Vector.ByCoordinateArrayN({3.0,4.0,0.0},true); 

	vec5_coord={vec5.get_X(),vec5.get_Y(),vec5.get_Z()};

	



	is_same = vec.Equals(vec);// same vec

	vec2=  Vector.ByCoordinates(1.0,2.0,0.0);

	is_same2 = vec.Equals(vec2);// different vec

	

	

	vec3 =  Vector.ByCoordinates(1.0,0.0,0.0,true); 

	is_parallel1 = vec.IsParallel(vec); //same vec

	vec4=  Vector.ByCoordinates(3.0,0.0,0.0);	

	is_parallel2 = vec3.IsParallel(vec4);//parallel

	vec5 =  Vector.ByCoordinates(3.0,4.0,5.0); //non parallel

	is_parallel3 = vec.IsParallel(vec5);



	vec6 =  Vector.ByCoordinates(0.0,1.0,0.0);

	vec7 =  Vector.ByCoordinates(1.0,0.0,0.0);



	is_perp1 = vec6.IsPerpendicular(vec7);//same vec

	is_perp2 = vec6.IsPerpendicular(vec5);//diff vec



	dotProduct=vec2.Dot(vec2);

	vec8 =  Vector.ByCoordinates(1.0,0.0,0.0,false);

	vec9 =  Vector.ByCoordinates(0.0,1.0,0.0,false);

	crossProduct=vec8.Cross(vec9);

	cross_X=crossProduct.get_X();

	cross_Y=crossProduct.get_Y();

	cross_Z=crossProduct.get_Z();



	newVec=vec5.Scale(2.0);//single

	newVec_X=newVec.get_X();

	newVec_Y=newVec.get_Y();

	newVec_Z=newVec.get_Z();





	coord_Vec=    vec.ComputeGlobalCoords(1,2,3);

	



	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT022_Array_Marshal()
        {
            string code = @"
import (Dummy from ""ProtoTest.dll"");



dummy = Dummy.Dummy();

arr = {0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0};



sum_1_10 = dummy.SumAll(arr);

twice_arr = dummy.Twice(arr);



	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT022_Associative_Class_Constructor_AssignUserDefineProperties()
        {
            string code = @"
class MyPoint

    

{     

    X: var;

    Y: var;

    constructor Create(x : double, y : double)

        {

        X = x;

        Y = y;

        }  

}



class MyLine

    {

    Start: MyPoint;

    End: MyPoint;

    constructor Create(start : MyPoint, end : MyPoint)

        {

        Start = start;

        End = end;

        }



    }

    p1 = MyPoint.Create(10.2,10.1);

	p2 = MyPoint.Create(-10.2, -10.1);

	l = MyLine.Create(p1,p2);

	

	lsX = l.Start.X;

	lsY = l.Start.Y;



	leX = l.End.X;

	leY = l.End.Y;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT022_CountTrue_ImperativeAssociative()
        {
            string code = @"
[Imperative]

{

	a1 = {true,0,1,1.0,null};

	a2 = {false, CountTrue(a1),0.0};

	a3 = a1;

	[Associative]

	{

		a1 = {true,{true}};

		a4 = a2;

		a2 = {true};

		b = CountTrue(a4);//1

	}

	

	c = CountTrue(a3);//1

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT022_Defect_1457740()
        {
            string code = @"
import (""basicImport1.ds"");

import (""basicImport3.ds"");



arr1 = { 1, 3, 5 };

temp = Scale( arr1, a );

a = a;

b = 2 * a;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT022_Defect_1459905()
        {
            string code = @"
class A

{

    X : int;



	constructor A(x : int)

	{

	    X = x; 

	}

}



a = A.A(1);

a = a.X;









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT022_Defect_1459905_2()
        {
            string code = @"
class B

{ 

	x3 : int ;

		

	constructor B(a) 

	{	

		x3 = a;

	}

	def foo ( )

	{

		return = x3;

	}

	

}



class A extends B

{ 

	x1 : int ;

	

	

	constructor A(a1,a2) : base.B(a2)

	{	

		x1 = a1; 				

	}



	def foo1 ( )

	{

		return = x1;

	}	

}





a1 = A.A( 1, 2 );

a1 = a1.foo(); //works fine











";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT022_Defect_1459905_3()
        {
            string code = @"
class B

{ 

	x3 : int ;

		

	constructor B(a) 

	{	

		x3 = a;

	}

	

}

def foo ( b1 : B )

{

    return = b1.x3;

}

b1 = B.B( 1 );

b1 = foo(b1); 











";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT022_Defect_1459905_4()
        {
            string code = @"
class B

{ 

	x3 : int ;

		

	constructor B(a) 

	{	

		x3 = a;

	}

	

}



class B2

{ 

	x3 : int ;

		

	constructor B2(a) 

	{	

		x3 = a;

	}

	

}



def foo ( b1 : B )

{

    return = b1.x3;

}

b1 = B.B( 1 );

x = b1.x3;

b1 = B2.B2( 2 );

y = x;











";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT022_LanguageBlockScope_DeepNested_AIA_Function()
        {
            string code = @"
[Associative]

{

	def foo : int(a : int, b : int)

	{

		return = a - b;

	}

	[Imperative]	

	{

		x_1 = 20;

		y_1 = 10;

		z_1 = foo (x_1, y_1);

	

	

	[Associative]

		{

			x_2 = 100;

			y_2 = 100;

			z_2 = foo (x_2, y_2);

			

		}

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT023_Associative_Class_Constructor_CallingAFunction()
        {
            string code = @"


def Divide : double (a : double, b : double)

{

	return = (a+b)/2;

}



class MyPoint

    

{     

    X: var;

    Y: var;

    constructor Create(x : double, y : double)

        {

        X = Divide(x+y, x+y);

        Y = Divide(x-y, x-y);

        }  

}





    p = MyPoint.Create(10.2,10.1);

	pX = p.X;

	pY = p.Y;

	

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT023_CountFalse_IfElse()
        {
            string code = @"
result =

[Imperative]

{

	arr1 = {false,{{{{false}}}},null,0};

	arr2 = {{true},{false},null,null};

	if(CountFalse(arr1) > 1)

	{

		arr2 = arr1;

	}

	return = CountFalse(arr2);//2

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT023_Defect_1459789()
        {
            string code = @"
class MyPoint 

{

	// define general system of dependencies	

	x : double = 1; 

    y : double = 2;

    public constructor ByXYcoordinates(xValue : double )

    {

		x = xValue; 			

		y = x;

	}	

	// add 'incremental' modifiers	

	def incrementX(xValue : double) 

	{

	    return = ByXYcoordinates(x + xValue);

	}

	

}



a 		 = MyPoint.ByXYcoordinates(1.0);			        

aY 		  = a.y;

aX 	          = a.x;



// test update

a 		  = MyPoint.ByXYcoordinates(2.0);

// expected : aY = 2.0 and aX = 2.0

// recieved : aY = 1.0 and aX = 1.0















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT023_Defect_1459789_10()
        {
            string code = @"
class A 

{    

    a1: var;    

    a2 : double[];    

    constructor A ( ax: int, b : double[] )    

    {        

        a1 = ax;    

	a2 = b;    

    }

    def create ()

    {

        temp1 = [Imperative]

	{

	    return = A.A ( 2, { 0.0, 0.0 } );

	}

	return = temp1;

    }

}



class B extends A

{    

    b1  :bool;    

    b2: int;    

    constructor B ( ax: int, b : double[], c : bool, d : int ) : base.A ( ax, b )    

    {        

        b1 = c;    

	b2 = d;    

    }

}



a = { 1.0, 2.0 };

b1 = B.B ( 1, a, true, 1 );

test1 = b1.a2[0];

a = { { 2.0, 2.0 } => a1;

      a1[0] + 1 => a2;

      { a2, a2 } ;

    }







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT023_Defect_1459789_2()
        {
            string code = @"
class MyPoint 

{

    // define general system of dependencies	

    x : double = 1; 

    y : double = 2;

    public constructor ByXYcoordinates(xValue : double )

    {

	x = xValue; 			

	y = x;

    }	

    // add 'incremental' modifiers	

    def incrementX(xValue : double) 

    {

	return = ByXYcoordinates(x + xValue);

    }	

}



a 		  = MyPoint.ByXYcoordinates(1.0);			        

aY 		  = a.y;

aX 	          = a.x;

// test update     	    

a		  = a.incrementX(3.0);

















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT023_Defect_1459789_3()
        {
            string code = @"
class A 

{    

    a1: var;    

    a2 : double[];    

    constructor A ( a: int, b : double[] )    

    {        

        a1 = a;    

	a2 = b;    

    }

}



class B extends A

{    

    b1  :bool;    

    b2: int;    

    constructor B ( a: int, b : double[], c : bool, d : int ) : base.A ( a, b )    

    {        

        b1 = c;    

	b2 = d;    

    }

}



b1 = B.B ( 1, {1.0, 2.0}, true, 1 );

test1 = b1.a2[0];

b1.a2[0] = b1.a2[1];



















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT023_Defect_1459789_4()
        {
            string code = @"
class A 

{    

    a1: var;    

    a2 : double[]..[];    

    constructor A ( a: int, b : double[]..[] )    

    {        

        a1 = a;    

	a2 = b;    

    }

}



class B extends A

{    

    b1  :bool;    

    b2: int;    

    constructor B ( a: int, b : double[]..[], c : bool, d : int ) : base.A ( a, b )    

    {        

        b1 = c;    

	b2 = d;    

    }

}



a = { 1.0, 2.0 };

b1 = B.B ( 1, a, true, 1 );

test1 = b1.a2[0];

a = { { 1.0, 2} , 3 };





















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT023_Defect_1459789_5()
        {
            string code = @"
class A 

{    

    a1: var;    

    a2 : double[]..[];    

    constructor A ( a: int, b : double[]..[] )    

    {        

        a1 = a;    

	a2 = b;    

    }

    def create ()

    {

        temp1 = A.A ( 2, { 0.0, 0.0 } );

	return = temp1;

    }

}



class B extends A

{    

    b1  :bool;    

    b2: int;    

    constructor B ( a: int, b : double[]..[], c : bool, d : int ) : base.A ( a, b )    

    {        

        b1 = c;    

	b2 = d;    

    }

}



a = { 1.0, 2.0 };

b1 = B.B ( 1, a, true, 1 );

test1 = b1.a2[0];

a = { { 1.0, 2} , 3 };

b1 = b1.create();

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT023_Defect_1459789_6()
        {
            string code = @"
class A 

{    

    a1: var;    

    a2 : double[]..[];    

    constructor A ( a: int, b : double[]..[] )    

    {        

        a1 = a;    

	a2 = b;    

    }

    def create ()

    {

        temp1 = [Imperative]

	{

	    return = A.A ( 2, { 0.0, 0.0 } );

	}

	return = temp1;

    }

}



class B extends A

{    

    b1  :bool;    

    b2: int;    

    constructor B ( a: int, b : double[]..[], c : bool, d : int ) : base.A ( a, b )    

    {        

        b1 = c;    

	b2 = d;    

    }

}



a = { 1.0, 2.0 };

b1 = B.B ( 1, a, true, 1 );

test1 = b1.a2[0];

a = { { 1.0, 2} , 3 };

b1 = b1.create();

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test, Ignore]
        public void DebugEQT023_Defect_1459789_7()
        {
            string code = @"
class A 

{    

    a1: var;    

    a2 : double[];    

    constructor A ( ax: int, b : double[] )    

    {        

        a1 = ax;    

	a2 = b;    

    }

    def create ()

    {

        temp1 = [Imperative]

	{

	    return = A.A ( 2, { 0.0, 0.0 } );

	}

	return = temp1;

    }

}



class B extends A

{    

    b1  :bool;    

    b2: int;    

    constructor B ( ax: int, b : double[], c : bool, d : int ) : base.A ( ax, b )    

    {        

        b1 = c;    

	b2 = d;    

    }

}



a = { 1.0, 2.0 };

b1 = B.B ( 1, a, true, 1 );

test1 = b1.a2[0];

[Imperative]

{

        a = {  3.0, 2 };

	b1 = b1.create();

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        // Comment Jun: Aparajit to address why the testcase hangs NUnit whereas a normal run catches the cycle
        [Test, Ignore]
        public void DebugEQT023_Defect_1459789_8()
        {
            string code = @"
class A 

{    

    a1: var;    

    a2 : double[];    

    constructor A ( ax: int, b : double[] )    

    {        

        a1 = ax;    

	a2 = b;    

    }

    def create ()

    {

        temp1 = [Imperative]

	{

	    return = A.A ( 2, { 0.0, 0.0 } );

	}

	return = temp1;

    }

}



class B extends A

{    

    b1  :bool;    

    b2: int;    

    constructor B ( ax: int, b : double[], c : bool, d : int ) : base.A ( ax, b )    

    {        

        b1 = c;    

	b2 = d;    

    }

}

def foo ( x : B )

{

    return = x.create();

}

a = { 1.0, 2.0 };

b1 = B.B ( 1, a, true, 1 );

test1 = b1.a2[0];

[Imperative]

{

	a = { { 1.0, 2} , 3 };

        b1 = foo ( b1 );

	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT023_Defect_1459789_9()
        {
            string code = @"
class A 

{    

    a1: var;    

    a2 : double[];    

    constructor A ( ax: int, b : double[] )    

    {        

        a1 = ax;    

	a2 = b;    

    }

    def create ()

    {

        temp1 = [Imperative]

	{

	    return = A.A ( 2, { 0.0, 0.0 } );

	}

	return = temp1;

    }

}



class B extends A

{    

    b1  :bool;    

    b2: int;    

    constructor B ( ax: int, b : double[], c : bool, d : int ) : base.A ( ax, b )    

    {        

        b1 = c;    

	b2 = d;    

    }

}

def foo (  )

{

    b1 = b1.create();

    return = null;

}

a = { 1.0, 2.0 };

b1 = B.B ( 1, a, true, 1 );

test1 = b1.a2[0];

dummy = foo (  );

";
            //Assert.Fail("");
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT023_LanguageBlockScope_AssociativeParallelImperative_Function()
        {
            string code = @"
[Associative]

{

	def foo : int(a : int, b : int)

	{

		return = a - b;

	}

	 

	a = 10;

	

}



[Imperative]	

{

	x = 20;

	y = 0;

	z = foo (x, y);

	

}
";
            //Assert.Fail("");
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT024_Associative_Class_Constructor_CallingAnImperativeFunction()
        {
            string code = @"
[Imperative]

{

	def Greater : double (a : double, b : double)

	{

		if (a > b)

			return = a;

		//else

			return = b;

	}

}



class MyPoint    

{     

    X: var;

    Y: var;

    constructor Create(x : double, y : double)

    {

        X = Greater(x,y);

        Y = Greater(x,y);

    }  

}





p1 = MyPoint.Create(20.0,30.0);

p2 = MyPoint.Create(-20.0,-30.0);

p1X = p1.X;

p1Y = p1.Y;

p2X = p2.X;

p2Y = p2.Y;

	

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT024_CountFalse_ForLoop()
        {
            string code = @"
result = 

[Imperative]

{

	a = {1,3,5,7,{}};

	b = {null,null,{0,false}};

	c = {CountFalse({{false},null})};

	

	d = {a,b,c};

	j = 0;

	e = {};

	

	for(i in d)

	{

		e[j]= CountFalse(i);

		j = j+1;

	}

	return  = e;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT024_Defect_1459470()
        {
            string code = @"
a = 0..4..1;

b = a;

c = b[2];

a = 10..14..1;

b[2] = b[2] + 1;

a[2] = a[2] + 1;

x = a;



					        





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT024_Defect_1459470_2()
        {
            string code = @"
class A

{

	a : var;

	b : var;

	c : var;

	constructor A ()

	{



		a = 0;

		b = a;

		c = b + 1;

		a = 1;	

	}

}



x = A.A();

a1 = x.a;

b1 = x.b;

c1 = x.c;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT024_Defect_1459470_3()
        {
            string code = @"
def foo ()

{

	a = 0..4..1;

	b = a;

	c = b[2];

	a = 10..14..1;

	b[2] = b[2] + 1;

	a[2] = a[2] + 1;

	return = true;

	

}



a :int[];

b : int[];

c : int;



test = foo();



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT024_Defect_1459470_4()
        {
            string code = @"
a = {1,2,3,4};

b = a;

c = b[2];

d = a[2];

a[0..1] = {1, 2};

b[2..3] = 5;



	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT024_LanguageBlockScope_ImperativeParallelAssociative_Function()
        {
            string code = @"
[Imperative]

{

	def foo : int(a : int, b : int)

	{

		return = a - b;

	}

	 

	a = 10;

	

}



[Associative]	

{

	x = 20;

	y = 0;

	z = foo (x, y);

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT025_Associative_Class_Constructor_CallingAnotherConstructor()
        {
            string code = @"
class MyPoint

    

{     

    X: var;

    Y: var;

    constructor Create(x : double, y : double)

        {

        X = x;

        Y = y;

        }  

}



class MyLine

    {

    Start: MyPoint;

    End: MyPoint;

    constructor Create(x1: double, y1 : double, x2: double, y2: double)

        {

		p1 = MyPoint.Create(x1,y1);

		p2 = MyPoint.Create(x2,y2);

        Start = p1;

        End = p2;

        }

    }



	l = MyLine.Create(1.0, 2.0, -1.0, -2.0);

	

	lsX = l.Start.X;

	lsY = l.Start.Y;



	leX = l.End.X;

	leY = l.End.Y;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT025_CountFalse_WhileLoop()
        {
            string code = @"
result = 

[Imperative]

{

	a = {1,3,5,7,{0}};//0

	b = {1,null,false};//1

	c = {{true}};//0

	

	d = {a,b,c};

	

	i = 0;

	j = 0;

	e = {};

	

	while(i<Count(d))

	{

		e[j]= CountFalse(d[i]);

		i = i+1;

		j = j+1;

	}

	return = e ;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT025_Defect_1459704()
        {
            string code = @"
a = b;

b = 3;

c = a;





					        





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT025_Defect_1459704_2()
        {
            string code = @"
class A 

{

    a : int;

    b : int;

    constructor A ( a1:int)

    {

        a = b + 1;

	b = a1;

    }

}



def foo ( a1 : int)

{

    b = 0;	

    a = b + 1;

    b = a1;

    return  = a ;

}



p = A.A(1);

a1 = p.a;

a2 = foo(10);





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT025_LanguageBlockScope_AssociativeParallelAssociative_Function()
        {
            string code = @"
[Associative]

{

	def foo : int(a : int, b : int)

	{

		return = a - b;

	}

	 

	a = 10;

	

}



[Associative]	

{

	x = 20;

	y = 0;

	z = foo (x, y);

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT026_Associative_Class_Constructor_BaseConstructorAssignProperties()
        {
            string code = @"
class MyPoint

    

    {

    

    X: double;

    Y: double;

    

    constructor CreateByXY(x : double, y : double)

        

        

        {

        X = x;

        Y = y;

        

        }   

    }

    

class MyNewPoint extends MyPoint

    {

    

    Z : double;

    

    constructor Create (x: double, y: double, z : double) : base.CreateByXY(x, y)

        {

         Z = z;

        }

    }

   

test = MyNewPoint.Create (10, 20, 30);

x = test.X;

y = test.Y;

z = test.Z;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT026_CountFalse_Function()
        {
            string code = @"
def foo(x:var[]..[])

{

	a = {};

	i = 0;

	[Imperative]

	{

		for(j in x)

		{

			a[i] = CountFalse(j);

			i = i+1;

		}

	}

	return  = a;

}



b = {



{null},//0

{1,2,3,{false}},//1



{0},//0

{false, false,0,false, null},//3

{x, null}//0



};

result = foo(b);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT026_Defect_1459631()
        {
            string code = @"
class A

{

    x : int = 1;

	y : int = x + 1;	

	constructor A ()

	{

	    x = 2;		

	}

}



a1 = A.A();

t1 = a1.x;

t2 = a1.y;





					        





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT026_Defect_1459631_2()
        {
            string code = @"
def foo (a ) = a * 2;

class A

{

        x : int = foo ( 1 ) ;

	y : int = x + foo ( x) ;

        z : int = x + y;	

	w :int = 1;

	constructor A ()

	{

	    w = 4;		

	}

}



a1 = A.A();

t1 = a1.x;

t2 = a1.y;

t3 = a1.z;

t4 = a1.w;



					        





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT026_Defect_1459631_3()
        {
            string code = @"
def foo (a ) = a * 2;

def foo2 (a ) 

{

    b = { a, a, a};

    return = b;

        

}



class A

{

        x : int   = foo ( 1 ) ;

	y : int   = x + foo ( x ) ;

        z : int[] = foo2 ( x + y );	

	w : int   = z[0];

	constructor A ()

	{

	    //w = 4;		

	}

}



a1 = A.A();

t1 = a1.x;

t2 = a1.y;

t3 = a1.z;

t4 = a1.w;



					        





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT026_LanguageBlockScope_ImperativeParallelImperative_Function()
        {
            string code = @"
[Imperative]

{

	def foo : int(a : int, b : int)

	{

		return = a - b;

	}

	 

	a = 10;

	

}



[Imperative]	

{

	x = 20;

	y = 0;

	z = foo (x, y);

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT027_Associative_Class_Constructor_BaseConstructorWithSameName()
        {
            string code = @"
class MyPoint

    

    {

    

    X: double;

    Y: double;

    

    constructor Create(x : double, y : double)

        

        

        {

        X = x;

        Y = y;

        

        }   

    }

    

class MyNewPoint extends MyPoint

    {

    

    Z : double;

    

    constructor Create (x: double, y: double, z : double) : base.Create(x, y)

        {

         Z = z;

        }

    }

   

test = MyNewPoint.Create (10.1, 20.2, 30.3);

z = test.Z;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT027_CountFalse_Class()
        {
            string code = @"
class C

{

	a : int;

	constructor C(x:var[]..[])

	{

		a = CountFalse(x);

	}

	

	def foo(y:var[]..[])

	{

		return = CountFalse(y)+ a;

	}

}



b = {0.000, null, false,{{false},v}};//2

c = C.C(b);

m = c.a;//2

n = c.foo(b);//4

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT027_Defect_1460741()
        {
            string code = @"
class A

{ 

	y : int[];

	

	

	constructor A ()

	{

	y={1,2};	      	

	}	

}

class B extends A

{

	constructor B()

	{

	y={3,4};	



	}



}



a1 = B.B();

x1 = a1.y;//null



x3 = [Imperative]

{

    a2 = B.B();

    x2 = a2.y;

    return = x2;

}









					        





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT027_Defect_1460741_2()
        {
            string code = @"
class C

{ 

	c1 : double[];

	

	constructor C ()

	{

	    c1 = {1.0,2.0};            	    

	}	

}



class A

{ 

	y : int[];

	x : C;

	

	constructor A ()

	{

	    y={1,2};

            x = false;   

	}	

}

class B extends A

{

	constructor B()

	{

	    y={3,4};   

	    x = C.C();	    

	}



}



a1 = B.B();

x1 = a1.y;

x2 = a1.x.c1;



x3 = [Imperative]

{

    x4 = a1.x.c1;

    return = x4;

}









					        





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT027_LanguageBlockScope_MultipleParallelLanguageBlocks_AIA_Function()
        {
            string code = @"
[Associative]

{

	def foo : int(a : int, b : int)

	{

		return = a - b;

	}

	 

	a = 10;

	

}



[Imperative]	

{

	x_1 = 20;

	y_1 = 0;

	z_1 = foo (x_1, y_1);

	

}



[Associative]

{

	x_2 = 20;

	y_2 = 0;

	z_2 = foo (x_2, y_2);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT028_Associative_Class_Property_DefaultAssignment()
        {
            string code = @"


	class MyPoint

	{

		X : double = 0;

		Y : double = 0;

		Z : double = 0;

                            

        constructor ByXY (x : double, y : double)

        {

			X = x;

			Y = y;

        }

	

    }

	



    pt1 = MyPoint.ByXY (1,2);



	xPt1 = pt1.X;

	yPt1 = pt1.Y;

	zPt1 = pt1.Z;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT028_CountFalse_Inline()
        {
            string code = @"
[Imperative]

{

def foo(x:var[])

{

	if(CountFalse(x) > 0)

		return = true;

	return = false;

}

a = {null,0};//0

b = {null,20,30,null,{10,0},false,{true,0,{true,{false},5,2,true}}};//2

c = {1,2,foo(b)};



result = CountFalse(c) > 0 ? CountFalse(a):CountFalse(b);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT028_LanguageBlockScope_MultipleParallelLanguageBlocks_IAI_Function()
        {
            string code = @"
[Imperative]

{

	def foo : int(a : int, b : int)

	{

		return = a - b;

	}

	 

	a = 10;

	

}



[Associative]	

{

	x_1 = 20;

	y_1 = 0;

	z_1 = foo (x_1, y_1);

	

}



[Imperative]

{

	x_2 = 20;

	y_2 = 0;

	z_2 = foo (x_2, y_2);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT028_Modifier_Stack_Simple()
        {
            string code = @"
a = {

     2 ;

    +4;

    +3;                                

} //expected : a = 9; received : 13

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT029_Associative_Class_Property_AccessModifier()
        {
            string code = @"
class A

{

    private x:int;



    constructor A()

    {

        x = 3;

    }

}



a = A.A();

// compile error!

t = a.x;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT029_CountFalse_RangeExpression_01()
        {
            string code = @"
result = 

[Imperative]

{

	a1 = {0,false, null};//1

	a2 = 8;

	a3 = {2,{false,{false,1}},{false,x, true}};//3

	a = CountFalse(a1)..a2..CountFalse(a3);//{1,4,7}

	

	return = CountFalse(a);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT029_CountFalse_RangeExpression_02()
        {
            string code = @"
result = 

[Imperative]

{

	a1 = {1,false, null};//1

	a2 = 8;

	a3 = {2,{false,{false,1}},{false,x, true}};//3

	a = {1.0,4.0,7.0};

	//a = CountFalse(a1)..a2..#CountFalse(a3);//{}



	return = CountFalse(a);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT029_Defect_1460139_Update_In_Class()
        {
            string code = @"
X = 1;

Y = X + 1;

X = X + 1;

X = X + 1; // this line causing the problem

test = X + Y;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT029_LanguageBlockScope_ParallelInsideNestedBlock_AssociativeNested_II_Function()
        {
            string code = @"
[Associative]

{

	def foo : int(a : int, b : int)

	{

		return = a - b;

	}

	 

	[Imperative]

	{

	x_I1 = 50;

	y_I1 = 50;

	z_I1 = foo (x_I1, y_I1);

	}

	

	x_A1 = 30;

	y_A1 = 12;

	z_A1 = foo (x_A1, y_A1);

	

	[Imperative]

	{

	x_I2 = 0;

	y_I2 = 12;

	z_I2 = foo (x_I2, y_I2);

	}

	

	x_A2 = 0;

	y_A2 = -10;

	z_A2 = foo (x_A2, y_A2);

	

	

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_Arithmatic_List_And_List_Same_Length()
        {
            string code = @"
list1 = { 1, 4, 7, 2};

list2 = { 5, 8, 3, 6 };



list3 = list1 + list2; // { 6, 12, 10, 8 }

list4 = list1 - list2; // { -4, -4, 4, -4}

list5 = list1 * list2; // { 5, 32, 21, 12 }

list6 = list2 / list1; // { 5, 2, 0, 3 }

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_Assignment_Slicing_Modify_Arguments()
        {
            string code = @"
def foo ( a , b )

{

	a = a + 1;

	b = b + 3;



	return = { a , b };

}



	{a , b} = foo ( 1 , 2 );

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_AssociativeBlock_Negative()
        {
            string code = @"
[Associative]

{

    i = 0;

    temp = 1;

    while ( i <= 5)

	{

	    temp = temp + 1;

         i = i + 1;

    }

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_Class_In_Various_Nested_Scopes()
        {
            string code = @"
class Dummy

{ 

	x : var;  

	constructor Dummy () 

	{	

		x = 2;	 

	}

}



c1 = [Imperative]

{

	a = Dummy.Dummy();

	b = [Associative]

	{

	    return = Dummy.Dummy();

	}

	c = a.x + b.x;

	return = c;

}



c2 = [Associative]

{

	a = Dummy.Dummy();

	b = [Imperative]

	{

	    return = Dummy.Dummy();

	}

	c = a.x + b.x;

	return = c;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_Collection_Assignment_Associative()
        {
            string code = @"
[Associative]

{

	a = { {1,2}, {3,4} };

	

	a[1] = {-1,-2,3};

	

	c = a[1][1];

	

	d = a[0];

	

	b = { 1, 2 };

	

	b[0] = {2,2};



	e = b[0];

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_Function_In_Imp_Scope()
        {
            string code = @"
[Imperative]

{

    def foo : double( a:double, b : int )

    {

	   return = a * b;

	}

	

    a = foo( 2.5, 2 );

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_GlobalFunctionWithDefaultArg()
        {
            string code = @"
def foo:double(x:int, y:double = 2.0)

{

	return = x + y;

}



a = foo;

b = foo(3); //b=5.0;

c = foo(2, 4.0); //c = 6.0
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_IfElseIf()
        {
            string code = @"
[Imperative]

{

 a1 = 7.5;

 

 temp1 = 10;



 

 if( a1>=10 )

 {

 temp1 = temp1 + 1;

 }

 

 elseif( a1<2 )

 {

 temp1 = temp1 + 2;

 }



 elseif(a1<10)

 {

 temp1 = temp1 + 3;

 }

 

  

 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_SampleTestUsingCodeFromExternalFile__2_()
        {
            string code = @"
[Associative]

{

    variable = 5;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_SampleTestUsingCodeFromExternalFile()
        {
            string code = @"
[Imperative]

{

    variable = 5;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_SimpleRangeExpression()
        {
            string code = @"
[Imperative]

{

	a15 = 1/2..1/4..-1/4;

	a16 = (1/2)..(1/4)..(-1/4);

	a18 = 1.0/2.0..1.0/4.0..-1.0/4.0;

	a19 = (1.0/2.0)..(1.0/4.0)..(-1.0/4.0);

	a20 = 1..3*2; 

	//a21 = 1..-6;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_String_Not()
        {
            string code = @"
a = ""a"";

result = 

[Imperative]

{

	if(a)

	{

		return = false;

	}else if(!a)

	{

		return = false;

	}

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_TestAssocInsideImp()
        {
            string code = @"
[Imperative]

{

    x = 5.1;

    z = y;

    w = z * 2;

    [Associative]

    {

        y = 5;

        z = x;

        x = 35;

        i = 3;

    }

    f = i;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_TestGCEndofIfBlk()
        {
            string code = @"
import(""DisposeVerify.ds"");



DisposeVerify.x = 1;

a1 = A.A();

[Imperative]

{

    m = 10;

    if (m > 10)

        a2 = A.A();

    else

        a3 = A.A();

    a4 = A.A();

}



v = DisposeVerify.x; // 3
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_TestNegativeUsage_InAssociativeBlock_Negative()
        {
            string code = @"
[Associative]

{

	a = { 2, 3 };

	x = 1;

	

	for( y in a )

	{

		x = x + 1;

	}

}

	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_Update_Function_Argument_Across_Language_Scope()
        {
            string code = @"
a = 1;

def foo ( a1 : double )

{

    return = a1 + 1;

}

b = foo ( c ) ;

c = a + 1;



[Imperative]

{

    a = 2.5;

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT02_WhileBreakContinue()
        {
            string code = @"
[Imperative]

{

    x = 0;

    sum = 0;



    while (x <= 10) 

    {

        x = x + 1;

        if (x >= 5)

            break;

        

        y = 0;

        while (true) 

        {

            y = y + 1;

            if (y >= 10)

                break;

        }

        // y == 10 



        sum = sum + y;

    }

    // sum == 40 

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT030_Associative_Class_Property_AccessModifier()
        {
            string code = @"
class A

{

    private x:int;



    constructor A()

    {

        x = 3;

    }

}



class B extends A

{

    def foo()

    {

        return = x;

    }

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT030_CountFalse_Replication()
        {
            string code = @"


def foo(x:int)

{

	return = x +1;

}



a = {false,{false},0};//2

b = {CountFalse({a[2]})};

c = {{{false}}};//1

d = {{false},{false,{true,false,0}}};//3



arr = {CountFalse(a),CountFalse(b),CountFalse(c),CountFalse(d)};



result = foo(arr);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT030_Defect_1467236_Update_In_Class()
        {
            string code = @"
class Parent

{

A : var;

B : var;

C : var;



constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



class Child extends Parent

{

constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



def modify(tmp : Child) // definition with inherited class



{



tmp.A = tmp.A +1;

tmp.B = tmp.B +1;

tmp.C = tmp.C +1;

return=true;



}





oldPoint = Parent.Create( 1, 2, 3 );

derivedpoint = Child.Create( 7,8,9 );

test1 = modify( oldPoint ); // call function with object of parent class

test2 = modify( derivedpoint );

x1 = oldPoint.A;

x2 = derivedpoint.B;

//expected : x2 = 9

//received : cyclic dependency 

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT030_Defect_1467236_Update_In_Class_2()
        {
            string code = @"
class Parent

{

A : var;

B : var;

C : var;



	constructor Create( x:int, y:int, z:int )

	{

		A = x;

		B = y;

		C = z;

	}

}



class Child extends Parent

{

	constructor Create( x:int, y:int, z:int )

	{

		[Imperative]

		{

			A = x;

			B = y;

			C = z;

		}

	}

}



def modify(tmp : Child) // definition with inherited class



{

	[Imperative]

	{

		tmp.A = tmp.A +1;

		tmp.B = tmp.B +1;

		tmp.C = tmp.C +1;

		return=true;

	}

	return = true;

}



[Imperative]

{



	oldPoint = Parent.Create( 1, 2, 3 );

	derivedpoint = Child.Create( 7,8,9 );

	test1 = modify( oldPoint ); // call function with object of parent class

	test2 = modify( derivedpoint );

	x1 = oldPoint.A;

	x2 = derivedpoint.B;

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT030_LanguageBlockScope_ParallelInsideNestedBlock_ImperativeNested_AA()
        {
            string code = @"
[Imperative]

{

	def foo : int(a : int, b : int)

	{

		return = a - b;

	}

	 

	[Associative]

	{

		x_A1 = 30;

		y_A1 = 12;

		z_A1 = foo (x_A1, y_A1);

	

	}

	

	x_I1 = 50;

	y_I1 = 50;

	z_I1 = foo (x_I1, y_I1);

	

	[Associative]

	{

		x_A2 = 0;

		y_A2 = -10;

		z_A2 = foo (x_A2, y_A2);

	}

	

	x_I2 = 0;

	y_I2 = 12;

	z_I2 = foo (x_I2, y_I2);

	

	

	

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT031_Associative_Class_Property_AccessModifier()
        {
            string code = @"
class A

{

    protected x:int;



    constructor A()

    {

        x = 3;

    }

}



class B extends A

{

    constructor B()

    {

        x = 4;

    }



    def foo:int()

    {

        return = x;

    }

}



b = B.B();

x = b.foo();

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT031_CountFalse_DynamicArray()
        {
            string code = @"
result = 

[Imperative]

{



	a1 = {

	{{false},{}},

	{@a,2,{true}},

	{@a,@b,@null},//{null,null,null}

	{null}

	};

	a2 = {};



	i = 0;

	j = 0; 

	while(i < CountFalse(a1))

	{

		if(CountFalse(a1[i])>0)

		{

			a2[j] = a1[i];

			j = j+1;

			

		}

		i = i+1;

	}

	return = CountFalse(a2);

} 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT031_Defect_1450594()
        {
            string code = @"
[Imperative]

{

   a = 2;

    [Associative]

    {

        

        i = 3;

    }

    f = i;

}



[Associative]

{



	def foo1 ( i )

	{

		x = 1;

		return = x;

	}

	p = x;

	q = a;



}

y = 1;

[Imperative]

{



   def foo ( i )

   {

		x = 2;

		if( i < x ) 

		{

		    y = 3;

			return = y * i;

		}

		return = y;

	}

	x = y;

	y1 = foo ( 1 );

	y2 = foo ( 3 );

	z = x * 2;

	

}









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT032_CountFalse_ModifierStack()
        {
            string code = @"
x = {true, 0,{1},false,x,null,{false}};

m = 2.56;

a = {

	CountFalse(x) => a1; //2

	CountFalse(x[6]) => a2;//1

	CountFalse(x[CountFalse(x)]);//0

	m => a4;

	CountFalse({a4}) => a5;//0

	}

	x = {};

	result = {a1,a2,a3,a4,a5};

	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT032_Cross_Language_Variables()
        {
            string code = @"


a = 5;

b = 2 * a;



[Imperative] {

	sum = 0;

	arr = 0..b;

	for (i  in arr) {

		sum = sum + 1;

	}

}





a = 10;



// expected: sum = 21

// result: sum = 11
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT033_CountFalse_ImperativeAssociative()
        {
            string code = @"
[Imperative]

{

	a1 = {false,0,1,1.0,null};

	a2 = {true, CountFalse(a1),0.0};

	a3 = a1;

	[Associative]

	{

		a1 = {false,{false}};

		a4 = a2;

		a2 = {false};

		b = CountFalse(a4);//1

	}

	

	c = CountFalse(a3);//1

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT033_Wrong_Spelling_Of_Language_Block()
        {
            string code = @"
[associative]

{

    a= 1;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT034_AllFalse_IfElse()
        {
            string code = @"
a = {false, false};//true

b = {{false}};//true

c = {false, 0};//false

result = {};



[Imperative]

{

	if(AllFalse(a)){

		a[2] = 0;

		result[0] = AllFalse(a);//false

	} 

	if(!AllFalse(b)){

		

		result[1] = AllFalse(b);//false

	}else

	{result[1]= null;}

	if(!AllFalse(c)){

		result[2] = AllFalse(c);

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT035_AllFalse_ForLoop()
        {
            string code = @"




result = 

[Imperative]

{

	a = {false,false0,0,null,x};//false

	b = {false,false0,x};//false

	c = {};//false

	d = {{}};//false

	

	h = {

	{{0}},

	{false}

};





	e = {a,b ,c ,d,h};

	f = {};

	j = 0;



	for(i in e)

	{	

		if(AllFalse(i)!=true){

			f[j] = AllFalse(i);

			j = j+1;

		}

		

	}

return = f;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT036_1_Null_Check()
        {
            string code = @"
result = null;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT036_AllFalse_WhileLoop()
        {
            string code = @"


result = 

[Imperative]

{

	a = {false,false0,0,null,x};//false

	b = {false,false0,x};//false

	c = {};//false

	d = {{}};//false



	e = {a,b ,c ,d};

	i = 0;

	f = {};

	j = 0;



	while(!AllFalse(e[i])&& i < Count(e))

	{	

		if(AllFalse(e[i])!=true){

			f[j] = AllFalse(e[i]);

			j = j+1;

		}

		i = i+1;

		

	}

return = f;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT037_AllFalse_Function()
        {
            string code = @"
def foo( x : bool)

{	

	return = !x;

}



a1 = {0};

a2 = {null};

a3 = {!true};



b = {a1,a2,a3};



result = {foo(AllFalse(a1)),foo(AllFalse(a2)),foo(AllFalse(a3))};//true,true,false

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT038_AllFalse_Class()
        {
            string code = @"
class C

{

	x: var;

	y :int;

	constructor C(b:bool)

	{

		x = b;

		y = 0.0;

	}

	

	def foo(z:var[]..[])

	{

	temp = 

	[Imperative]

		{

			if(AllFalse(z)== x )

			{

				

				return = true;

			}

			else{

		

			return = false;

			}

		}

	    return = temp;

	}

}



c = C.C(true);;

d = c.x;

e = c.y;

g = {false,{false}};

f = c.foo(g);//true



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT039_AllFalse_Inline()
        {
            string code = @"
a1 = {false,{false}};

a = AllFalse(a1);//true

b1 = {null,null};

b = AllFalse(b1);//false

c = AllFalse({b});//t



result = a? c:b;//t
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_Arithmatic_Mixed()
        {
            string code = @"
list1 = { 13, 23, 42, 65, 23 };

list2 = { 12, 8, 45, 64 };



list3 = 3 * 6 + 3 * (list1 + 10) - list2 + list1 * list2 / 3 + list1 / list2; // { 128, 172, 759, 1566 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_Assignment_Slicing_With_Collection()
        {
            string code = @"
def foo ( a:int[] )

{

	a[0] = 0;

	return = a;

}

	a = {1,2,3};

	c = foo ( a  );

	d = c[0];

	e = c[1];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_Class_In_Various_Scopes()
        {
            string code = @"
class Dummy

{ 

	x : var;  

	constructor Dummy () 

	{	

		x = 2;	 

	}

}

a = Dummy.Dummy();

c1 = [Imperative]

{

	b = [Associative]

	{

	    return = a;

	}

	c = a.x + b.x;

	return = c;

}



c2 = [Associative]

{

	b = [Imperative]

	{

	    return = a;

	}

	c = a.x + b.x;

	return = c;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_Collection_Assignment_Nested_Block()
        {
            string code = @"
[Associative]

{

	a = { {1,2,3},{4,5,6} };

	

	[Imperative]

	{

		c = a[0];

		d = a[1][2];

	}

	

	e = c;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_Defect_UndefinedType()
        {
            string code = @"


def foo(x:S)

{

	return = x;

}

b = foo(1);



class C 

{

	fx:M;

	constructor C(x :N)

	{

		fx = x;

	}

	

	def foo(fy : M)

	{

		fx = fy;

		return = fx;

	}



	

}



c = C.C(1);

r1 = c.fx;

r2 = c.foo(2);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_ForLoopBreakContinue()
        {
            string code = @"
[Imperative]

{

    sum = 0;



    for (x in {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13})

    {

        if (x >= 11)

            break;



        sum = sum + x;

    }

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_Function_In_Nested_Scope()
        {
            string code = @"
[Imperative]

{

    def foo : double( a:double, b : int )

    {

	   return = a * b;

	}

	a = 3;

	[Associative]

	{

		a = foo( 2.5, 1 );

	}

	b = 

	[Associative]

	{

		a = foo( 2.5, 1 );

		return = a;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_GlobalFunctionInAssocBlk()
        {
            string code = @"
[Associative]

{

	def foo:double(x:int, y:double = 2.0)

	{

		return = x + y;

	}



	a = foo;

	b = foo(3); //b=5.0;

	c = foo(2, 4.0); //c = 6.0

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_MultipleIfStatement()
        {
            string code = @"
[Imperative]

{

 a=1;

 b=2;

 temp=1;

 

 if(a==1)

 {temp=temp+1;}

 

 if(b==2)  //this if statement is ignored

 {temp=4;}

 

 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_SimpleRangeExpressionUsingCollection()
        {
            string code = @"
[Imperative]

{

	a = 3 ;

	b = 2 ;

	c = -1;

	w1 = a..b..-1 ; //correct  

	w2 = a..b..c; //correct 



	e1 = 1..2 ; //correct

	f = 3..4 ; //correct

	w3 = e1..f; //correct

	w4 = (3-2)..(w3[1][1])..(c+2) ; //correct



	w5 = (w3[1][1]-2)..(w3[1][1])..(w3[0][1]-1) ; //correct

}



/* expected results : 



    Updated variable a = 3

    Updated variable b = 2

    Updated variable c = -1

    Updated variable w1 = { 3, 2 }

    Updated variable w2 = { 3, 2 }

    Updated variable e1 = { 1, 2 }

    Updated variable f = { 3, 4 }

    Updated variable w3 = { { 1, 2, 3 }, { 2, 3, 4 } }

    Updated variable w4 = { 1, 2, 3 }

    Updated variable w5 = { 1, 2, 3 }

*/

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_TestAssignmentToUndefinedVariables_negative__2_()
        {
            string code = @"
[Associative]

{

    a = b;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_TestAssignmentToUndefinedVariables_negative()
        {
            string code = @"
[Imperative]

{

    a = b;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_TestGCEndofLangBlk()
        {
            string code = @"
import(""DisposeVerify.ds"");



DisposeVerify.x = 1;



a1 = A.A();

[Imperative]

{

    a2 = A.A();

    [Associative]

    {

        a3 = a2;

        a4 = A.A();

    }

	a5 = a1;

	v1 = DisposeVerify.x; // 2

}

v2 = DisposeVerify.x; // 3
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_TestImpInsideAssoc()
        {
            string code = @"
[Associative]

{

    x = 5.1;

    z = y;

    w = z * 2;

    [Imperative]

    {

        y = 5;

        z = x;

        x = 35;

        i = 3;

    }

    f = i;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_TestNegativeUsage_InUnnamedBlock_Negative()
        {
            string code = @"
{

	a = { 2,3 };

	x = 1;

	

	for( y in a )

	{

		x = x + 1;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_UnnamedBlock_Negative()
        {
            string code = @"
{

    i = 0;

    temp = 1;

    while ( i < 5 )

	{

	    temp = temp + 1;

        i = i + 1;

    }

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT03_Update_Function_Argument_Across_Language_Scope()
        {
            string code = @"

a = 1;

def foo ( a1 : int )

{

    return = a1 + 1;

}

b = foo ( c ) ;

c = a + 1;



[Imperative]

{

    a = 2.5;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT040_AllFalse_RangeExpression_01()
        {
            string code = @"
s
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT040_AllFalse_Replication()
        {
            string code = @"
a = {



	{{0}},

	{false}



};

c = AllFalse(a);



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT042_AllFalse_DynamicArray()
        {
            string code = @"
b = {};



a = {{true},{false},{false},

	{false,{true,false}}};

	

	i = 0;

	result2 = 

	[Imperative]

	{

		while(i<Count(a))

		{

			b[i] = AllFalse(a[i]);

			i = i+1;

		}

		return = b;

	}

	result = AllFalse(a);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT043_AllFalse_ModifierStack()
        {
            string code = @"
arr0 = {{false}};

arr1 = {1||0};

arr2 = {false&&0};







a = 

{

	AllFalse(arr0) => a1;//1

	AllFalse(arr1) => a2;//0

	AllFalse(arr2) => a3;//1

	&&a1 => a4;//1

	

}



result = {a1,a2,a3,a4};

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT044_AllFalse_ImperativeAssociative()
        {
            string code = @"
[Imperative]

{

	a = {false||true};

	b = {""false""};

	c = a;

	a = {false};

	[Associative]

	{

		

		d = b;

		

		b = {false};

		

		m = AllFalse(c);//f

		n = AllFalse(d);//t

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT045_Defect_CountArray_1()
        {
            string code = @"
a = {0,1,null};

b = {m,{},a};

c={};

c[0] = 1;

c[1] = true;

c[2] = 0;

c[3] = 0;



a1 = Count(a);

b1 = Count(b);

c1 = Count(c);



result = {a1,b1,c1};
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT045_Defect_CountArray_2()
        {
            string code = @"
result=

[Imperative]

{

a = {};

b = a;

a[0] = b;

a[1] = ""true"";

c = Count(a);

a[2] = c;

return = Count(a);

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT045_Defect_CountArray_3()
        {
            string code = @"
a = {};

b = {null,1+2};

a[0] = b;

a[1] = b[1];



result = Count(a);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT046_Sum_IfElse()
        {
            string code = @"
result = 

[Imperative]

{

	a = {1,2,3,4};

	b = {1.0,2.0,3.0,4.0};

	c = {1.0,2,3,4.0};

	d = {};

	e = {{1,2,3,4}};

	f = {true,1,2,3,4};

	g = {null};

	

	m= {-1,-1,-1,-1,-1,-1,-1};

	

	if(Sum(a)>=0) m[0] = Sum(a);	

	if(Sum(b)>=0) m[1] = Sum(b);

	if(Sum(c)>=0) m[2] = Sum(c);

	if(Sum(d)>=0) m[3] = Sum(d); 

	if(Sum(e)>=0) m[4] = Sum(e);

	if(Sum(f)>=0) m[5] = Sum(f);

	if(Sum(g)>=0) m[6] = Sum(g);

	

	return = m;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT047_Sum_ForLoop()
        {
            string code = @"
result = 

[Imperative]

{

	a = {0,0.0};

	b = {{}};

	c = {m,Sum(a),b,10.0};

	

	d = {a,b,c};

	j = 0;

	

	for(i in d)

	{

		d[j] = Sum(i);

		j = j+1;

	}

	

	return = d; 

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT048_Sum_WhileLoop()
        {
            string code = @"
result = 

[Imperative]

{

	a = {-2,0.0};

	b = {{}};

	c = {m,Sum(a),b,10.0};

	

	d = {a,b,c};

	j = 0;

	k = 0;

	e = {};

	

	while(j<Count(d))

	{

		if(Sum(d[j])!=0)

		{

			e[k] = Sum(d[j]);

			k = k+1;

		}

		j = j+1;

	}

	

	return = e; 

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT049_Sum_Function()
        {
            string code = @"
def foo(x:var[])

{

	return =

	[Imperative]

	{

		return = Sum(x);

	}

}



a = {-0.1,true,{},null,1};

b = {m+n,{{{1}}}};



c = {Sum(a),Sum(b)};

result = foo(c);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_Arithmatic_Single_List_And_Integer()
        {
            string code = @"
list1 = { 1, 2, 3, 4, 5 };

a = 5;



list2 = a + list1; // { 6, 7, 8, 9, 10 }

list3 = list1 + a; // { 6, 7, 8, 9, 10 }

list4 = a - list1; // { 4, 3, 2, 1, 0 }

list5 = list1 - a; // { -4, -3, -2, -1, 0 }

list6 = a * list1; // { 5, 10, 15, 20, 25 }

list7 = list1 * a; // { 5, 10, 15, 20, 25 }

list8 = a / list1; 

list9 = list1 / a; 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_Class_Properties()
        {
            string code = @"
class A

{ 

	x1 : var[];  

	x2 : int ;

	x3 : double;

	x4 : bool;

	x5 : B;

	constructor A () 

	{	

		x1  = { 1, 2 };  

		x2  = 1;

		x3  = 1.5;

		x4  = true;

		x5  = B.B(1);

	}

}

class B

{ 

	y : int;

	constructor B (i : int) 

	{	

		y = i;

	}

}

a = A.A();

t1 = a.x1;

t2 = a.x2;

t3 = a.x3;

t4 = a.x4;

t5 = a.x5;

t6 = t5[0].y;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_Collection_Assignment_Using_Indexed_Values()
        {
            string code = @"
[Associative]

{

	a = { {1,2,3},{4,5,6} };

	

	b = { a[0], 4 };

	

	c = b[0];

	

	d = b[1];

	

	e = { a[0][0], a[0][1], a[1][0] };

	

}





	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_Defect_1454320_String()
        {
            string code = @"
[Associative]

{

str = ""hello world!"";

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_Defect_1467100_String()
        {
            string code = @"
def f(s : string)

{

    return = s;

}

x = f(""hello"");



//expected : x = ""hello""

//received : x = null

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_ForLoopBreakContinue()
        {
            string code = @"
[Imperative]

{

    sum = 0;



    for (x in {1, 2, 3, 4, 5, 6, 7, 8, 9, 10})

    {

        sum = sum + x;



        if (x <= 5)

            continue;



        sum = sum + 1;

    }

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_Function_In_Nested_Scope()
        {
            string code = @"
[Associative]

{

    def foo : int( a:int, b : int )

    {

	   return = a * b;

	}

	a = 3.5;

	[Imperative]

	{

		a = foo( 2, 1 );

	}

	b = 

	[Imperative]

	{

		a = foo( 2, 1 );

		return = a;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_GlobalFunctionInImperBlk()
        {
            string code = @"
[Imperative]

{

	def foo:double(x:int, y:double = 2.0)

	{

		return = x + y;

	}



	a = foo;

	b = foo(3); //b=5.0;

	c = foo(2, 4.0); //c = 6.0

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_IfStatementExpressions()
        {
            string code = @"
[Imperative]

{

 a=1;

 b=2;

 temp1=1;

 if((a/b)==0)

 {

  temp1=0;

  if((a*b)==2)

  { temp1=2;

  }

 } 

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_OutsideBlock_Negative()
        {
            string code = @"
i = 0;    

temp = 1;

while( i < 5 )

{

    temp = temp + 1;

    i = i + 1;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_SimpleRangeExpressionUsingFunctions()
        {
            string code = @"
[Imperative]

{



	def twice : double( a : double ) 

	{

		return = 2 * a;

	}



	z1 = 1..twice(4)..twice(1);

	z2 = 1..twice(4)..twice(1)-1;

	z3 = 1..twice(4)..(twice(1)-1);

	z4 = 2*twice(1)..1..-1;

	z5 = (2*twice(1))..1..-1;

	//z6 = z5 - z2 + 0.3;

	z7 = (z3[0]+0.3)..4..#1 ; 

   

}



/*

Succesfully created function 'twice' 

    Updated variable z1 = { 1, 3, 5, 7 }

    Updated variable z2 = { 1, 2, 3, ... , 6, 7, 8 }

    Updated variable z3 = { 1, 2, 3, ... , 6, 7, 8 }

    Updated variable z4 = { 4, 3, 2, 1 }

    Updated variable z5 = { 4, 3, 2, 1 }

    //Updated variable z6 = { 3.3, 1.3, -1.7, -2.7 }

    Updated variable z7 = { 1.3 }



	*/
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_TestAssignmentStmtInExpression_negative__2_()
        {
            string code = @"
[Associative]

{

    b = if (2==2) { a = 0; }

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_TestAssignmentStmtInExpression_negative()
        {
            string code = @"
[Imperative]

{

    b = if (2==2) { a = 0; }

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_TestGCReturnFromLangBlk()
        {
            string code = @"
import(""DisposeVerify.ds"");

DisposeVerify.x = 1;

[Imperative]

{

	// %tempLangBlk = 

    [Associative]

    {

        a1 = A.A();

        return = a1; // a1 is not gced here because it is been returned

    }

	v1 = DisposeVerify.x; // 1

	// %tempLangBlk, same value as a1, is gcced here, this is also to test after assign the return value from the language 

	// block, the ref count of that value is still 1

}

v2 = DisposeVerify.x; // 2
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_TestImperativeBlockWithMissingBracket_negative()
        {
            string code = @"
[Imperative]

{

    x = 5.1;

    

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_TestNegativeUsage_OutsideBlock_Negative()
        {
            string code = @"


	a = { 2,3 };

	x = 1;

	

	for( y in a )

	{

		x = x + 1;

	}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT04_Update_Class_Instance_Argument()
        {
            string code = @"
class A

{

    a : int;

	constructor A ( x : int )

	{

	    a = x;

	}

	def add ( x : int )

	{

	    a = a + x;

		return = a;

	}

}



t1 = 1;

a1 = A.A(t1);

b1 = a1.add(t1);

[Imperative]

{

	t1 = 2;

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT050_Sum_Class()
        {
            string code = @"
class C 

{

	x: int;

	y: bool;

	sum : var;

	

	constructor C(a:var[]..[])

	{

		x = 10.0;

		y = false;

		arr = {Sum(a),x,y};

		

		sum = Sum(arr);

	}

	

	def foo(b:var[]..[])

	{

		r = 

		[Imperative]

		{	

			c = {};

			i = 0;

			while(i<Count(b))

			{

				c[i] = Sum(b[i]);

				i = i+1;

			}

			if(Sum(c) == Sum(b)){

				return  = true;

				

			}else

			{return = false;}

		}

		return = r;

	}

}



a = {1,-1};

b = {null, "" "",{1}};

c = {a,b};





d = C.C(c);

m = d.sum;

p = d.x;

q = d.y;

n= d.foo(c);



result = {m,n,Sum({m,n})};

//11.0,true,11.0

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT051_Inherit_defaultconstructor()
        {
            string code = @"
// default constructor

class baseClass

{ 

	val1 : int =2 ;





}



class derivedClass extends  baseClass

{ 

	val2 : int =1;

	val3 : double=1;

	

	



}





instance = derivedClass.derivedClass();

result1 = instance.val2;//1

result2 = instance.val3;//1

result3 = instance.val1;//2
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT051_Sum_Inline()
        {
            string code = @"
a = {1,{2,-3.00}};//0.0

sum = Sum(a);

b = Sum(a) -1;//-1.0

c = Sum({a,b,-1});//-2.0;

result = Sum(a)==0&& b==-1.00? b :c;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT052_Inherit_defaultproperty()
        {
            string code = @"
// access  property from inherited class and test default values are retained

class A

{ 

	x : var ;

	y : int;

	z : bool;

	u : double;

	v : B;

	w1 : int[];

	w2 : double[];

	w3 : bool[];

	w4 : B[][];

	

	constructor A ()

	{

		      	

	}	

}

class B extends A

{

	



}



a1 = B.B();

x1 = a1.x; // null

x2 = a1.y;//0

x3 = a1.z;//false

x4 = a1.u;//0.0

x5 = a1.v;//null

x6 = a1.w1;//0

x7 = a1.w2;//0.0

x8 = a1.w3;//false

x9 = a1.w4;//null

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT052_Sum_RangeExpression()
        {
            string code = @"
result = 

[Imperative]

{

	a1 = {1,true, null};//1

	a2 = 8;

	a3 = {2,{true,{true,1.0}},{false,x, true}};//3.0

	a = Sum(a1)..a2..Sum(a3);//{1,4,7}

	

	return = Sum(a);//12.0

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT053_Inherit_changevalue()
        {
            string code = @"
// set variablse in abse class to default value and modify them in inherited class 

class A

{ 

	x : var ;

	y : int;

	z : bool;

	u : double;

	v : B;

	w1 : int[];

	w2 : double[];

	w3 : bool[];

	w4 : B[][];

	

	constructor A ()

	{

		      	

	}	

}

class B extends A

{

	constructor B()

	{

	y=1;

	z=true;

	u=0.5;

	w1={2,2};

	w2 ={0.5,0.5};

	w3 ={true,false};

	w4 ={this.x,this.x};

	}



}



a1 = B.B();

x1 = a1.x;//null

x2 = a1.y;//1

x3 = a1.z;//true

x4 = a1.u;//0.5

x5 = a1.v;//null

x6 = a1.w1;//{2,2}

x7 = a1.w2;//{0.5,0.5}

x8 = a1.w3;//{true,false}

x9 = a1.w4;//{null,null}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT053_Sum_Replication()
        {
            string code = @"
a = {1,2,3};

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT054_Inherit_nested()
        {
            string code = @"
class A

{ 

	x : var ;

	y : int;

	z : bool;

	u : double;

	v : B;

	w1 : int[];

	w2 : double[];

	w3 : bool[];

	w4 : B[][];

	

	constructor A ()

	{

		      	

	}	

}

class B extends A

{

	constructor B()

	{

	x=this.B();

	y=1;

	z=true;

	u=0.5;

	w1={2,2};

	w2 ={0.5,0.5};

	w3 ={true,false};

	w4 ={this.B(),this.B()};

	}



}



a1 = B.B();

x1 = a1.x;

x2 = a1.y;

x3 = a1.z;

x4 = a1.u;

x5 = a1.v;

x6 = a1.w1;

x7 = a1.w2;

x8 = a1.w3;

x9 = a1.w4;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT054_Sum_DynamicArr()
        {
            string code = @"
a = {};

b = {1.0,2,3.0};

c = {null,m,""1""};



a[0]=Sum(b);//6.0

a[1] = Sum(c);//0

a[2] = Sum({a[0],a[1]});//6.0



result = Sum(a);//12.0
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT055_Inherit_donotchangevalue()
        {
            string code = @"
class A

{ 

	public x : var ;	

	private y : var ;

	//protected z : var = 0 ;

	constructor A ()

	{

		   	

	}

	public def foo1 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	} 

	private def foo2 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	}	

}

class B extends A

{

	

}



a = B.B();

a1 = a.foo1(1);

a2 = a.foo2(1);

a.x = 4;

//a.y = 5;

a3 = a.x;

//a4 = a.y;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT055_Sum_ModifierStack()
        {
            string code = @"
a = 

{

	{1,false} => a1;

	Sum(a1)=> a2;//1

	Sum({a1,a2}) => a3;//2

}



result = Sum({a1,a2,a3,a});//6
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT056_Inherit_private()
        {
            string code = @"
// do not modify in extended class

class A

{ 

	public x : var ;	

	private y : var ;

	//protected z : var = 0 ;

	constructor A ()

	{

		   	

	}

	public def foo1 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	} 

	private def foo2 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	}	

	def testprivate ()

       {

          return=foo2(1);

       }

}

class B extends A

{

   

	

}



a = B.B();

a1 = a.foo1(1);

a2 = a.foo2(1);//not accessible

a3=a.testprivate();//3

a.x = 4;

//a.y = 5;

a4 = a.x;//1

a5 = a.y;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test, Ignore]
        public void DebugEQT056_Sum_AssociativeImperative()
        {
            string code = @"
a = {1,0,0.0};

b = {2.0,0,true};

b1 = {b,1};



[Imperative]

{

	c = a[2];

	a[1] = 1;

	m = a;

	sum1 = Sum({c});//0.0



	[Associative]

	{

		 b[1] = 1;

		 sum2 = Sum( b1);////4.0

	}

	

	a[2]  =1;



	sum3 = Sum({c});//0.0



}







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT057_Average_DataType_01()
        {
            string code = @"
a = {};

b = {1,2,3};

c = {0.1,0.2,0.3,1};

d = {true, false, 1};



a1 = Average(a);

b1 = Average(b);

c1 = Average(c);

d1 = Average(d);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT057_Inherit_private_modify()
        {
            string code = @"
//modify in extended class 

class A

{ 

	public x : var ;	

	private y : var ;

	//protected z : var = 0 ;



	constructor A ()

	{

		   	

	}

	public def foo1 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	} 

	private def foo2 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	}	

	def testprivate ()

        {

          return=foo2(1);

        }

}

class B extends A

{

        private def foo2 (a)

	{

	    x = a;



	    return = x ; 

        }

	def testextended ()

        {

          return=foo2(10);

        }

		

}



b = B.B();

b1 = b.foo1(1);

b2 = b.foo2(1);//private

b3=b.testprivate();//3

b4=b.testextended();//10  from the extended class 



b.x = 4;

//a.y = 5;

b5 = b.x;

b6 = b.y;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT058_Average_DataType_02()
        {
            string code = @"
import(""ProtoGeometry.dll"");

//WCS = CoordinateSystem.Identity();

pt1=Point.ByCoordinates(1,1,1);

a = {true};

b = {{1},2,3};

c = {""a"",0.2,0.3,1};

d = {pt1, {}, 1};



a1 = Average(a);

b1 = Average(b);

c1 = Average(c);

d1 = Average(d);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT058_Inherit_private_notmodify()
        {
            string code = @"
// do not modify private member

class A

{ 

	public x : var ;	

	private y : var ;

	//protected z : var = 0 ;



	constructor A ()

	{

		   	

	}

	public def foo1 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	} 

	private def foo2 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	}	

	def testprivate ()

        {

          return=foo2(1);

        }

}

class B extends A

{

	def testextended ()

        {

          return=foo2(10);

        }

		

}



a = B.B();

a1 = a.foo1(1);

a2 = a.foo2(1);//private function

a3=a.testprivate();//3

a4=a.testextended();// private function null



a.x = 4;

//a.y = 5;

a5 = a.x;

a6 = a.y;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT059_Defect_Flatten_RangeExpression()
        {
            string code = @"
a = 0..10..5;

b = 20..30..2;

c = {a, b};

d = Flatten({a,b});

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT059_Defect_Flatten_RangeExpression_1()
        {
            string code = @"
a = {{null}};

b = {1,2,{3}};

c = {a,b};

d = Flatten(c);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT059_Inherit_access_privatemember()
        {
            string code = @"
//access (in extended class) the private property created in base class 

class A

{ 

	public x : var ;	

	private y : var ;

	//protected z : var = 0 ;



	constructor A ()

	{

		   	

	}

	public def foo1 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	} 

	private def foo2 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	}	

	def testprivate ()

        {

          return=foo2(1);

        }

}

class B extends A

{

        private def foo2 (a)

	{

	    x = y;



	    return = x ; 

        }

	def testextended ()

        {

          return=foo2(10);

        }

		

}



a = B.B();

a1 = a.foo1(1);

a2 = a.foo2(1);// access private property from base class 

a3=a.testprivate();//3

a4=a.testextended();//10  from the extended class 



a.x = 4;

//a.y = 5;

a5 = a.x;

a6 = a.y;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_ClassMemerVarAsFunctionPointer()
        {
            string code = @"
class A

{

	x:var;

	constructor A()

	{

		x = foo;

	}

}



def foo:double(x:int, y:double = 2.0)

{

	return = x + y;

}



a = A.A();

b = a.x(3,2.0);	//b=5.0;

c = a.x(2, 4.0);	//c = 6.0
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_ClassMemerVarAsFunctionPointerDefaultArg()
        {
            string code = @"
class A

{

	x:var;

	constructor A()

	{

		x = foo;

	}

}



def foo:double(x:int, y:double = 2.0)

{

	return = x + y;

}



a = A.A();

b = a.x(3);	//b=5.0;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_Class_Properties()
        {
            string code = @"
class A

{ 

	x1 : var[][];  

	x2 : int[] ;

	x3 : double[]..[];

	x4 : bool[];

	x5 : B[];

	constructor A () 

	{	

		x1  = { 1, 2 };  

		x2  = { 1, 2 };

		x3  = { 1.5, 2.5 };

		x4  = { true, false };

		x5  = { B.B(1), B.B(2) };

	}

}

class B

{ 

	y : int;

	constructor B (i : int) 

	{	

		y = i;

	}

}

a = A.A();

t1 = a.x1;

t2 = a.x2;

t3 = a.x3;

t4 = a.x4;

t5 = a.x5;

t6 = t5[0].y;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_Collection_Assignment_Using_Class()
        {
            string code = @"
class collection

{

	

	public a : var[];

	

	constructor create( )

	{

		a = { 1,2,3 };

	}

	

	def ret_col ( )

	{

		return=  a;

	}

}



[Imperative]

{

	c1 = collection.create(  );

	d = c1.ret_col();

}



		

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_FunctionBreakContinue()
        {
            string code = @"
[Imperative]

{

    def ding:int(x:int)

    {

        if (x >= 5)

            break;



        return = 2 * x;

    }



    def dong:int(x: int)

    {

        if (x >= 5)

            continue;



        return = 2 * x;

    }



    a = ding(1);

    b = ding(6);

    c = dong(2);

    d = dong(7);

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_Function_outside_Any_Block()
        {
            string code = @"
def foo : int( a:int, b : int )

{

    return = a * b;

}

a = 3.5;

b = 3.5;

[Associative]

{

	a = 3.5;

	[Imperative]

	{

		a = foo( 2, 1 );

	}

	b = 

	[Imperative]

	{

		a = foo( 2, 1 );

		return = a;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_InsideFunction()
        {
            string code = @"
[Imperative]

{

	def fn1:int(a:int)

	{   

		if(a>=0)

			return = 1;

		else 

			return = 0;

	}

    def fn2:int(a:int)

	{   

	   

		if( a < 0 )

		{

			return = 0;

		}

		elseif	( a == 2 )

		{

			return = 2;

		}

		else

		{

			return = 1;

		}

	}

	

    temp = 0;

    temp2 = 0;



	 if(fn1(-1)==0)

		 temp=fn1(2);	 

		 

	



	if(fn2(2)==2)

	   temp2=fn2(1);

} 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_Logic_List_And_List_Different_Value()
        {
            string code = @"
list1 = { 1, 8, 10, 4, 7 };

list2 = { 2, 6, 10, 3, 5, 20 };



list3 = list1 > list2; // { false, true, false, true, true }

list4 = list1 < list2;	// { true, false, false, false, false }

list5 = list1 >= list2; // { false, true, true, true, true }

list6 = list1 <= list2; // { true, false, true, false, false }



list9 = { true, false, true };



list7 = list9 && list5; // { false, false, true }

list8 = list9 || list6; // { true, false, true }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_RangeExpressionWithIncrement()
        {
            string code = @"
[Imperative]

{

	d = 0.9..1..0.1;

	e1 = -0.4..-0.5..-0.1;

	f = -0.4..-0.3..0.1;

	g = 0.4..1..0.2;

	h = 0.4..1..0.1;

	i = 0.4..1;

	j = 0.6..1..0.4;

	k = 0.09..0.1..0.01;

	l = 0.2..0.3..0.05;

	m = 0.05..0.1..0.04;

	n = 0.1..0.9..~0.3;

	k = 0.02..0.03..#3;

	l = 0.9..1..#5;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_String_ForLoop()
        {
            string code = @"
a = ""hello"";

b = ""world"";



c = { a, b };

j = 0;

//s = { };

r = 

[Imperative]

{



	for(i in c)

	{

	    s[j] = String(i);

	    j = j + 1;

	}

	

	def String(x : string)

	{

	    return = x;

}

    return = s;

  

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_TestForLoopInsideNestedBlocks()
        {
            string code = @"
[Associative]

{

	a = { 4, 5 };



	[Imperative]

	{

		x = 0;

		b = { 2,3 };

		for( y in b )

		{

			x = y + x;

		}

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_TestGCReturnFromFunction()
        {
            string code = @"
import(""DisposeVerify.ds"");

DisposeVerify.x = 1;

def foo : A()

{

	arr = { A.A(), A.A(), A.A() };

	return = arr[1]; // only the second element in arr is not gced, ref count of arr[1] is incremented

}



[Imperative]

{

  

m = foo();

v1 = DisposeVerify.x; // 3

m = 10;

// test after assign the return value from foo, the ref count of that value is 1

v2 = DisposeVerify.x; // 4

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_TestImperativeBlockWithMissingBracket_negative()
        {
            string code = @"
[Imperative]



    x = 5.1;

    

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_TestRepeatedAssignment()
        {
            string code = @"
[Associative]

{

    b = a = 2;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_TestRepeatedAssignment_negative__2_()
        {
            string code = @"
[Associative]

{

    b = a = 2;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_TestRepeatedAssignment_negative()
        {
            string code = @"
[Imperative]

{

    b = a = 2;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_Update_Class_Instance_Argument()
        {
            string code = @"
class A

{

    a : int;

	constructor A ( x : int )

	{

	    a = x;

	}

	def add ( x : int )

	{

	    a = a + x;

		return = A.A(a);

	}

}



t1 = 1;

a1 = A.A(t1);

b1 = a1.add(t1);

t2 = b1.a;



//t1 = 2;

[Imperative]

{

	t1 = 2;

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT05_WithinFunction()
        {
            string code = @"
[Imperative]

{

	def fn1 : int (a : int)

	{   

		i = 0;

		temp = 1;

		while ( i < a )

		{

		    temp = temp + 1;

		    i = i + 1;

		}

		return = temp;

	}

	testvar = fn1(5);

} 

	

	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT060_Average_ForLoop()
        {
            string code = @"
result = 

[Imperative]

{

	a = {};

	b = {1,{2},{{2},1}};

	c = {true, false, null, 10};

	d = {a,b,c};

	

	e = {};

	j = 0;

	

	for(i in d)

	{

		e[j] = Average(i);

		 j = j+1;

		

	}

	return = e;

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT061_Average_Function()
        {
            string code = @"
def foo : double (x :var[]..[])

{

	

	return = Average(x);

}



a = {1,2,2,1};

b = {1,{}};



c = Average(a);

result = {foo(a),foo(b)};
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT061_Inherit_Property()
        {
            string code = @"
class TestPoint

{

    A : var;

           

    constructor Create( xx : int )

    {

	    A = xx;          

    }

	

	def Modify( )		

	{	

	    A = A + 1;

	    return = A;

	}

                                

}



class derived extends TestPoint

{

	D : var;

           

    constructor Create( xx : int ): base.Create( xx )

    {

	    D = xx; 

    }

	

	def Modify( val:int )

	{

	    D = A + val;

	    return = D;

	}   

}



oldPoint = TestPoint.Create(1);

derivedpoint=derived.Create(7);

basePoint=oldPoint.Modify();

callbase=derivedpoint.Modify();

derivedPoint2 = derivedpoint.Modify(2);

xPoint1 = oldPoint.A;

xPoint2 = derivedpoint.A;

xPoint3 = derivedpoint.D;

    





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT062_Average_Class()
        {
            string code = @"
class C 

{

	x : var;

	y : var;

	

	constructor C1(m:var[]..[], n:var[]..[])

	{

		x = Average(m);

		y = Average(n);

	}



	def foo()

	{

		return = Average({x,y});

	}

}



a = {1,{2},{{{3}}}};

b = {0.1,2,0};



m = C.C1(a,b);

m1 = m.x;

m2 = m.y;

n = m.foo();
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT062_Inherit_classAsArgument()
        {
            string code = @"


class TestPoint

{

            A : var;

            B : var;

            C : var;

                                

        constructor Create(xx : int, yy : int, zz : int)

        {

	    A = xx; 

            B = yy;

            C = zz;

        }

	def Modify(oldPoint : TestPoint)

	{

	    return=TestPoint.Create(oldPoint.A + 1, oldPoint.B + 1, oldPoint.C + 1);	

	}

                                

}



class derived extends TestPoint

{

     constructor Create(xx : int, yy : int, zz : int)

        {

	    A = xx; 

            B = yy;

            C = zz;

     }

	def Modify(oldPoint : TestPoint, val:int)

		

	{

        return = derived.Create(oldPoint.A + val, oldPoint.B + val, oldPoint.C + val);

		

	}   

}

	oldPoint = TestPoint.Create(1, 2, 3);

        derivedpoint=derived.Create(7,8,9);

	basePoint=oldPoint.Modify(derivedpoint);

	derivedPoint2 =derivedpoint.Modify(derivedpoint, 2);



	xPoint1 = oldPoint.A; //1

        yPoint1 = oldPoint.B;    //2        

        zPoint1 = oldPoint.C;       //3        



        xPoint2 = derivedpoint.A; //9

        yPoint2 = derivedpoint.B;    //10 

        zPoint2 = derivedpoint.C;//11



        xPoint3 = basePoint.A;//8

        yPoint3 = basePoint.B;   //9         

        zPoint3 = basePoint.C;//10



        xPoint4 = derivedPoint2.A;//9

        yPoint4 = derivedPoint2.B;//10            

        zPoint4 = derivedPoint2.C; //11            









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT063_Average_Inline()
        {
            string code = @"
a = {1.0,2};

b = {{0},1.0,{2}};



result = Average(a)>Average(b)?true:false;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT063_Inherit_classAsArgument_callinfunction()
        {
            string code = @"


class TestPoint

{

            A : var;

            B : var;

            C : var;

                                

        constructor Create(xx : int, yy : int, zz : int)

        {

	    A = xx; 

            B = yy;

            C = zz;

        }



                                

}



class derived extends TestPoint

{

    

           

     constructor Create(xx : int, yy : int, zz : int)

        {

	        A = xx; 

            B = yy;

            C = zz;

     }

	   

}

def modify(oldPoint : TestPoint)

		

        {

	

	    A1 = oldPoint.A +1;

	  

	    return=A1;

		

        }





        oldPoint = TestPoint.Create(1, 2, 3);

        derivedpoint=derived.Create(7,8,9);

	basePoint=modify(oldPoint);//2

	derivedPoint2 = modify(derivedpoint);//8



	xPoint1 =  oldPoint.A; //1

        yPoint1 =  oldPoint.B;    //2        

        zPoint1 =  oldPoint.C;       //3        



        xPoint2 = derivedpoint.A; //7

        yPoint2 = derivedpoint.B;    //8        

        zPoint2 = derivedpoint.C;//9           









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT064_Average_RangeExpression()
        {
            string code = @"
a = 0..6..3;//0,3,6

b = 0..10..~3;//0,3.3,6.6,10

m = Average(a);//3

n = Average(b);//5.0



c = Average({m})..Average({n});//3.0,4.0,5.0
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT064_Inherit_classAsArgument_callinfunction_negative()
        {
            string code = @"
// do not extend and try calling

class TestPoint

{

            A : var;

            B : var;

            C : var;

                                

        constructor Create(xx : int, yy : int, zz : int)

        {

	    A = xx; 

            B = yy;

            C = zz;

        }



                                

}



class derived 



{

            A : var;

            B : var;

            C : var;

           

     constructor Create(xx : int, yy : int, zz : int)

        {

	        A = xx; 

            B = yy;

            C = zz;

     }

	   

}

def modify(oldPoint : TestPoint)

		

        {

	

	    A1 = oldPoint.A +1;

	  

	    return=A1;

		

        }





        oldPoint = TestPoint.Create(1, 2, 3);

        derivedpoint=derived.Create(7,8,9);

	basePoint=modify(oldPoint);//2

	derivedPoint2 = modify(derivedpoint);//8



	xPoint1 =  oldPoint.A; //1

        yPoint1 =  oldPoint.B;    //2        

        zPoint1 =  oldPoint.C;       //3        



        xPoint2 = derivedpoint.A; //7

        yPoint2 = derivedpoint.B;    //8        

        zPoint2 = derivedpoint.C;//9           









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT065_Average_ModifierStack()
        {
            string code = @"
b = {0.0,1};//0.5

c = b;

a =

{

	Average(c) =>a1;

	Average({a1}) +1 => a2;

	

}

b[0]=1;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT065_Inherit_constructor_withoutbase()
        {
            string code = @"
class TestPoint

{

    A : var;

           

    constructor Create(xx : int)

    {

	    A = xx; 

    }

	

	def Modify()

	{

	    A = A +1;

	    return = A;

	}

                                

}



class derived extends TestPoint

{

	    D : var;

           

        constructor Create(xx : int)

        {

	        D = xx;           

        }

	

	def Modify(val:int)		

	{

	    D = A +val;

	    return = D;		

	}   

}

	

oldPoint = TestPoint.Create(1);

derivedpoint=derived.Create(7);

basePoint=oldPoint.Modify();

xPoint1 = oldPoint.A;//2

xPoint2 = derivedpoint.A;//1

xPoint3 = derivedpoint.D;//7
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT066_Inherit_constructor_failing_witbase()
        {
            string code = @"
// failing constructor in base

class A

{ 

	x : var ;	

	

	constructor A ()

	{

		 x = w;     	

	}	

}

class B extends A

{ 

	y : var ;	

	

	constructor B ():base.A()

	{

		 y = 10;     	

	}	

}

a1 = A.A();

b1=B.B();

a2 = a1.x;//null

b2 = b1.y;//10





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT066_Print_String()
        {
            string code = @"
r1 = Print(""Hello World"");

str = ""Hello World!!"";

r2 = Print(str);

a = 1;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT067_Inherit_propertynotassignedinbase()
        {
            string code = @"
// no value in base

class A

{ 

	x : var ;	

	

	constructor A ()

	{

		     	

	}	

}

class B extends A

{ 

	y : var ;	

	

	constructor B ():base.A()

	{

		 y = 10;     	

	}	

}

a1 = A.A();

b1=B.B();

a2 = a1.x;//null

b2 = b1.y;//10





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT067_Print_Arr()
        {
            string code = @"
arr = { 0, 1 ,2};

r1 = Print(arr);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT068_Inherit_propertyassignedinherited()
        {
            string code = @"
// failing constructor in base reassigned in inherited

class A

{ 

	x : var ;	

	

	constructor A ()

	{

		x=w;     	

	}	

}

class B extends A

{ 

	y : var ;	

	

	constructor B ():base.A()

	{

		 x = 10;     	

	}	

}

a1 = A.A();

b1=B.B();

a2 = a1.x;//null

b2 = b1.y;//null

b3 = b1.x;//10







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT069_Inherit_constructor_failing_both()
        {
            string code = @"
// failing constructor in both

class A

{ 

	x : var ;	

	

	constructor A ()

	{

		 x = w;     	

	}	

}

class B extends A

{ 

	y : var ;	

	

	constructor B ():base.A()

	{

		 y = w;     	

	}	

}

a1 = A.A();

b1=B.B();

a2 = a1.x;//null

b2 = b1.y;//null





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT06_ClassMemerVarAsFunctionPointerAssocBlk()
        {
            string code = @"
class A

{

	x:var;

	constructor A()

	{

		x = foo;

	}

}



def foo:double(x:int, y:double = 2.0)

{

	return = x + y;

}

[Associative]

{

	a = A.A();

	b = a.x(3,2.0);	//b=5.0;

	c = a.x(2, 4.0);	//c = 6.0

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT06_Class_Properties()
        {
            string code = @"
class A

{ 

	x1 : int = 5;

	constructor A () 

	{	

		

	}

}



a = A.A();

t1 = a.x1;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT06_Collection_Assignment_Using_Class_2()
        {
            string code = @"
class collection

{

	

	public a : var[];

	

	constructor create( b )

	{

		a = { 1,2,b };

	}

	

	def modify ( c )

	{

		a[0] = c;

		return = a;

	}



}



[Associative]

{

	c1 = collection.create( 3 );

	

	d = c1.modify( 4 );

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT06_Function_Imp_Inside_Assoc()
        {
            string code = @"
[Associative]

{

	def foo : int( a:int, b : int )

	{

		return = a * b;

	}

	a = 3.5;

	b = 3.5;



	[Imperative]

	{

		a = foo( 2, 1 );

	}

	b = 

	[Imperative]

	{

		c = foo( 2, 1 );

		return = c;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT06_InsideNestedBlock()
        {
            string code = @"
[Associative]

{

	a = 4;

	b = a*2;

	temp = 0;

	[Imperative]

	{

		i=0;

		temp=1;

		while(i<=5)

		{

	      i=i+1;

		  temp=temp+1;

		}

    }

	a = temp;

      

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT06_Logic_List_And_List_Same_Length()
        {
            string code = @"
list1 = { 1, 8, 10, 4, 7 };

list2 = { 2, 6, 10, 3, 5 };



list3 = list1 > list2; // { false, true, false, true, true }

list4 = list1 < list2;	// { true, false, false, false, false }

list5 = list1 >= list2; // { false, true, true, true, true }

list6 = list1 <= list2; // { true, false, true, false, false }



list7 = list3 && list5; // { false, true, false, true, true }

list8 = list4 || list6; // { true, false, true, false, false }

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT06_NestedIfElse()
        {
            string code = @"
[Imperative]

{

def fn1:int(a:int)

{   

     if( a >= 0 )

		return = 1;

	else

		return = 0;

}



 a = 1;

 b = 2;

 temp1 = 1;

 

 if( a/b == 0 )

 {

  temp1=0;

  if( a*b == 1 )

  { 

	temp1=2;

  }  

  else if( a*b == 4 )

  { 

	temp1=5;

  }  

  else

  {

	temp1=3;

	if( fn1(-1)>-1 )

	{

		temp1=4;

	}

  }

 } 

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT06_RangeExpressionWithIncrement()
        {
            string code = @"
[Imperative]

{

	a = 0.3..0.1..-0.1;

	b = 0.1..0.3..0.2;

	c = 0.1..0.3..0.1;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT06_String_Class()
        {
            string code = @"
class A

{

	str:string = ""a"";

    def foo(s : string)

    {

        str = s;

return = str;

    }

}



a = A.A();

[Imperative]

{

	str1 = a.str;

    str2 = a.foo(""foo"");

    a.str = a.str + ""b"";

	str3 =a.str;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT06_TestGCEndofWhileBlk()
        {
            string code = @"
import(""DisposeVerify.ds"");



[Imperative]

{

  

DisposeVerify.x = 1;

arr = { A.A(), A.A(), A.A() };



[Associative]

{

    [Imperative]

    {

        a = 3;

        while (a > 0)

        {

            mm = A.A();

            a = a - 1;

        }

        v1 = DisposeVerify.x; // 3

    }

}

v2 = DisposeVerify.x; // 4

arr = null;

v3 = DisposeVerify.x; // 7



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT06_TestInUnnamedBlock_negative__2_()
        {
            string code = @"
{

    b = 2;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT06_TestInUnnamedBlock_negative()
        {
            string code = @"
{

    b = 2;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT06_TestInsideNestedBlocksUsingCollectionFromAssociativeBlock()
        {
            string code = @"
[Associative]

{

	a = { 4,5 };



	b =[Imperative]

	{

	

		x = 0;

		for( y in a )

		{

			x = x + y;

		}

		return = x;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT06_TestNestedImpBlockWithMissingBracket_negative()
        {
            string code = @"
[Imperative]

{

    x = 5.1;

    [Associative]

    {



    

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test, Ignore]
        public void DebugEQT06_Update_Class_Instance_Argument()
        {
            string code = @"
class A

{

    a : int;

	constructor A ( x : int )

	{

	    a = x;

	}

	def add ( x : int )

	{

	    a = a + x;

		return = A.A(a);

	}

}



t1 = 1;

a1 = A.A(t1);

a2 = a1.a;



r1 = [Imperative]

{

	b1 = a1.add(t1);

	t2 = b1.a;

	t1 = 2;

	return = t2;

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT070_Inherit_constructor_failing_inherited()
        {
            string code = @"
// failing constructor in inherited

class A

{ 

	x : var ;	

	

	constructor A ()

	{

		 x = 10;     	

	}	

}

class B extends A

{ 

	y : var ;	

	

	constructor B ():base.A()

	{

		 y = w;     	

	}	

}

a1 = A.A();

b1=B.B();

a2 = a1.x;//10

b2 = b1.y;//null

b3=b1.x;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT071_Inherit_constructor_failing_inherited_sameproperty()
        {
            string code = @"
// failing constructor in inherited same property failing in inherited

class A

{ 

	x : var ;	

	

	constructor A ()

	{

		 x = 10;     	

	}	

}

class B extends A

{ 

	y : var ;	

	

	constructor B ():base.A()

	{

		 x = w;     	

	}	

}

a1 = A.A();

b1=B.B();

a2 = a1.x;//10

b2 = b1.y;//null

b3=b1.x;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT072_inherit_Class_Constructor_CallingAFunction()
        {
            string code = @"
def Divide : double (a : double, b : double)

{

	return = (a+b)/2;

}



class MyPoint

    

{     

    X: var;

    Y: var;

    constructor Create(x : double, y : double)

    {

        X = Divide(x+y, x+y);

        Y = Divide(x-y, x-y);

    }  

}



class testPoint extends MyPoint

    

{     

    

    constructor Create(x : double, y : double)

    {

        X = Divide(x*y, x/y);

        Y = Divide(x/y, x*y);



    }  

}

p = testPoint.Create(10,10);

pX = p.X;

pY = p.Y;

	

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT073inherit_Constructor_WithSameNameAndDifferentArgumenType()
        {
            string code = @"
class TestClass

    {

    X: var;

    Y: var;

    public constructor Create(x : double, y : double)

        {

        X =  x;

        Y =  y;

        }

    constructor Create(x : bool, y : bool)

        {

        X = x;

        Y = y;

        }

    }

class myClass extends TestClass

{

 public constructor Create(x : double, y : double):base.Create(x,y)

        {

        X =  x;

        Y =  y;

        }

    constructor Create(x : bool, y : bool):base.Create(x,y)

        {

        X = x;

        Y = y;

        }

}



test1 = myClass.Create(1.0,2.0);



test2 = myClass.Create (true, false);

	

	x1 = test1.X;

	y1 = test1.Y;

	

	x2 = test2.X;

	y2 = test2.Y;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT074_Inherit_property_array()
        {
            string code = @"
// array assign value in inherited 

class A

{ 

	y : int[];

	

	

	constructor A ()

	{

		      	

	}	

}

class B extends A

{

	constructor B()

	{

	y={1,2};



	}



}



a1 = B.B();

x1 = a1.y;//null

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT075_Inherit_property_array_modify()
        {
            string code = @"
// array assign value in inherited 

class A

{ 

	y : int[];

	

	

	constructor A ()

	{

	y={1,2};	      	

	}	

}

class B extends A

{

	constructor B()

	{

	y={3,4};	



	}



}



a1 = B.B();

x1 = a1.y;//null

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT076_Inherit_property_array_modifyanitem()
        {
            string code = @"
// array assign value in inherited 

class A

{ 

	y : int[];

	

	

	constructor A ()

	{

	y={1,2};	      	

	}	

}

class B extends A

{

	constructor B()

	{

	

         y[0]=-1; 

	}



}



a1 = B.B();

x1 = a1.y;//null

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT077_Inherit_property_thatdoesnotexist()
        {
            string code = @"
// array assign value in inherited 

class A

{ 

	y : int[];

	

	

	constructor A ()

	{

	y={1,2};	      	

	}	

}

class B extends A

{

	constructor B()

	{

	

         y[0]=-1; 

	}



}



a1 = B.B();

x1 = a1.z;//null

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT078_Inherit_property_singletonconvertedtoarray()
        {
            string code = @"
class A

{ 

	y : int;

	

	

	constructor A ()

	{

    	y=1;	      	

	}	

}

class B extends A

{

	constructor B()

	{

	y={3,4};	



	}



}



a1 = B.B();

x1 = a1.y;//null

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_BreakStatement()
        {
            string code = @"
[Imperative]

{

		i=0;

		temp=0;

		while( i <= 5 )

		{ 

	      i = i + 1;

		  if ( i == 3 )

		      break;

		  temp=temp+1;

		}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_ClassMemerVarAsFunctionPointerImperBlk()
        {
            string code = @"
class A

{

	x:var;

	constructor A()

	{

		x = foo;

	}

}



def foo:double(x:int, y:double = 2.0)

{

	return = x + y;

}

[Imperative]

{

	a = A.A();

	b = a.x(3);	//b=5.0;

	c = a.x(2, 4.0);	//c = 6.0

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_Class_Properties()
        {
            string code = @"
class A

{ 

	static x1 : int;

	constructor A () 

	{	

		x1 = 5;

	}

}



a = A.A();

t1 = a.x1;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_Collection_Assignment_In_Function_Scope()
        {
            string code = @"
def collection :int[] ( a :int[] , b:int , c:int )

{

	a[1] = b;

	a[2] = c;

	return= a;

}



	a = { 1,0,0 };

	[Imperative]

	{

		a = collection( a, 2, 3 );

	}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_Function_Assoc_Inside_Imp()
        {
            string code = @"
[Imperative]

{

	def foo : int( a:int, b : int )

	{

		return = a * b;

	}

	a = 3.5;

	b = 3.5;



	[Associative]

	{

		a = foo( 2, 1 );

	}

	b = 

	[Associative]

	{

		c = foo( 2, 1 );

		return = c;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_Logic_Mixed()
        {
            string code = @"
list1 = { 1, 5, 8, 3, 6 };

list2 = { 4, 1, 6, 3 };



list3 = (list1 > 1) && (list2 > list1) || (list2 < 5); // { true, true, false , true }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_RangeExpressionWithIncrementUsingFunctionCall()
        {
            string code = @"
[Imperative]

{

	def increment : double[] (x : double[]) 

	{

		j = 0;

		for( i in x )

		{

			x[j] = x[j] + 1 ;

			j = j + 1;

		}

		return = x;

	}

	a = {1,2,3};

	b = {3,4,5} ;

	c = {1.5,2.5,4,3.65};

	f = {7,8*2,9+1,5-3,-1,-0.34};





	//nested collection

	d = {3.5,increment(c)};

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_ScopeVariableInBlocks()
        {
            string code = @"
[Imperative]

{

	a = 4;

	b = a*2;

	temp = 0;

	if(b==8)

	{

		i=0;

		temp=1;

		if(i<=a)

		{

		  temp=temp+1;

		}

    }

	a = temp;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_String_Replication()
        {
            string code = @"
a = ""a"";

bcd = {""b"",""c"",""d""};



r = a +bcd;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_String_Replication_1()
        {
            string code = @"
a = {""a""};

bc = {""b"",""c""};



str = a + bc;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_String_Replication_2()
        {
            string code = @"
a = ""a"";

b = {{""b""},{""c""}};



str = a +b;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_TestBlockWithIncorrectBlockName_negative()
        {
            string code = @"
[imperitive]

{

    x = 5.1;    

    

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_TestForLoopUsingLocalVariable()
        {
            string code = @"
[Imperative]

{

	a = { 1, 2, 3, 4, 5 };

	x = 0;

	for( y in a )

	{

		local_var = y + x;	

        x = local_var + y;		

	}

	z = local_var;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_TestGCEndofForBlk()
        {
            string code = @"
import(""DisposeVerify.ds"");



[Imperative]

{

  

DisposeVerify.x = 1;

arr = { A.A(), A.A(), A.A() };

[Associative]

{

    [Imperative]

    {

        for(i in arr)

        {

            mm = i;

            mm2 = A.A();

        }

        v1 = DisposeVerify.x; // 3

    }

}

v2 = DisposeVerify.x; // 4

arr = null;

v3 = DisposeVerify.x; // 7



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_TestOutsideBlock__2_()
        {
            string code = @"
b = 2;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_TestOutsideBlock()
        {
            string code = @"
b = 2;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT07_Update_Array_Variable()
        {
            string code = @"
a = 1..3;

c = a;

b = [ Imperative ]

{

    count = 0;

	for ( i in a )

	{

	    a[count] = i + 1;

		count = count+1;

	}

	return = a;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_Class_Properties()
        {
            string code = @"
class A

{ 

	x1 : int ;

	x2 : double[][];

	

	constructor A () 

	{	

		x1  = { true, 2.5 };  

		x2 = B.B();		

	}

}

class B

{ 

	x1 : int ;

		

	constructor B () 

	{	

		x1 = 1;

	}

}



a = A.A();

t1 = a.x1;

t2 = a.x2[1].x1;









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_Collection_Assignment_In_Function_Scope_2()
        {
            string code = @"
def foo ( a )

{

	return= a;

}



	a = { 1, foo( 2 ) , 3 };

	

	[Imperative]

	{

		b = { foo( 4 ), 5, 6 };

	}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_ContinueStatement()
        {
            string code = @"
[Imperative]

{

		i = 0;

		temp = 0;

		while ( i <= 5 )

		{

		  i = i + 1;

		  if( i <= 3 )

		  {

		      continue;

	      }

		  temp=temp+1;

		 

		}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_FunctionPointerUpdateTest()
        {
            string code = @"
def foo1:int(x:int)

{

	return = x;

}



def foo2:double(x:int, y:double = 2.0)

{

	return = x + y;

}



a = foo1;

b = a(3);

a = foo2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_Function_From_Inside_Class_Constructor()
        {
            string code = @"
def add_1 : int( a:int )

{

	return = a + 1;

}



class A

{

	a : var;



	constructor CreateA ( a1 : int )

	{

		a = add_1(a1);

	}

}



[Imperative]

{

	arg = 1;

	b = 1;

	

    [Associative]

	{

		A_inst = A.CreateA( arg );

		a = A_inst.a;

	}



    [Associative]

    {

        b = [Imperative]

        {

            A_inst = A.CreateA( arg );

            return = A_inst.a;

        }

    }

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_Logic_Single_List_And_Value()
        {
            string code = @"
list1 = { 1, 2, 3, 4, 5 };

a = 3;



list2 = a > list1; // { true, true, false, false, false }

list3 = list1 > a; // { false, false, false, true, true }

list4 = a >= list1; // { true, true, true, false, false }

list5 = list1 >= a; // { false, false, true, true, true }

list6 = a < list1; // { false, false, false, true, true }

list7 = list1 < a; // { true, true, false, false, false }

list8 = a <= list1; // { false, false, true, true, true }

list9 = list1 <= a; // { true, true, true, false, false }



list10 = list2 && true; // { true, true, false, false, false }

list11 = false && list2; // { false, false, false, false, false }

list12 = list2 || true; // { true, true, true, true, true }

list13 = false || list2; // { true, true, false, false, false }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_NestedBlocks()
        {
            string code = @"
[Associative]

{

	a = 4;

	

	[Imperative]

	{

		i=10;

		temp=1;

		if(i>=-2)

		{

		  temp=2;

		}

    }

	b=2*a;

	a=2;

              

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_RangeExpressionWithIncrementUsingVariables()
        {
            string code = @"
[Imperative]

{

	def square : double ( x :double ) 

	{

		return = x * x;

	}



	z = square(4);

	x = 1 ;

	y = -2 ;

	a = 1..2 ;

	b = 1..6..3;

	c = 2..3..1;

	d = 2..10..2;

	e1 = 1..3..0.5;

	f = 2..4..0.2 ;



	//using variables

	h = z..3..-4;

	i = 1..z..x;

	j = z..x..y; 

	k = a..b..x ;

	l = a..c..x ;



	//using function call 

	g = 6..9.5..square(-1);

	m = 0.8..square(1)..0.1; 

	n = square(1)..0.8..-0.1;

	o = 0.8..square(0.9)..0.01; 



}



/*

result

z = 16

x = 1

y = -2

a = {1,2}

b = {1,4}

c = {2,3}

d = {2,4,6,8,10}

e1 = {1.000000,1.500000,2.000000,2.500000,3.000000}

f = {2.000000,2.200000,2.400000,2.600000,2.800000,3.000000,3.200000,3.400000,3.600000,3.800000,4.000000}

h = {16,12,8,4}

i = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16}

j = {16,14,12,10,8,6,4,2}

k = {{1},{2,3,4}}

l = {{1,2},{2,3}}

g = {6.000000,7.000000,8.000000,9.000000}

m = {0.800000,0.900000,1.000000}

n = {1.000000,0.900000,0.800000}

o = {0.800000,0.810000}

*/
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_String_Inline()
        {
            string code = @"
a = ""a"";

b = ""b"";



r = a>b? a:b;



r1 = a==b? ""Equal"":""!Equal"";
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_String_Inline_2()
        {
            string code = @"
a = ""a"";

b = ""b"";



r = a>b? a:b;



r1 = a==b? ""Equal"":""!Equal"";



b = ""a"";
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_TestBlockWithIncorrectBlockName_negative()
        {
            string code = @"
[Imperative]

{

    x = 5.1; 

    [assoc]

    {

        y = 2;

    }

    

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_TestCyclicReference__2_()
        {
            string code = @"
[Associative]

{

	a = 2;

        b = a *3;

        a = 6.5;

        a = b / 3; 

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_TestCyclicReference()
        {
            string code = @"
[Imperative]

{

	a = 2;

        b = a *3;

        a = 6.5;

        a = b / 3; 

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_TestForLoopInsideFunctionDeclaration()
        {
            string code = @"
[Imperative]

{

	def sum : double ( a : double, b : double, c : double )

	{   

		x = 0;

	    z = {a, b, c};

		for(y in z)

		{

			x = x + y;

		}

		

		return = x;

	}

	

	

	

	y = sum ( 1.0, 2.5, -3.5 );

	

	z = sum ( -4.0, 5.0, 6.0 );



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT08_TestGCArray02()
        {
            string code = @"
import(""DisposeVerify.ds"");



[Imperative]

{

  

DisposeVerify.x = 1;



arr = { A.A(), A.A(), A.A() };



b = arr;

b = null;

v1 = DisposeVerify.x; // 1

arr = null;

v2 = DisposeVerify.x; // 4



a1 = A.A();

a2 = A.A();

a3 = A.A();

arr2 = { a1, a2, a3 };

b2 = arr2;

b2 = null;

v3 = DisposeVerify.x; // 4

arr2 = null; 

v4 = DisposeVerify.x; // 4

a1 = null; 

v5 = DisposeVerify.x; // 5

a2 = null;

v6 = DisposeVerify.x; // 6

a3 = null; 

v7 = DisposeVerify.x; // 7



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }

        // TODO Jun: Why does this testcase cycle until it crashes due to a null node at runtime?
        [Test, Ignore]
        public void DebugEQT08_Update_Array_Variable()
        {
            string code = @"
a = 1..3;

c = a;

b = [ Imperative ]

{

    count = 0;

	for ( i in a )

	{

	    if ( i > 0 )

		{

		    a[count] = i + 1;

		}

		count = count+1;

	}

	return = a;

}





d = [ Imperative ]

{

    count2 = 0;

	while (count2 <= 2 ) 

	{

	    if ( a[count2] > 0 )

		{

		    a[count2] = a[count2] + 1;

		}

		count2 = count2+1;

	}

	return = a;

}



e = b;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_2D_Collection_Assignment_In_Class_Scope()
        {
            string code = @"
class coll

{

	a : var[][];

	

	constructor Create ()

	{

		a = { {1,2} , {3,4} };

	}

	

	def ret ()

	{

		return= a;

	}

}



	c1 = coll.Create();

	b = c1.ret();

	c = b[1];

	

	[Imperative]

	{	

		c2 = coll.Create();

		b1 = c2.ret();

		d = b1[0];

	}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_Class_Inheritance()
        {
            string code = @"
class B

{ 

	x3 : int ;

		

	constructor B () 

	{	

		x3 = 2;

	}

}



class A extends B

{ 

	x1 : int ;

	x2 : double;

	

	constructor A () : base.B ()

	{	

		x1 = 1; 

		x2 = 1.5;		

	}

}





a1 = A.A();

b1 = a1.x1;

b2 = a1.x2;

b3 = a1.x3;













";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_Defect_1449829()
        {
            string code = @"
[Associative]

{ 

 a = 2;

[Imperative]

{   

	b = 1;



    if(a == 2 )

	{

	b = 2;

    }

    else 

    {

	b = 4;

    }

}

}

  
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_Function_From_Inside_Class_Constructor()
        {
            string code = @"
def add_1 : int( a:int )

{

	return = a + 1;

}



class A

{

	a : var;



	constructor CreateA ( a1 : int )

	{

		a = add_1(a1);

	}

}



[Associative]

{

	arg = 1;

	b = 1;

    [Imperative]

    {

        [Associative]

        {

            A_inst = A.CreateA( arg  );

            a = A_inst.a;

        }

    }

	b = 

	[Imperative]

	{

		A_inst = A.CreateA( arg  );

		return = A_inst.a;

	}

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_NegativeTest_Non_FunctionPointer()
        {
            string code = @"
def foo:int(x:int)

{

	return = x;

}



a = 2;

b = a();
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_NestedIfElseInsideWhileStatement()
        {
            string code = @"
[Imperative]

{

		i=0;

		temp=0;

		while(i<=5)

		{ 

			i=i+1;

			if(i<=3)

			{

				temp=temp+1;

			}		  

			elseif(i==4)

			{

				temp = temp+1;

				if(temp==i) 

				{

					temp=temp+1;

				}			

			}

			else 

			{

				if (i==5)

				{ temp=temp+1;

				}

			}

		}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_NestedWhileStatement()
        {
            string code = @"
[Imperative]

{

	i = 1;

	a = 0;

	p = 0;

	

	temp = 0;

	

	while( i <= 5 )

	{

		a = 1;

		while( a <= 5 )

		{

			p = 1;

			while( p <= 5 )

			{

				temp = temp + 1;

				p = p + 1;

			}

			a = a + 1;

		}

		i = i + 1;

	}

}  
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_Pass_1_single_list_of_class_type()
        {
            string code = @"
class Point_OnX

{

	x : int;

	

	constructor Point_3DCtor(p : Point_3D)

	{

		x = p.x;

	}

}



class Point_3D

{

	x : int;

	y : int;

	z : int;

	

	constructor ValueCtor(_x : int, _y : int, _z : int)

	{

		x = _x;

		y = _y;

		z = _z;

	}

}



list =  {

			Point_3D.ValueCtor(1, 2, 3), 

			Point_3D.ValueCtor(4, 5, 6),

			Point_3D.ValueCtor(7, 8, 9)

		};

		

list2 = Point_OnX.Point_3DCtor(list);



list2_0_x = list2[0].x; // 1

list2_1_x = list2[1].x; // 4

list2_2_x = list2[2].x; // 7
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_RangeExpressionWithApproximateIncrement()
        {
            string code = @"
[Imperative]

{



	def square : double ( x: double ) 

	{

		return = x * x;

	}

	

	x = 0.1; 



	a = 0..2..~0.5;

	b = 0..0.1..~square(0.1);



	f = 0..0.1..~x;      

	g = 0.2..0.3..~x;    

	h = 0.3..0.2..~-0.1; 

	

	j = 0.8..0.5..~-0.3;

	k = 0.5..0.8..~0.3; 



	l = 0.2..0.3..~0.0;



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_Replication_On_Operators_In_Range_Expr()
        {
            string code = @"
[Imperative]

{

	z5 = 4..1; // { 4, 3, 2, 1 }

	z2 = 1..8; // { 1, 2, 3, ... , 6, 7, 8 }

	z6 = z5 - z2 + 0.3;  // { 3.3, 1.3, -1.7, -2.7 }

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_String_DynamicArr()
        {
            string code = @"
a[1] = foo(""1"" + 1);

a[2] = foo(""2"");

a[10] = foo(""10"");

a[ - 2] = foo("" - 2"");//smart formatting



r = 

[Imperative]

{

    i = 5;

    while(i < 7)

    {

        a[i] = foo(""whileLoop"");

        i = i + 1;

    }

    return = a;

}



def foo(x:var)

{

    return = x + ""!!"";

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_TestForLoopWithBreakStatement()
        {
            string code = @"
[Imperative]

{

	a = { 1,2,3 };

	x = 0;

	for( i in a )

	{

		x = x + 1;

		break;

	}	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_TestGCPassingArguments()
        {
            string code = @"
import(""DisposeVerify.ds"");

DisposeVerify.x = 1;



def foo : int(p : A[])

{

	return = 10;

}

def foo2 : int(p : A)

{

	return = 10;

}



a1 = A.A();

a2 = { A.A(), A.A(), A.A() };



x = foo2(a1);

y = foo(a2);



v1 = DisposeVerify.x; // 1

v2 = DisposeVerify.x; // 1



a1 = null;

v3 = DisposeVerify.x; // 2

a2 = null;

v4 = DisposeVerify.x; // 5





b = foo2(A.A());

v5 = DisposeVerify.x; // 6



c = foo( { A.A(), A.A(), A.A() } );

v6 = DisposeVerify.x; // 9
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_TestInNestedBlock__2_()
        {
            string code = @"
[Associative]

{

	a = 4;

	b = a + 2;

	[Imperative]

	{

		b = 0;

		c = 0;

		if ( a == 4 )

		{

			b = 4;

		}			

		else

		{

			c = 5;

		}



		d = b;

		e = c;	

        g2 = g1;	

	}

	f = a * 2;

    g1 = 3;

    g3 = g2;

      

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT09_TestInNestedBlock()
        {
            string code = @"
[Imperative]

{

	a = 4;

	b = a + 2;

    [Associative]

    {

        [Imperative]

        {

            b = 0;

            c = 0;

            if ( a == 4 )

            {

                b = 4;

            }			

            else

            {

                c = 5;

            }



            d = b;

            e = c;	

            g2 = g1;	

        }

    }

	f = a * 2;

    g1 = 3;

    g3 = g2;

      

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test, Ignore]
        public void DebugEQT09_Update_Across_Multiple_Imperative_Blocks()
        {
            string code = @"
a = 1;

b = a;

c = [ Imperative ]

{

    a = 2;

	return = a;

}

d = [ Imperative ]

{

    a = 3;

	return = a;

}

e = c;

f = d;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT100_Class_inheritance_replication()
        {
            string code = @"
class A

{

        def Test : int[] (a : A)

        { return = {2}; }

}



class B extends A

{

        def Test : int (b : B)

        { return = 5; }

}



class C extends B

{

}

 

c = C.C();

b = c.Test(c);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT100_Class_inheritance_replication_2()
        {
            string code = @"
class A

{

        def Test : int(b : B)

        { return = 2; }

}



class B extends A

{

        def Test : int[] (a : A)

        { return = {5}; }

}



class C extends B

{

}

 

c = C.C();

result = c.Test(c);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_2D_Collection_Assignment_In_Function_Scope()
        {
            string code = @"
	def foo( a:int[] )

	{

		a[0][0] = 1;

		return= a;

	}





	b = { {0,2,3}, {4,5,6} };

	d = foo( b );

	c = d[0];



		

		

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_Class_Inheritance()
        {
            string code = @"
class B

{ 

	x3 : int ;

		

	constructor () 

	{	

		x3 = 2;

	}

}



class A extends B

{ 

	x1 : int ;

	x2 : double;

	

	constructor () : base ()

	{	

		x1 = 1; 

		x2 = 1.5;		

	}

}





a1 = A();

b1 = a1.x1;

b2 = a1.x2;

b3 = a1.x3;













";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_Defect_1449732()
        {
            string code = @"
[Imperative]

{

	def fn1:int(a:int,b:int)

	{

	return = a + b -1;

	}

 

	c = fn1(3,2);

} 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_Function_From_Inside_Class_Method()
        {
            string code = @"
def add_1 : int( a:int )

{

	return = a + 1;

}



class A

{

	a : var;



	constructor CreateA ( a1 : int )

	{

		a = add_1(a1);

	}

	def add1 : int(  )

    {

	    return = add_1(a);

    }

}



[Associative]

{

	arg = 1;

	b = 1;



    [Imperative]

    {

        [Associative]

        {

            A_inst = A.CreateA( arg  );

            a = A_inst.add1();

        }

    }



	b = 

	[Imperative]

	{

		A_inst = A.CreateA( arg  );

		return = A_inst.add1();

	}

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_NegativeTest_UsingFunctionNameAsVarName_Global()
        {
            string code = @"
def foo:int(x:int)

{

	return = x;

}



foo = 3;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_Pass_2_Lists_Different_Length_2_Integers()
        {
            string code = @"
class Point_4D

{

	x : var;

	y : var;

	z : var;

	w : var;

	

	constructor ValueCtor(_x : int, _y : int, _z : int, _w : int)

	{

		x = _x;

		y = _y;

		z = _z;

		w = _w;

	}

	

	def GetValue : int()

	{

		return = x + y + z + w;

	}

}



list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

list2 = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };

pointList = Point_4D.ValueCtor(list1, list2, 66, 88);



pointList_0_x = pointList[0].GetValue(); // 166

pointList_5_x = pointList[5].GetValue(); // 176

pointList_9_x = pointList[9].GetValue(); // 184
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_RangeExpressionWithReplication()
        {
            string code = @"
[Imperative]

{



	//step value greater than the end value

	a = 1..2..3;

	b = 3..4..3;



	c = a..b..a[0]; // {{1,2,3}}



	d = 0.5..0.9..0.1;

	e1 = 0.1..0.2..0.05;

	f = e1<1>..d<2>..0.5;

	g = e1..d..0.2;

	h = e1<2>..d<1>..0.5;



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_String_ModifierStack()
        {
            string code = @"
a =

{

    ""a"";

    + ""1"" => a1;

    + { ""2"", ""3"" } => a2;

    ""b"" => b;

}



r = a;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_TestGCReturnArguments()
        {
            string code = @"
import(""DisposeVerify.ds"");

DisposeVerify.x = 1;



def foo : A(p : A[])

{

	return = p[0];

}



[Imperative]

{

  

m = foo( { A.A(), A.A(), A.A() } );

v1 = DisposeVerify.x; // 3

m = null; 

v2 = DisposeVerify.x; // 4



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_TestInFunctionScope__2_()
        {
            string code = @"
[Associative]

{

	 def add:double( n1:int, n2:double )

	 {

		  

		  return = n1 + n2;



	 }



	 test = add(2,2.5);

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_TestInFunctionScope()
        {
            string code = @"
[Imperative]

{

	 def add:double( n1:int, n2:double )

	 {

		  

		  return = n1 + n2;



	 }



	 test = add(2,2.5);

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_TestNestedForLoops()
        {
            string code = @"
[Imperative]

{

	a = { 1,2,3 };

	x = 0;

	for ( i in a )

	{

		for ( j in a )

        {

			x = x + j;

		}

	}

}	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_TypeConversion()
        {
            string code = @"
[Imperative]

{

    temp = 0;

    a=4.0;

    if(a==4)

        temp=1;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_Update_Array_Across_Multiple_Imperative_Blocks()
        {
            string code = @"
a = 1..3;

b = a;

c = [Imperative ]

{

    x = { 10, a[1], a[2] };

	a[0] = 10;

	return = x;

}

d = [ Imperative ]

{

    a[1] = 20;

	return = a;

}

e = c;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT10_WhilewithAssgnmtStatement_Negative()
        {
            string code = @"
[Imperative]

{

		i = 2;

		temp = 1;

		while( i = 2 )

		{ 

	        i = i + 1 ;

		    temp = temp + 1 ;

		}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_2D_Collection_Assignment_Heterogeneous()
        {
            string code = @"
[Imperative]

{

	a = { {1,2,3}, {4}, {5,6} };

	b = a[1];

	a[1] = 2;

	a[1] = a[1] + 1;

	a[2] = {7,8};

	c = a[1];

	d = a[2][1];

}	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_Class_Inheritance()
        {
            string code = @"
class B

{ 

	x3 : int ;

		

	constructor B(a) 

	{	

		x3 = a;

	}

	def foo ( )

	{

		return = x3;

	}

	def foo ( a : int)

	{

		return = x3 + a;

	}

	

	def foo2 ( a : int)

	{

		return = x3 + a;

	}

}



class A extends B

{ 

	x1 : int ;

	x2 : double;

	

	constructor A(a1,a2,a3) : base.B(a3)

	{	

		x1 = a1; 

		x2 = a2;		

	}

	def foo ( )

	{

		return = {x1, x2};

	}

}





a1 = A.A( 1, 1.5, 0 );

b1 = a1.foo();

b2 = a1.foo2(1);

















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_Defect_1450174()
        {
            string code = @"
[Imperative]

{

	def function1:double(a:int,b:double)

	{ 

	return = a * b;

	}	

 

	c = function1(2 + 3,4.0 + 6.0 / 4.0);

}

  
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_Function_From_Inside_Class_Method()
        {
            string code = @"
def add_1 : int( a:int )

{

	return = a + 1;

}



class A

{

	a : var;



	constructor CreateA ( a1 : int )

	{

		a = add_1(a1);

	}

	def add1 : int(  )

    {

	    return = add_1(a);

    }

}



[Imperative]

{

	arg = 1;

	b = 1;

	[Associative]

	{

		A_inst = A.CreateA( arg );

		a = A_inst.add1();

	}

    b = [Associative]

    {

        return = [Imperative]

        {

            A_inst = A.CreateA( arg );

            return = A_inst.add1();

        }

    }

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_NegativeTest_UsingFunctionNameAsVarName_Global_ImperBlk()
        {
            string code = @"
[Imperative]

{

	def foo:int(x:int)

	{

		return = x;

	}



	foo = 3;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_Pass_2_lists_of_class_type_same_length_and_1_variable_of_class_type()
        {
            string code = @"
class Point_1D

{

	x : int;

	

	constructor ValueCtor(_x : int)

	{

		x = _x;

	}

}



class Point_3D

{

	x : int;

	y : int;

	z : int;

	

	constructor Point_1DCtor(px : Point_1D, py : Point_1D, pz : Point_1D)

	{

		x = px.x;

		y = py.x;

		z = pz.x;

	}

}



p1 = {

		Point_1D.ValueCtor(1),

		Point_1D.ValueCtor(2),

		Point_1D.ValueCtor(3)

	 };



list = Point_3D.Point_1DCtor(p1, p1, Point_1D.ValueCtor(4)); 



list_0_x = list[0].x; // 1

list_1_y = list[1].y; // 2

list_2_z = list[2].z; // 4

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_RangeExpressionUsingClasses()
        {
            string code = @"
class point

{

		x : var[];

		

		constructor point1(a : int[])

		{

			x = a;

		}

		

		def foo(a : int)

		{

			return = a;

		}

}



def foo1(a : int)

		{

			return = a;

		}

def foo2(a : int[])

		{

			return = a[2];

		}

[Imperative]

{



	x1 = 1..4;

	//x1 = { 1, 2, 3, 4 };

	a = point.point1(x1);

	a1 = a.x;

	a2 = a.foo(x1);	

	a3 = foo1(x1[0]);

	a4 = foo2(x1);



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_String_Imperative()
        {
            string code = @"
r =

[Imperative]

{

    a = ""a"";

    b = a;

    

}

c = b;

b = ""b1"";

a = ""a1"";



m = ""m"";

n = m;

n = ""n"";

m = m+n;



//a =""a1""

//b = ""b1""

//c = ""b1"";

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_TestForLoopWithSingleton()
        {
            string code = @"
[Imperative]

{

	a = {1};

	b = 1;

	x = 0;

 

	for ( y in a )

	{

		x = x + 1;

	}

 

	for ( y in b )

	{

		x = x + 1;

	}

} 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_TestGCLangBlkInFunction()
        {
            string code = @"
import(""DisposeVerify.ds"");



def foo : A(a : A)

{

	aaa = A.A();

	[Imperative]

	{

		aaaa = aaa;

		c = a;

	}

	return = aaa;

}

DisposeVerify.x = 1;

aa = A.A();

bb = foo(aa);

v1 = DisposeVerify.x; // 2

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_TestIfElseUsingFunctionCall()
        {
            string code = @"
[Imperative]

{

 def add : double (a :double, b:double)

 {

     return  = a + b;

 }

 

 a=4.0;

 b = 4.0;

 if(a<add(1.0,2.0))

 {

     a = 1;

 }

 else

 {

     a = 0;

 }

 

 if(add(1.5,2.0) >= a)

 {

     b = 1;

 }

 else

 {

     b = 0;

 }

 

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_TestInClassScope__2_()
        {
            string code = @"


                                 class A 

                                 {

                                      

                                      P1:int;

                                      constructor A(p1:int)

                                      {

                                          P1 = p1;

                                      }

          

                                 }



                                 a1 = A.A(2);

                                 b1 = a1.P1;

                            



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_TestInClassScope()
        {
            string code = @"


                                 class A 

                                 {

                                      

                                      P1:int;

                                      constructor A(p1:int)

                                      {

                                          P1 = p1;

                                      }

          

                                 }



                                 a1 = A.A(2);

                                 b1 = a1.P1;

                            



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_Update_Undefined_Variables()
        {
            string code = @"
b = a;

[Imperative]

{

    a = 3;

}

[Associative]

{

    a = 4;	

}

c = b;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT11_WhilewithLogicalOperators()
        {
            string code = @"
[Imperative]

{

		i1 = 5;

		temp1 = 1;

		while( i >= 2) 

		{ 

	        i1=i1-1;

		    temp1=temp1+1;

		}

		

		i2 = 5;

		temp2 = 1;

		while ( i2 != 1 )

		{

		    i2 = i2 - 1;

		    temp2 = temp2 + 1;

		}

         

		temp3 = 2;

        while( i2 == 1 )

		{

		     temp3 = temp3 + 1;

		     i2 = i2 - 1;

		} 

		while( ( i2 == 1 ) && ( i1 == 1 ) )  

        {

             temp3=temp3+1;

		     i2=i2-1;

        }

		temp4 = 3;

		while( ( i2 == 1 ) || ( i1 == 5 ) )

        {

            i1 = i1 - 1;		

            temp4 = 4;

        }       

 

}		



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT12_Char_Function()
        {
            string code = @"
def foo ( x)

{

	b1= x ;

	return =b1;



}

c1 = foo( '1.5');

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT12_Collection_Assignment_Block_Return_Statement()
        {
            string code = @"
a;b;c1;c2;
[Associative]

{

	a = 3;

	

	b = [Imperative]

	{

		c = { 1,2,3 };

		if( c[1] <= 3 )

		return= c;

	}

	

	b[2] = 4;

	a = b;

	c1 = a[1];

	c2 = a[2];

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT12_Defect_1450599()
        {
            string code = @"
[Imperative]



	x = 5;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT12_Function_From_Inside_Function()
        {
            string code = @"
def add_1 : double( a:double )

{

	return = a + 1;

}



[Associative]

{

	def add_2 : double( a:double )

	{

		return = add_1( a ) + 1;

	}

	

	a = 1.5;

	b = add_2 (a );

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT12_NegativeTest_UsingGlobalFunctionNameAsMemVarName_Class()
        {
            string code = @"
def foo:int(x:int)

{

	return = x;

}



class A

{

	foo : var;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT12_Pass_2_Lists_Same_Length_1_Integer()
        {
            string code = @"
class Point_3D

{

	x : var;

	y : var;

	z : var;



	constructor ValueCtor(_x : int, _y : int, _z : int)

	{

		x = _x;

		y = _y;

		z = _z;

	}



	def GetValue : int()

	{

		return = x + y + z;

	}

}



list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

list2 = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

pointList = Point_3D.ValueCtor(list1, list2, 99);



pointList_0_x = pointList[0].GetValue(); // 111

pointList_5_x = pointList[5].GetValue(); // 121 

pointList_9_x = pointList[9].GetValue(); // 129
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT12_RangeExpressionUsingNestedRangeExpressions()
        {
            string code = @"
[Imperative]

{



	x = 1..5..2; // {1,3,5}

	y = 0..6..2; // {0,2,4,6}



	a = (3..12..3)..(4..16..4); // {3,6,9,12} .. {4..8..12..16}

	b = 3..00.6..#5;      // {3.0,2.4,1.8,1.2,0.6}

	//c = b[0]..7..#1;    //This indexed case works

	c = 5..7..#1;         //Compile error here , 5

	d = 5.5..6..#3;       // {5.5,5.75,6.0}

	e1 = -6..-8..#3;      //{-6,-7,-8}

	f = 1..0.8..#2;       //{1,0.8}

	g = 1..-0.8..#3;      // {1.0,0.1,-0.8}

	h = 2.5..2.75..#4;    //{2.5,2.58,2.67,2.75}

	i = x[0]..y[3]..#10;//1..6..#10

	j = 1..0.9..#4;// {1.0, 0.96,.93,0.9}

	k= 1..3..#0;//null



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT12_TestForLoopWith2DCollection()
        {
            string code = @"
[Imperative]

{

	a = {{1},{2,3},{4,5,6}};

	x = 0;

	i = 0;

    for (y in a)

	{

		x = x + y[i];

	    i = i + 1;	

	}



	z = 0;

    for (i1 in a)

	{

		for(j1 in i1)

		{

		    z = z + j1;

		}

	}

			

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT12_TestGCIfElseInFunction()
        {
            string code = @"
import(""DisposeVerify.ds"");



[Imperative]

{

	def foo : int(a : A)

	{

		a1 = A.A();

		if (1 == 1)

		{

			a2 = A.A();

		}

		

		return = 10;

	}

	DisposeVerify.x = 1;

	aaaa = [Associative]

	{

		aaaaaaa = A.A();

		return = A.A();

	}

	if (1 == 1)

		aaaaa = A.A();

	aa = A.A();

	cc = foo(aa);

	v1 = DisposeVerify.x;

}



v2 = DisposeVerify.x; // 4
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT12_TestIfElseUsingClassProperty()
        {
            string code = @"


	class A 

    {                                      

		P1:var;

        constructor A(p1:int)

        {

            P1 = p1;

        }

          

    }

    

	[Imperative]

	{

	    a1 = A.A(2);

        b1 = a1.P1; 

		x = 2;

		y = 2;

		if(a1.P1 == 2 )

		{

		    x = 1;

		}

		else

		{

			x = 0;

		}

		

		if(3 < a1.P1  )

		{

		    y = 1;

		}

		else

		{

			y = 0;

		}

	}

                              



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT12_TestUsingMathAndLogicalExpr__2_()
        {
            string code = @"
[Associative]

{

  e = 0;

  a = 1 + 2;

  b = 0.1 + 1.9;

  b = a + b;

  c = b - a - 1;

  d = a + b -c;

  if( c < a )

  {

     e = 1;

  }

  else

  {

    e = 2;

  }



  if( c < a || b > d)

  {

     e = 3;

  }

  else

  {

    e = 4;

  }



  if( c < a && b > d)

  {

     e = 3;

  }

  else

  {

    e = 4;

  }



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT12_TestUsingMathAndLogicalExpr()
        {
            string code = @"
[Imperative]

{

  e = 0;

  a = 1 + 2;

  b = 0.1 + 1.9;

  b = a + b;

  c = b - a - 1;

  d = a + b -c;

  if( c < a )

  {

     e = 1;

  }

  else

  {

    e = 2;

  }



  if( c < a || b > d)

  {

     e = 3;

  }

  else

  {

    e = 4;

  }



  if( c < a && b > d)

  {

     e = 3;

  }

  else

  {

    e = 4;

  }



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT12_Update_Undefined_Variables()
        {
            string code = @"
b = a;

[Imperative]

{

    a = 3;

}

[Associative]

{

    a = 4;

    d = b + 1;	

}

c = b;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT12_WhileWithFunctionCall()
        {
            string code = @"
[Imperative]

{ 

	def fn1 :int ( a : int )

	{   

		i = 0;

		temp = 1;

		while ( i < a )

		{

			temp = temp + 1;

			i = i + 1;

		}

		return = temp;

	}



	testvar = 8;

	

	while ( testvar != fn1(6) )

	{ 

		testvar=testvar-1;

	}



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT13_2D_Collection_Assignment_Block_Return_Statement()
        {
            string code = @"
a;
b;
c1;c2;
[Associative]

{

	a = 3;

	

	b = [Imperative]

	{

		c = { { 1,2,3 } , { 4,5,6 } } ;

		return= c;

	}

	

	b[0][0] = 0;

	a = b;

	c1 = a[0];

	c2 = a[1][2];

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT13_Class_Default_Constructors()
        {
            string code = @"
class A

{ 

	x : int = 5 + 4 ;

	y : var;

	z : bool;

	w : B;

	p : int [];

	

}



class B

{ 

	x : int  ;	

	

}



a1 = A.A();

x1 = a1.x;

y1 = a1.y;

z1 = a1.z;

w1 = a1.w;

p1 = a1.p;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT13_Defect_1450527()
        {
            string code = @"
[Associative]
{
	a = 1;
	temp=0;
	[Imperative]
	{
	    i = 0;
	    if(i <= a)
	    {
	        temp = temp + 1;
	    }
	}
	a = 2;
}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT13_DoWhileStatment_negative()
        {
            string code = @"
[Imperative]

{

	 a = 1;

	 temp = 1;

	 do

	 {  

	    temp = temp + 1;

	    a = a + 1;

	  

	 } while(a<3);

} 

  
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT13_Function_From_Inside_Function()
        {
            string code = @"
def add_1 : double( a:double )

{

	return = a + 1;

}



[Imperative]

{

	def add_2 : double( a:double )

	{

		return = add_1( a ) + 1;

	}

	

	a = 1.5;

	b = add_2 (a );

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT13_GCTestComplexCase()
        {
            string code = @"
import(""DisposeVerify.ds"");





def flatten(arr : A[][])

{

	solids = {};

	i = 0;

	[Imperative]

	{

		for(obj in arr)

		{

			for(solid in obj)

			{

				solids[i] = solid;

				i = i + 1;

			}

		}

	}

	return = solids;

}



DisposeVerify.x = 1;

arrr = { { A.A(), A.A(), A.A() }, { A.A(), A.A(), A.A() }, { A.A(), A.A(), A.A() } };

arrr2 = flatten(arrr);

v1 = DisposeVerify.x; // 1

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT13_IfElseIf()
        {
            string code = @"
[Imperative]

{

 a1 = -7.5;

 

 temp1 = 10.5;



 

 if( a1>=10.5 )

 {

 temp1 = temp1 + 1;

 }

 

 elseif( a1<2 )

 {

 temp1 = temp1 + 2;

 }



 

  

 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT13_NegativeTest_UsingMemFunctionNameAsMemVarName_Class()
        {
            string code = @"
def foo:int(x:int)

{

	return = x;

}



class A

{

	memFoo : var;

	def memFoo()

	{

		return = 2;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT13_Pass_3_Lists_Different_Length()
        {
            string code = @"
class Point_3D

{

	x : var;

	y : var;

	z : var;



	constructor ValueCtor(_x : int, _y : int, _z : int)

	{

		x = _x;

		y = _y;

		z = _z;

	}



	def GetValue : int()

	{

		return = x + y + z;

	}

}



list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

list2 = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };

list3 = { 25, 26, 27, 28, 29, 30 };

pointList = Point_3D.ValueCtor(list1, list2, list3);



pointList_0_x = pointList[0].GetValue(); // 37

pointList_3_x = pointList[3].GetValue(); // 46

pointList_5_x = pointList[5].GetValue(); // 52
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT13_RangeExpressionWithStartEndValuesUsingFunctionCall()
        {
            string code = @"
[Imperative]

{



	def even : double (a : int) 

	{

		if((a % 2)>0)

		return = (a+(a * 0.5));

		else

		return = (a-(a * 0.5));

	}



	d = 3;

	x = 1..2..#d;

	a = even(2) ;

	b = 1..a;

	c = even(3)..even(5)..#6;

	d = even(5)..even(6)..#4;

	e1 = e..4..#3;  //e takes default value 2.17

	f = even(3)..(even(8)+4*0.5)..#3;

	g = even(2)+1..1..#5;

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT13_TestForLoopWithNegativeAndDecimalCollection()
        {
            string code = @"
[Imperative]

{

	a = { -1,-3,-5 };

	b = { 2.5,3.5,4.2 };

	x = 0;

	y = 0;

    for ( i in a )

	{

		x = x + i;

	}

	

	for ( i in b )

	{

		y = y + i;

	}

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT13_TestUsingMathAndLogicalExpr__2_()
        {
            string code = @"
[Associative]

{

  a = 3.5;

  b = 1.5;

  c = a + b; 

  d = a - c;

  e = a * d;

  f = a / e; 



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT13_TestUsingMathAndLogicalExpr()
        {
            string code = @"
[Imperative]

{

  a = 3.5;

  b = 1.5;

  b = a + b; 

  b = a - b;

  b = a * b;

  b = a / b; 



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test, Ignore]
        public void DebugEQT13_Update_Variables_Across_Blocks()
        {
            string code = @"
a = 3;



b = a * 3;



c = [Imperative]

{

    d = b + 3;

	a = 4;

	return = d;

}



f = c + 1;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_2D_Collection_Assignment_Using_For_Loop()
        {
            string code = @"
pts = {{0,1,2},{0,1,2}};

x = {1,2};

y = {1,2,3};



[Imperative]

{

    c1 = 0;

	for ( i in x )

	{

		c2 = 0;

		for ( j in y )

		{

		    pts[c1][c2] = i+j;

			c2 = c2+1;

		}

		c1 = c1 + 1;

	}

	

}



p1 = pts[1][1];

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_Class_Named_Constructors()
        {
            string code = @"
class A

{ 

	x : int;

	

	constructor A ()

	{

		x = 1;		

	}

	

	constructor A (i)

	{

		x = i;		

	}

	

	constructor A1 (i)

	{

		x = i;		

	}

	

	

}



xx = [Imperative]

{

	a1 = A.A();

	a2 = A.A(2);

	a3 = A.A(3);

	return = { a1, a2, a3 };

}



x1 = xx[0].x;

x2 = xx[1].x;

x3 = xx[2].x;





















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_Defect_1450550()
        {
            string code = @"
[Associative]

{

	a = 4;

	b = a*2;



	x = [Imperative]

	{

		def fn:int(a:int)

		{

		    return = a;

		}

		

		_i = fn(0);

		

		return = _i; 

	}



	a = x;

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_Defect_1461209()
        {
            string code = @"
class A

{

    a : var;

	constructor A ( a1 : double)

	{

	    a = a1;

	}

}



y = A.A( x);

a1 = y.a;

x = 3;

x = 5;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_Defect_1461209_2()
        {
            string code = @"
class A

{

    a : var;

	constructor A ( a1 : double)

	{

	    a = a1;

	}

}



y = A.A( x);

a1 = y.a;

x = [Imperative]

{

    return = 5;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_Defect_1461209_3()
        {
            string code = @"
class A

{

    a : var = foo (1);

	

	def foo (a1 : var)

	{

	    return = a1 + 1;

	}

}



y = A.A( );

a1 = y.a;

a2 = y.foo(1);



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_Defect_1461209_4()
        {
            string code = @"
class A

{

    a : var ;

	b = a + 1;

	

	constructor A (a1 : var)

	{

	    a = a1 + 1;

	}

}



y = A.A( x );

a1 = y.a;

b1 = y.b;



x = [Imperative]

{

    return = 3;

}

x = 2;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_Function_Recursive_imperative()
        {
            string code = @"
[Imperative]

{

	def factorial : int( n : int )

	{

		if ( n > 1 ) 

		{

		    return = n * factorial ( n - 1 );

		}

		else 

		{

		    return = 1;

		}		

	}

	

	a = 3;

	b = factorial (a );

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_IfElseStatementExpressions()
        {
            string code = @"
[Imperative]

{

 a=1;

 b=2;

 temp1=1;

 if((a/b)==1)

 {

  temp1=0;

 }

 elseif ((a*b)==2)

 { temp1=2;

 }

 

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_NegativeTest_UsingFunctionNameInNonAssignBinaryExpr()
        {
            string code = @"
def foo:int(x:int)

{

	return = x;

}



a = foo + 2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_Pass_3_Lists_Same_Length()
        {
            string code = @"
class Point_3D

{

	x : var;

	y : var;

	z : var;



	constructor ValueCtor(_x : int, _y : int, _z : int)

	{

		x = _x;

		y = _y;

		z = _z;

	}



	def GetValue : int()

	{

		return = x + y + z;

	}

}



list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

list2 = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

list3 = { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

pointList = Point_3D.ValueCtor(list1, list2, list3);



pointList_0_x = pointList[0].GetValue(); // 33

pointList_5_x = pointList[5].GetValue(); // 48

pointList_9_x = pointList[9].GetValue(); // 60
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_RangeExpressionUsingClassMethods()
        {
            string code = @"
class collection

{

	x : var[];

	constructor Create(a: int)

	{

		x = a..(a+3)..#4;

	}

	

	public def get_x()

	{

		return = x;

	}

}



[Imperative]

{



	a = collection.Create(5);

	

	b = a.get_x();

	



}

     

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_TestFactorialUsingWhileStmt()
        {
            string code = @"
[Imperative]

{

    a = 1;

	b = 1;

    while( a <= 5 )

	{

		a = a + 1;

		b = b * (a-1) ;		

	}

	factorial_a = b * a;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_TestForLoopWithBooleanCollection()
        {
            string code = @"
[Imperative]

{ 

	a = { true, false, true, true };

	x = false;

	

	for( i in a )

	{

	    x = x + i;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_TestUsingMathAndLogicalExpr__2_()
        {
            string code = @"
[Associative]

{

  a = 3;

  b = -4;

  c = a + b; 

  d = a - c;

  e = a * d;

  f = a / e; 

  

  c1 = 1 && 2;

  c2 = 1 && 0;

  c3 = null && true;

  



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT14_TestUsingMathAndLogicalExpr()
        {
            string code = @"
[Imperative]

{

  a = 3;

  b = -4;

  b = a + b; 

  b = a - b;

  b = a * b;

  b = a / b; 

  

  c1 = 1 && 2;

  c2 = 1 && 0;

  c3 = null && true;

  



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_2D_Collection_Assignment_Using_While_Loop()
        {
            string code = @"
[Imperative]



{

	pts = {{0,1,2},{0,1,2}};

	x = {1,2,3};

	y = {1,2,3};

    i = 0;

	while ( i < 2 )

	{		

		j = 0;

		while ( j  < 3 )

		{

		    pts[i][j] = i+j;

			j = j + 1;

		}

		i = i + 1;

	}



	p1 = pts[1][1];

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_Class_Constructor_Negative()
        {
            string code = @"
class A

{ 

	x : int[];

	

	constructor A (i:int[])

	{

		x = i;		

	}

	

	

}



xx = [Imperative]

{

	y = 1;

	a1 = A.A(y);

	return = a1;

}



x1 = xx.x;

x2 = 3;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_Defect_1452044()
        {
            string code = @"
[Associative]

{

	a = 2;

	[Imperative]

	{

		b = 2 * a;

	}

		

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_Defect_1460935()
        {
            string code = @"
class B

{ 

	x3 : int ;

		

	constructor B(a) 

	{	

		x3 = a;

	}

	

}

def foo ( b1 : B )

{

    return = b1.x3;

}

b1 = B.B( 1 );

x = b1.x3;

b1 = 1;

y = x; // expected : null; recieved : 1







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_Defect_1460935_2()
        {
            string code = @"
class B

{ 

	x3 : int ;

		

	constructor B(a) 

	{	

		x3 = a;

	}

	

}

def foo ( b1 : B )

{

    return = b1.x3;

}

b1 = B.B( 1 );

x = b1.x3;

b1 = 2;

y = x; // expected : null; recieved : exception









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_Defect_1460935_3()
        {
            string code = @"
x = 1;

y = x;

x = true; //if x = false, the update mechanism works fine

yy = y;

x = false;









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_Defect_1460935_4()
        {
            string code = @"
class B

{ 

	x3 : int ;

		

	constructor B(a) 

	{	

		x3 = a;

	}

	

}

class A

{ 

	x3 : int ;

		

	constructor A(a) 

	{	

		x3 = a;

	}

	

}

def foo ( b1 : B )

{

    return = b1.x3;

}



b1 = B.B( 1 );

x = b1.x3;

y = foo ( b1 );

[Imperative]

{

	b1 = A.A( 2 );	

}



b2 = B.B( 2 );

x2 = b2.x3;

y2 = foo ( b2 );

[Imperative]

{

	b2 = null;

}

















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_Defect_1460935_5()
        {
            string code = @"
class B

{ 

	x3 : int ;

		

	constructor B(a) 

	{	

		x3 = a;

	}

	

}

b3 = B.B( 2 );

x3 = b3.x3;

[Imperative]

{

	b3 = { B.B( 1 ), B.B( 2 ) } ;

}















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_Defect_1460935_6()
        {
            string code = @"
class B

{ 

	x3 : int ;

		

	constructor B(a) 

	{	

		x3 = a;

	}

	

}



def foo ( b : B )

{

    return = { b.x3, b.x3 + 1 };

}

b1 = B.B( 2 );

x1 = b1.x3;

f1 = foo ( b1);



b1 = null;

















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_Function_From_Parallel_Blocks()
        {
            string code = @"
[Imperative]

{

	def factorial : int( n : int )

	{

		if ( n > 1 ) 

		{

		    return = n * factorial ( n - 1 );

		}

		else 

		{

		    return = 1;

		}		

	}

	

	

	

}



[Imperative]

{

	a = 3;

	b = factorial (a );

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_NegativeTest_UsingFunctionNameInNonAssignBinaryExpr_Global_ImperBlk()
        {
            string code = @"
[Imperative]

{

	def foo:int(x:int)

	{

		return = x;

	}



	a = foo + 2;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_Pass_a_3x3_and_2x4_lists()
        {
            string code = @"
class Point_2D

{

	x : int;

	y : int;

	

	constructor ValueCtor(x1 : int, y1 : int)

	{

		x = x1;

		y = y1;

	}

	

	def GetValue()

	{

		return = x * y;

	}

}



list1 = { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };

list2 = { { 1, 2, 3, 4 }, { 1, 2, 3, 4 } };



list3 = Point_2D.ValueCtor(list1, list2);



list2_0_0 = list3[0][0].GetValue(); // 1

list2_0_1 = list3[0][1].GetValue(); // 4

list2_0_2 = list3[0][2].GetValue(); // 9

list2_1_0 = list3[1][0].GetValue(); // 1

list2_1_1 = list3[1][1].GetValue(); // 4

list2_1_2 = list3[1][2].GetValue(); // 9

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_SimpleRangeExpression_1()
        {
            string code = @"
[Imperative]

{



	a = 1..2.2..#3;

	b = 0.1..0.2..#4;

	c = 1..3..~0.2;

	d = (a[0]+1)..(c[2]+0.9)..0.1; 

	e1 = 6..0.5..~-0.3;

	f = 0.5..1..~0.3;

	g = 0.5..0.6..0.01;

	h = 0.51..0.52..0.01;

	i = 0.95..1..0.05;

	j = 0.8..0.99..#10;

	//k = 0.9..1..#1;

	l = 0.9..1..0.1;



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_TestEmptyIfStmt()
        {
            string code = @"
[Imperative]

{

 a = 0;

 b = 1;

 if(a == b);

 else a = 1;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_TestForLoopWithMixedCollection()
        {
            string code = @"
[Imperative]

{

	a = { -2, 3, 4.5 };

	x = 1;

	for ( y in a )

	{

		x = x * y;       

    }

	

	a = { -2, 3, 4.5, true };

	y = 1;

	for ( i in a )

	{

		y = i * y;       

    }

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_TestInRecursiveFunctionScope__2_()
        {
            string code = @"
[Imperative]

{

	

	def fac : int ( n : int )

    {

        if(n == 0 )

        {

			return = 1;

        }

		//return = 2;

		return = n * fac (n-1 );

	}

    val = fac(5);				



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_TestInRecursiveFunctionScope()
        {
            string code = @"
[Imperative]

{

	

	def fac : int ( n : int )

	{

	    if(n == 0 )

        {

		    return = 1;

        }

		return = n * fac (n-1 );

	}

    val = fac(5);				



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT15_TestWhileWithDecimalvalues()
        {
            string code = @"
[Imperative]

{

    a = 1.5;

	b = 1;

    while(a <= 5.5)

	{

		a = a + 1;

		b = b * (a-1) ;		

	}

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_Assigning_Class_Collection_Property()
        {
            string code = @"
class A

{

    a = {1,2,3};

}

a = A.A();

val = a.a;

val[0] = 100;

t = a.a[0];         





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_Class_Constructor_Negative()
        {
            string code = @"
class A

{ 

	x : int;

	

	constructor A (i)

	{

		x = i;		

		return = { x, i};

	}

	

	

}



a1 = A.A(1);



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_Defect_1460623()
        {
            string code = @"
a2 = 1.0;

test2 = a2;

a2 = 3.0;

a2 = 3.3;

t2 = test2; // expected : 3.3; recieved : 3.0



a1 = { 1.0, 2.0};

test1 = a1[1]; 

a1[1] = 3.0;

a1[1] = 3.3;

t1 = test1; // expected : 3.3; recieved : 3.0

















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_Defect_1460623_2()
        {
            string code = @"
def foo ( a )

{

    return = a;

}

x = 1;

y = foo (x );

x = 2;

x = 3;

[Imperative]

{

    x = 4;

}

z = x;

















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_Defect_1460623_3()
        {
            string code = @"
def foo ( a )

{

    x = a;

	y = x + 3;

	x = a + 1;

	x = a + 2;

	return = y;

}

x = 1;

y = foo (x );

[Imperative]

{

    x = 2;

}

















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_Defect_1460623_4()
        {
            string code = @"
class A

{

	x : var;

	constructor A ( a )

	{

    	x = a;		

		x = a + 1;

		x = a + 2;

	}

	

	def foo ()

	{

	    x = 4;

		x = 5;

		return = 5;

	}

}



x1 = 1;

a1 = A.A( x1 );

y1 = a1.x;

z1 = a1.foo();



[Imperative]

{

    x1 = 2;

}



















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_Function_From_Parallel_Blocks()
        {
            string code = @"
[Imperative]

{

	def factorial : int( n : int )

	{

		if ( n > 1 ) 

		{

		    return = n * factorial ( n - 1 );

		}

		else 

		{

		    return = 1;

		}		

	}

	

	

	

}



[Associative]

{

	a = 3;

	b = factorial (a );

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_NegativeTest_UsingMemFunctionAsFunctionPtr()
        {
            string code = @"
def foo:int(x:int)

{

	return = x;

}

class A

{

	x : function; 

	y: function;

	constructor A()

	{

		x = foo;

		y = memFoo;

	}

	def memFoo(xx:int)

	{

		return = xx;

	}

}

a = A.A();

x = a.x(2);

y = a.y(2);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_Pass_a_3x3_List()
        {
            string code = @"
class Point_1D

{

	x : int;

	

	constructor ValueCtor(_x : int)

	{

		x = _x;

	}

	

	def GetValue()

	{

		return = x * x;

	}

}



list1 = { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };

list2 = Point_1D.ValueCtor(list1);



list2_0_0 = list2[0][0].GetValue(); // 1

list2_1_1 = list2[1][1].GetValue(); // 4

list2_2_2 = list2[2][2].GetValue(); // 9



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_SimpleRangeExpression_2()
        {
            string code = @"
[Imperative]

{

	a = 1.2..1.3..0.1;

	b = 2..3..0.1;

	c = 1.2..1.5..0.1;

	//d = 1.3..1.4..~0.5; //incorrect 

	d = 1.3..1.4..0.5; 

	e1 = 1.5..1.7..~0.2;

	f = 3..3.2..~0.2;

	g = 3.6..3.8..~0.2; 

	h = 3.8..4..~0.2; 

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_TestForLoopInsideIfElseStatement()
        {
            string code = @"
[Imperative]

{

	a = 1;

	b = { 2,3,4 };

	if( a == 1 )

	{

		for( y in b )

		{

			a = a + y;

		}

	}

	

	else if( a !=1)

	{

		for( y in b )

		{

			a = a + 1;

		}

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_TestIfConditionWithNegation_Negative()
        {
            string code = @"
[Imperative]

{

    a = 3;

    b = -3;

	if ( a == !b )

	{

	    a = 4;

	}

	

}

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_TestInvalidSyntax__2_()
        {
            string code = @"
[Associative]

{

	x = ;

        y = x;

        z == 4;

       			



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_TestInvalidSyntax()
        {
            string code = @"
[Imperative]

{

	x = ;

        y = x;

        z == 4;

       			



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16_TestWhileWithLogicalOperators()
        {
            string code = @"
[Imperative]

{

    a = 1.5;

	b = 1;

    while(a <= 5.5 && b < 20)

	{

		a = a + 1;

		b = b * (a-1) ;		

	}	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT16__Defect_1452588()
        {
            string code = @"
[Imperative]

{

	a = { 1,2,3,4,5 };

	for( y in a )

	{

		x = 5;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT17_Assigning_Collection_And_Updating()
        {
            string code = @"
a = {1, 2, 3};

b = a;

b[0] = 100;

t = a[0];       // t = 100, as expected

      





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT17_Class_Constructor_Negative()
        {
            string code = @"
class A

{ 

	x : int;

	

	constructor A (i)

	{

		x = i;				

	}

	

	

}



class B

{ 

	x : int;

	

	constructor B (i)

	{

		x = i;		

		

	}

	

}



b1 = B.B(1);

a1 = A.A(b1);



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT17_Defect_1459759()
        {
            string code = @"
class B

{

    b1 : var;

	constructor B ( )

	{

	    b1 = 3;

	}

}



p1 = 1;

p2 = p1 * 2;

p1 = true;



x1 = 3;

y1 = x1 + 1;

x1 = B.B();



















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT17_Defect_1459759_2()
        {
            string code = @"
a1 = { 1, 2 };

y = a1[1] + 1;

a1[1] = 3;

a1 = 5;



















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT17_Function_From_Parallel_Blocks()
        {
            string code = @"
[Associative]

{

	def foo : int( n : int )

	{

		return = n * n;	

	}

	

	

	

}



[Associative]

{

	a = 3;

	b = foo (a );

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT17_PassFunctionPointerAsArg()
        {
            string code = @"
def foo:int(x:int)

{

	return = x;

}



def foo1:int(f:function, x:int)

{

	return = f(x);

}



a = foo1(foo, 2);

b = foo;

c = foo1(b, 3);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT17_Pass_ConstructorCall_Return_List()
        {
            string code = @"
class Point_1D

{

	x : int;

	

	constructor ValueCtor(_x : int)

	{

		x = _x;

	}

}



class Point_3D

{

	x : int;

	y : int;

	z : int;

	

	constructor PointOnXCtor(p : Point_1D)

	{

		x = p.x;

		y = 0;

		z = 0;

	}

	

	def GetIndexX()

	{

		return = x * x;

	}

}



list1 = { 1, 2, 3, 4, 5 };

list2 = Point_3D.PointOnXCtor(Point_1D.ValueCtor(list1));



list2_0 = list2[0].GetIndexX(); // 1

list2_3 = list2[3].GetIndexX(); // 16

list2_4 = list2[4].GetIndexX(); // 25

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT17_SimpleRangeExpression_3()
        {
            string code = @"
[Imperative]

{

	a = 1..2.2..~0.2;

	b = 1..2..#3;

	c = 2.3..2..#3;

	d = 1.2..1.4..~0.2;

	e1 = 0.9..1..0.1;

	f = 0.9..0.99..~0.01;

	g = 0.8..0.9..~0.1;

	h = 0.8..0.9..0.1;

	i = 0.9..1.1..0.1;

	j = 1..0.9..-0.05;

	k = 1.2..1.3..~0.1;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT17_TestForLoopInsideNestedIfElseStatement()
        {
            string code = @"
[Imperative]

{

	a = 1;

	b = { 2,3,4 };

	c = 1;

	if( a == 1 )

	{

		if(c ==1)

		{

			for( y in b )

			{

				a = a + y;

			}

		}	

	}

	

	else if( a !=1)

	{

		for( y in b )

		{

			a = a + 1;

		}

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT17_TestInvalidSyntax__2_()
        {
            string code = @"
[Associative]

{

	_rt = 3;

       ""dg"" = 4;

       w = 2

       f = 3;

       v = v;

       			



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT17_TestInvalidSyntax()
        {
            string code = @"
[Imperative]

{

	_rt = 3;

       ""dg"" = 4;

       w = 2

       f = 3;

       v = v;

       			



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT17_TestWhileWithBool()
        {
            string code = @"
[Imperative]

{

    a = 0;	

    while(a == false)

	{

		a = 1;	

	}	

	

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT17_WhileInsideElse()
        {
            string code = @"
[Imperative]

{

	i=1;

	a=3;

    temp=0;

	if(a==4)             

	{

		 i = 4;

	}

	else

	{

		while(i<=4)

		 {

			  if(i>10) 

				temp=4;			  

			  else 

				i=i+1;

		 }

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT17__Defect_1452588_2()
        {
            string code = @"
[Imperative]

{

	a = 1;

	

	if( a == 1 )

	{

		if( a + 1 == 2)

			b = 2;

	}

	

	c = a;

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT18_Assigning_Collection_In_Function_And_Updating()
        {
            string code = @"
def A (a: int [])

{

    return = a;

}



val = {1,2,3};

b = A(val);

t = b;

t[0] = 100;    // 

y = b[0];

z = val[0];    // val[0] is still 1



      





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT18_Class_Constructor_Empty()
        {
            string code = @"
class A

{ 

	x : int[] = {1,2};

	

	constructor A ()

	{

		y = 2;		

	}	

}



a1 = A.A();

x = a1.x;

x1 = x[0];

x2 = x[1];

x3 = a1.y;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT18_FunctionPointerAsReturnVal()
        {
            string code = @"
def foo:int(x:int)

{

	return = x;

}



def foo1:int(f : function, x:int)

{

	return = f(x);

}



def foo2:function()

{

	return = foo;

}



a = foo2();

b = a(2);

c = foo1(a, 3);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT18_Function_Recursive_associative()
        {
            string code = @"
[Imperative]

{

	def factorial : int( n : int )

	{

		if ( n > 1 ) 

		{

		    return = n * factorial ( n - 1 );

		}

		else 

		{

		    return = 1;

		}		

	}

	

	a = 3;

	b = factorial (a );

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT18_Pass_ConstructorCall_Return_List_to_Function()
        {
            string code = @"
class Point_1D

{

	x : var;

	

	constructor ValueCtor(_x : int)

	{

		x = _x;

	}

}



def GetPointIndex : int(p : Point_1D)

{

	return = p.x;

}



list1 = { 1, 2, 3, 4, 5, 6 };

list2 = GetPointIndex(Point_1D.ValueCtor(list1)); // { 1, 2, 3, 4, 5, 6 }

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT18_SimpleRangeExpression_4()
        {
            string code = @"
[Imperative]

{

	a = 2.3..2.6..0.3;

	b = 4.3..4..-0.3;

	c= 3.7..4..0.3;

	d = 4..4.3..0.3;

	e1 = 3.2..3.3..0.3;

	f = 0.4..1..0.1;

	g = 0.4..0.45..0.05;

	h = 0.4..0.45..~0.05; 

	g = 0.4..0.6..~0.05;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT18_TestForLoopInsideWhileStatement()
        {
            string code = @"
[Imperative]

{

	a = 1;

	b = { 1,1,1 };

	x = 0;

	

	if( a == 1 )

	{

		while( a <= 5 )

		{

			for( i in b )

			{

				x = x + 1;

			}

			a = a + 1;

		}

	}

}

			
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT18_TestMethodCallInExpr__2_()
        {
            string code = @"
[Associative]

{

	def mul : double ( n1 : int, n2 : int )

    {

      	return = n1 * n2;

    }

    def add : double( n1 : int, n2 : double )

    {

       	return = n1 + n2;

    }



    test0 = add (-1 , 7.5 ) ;

    test1 = add (mul(1,2), 4.5 ) ;  

    test2 = add (mul(1,2.5), 4 ) ; 

    test3 = add (add(1.5,0.5), 4.5 ) ;  

    test4 = add (1+1, 4.5 ) ;

    test5 = add ( add(1,1) + add(1,0.5), 3.0 ) ;

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT18_TestMethodCallInExpr()
        {
            string code = @"
[Imperative]

{

	   def  mul : double ( n1 : double, n2 : double )

        {

        	return = n1 * n2;

        }

        def add : double ( n1 : double, n2 : double )

        {

        	return = n1 + n2;

        }



        test0 = add (-1 , 7.5 ) ;

        test1 = add ( mul(1,2), 4.5 ) ;  

        test2 = add (mul(1,2.5), 4 ) ; 

        test3 = add (add(1.5,0.5), 4.5 ) ;  

        test4 = add (1+1, 4.5 ) ;

        test5 = add (add(1,1)+add(1,0.5), 3.0 ) ;



       

       			



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT18_TestWhileWithNull()
        {
            string code = @"
[Imperative]

{

    a = null;

    c = null;

	

    while(a == 0)

	{

		a = 1;	

	}



    while(null == c)

	{

		c = 1;	

	}



    while(a == b)

	{

		a = 2;	

	}	

	

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test, Ignore]
        public void DebugEQT18_Update_Variables_In_Inner_Assoc()
        {
            string code = @"
c = 2;

b = c * 2;

x = b;

[Imperative]

{

    c = 1;

	b = c + 1;

	d = b + 1;

	y = 1;

	[Associative]

	{

	  	b = c + 2;		

		c = 4;

		z = 1;

	}

}



b = c + 3;



















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT18_WhileInsideIf()
        {
            string code = @"
[Imperative]

{

	i=1;

	a=3;

    temp=0;

	if(a==3)             //when the if statement is removed, while loop works fine, otherwise runs only once

	{

		 while(i<=4)

		 {

			  if(i>10) 

				temp=4;			  

			  else 

				i=i+1;

		 }

	}

}

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT18__Negative_Block_Syntax()
        {
            string code = @"
x = 1;

y = {Imperative]

{

   return = x + 1;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT19_Assigning_Collection_In_Function_And_Updating()
        {
            string code = @"
def A (a: int [])

{

    return = a;

}



val = {1,2,3};

b = A(val);

b[0] = 100;     

z = val[0];     





      





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT19_BasicIfElseTestingWithNumbers()
        {
            string code = @"
[Imperative]

{

    a = 0;

    b = 0;

    c = 0;

    d = 0;

    if(1)

	{

		a = 1;

	}

	else

	{

		a = 2;

	}

	

	

	if(0)

	{

		b = 1;

	}

	else

	{

		b = 2;

	}

	

	if(0)

	{

		c = 1;

	}

	elseif(1)

	{

		c = 3;

	}

	

	if(0)

	{

		d = 1;

	}

	elseif(0)

	{

		d = 2;

	}

	else

	{

		d = 4;

	}

		

} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT19_Class_Constructor_Test_Default_Property_Values()
        {
            string code = @"
class A

{ 

	x : var ;

	y : int;

	z : bool;

	u : double;

	v : B;

	w1 : int[];

	w2 : double[];

	w3 : bool[];

	w4 : B[][];

	

	constructor A ()

	{

		      	

	}	

}



a1 = A.A();

x1 = a1.x;

x2 = a1.y;

x3 = a1.z;

x4 = a1.u;

x5 = a1.v;

x6 = a1.w1;

x7 = a1.w2;

x8 = a1.w3;

x9 = a1.w4;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT19_Function_From_Imperative_While_And_For_Loops()
        {
            string code = @"
[Imperative]

{

	def foo : int( n : int )

	{

		return = n * n;	

	}

	

	a = { 0, 1, 2, 3, 4, 5 };

	x = 0;

	for ( i in a )

	{

	    x = x + foo ( i );

	}

	

	y = 0;

	j = 0;

	while ( a[j] <= 4 )

	{

	    y = y + foo ( a[j] );

		j = j + 1;

	}

	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT19_Imperative_Nested_1467063()
        {
            string code = @"
[Imperative]

{

   a=1;

   [Imperative]

    {

    b=a+1;

    }



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT19_NegativeTest_PassingFunctionPtrAsArg_CSFFI()
        {
            string code = @"
import (""ProtoGeometry.dll"");



def foo : CoordinateSystem()

{

	return = CoordinateSystem.Identity();

}



a = Point.ByCartesianCoordinates(foo, 1.0, 2.0, 3.0);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT19_Pass_FunctionCall_Return_List()
        {
            string code = @"
def foo : int(a : int)

{

	return = a * a;

}



class Point_1D

{

	x : int;

	

	constructor ValueCtor(_x : int)

	{

		x = _x;

	}

	

	def GetIndex()

	{

		return = x * x;

	}

}



list1 = { 1, 2, 3, 4, 5 };

list2 = Point_1D.ValueCtor(foo(foo(list1)));



list2_0 = list2[0].GetIndex(); // 1

list2_3 = list2[3].GetIndex(); // 65536

list2_4 = list2[4].GetIndex(); // 390625
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT19_SimpleRangeExpression_5()
        {
            string code = @"
[Imperative]

{

	//a = 0.1..0.2..#1; //giving error

	b = 0.1..0.2..#2;

	c = 0.1..0.2..#3;

	d = 0.1..0.1..#4;

	e1 = 0.9..1..#5;

	f = 0.8..0.89..#3;

	g = 0.9..0.8..#3;

	h = 0.9..0.7..#5;

	i = 0.6..1..#4;

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT19_TestAssignmentToCollection__2_()
        {
            string code = @"
[Associative]

{

	a = {{1,2},3.5};

	c = a[1];

	d = a[0][1];

        a[0][1] = 5;

       	b = a[0][1] + a[1];	



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT19_TestAssignmentToCollection()
        {
            string code = @"
[Imperative]

{

	a = {{1,2},3.5};

	c = a[1];

	d = a[0][1];

        a[0][1] = 5;

       	b = a[0][1] + a[1];

        a = 2;		



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT19_TestForLoopInsideNestedWhileStatement()
        {
            string code = @"
[Imperative]

{

	i = 1;

	a = {1,2,3,4,5};

	x = 0;

	

	while( i <= 5 )

	{

		j = 1;

		while( j <= 5 )

		{

			for( y in a )

			{

			x = x + 1;

			}

			j = j + 1;

		}

		i = i + 1;

	}

}	

		

			
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT19_TestWhileWithIf()
        {
            string code = @"
[Imperative]

{

    a = 2;

	b = a;

	while ( a <= 4)

	{

		if(a < 4)

		{

			b = b + a;

		}

		else

		{

			b = b + 2*a;

		}

		a = a + 1;

	}

	

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT19_Update_Class_Properties_Thru_Methods()
        {
            string code = @"
class A

{

    a : int = 0;

	

	constructor A ()

	{

	    a = 1;

	}

	

	def Update ()

	{

	    a = 2;

		return = true;

	}

}



a1 = A.A();

b1 = a1.a;

x1 = a1.Update();

b2 = b1;



















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_BasicIfElseTestingWithNumbers()
        {
            string code = @"
[Imperative]

{

    a = 0;

    b = 0;

    c = 0;

    d = 0;

    e = 0;

    f = 0;

    if(1.5)

	{

		a = 1;

	}

	else

	{

		a = 2;

	}

	

	

	if(-1)

	{

		b = 1;

	}

	else

	{

		b = 2;

	}

	

	if(0)

	{

		c = 1;

	}

	elseif(20)

	{

		c = 3;

	}

	

	if(0)

	{

		d = 1;

	}

	elseif(0)

	{

		d = 2;

	}

	else

	{

		d = 4;

	}

	

	if(true)

	{

		e = 5;

	}

	

	if(false)

	{

		f = 1;

	}

	else

	{

		f = 6;

	}

		

} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_Class_Constructor_Fails()
        {
            string code = @"
class A

{ 

	x : var ;	

	

	constructor A ()

	{

		 x = w;     	

	}	

}



a1 = A.A();

b1 = a1.x;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_Defect_1458567()
        {
            string code = @"
a = 1;

b = a[1];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_Defect_1458567_2()
        {
            string code = @"
class Point

{

    X : double;

	Y : double;

	Z : double;

	

	constructor ByCoordinates( x : double, y : double, z : double )

	{

	    X = x;

		Y = y;

		Z = z;		

	}

}



class Line

{

    P1 : Point;

	P2 : Point;

	

	constructor ByStartPointEndPoint( p1 : Point, p2 : Point )

	{

	    P1 = p1;

		P2 = p2;

	}

	

	def PointAtParameter (p : double )

	{

	

	    t1 = P1.X + ( p * (P2.X - P1.X) );

		return = Point.ByCoordinates( t1, P1.Y, P1.Z);

	    

	}

	

}



startPt = Point.ByCoordinates(1, 1, 0);

endPt   = Point.ByCoordinates(1, 5, 0);

line_0  = Line.ByStartPointEndPoint(startPt, endPt); 	

x1 = line_0[10].P1.X;

x2 = line_0[0].P1.X;

x3 = line_0.P1.X;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_Defect_1461391()
        {
            string code = @"
a = 1;

def foo ( a1 : double )

{

    return = a1 + 1;

}

b = foo ( c ) ;

c = a + 1;



[Imperative]

{

    a = 2.5;

}



















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_Defect_1461391_2()
        {
            string code = @"
a = 1;

def foo ( a1 : double[] )

{

    return = a1[0] + a1[1];

}

b = foo ( c ) ;

c = { a, a };



[Imperative]

{

    a = 2.5;

}



















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_Defect_1461391_3()
        {
            string code = @"
a = 1;

def foo ( a1 : double )

{

    return = a1 + 1;

}

b = foo ( a ) ;





[Imperative]

{

   a = foo(2);

}



















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_Defect_1461391_4()
        {
            string code = @"
class A

{

    a : int;

	constructor A ( a1 : int )

	{

	    a = a1;		

	}

	

	def update ( a2 : int )

	{

	    a = a2;

		return = true;

	}

}



x = { 1, 2 };

y1 = A.A(x);

y2 = { y1[0].a, y1[1].a };



[Imperative]

{ 

	for ( count in 0..1)

	{

	    temp = y1[count].update(0);	

	}

}



t1 = y2[0];

t2 = y2[1];





















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_Defect_1461391_5()
        {
            string code = @"
class A

{

    a : int;

	constructor A ( a1 : int )

	{

	    a = a1;		

	}

	

	def update ( a2 : int )

	{

	    a = a2;

		return = true;

	}

}



def foo ( a : A) 

{

    return = a.a;

}





x = { 1, 2 };

y1 = A.A(x);

y2 = foo ( y1);



[Imperative]

{ 

	count = 0;

	for ( i in y1)

	{

	    temp = y1[count].update(0);	

        count = count + 1;		

	}

}



t1 = y2[0];

t2 = y2[1];





















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_Defect_1461391_6()
        {
            string code = @"
def foo ( a : int) 

{

    return = a;

}





y1 = { 1, 2 };

y2 = foo ( y1);



[Imperative]

{ 

	count = 0;

	for ( i in y1)

	{

	    y1[count] = y1[count] + 1;	

        count = count + 1;		

	}

}



t1 = y2[0];

t2 = y2[1];





















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_FunctionPtrUpdateOnMemVar_1()
        {
            string code = @"
def foo1:int(x:int)

{

	return = x;

}

class A

{

	x:function;

	constructor A(xx:function)

	{

		x = xx;

	}

}



a = A.A(foo1);

b = a.x(3);    //b = 3
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_Function_From_Imperative_If_Block()
        {
            string code = @"
[Associative]

{

	def foo : int( n : int )

	{

		return = n * n;	

	}

	

	[Imperative]

	{

	

		a = { 0, 1, 2, 3, 4, 5 };

		x = 0;

		for ( i in a )

		{

			x = x + foo ( i );

		}

		

		y = 0;

		j = 0;

		while ( a[j] <= 4 )

		{

			y = y + foo ( a[j] );

			j = j + 1;

		}

		

		z = 0;

		

		if( x == 55 )

		{

		    x = foo (x);

		}

		

		if ( x == 50 )

		{

		    x = 2;

		}

		elseif ( y == 30 )

		{

		    y = foo ( y );

		}

		

		if ( x == 50 )

		{

		    x = 2;

		}

		elseif ( y == 35 )

		{

		    x = 3; 

		}

		else

		{

		    z = foo (5);

		}

	}

	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_Pass_Single_List()
        {
            string code = @"
class Point_1D

{

	x : var;



	constructor ValueCtor(_x : int)

	{

		x = _x;

	}



	def GetValue : int()

	{

		return = x * x;

	}

}



list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

pointList = Point_1D.ValueCtor(list1);



pointList_0_x = pointList[0].GetValue(); // 1

pointList_5_x = pointList[5].GetValue(); // 36

pointList_9_x = pointList[9].GetValue(); // 100
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_RangeExpressionsUsingPowerOperator()
        {
            string code = @"
[Imperative]

{

	def power : double (a:double,b:int) 

	{

		temp = 1;

		while( b > 0 )

		{

			temp = temp * a;

			b = b - 1;

		}

		return = temp;

	}



	a = 3;

	b = 2; 

	c = power(2,3);

	d = b..a;

	e1 = b..c..power(2,1);

	f = power(1.0,1)..power(2,2)..power(0.5,1);   

	/*h = power(0.1,2)..power(0.2,2)..~power(0.1,2);

	i = power(0.1,1)..power(0.2,1)..~power(0.1,1);         has not been implemented yet

	j = power(0.4,1)..power(0.45,1)..~power(0.05,1);

	k = power(1.2,1)..power(1.4,1)..~power(0.2,1);

	l = power(1.2,1)..power(1.3,1)..~power(0.1,1); 

	m = power(0.8,1)..power(0.9,1)..~power(0.1,1);

	n = power(0.08,1)..power(0.3,2)..~power(0.1,2); */

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_TestForLoopWithoutBracket()
        {
            string code = @"
[Imperative]

{

	a = { 1, 2, 3 };

    x = 0;

	

	for( y in a )

	    x = y;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_TestInvalidSyntax__2_()
        {
            string code = @"
[Associative]

{

	a = 2;;;;;

    b = 3;

       			



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_TestInvalidSyntax()
        {
            string code = @"
[Imperative]

{

	a = 2;;;;;

    b = 3;

       			



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT20_TestWhileToCreate2DimArray()
        {
            string code = @"
def Create2DArray( col : int)

{

	result = [Imperative]

    {

		array = { 1, 2 };

		counter = 0;

		while( counter < col)

		{

			array[counter] = { 1, 2};

			counter = counter + 1;

		}

		return = array;

	}

    return = result;

}



x = Create2DArray( 2) ;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT21_Class_Constructor_Calling_Base_Constructor()
        {
            string code = @"
class A

{ 

	x : var ;	

	

	constructor A ()

	{

		 x = 1;     	

	}	

}



class B extends A

{ 

	y : var ;	

	

	constructor B () : base.A()

	{

		 y = 2;     	

	}	

}



class C extends B

{ 

	z : var ;	

	

	constructor C () : base.B()

	{

		 z = 3;     	

	}	

}



c = C.C();

c1 = c.x;

c2 = c.y;

c3 = c.z;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT21_Defect_1460891()
        {
            string code = @"
[Imperative]

{

    b = { };

    count = 0;

    a = 1..5..2;

    for ( i in a )

    {

        b[count] = i + 1;

        count = count + 1;

    }

	c = b ;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT21_Defect_1460891_2()
        {
            string code = @"


def CreateArray ( x : var[] , i )

{

    x[i] = i;

	return = x;

}



b = {0, 1};

count = 0..1;



b = CreateArray ( b, count );



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT21_Defect_1461390()
        {
            string code = @"
[Associative]

{

    a = 0;

    d = a + 1;

    [Imperative]

    {

       b = 2 + a;

       a = 1.5;

              

    }

    c = a + 2; // fail : runtime assertion 

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test, Ignore]
        public void DebugEQT21_Defect_1461390_2()
        {
            string code = @"
a = 1;

b = a + 1;

[Imperative]

{

    a = 2;

    c = b + 1;

	b = a + 2;

    [Associative]

    {

       a = 1.5;

       d = c + 1;

       b = a + 3; 

       a = 2.5; 	   

    }

    b = a + 4;

    a = 3;	

}

f = a + b;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT21_FunctionPtrUpdateOnMemVar_2()
        {
            string code = @"
def foo1:int(x:int)

{

	return = x;

}



def foo2:double(x:int, y:double = 2.0)

{

	return = x + y;

}

class A

{

	x:var;

}



a = A.A();

a.x = foo1;

b = a.x(2); //b = 3;

a.x = foo2; //b = 5.0
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT21_Function_From_Nested_Imperative_Loops()
        {
            string code = @"
[Imperative]

{

	def foo : int( n : int )

	{

		return = n ;	

	}

	

	a = { 0, 1, 2, 3, 4, 5 };

	x = 0;

	for ( i in a )

	{

	    for ( j in a )

		{

		    x = x + foo ( j );

		}

	}

	

	y = 0;

	j = 0;

	while ( j <= 4 )

	{

	    p = 0;

		while ( p <= 4)

		{

		    y = y + foo ( a[p] );

			p = p + 1;

		}

		j = j + 1;

	}

	

	if( x < 100 )

	{

	    if ( x > 20 )

		{

		    x = x + foo (x );

		}

	}

	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT21_IfElseWithArray_negative()
        {
            string code = @"
[Imperative]

{

    a = { 0, 4, 2, 3 };

	b = 1;

    c = 0;

	if(a > b)

	{

		c = 0;

	}

	else

	{

		c = 1;

	}



} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT21_Pass_Single_List_2_Integer()
        {
            string code = @"
class Point_3D

{

	x : var;

	y : var;

	z : var;



	constructor ValueCtor(_x : int, _y : int, _z : int)

	{

		x = _x;

		y = _y;

		z = _z;

	}



	def GetValue : int()

	{

		return = x + y + z;

	}

}



list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

pointList = Point_3D.ValueCtor(list1, 66, 88);

pointList_0_x = pointList[0].GetValue(); // 155

pointList_5_x = pointList[5].GetValue(); // 160

pointList_9_x = pointList[9].GetValue(); // 164
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT21_RangeExpressionsUsingEvenFunction()
        {
            string code = @"
[Imperative]

{



	def even : int (a : int) 

	{	

		if(( a % 2 ) > 0 )

			return = a + 1;

		

		else 

			return = a;

	}



	x = 1..3..1;

	y = 1..9..2;

	z = 11..19..2;



	c = even(x); // 2,2,4

	d = even(x)..even(c)..(even(0)+0.5); // {2,2,4}



	e1 = even(y)..even(z)..1; // {2,4,6,8,10} .. {12,14,16,18,20}..1

	f = even(e1[0])..even(e1[1]); // even({2,3,4,5,6,7,8,9,10,11,12} ..even({4,5,6,7,8,9,10,11,12,13,14})

   /*  {2,4,4,6,6,8,8,10,10,12,12} .. {4,6,6,8,8,10,10,12,12,14,14}

*/ 

	g = even(y)..even(z)..f[0][1];  // {2,4,6,8,10} .. {12,14,16,18,20} .. 3



}







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT21_TestAssignmentToBool__2_()
        {
            string code = @"
[Associative]

{

	a = true;

    b = false;      			



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT21_TestAssignmentToBool()
        {
            string code = @"
[Imperative]

{

	a = true;

    b = false;      			



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT21_TestIfElseStatementInsideForLoop()
        {
            string code = @"
[Imperative]

{

	a = { 1,2,3,4,5 };

	x = 0;

	

	for ( i in a )

	{

		if( i >=4 )

			x = x + 3;

			

		else if ( i ==1 )

			x = x + 2;

		

		else

			x = x + 1;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT21_TestWhileToCallFunctionWithNoReturnType()
        {
            string code = @"
def foo ()
{
	return = 0;
}

def test ()
{
	temp = [Imperative]
	{
		t1 = foo();
		t2 = 2;
		while ( t2 > ( t1 + 1 ) )
		{
		    t1 = t1 + 1;
		}
		return = t1;	
	}
	return = temp;
}
x = test();

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT22_Class_Constructor_Not_Calling_Base_Constructor()
        {
            string code = @"
class A

{ 

	x : var = 0 ;	

	

	constructor A ()

	{

		 x = 1;     	

	}	

}



class C extends A

{ 

	y : var ;	

	

	constructor C () 

	{

		 y = 2;

         x = 2;		 

	}	

}





c = C.C();

c1 = c.x;

c2 = c.y;







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT22_Create_Multi_Dim_Dynamic_Array()
        {
            string code = @"
[Imperative]

{

    d = {{}};

    r = c = 0;

    a = { 0, 1, 2 };

	b = { 3, 4, 5 };

    for ( i in a )

    {

        c = 0;

		for ( j in b)

		{

		    d[r][c] = i + j;

			c = c + 1;

        }

		r = r + 1;

    }

	test = d;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT22_Defect_1463683()
        {
            string code = @"
def foo ()

{

	return = 1;

}



def test ()

{

	temp = [Imperative]

	{

		t1 = foo();

		t2 = 3;

		if ( t2 < ( t1 + 1 ) )

		{

		    t1 = t1 + 2;

		}

		else

		{

		    t1 = t1 ;

		}

		return = t1;		

	}

	return = temp;



}



x = test();
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT22_Defect_1463683_2()
        {
            string code = @"
def foo ()

{

	return = 1;

}

class A 

{

    t1 : int;

	t2 : int;



	

	def test ()

	{

		temp = [Imperative]

		{

			t1 = foo();

			t2 = 3;

			if ( t2 < ( t1 + 1 ) )

			{

				t1 = t1 + 2;

			}

			else

			{

				t1 = t1 ;

			}

			return = t1;		

		}

		return = temp;



	}

}



a = A.A();

x = a.test();

x1 = a.t1;

x2 = a.t2;



[Imperative]

{

	y = a.test();

	y1 = a.t1;

	y2 = a.t2;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT22_Defect_1463683_3()
        {
            string code = @"
def foo ()

{

	return = { 0, 1, 2 };

}

class A 

{

    t1;

	t2;	

	def test ()

	{

		c = 0;

		temp = [Imperative]

		{

			t1 = foo();

			t2 = 0;

			for ( i in t1 )

			{

				if (i < ( t2 + 1 ) )

				{

					t1[c] = i + 1;

				}

				else

				{

					t1[c] = i +2 ;

				}

				c = c + 1 ;

			}

			return = t1;		

		}

		return = temp;



	}

}



a = A.A();

x = a.test();

x1 = a.t1;

x2 = a.t2;

y;y1;y2;


[Imperative]

{

	y = a.test();

	y1 = a.t1;

	y2 = a.t2;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT22_Defect_1463683_4()
        {
            string code = @"
def foo ()

{

	return = 1;

}



def test (t2)

{

	temp = [Imperative]

	{

		t1 = foo();

		if ( (t2 > ( t1 + 1 )) && (t2 >=3)  )

		{

		    t1 = t1 + 2;

		}

		else

		{

		    t1 = t1 ;

		}

		return = t1;		

	}

	return = temp;



}



x1 = test(3);

x2 = test(0);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT22_Function_Call_As_Instance_Arguments()
        {
            string code = @"
class A

{

	a : var;



	constructor CreateA ( a1 : int )

	{

		a = a1;

	}

	

	constructor CreateB ( a1 : double )

	{

		a = a1;

	}

}



[Associative]

{

	def foo : int( n : int )

	{

		return = n ;	

	}

	

	def foo2 : double( n : double )

	{

		return = n ;	

	}

	

	A1 = A.CreateA(foo(foo(1))).a;	

	A2 = A.CreateB(foo2(foo(1))).a;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT22_IfElseWithArrayElements()
        {
            string code = @"
[Imperative]

{

    a = { 0, 4, 2, 3 };

	b = 1;

    c = 0;

	if(a[0] > b)

	{

		c = 0;

	}

	elseif( b  < a[1] )

	{

		c = 1;

	}



} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT22_Pass_1_single_list_of_class_type_and_1_variable_of_class_type()
        {
            string code = @"
class Integer

{

	value : int;

	

	constructor ValueCtor(_value : int)

	{

		value = _value;

	}

	

	def Mul : int(i1 : Integer, i2 : Integer)

	{

		return = i1.value * value * i2.value;

	}

}



list = {

			Integer.ValueCtor(4),

			Integer.ValueCtor(5),

			Integer.ValueCtor(7)

		};

i = Integer.ValueCtor(2);

m = i.Mul(list, i); // { 16, 20, 28 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT22_RangeExpressionsUsingClassMethods_2()
        {
            string code = @"
class addition

{

	a : var[];

	constructor Create( y : int[] )

	{

		a = y;

	}

	def get_col ( x : int )

	{

		a[0] = x;

		return = a; 

	}

}



[Imperative]

{

	a = 2..10..2;

	c = addition.Create( a );

	d = c.get_col( 5 );

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT22_TestAssignmentToNegativeNumbers__2_()
        {
            string code = @"
[Associative]

{

	a = -1;

	b = -111;

	c = -0.1;

	d = -1.99;

	e = 1.99;

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT22_TestAssignmentToNegativeNumbers()
        {
            string code = @"
[Imperative]

{

	a = -1;

	b = -111;

	c = -0.1;

	d = -1.99;

	e = 1.99;

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT22_TestWhileStatementInsideForLoop()
        {
            string code = @"
[Imperative]

{

	a = { 1,2,3 };

	x = 0;

	

	for( y in a )

	{

		i = 1;

		while( i <= 5 )

		{

			j = 1;

			while( j <= 5 )

			{

				x = x + 1;

				j = j + 1;

			}

		i = i + 1;

		}

	}

}

	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT22_Update_Class_Instance()
        {
            string code = @"
class A

{

    a : int[];

	constructor A ( a1 : int[] )

	{

	    a = a1;		

	}

	

	def update ( a2 : int, i:int )

	{

	    a[i] = a2;

		return = true;

	}

}



y1 = { 1, 2 };

y2 = { 3, 4 };



x = { A.A (y1), A.A(y2) };

t1 = x[0].a[0];

t2 = x[1].a[1];

dummy = 0;

[Imperative]

{ 

	count = 0;

	for ( i in y1)

	{

	    y1[count] = y1[count] + 1;	      

		count = count + 1;		

	}

}

dummy=1;

[Imperative]

{ 

	count = 0;

	for ( i in y2)

	{

	    y2[count] = y2[count] + 1;	      

		count = count + 1;		

	}

}

























";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_Class_Constructor_Base_Constructor_Same_Name()
        {
            string code = @"
class A

{ 

	x : var = 0 ;	

	

	constructor A ()

	{

		 x = 1;     	

	}	

}



class C extends A

{ 

	y : var ;	

	

	constructor A () : base.A()

	{

		 y = 2;

         x = 2;		 

	}

	

}



class B extends A

{ 

	y : var ;	

	

	constructor A () : base.A()

	{

		 y = 2;

         

	}

	

}



class D extends A

{ 

	y : var ;	

	

	constructor A () : base.A() 

	{

		 y = 2;

         

	}

	

}







c = C.A();

c1 = c.x;

c2 = c.y;



b = B.A();

b1 = b.x;

b2 = b.y;



d = D.A();

d1 = d.x;

d2 = d.y;







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_Create_Dynamic_Array_Using_Replication_In_Imperative_Scope()
        {
            string code = @"
[Imperative]

{



	def CreateArray ( x : var[] , i )

	{

		x[i] = i;

		return = x;

	}



	test = { };

	test = CreateArray ( test, 0 );

	test = CreateArray ( test, 1 );

	

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_Function_Call_As_Function_Call_Arguments()
        {
            string code = @"
[Associative]

{

	def foo : double ( a : double , b :double )

	{

		return = a + b ;	

	}

	

	def foo2 : double ( a : double , b :double )

	{

		return = foo ( a , b ) + foo ( a, b );	

	}

	

	a1 = 2;

	b1 = 4;

	c1 = foo2( foo (a1, b1 ), foo ( a1, foo (a1, b1 ) ) );

	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_IfElseSyntax_negative()
        {
            string code = @"
[Imperative]

{

    if(1.5

	{

		b = 1;

	}

		

}

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_Pass_2_lists_of_class_type_with_different_length()
        {
            string code = @"
class Integer

{

	value : int;

	

	constructor ValueCtor(_value : int)

	{

		value = _value;

	}

	

	def Mul : int(i1 : Integer, i2 : Integer)

	{

		return = i1.value * value * i2.value;

	}

}



list1 = {

			Integer.ValueCtor(4),

			Integer.ValueCtor(5),

			Integer.ValueCtor(7)

		};



list2 = { 

			Integer.ValueCtor(1),

			Integer.ValueCtor(2)

		};

		

i = Integer.ValueCtor(2);

m = i.Mul(list1, list2); // { 8, 20 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_RangeExpressionsUsingClassMethods_3()
        {
            string code = @"
class compare

{

	a ;

	b ; 

	constructor Create (x, y)

	{

		a = x ;

		b = y ;

	}

	def get_max ()

	{

		return = (a > b) ? a : b ; 

	}

	def get_min ()

	{

		return = (a < b) ? a : b ; 

	}

}



[Imperative]

{

	a = 1..5..1;

	b = 10..2..-2;

	c = compare.Create(a,b); 

	i = 4;

	d = c[0..i].get_max();

	e1 = c[0..i].get_min();



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_TestForLoopWithDummyCollection()
        {
            string code = @"
[Imperative]

{

	a = {0, 0, 0, 0, 0, 0};

	b = {5, 4, 3, 2, 1, 0, -1, -2};

	i = 5;

	for( x in b )

	{

		if(i >= 0)

		{

			a[i] = x;

			i = i - 1;

		}

	}

	a1 = a[0];

	a2 = a[1];

	a3 = a[2];

	a4 = a[3];

	a5 = a[4];

	a6 = a[5];

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_TestUsingMathAndLogicalExpr__2_()
        {
            string code = @"
[Associative]

{

  a = -3.5;

  b = -4;

  c1 = a + b; 

  c2 = a - b;

  c3 = a * b;

  c4 = a / b; 



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_TestUsingMathAndLogicalExpr()
        {
            string code = @"
[Imperative]

{

  a = -3.5;

  b = -4;

  c1 = a + b; 

  c2 = a - b;

  c3 = a * b;

  c4 = a / b; 



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_Update_Class_Instance_Using_Set_Method()
        {
            string code = @"
class A

{

    a : int;	

}



a1 = A.A();

a1.a = 1;

b = a1.a;

a1.a = 2;

























";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_Update_Class_Instance_Using_Set_Method_2()
        {
            string code = @"
class A

{

    a : int[];	

}



a1 = A.A();

a1.a = {1,2};

b = a1.a;

a1.a = {2,3};

























";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_Update_Class_Instance_Using_Set_Method_3()
        {
            string code = @"
class A

{

    a : int[];	

}



a1 = A.A();

a1.a = {1,2};

b = a1.a;

a1.a = null;

























";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_Update_Class_Instance_Using_Set_Method_4()
        {
            string code = @"
class A

{

    a : int[];	

}



a1 = A.A();

a1.a = {1,2};

b = a1.a;

a1.a = 3.5;

























";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_Update_Class_Instance_Using_Set_Method_5()
        {
            string code = @"
class A

{

    a : int[];	

}



a1 = A.A();

a1.a = {1,2};

b = a1.a;

a1.a = true;

























";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_Update_Class_Instance_Using_Set_Method_6()
        {
            string code = @"
class A

{

    a : int[];	

}

def foo ( x1 : A)

{

    x1.a = { 0, 0};

    x1.a[3] = -1;

    return = x1;

}

a1 = A.A();

a1.a = {1,2};

b = a1.a;

a1 = foo ( a1);



























";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT23_Update_Class_Instance_Using_Set_Method_7()
        {
            string code = @"
class A

{

    a : int[];	

}

def foo ( x1 : A)

{

    x1.a = { 0, 0};

    x1.a[3] = -1;

    return = true;

}

a1 = A.A();

a1.a = {1,2};

b = a1.a;

dummy = foo ( a1);



























";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Class_Constructor_Calling_Base_Methods()
        {
            string code = @"
class A

{ 

	x : var = 0 ;	

	

	constructor A ()

	{

		 x = 1;     	

	}

	def foo ()

	{

	    return = x + 1;

	}	

}



class C extends A

{ 

	y : var ;	

	

	constructor C () : base.A()

	{

		 y = foo();

         	 

	}

	

}





c = C.C();

c1 = c.x;

c2 = c.y;









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Dynamic_Array_Accessing_Out_Of_Bound_Index()
        {
            string code = @"
class A

{

    Y : double;

    constructor A( y : double)

    {

        Y = y;

    }

}



class B

{

    A1 : A;

    A2 : A;

    constructor B( a1 : A, a2 : A)

    {

        A1 = a1;

        A2 = a2;

    }

}



def foo ( x : double)

{

    return = x + 1;

}





innerCircle2Rad = 100;

basePoint = {  };

basePoint2 = { };





nsides = 4;

a = 0..nsides - 1..1;

b = 0..nsides - 1..2;



collection = { };

[Imperative]

{

    temp1 = {  };

    temp2 = {  };



    for(i in a)

    {

        basePoint[i] = A.A( innerCircle2Rad * foo(i * 360 / nsides) );

        temp1[i] = basePoint[i].Y;

    }



    for(i in a)

    {



        if(i <= nsides-2)

        {

            basePoint2[i] = B.B(basePoint[i], basePoint[i+1]);        

            temp2[i] = { basePoint2[i].A1.Y, basePoint2[i].A2.Y };                      

        }



        basePoint2[nsides-1] = B.B(basePoint[nsides-1], basePoint[0]);

    }



    collection = { temp1, temp2 };

}   

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Dynamic_Array_Argument_Function_1465802_1()
        {
            string code = @"


	def foo : int(i:int[])

	{

		return = 1;

	}



[Associative]

{

cy={};

cy[0]=10;

cy[1]=12;



b1=foo(cy);



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Dynamic_Array_Argument_Function_1465802_2()
        {
            string code = @"


	def foo : int(i:int[])

	{

		return = 1;

	}



[Associative]

{

cy={};

cy[0]=10;

cy[1]=null;



b1=foo(cy);



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Dynamic_Array_Class_Scope()
        {
            string code = @"
class A

{

    X : var[];

    Y : var[];

    Count1;

    

    constructor A ( i : int )

    {

        X = 0..i;

	[Imperative]

	{

	    Count1 = 0;	    

	    y = {};

	    for ( i in X ) 

	    {

	        y[Count1] = i * -1;

		Count1 = Count1+1;

	    }          

            Y = y;	    

	}

	

    }

}



p = 3;

a = A.A(p);

b1 = a.X;

b2 = a.Y;

b3 = a.Count1;

p = 4;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Dynamic_Array_Class_Scope_2()
        {
            string code = @"
class A

{

    X = { };

    Y = { };

    Count1 :int;

    

    constructor A ( i : int )

    {

        X = 0..i;

	[Imperative]

	{

	    Count1 = 0;	    

	    

	    for ( i in X ) 

	    {

	        Y[Count1] = i * -1;

		Count1 = Count1+1;

	    }          

            	    

	}

	

    }

}



p = 4;

a = A.A(p);

b1 = a.X;

b2 = a.Y;

b3 = a.Count1;

//p = 4;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Dynamic_Array_Class_Scope_3()
        {
            string code = @"
class A

{

    X :int[] = { };

    Y :int[] = { };

    Count1 :int;

    

    constructor A ( i : int )

    {

        X = 0..i;

	Y = i..0..-1;

	Count1 = i+1;

    }

    

    def update ( )

    {

        [Imperative]

	{

	    i = 0;

	    while  ( i < Count1 )

	    {

	        temp = Y[i];

		Y[i] = X[i];

		X[i] = temp;

		i = i + 1;

	    }    

	    X[Count1] = 100;

	    Y[Count1] = 100;

	    Count1 = Count1 + 1;

	}

	return = true;

    }

}



p = 4;

a = A.A(p);

b1 = a.X;

b2 = a.Y;

b3 = a.Count1;

test = a.update();

c1 = a.X;

c2 = a.Y;

c3 = a.Count1;

test = b1;







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Dynamic_Array_Imperative_Function_Scope()
        {
            string code = @"
def createArray( p : int[] )

{  

    a = [Imperative]  

    {    

        collection = {};	

	lineCnt = 0;

	while ( lineCnt < 2 )

	{

            collection [ lineCnt ] = p [ lineCnt ] * -1;

	    lineCnt = lineCnt + 1;      

	}

	return = collection;

    }

    return = a;

}



x = createArray ( { 1, 2, 3, 4 } );

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Dynamic_Array_Imperative_Scope()
        {
            string code = @"
t = [Imperative]

{

    d = { { } };

    r = c = 0;

    a = { 0, 1, 2 };

    b = { 3, 4, 5 };

    for ( i in a )

    {

        c = 0;

	for ( j in b)

	{

	    d[r][c] = i + j;

	    c = c + 1;

        }

	r = r + 1;

    }

    test = d;

    return = test;

}

// expected : test = { { 3, 4, 5 }, {4, 5, 6}, {5, 6, 7} }

// received : test = { { 3, 4, 5 }, , }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Dynamic_Array_Inside_Function()
        {
            string code = @"


def foo ( d : var[] )

{

    [Imperative]

    {

	r = c = 0;

	a = { 0, 1, 2 };

	b1 = { 3, 4, 5 };

	for ( i in a )

	{

	    c = 0;

	    for ( j in b1)

	    {

		d[r][c] = i + j;

		c = c + 1;

	    }

	    r = r + 1;

	}	

    }

    return = d;

}



b = {};

b = foo ( b ) ;     

a = b;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Dynamic_Array_Inside_Function_2()
        {
            string code = @"


def foo ( d : var[]..[] )

{

    [Imperative]

    {

	r = c = 0;

	a = { 0, 1, 2 };

	b1 = { 3, 4, 5 };

	for ( i in a )

	{

	    c = 0;

	    for ( j in b1)

	    {

		d[r][c] = i + j;

		c = c + 1;

	    }

	    r = r + 1;

	}	

    }

    return = d;

}



b = { {} };

b = foo ( b ) ;     

a = b;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Dynamic_Array_Passed_As_Int_Array_To_Class_Method()
        {
            string code = @"
class A

{

                constructor A()

                {}

                def  foo : int(i : int[])

                {

                                return  = i[0] + i[1];

                }

}



[Associative]

{

                cy={};

                cy[0]=10;

                cy[1]=12;

                a=cy;

                d={cy[0],cy[1]};

                aa = A.A();              



                b1=aa.foo(d);//works

                b2=aa.foo(a); //does not work ñ error: Unknown Datatype Invalid

                b3=aa.foo(cy); //does not work ñ error: Unknown Datatype Invalid



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Dynamic_Array_Passed_As_Primitive_Array_To_Function()
        {
            string code = @"
class A

{

                constructor A()

                {}

                def  foo : double(i : var[])

                {

                                return  = i[0] + i[1];

                }

}



[Associative]

{

                cy={};

                cy[0]=1;

                cy[1]=1.5;

                a=cy;

                d={cy[0],cy[1]};

                aa = A.A();              



                b1=aa.foo(d);//works

                b2=aa.foo(a); //does not work ñ error: Unknown Datatype Invalid

                b3=aa.foo(cy); //does not work ñ error: Unknown Datatype Invalid



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Function_Call_In_Range_Expression()
        {
            string code = @"
[Associative]

{

	def foo : double ( a : double , b :double )

	{

		return = a + b ;	

	}

	

	a1 = 1..foo(2,3)..foo(1,1);

	a2 = 1..foo(2,3)..#foo(1,1);

	a3 = 1..foo(2,3)..~foo(1,1);

	a4 = { foo(1,0), foo(1,1), 3 };

	

}



[Imperative]

{

	def foo_2 : double ( a : double , b :double )

	{

		return = a + b ;	

	}

	

	a1 = 1..foo_2(2,3)..foo_2(1,1);

	a2 = 1..foo_2(2,3)..#foo_2(1,1);

	a3 = 1..foo_2(2,3)..~foo_2(1,1);

	a4 = { foo_2(1,0), foo_2(1,1), 3 };

	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_IfElseSyntax_negative()
        {
            string code = @"
[Imperative]

{

    if1.5

	{

		b = 1;

	}

		

}

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Pass_3x3_List_And_2x4_List()
        {
            string code = @"
class Math

{

	a : int;

	

	constructor ValueCtor(_a : int)

	{	

		a = _a;

	}

	

	def Div : int(num1 : int, num2 : int)

	{

		return = (num1 + num2) / a;

	}

}



list1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

list2 = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };

m = Math.ValueCtor(2);

list3 = m.Div(list1, list2);  // { { 1, 2, 3 }, { 4, 5, 6 } }

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_TestForLoopToModifyCollection()
        {
            string code = @"
[Imperative]

{

	a = {1,2,3,4,5,6,7};

	i = 0;

	for( x in a )

	{

	

		a[i] = a[i] + 1;

		i = i + 1;

		

	}

	a1 = a[0];

	a2 = a[1];

	a3 = a[2];

	a4 = a[3];

	a5 = a[4];

	a6 = a[5];

	a7 = a[6];

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_TestUsingMathematicalExpr__2_()
        {
            string code = @"
[Associative]

{

  a = 3;

  b = 2;

  c1 = a + b; 

  c2 = a - b;

  c3 = a * b;

  c4 = a / b; 



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_TestUsingMathematicalExpr()
        {
            string code = @"
[Imperative]

{

  a = 3;

  b = 2;

  c1 = a + b; 

  c2 = a - b;

  c3 = a * b;

  c4 = a / b; 



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT24_Update_Variable_Type()
        {
            string code = @"
class A

{	Pt : double;

	constructor A (pt : double)	

	{		

	    Pt = pt;	

	}

}

c = 1.0;

c = A.A( c );

x = c.Pt;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Adding_Elements_ToMemberOfClass_1465704_10()
        {
            string code = @"
class A

{

x : var[][];

constructor A ( )

{

x = { { 0, 0 } , { 1, 1 } };

}



}



y = A.A();

 // expected { { 0,0 }, { 1, 1, 1 }, {2, false, {2, 2}} }

x=[Imperative]

{



def add ( )

{

y.x[1][2] = 1;

y.x[2] = { null, false,{ 2, 2} };

return = y.x;

}

z = add();

return=z;

}











";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Adding_Elements_To_Array()
        {
            string code = @"
a = 0..2;

a[3] = 3;

b = a;



x = { { 0, 0 } , { 1, 1 } };

x[1][2] = 1;

x[2] = {2,2,2,2};

y = x;







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Adding_Elements_To_Array_Class()
        {
            string code = @"
class A

{

    x : var[][];

    constructor A (  )

    {

        x = { { 0, 0 } , { 1, 1 } };

    }



    def add ( ) 

    {

	x[1][2] = 1;

	x[2] = { 2, 2, 2, 2 };

	return = x;

    }

}



y = A.A();

x = y.add(); // expected { { 0,0 }, { 1, 1, 1 }, {2, 2, 2, 2} }







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Adding_Elements_To_Array_Function()
        {
            string code = @"
def add ( x : var[]..[] ) 

{

    x[1][2] = 1;

    x[2] = { 2, 2, 2, 2 };

    return = x;

}



x = { { 0, 0 } , { 1, 1 } };

x = add(x);







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Adding_elements_MemberClass_imperative_1465704_8()
        {
            string code = @"
class A

{

x : var[];

constructor A ( )

{

x = { { 0, 0 } , { 1, 1 } };

}



}



y = A.A();

 // expected { { 0,0 }, { 1, 1, 1 }, {2, false, {2, 2}} }



a=[Imperative]

{



def add ( )

{

z=0..5;

for(i in z)

{

	y.x[i] = 1;



}

return = y.x; 

}

y = add();

return=y;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Adding_elements_MemberClass_imperative_1465704_9()
        {
            string code = @"
class A

{

x : var[];

constructor A ( )

{

x = { { 0, 0 } , { 1, 1 } };

}



}



y = A.A();

 // expected { { 0,0 }, { 1, 1, 1 }, {2, false, {2, 2}} }



a=[Imperative]

{



def add ( )

{

z=5;

j=0;

while ( j<=z)

{

	y.x[j] = 1;;

j=j+1;



}

return = y.x; 

}

y = add();

return=y;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Adding_elements_tomemberofclass_1465704()
        {
            string code = @"
class A

{

x : var[][];

constructor A ( )

{

x = { { 0, 0 } , { 1, 1 } };

}



def add ( )

{

x[1][2] = 1;

x[2] = { 2, 2, 2, 2 };

return = x;

}

}



y = A.A();

x = y.add(); //x = {{0,0},{1,1,1},{2,2,2,2}}







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Adding_elements_tomemberofclass_1465704_2()
        {
            string code = @"
class A

{

x : var[][];

constructor A ( )

{

x = { { 0, 0 } , { 1, 1 } };

}





}

def add ( a:A)

{

a.x[1][2] = 1;

a.x[2] = { 2, 2, 2, 2 };

return = a.x;

}



y = A.A();

x = add(y); // expected { { 0,0 }, { 1, 1, 1 }, {2, 2, 2, 2} }









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Adding_elements_tomemberofclass_1465704_3()
        {
            string code = @"
class A

{

x : var[]..[];

constructor A ( )

{

x = { { 0, 0 } , { 1, 1 } };

}



def add ( )

{

x[1][2] = 1;

x[2] = { 2, false,{ 2, 2} };

return = x;

}

}



y = A.A();

x = y.add(); // expected { { 0,0 }, { 1, 1, 1 }, {2, false, {2, 2}} }











";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Adding_elements_tomemberofclass_1465704_4()
        {
            string code = @"
class A

{

x : var[]..[];

a: var[]..[];

constructor A ( )

{

x = { { 0, 0 } , { 1, 1 } };

}



def add ( )

{

x[1][2] = 1;

x[2] = { 2, false,{ 2, 2} };

return = x;

}

def test( )

{

a = x;

a[3]=1;

return = a;

}

}



y = A.A();

x = y.add(); 

z=y.test();//z = {{0,0},{1,1,1},{2,false,{2,2}},1}











";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Adding_elements_tomemberofclass_1465704_5()
        {
            string code = @"
class A

{

x : var[][];

a: var;

constructor A ( )

{

x = { { 0, 0 } , { 1, 1 } };

}



def remove ( )

{

x=Remove(x,1);

return = x;

}

def add( )

{

x[1] = {4,4};



return = x;

}

}



y = A.A();

x = y.remove(); //x = {{0,0},{4,4}}

z=y.add();//z = {{0,0},{4,4}}



















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Adding_elements_tomemberofclass_1465704_6()
        {
            string code = @"
class A

{

x : var[]..[];

constructor A ( )

{

x = { { 0, 0 } , { 1, 1 } };

}



}

class B extends A 

{

def add ( )

{

x[1][2] = 1;

x[2] = { 2, false,{ 2, 2} };

return = x;

}

}



y = B.B();

x = y.add(); // expected { { 0,0 }, { 1, 1, 1 }, {2, false, {2, 2}} }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Adding_elements_tomemberofclass_1465704_7()
        {
            string code = @"
class A

{

x : var[]..[];

constructor A ( )

{

x = { { 0, 0 } , { 1, 1 } };

}



}



y = A.A();

 // expected { { 0,0 }, { 1, 1, 1 }, {2, false, {2, 2}} }

x=[Imperative]

{



def add ( )

{

y.x[1][2] = 1;

y.x[2] = { 2, false,{ 2, 2} };

return = y.x;

}

z = add();

return=z;

}











";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Class_Assignment_dynamic_imperative_1465637_1()
        {
            string code = @"
class A

{

X:var;

Y:var;

Count1 :int;



constructor A ( i : int )

	{

	X = 0..i;

	[Imperative]

	{

		Y = {0,0,0,0,0};

		Count1 = 0; 

		for ( i in X ) {

			Y[Count1] = i * -1;

			Count1 = Count1 + 1;

		}

	}

}

}



p = 4;

a = A.A(p);

b1 = a.X;

 // expected { 0, 1, 2, 3, 4 }

b2 = a.Y;

 // expected {0,-1,-2,-3,-4}

b3 = a.Count1;

//received : //watch:

 b1 = {0,-1,-2,-3,-4};//watch: 

b2 = {0,0,0,0,0};



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Class_Properties_Modifiers()
        {
            string code = @"
class A

{ 

	public x : var ;	

	private y : var ;

	//protected z : var = 0 ;

	constructor A ()

	{

		   	

	}

	public def foo1 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	} 

	private def foo2 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	}	

}



a = A.A();

a1 = a.foo1(1);

a2 = a.foo2(1);

a.x = 4;

a.y = 5;

a3 = a.x;

a4 = a.y;









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Defect_1459759()
        {
            string code = @"
p1 = 2;

p2 = p1+2;

p1 = true;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Defect_1459759_2()
        {
            string code = @"
a1 = { 1, 2 };

y = a1[1] + 1;

a1[1] = 3;

a1 = 5;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Defect_1459759_3()
        {
            string code = @"
a = { 2 , b ,3 };

b = 3;

c = a[1] + 2;

d = c + 1;

b = { 1,2 };
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Defect_1459759_4()
        {
            string code = @"
[Imperative]

{

	[Associative]

	{

		p1 = 2;

		p2 = p1+2;

		p1 = true;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Defect_1459759_5()
        {
            string code = @"
[Imperative]

{

	a = 2;

	x = [Associative]

	{

		b = { 2, 3 };

		c = b[1] + 1;

		b = 2;

		return = c;

	}

	a = x;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Defect_1459759_6()
        {
            string code = @"


	def foo ( a, b )

	{

		a = b + 1;

		b = true;



		return = { a , b };

	}



[Imperative]

{



	c = 3;

	d = 4;



	e = foo( c , d );

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Defect_1459759_7()
        {
            string code = @"
class A

{

	a : var;



	constructor Create( xx )

	{

		a = xx;

	}



	def foo ( yy )

	{

		a = yy;

		return = yy;

	}

}



	test1 = A.Create( 3 );

	test2 = A.Create( 2 );



	test1.a = test2.a + 1;

	

	c = test2.foo( true );

	d = test1.a;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Function_Call_In_Mathematical_And_Logical_Expr()
        {
            string code = @"
[Associative]

{

	def foo : double ( a : double , b :double )

	{

		return = a + b ;	

	}

	

	a1 = 1 + foo(2,3);

	a2 = 2.0 / foo(2,3);

	a3 = 1 && foo(2,2);	

}



[Imperative]

{

	def foo_2 : double( a : double , b :double )

	{

		return = a + b ;	

	}

	

	a1 = 1 + foo_2(2,3);

	a2 = 2.0 / foo_2(2,3);

	a3 = 1 && foo_2(2,2);

	a4 = 0;

	

	if( foo_2(1,2) > foo_2(1,0) )

	{

	    a4 = 1;

	}

	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_IfElseSyntax_negative()
        {
            string code = @"
[Imperative]

{

    if1.5)

	{

		b = 1;

	}

		

} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_Pass_3_List_Different_Length()
        {
            string code = @"
class Math

{

	a : int;

	

	constructor ValueCtor(_a : int)

	{	

		a = _a;

	}

	

	def Div : int(num1 : int, num2 : int, num3 : int)

	{

		return = (num1 + num2 + num3) / a;

	}

}

list1 = { 1, 2, 3, 4, 5, 6, 7 };

list2 = { 1, 2, 3, 4, 5 };

list3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

m = Math.ValueCtor( 2 ); 

list4 = m.Div(list1, list2, list3); // { 1.5,3.0,4.5,6.0,7.5} }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_RangeExpression_WithDefaultDecrement()
        {
            string code = @"
a=5..1;









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_RangeExpression_WithDefaultDecrement_1467121()
        {
            string code = @"
a=5..1;

b=-5..-1;

c=1..0.5;

d=1..-0.5;







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_RangeExpression_WithDefaultDecrement_nested_1467121_2()
        {
            string code = @"
a=(5..1).. (1..5);









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_TestForLoopEmptyCollection()
        {
            string code = @"
[Imperative]

{

	a = {};

	x = 0;

	for( i in a )

	{

		x = x + 1;

	}

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_TestUsingMathematicalExpr__2_()
        {
            string code = @"
[Associative]

{

  a = 3.0;

  b = 2;

  c1 = a + b; 

  c2 = a - b;

  c3 = a * b;

  c4 = a / b; 



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT25_TestUsingMathematicalExpr()
        {
            string code = @"
[Imperative]

{

  a = 3.0;

  b = 2;

  c1 = a + b; 

  c2 = a - b;

  c3 = a * b;

  c4 = a / b; 



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_Class_Properties_Access()
        {
            string code = @"
class A

{ 

	public x : var ;	

	private y : var ;

	//protected z : var = 0 ;

	constructor A ()

	{

		   	

	}

	public def foo1 (a) 

	{

	    x = a;

		return = x + a;

	} 

	private def foo2 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	}	

	public def foo3 (a)

	{

	    x = a;

		return = x + foo2(a);

	}

}



[Imperative]

{

    a2 = [Associative]

	{

	    a1 = [Imperative]

		{

		    a = A.A();

			return = a;

		}

		a11 = a1.foo1(1);

		a12 = a1.x;

		return = a11+a12;

	}

	ax = A.A();

	a3 = ax.foo1(1);

	a4 = ax.foo3(1);

	a5 = ax.x;

	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_Defct_DNL_1459616()
        {
            string code = @"
a=1;

a={a,2};
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_Defct_DNL_1459616_2()
        {
            string code = @"
a={1,2};

[Imperative]

{

    a={a,2};

}



b = a;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_Defct_DNL_1459616_3()
        {
            string code = @"
a={1,2};

[Imperative]

{

    a={a,2};

}



b = { 1, 2 };

def foo ( )

{

    b =  { b[1], b[1] };

    return = null;

}



dummy = foo ();

c = b;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_Defct_DNL_1459616_4()
        {
            string code = @"
class A

{

    x : var[]..[];

    constructor A ()

    {

        a = { a, a };

        x = a;	

    }

    def foo ()

    {

        b = { b[0], b[0], b };

	return = b;

    }

}



//a={1,2};

x1 = A.A();



c = [Imperative]

{

    //b = { 0, 1 };

    t1 = x1.x;

    t2  = x1.foo();

    return = { t1, t2 };

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_Defct_DNL_1459616_5()
        {
            string code = @"
class A

{

    x : var[]..[];

    constructor A ()

    {

        a = { a, a };

        x = a;	

    }

    def foo ()

    {

        b = { b[0], b[0], b };

	return = b;

    }

}



a={1,2};

x1 = A.A();



c = [Imperative]

{

    b = { 0, 1 };

    t1 = x1.x;

    t2  = x1.foo();

    return = { t1, t2 };

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_Defect_1450854__2_()
        {
            string code = @"
[Associative]

{

    a = 1;

    b = 2;

    c = 0;

	

    if (3 == a ^ b )

    {

        c = 3;

    }

    else

    {

        c = 0;

    }	

		

} 





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_Defect_1450854()
        {
            string code = @"
[Imperative]

{

    a = 1;

    b = 2;

    c = 0;

	

    if (3 == a ^ b )

    {

        c = 3;

    }

    else

    {

        c = 0;

    }	

		

} 





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_Defect_1463663()
        {
            string code = @"
a = {

  1;

  +1;

  } 

  

b = a + 1;



c = [Imperative]

{

  a1 = {

  1;

  +1;

  } 

  

  b1 = a1 + 1;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_Function_Call_In_Mathematical_And_Logical_Expr()
        {
            string code = @"
[Imperative]

{

	def foo_2 : double ( a : double , b :double )

	{

		return = a + b ;	

	}

	a4 = 0;

	if( foo_2(1,2) < foo_2(1,0) )

	{

	    a4 = 1;

	}

	elseif( foo_2(1,2) && foo_2(1,0) )

	{

	    a4 = 2;

	}

	

	x = 0;	

	while (x < foo_2(1,2))

	{

	    x = x + 1;

	}

	

	c = { 0, 1, 2 };

	for (i in c )

	{

		if( foo_2(1,2) > foo_2(1,0) )

		{

		    x = x + 1;

		}

	}

	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_IfElseWithNegatedCondition()
        {
            string code = @"
[Imperative]

{

    a = 1;

	b = 1;

    c = 0;

	if( !(a == b) )

	{

		c = 1;

	}

	else

	{

		c = 2;

	}

		

} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_Negative_TestPropertyAccessOnPrimitive()
        {
            string code = @"
x = 1;

y = x.a;



[Imperative]

{

    x1 = 1;

    y1 = x1.a;

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_Pass_3_List_Different_Length_2_Integers()
        {
            string code = @"
class Math

{

	a : int;

	

	constructor ValueCtor(_a : int)

	{	

		a = _a;

	}

	

	def Div : int(num1 : int, num2 : int, num3 : int, num4 : int, num5 : int)

	{

		return = (num1 + num2 + num3 + num4 + num5) / a;

	}

}

list1 = { 10, 11, 12, 13, 14, 15, 16 };

list2 = { 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

list3 = { 30, 31, 32, 33, 34 };

m = Math.ValueCtor(4); 

listX2 = m.Div(list1, list2, list3, 15, 25); // { 25, 25, 26, 27, 28 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_RangeExpression_Function_tilda_1457845()
        {
            string code = @"
[Imperative]

{



	def square : double ( x: double ) 

	{

		return = x * x;

	}

	

	x = 0.1; 



	a = 0..2..~0.5;

	b = 0..0.1..~square(0.1);



	f = 0..0.1..~x;      

	g = 0.2..0.3..~x;    

	h = 0.3..0.2..~-0.1; 

	

	j = 0.8..0.5..~-0.3;

	k = 0.5..0.8..~0.3; 



	l = 0.2..0.3..~0.0;

	m = 0.2..0.3..~1/2; // division 



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_RangeExpression_Function_tilda_associative_1457845_3()
        {
            string code = @"


[Associative]

{

	def square : double ( x: double ) 

	{

		return = x * x;

	}

}

[Imperative]

{

	x = 0.1; 



	a = 0..2..~0.5;

	b = 0..0.1..~square(0.1);



	f = 0..0.1..~x;      

	g = 0.2..0.3..~x;    

	h = 0.3..0.2..~-0.1; 

	

	j = 0.8..0.5..~-0.3;

	k = 0.5..0.8..~0.3; 



	l = 0.2..0.3..~0.0;

	m = 0.2..0.3..~1/2; // division 

}

	







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_RangeExpression_Function_tilda_multilanguage_1457845_2()
        {
            string code = @"


[Associative]

{

	def square : double ( x: double ) 

	{

		return = x * x;

	}

[Imperative]

{

	x = 0.1; 



	a = 0..2..~0.5;

	b = 0..0.1..~square(0.1);



	f = 0..0.1..~x;      

	g = 0.2..0.3..~x;    

	h = 0.3..0.2..~-0.1; 

	

	j = 0.8..0.5..~-0.3;

	k = 0.5..0.8..~0.3; 



	l = 0.2..0.3..~0.0;

	m = 0.2..0.3..~1/2; // division 

}

	}







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_TestForLoopOnNullObject()
        {
            string code = @"
[Imperative]

{

	x = 0;

	

	for ( i in b )

	{

		x = x + 1;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_defect_1464429_DynamicArray()
        {
            string code = @"


def CreateArray ( x : var[] , i )

{

x[i] = i;

return = x;

}



b = { }; // Note : b = { 0, 0} works fine

count = 0..1;

t2 = CreateArray ( b, count );

t1=b;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT26_defect_1464429_DynamicArray_class()
        {
            string code = @"
class test

{

def CreateArray ( x : var[] , i )

{

x[i] = i;

return = x;

}

}



b = { }; // Note : b = { 0, 0} works fine

count = 0..1;

a= test.test();

t2 = a.CreateArray( b, count );

t1=b;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Class_Properties_Access()
        {
            string code = @"
class A

{ 

	public x : var ;	

	private y : var ;

	//protected z : var = 0 ;

	constructor A (i)

	{

		x = i;

        y = i;		

	}

	public def foo1 (a) 

	{

	    x = a;

		return = x + a;

	} 

	private def foo2 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	}	

	public def foo3 (a)

	{

	    x = a;

		return = x + foo2(a);

	}

}



[Imperative]

{

    aa = 0;

	a2 = [Associative]

	{

	    a1 = [Imperative]

		{

		    x = { 1, 2};

			add = 0;

			for ( i in x )

			{

			    ax = A.A(i); 

                add = add + ax.foo1(1) + ax.foo3(1);				

			}

			return = add;

		}

		a2 = A.A(3);

		return = a1 +a2.x;

	}

	if(a2 > 0 )

	{

	    x2 = A.A(2);

		aa = x2.foo3(2);

	}

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Defect_1450847__2_()
        {
            string code = @"
[Associative]

{

	 a = 2;

	 b = 0;

	 c = -1;

	 d = null;

	 

	 a1 = ~a; 

	 b1 = ~b;

	 c1 = ~c;

	 d1 = ~d;

	 

	 e = -0.5;

	 e1 = ~e1;

	 

	 f1 = ~e + ~a;

 

 }



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Defect_1450847()
        {
            string code = @"
[Imperative]

{

	 a = 2;

	 b = 0;

	 c = -1;

	 d = null;

	 

	 a1 = ~a; 

	 b1 = ~b;

	 c1 = ~c;

	 d1 = ~d;

	 

	 e = -0.5;

	 e1 = ~e1;

	 

	 f1 = ~e + ~a;

 

 }



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_DynamicArray_Class_1465802_Argument()
        {
            string code = @"
class A

{



	constructor A()

	{



}

	def foo : int(i:int[])

	{

		return = i[0] + i[1];

	}

}

[Associative]

{

cy={};

cy[0]=10;

cy[1]=12;

a=cy;

d={cy[0],cy[1]};

aa = A.A();

b1=aa.foo(cy);

b2=aa.foo(d);

b31=aa.foo(a);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_DynamicArray_Class_1465802_Argument_2()
        {
            string code = @"


class A

{



	constructor A()

	{



}

	def foo : int(i:int[])

	{

		return = 1;

	}

}

[Associative]

{

cy={};

cy[0]=10;

cy[1]=null;

aa = A.A();

b1=aa.foo(cy);



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_DynamicArray_Class_1465802_member()
        {
            string code = @"
class A

{

i:int[];

	constructor A(d:int[])

	{

i=d;

}

	def foo : int()

	{

		return = i[0] + i[1];

	}

}

[Associative]

{

cy={};

cy[0]=10;

cy[1]=12;

a=cy;

d={cy[0],cy[1]};

aa = A.A(cy);

bb = A.A(d);

cc = A.A(a);

a1=aa.foo();

b1=bb.foo();

c1=cc.foo();

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_DynamicArray_Invalid_Index_1465614_1()
        {
            string code = @"
a={};

b=a[2];

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_DynamicArray_Invalid_Index_1465614_2()
        {
            string code = @"
class Point

{

X : double;

Y : double;

Z : double;

constructor ByCoordinates ( x1 : double, y1 : double, z1 : double ) 

{

X = x1;

Y = y1;

Z = z1;

}

}

class Line{

P1: Point;

P2: Point;

constructor ByStartPointEndPoint ( p1: Point, p2: Point )



{

P1 = p1;

P2 = p2;

}

}

baseLineCollection = { };

basePoint = { }; // replace this with ""basePoint = { 0, 0};"", and it works fine

nsides = 2;

a = 0..nsides - 1..1;

[Imperative]

{

for(i in a)

{

basePoint[i] = Point.ByCoordinates(i, i, 0);

}

for(i in a)

{

baseLineCollection[i] = Line.ByStartPointEndPoint(basePoint[i], basePoint[i+1]);

}

}

x=basePoint[0].X;

y=basePoint[0].Y;

z=basePoint[0].Z;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_DynamicArray_Invalid_Index_1467104()
        {
            string code = @"
class Point

{

	x : var;



	constructor Create(xx : double)

	{

		x = xx;

	}



}



pts = Point.Create( { 1, 2} );

aa = pts[null].x;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_DynamicArray_Invalid_Index_1467104_2()
        {
            string code = @"
class Point

{

x : var[];



constructor Create(xx : double)

{

	x = {xx,1};

}



}

[Imperative]

{



pts = Point.Create( { 1, 2} );



aa = pts[null].x[null];

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_DynamicArray_Invalid_Index_imperative_1467104_3()
        {
            string code = @"
class Point

{

x : var[];



constructor Create(xx : double)

{

	x = {xx,1};

}



}

[Imperative]

{

	pts = Point.Create( { 1, 2} );

	aa = pts[null];

	aa1 = pts[null].x[null];

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Function_Call_Before_Declaration()
        {
            string code = @"
[Associative]

{ 

	def Level1 : int (a : int) 

	{  

		return = Level2(a+1); 

	}  

	def Level2 : int (a : int) 

	{  

		return = a + 1; 

	} 



	input = 3; 

	result = Level1(input); 



}



[Imperative]

{ 

	a = foo(1); 

	def foo : int (a : int)

	{

		return = a + 1; 

	}



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_IfElseSyntax_negative()
        {
            string code = @"
[Imperative]

{

    if(1)

	

		b = 1;

	}

		

} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_Cross_Reference()
        {
            string code = @"
a = {

		  1 => a1;

		  b1 + a1 => a2;		  		  

    };



b = {

		  2 => b1;		  		  

    };	  



	  

	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_Inside_Class()
        {
            string code = @"
class B

{

    x : var;

    constructor B ( y )

    {

        x = y;

    }

}

class A

{ 

    a : var;

	a1 : var;

	a2  :var;

	a3 : var;

	a4 : var;

	a5 : var[];

	a6 : var[];

	a7 : var;

	a8 : var;

	

    constructor A ( x : var )

	{

	    a = {

		  x => a1;

		  a1 - 0.5 => a2;

		  a2 * null => a3;

		  a1 > 10 ? true : false => a4;

		  a1..2 => a5;

		  { a3, a3 } => a6;

		  B.B(a1) => a7;	 

          B.B(a1).x => a8;			  

     }

	}

}



a1 = A.A ( 1 );	

x = { a1.a1, a1.a2, a1.a3, a1.a4, a1.a5, a1.a6, a1.a7, a1.a8 };

y = a1.a;

	  

	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_Inside_Class_2()
        {
            string code = @"
class B

{

    x : var;

    constructor B ( y )

    {

        x = y;

    }

}

class A

{ 

    a : var;

	a1 : var;

	a2  :var;

	a3 : var;

	a4 : var;

	a5 : var;

	a6 : var;

	a7 : var;

	a8 : var;

	

    constructor A ( x : var )

	{

	    a = x;			  

	}

	def update ( x : var )

	{

	    a = {

		  x => a1;

		  a1 - 0.5 => a2;

		  a2 * null => a3;

		  a1 > 10 ? true : false => a4;

		  a1..2 => a5;

		  { a3, a3 } => a6;

		  B.B(a1) => a7;	 

          B.B(a1).x => a8;			  

	  };

	  return = x;

	}

}



a1 = A.A ( 0 );	

x = a1.update(1);

y = { a1.a1, a1.a2, a1.a3, a1.a4, a1.a5, a1.a6, a1.a8 };



	  

	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_Inside_Function()
        {
            string code = @"
class A

{ 

    x : int;

    constructor A ( y )

	{

	    x = y;

	}

}



def foo ( ) 

{

    

	a = {

		  1 => a1;

		  a1 - 0.5 => a2;

		  a2 * null => a3;

		  a1 > 10 ? true : false => a4;

		  a1..2 => a5;

		  { a3, a3 } => a6;

		  A.A(a1) => a7;	 

          A.A(a1).x => a8;			  

	  }

    return = { a1, a2, a3, a4, a5, a6, a8 };

}



x = foo ();	

	  

	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_Update()
        {
            string code = @"
b1 = 2;



a = {

		  1 => a1;

		  a1 + b1 => a2;		  		  

    };

	

b1 = 3;

a1 = 2;

a1 = null;

dummy = 1;



  



	  

	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_Update_2()
        {
            string code = @"
a = {

		  1 => a1;

		  a1 + b1 => a2;		  		  

    };

b1 = 2;	





  



	  

	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_Update_3()
        {
            string code = @"
class B

{

    y : var;

    constructor B ( x : var )

    {

        y = x;

    } 

}



class A

{

    x : var;

    constructor A ( y : var )

    {

        x = y;

    }

    

    def foo1 ( )

    {

        return = A.A(x + 1);

    }

    

    def foo2 ( y : var )

    {

        return = B.B( y );

    }

    

    def foo3 ( x1 : A, x2 : B )

    {

        return = A.A ( x1.x + x2.y );

    }

}



y = 1;



a = {

		  A.A(1) => a1;

		  a1.foo1() => a2;

		  a1.foo2( y) => a3;

                  a1.foo3(a2,a3);                 		  

    }

    

z = a.x;







  



	  

	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_Update_4()
        {
            string code = @"
y = 3;



a =

	{

		y + 1 => a1;

		 +1 => a2;

	}

	

b1 = a1;

b2 = a2;



y = 4;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_Update_5()
        {
            string code = @"
def foo ( x )

{

    return = x * 2;

}



y = 3;

a =

	{

		foo( y ) + 1 => a1;

		 * 3 => a2;

	}

y = 2;	

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_Update_6()
        {
            string code = @"
class A

{

    x : var;

    constructor A ( y)

    {

        x = y;

    }

}



def foo ( a : A )

{

    return = a.x * 2;

}



y = 3;

a =

	{

		A.A ( y ) => a1;

		foo ( a1 ) => a2;

	}



b = foo ( a1 );



y = 2;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_With_Array()
        {
            string code = @"
a =

	{

		{1,2,3,4} => a1;

		a[0] + 1 => a2; 

	}

	

b1 = a1;

b2 = a;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_With_Array_2()
        {
            string code = @"
a =

	{

		{ 1, 2, 3, 4} => a1;

		 a [ 0] + 1 => a2;

	}

	

b1 = a1;

b2 = a2;



a = 4;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_With_Array_3()
        {
            string code = @"
a =

	{

		{1,2,3,4} => a1; // identify the initial state to modify

		{a1[0]+3, a1[-1]};  // modify selected members [question: can we refer to 'a@initial' in this way 

				     // inside the modifier block where the right assigned variable was created?]

		//+10 // this modification applies to the whole collection

	}



	

b = a;

c = { a1[0], a[-1] };



x = [Imperative]

{

    return = { a[0], a1[1] };



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_With_Array_4()
        {
            string code = @"
a = { 1, 2, 3, 4 };

a[0] =

	{

		a[0] + 1 => a1;

		a1 * 2 => a2;  

		{ a2, a2};

	}



/*[Imperative]

{

    a[1] =

	{

		a[1] + 1 => a1;

		a1 * 2 => a2;  

		{ a2, a2};

	}

}*/



b = a;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_With_Different_Types()
        {
            string code = @"
    class A

	{ 

	    x : int;

	    constructor A ( y )

		{

		    x = y;

		}

	}



	a = {

		  1 => a1;

		  0.5 => a2;

		  null => a3;

		  false => a4;

		  { 1,2 } => a5;

		  { null, null } => a6;

		  A.A(1) => a7;	 

          A.A(1).x => a8;			  

	  } 

	  

	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_With_Different_Types_2()
        {
            string code = @"
    class A

	{ 

	    x : int;

	    constructor A ( y )

		{

		    x = y;

		}

	}



	a = {

		  1 => a1;

		  a1 - 0.5 => a2;

		  a2 * null => a3;

		  a1 > 10 ? true : false => a4;

		  a1..2 => a5;

		  { a3, a3 } => a6;

		  A.A(a1) => a7;	 

          A.A(a1).x => a8;			  

	  } 

	  

	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_With_Function_Call()
        {
            string code = @"
def foo ( a : int, b : double )

{

    return = a + b + 3;

}



v = 1;

a = {

  1 => a1;

  +1 => a2;

  +foo(a2,a1)-3 => a3;

  } 

  

b = a + 1;

c = a1 + 1;

d = a2 + 1;

f = a3 + 1;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_With_Function_Call_2()
        {
            string code = @"
def foo ( a : int, b : double )

{

    return = a + b + 3;

}



x = [Associative]

{

	v = 1;

	a = {

	  1 => a1;

	  +1 => a2;

	  +foo(a2,a1)-3 => a3;

	  } 

	  

	b = a + 1;

	c = a1 + 1;

	d = a2 + 1;

    f = a3 + 1;

	return = { b, c, d, f };

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_With_Inline_Condition()
        {
            string code = @"
class B

{

    b : var;

    constructor B ( y )

    {

        b = y;

    }

}

class A

{ 

    a : var;

    constructor A ( x : var )

    {

        a = x;

    }

}



x1 = 1;

x2 = 0.1;

x3 = true;

x4 = A.A(10);



a = 

{

	x1 > x2 ? true : false => a1;

	x4.a == B.B(10).b ? true : false => a2;

	x1 == x2 ? true : x3 => a3;

	x1 != x2 ? B.B(2).b : A.A( 1).a => a4;		  

};	  



x = a == 2 ? true : false;

	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_With_Range_Expr()
        {
            string code = @"
def foo ( x : int[])

{

    return = { x[1], x[0] };

}

class A

{ 

    a : var;

    constructor A ( x : var )

    {

        a = x;

    }

}



x1 = 1;

x2 = 0.1;

x3 = true;

x4 = A.A(10);



a = 

{

	x1 .. x2  => a1;

	x2 .. x1 => a4;

	1 .. x4.a .. 2 => a2;

	a[0]..a[2]..#5 => a5;

	x1 == x2 ? false : x1..2 => a3;

        foo ( a3) ;	

};	  



b = 0.0..a[0]..0.5;



	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_With_Right_Assignment()
        {
            string code = @"
v = 1;

a = 

{

  1 => a1;

  +1 => a2;

  +v => a3;

} 

b = a + 1;

c = a1 + 1;

d = a2 + 1;

f = a3 + 1;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Modifier_Stack_With_Self_Updates()
        {
            string code = @"
a = {

    1 => a1;

    +1 => a2;

    +1 => a3;

    +a2 => a4;

    +a3 => a5;

}



	



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_Pass_3_List_Same_Length()
        {
            string code = @"
class Math

{

	a : int;

	

	constructor ValueCtor(_a : int)

	{	

		a = _a;

	}

	

	def Mul : int(num1 : int, num2 : int, num3 : int)

	{

		return = (num1 + num2 + num3) * a;

	}

}

list1 = { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40 };

list2 = { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

list3 = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

m = Math.ValueCtor(4); 

list4 = m.Mul(list1, list2, list3); // { 252, 264, 276, 288, 300, 312, 324, 336, 348, 360 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_RangeExpression_Function_Associative_1463472()
        {
            string code = @"
[Associative]

{

	def twice : double( a : double )

	{

		return = 2 * a;

	}

	z1 = 1..twice(4)..twice(1);

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_RangeExpression_Function_Associative_1463472_2()
        {
            string code = @"
[Associative]

{

	def twice : int []( a : double )

	{

		c=1..a;

		return = c;

	}

d=1..4;

c=twice(4);

//	z1 = 1..twice(4)..twice(1);

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_RangeExpression_Function_Associative_replication()
        {
            string code = @"
[Associative]

{

	def twice : int[]( a : int )

	{

		c=2*(1..a);

		return = c;

	}

    d={1,2,3,4};

	z1=twice(d);

//	z1 = 1..twice(4)..twice(1);

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_RangeExpression_Function_return_1463472()
        {
            string code = @"
[Associative]

{

	def twice : int []( a : double )

	{

		c=1..a;

		return = c;

	}

d=1..4;

c=twice(4);

//	z1 = 1..twice(4)..twice(1);

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_RangeExpression_class_return_1463472_2()
        {
            string code = @"
class twice

{

	def twice : int []( a : double )

	{

		c=1..a;

		return = c;

	}

}

d=1..4;

a=twice.twice();



c=a.twice(4);

//	z1 = 1..twice(4)..twice(1);





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_TestCallingFunctionInsideForLoop()
        {
            string code = @"
[Imperative]

{

	def function1 : double ( a : double )

	{		

		return = a + 0.7;

	}

	

	a = { 1.3, 2.3, 3.3, 4.3 };

	

	x = 3;

	

	for ( i in a )

	{	

		x = x + function1( i );

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_defect_1464429_DynamicArray()
        {
            string code = @"


def CreateArray ( x : var[] , i )

{

x[i] = i;

return = x;

}



b = { }; // Note : b = { 0, 0} works fine

count = 0..1;

t2 = CreateArray ( b, count );

t1=b;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_defect_1464429_DynamicArray_class()
        {
            string code = @"
class test

{

	def CreateArray ( x : var[] , i )

	{

		smallest1  =  i>1?i*i:i;

		x[i] = smallest1;

		return = x;

	}

}



b = { }; // Note : b = { 0, 0} works fine

count = 0..2;

a= test.test();

t2 = a.CreateArray( b, count );

t1=b;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_defect_1464429_DynamicArray_class_inherit()
        {
            string code = @"
class test

{

y ={};

	def CreateArray (  i :int)

	{

		y[1] = i;

		return = y;

	}

}



class test1 extends test

{



   def CreateArray (  i :int)

	{



		y[i] = i*-1;

		return = y;

	}

}



count = 0..2;

a= test1.test1();



t2 = a.CreateArray(  count );

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_defect_1464429_DynamicArray_inline()
        {
            string code = @"
class test

{

	def CreateArray ( x : var[] , i )

	{

		smallest1  =  i>1?i*i:i;

		x[i] = smallest1;

		return = x;

	}

}



b = { }; // Note : b = { 0, 0} works fine

count = 0..2;

a= test.test();

t2 = a.CreateArray( b, count );

t1=b;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_defect_1464429_DynamicArray_memberof_class()
        {
            string code = @"
class test

{

y ={};

	def CreateArray (  i :int)

	{



		y[i] = i;

		return = y;

	}

}





count = 0..2;

a= test.test();



t2 = a.CreateArray(  count );
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT27_defect_1464429_DynamicArray_update()
        {
            string code = @"


def CreateArray ( x : var[] , i )

{

x[i] = i;

return = x;

}



b = { }; // Note : b = { 0, 0} works fine

count = 0..1;

t2 = CreateArray ( b, count );

t1=b;

count = -2..-1;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT28_Class_Properties_Access()
        {
            string code = @"
class A

{ 

	public x : var ;	

	private y : var ;

	//protected z : var = 0 ;

	constructor A (i)

	{

		x = i;

        y = i;		

	}

 

	private def foo2 (a)

	{

	    x = a;

		y = a + 1;

		return = x + y;

	}	

	public def foo3 (a)

	{

	    x = a;

		return = x + foo2(a);

	}

}



class B

{ 

	public x : var ;	

	public y : A ;

	//protected z : var = 0 ;

	constructor B (i)

	{

		x = i;

        y = A.A(i);		

	}

 

	public def foo3 (a)

	{

	    x = a;

		y = A.A(a);

		return = x + y.x;

	}	

	

}

def foo (a1 : A, b1 :B )

{

    x = a1.x + b1.x;

	//y = a1.foo3(1) + b1.foo3(1);

	return = x ;//+ y;

}



v1 = [Imperative]

{

    def foo (a1 : A, b1 :B )

	{

		x = a1.x + b1.x;

		y = a1.foo3(1) + b1.foo3(1);

		return = x + y;

	}



    a1 = A.A(1);

	b1 = B.B(1);

	

	f1 = foo(a1,b1);

	x = { 1, 2 };

	add = 0;

	for ( i in x )

	{

	    ax = A.A(i); 

        bx = B.B(i);

		add = add + foo(ax, bx);				

	}

	if(add > 0 )

	{

	    add = add + foo(a1,b1);		

	}

	return = add;

}



a2 = A.A(2);

b2 = B.B(2);

f2 = foo(a2,b2);



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT28_Defect_1452966()
        {
            string code = @"
[Imperative]

{

	a = { 1,2,3 };

	x = 0;

	for ( i in a )

	{

		for ( j in a )

        {

			x = x + j;

		}

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT28_Function_Arguments_Declared_Before_Function_Def()
        {
            string code = @"
result = [Associative]

{ 

	a = 0;

	b = 1;

	def foo : int (a : int, b: int)

	{

		return = a + b; 

	}

	

	result = foo( a, b); 

	return = result;



}

result2 = 

[Imperative]

{ 

	a = 3;

	b = 4;

	def foo : int (a : int, b: int)

	{

		return = a + b; 

	}

	

	result2 = foo( a, b); 

	return = result2;



}



result3 = 

[Associative]

{ 

	a = 5;

	b = 6;

	result3 = [Imperative]

	{

		def foo : int (a : int, b: int)

		{

			return = a + b; 

		}

		

		result3 = foo( a, b); 

		return = result3;

	}

	return = result3;



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT28_IfElseSyntax_negative()
        {
            string code = @"
[Imperative]

{

    if(1)

	{

		{

		    b = 1;

	

		

} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT28_Pass_3_List_Same_Length_2_Integers()
        {
            string code = @"
class Math

{

	a : int;

	

	constructor ValueCtor(_a : int)

	{	

		a = _a;

	}

	

	def Div : int(num1 : int, num2 : int, num3 : int, num4 : int, num5 : int)

	{

		return = (num1 + num2 + num3 + num4 + num5) / a;

	}

}

list1 = { 10, 11, 12, 13, 14 };

list2 = { 20, 21, 22, 23, 24 };

list3 = { 30, 31, 32, 33, 34 };

m = Math.ValueCtor(4); 

list2 = m.Div(list1, list2, list3, 15, 25);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT28_Update_With_Inline_Condition()
        {
            string code = @"
x = 3;

a1 = 1;

a2 = 2;

a = x > 2 ? a1: a2;

a1 = 3;

a2 = 4;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT28_Update_With_Inline_Condition_2()
        {
            string code = @"
x = 3;

a1 = { 1, 2};

a2 = 3;

a = x > 2 ? a2: a1;



a2 = 5;

x = 1;

a1[0] = 0;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT28_defect_1465706__DynamicArray_Imperative()
        {
            string code = @"
[Imperative]

{

def CreateArray ( x : var[] , i )

{

x[i] = i;

return = x;

}



test = { };

test = CreateArray ( test, 0 );

test = CreateArray ( test, 1 );

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT28_defect_1465706__DynamicArray_Imperative_2()
        {
            string code = @"
[Imperative]

{

    def test (i:int)

    {

        local = {};

        for(j in i)

        {

            local[j] = j;



        }

        return = local;

    }



    a={3,4,5};

    t = test(a);

    r = {t[0][3], t[1][4], t[2][5]};

    return = r;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT29_Class_Method_Chaining()
        {
            string code = @"
class A

{ 

	x : int[];	

	

	constructor A ( i :int[])

	{

		x = i;

       	

	}

 

	public def foo ()

	{

	    return = x;

	}

}



class B

{ 

	public x : A ;	

	

	constructor B (i:A)

	{

		x = i;

       

	}

 

	public def foo ()

	{

	    return = x;

	}	

	

}



x = { 1, 2, 3 };

y = { 4, 5, 6 };

a1 = A.A(x);

a2 = A.A(y);

b1 = B.B({a1,a2});

t1 = b1[0].x.x[1];







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT29_Defect_1449887__2_()
        {
            string code = @"
[Associative]

{  

	a = 14;  

	b = 7;  

	c = a & b; 

	d = a|b;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT29_Defect_1449887()
        {
            string code = @"
[Imperative]

{  

	a = 14;  

	b = 7;  

	c = a & b; 

	d = a|b;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT29_Defect_1452966_2()
        {
            string code = @"
[Imperative]

{

	a = {{6},{5,4},{3,2,1}};

	x = 0;

	

    for ( i in a )

	{

		for ( j in i )

		{

			x = x + j;

		}

	}		

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT29_DynamicArray_Using_Out_Of_Bound_Indices()
        {
            string code = @"
   

    basePoint = {  };

    

    basePoint [ 4 ] =3;

    test = basePoint;

    

    a = basePoint[0] + 1;

    b = basePoint[ 4] + 1;

    c = basePoint [ 8 ] + 1;

    

    d = { 0,1 };

    e1 = d [ 8] + 1;

    

    x = { };

    y = { };    

    t = [Imperative]

    {

        k = { };

	for ( i in 0..1 )

	{

	    x[i] = i;

	}

	k[0] = 0;

	for ( i in x )

	{

	    y[i] = x[i] + x[i+1];

	    k[i+1] = x[i] + x[i+1];

	

	}

	return = k;

    }

    z = y;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT29_Function_With_Different_Arguments()
        {
            string code = @"
[Imperative]

{ 

	 def foo : double ( a : int, b : double, c : bool, d : int[], e : double[][], f:int[]..[], g : bool[] )

	 {

	     x = -1;

		 if ( c == true && g[0] == true)

		 {

		     x = x + a + b + d[0] + e[0][0];

		 }

		 else

		 {

		     x = 0;

		 }

         return  = x;

	 }

	 

	 a = 1;

	 b = 1;

	 c = true;

	 d = { 1, 2 };

	 e = { { 1, 1 }, {2, 2 } } ;

	 f = { {0, 1}, 2 };

	 g = { true, false };

	 

	 y = foo ( a, b, c, d, e, f, g );



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT29_IfElseSyntax_negative()
        {
            string code = @"
[Imperative]

{

    b = 0;

    if(1)

	{

		b = 1

	}

	

		

} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT29_Pass_FunctionCall_Reutrn_List001()
        {
            string code = @"
class Math

{

	a : int;

	

	constructor ValueCtor(_a : int)

	{	

		a = _a;

	}

	

	def Mul : int(num : int)

	{

		return = num * a;

	}

}



list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

m = Math.ValueCtor(10);

list2 = m.Mul(m.Mul(list1));  // { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT30_Class_Property_Update_Negative()
        {
            string code = @"
class A

{ 

	x : int[];		

	constructor A ( i :int[])

	{

		x = i;       	

	} 

	public def foo ()

	{

	    x = true;

		return = x;

	}

}

x = { 1, 2, 3 };

a1 = A.A(x);

x1 = a1.x;

x2 = a1.foo();

x3 = 3;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT30_Defect_1449887_2__2_()
        {
            string code = @"
[Associative]

{   



 def ANDfunc:int(a:int,b:int)

 { 

  

  return = a & b; 

 

 }



 def ORfunc:int(a:int,b:int)

 {

   

   return = a|b;

 

 }

 

 e = 14;

 

 f = 7;

 

 c = ANDfunc(e,f); 

 

 d = ORfunc(e,f);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT30_Defect_1449887_2()
        {
            string code = @"
[Imperative]

{   



 def ANDfunc:int(a:int,b:int)

 { 

  

  return = a & b; 

 

 }



 def ORfunc:int(a:int,b:int)

 {

   

   return = a|b;

 

 }

 

 e = 14;

 

 f = 7;

 

 c = ANDfunc(e,f); 

 

 d = ORfunc(e,f);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT30_ForLoopNull()
        {
            string code = @"
[Imperative]

{

	a = { 1,null,null };

	x = 1;

	

	for( i in a )

	{

		x = x + 1;

	}

}

	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT30_Function_With_Mismatching_Return_Type_DS()
        {
            string code = @"
[Imperative]

{ 

	 def foo1 : double ( a : double )

	 {

	    return = true;

	 }

	 

	 dummyArg = 1.5;

	

	b1 = foo1 ( dummyArg );

	

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT30_IfElseSyntax_negative()
        {
            string code = @"
[Imperative]

{

    if(1)

	{

		b = 1;

	}

	else c = 2 } 

	

		

} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT30_Pass_FunctionCall_Reutrn_List002()
        {
            string code = @"
class Math

{

	a : int;

	

	constructor ValueCtor(_a : int)

	{	

		a = _a;

	}

	

	def Mul : int(num : int)

	{

		return = num * a;

	}

}



def foo : int (a : int)

{

	return = a * a;

}



list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

m = Math.ValueCtor(10);

list2 = m.Mul(foo(list1));  // { 10, 40, 90, 160, 250, 360, 490, 640, 810, 1000 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT30_Update_Global_Variables_Class()
        {
            string code = @"
x  = 1;



class A

{

    static y : int;

    constructor A ( x )

    {

        y = x;

    }

    constructor A2 ( x1 )

    {

        y = x + x1;

    }

}



y = A.A(2);

z = y.y;



y1 = A.A2(2);

z1 = y1.y;



x = 3;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT30_Update_Global_Variables_Function()
        {
            string code = @"
x  = 1;



class A

{

   x : double;

   constructor A ( x1 )

   {

       x = x1;

   }

   def getx ( )

   {

       x = x + 1;

       return = x ;

   }

}



y = A.A(2);

z1 = y.x;

z2 = y.getx();

z3 = x;

z4 = y.x;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT30_Update_Global_Variables_Imperative_Scope()
        {
            string code = @"
x  = {0,0,0,0};

count = 0;

i = 0;

sum  = 0;

test = sum;

[Imperative]

{

    for  ( i in x ) 

    {

       x[count] = count;

       count = count + 1;       

    }

    j = 0;

    while ( j < count )

    {

        sum = x[j]+ sum;

        j = j + 1;

    }

}



y = x;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT30_Update_Global_Variables_Imperative_Scope_2()
        {
            string code = @"


count = 0;

i = 0;

sum  = 0;

test = sum;

[Imperative]

{

    for  ( i in x ) 

    {

       x[count] = count;

       count = count + 1;       

    }

    j = 0;

    while ( j < count )

    {

        sum = x[j]+ sum;

        j = j + 1;

    }

}

x  = {0,0,0,0};

y = x;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_Class_By_Composition()
        {
            string code = @"
class Point

{

    X : double;

	Y : double;

	Z : double;

	

	constructor ByCoordinates( x : double, y : double, z : double )

	{

	    X = x;

		Y = y;

		Z = z;		

	}

}



class Line

{

    P1 : Point;

	P2 : Point;

	

	constructor ByStartPointEndPoint( p1 : Point, p2 : Point )

	{

	    P1 = p1;

		P2 = p2;

	}

	

	def PointAtParameter (p : double )

	{

	

	    t1 = P1.X + ( p * (P2.X - P1.X) );

		//t2 = 

		return = Point.ByCoordinates( t1, P1.Y, P1.Z);

	    

	}

	

}





class MyLineByComposition 

{

	BaseLine : Line; // line property

	MidPoint : Point; // midPoint property

	

	public constructor ByPoints(start : Point, end : Point)

	{

		BaseLine = Line.ByStartPointEndPoint(start, end);

		MidPoint = BaseLine.PointAtParameter(0.5);

	}

}



p1 = Point.ByCoordinates( 5.0, 0.0, 0.0 );

p2 = Point.ByCoordinates( 10.0, 0.0, 0.0 );



myLineInstance = MyLineByComposition.ByPoints(p1, p2);



testP = myLineInstance.MidPoint;

x1 = testP.X;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_Defect_1449877__2_()
        {
            string code = @"
[Associative]

{

	a = -1;

	b = -2;

	c = -3;

	c = a * b * c;

	d = c * b - a;

	e = b + c / a;

	f = a * b + c;

} 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_Defect_1449877()
        {
            string code = @"
[Imperative]

{

	a = -1;

	b = -2;

	c = -3;

	c = a * b * c;

	d = c * b - a;

	e = b + c / a;

	f = a * b + c;

} 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_Defect_1459777()
        {
            string code = @"
class A 

{

    a : var;

	constructor A ( x)

	{

	    a = x;

	}

}



x = 3;

a1 = A.A(x);

b1 = a1.a;

x = 4;

c1 = b1;



// expected : c1 = 4;

// recieved : c1 = 3



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_Defect_1459777_2()
        {
            string code = @"
class A

{

    a : int;	

}



a1 = A.A();

a1.a = 1;

b = a1.a;

a1.a = 2; // expected b = 2; received : b = 1;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_Defect_1459777_3()
        {
            string code = @"
class A

{

    a : int;	

}



a1 = A.A();

x = a1.a;

c = [Imperative]

{

    a1.a = 1;

    b = a1.a;

    a1.a = 3; 

	return = b;

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_Defect_1459777_4()
        {
            string code = @"
class A

{

    a : int;	

}

class B extends A 

{

    b : var; 

	

}



def foo ( x )

{

    x.b = 2;

	return = true;

}

y = B.B();

y.b = 1;

z = y.b;

test = foo ( y ) ;

z2 = z;







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_Defect_1459777_5()
        {
            string code = @"
class A

{

    a : int;	

}

class B 

{

    b : var;

    constructor B ( a : A )

    { 

	    a.a = 2;

		b = a.a + 2;

    }	

	

}



y = A.A();

z = y.a;

x = B.B(y);

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_Defect_1459777_6()
        {
            string code = @"
	

class A

{

    a : int;	

}

class B 

{

    b : var;

    constructor B ( a : A )

    { 

	    a.a = 3;

    }	

	def foo ( a : A )

	{

	    a.a = 3;

		return = true;

	}

	

}



y = A.A();

z = y.a;

x1 = B.B( y );

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_Defect_1459777_7()
        {
            string code = @"
class A

{

    a : int;	

}



x = A.A();

y = x.a;

y1 = 0..y;

y2 = y > 1 ? true : false;

y3 = 1 < x.a ? true : false;

x.a = 2;

z1 = y1;

z2 = y2;

z3 = y3;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_Defect_1459777_8()
        {
            string code = @"
class A

{

    a : int;	

}



def foo ( x ) 

{

    return  = x + 1;

}



x1 = A.A();

y1 = foo( x1.a );

x1.a = 2;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_Defect_1459777_9()
        {
            string code = @"
class A

{

    a : int;	

}



def foo ( x ) 

{

    return  = x + 1;

}



x1 =  { A.A(), A.A() };

a1 = A.A();

x2 =  { a1.a, a1.a };

y2 = foo ( x2[0] );

y1 = foo ( x1[1].a );

x1[1].a = 2;

a1.a = 2; 



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_ForLoopSyntax01_Negative()
        {
            string code = @"
[Imperative]

{

	a = { 1,2,3,4 };

	

	x = 0;

	

	for ( (i in a) )

	{

		x = x + i;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_Function_With_Mismatching_Return_Type()
        {
            string code = @"
[Imperative]

{ 

	 def foo2 : double ( a : double )

	 {

	    return = 5;

	 }

	 

	dummyArg = 1.5;

	

	b2 = foo2 ( dummyArg );

	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_IfElseSyntax_negative()
        {
            string code = @"
[Imperative]

{

    if(1)

	{

		b = 1;

	}

	elsee  { c = 2 } 

	

		

} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT31_Pass_FunctionCall_Reutrn_List003()
        {
            string code = @"
class Math

{

	a : int;

	

	constructor ValueCtor(_a : int)

	{	

		a = _a;

	}

	

	def Mul : int(num : int)

	{

		return = num * a;

	}

}



def foo : int (a : int)

{

	return = a * a;

}



list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

m = Math.ValueCtor(10);

list2 = foo(m.Mul(list1));  // { 100, 400, 900, 1600, 2500, 3600, 4900, 6400, 8100, 10000 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT32_Class_ReDeclaration()
        {
            string code = @"
class Point

{

    X : double;

	Y : double;

	Z : double;

	

	constructor ByCoordinates( x : double, y : double, z : double )

	{

	    X = x;

		Y = y;

		Z = z;		

	}

}



class Line

{

    P1 : Point;

	P2 : Point;

	

	constructor ByStartPointEndPoint( p1 : Point, p2 : Point )

	{

	    P1 = p1;

		P2 = p2;

	}

	

	def PointAtParameter (p : double )

	{

	

	    t1 = P1.X + ( p * (P2.X - P1.X) );

		//t2 = 

		return = Point.ByCoordinates( t1, P1.Y, P1.Z);

	    

	}

	

}



class Point

{

    X : double;

	

	

	constructor ByCoordinates( x : double )

	{

	    X = x;

			

	}

}



class MyLineByComposition 

{

	BaseLine : Line; // line property

	MidPoint : Point; // midPoint property

	

	public constructor ByPoints(start : Point, end : Point)

	{

		BaseLine = Line.ByStartPointEndPoint(start, end);

		MidPoint = BaseLine.PointAtParameter(0.5);

	}

}



p1 = Point.ByCoordinates( 5.0, 0.0, 0.0 );

p2 = Point.ByCoordinates( 10.0, 0.0, 0.0 );



myLineInstance = MyLineByComposition.ByPoints(p1, p2);



testP = myLineInstance.MidPoint;

x1 = testP.X;





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT32_Defect_1449877_2__2_()
        {
            string code = @"
[Associative]

{

	def func:int(a:int,b:int)

	{

	return = b + a;

	}

	a = 3;

	b = -1;

	d = func(a,b);



} 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT32_Defect_1449877_2()
        {
            string code = @"
[Imperative]

{

	def func:int(a:int,b:int)

	{

	return = b + a;

	}

	a = 3;

	b = -1;

	d = func(a,b);



} 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT32_ForLoopSyntax02_Negative()
        {
            string code = @"
[Imperative]

{

	a = { 1,2,3,4 };

	

	x = 0;

	

	for  (i in a) 

	{

	{

		x = x + i;

	}

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT32_Function_With_Mismatching_Return_Type()
        {
            string code = @"
[Imperative]

{ 

	 def foo3 : int ( a : double )

	 {

	    return = 5.5;

	 }

	 

	dummyArg = 1.5;

	

	b2 = foo3 ( dummyArg );

	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT32_IfElseSyntax_negative()
        {
            string code = @"
[Imperative]

{

    if(1)

	{

		b = 1;

	}

	elseif  { c = 2 ;

	

		

} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT32_Pass_Single_3x3_List()
        {
            string code = @"
class Math

{

	a : int;

	

	constructor ValueCtor(_a : int)

	{	

		a = _a;

	}

	

	def Mul : int(num : int)

	{

		return = num * a;

	}

}



list1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

m = Math.ValueCtor(10);

list2 = m.Mul(list1);  // { { 10, 20, 30 }, { 40, 50, 60 }, { 70, 80, 90 } }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT32_Update_With_Range_Expr()
        {
            string code = @"
y = 1;

y1 = 0..y;

y = 2;

z1 = y1;                             



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT33_Class_Methods()
        {
            string code = @"
class Point

{

    X : double;

	Y : double;

	Z : double;

	

	constructor ByCoordinates( x : double, y : double, z : double )

	{

	    X = x;

		Y = y;

		Z = z;		

	}

	

	def addP1( x : int )

	{

	    X = x;

		return = X;

		

	}

	

	def addP2( x : int )

	{

	    W = x;

		return  = W;

		

	}

}





p1 = Point.ByCoordinates( 5.0, 0.0, 0.0 );



x1 = p1.X;

x2 = p1.x;

x3 = p1.addP1(1);

x4 = p1.addP2(1);

x5 = p1.W;

x6 = p1.X;









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT33_Defect_1450003__2_()
        {
            string code = @"
[Associative]

{

	def check:double( _a:double, _b:int )

	{

	_c = _a * _b;

	return = _c;

	} 



	_a_test = check(2.5,5);

	_b = 4.5;

	_c = true;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT33_Defect_1450003()
        {
            string code = @"
[Imperative]

{

	def check:double( _a:double, _b:int )

	{

	_c = _a * _b;

	return = _c;

	} 



	_a_test = check(2.5,5);

	_b = 4.5;

	_c = true;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT33_Defect_1466107()
        {
            string code = @"
class B

{

    b : int;	

}

class A extends B

{

    a : int;	

}

def foo ( x ) 

{

    return  = x + 1;

}



x1 =  { A.A(), A.A() };

a1 = A.A();

x2 =  { a1.a, a1.a };

y2 = foo ( x2[0] );

y1 = foo ( x1[1].b );

x1[1].b = 2;

a1.a = 2; 



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT33_Defect_1466107_2()
        {
            string code = @"
class B

{

    b : int;	

}

class A extends B

{

    a : int;	

}

def foo ( x ) 

{

    return  = x + 1;

}



x1 =  { A.A(), A.A() };

a1 = A.A();

x2 =  { a1.a, a1.a };

y2 = foo ( x2[0] );

y1 = foo ( x1[1].b );



def foo1 ( t1 : A )

{

    t1.b = 2;

	return = null;

}



def foo2 ( t1 : A )

{

    t1.a = 2;

	return = null;

}



dummy1 = foo1 ( x1[1] );

dummy2 = foo2 ( a1 );



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT33_ForLoopToReplaceReplicationGuides()
        {
            string code = @"
a = { 1, 2 };

b = { 3, 4 };

//c = a<1> + b <2>;



dummyArray = { { 0, 0 }, { 0, 0 } };

counter1 = 0;

counter2 = 0;



[Imperative]

{



	for ( i in a )

	{

		counter2 = 0;

		

		for ( j in b )

		{	    

			dummyArray[ counter1 ][ counter2 ] = i + j;

			

			counter2 = counter2 + 1;

		}

		counter1 = counter1 + 1;

	}

	

}



a1 = dummyArray[0][0];

a2 = dummyArray[0][1];

a3 = dummyArray[1][0];

a4 = dummyArray[1][1];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT33_Function_With_Mismatching_Return_Type()
        {
            string code = @"
class A

{

    a : int;

	constructor A1(a1 : int)

	{

	    a = a1;

	}

}



[Imperative]

{ 

	 def foo3 : int ( a : double )

	 {

	    temp = A.A1(1);

		return = temp;

	 }

	 

	dummyArg = 1.5;

	

	b2 = foo3 ( dummyArg );	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT33_IfElseSyntax_negative()
        {
            string code = @"
[Imperative]

{

    if(0)

	{

		b = 1;

	}

	elseif (0) { c = 2; }

	else { c = 3;}

	else {c = 4};

	

		

} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT33_Pass_Single_List()
        {
            string code = @"
class Math

{

	a : double;

	

	constructor ValueCtor(_a : double)

	{	

		a = _a;

	}

	

	def Mul : double(num : double)

	{

		return = num * a;

	}

}



list1 = { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0 };

m = Math.ValueCtor(10.0);

list2 = m.Mul(list1);  // { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT34_Class_Static_Methods()
        {
            string code = @"
class Point

{

    static X : double;

	Y : double;

	constructor ByCoordinates( x : double, y: double )

	{

	    X = x;

		Y = y;

			

	}

	

	static def add1( )

	{

	    X = X + 1;

		Y = Y + 1;

		return = X + Y;

		

	}

	

	def add2( )

	{

	    X = X + 1;

		Y = Y + 1;

		return = X + Y;		

	}

}





p1 = Point.ByCoordinates( 5.0, 0.0);



x1 = p1.X;

x2 = p1.Y;

x3 = p1.add1();

x4 = p1.add2();

x5 = 1;









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT34_Defect_1450727__2_()
        {
            string code = @"
[Associative]

{



	x = -5.5;

	y = -4.2;

 

	z = x + y;

 

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT34_Defect_1450727()
        {
            string code = @"
[Imperative]

{



	x = -5.5;

	y = -4.2;

 

	z = x + y;

 

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT34_Defect_1452966()
        {
            string code = @"
[Imperative]

{

	a = { 1, 2, 3, 4 };

	sum = 0;

	

	for(i in a )

	{

		for ( i in a )

		{

			sum = sum + i;

		}

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT34_Defect_DNL_1463327()
        {
            string code = @"
class A

{        

    Pt : double;        

    constructor A (pt : double)            

    {                        

        Pt = pt;            

    }

}



c = 1.0;

x = [Imperative]

{

	c = A.A( c );

	x = c.Pt;

	return = x;

}

// expected : c = A ( Pt = 1.0 ); x = 1.0

// received : System.NullReferenceException: Object reference not set to an instance of an object.

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT34_Defect_DNL_1463327_2()
        {
            string code = @"
class A

{        

    Pt : double[];        

    constructor A (pt : double[])            

    {                        

        Pt = pt;            

    }

}



c = 0.0..3.0;

y = c[0];

x = [Imperative]

{

	c = A.A( {c[0], c[0]} );

	x = c.Pt;

	return = x;

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT34_Defect_DNL_1463327_3()
        {
            string code = @"
class A

{        

    Pt : double;        

    constructor A (pt : double)            

    {                        

        Pt = pt;            

    }

}



t = 0.0..3.0;

c = A.A ( t );

c1 = Count ( c );

x = [Imperative]

{

	c = A.A( c[0].Pt );

	x = c.Pt;

	return = x;

}



t = 0.0..2.0;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT34_Defect_DNL_1463327_4()
        {
            string code = @"
class A

{        

    Pt : double;        

    constructor A (pt : double)            

    {                        

        Pt = pt;            

    }

}



t = 0.0..3.0;

c = A.A ( t );

c = A.A ( c[0].Pt );

c = A.A ( c.Pt );

x = c.Pt;

t = 0.0..1.0;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT34_Function_With_Mismatching_Return_Type()
        {
            string code = @"
[Associative]

{ 

	 def foo1 : double ( a : double )

	 {

	    return = true;

	 }

	 

	 dummyArg = 1.5;

	

	b1 = foo1 ( dummyArg );

	

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT34_IfElseSyntax_negative()
        {
            string code = @"
[Imperative]

{

    if(0)

	{

		b = 1;

	}

	elseif { c = 2; }

	else { c = 3;}

	else {c = 4};

	

		

} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT34_Pass_Single_List_2_Integers()
        {
            string code = @"
class Math

{

	a : int;

	

	constructor ValueCtor(_a : int)

	{	

		a = _a;

	}

	

	def Mul : int(num1 : int, num2 : int, num3 : int)

	{

		return = (num1 + num2 + num3) * a;

	}

}

list1 = { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40 };

m = Math.ValueCtor(5);

list2 = m.Mul(list1, 12, 17); // {300,305,310,315,320,325,330,335,340,345}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT35_Class_Method_Overloading()
        {
            string code = @"
class Point

{

    X : double;

	Y : double;

	constructor ByCoordinates( x : double, y: double )

	{

	    X = x;

		Y = y;

			

	}

	

	def add1( )

	{

	    X = X + 1;

		Y = Y + 1;

		return = X + Y;

		

	}

	

}



class Point2 extends Point

{

    a : double;

	b : double;

	constructor ByCoordinates( x : double, y: double )

	{

	    X = x;

		Y = y;

		a = X;

		b = Y;			

	}

	

	def add1( )

	{	    

		return = X + Y;		

	}

	

}





p1 = Point.ByCoordinates( 5.0, 10.0);

p2 = Point2.ByCoordinates( 15.0, 20.0);



a1 = p1.add1();

a2 = p2.add1();











";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT35_Defect_1450727_2__2_()
        {
            string code = @"
[Associative]

{

	def neg_float:double(x:double,y:double)

	{

	a = x;

	b = y;

	return = a + b;

	}



	z = neg_float(-2.3,-5.8);

 

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT35_Defect_1450727_2()
        {
            string code = @"
[Imperative]

{

	def neg_float:double(x:double,y:double)

	{

	a = x;

	b = y;

	return = a + b;

	}



	z = neg_float(-2.3,-5.8);

 

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT35_Defect_1452966_2()
        {
            string code = @"
[Imperative]

{

	a = { {1, 2, 3}, {4}, {5,6} };

	sum = 0;

	

	for(i in a )

	{

		for (  j in i )

		{

			sum = sum + j;

		}

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT35_Defect_DNL_1463700()
        {
            string code = @"
class A

{        

    x = {1,2,3};        

    def foo()        

    {                

        x[0] = 100;        

    }

}



a = A.A();

t = a.x;

x = a.foo();

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT35_Defect_DNL_1463700_2()
        {
            string code = @"
class A

{        

    x = {1,2,3};        

    count = 3;

    def foo()        

    {                

       count = 0;

       [Imperative]

       {

           for ( i in x )

	   {

	       x[count] = i*2;

	       count = count + 1;

	   }

        } 

        return = null;        

    }

}



a = A.A();

t1 = a.x;

t2 = a.count;

dummy = a.foo();



t3 = t1;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT35_Function_With_Mismatching_Return_Type()
        {
            string code = @"
[Associative]

{ 

	 def foo2 : double ( a : double )

	 {

	    return = 5;

	 }

	 

	dummyArg = 1.5;

	

	b2 = foo2 ( dummyArg );

	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT35_IfElseWithEmptyBody()
        {
            string code = @"
[Imperative]

{

    c = 0;

    if(0)

	{

		

	}

	elseif (1) { c = 2; }

	else { }

	

	

		

} 

 

 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT35_Pass_1_list_of_class_type_and_1_variable_of_class_type()
        {
            string code = @"
class Point_3D
{
	x : int;
	y : int;
	z : int;

	constructor ValueCtor(_x : int, _y : int, _z : int)
	{
		x = _x;
		y = _y;
		z = _z;
	}

	def GetCoor(type : int)
	{
		return = type == 1 ? x : type == 2 ? y : z;
	}
}

def GetMidPoint : Point_3D(p1 : Point_3D, p2 : Point_3D)
{
	return = Point_3D.ValueCtor(	
									(p1.GetCoor(1) + p2.GetCoor(1)), 
									(p1.GetCoor(2) + p2.GetCoor(2)), 
									(p1.GetCoor(3) + p2.GetCoor(3)) 
								);
}

list1 = { 
			Point_3D.ValueCtor(1, 2, 3),
			Point_3D.ValueCtor(4, 5, 6),
			Point_3D.ValueCtor(7, 8, 9)
		};

var2 = Point_3D.ValueCtor(10, 10, 10);

list3 = GetMidPoint(list1, var2);
list3_0_x = list3[0].GetCoor(1); // 11
list3_1_y = list3[1].GetCoor(2); // 15
list3_2_z = list3[2].GetCoor(3); // 19
			
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT36_Class_Method_Calling_Constructor()
        {
            string code = @"
class Point

{

    X : double;

	Y : double;

	constructor ByCoordinates( x : double, y: double )

	{

	    X = x;

		Y = y;

			

	}

	

	def create( )

	{

	    X = X + 1;

		Y = Y + 1;

		return = Point.ByCoordinates( X, Y );

		

	}

	

}



class Point2 extends Point

{

    a : double;

	b : double;

	constructor ByCoordinates( x : double, y: double )

	{

	    X = x;

		Y = y;

		a = X;

		b = Y;			

	}

	

	def create( )

	{

	    X = X + X;

		b = b + b;

		return = Point2.ByCoordinates( X, b );

		

	}

	

}





p1 = Point.ByCoordinates( 5.0, 10.0);

p2 = Point2.ByCoordinates( 15.0, 20.0);



a1 = p1.create();

a2 = a1.X;

a3 = a1.Y;



b1 = p2.create();

b2 = b1.X;

b3 = b1.Y;

b4 = b1.a;

b5 = b1.b;













";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT36_Defect_1450555__2_()
        {
            string code = @"
[Associative]

{

	a = true;

	b = 2;

	c = 2;

 

	if( a )

	b = false;

 

	if( b==0 )

	c = 1;

 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT36_Defect_1450555()
        {
            string code = @"
[Imperative]

{

	a = true;

	b = 2;

	c = 2;

 

	if( a )

	b = false;

 

	if( b==0 )

	c = 1;

 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT36_Defect_1452966_3()
        {
            string code = @"
[Associative]

{

	a = { {1, 2, 3}, {4}, {5,6} };

	

	def forloop :int ( a: int[]..[] )

	{

		sum = 0;

		sum = [Imperative]

		{

			for(i in a )

			{

				for (  j in i )

				{

					sum = sum + j;

				}

			}

			return = sum;

		}

		return = sum;

	}

	

	b =forloop(a);

	

	

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT36_Function_With_Mismatching_Return_Type()
        {
            string code = @"
[Associative]

{ 

	 def foo3 : int ( a : double )

	 {

	    return = 5.5;

	 }

	 

	dummyArg = 1.5;

	

	b2 = foo3 ( dummyArg );

	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT36_IfElseInsideFunctionScope()
        {
            string code = @"
[Imperative]

{ 

 def crushcode:int (a:int, b:int)

 {

  if(a<=b)

      return = a+b;  

  else 

     return = 0;           

 }                                



 temp=crushcode(2,3);  

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT36_Modifier_Block_Multiple_Updates()
        {
            string code = @"
a = 1;

b = a + 1;

a = { 2 => a1;

      a1 + 1 => a2;

      a2 * 2 ;

    }

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT36_Modifier_Block_Multiple_Updates_2()
        {
            string code = @"
a = 1;

b = a + 1;

a = { 2 => a1;

      a1 + 1 => a2;

      a2 * 2 ;

    }

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT36_Pass_1_single_list_of_class_type()
        {
            string code = @"
class Integer

{

	value : int;

	

	constructor ValueCtor(_value : int)

	{

		value = _value;

	}

}



def Square : int(i : Integer)

{

	return = i.value * i.value;

}



list = 	{

			Integer.ValueCtor(2),

			Integer.ValueCtor(3),

			Integer.ValueCtor(4),

			Integer.ValueCtor(5)

		};

		

list2 = Square(list); // { 4, 9, 16, 25 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT37_Class_Method_Using_This()
        {
            string code = @"
class Point

{

    X : double;

	Y : double;

	constructor ByCoordinates( x : double, y: double )

	{

	    X = x;

		Y = y;

			

	}

	

	def add(this : Point, d : double )

	{

	  	this.X = this.X + d;

		this.Y = this.Y + d;

		return = this.X + this.Y;

		

	}

	

}





p1 = Point.ByCoordinates( 5.0, 10.0);



a1 = p1.add(4.0);

a2 = p1.X;

a3 = p1.Y;













";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT37_Defect_1450920()
        {
            string code = @"
[Imperative]

{

    a = 0;

    b = 0;

    c = 0;

    d = 0;



    if(true)

	{

		a = 1;

	}

	

	if(false)

	{

		b = 1;

	}

	elseif(true)

	{

		b = 2;

	}

	

	if(false)

	{

		c = 1;

	}

	elseif(false)

	{

		c = 2;

	}

	else

	{

		c =  3;

	}		

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT37_Defect_1454517()
        {
            string code = @"
	a = { 4,5 };

	

	b =[Imperative]

	{

		x = 0;

		for( y in a )

		{

			x = x + y;

		}

		

		return = x;

	}

	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT37_Function_With_Mismatching_Return_Type()
        {
            string code = @"
class A

{

    a : int;

	constructor A1(a1 : int)

	{

	    a = a1;

	}

}



[Associative]

{ 

	 def foo3 : int ( a : double )

	 {

	    temp = A.A1(1);

		return = temp;

	 }

	 

	dummyArg = 1.5;

	

	b2 = foo3 ( dummyArg );	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT37_Modify_Collections_Referencing_Each_Other()
        {
            string code = @"
a = {1,2,3};

b = a;

c1 = a[0];

b[0] = 10;

c2 = a[0];

testArray = a;

testArrayMember1 = c1;

testArrayMember2 = c2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT37_Pass_2_lists_of_class_type_different_length()
        {
            string code = @"
class Point_3D

{

	x : int;

	y : int;

	z : int;

	

	constructor ValueCtor(_x : int, _y : int, _z : int)

	{

		x = _x;

		y = _y;

		z = _z;

	}

	

	def GetCoor(type : int)

	{

		return = type == 1 ? x : type == 2 ? y : z;

	}

}



def GetMidPoint : Point_3D(p1 : Point_3D, p2 : Point_3D)

{

	return = Point_3D.ValueCtor(	

									(p1.GetCoor(1) + p2.GetCoor(1)), 

									(p1.GetCoor(2) + p2.GetCoor(2)), 

									(p1.GetCoor(3) + p2.GetCoor(3)) 

								);

}



list1 = { 

			Point_3D.ValueCtor(1, 2, 3),

			Point_3D.ValueCtor(4, 5, 6),

			Point_3D.ValueCtor(7, 8, 9)

		};



list2 = {

			Point_3D.ValueCtor(10, 10, 10),

			Point_3D.ValueCtor(20, 20, 20)

		};



list3 = GetMidPoint(list1, list2);



list3_0_x = list3[0].GetCoor(1); // 11

list3_1_y = list3[1].GetCoor(2); // 25

			
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT37_TestOperationOnNullAndBool__2_()
        {
            string code = @"
[Associative]

{

	a = true;

	b = a + 1;

	c = null + 2;



 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT37_TestOperationOnNullAndBool()
        {
            string code = @"
[Imperative]

{

	a = true;

	b = a + 1;

	c = null + 2;



 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT38_Class_Method_Using_This()
        {
            string code = @"
class Point

{

    X : double;

	Y : double;

	constructor ByCoordinates( x : double, y: double )

	{

	    X = x;

		Y = y;

			

	}

	

	def add( d : double )

	{

	  	this.X = this.X + d;

		this.Y = this.Y + d;

		return = this.X + this.Y;

		

	}

	

}





p1 = Point.ByCoordinates( 5.0, 10.0);



a1 = p1.add(4.0);

a2 = p1.X;

a3 = p1.Y;













";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT38_Defect_1449928__2_()
        {
            string code = @"
[Associative]

{

 a = 2.3;

 b = -6.9;



 c = a / b;

} 



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT38_Defect_1449928()
        {
            string code = @"
[Imperative]

{

 a = 2.3;

 b = -6.9;



 c = a / b;

} 



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT38_Defect_1450939()
        {
            string code = @"
[Imperative]

{

   	def test:int( a:int, b:int )

	{

		c = 0;

	    if( !(a == b) ) 

		{

			c = 0;

		}

		elseif ( !(a==b) )

		{

			c = 1;

		}

		else

		{

			c = 2;

		}

		

		return = c;



	}

	

	

	a = 1;

	b = 1;

    c = 0;

    d = 0;

	if( !(a == b) ) 

	{

		d = 0;

	}

	elseif ( !(a==b) )

	{

		d = 1;

	}

	else

	{

		d = 2;

	}

	

	

	if( ! (test ( a, b ) == 2 ) )

	{

		c = 3;

	}

	else

	{

		c = 2;

	}

		

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT38_Defect_1454517_2()
        {
            string code = @"
	a = { 4,5 };

	x = 0;

	

	[Imperative]

	{

		x = 0;

		for( y in a )

		{

			x = x + y;

		}

	}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT38_Defect_1454517_3()
        {
            string code = @"
def foo ( a : int [] )

{

    x = 0;

	x = [Imperative]

	{	

		for( y in a )

		{

			x = x + y;

		}

		return =x;

	}

	return = x;

}



a = { 4,5 };	

[Imperative]

{

	b = foo(a);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT38_Defect_1467059_Modifier_Stack_With_Undefined_Variable()
        {
            string code = @"
a = {

          1 => a1;

          a1 + b1 => a2;    

          +2;                

    };

b1 = 2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT38_Defect_1467059_Modifier_Stack_With_Undefined_Variable_2()
        {
            string code = @"
def foo ( x )

{

    return = x;

}

a = {

          1 => a1;

          a1 + foo(b1) => a2;    

          +2;                

    };

b1 = 2;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT38_Function_With_Mismatching_Return_Type()
        {
            string code = @"
[Associative]

{ 

	 def foo3 : int[] ( a : double )

	 {

	    return = a;

	 }

	 

	dummyArg = 1.5;

	

	b2 = foo3 ( dummyArg );	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT38_Pass_2_lists_of_class_type_different_length_and_1_integer()
        {
            string code = @"
class Integer

{

	value : int;

	constructor ValueCtor(_value : int)

	{

		value =  _value;

	}

}



def Sum : int(i1 : Integer, i2 : Integer, i3 : int)

{

	return = i1.value + i2.value + i3;

}



list1 = {

			Integer.ValueCtor(2),

			Integer.ValueCtor(5),

			Integer.ValueCtor(8)

		};

list2 = {

			Integer.ValueCtor(3),

			Integer.ValueCtor(6),

			Integer.ValueCtor(9),

			Integer.ValueCtor(12)

		};



list3 = Sum(list1, list2, 10); // { 15, 21, 27 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT39_Class_Method_Returning_Collection()
        {
            string code = @"
class Point

{

    X : double;

	Y : double;

	constructor ByCoordinates( x : double, y: double )

	{

	    X = x;

		Y = y;

			

	}

	

	def add( d : double )

	{

	  	return = { X+d, Y+d };

		

	}

	

}





p1 = Point.ByCoordinates( 5.0, 10.0);



a1 = p1.add(4.0);

a2 = a1[0];

a3 = a1[1];













";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT39_Defect_1449704__2_()
        {
            string code = @"
[Associative]

{

 a = b;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT39_Defect_1449704()
        {
            string code = @"
[Imperative]

{

 a = b;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT39_Defect_1450920_2()
        {
            string code = @"
[Imperative]

{

a=0;

b=0;

c=0;

d=0;

    if(0.4)

	{

		d = 4;

	}

	

	if(1.4)

	{

		a = 1;

	}

	

	if(0)

	{

		b = 1;

	}

	elseif(-1)

	{

		b = 2;

	}

	

	if(0)

	{

		c = 1;

	}

	elseif(0)

	{

		c = 2;

	}

	else

	{

		c =  3;

	}		

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT39_Defect_1452951()
        {
            string code = @"
[Associative]

{

	a = { 4,5 };

   

	[Imperative]

	{

	       //a = { 4,5 }; // works fine

		x = 0;

		for( y in a )

		{

			x = x + y;

		}

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT39_Defect_1452951_1()
        {
            string code = @"
[Imperative]

{

	def foo ( a : int[])

	{

	    a[1] = 4;

		return = a;

	}

	a = { 4,5 };

   

	[Associative]

	{

	   x = foo(a);

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT39_Defect_1452951_2()
        {
            string code = @"
class A

{

    a1 : var[];

	constructor A( x : int[])

	{

	    a1 = x;

		[Imperative]

		{

		    if(a1[0] < 10 ) 

			{

			    a1[0] = 10;

			}

		}

	}

	

	def foo :int[] ( )

	{

	    count = 0;

		[Imperative]

		{

			for ( i in a1 )

			{

				a1[count]  = i + 1;

				count = count + 1;

			}

		}

		return = a1;

	}

	

}



a = { 4, 4 };

[Imperative]

{

	a2 = A.A(a);

	a3 = a2.foo();

	a4 = a2.a1;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT39_Defect_1452951_3()
        {
            string code = @"
class A

{

    a1 : var[];

	constructor A( x : int[])

	{

	    a1 = x;

		[Imperative]

		{

		    if(a1[0] < 10 ) 

			{

			    a1[0] = 10;

			}

		}

	}

	

	def foo :int ( )

	{

	    count = 0;

		[Imperative]

		{

			for ( i in a1 )

			{

				count = count + 1;

			}

		}

		return = count;

	}

	

}



a = { 4, 4 };

[Imperative]

{

	a2 = A.A(a);

	a3 = a2.foo();

	a4 = a2.a1;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT39_Defect_1465319_Modifier_Stack_Update_Issue()
        {
            string code = @"
a = {

1 => a1; 

a1 + b1 + x=> a2; 

};

b1 = 2;



y1 = 2;

x = {

1 => x1;

x1 + y1 => x2; 

};

y1 = 5;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT39_Function_With_Mismatching_Return_Type()
        {
            string code = @"
[Associative]

{ 

	 def foo3 : int ( a : double )

	 {

	    return = {1, 2};

	 }

	 

	dummyArg = 1.5;

	

	b2 = foo3 ( dummyArg );	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT39_Pass_2_lists_of_class_type_same_length_and_1_variable_of_class_type()
        {
            string code = @"
class Integer

{

	value : int;

	constructor ValueCtor(_value : int)

	{

		value =  _value;

	}

}



def Sum : int(i1 : Integer, i2 : Integer, i3 : Integer)

{

	return = i1.value + i2.value + i3.value;

}



list1 = {

			Integer.ValueCtor(2),

			Integer.ValueCtor(5),

			Integer.ValueCtor(8)

		};

list2 = {

			Integer.ValueCtor(3),

			Integer.ValueCtor(6),

			Integer.ValueCtor(9)

		};



list3 = Sum(list1, list2, Integer.ValueCtor(10)); // { 15, 21, 27 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Class_Property_Initialization_With_Another_Class()
        {
            string code = @"
class Point

{

    X : double;

		

	public constructor ByCoordinates( xValue : double  )

    {

		X = xValue; 			

	}

}

class MyPoint 

{

	inner  : Point = Point.ByCoordinates(3);	

}



p1 = MyPoint.MyPoint();

t1 = p1.inner.X;

	







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Create_3_Dim_Collection_Using_For_Loop()
        {
            string code = @"
x = { { { 0, 0} , { 0, 0} }, { { 0, 0 }, { 0, 0} }};



a = { 0, 1 };

b = { 2, 3};

c = { 4, 5 };



y = [Imperative]

{

	c1 = 0;

	for ( i in a)

	{

	    c2 = 0;

		for ( j in b )

		{

		    c3 = 0;

			for ( k in c )

			{

			    x[c1][c2][c3] = i + j + k;

				c3 = c3 + 1;

			}

			c2 = c2+ 1;

		}

		c1 = c1 + 1;

	}

	

	return = x;

			

}

p1 = y[0][0][0];

p2 = y[0][0][1];

p3 = y[0][1][0];

p4 = y[0][1][1];

p5 = y[1][0][0];

p6 = y[1][0][1];

p7 = y[1][1][0];

p8 = y[1][1][1];





p9 = x [1][1][1];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Defect_1450552__2_()
        {
            string code = @"
[Associative]

{

 a = b;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Defect_1450552()
        {
            string code = @"
[Imperative]

{

 a = b;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Defect_1450843()
        {
            string code = @"
[Imperative]

{

 a = null;

 b1 = 0;

 b2 = 0;

 b3 = 0;



 if(a!=1); 

 else 

   b1 = 2; 

   

 if(a==1); 

 else 

   b2 = 2;

   

 if(a==1); 

 elseif(a ==3);

 else b3 = 2;



}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Defect_1467057_Modifier_Stack_Cross_Update_Issue()
        {
            string code = @"
a = {

          1 => a1;

          b1 + a1 => a2;                    

    };



b = {

          2 => b1;                    

    };
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Defect_1467057_Modifier_Stack_Cross_Update_Issue_2()
        {
            string code = @"
a = {

          1 => a1;

          b1 + a1 => a2;                    

    };



b = {

          a1 + 2 => b1;                    

    };
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Defect_1467057_Modifier_Stack_Cross_Update_Issue_3()
        {
            string code = @"
a = {

          1 => a1;

          b1 + a1 => a2;                    

    };



b = {

          a2 + 2 => b1;                    

    };
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Defect_1467057_Modifier_Stack_Update_Issue()
        {
            string code = @"
a = {

          1 => a1;

          b1 + a1 => a2;                    

    };



b = {

          2 => b1;                    

    };
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Defect_1467088_Modifier_Stack_Cross_Update_Issue()
        {
            string code = @"
a = {

          1 => a1;

          b1 + a1 => a2;                    

    };



b = {

          a1 + 2 => b1;                    

    };



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Defect_1467088_Modifier_Stack_Cross_Update_Issue_2()
        {
            string code = @"




a = {

          1 => a1;

          b1 + a1 => a2;                    

    };



[Imperative]

{



	b = {

		  a1 + 2 => b1;                    

	    };

	

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Defect_1467088_Modifier_Stack_Cross_Update_Issue_3()
        {
            string code = @"




a = {

          1 => a1;

          b1 + a1 => a2;                    

    };



[Associative]

{



	b = {

		  a1 + 2 => b1;                    

	    };

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Function_With_Mismatching_Return_Type()
        {
            string code = @"
[Associative]

{ 

	 def foo3 : int[][] ( a : double )

	 {

	    return = { {2.5}, {3.5}};

	 }

	 

	dummyArg = 1.5;

	

	b2 = foo3 ( dummyArg );	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Index_DynamicArray_1464942_5()
        {
            string code = @"
class test

{



def foo(y:int)

{    

	return = y;

}

}





x = { };

y=test.test();

a=y.foo({0});

x[a]=3;

//x[y.foo({0})] = 3;

z = x;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Index_DynamicArray_byarray_1464942_6()
        {
            string code = @"
class test

{



def foo(y:int[])

{    

	return = y;

}

}





x = { };

y=test.test();

a=y.foo({0,1});

x[y.foo({0,1})] = 3;

z = x;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Index_byFunction_argument_1467064_4()
        {
            string code = @"
class test

{



def foo(y:int)

{    

	return = y;

}

}

[Imperative]

{



x = { 1, 2 };

y=test.test();

x[y.foo(1)] = 3;

y = x;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Index_byFunction_class_imperative_1467064_3()
        {
            string code = @"
class test

{

def foo()

{    

	return = 2;

}

}

[Imperative]

{



x = { 1, 2 };

y=test.test();

x[y.foo()] = 3;

y = x;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Index_usingFunction_1467064()
        {
            string code = @"
def foo()

{    

return = 0;

}

x = { 1, 2 };

x[foo()] = 3;

y = x;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Index_usingFunction_class_1467064_2()
        {
            string code = @"
class test

{

def foo()

{    

	return = 0;

}

}

x = { 1, 2 };

y=test.test();

x[y.foo()] = 3;

a = x;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT40_Pass_2_List_of_class_type_Same_Length()
        {
            string code = @"
class Point_3D

{

	x : var;

	y : var;

	z : var;

	

	constructor ValueCtor(_x : int, _y : int, _z : int)

	{

		x = _x;

		y = _y;

		z = _z;

	}

	

	def GetCoor(type : int)

	{

		return = type == 1 ? x : type == 2 ? y : z;

	}

}



def GetMidPoint : Point_3D(p1 : Point_3D, p2 : Point_3D)

{

	return = Point_3D.ValueCtor(	

									(p1.GetCoor(1) + p2.GetCoor(1)), 

									(p1.GetCoor(2) + p2.GetCoor(2)), 

									(p1.GetCoor(3) + p2.GetCoor(3)) 

								);

}



list1 = { 

			Point_3D.ValueCtor(1, 2, 3),

			Point_3D.ValueCtor(4, 5, 6),

			Point_3D.ValueCtor(7, 8, 9)

		};



list2 = { 

			Point_3D.ValueCtor(10, 11, 12),

			Point_3D.ValueCtor(13, 14, 15),

			Point_3D.ValueCtor(16, 17, 18)

		};



list3 = GetMidPoint(list1, list2);



list3_0_x = list3[0].GetCoor(1); // 11

list3_1_y = list3[1].GetCoor(2); // 19

list3_2_z = list3[2].GetCoor(3); // 27

			
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT41_Accessing_Non_Existent_Properties_From_Array_Elements()
        {
            string code = @"
class A 

{

    x : var;

    constructor A ( y : var )

    {

        x = y;

    }

}

class B 

{

    x2 : var;

    constructor B ( y : var )

    {

        x2 = y;

    }

}



c = { A.A(0), B.B(1) };

d = c[1].x; 



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT41_Accessing_Non_Existent_Property_FromArray_1467083()
        {
            string code = @"
class A

{

x : var;

constructor A ( y : var )

{

x = y;

}

}

class B

{

x2 : var;

constructor B ( y : var )

{

x2 = y;

}

}



c = { A.A(0), B.B(1) };



c0 = c[0].x;//0

d = c[1].x;//null



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT41_Accessing_Non_Existent_Property_FromArray_1467083_2()
        {
            string code = @"
class A

{

x : var;

constructor A ( y : var )

{

x = y;

}

}

class B

{

x2 : var;

constructor B ( y : var )

{

x2 = y;

}

}



c = { A.A(0), B.B(1),1 };



e = c[2].x;

e1 = c[2].x2;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT41_Accessing_Non_Existent_Property_FromArray_1467083_3()
        {
            string code = @"
class A

{

x : var;

constructor A ( y : var )

{

x = y;

}

}

class B

{

x2 : var;

constructor B ( y : var )

{

x2 = y;

}

}



c = null;

d={A.A(0),null};

e = c[0].x; // null

e1 = c[1].x2;//null

f = d[0].x;//0

f1 = d[1].x2;//null



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT41_Create_3_Dim_Collection_Using_For_Loop_In_Func_Call()
        {
            string code = @"


def foo :int[]..[]( a : int[], b:int[], c :int[])

{

	y = [Imperative]

	{

		x = { { { 0, 0} , { 0, 0} }, { { 0, 0 }, { 0, 0} }};

		c1 = 0;

		for ( i in a)

		{

			c2 = 0;

			for ( j in b )

			{

				c3 = 0;

				for ( k in c )

				{

					x[c1][c2][c3] = i + j + k;

					c3 = c3 + 1;

				}

				c2 = c2+ 1;

			}

			c1 = c1 + 1;

		}		

		return = x;				

	}

	return = y;

}





a = { 0, 1 };

b = { 2, 3};

c = { 4, 5 };



y = foo ( a, b, c );



p1 = y[0][0][0];

p2 = y[0][0][1];

p3 = y[0][1][0];

p4 = y[0][1][1];

p5 = y[1][0][0];

p6 = y[1][0][1];

p7 = y[1][1][0];

p8 = y[1][1][1];



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT41_Defect_1450778()
        {
            string code = @"
[Imperative]

{

 a=1;

 b=2;

 c=2;

 d = 2;



 

 if(a==1)

 {

    c = 1;

 }

 

 if(b==2)  

 {

     d = 1;

 }

 

 }





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT41_Defect_1467072_Class_Update()
        {
            string code = @"
class A 

{

    a : int;

    constructor A ( a1:int)

    {

        a = b + 1;

        b = a1;

    }

}



def foo ( a1 : int)

{

    a = b + 1;

    b = a1;

    return  = a ;

}



ga = gb + 1;

gb = gf;

gc = foo (ga);

gd = A.A(gc);

e1 = gd.a;

gf = 2;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT41_Defect_1467072_Class_Update_2()
        {
            string code = @"
class A 

{

    a : int;

    constructor A ( a1:int)

    {

        b1 = foo(a1) + 1;

        a = b1+1;

	b1 = foo(a1);

    }

}



def foo ( a1 : int)

{

    a = b + 1;

    b = a1;

    return  = a ;

}



x = A.A(2);

y = x.a;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT41_Function_With_Mismatching_Return_Type()
        {
            string code = @"
[Associative]

{ 

	 def foo3 : int[][] ( a : double )

	 {

	    return = { {2.5}, 3};

	 }

	 

	dummyArg = 1.5;

	

	b2 = foo3 ( dummyArg );	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT41_Pass_3x3_List_And_2x4_List()
        {
            string code = @"
def foo : int(a : int, b : int)

{

	return = a * b;

}



list1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

list2 = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };

list3 = foo(list1, list2); // { { 1, 4, 9 }, { 20, 30, 42 } }

x = list3[0];

y = list3[1];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT41_Test_Static_Properties()
        {
            string code = @"
class A

{

    static x:int;

}



a = A.A();

a.x = 3;

A.x = 3;

t1 = a.x;

t2 = A.x;























";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT41_Test_Static_Properties_2()
        {
            string code = @"
class A

{

    static x:int = 3;

	

}



a = A.A();



b = [Imperative]

{

	a.x = 4;

	A.x = 4;

	t1 = a.x;

	t2 = A.x;

	return = { t1, t2 };

}























";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT41__Defect_1452423__2_()
        {
            string code = @"
[Associative]

{

	b = true;

	c = 4.5;

	d = c * b;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT41__Defect_1452423()
        {
            string code = @"
[Imperative]

{

	b = true;

	c = 4.5;

	d = c * b;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT42_Create_3_Dim_Collection_Using_For_Loop_In_Class_Constructor()
        {
            string code = @"
class A

{

    a : var[];

	b : var[];

	c : var[];

	y : var[];

	

	constructor A( a1:int[], a2:int[], a3:int[])

	{

	    a = a1;

		b = a2;

		c = a3;

		y = [Imperative]

		{

			x = { { { 0, 0} , { 0, 0} }, { { 0, 0 }, { 0, 0} }};

			c1 = 0;

			for ( i in a)

			{

				c2 = 0;

				for ( j in b )

				{

					c3 = 0;

					for ( k in c )

					{

						x[c1][c2][c3] = i + j + k;

						c3 = c3 + 1;

					}

					c2 = c2+ 1;

				}

				c1 = c1 + 1;

			}		

			return = x;				

		}		

	}	

}





a = { 0, 1 };

b = { 2, 3};

c = { 4, 5 };

x = A.A( a, b , c);

y = x.y;



p1 = y[0][0][0];

p2 = y[0][0][1];

p3 = y[0][1][0];

p4 = y[0][1][1];

p5 = y[1][0][0];

p6 = y[1][0][1];

p7 = y[1][1][0];

p8 = y[1][1][1];



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT42_Defect_1449707()
        {
            string code = @"
[Imperative]

{

 a = 1;

 b = 1;

 c = 1;

 if( a < 1 )

	c = 6;

 

 else if( b >= 2 )

	c = 5;

 

 else

	c = 4;

} 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT42_Defect_1461717()
        {
            string code = @"
class A

{

    a : var;

	constructor A ()

	{

	    a = 1;

	}

}

class B extends A

{

    b : var;

	constructor B ()

	{

	    b = 1;

	}

}



A = B.B();





















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT42_Defect_1466071_Cross_Update()
        {
            string code = @"
class A

{

a : int; 

}



a1 = A.A();

x = a1.a;

c = [Imperative]

{

a1.a = 1;

return = a1.a;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT42_Defect_1466071_Cross_Update_2()
        {
            string code = @"
i = 5;

totalLength = 6;

[Associative]

{



	x = totalLength > i ? 1 : 0;

	

	[Imperative]

	{

		for (j in 0..3)

		{

			i = i + 1;

		}	

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT42_Defect_1466071_Cross_Update_3()
        {
            string code = @"
y = 1;

a = 2;

x = a > y ? 1 : 0;

y = [Imperative]

{

                while (y < 2) // create a simple outer loop

                {

                    y = y + 1;                              

                }

		return = y;

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT42_Function_With_Mismatching_Return_Type()
        {
            string code = @"
[Associative]

{ 

	 def foo3 : bool[]..[] ( a : double )

	 {

	    return = { {2}, 3};

	 }

	 

	dummyArg = 1.5;

	

	b2 = foo3 ( dummyArg );	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT42_Pass_3_List_Different_Length()
        {
            string code = @"
def foo : int(a : int, b : int, c : int)

{

	return = a * b - c;

}

list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

list2 = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3 };

list3 = {1, 4, 7, 2, 5, 8, 3 };

list4 = foo(list1, list2, list3); // { 9, 14, 17, 26, 25, 22, 25 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT42__Defect_1452423_2__2_()
        {
            string code = @"
[Associative]

{

	a = { -2,3,4.5,true };

	x = 1;

	for ( y in a )

	{

		x = x *y;       //incorrect result

    }

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT42__Defect_1452423_2()
        {
            string code = @"
[Imperative]

{

	a = { -2,3,4.5,true };

	x = 1;

	for ( y in a )

	{

		x = x *y;       //incorrect result

    }

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT43_Create_3_Dim_Collection_Using_For_Loop_In_Class_Method()
        {
            string code = @"
class A
{
    a : var[];
	b : var[];
	c : var[];	

	constructor A( a1:int[], a2:int[], a3:int[])
	{
	    a = a1;
		b = a2;
		c = a3;
	}	

	def foo :int[]..[]( )
	{
		y = [Imperative]
		{
			x = { { { 0, 0} , { 0, 0} }, { { 0, 0 }, { 0, 0} }};
			c1 = 0;

			for ( i in a)
			{
				c2 = 0;
				for ( j in b )
				{
					c3 = 0;
					for ( k in c )
					{
						x[c1][c2][c3] = i + j + k;
						c3 = c3 + 1;
					}
					c2 = c2+ 1;
				}
				c1 = c1 + 1;
			}		
			return = x;				
		}
		return = y;
	}
}

a = { 0, 1 };
b = { 2, 3};
c = { 4, 5 };
x = A.A( a, b , c);
y = x.foo ();

p1 = y[0][0][0];
p2 = y[0][0][1];
p3 = y[0][1][0];
p4 = y[0][1][1];
p5 = y[1][0][0];
p6 = y[1][0][1];
p7 = y[1][1][0];
p8 = y[1][1][1];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT43_Create_CollectioninForLoop_1457172()
        {
            string code = @"
class A

{

a : var;

b : var;





constructor A( a1:int[], a2:int[])

{

a = a1;

b = a2;



}



def foo :int[]..[]( a : int[], b:int[])

{

y = [Imperative]

{

x = { { 0,0,0 }, {0,0,0} , {0,0,0} };

c1 = 0;

for ( i in a)

{

c2 = 0;

for ( j in b )

{

x[c1][c2] = i + j ;

c2 = c2+ 1;

}

c1 = c1 + 1;

}

return = x;

}

return = y;

}

}





a = { 0, 1, 2 };

b = { 3, 4, 5 };



x = A.A( a, b);

y = x.foo ();



p1 = y[0][0];

p2 = y[0][0];

p3 = y[0][2];

p4 = y[1][0];

p5 = y[1][1];

p6 = y[1][2];

p7 = y[2][0];

p8 = y[2][1];

p8 = y[2][2];

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT43_Create_CollectioninForLoop_1457172_2()
        {
            string code = @"
class A

{

a : var;

b : var;

c : var;



constructor A( a1:int[], a2:int[], a3:int[])

{

a = a1;

b = a2;

c = a3;

}



def foo :int[]..[]( a : int[], b:int[], c :int[])

{

y = [Imperative]

{

x = { { { 0, 0} , { 0, 0} }, { { 0, 0 }, { 0, 0} }};

c1 = 0;

for ( i in a)

{

c2 = 0;

for ( j in b )

{

c3 = 0;

for ( k in c )

{

x[c1][c2][c3] = i + j + k;

c3 = c3 + 1;

}

c2 = c2+ 1;

}

c1 = c1 + 1;

}

return = x;

}

return = y;

}

}





a = { 0, 1 };

b = { 2, 3};

c = { 4, 5 };

x = A.A( a, b , c);

y = x.foo (); // y expected : y={{{6,7},{7,8}},{{7,8},{8,9}}}



p1 = y[0][0][0]; //6

p2 = y[0][0][1];//7

p3 = y[0][1][0];//7

p4 = y[0][1][1];//8

p5 = y[1][0][0];//7

p6 = y[1][0][1];//8

p5 = y[1][1][0];//8

p6 = y[1][1][1];//9



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT43_Defect_1450706()
        {
            string code = @"
[Imperative]

{

 a1 = 7.3;

 a2 = -6.5 ;

 

 temp1 = 10;

 temp2 = 10;

 

 if( a1 <= 7.5 )

	temp1 = temp1 + 2;

 

 if( a2 >= -9.5 )

	temp2 = temp2 + 2;



 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT43_Defect_1461479()
        {
            string code = @"
class A

{

    static x:int=1;	

}



x2 = A.x;



















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT43_Defect_1461479_2()
        {
            string code = @"
class A

{ 

	static x1 : int;

	constructor A () 

	{	

		x1 = 5;

	}

}



a = A.A();

t1 = a.x1;























";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT43_Defect_1461479_3()
        {
            string code = @"
class A

{

    static x:int=1;	

	def foo1 ()

	{

	    x = 6;

		return = x;

	}

}



class B extends A

{

    static y:int=1;

    constructor B ( )

    {

	    y = 4;

    } 

    def foo2 ()

	{

	    x = 7;

		y = 8;

		return = { x, y } ;

	}	

}



x2 = A.x;

x3 = B.B();

t1 = x3.y;

t2 = x3.x;

x3.y = 2;

x3.x = 3;

t3 = x3.y;

t4 = x3.x;

t5 = x3.foo1();

t6 = x3.foo2();























";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT43_Defect_1461479_4()
        {
            string code = @"
class A

{

    static x:int=1;

    def foo ()

    {

	    x = 4;

		return = x;

    }	

	

}



def foo2( a : int)

{

    A.x = 3;

	x = A.x + a;

	return = x;

}



b = foo2( 1 ) ;

a = A.A();

c = a.x;

d = a.foo();





















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT43_Defect_1463498()
        {
            string code = @"
[Associative]

{

def foo : int ( a : int, b : int )

{

	a = a + b;

	b = 2 * b;

	return = a + b;

}



a = 1;

b = 2;

c = foo (a, b ); // expected 9, received -3

d = a + b;



}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT43_Function_With_Matching_Return_Type()
        {
            string code = @"
[Associative]

{ 

	 def foo3 : int[]..[] ( a : double )

	 {

	    return = { { 0, 2 }, { 1 } };

	 }

	 

	dummyArg = 1.5;

	

	b2 = foo3 ( dummyArg )[0][0];	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT43_Pass_3_List_Different_Length_2_Integers()
        {
            string code = @"
def foo : int(a : int, b : int, c : int, d : int, e : int)

{

	return = a * b - c / d + e;

}

list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

list2 = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3 };

list3 = {1, 4, 7, 2, 5, 8, 3 };

list4 = foo(list1, list2, list3, 4, 23);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT43__Defect_1452423_3__2_()
        {
            string code = @"
[Associative]

{

	a = 0;

	while ( a == false )

	{

		a = 1;

	}

	

	b = a;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT43__Defect_1452423_3()
        {
            string code = @"
[Imperative]

{

	a = 0;

	while ( a == false )

	{

		a = 1;

	}

	

	b = a;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT44_Defect_1450706_2()
        {
            string code = @"
[Imperative]

{

	def float_fn:int(a:int)

	{

		if( a < 2 )

			return = 0;

		else

			return = 1;

	}

	 

	x = float_fn(1);

 

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT44_Defect_1457029()
        {
            string code = @"
class A

{

    Pt : double;

    constructor A (pt : double)

    {

        Pt = pt;

    }

    

    

}

    

c1 = { { 1.0, 2.0}, 3.0 };

c1 = A.A( c1[0] );

x = c1.Pt;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT44_Defect_1457029_2()
        {
            string code = @"
class A

{

    Pt : double;

    constructor A (pt : double)

    {

        Pt = pt;

    }

    

    

}

    

c1 = { { 1.0, 2.0}, 3.0 };

c1 = A.A( c1[0][0] );

x = c1.Pt;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT44_Defect_1461860()
        {
            string code = @"
class A

{

    static x:int = 3;

	

}



[Imperative]

{

	a = A.A();

	b = [Associative]

	{

	    a.x = 4;

		return = a.x;

	}

}























";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT44_Defect_1461860_2()
        {
            string code = @"
class A

{

    static x:int = 3;

	

}

a1 = A.A();

a2 = A.A();

y = [Imperative]

{

	x = { a1, a2 };

	count = 0;

	

	for ( i in x )

	{

	    i.x = count;

        count = count + 1;		

	}

	

	return = x;

}



c = y.x;

















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT44_Function_With_Null_Argument()
        {
            string code = @"
[Imperative]

{ 

	 def foo : double ( a : double )

	 {

	    return = 1.5;

     }

	

	 b2 = foo ( null );	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT44_Pass_3_List_Same_Length()
        {
            string code = @"
def foo : int(a : int, b : int, c : int)

{

	return = a * b - c;

}

list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

list2 = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

list3 = {1, 4, 7, 2, 5, 8, 3, 6, 9, 0 };

list4 = foo(list1, list2, list3); // { 9, 14, 17, 26, 25, 22, 25, 18, 9, 10 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT44_Use_Bracket_Around_Range_Expr_In_For_Loop()
        {
            string code = @"


[Imperative] {



s = 0;



for (i in (0..10)) {

	s = s + i;

}



}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT44__Defect_1452423_4__2_()
        {
            string code = @"
[Associative]

{

	y = true;

	x = 1 + y;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT44__Defect_1452423_4()
        {
            string code = @"
[Imperative]

{

	y = true;

	x = 1 + y;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT45_Defect_1450506()
        {
            string code = @"
[Imperative]

{

    i1 = 2;

    i2 = 3;

	i3 = 4.5;

	

    temp = 2;

    

	while(( i2 == 3 ) && ( i1 == 2 )) 

	{

	temp = temp + 1;

	i2 = i2 - 1;

    }

	

	if(( i2 == 3 ) || ( i3 == 4.5 )) 

	{

	temp = temp + 1;

    }

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT45_Defect_1458284()
        {
            string code = @"
class Point

{

    X : var;

    Y : var;

    Z : var;

    id : var;

    

    constructor ByCoordinates(x : double, y : double, z : double)

    {

        X = x;

        Y = y;

        Z = z;

        id = x;

    }

}



    def length (pts : Point[])

    {

        numberOfPoints = [Imperative]

        {

            counter = 0;

            for(pt in pts)

            {

                counter = counter + 1;

            }

            

            return = counter;

        }

        return = numberOfPoints;

    }

    

    def getIds (pts : Point[])

    {

        numPoints = length(pts);

        

        pt_ids = [Imperative]

        {

            tempArr = -1..-1..#numPoints; // = { -1, -1, -1, -1, -1 }           

            counter = 0;

            for(pt in pts)

            {

                tempArr[counter] = pt.id;

		counter = counter + 1;

            }

            

            return = tempArr;

        }

        

        return = pt_ids;

    }



class BSplineCurve

{

    id : var;

    numPts : var;

    ids : var[]..[];

    

    constructor ByPoints(ptsOnCurve : Point[])

    {

        id = null;

        numPts = length(ptsOnCurve);

        ids = getIds(ptsOnCurve);

    }

}





pt1 = Point.ByCoordinates(0,0,0);

pt2 = Point.ByCoordinates(5,0,0);

pt3 = Point.ByCoordinates(10,0,0);

pt4 = Point.ByCoordinates(15,0,0);

pt5 = Point.ByCoordinates(20,0,0);



pts = {pt1, pt2, pt3, pt4, pt5};

bcurve = BSplineCurve.ByPoints(pts);

numpts = bcurve.numPts;

ids = bcurve.ids;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT45_Defect_1461479()
        {
            string code = @"
class A

{

	x : int = 2;

	def foo : int()

	{

		return = 2;

	}

}



a = A.foo(); //access non-static function, expected: a = null; actual: crash

b = A.x;

//A.x = 3;

//c = 4;





















";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT45_Function_With_Mismatching_Argument_Type()
        {
            string code = @"
[Associative]

{ 

	 def foo : double ( a : double )

	 {

	    return = 1.5;

     }

	

	 b2 = foo ( 1 );	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT45_Pass_3_List_Same_Length_2_Integers()
        {
            string code = @"
def foo : int(a : int, b : int, c : int, d : int, e : int)

{

	return = a * b - c * d + e;

}

list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

list2 = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

list3 = {1, 4, 7, 2, 5, 8, 3, 6, 9, 0 };

list4 = foo(list1, list2, list3, 26, 43); // { 27, -43, -115, 19, -57, -135, -7, -89, -173, 53 }  
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT45__Defect_1452423_5__2_()
        {
            string code = @"
[Associative]

{

	a = 4 + true;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT45__Defect_1452423_5()
        {
            string code = @"
[Imperative]

{

	a = 4 + true;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT46_Defect_1461716()
        {
            string code = @"
class A

{

    a : int;	

	constructor A ()

	{

	    a = 1;

	}	

}

a1 = A.A();

b1 = a1.A();

c1 = b1.a;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT46_Defect_1461716_2()
        {
            string code = @"
class A

{

    a : int;	

	constructor A ()

	{

	    a = 1;

	}	

}

def foo ( )

{

    a1 = A.A();

	b1 = a1.A();

	c1 = b1.a;

	return = { b1, c1 };

}



x = foo ();



[Imperative]

{

	a1 = A.A();

	b1 = a1.A();

	c1 = b1.a;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT46_Function_With_Mismatching_Argument_Type()
        {
            string code = @"
[Imperative]

{ 

	 def foo : double ( a : int )

	 {

	    return = 1.5;

     }

	

	 b2 = foo ( 1.5);

     c = 3;	 



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT46_Pass_FunctionCall_Reutrn_List()
        {
            string code = @"
def foo : int(a : int)

{

	return = a * a;

}



list1 = { 1, 2, 3, 4, 5 };

list3 = foo(foo(foo(list1))); // { 1, 256, 6561, 65536, 390625 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT46_TestBooleanOperationOnNull__2_()
        {
            string code = @"
[Imperative]

{

	a = null;

	b = a * 2;

	c = a && 2;	

	d = 0;

	if ( a && 2 == 0)

	{

        d = 1;

	}

	else

	{

	    d = 2;

	}

	

	if( !a )

	{

	    d = d + 2;

	}

	else

	{

	    d = d + 1;

	}

	if( a )

	{

	    d = d + 3;

	}

	

	

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT46_TestBooleanOperationOnNull()
        {
            string code = @"
[Imperative]

{

	a = null;

	b = a * 2;

	c = a && 2;	

	d = 0;

	if ( a && 2 == 0)

	{

        d = 1;

	}

	else

	{

	    d = 2;

	}

	

	if( !a )

	{

	    d = d + 2;

	}

	if( a )

	{

	    d = d + 1;

	}

	

	

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT46_TestIfWithNull()
        {
            string code = @"
[Imperative]

{

    a = null;

    c = null;

	

    if(a == 0)

	{

		a = 1;	

	}



    if(null == c)

	{

		c = 1;	

	}



    if(a == b)

	{

		a = 2;	

	}	

	

	

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT47_Calling_Imperative_Code_From_Conctructor()
        {
            string code = @"
class A

{

	a : int;

	

	constructor A( i:int )

	{

		[Imperative]

		{

		    a = i;

		}

	}

	

}



A1 = A.A( 1 );

a1 = A1.a;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT47_Defect_1450858()
        {
            string code = @"
[Imperative]

{	

	i = 1;

	a = 3;

	if( a==3 )             	

	{		 

		while( i <= 4 )

		{

		if( i > 10 )

		temp = 4;

		else

		i = i + 1;

		}

	}

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT47_Function_With_Mismatching_Argument_Type()
        {
            string code = @"
[Associative]

{ 

	 def foo : double ( a : double )

	 {

	    return = 1.5;

     }

	

	 b2 = foo ( true);	

	 c = 3;	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT47_Pass_Single_3x3_List()
        {
            string code = @"
def foo : int(a : int)

{

	return = a * a;

}



list1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

list2 = foo(list1); // { { 1, 4, 9 }, { 16, 25, 36 }, { 49, 64, 81 } }

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT47_TestBooleanOperationOnNull__2_()
        {
            string code = @"
[Associative]

{

	a = false;

        b = 0;

	d = 0;



	if( a == null)

	{

	    d = d + 1;

	}



    if( b == null)

	{

	    d = d + 1;

	}	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT47_TestBooleanOperationOnNull()
        {
            string code = @"
[Imperative]

{

	a = false;

        b = 0;

	d = 0;



	if( a == null)

	{

	    d = d + 1;

	}



    if( b == null)

	{

	    d = d + 1;

	}	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT48_Defect_1450858_2()
        {
            string code = @"
[Imperative]

{	

	def factorial:int(a:int)

	{

		 fact = 1;

		 

		 if( a != 0)

		 {

			 while( a > 0 )

			 { 

				fact = fact * a;

				a = a - 1;

			 }

		}	 

		

		return = fact;

	}

	

	test = factorial(4);

}	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT48_Defect_1460027()
        {
            string code = @"
class A

{

	a : int[][];

	

	constructor create(i:int)

	{

		

				a = { { 1,2,3 } , { 4,5,6 } };

	//a=1;

	

	}

	

}



A1 = A.create(1);

a1 = A1.a;

b1=a1[1][0];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT48_Defect_1460027_2()
        {
            string code = @"
class A

{

	a : var[]..[];

	

	constructor create(i:int)

	{

		

				a = { { 1,2,3 } , { 4,5,6 } };

	

	}

	

}



A1 = A.create(1);

a1 = A1.a;

b1=a1[1][0];

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT48_Defect_1460027_3()
        {
            string code = @"
class A

{

	a : var[]..[];

	

	constructor create()

	{

		

				a = { { 1,2,3 } , { 4,5,6 } };

	

	}

	

}



	test1 = A.create();

	

	a1 = test1.a;

	test1.a[0] = { 4,5,6 };



	b = test1.a[0];

	c = test1.a[0][0];
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        // Ignore - Aparajit to fix testcase
        [Test, Ignore] 
        public void DebugEQT48_Defect_1460027_4()
        {
            string code = @"
class A

{

	a : var[]..[];

	

	constructor create()

	{

		

				a = { { 1,2,3 } , { 4,5,6 } };

	

	}



	def foo ( x )

	{

		a[1][2] = x;

		return = a;

	}

}

	



	test1 = A.create();

	a1 = test1.a;

	b = test1.foo( a1[0][1] );

	

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT48_Function_With_Mismatching_Argument_Type()
        {
            string code = @"
class A

{

    a : int;

	constructor A1(a1 : int)

	{

	    a = a1;

	}

}



[Associative]

{ 

	 def foo : double ( a : int )

	 {

	    return = 1.5;

     }

	 a = A.A1(1);

	 b2 = foo ( a);	

	 c = 3;	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT48_MultipleAssignments__2_()
        {
            string code = @"
class A

{

    i : int;

	constructor A ( a : int)

	{

	     t1 = t2 = 2;

		 i = t1 + t2 + a ;

	}

	

	def foo : int ( )

	{

	    t1 = t2 = 2;

		t3 = t1 + t2 + i;

        return  = t3;		

	}

	

}



def foo : int ( a : int )

{

    t1 = t2 = 2;

	return = t1 + t2 + a ;

}

	

[Associative]

{

    

	a = b = 4;

    x = y = foo(1);

	a1 = A.A(1);

	b1 = a1.foo();

	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT48_MultipleAssignments()
        {
            string code = @"
class A

{

    i : int;

	constructor A ( a : int)

	{

	     t1 = t2 = 2;

		 i = t1 + t2 + a ;

	}

	

	def foo : int ( )

	{

	    t1 = t2 = 2;

		t3 = t1 + t2 + i;

        return  = t3;		

	}

	

}



[Imperative]

{

    def foo : int ( a : int )

	{

	    t1 = t2 = 2;

		return = t1 + t2 + a ;

	}

	a = b = 4;

    x = y = foo(1);

	a1 = A.A(1);

	b1 = a1.foo();

	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT48_Pass_Single_List()
        {
            string code = @"
def foo : int(num : int)

{

	return = num * num;

}

list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

list2 = foo(list1);  // { 1, 4, 9, 16, 25, 36, 49, 64, 81, 100 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT49_Defect_1450783()
        {
            string code = @"
[Imperative]

{

	a = 4;

	if( a == 4 )

	{

	    i = 0;

	}

	a = i;

	b = i;

} 

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT49_Defect_1455264()
        {
            string code = @"
[associative]

{

	a = 1;

	

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT49_Defect_1460505()
        {
            string code = @"
class Parent

{

A : var;

B : var;

C : var;



constructor Create( x:int, y:int, z:int )

{

A = x;	

B = y;

C = z;

}

}



class Child extends Parent

{

constructor Create( x:int, y:int, z:int )

{

A = x;	

B = y;

C = z;

}

}



def modify(oldPoint : Parent)



{





return=true;



}





oldPoint = Parent.Create( 1, 2, 3 );

derivedpoint = Child.Create( 7,8,9 );

basePoint = modify( oldPoint );

derivedPoint2 = modify( derivedpoint );
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT49_Defect_1460505_2()
        {
            string code = @"
class Parent

{

A : var;

B : var;

C : var;



constructor Create( x:int, y:int, z:int )

{

A = x;	

B = y;

C = z;

}

}



class Child extends Parent

{

constructor Create( x:int, y:int, z:int )

{

A = x;	

B = y;

C = z;

}

}



def modify(oldPoint : Child)



{





return=true;



}





oldPoint = Parent.Create( 1, 2, 3 );

derivedpoint = Child.Create( 7,8,9 );

basePoint = modify( oldPoint );

derivedPoint2 = modify( derivedpoint );
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT49_Function_With_Matching_Return_Type()
        {
            string code = @"
class A

{

    a : int;

	constructor A1(a1 : int)

	{

	    a = a1;

	}

}



[Associative]

{ 

	 def foo : A ( x : A )

	 {

	    return = x;

     }

	 aa = A.A1(1);

	 b2 = foo ( aa).a;

	 c = 3;	

	 



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT49_Pass_Single_List_2_Integers()
        {
            string code = @"
def foo : int(num : int, num2 : int, num3 : int)

{

	return = num * num2 - num3;

}

list1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

list2 = foo(list1, 34, 18); // { 16, 50, 84, 118, 152, 186, 220, 254, 288, 322 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT49_TestForStringObjectType()
        {
            string code = @"
[Associative]

{

    def foo : string (x : string )

	{

	   return = x; 		

	}

    a = ""sarmistha"";

    b = foo ( a );	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT50_1_of_3_Exprs_is_List()
        {
            string code = @"
list1 = { true, false, true, false, true };



list2 = list1 ? 1 : 0; // { 1, 0, 1, 0, 1 }



list3 = true ? 10 : list2; // { 10, 10, 10, 10, 10 }



list4 = false ? 10 : list2; // { 1, 0, 1, 0, 1 }



a = { 1, 2, 3, 4, 5 };

b = {5, 4, 3, 2, 1 };

c = { 4, 3, 2, 1 };



list5 = a > b ? 1 : 0; // { 0, 0, 0, 1, 1 }

list6 = c > a ? 1 : 0; // { 1, 1, 0, 0 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT50_Defect_1449889()
        {
            string code = @"
[Imperative]

{

	a = 3;

	b = 2;

	c = a & b;

	d = 5;

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT50_Defect_1450817()
        {
            string code = @"
[Imperative]

{ 

	def fn:int(a:int)

	{

		if( a < 0 )

		if( a < -1 )

		return = 0;

		else

		return = -1;

		

		return = 1;

	}

	

	x = fn(-1);

	

	temp = 1;

	

	if (fn(2))

	{

		temp = fn(5);

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT50_Defect_1456713()
        {
            string code = @"
a = 2.3;

b = a * 3;



//Expected : b = 6.9;

//Recieved : b = 6.8999999999999995;



























";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT50_Defect_1456738_Replication_Race_Condition()
        {
            string code = @"
//import ( ""Math.dll"");



class Math

{

   static def Sin ( x1 : double)

   {

       return = x1;

   }

}



// dimensions of the roof in each direction

//

xSize = 10;

ySize = 20;



// number of Waves in each direction

//

xWaves = 1;

yWaves = 3;



// number of points per Wave in each direction\

//

xPointsPerWave = 10;

yPointsPerWave = 10;



// amplitudes of the frequencies (z dimension)

//

lowFrequencyAmpitude = 1.0; // only ever a single low frequency wave

highFrequencyAmpitude = 0.75; // user controls the number and amplitude of high frequency waves 



// dimensions of the beams

//

radius = 0.1;

roofWallHeight = 0.3; // not used

roofWallThickness = 0.1; // not used



// calculate how many 180 degree cycles we need for the Waves

//

x180ToUse = xWaves==1?xWaves:(xWaves*2)-1;

y180ToUse = yWaves==1?yWaves:(yWaves*2)-1;



// count of total number of points in each direction

//

xCount = xPointsPerWave*xWaves;

yCount = yPointsPerWave*yWaves;





xHighFrequency = Math.Sin(0..(180*x180ToUse)..#xCount)*highFrequencyAmpitude;

xLowFrequency = Math.Sin(-5..185..#xCount)*lowFrequencyAmpitude;

yHighFrequency = Math.Sin(0..(180*y180ToUse)..#yCount)*highFrequencyAmpitude;

yLowFrequency = Math.Sin(-5..185..#yCount)*lowFrequencyAmpitude;



sinRange = {0.0, 10, 20, 30, 40 ,50, 60 ,70 ,80 , 90 ,100, 110 ,120, 130, 140, 150, 160, 170};

xHighFrequency = Math.Sin(sinRange) * highFrequencyAmpitude;



y = Count(xHighFrequency);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT50_Defect_1460510()
        {
            string code = @"
class TestPoint

{

            A : var;

                                

       constructor Create()

        {

	    A = 10; 

        }

	

}



class derived extends TestPoint

{

	    A : var;

     constructor Create()

        {

	    A = 20; 

     }

	def Modify()

		

	{

	   A = A +1;

	    return=true;

	}   

}

	oldPoint = TestPoint.Create();

    derivedpoint=derived.Create();

	derivedPoint2 = derivedpoint.Modify();

	xPoint1 = oldPoint.A;

    xPoint2 = derivedpoint.A;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT50_Defect_1460510_2()
        {
            string code = @"
class Base

{

	A : int;



	constructor Create()

	{

		A = 5;

	}

}



class Derived extends Base

{

	A : var;



	constructor Create1()

	{

		A = 10;

	}

}



	def Modify( object : Base )

	{

		object.A = object.A + 1;

		return = object.A;

	}



	B = Base.Create();

	D = Derived.Create1();

	a = Modify( B );



	
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT50_Function_With_Mismatching_Argument_Type()
        {
            string code = @"
[Associative]

{ 

	 def foo : double ( a : int[] )

	 {

	    return = 1.5;

     }

	 aa = { };

	 b2 = foo ( aa );	

	 c = 3;	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT50_Replication_Imperative_Scope()
        {
            string code = @"
[Imperative]

{



	def even : int (a : int) 

	{	

		if(( a % 2 ) > 0 )

			return = a + 1;		

		else 

			return = a;

		

		return = 0;

	}





    x = { 1, 2, 3 };

	c = even(x);

	

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT51_2_of_3_Exprs_are_Lists_Different_Length()
        {
            string code = @"
list1 = { 1, 2, 3, 4, 5 };

list2 = { true, false, true, false };



list3 = list2 ? list1 : 0; // { 1, 0, 3, 0 }

list4 = list2 ? 0 : list1; // { 0, 2, 0, 4 }

list5 = { -1, -2, -3, -4, -5, -6 };

list6 = true ? list1 : list5; // { 1, 2, 3, 4, 5 }

list7 = false ? list1 : list5; // { -1, -2, -3, -4, -5 }  



a = { 1, 2, 3, 4 };

b = { 5, 4, 3, 2, 1 };

c = { 1, 4, 7 };



list8 = a >= b ? a + c : 10; // { 10, 10, 10 }

list9 = a < b ? 10 : a + c; // { 10, 10, 10 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT51_Assignment_Using_Negative_Index()
        {
            string code = @"
a = { 0, 1, 2, 3 };



c1 = a [-1];

c2 = a [-2];

c3 = a [-3];

c4 = a [-4];

c5 = a [-5];

c6 = a [-1.5];

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT51_Defect_1452588()
        {
            string code = @"
[Imperative]

{

    a = 0;

    

    if ( a == 0 )

    {

	    b = 2;

    }

    c = a;

} 

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT51_Defect_1461399()
        {
            string code = @"
class Arc

{

constructor Arc()

{



}

def get_StartPoint()

{

	return = 1;

}

}



def CurveProperties(curve : Arc)

{



 return = {

	curve.get_StartPoint(),

	curve.get_StartPoint(),

	curve.get_StartPoint()



	

 };

}



test = CurveProperties(null);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT51_Defect_1461399_2()
        {
            string code = @"
class Arc

{

    constructor Arc()

    {

        

    }

    def get_StartPoint()

    {

        return = 1;

    }

    

    

    def CurveProperties(curve : Arc)

    {

        

        return =

        {

            curve.get_StartPoint(),

            curve.get_StartPoint(),

            curve.get_StartPoint()

        };

        

    }

} 

   

	Arc1 = Arc.Arc();

	test = Arc1.CurveProperties(null);
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT51_Defect_1461399_3()
        {
            string code = @"
class Arc

{

    constructor Arc()

    {

        

    }

    def get_StartPoint()

    {

        return = 1;

    }

    

    

    def CurveProperties(curve : Arc)

    {

        

        return =

        {

            curve.get_StartPoint(),

            curve.get_StartPoint(),

            curve.get_StartPoint()

        };

        

    }

} 



[Imperative]

{   

	Arc1 = Arc.Arc();

	test = Arc1.CurveProperties(null);

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT51_Function_With_Mismatching_Argument_Type()
        {
            string code = @"
[Associative]

{ 

	 def foo : double ( a : double[] )

	 {

	    return = 1.5;

     }

	 aa = {1, 2 };

	 b2 = foo ( aa );	

	 c = 3;	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT51_Using_Special_Characters_In_Identifiers()
        {
            string code = @"
@a = 1;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT52_2_of_3_Exprs_are_Lists_Same_Length()
        {
            string code = @"
list1 = { 1, 2, 3, 4, 5 };

list2 = { true, false, true, false, true };



list3 = list2 ? list1 : 0; // { 1, 0, 3, 0, 5 }

list4 = list2 ? 0 : list1; // { 0, 2, 0, 4, 0 }

list5 = true ? list3 : list4; // { 1, 0, 3, 0, 5 }

list6 = true ? list4 : list3; // {0, 2, 0, 4, 0 }



a = { 1, 2, 3, 4, 5 };

b = { 5, 4, 3, 2 };



list7 = a > b ? a + b : 10; // { 10, 10, 10, 6 }

list8 = a <= b ? 10 : a + b; // { 10, 10, 10, 6 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT52_Defect_1449889()
        {
            string code = @"
[Imperative]

{

	a = b;

    c = foo();

	d = 1;

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT52_Defect_1452588_2()
        {
            string code = @"
[Associative]

{ 

	[Imperative]

	{

            g2 = g1;	

	}	

	g1 = 3;      

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT52_Defect_1461479()
        {
            string code = @"
class A

{

	x : int = 2;

	

	def foo : int()

	{

		return = 2;

	}

}



a = A.foo(); 

b = A.x;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT52_Defect_1461479_2()
        {
            string code = @"
class Sample

{

	a : var = 2;

	

	static def ret_a ()

	{

		return = a;

	}

}



test1 = Sample.ret_a(); 

test2 = Sample.a;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT52_Defect_1461479_3()
        {
            string code = @"
class Sample

{

	static a : var;



	constructor Sample()

	{

		a = 3;

	}

	

	static def ret_a ( b )

	{

		a = b;

		return = a;

	}

}



	Sample1 = Sample.Sample();

	

	test1 = Sample1.ret_a( 2 ); 

	test2 = Sample1.a;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT52_Defect_1461479_4()
        {
            string code = @"
class Sample

{

	a : var = 2;

	

	def ret_a ()

	{

		return = B.a;

	}

	

}



class B

{

   a : int;

}



[Imperative]

{

	S = Sample.Sample();



	test1 = Sample.ret_a();

	test2 = Sample.a;

	test5 = S.ret_a();

}



S2 = Sample.Sample();

test3 = Sample.ret_a();

test4 = Sample.a;

test6 = S2.ret_a();
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT52_Defect_1461479_5()
        {
            string code = @"
class Sample

{

	a : var = 2;

	

	def ret_a ()

	{

		return = a;

	}

}

test3 = Sample.ret_a();

test4 = Sample.a;

def fun1 ()

{

    return = { Sample.ret_a(), Sample.a };

}

def fun2 ()

{

    return = [Imperative]

	{

	    return = { Sample.ret_a(), Sample.a };

	}

}

test5 = fun1();

test6 = fun2();

test7; 

test8;

[Imperative]

{

	test1 = Sample.ret_a();

	test2 = Sample.a;

	test7 = fun1();

    test8 = fun2();

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT52_Function_With_Mismatching_Argument_Type()
        {
            string code = @"
[Associative]

{ 

	 def foo : double ( a : double[] )

	 {

	    return = 1.5;

     }

	 aa = 1.5;

	 b2 = foo ( aa );	

	 c = 3;	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT52_Negative_Associative_Syntax()
        {
            string code = @"
[Imperative]

{

	x = 1;

	y = {Associative]

	{

	   return = x + 1;

	}

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_3_of_3_Exprs_are_different_dimension_list()
        {
            string code = @"
a = { { 1, 2, 3 }, { 4, 5, 6 } };

b = { { 1, 2 },  { 3, 4 }, { 5, 6 } };

c = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };



list = a > b ? b + c : a + c; // { { 2, 4, }, { 8, 10 } } 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Collection_Indexing_On_LHS_Using_Function_Call()
        {
            string code = @"
def foo()

{

    return = 0;

}



x = { 1, 2 };

x[foo()] = 3;



y = x;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Defect_1452575()
        {
            string code = @"
[Imperative]

{ 

	def float_fn:int(a:double)

	{

		if( a < 2.0 )

			return = 0;

		else

			return = 1;

	}

	 

	x = float_fn(-1.5);

     

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Defect_1454691()
        {
            string code = @"
class A

{

	a : var;



	constructor CreateA ( a1 : int )

	{

		a = add_1(a1);

	}

	

	def add_1 ( x )

	{

	    return  = x + 1;

	}

	

}



[Imperative]

{



	A1 = A.CreateA(1);

	a = A1.a;

}



[Associative]

{

    x = 3;

	A1 = A.CreateA(x);

	a = A1.a;

	b = [Imperative]

	{

	    if ( a < 10 )

		{

		    B1 = A.CreateA(a);

			return = B1.a;

		}

	}

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Function_Updating_Argument_Values()
        {
            string code = @"
[Associative]

{ 

	 def foo : double ( a : double )

	 {

	    a = 4.5;

		return = a;

     }

	 aa = 1.5;

	 b2 = foo ( aa );	

	 c = 3;	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Undefined_Class_As_Parameter()
        {
            string code = @"
class Parent

{

	A : var;

	B : var;

	C : var;



	constructor Create( x:int, y:int, z:int )

	{

		A = x;	

		B = y;

		C = z;

	}

}



class Child extends Parent

{

	constructor Create( x:int, y:int, z:int )

	{

		A = x;	

		B = y;

		C = z;

	}

}



def modify(oldPoint1 : TestPoint)

{

    oldPoint1.A = oldPoint1.A +1;

	oldPoint1.B = oldPoint1.B +1;

	oldPoint1.C = oldPoint1.C +1;

	return=true;

}





oldPoint = Parent.Create( 1, 2, 3 );

derivedpoint = Child.Create( 7,8,9 );

basePoint = modify( oldPoint );

derivedPoint2 = modify( derivedpoint );

x1 = oldPoint.A;

x2 = derivedpoint.B;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Undefined_Class_As_Parameter_1463738()
        {
            string code = @"
class Parent

{

A : var;

B : var;

C : var;



constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



class Child extends Parent

{

constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



def modify(oldPoint : TestPoint)



{



oldPoint.A = oldPoint.A +1;

oldPoint.B = oldPoint.B +1;

oldPoint.C = oldPoint.C +1;

return=true;



}





oldPoint = Parent.Create( 1, 2, 3 );

derivedpoint = Child.Create( 7,8,9 );

basePoint = modify( oldPoint );

derivedPoint2 = modify( derivedpoint );

x1=oldPoint.A;

x2=derivedpoint.B; 
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Undefined_Class_As_Parameter_1463738_2()
        {
            string code = @"
class Parent

{

A : var;

B : var;

C : var;



constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



class Child extends Parent

{

constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



def modify(oldPoint : TestPoint[]) // array of class as argumment and class is not defined



{



oldPoint.A = oldPoint.A +1;

oldPoint.B = oldPoint.B +1;

oldPoint.C = oldPoint.C +1;

return=true;



}





oldPoint = Parent.Create( 1, 2, 3 );

derivedpoint = Child.Create( 7,8,9 );

basePoint = modify( oldPoint );

derivedPoint2 = modify( derivedpoint );

x1 = oldPoint.A;

x2 = derivedpoint.B;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Undefined_Class_As_Parameter_1463738_3()
        {
            string code = @"
class Parent

{

A : var;

B : var;

C : var;



constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



class Child extends Parent

{

constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



def modify(tmp : Child) // definition with inherited class



{



tmp.A = tmp.A +1;

tmp.B = tmp.B +1;

tmp.C = tmp.C +1;

return=true;



}





oldPoint = Parent.Create( 1, 2, 3 );

derivedpoint = Child.Create( 7,8,9 );

test1 = modify( oldPoint ); // call function with object of parent class

test2 = modify( derivedpoint );

x1 = oldPoint.A;

x2 = derivedpoint.B;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Undefined_Class_As_Parameter_1463738_4()
        {
            string code = @"
class Parent

{

A : var;

B : var;

C : var;



constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



class Child extends Parent

{

constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



def modify(oldPoint : Parent)



{



oldPoint.A = oldPoint.A +1;

oldPoint.B = oldPoint.B +1;

oldPoint.C = oldPoint.C +1;

return=true;



}





oldPoint = Parent.Create( 1, 2, 3 );

derivedpoint = Child.Create( 7,8,9 );

basePoint = modify( oldPoint );

derivedPoint2 = modify( derivedpoint );

x1 = oldPoint.A;

x2 = derivedpoint.B;



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Undefined_Class_As_Parameter_1463738_5()
        {
            string code = @"
class Parent

{

A : var;

B : var;

C : var;



constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



class Child extends Parent

{

constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



def modify(oldPoint : var)



{



oldPoint.A = oldPoint.A +1;

oldPoint.B = oldPoint.B +1;

oldPoint.C = oldPoint.C +1;

return=true;



}





oldPoint = Parent.Create( 1, 2, 3 );

//derivedpoint = Child.Create( 7,8,9 );

basePoint = modify( oldPoint );

//derivedPoint2 = modify( derivedpoint );

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Undefined_Class_As_Parameter_1463738_6()
        {
            string code = @"
class Parent

{

A : var;

B : var;

C : var;



constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



class Child extends Parent

{

constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



def modify(oldPoint1 : Parent) // two different function in one of them has a known class type as argument 

{

oldPoint1.A = oldPoint1.A +1;

oldPoint1.B = oldPoint1.B +1;

oldPoint1.C = oldPoint1.C +1;

return=true;

}

def modify(oldPoint1 : TestPoint)

{

oldPoint1.A = oldPoint1.A +1;

oldPoint1.B = oldPoint1.B +1;

oldPoint1.C = oldPoint1.C +1;

return=true;

}





oldPoint = Parent.Create( 1, 2, 3 );

derivedpoint = Child.Create( 7,8,9 );

basePoint = modify( oldPoint );

derivedPoint2 = modify( derivedpoint );

x1 = oldPoint.A; 

x2 = derivedpoint.B; 

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Undefined_Class_As_Parameter_1463738_7()
        {
            string code = @"
class Parent

{

A : var;

B : var;

C : var;



constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



class Child extends Parent

{

constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}





def modify(oldPoint1 : Parent) // two different function in one of them has a known class type as argument 

{

oldPoint1.A = oldPoint1.A +1;

oldPoint1.B = oldPoint1.B +1;

oldPoint1.C = oldPoint1.C +1;

return=true;

}

[Imperative]

{

 def modify:void()

{

oldPoint1.A = oldPoint1.A +1;

oldPoint1.B = oldPoint1.B +1;

oldPoint1.C = oldPoint1.C +1;



}





oldPoint = Parent.Create( 1, 2, 3 );

derivedpoint = Child.Create( 7,8,9 );

basePoint = modify( oldPoint );

derivedPoint2 = modify( derivedpoint );

x1 = oldPoint.A; // expected 1, received : 2

x2 = derivedpoint.B; // expected 8; received : 9

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Undefined_Class_As_Parameter_1463738_8()
        {
            string code = @"
class Parent

{

A : var;

B : var;

C : var;



constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



class Child extends Parent

{

constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}





def modify(a:int,oldPoint1 : Parent) // two different function in one of them has a known class type as argument 

{

oldPoint1.A = oldPoint1.A +1;

oldPoint1.B = oldPoint1.B +1;

oldPoint1.C = oldPoint1.C +1;

return=true;

}

def modify(a:int,oldPoint1 : TestPoint)

{

oldPoint1.A = oldPoint1.A +1;

oldPoint1.B = oldPoint1.B +1;

oldPoint1.C = oldPoint1.C +1;

return =a ;

}





oldPoint = Parent.Create( 1, 2, 3 );

derivedpoint = Child.Create( 7,8,9 );

basePoint = modify(1, oldPoint );

derivedPoint2 = modify(1, derivedpoint );

x1 = oldPoint.A; 

x2 = derivedpoint.B; 

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Undefined_Class_As_Parameter_imperative_1463738_9()
        {
            string code = @"
class Parent

{

A : var;

B : var;

C : var;



constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}



class Child extends Parent

{

constructor Create( x:int, y:int, z:int )

{

A = x;

B = y;

C = z;

}

}

[Imperative] // in imperative , object type not defined 

{

def modify(a:int,oldPoint1 : TestPoint)

{

oldPoint1.A = oldPoint1.A +1;

oldPoint1.B = oldPoint1.B +1;

oldPoint1.C = oldPoint1.C +1;

return =a ;

}



oldPoint = Parent.Create( 1, 2, 3 );

derivedpoint = Child.Create( 7,8,9 );

basePoint = modify(1, oldPoint );

derivedPoint2 = modify(1, derivedpoint );

x1 = oldPoint.A; 

x2 = derivedpoint.B;

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Undefined_Class_negative_1467107_10()
        {
            string code = @"
def foo(x:int)

{

return = x + 1;

}



//y1 = test.foo(2);

m=null;

y2 = m.foo(2);









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Undefined_Class_negative_associative_1467091_13()
        {
            string code = @"
def foo ( x : int)

{

return = x + 1;

}



y = test.foo (1);







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Undefined_Class_negative_imperative_1467091_12()
        {
            string code = @"
[Imperative]

{

	def foo ( x : int)

	{

		return = x + 1;

	}



	y = test.foo (1);

}







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT53_Undefined_Class_negative_imperative_1467107_11()
        {
            string code = @"
[Imperative]

{

	def foo(x:int)

	{

		return = x + 1;

	}



	//y1 = test.foo(2);

	m=null;

	y2 = m.foo(2);

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT54_3_of_3_Exprs_are_Lists_Different_Length()
        {
            string code = @"
list1 = { true, false, true, true, false };

list2 = { 1, 2, 3, 4 };

list3 = { -1, -2, -3, -4, -5, -6 };



list4 = list1 ? list2 : list3; // { 1, -2, 3, 4 }

list5 = !list1 ? list2 : list4; // { 1, 2, 3, 4 }

list6 = { -1, -2, -3, -4, -5 };

list7 = list1 ? list2 : list6; // { 1, -2, 3, 4 }



a = { 3, 0, -1 };

b = { 2, 1, 0, 3 };

c = { -2, 4, 1, 2, 0 };



list8 = a < c ? b + c : a + c; // { 1, 4, 1 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT54_Associative_Nested_deffect_1467063()
        {
            string code = @"


[Associative]

{        a = 4;

         b = 2;

     [Associative]

	 {

       b = a + 4;

     }

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT54_Defect_1451089()
        {
            string code = @"
[Imperative]

{ 

 def foo:double (a:int, b:int, c : double)

 {

  if(a<=b && b > c)

      return = a+b+c;  

  else 

     return = 0;           

 }                                



 temp=foo(2,3,2.5);  

}







";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT54_Defect_1454691()
        {
            string code = @"
class A

{

	a : var;



	constructor CreateA ( a1 : int )

	{

		a = add_1(a1);

	}

	

	def add_1 ( x )

	{

	    return  = x + 1;

	}

	

}



class B extends A

{

	b : var;



	constructor CreateB ( a1 : int )

	{

		b = a1 + 1;

		a = b + 1 ; //add_1(b);

	}

	

}



[Imperative]

{



	A1 = A.CreateA(1);

	a1 = A1.a;

	B1 = B.CreateB(1);

	a2 = B1.a;

	b2 = B1.b;

}



def foo ( x ) 

{

    return = x;

}



c = [Associative]

{

    x = 3;

	A1 = A.CreateA(x);

	a1 = A1.a;

	B1 = B.CreateB(x);

	b1 = B1.b;

	a2 = B1.a;

	

	b = [Imperative]

	{

	    if ( a1 < 10 )

		{

		    B1 = B.CreateB(a1);

			return = { B1.a, B1.b };

		}

		return = 0;

	}

	return = b;

}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT54_Defect_1458562()
        {
            string code = @"
class A

{ 

	static x1 : int;

	constructor A () 

	{	

		x1 = 5;

	}

}



a = A.A();

t1 = a.x1;
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT54_Defect_1467185_Modifier_Stack()
        {
            string code = @"
class B

{

    x : var;

    constructor B ( y )

    {

        x = y;

    }    

    def bfoo(a : double)

    {

        return = a*98;

    }

}



class C

{

    x : int;

    

    constructor C(a : int)

    {

        x = a;

    }    

    def bfoo(a : double)

    {

        return = a*3;

    }

}



x = 1;

a =

{

    x => a1;

    - 0.5 => a2; // equivalent to a1 - 0.5 or in general (previous state) - 0.5

    * 4 => a3; // equivalent to a2 * 4 or in general (previous state)times 4

    a1 > 10 ? true : false => a4;

    a1..2 => a5;

    { a3, a3 } => a6;

     C.C(a1);

     bfoo(a2) => a61; // bfoo method of class C called

     B.B(a1) => a7;

     bfoo(a2) => a8; // bfoo method of class B called

     B.B(a1).x => a9; 

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT54_Defect_1467185_Modifier_Stack_2()
        {
            string code = @"
class B

{

    x : var;

    constructor B ( y )

    {

        x = y;

    }    

    def bfoo(a : double)

    {

        return = a+1;

    }

}



def foo ( x : double)

{

    return = x + 1;

}

x = 1;



a =

{

    {0,1,2,3 } => a1;

    + 0.5 => a2; 

    0..2 => a3; 

    foo ( a1[a3] ) => a4;

	B.B(a1).bfoo(a4) => a5;

    B.B(a1).bfoo(foo ( a1[a3] ) ) => a6;

}



a7 = B.B(a1).bfoo(a4); // works fine

a8 = B.B(a1).bfoo(foo ( a1[a3] ) ); // works fine
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT54_Defect_1467185_Modifier_Stack_3()
        {
            string code = @"
class B

{

    x : var;

    constructor B ( y )

    {

        x = y;

    }    

    def bfoo(a : double)

    {

        return = a+1;

    }

}



def foo ( x : int, y: int)

{

    return = x + y;

}

x = { 1,2,3,4};

a =

{

    {0,1 } => a1;

	2..3 => a2;

    foo( a1<1>, a2<2> ) => a3; 

    x[a2] => a5;

	+x[a1] => a6;

	(0..2) => a4; 

     + 1;	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT54_Function_Updating_Argument_Values()
        {
            string code = @"
[Imperative]

{ 

	 def foo : double ( a : double )

	 {

	    a = 4.5;

		return = a;

     }

	 aa = 1.5;

	 b2 = foo ( aa );	

	 c = 3;	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT55_3_of_3_Exprs_are_Lists_Same_Length()
        {
            string code = @"
list1 = { true, false, false, true };

list2 = { 1, 2, 3, 4 };

list3 = { -1, -2, -3, -4 };



list4 = list1 ? list2 : list3; // { 1, -2, -3, 4 }

list5 = !list1 ? list2 : list3; // { -1, 2, 3, -4 }



a = { 1, 4, 7 };

b = { 2, 8, 5 };

c = { 6, 9, 3 };



list6 = a > b ? b + c : b - c; // { -4, -1, 8 }
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT55_Associative_assign_If_condition_1467002()
        {
            string code = @"
[Associative]

{

	x = {} == null;

}



";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT55_Defect_1450506()
        {
            string code = @"
[Imperative]

{

    i1 = 1.5;

    i2 = 3;

    temp = 2;

    while( ( i2==3 ) && ( i1 <= 2.5 )) 

    {

        temp = temp + 1;

	    i2 = i2 - 1;

    }     

 

}









";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT55_Defect_1454691()
        {
            string code = @"
class A

{

	a : var;



	constructor CreateA ( a1 : int )

	{

		a = a1;

	}

	

	

}



[Imperative]

{

    y1 = 0;

	x = 1;

	while ( x != 2 )

	{

	    t1 = A.CreateA(x);

		y1 = y1 + t1.a;

		x = x + 1;	    

	}

	

	y2 = 0;

	c = { 3, 4 };

	for ( i in c )

	{

	    t1 = A.CreateA(i);

		y2 = y2 + t1.a;

	}

	

	y3 = 1;

	if( y3 < 2 )

	{

	    while ( y3 <= 2 )

		{

			t1 = A.CreateA(y3);

			y3 = y3 + t1.a;			    

		}

	}

	

	y4 = 1;

	if( y4 > 20 )

	{

	    y4 = -1;

	}

	else

	{

	    t1 = A.CreateA(y4);

		y4 = y4 + t1.a;

	}

	

}

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT55_Defect_1460616()
        {
            string code = @"
class A

{ 

	x : var ;

	constructor A ()

	{

		      	

	}	

}



class B extends A

{

	constructor B()

	{

	    x=this.B();



	}



}



class C

{ 

	x : var ;

	

	

	constructor C ()

	{

		  x = this.C();

	}



        constructor C_1 ()

	{

		  x = this.C_1();

	}

}



a1 = B.B();

x1 = a1.x;

a2 = C.C();

x2 = a2.x;

a3 = C.C_1();

x3 = a3.x;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT55_Defect_1460616_2()
        {
            string code = @"
class C

{ 

	x : var ;

	

    constructor C_1 ()

	{

		  x = C_1();

	}

}



a3 = C.C_1();

x3 = a3.x;

";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT55_Function_Updating_Argument_Values()
        {
            string code = @"
[Imperative]

{ 

	 def foo : int ( a : double )

	 {

	    a = 5;

		return = a;

     }

	 aa = 5.0;

	 b2 = foo ( aa );	

	 c = 3;	



}





";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT56_Defect_1454691()
        {
            string code = @"
class A

{

	a : var;

	constructor CreateA ( a1 : int )

	{

		a = add_1(a1);

	}

	

	def add_1 ( x )

	{

		return  = x + 1;

	}

}



[Associative]

{

    x = 3;

	A1 = A.CreateA(x);

	a1 = A1.a;

	b = [Imperative]

	{

		if ( a1 < 10 )

		{

			return = A1.a;

		}

	return = A1.a + 1;

	}

}
";
            DebugTestFx.CompareDebugAndRunResults(code);
        }
        [Test]
        public void DebugEQT56_Defect_1460162()
        {
            string code = @"
class A