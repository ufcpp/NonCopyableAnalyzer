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
    static void Box(object c) { }

    static object Ret(in Counter c) => c; // ❌

    static void Main()
    {
        var c = new Counter();
        object o1 = c; // ❌
        object o2 = new Counter(); // ❌
        Box(c); // ❌
        Box(new Counter()); // ❌

        var a1 = new Counter[] { new Counter() };
        var a2 = new object[] { new Counter(), c }; // ❌

        (object x, int i) = (new Counter(), 1); // ❌

        var s = "" + c; // ❌
    }
}