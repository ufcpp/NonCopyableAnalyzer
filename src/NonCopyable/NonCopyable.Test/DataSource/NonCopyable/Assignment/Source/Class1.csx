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
}

class Program
{
    static void Main()
    {
        var c1 = new Counter();
        Counter c2 = new Counter();

        Counter c3;
        c3 = c1;
        c1 = c2;
        c2 = new Counter();

        var t = (c1, new Counter(), c2);
        var (x, y) = (new Counter(), c1);
    }

    static void M(ref Counter i, out Counter o)
    {
        o = new Counter();
        o = i;
    }
}