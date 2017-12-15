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
        var c = new Counter();

        var a = new List<Counter>
        {
            new Counter(),
            c,
        };

        var b = new Dictionary<Counter, int>
        {
            { new Counter(), 1 },
            { c, 2 },
        };

        var c = new[]
        {
            new Counter(),
            c,
        };

        var d = new List<Counter>
        {
            [0] = new Counter(),
            [1] = c,
        };

        var e = new X
        {
            A = new Counter(),
            B = c,
        };
    }
}

class X
{
    public Counter A;
    public Counter B;
}
