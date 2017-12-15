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

    public static bool operator ==(Counter x, Counter y) => true;
    public static bool operator !=(in Counter x, in Counter y) => true;

    public static bool operator true(Counter x) => true;
    public static bool operator false(in Counter x) => true;

    public static bool operator ~(Counter x) => true;
    public static bool operator !(in Counter x) => true;
}

class Program
{
    static void Main()
    {
        var c1 = new Counter();

        var b1 = c1 == new Counter();
        var b2 = c1 != new Counter();
        if (c1 && true) { }
        if (c1 || false) { }
        var b3 = ~c1;
        var b4 = ~new Counter();
        var b5 = !c1;
        var b6 = !new Counter();
    }
}