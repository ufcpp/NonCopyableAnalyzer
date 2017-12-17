using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

[AttributeUsage(AttributeTargets.Struct)]
internal class NonCopyableAttribute : Attribute { }

[NonCopyable]
struct Counter
{
    private int _i;
    public Counter(int i) => _i = i;
    public void Count() => ++_i;
    public int Value => _i;

    public int M() => 0;
}

static class Ex
{
    public static int MVal(this Counter c) => 0;
    public static int MRef(ref this Counter c) => 0;
    public static int MIn(in this Counter c) => 0;
}

class Program
{
    static void Main()
    {
        var c = new Counter();
        c.M();
        c.MVal(); // ❌
        c.MRef();
        c.MIn();
        var w = c.M() + c.MVal() + c.MRef() + c.MIn(); // ❌
        var x = c.MVal() + c.M() + c.MRef() + c.MIn(); // ❌
        var y = c.MVal() + c.MRef() + c.M() + c.MIn(); // ❌
        var z = c.MVal() + c.MRef() + c.MIn() + c.M(); // ❌
    }
}