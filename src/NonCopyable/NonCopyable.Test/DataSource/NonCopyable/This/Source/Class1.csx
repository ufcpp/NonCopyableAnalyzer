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

    public Counter Clone1() => this; // ❌
    public Counter Clone2() { return this; } // ❌

    public IEnumerable<Counter> Clone3()
    {
        yield return new Counter();
        yield return this; // ❌
        yield return new Counter();
    }

    public void Set(in Counter c) => this = c; // ❌
    public void Reset() => this = new Counter();
}

class Program
{
    static void Main()
    {
        var c = new Counter();
        var c1 = c.Clone1();
        var c2 = c.Clone2();
        var c3 = c.Clone3();
        c.Set(new Counter());
        c.Reset();
    }
}