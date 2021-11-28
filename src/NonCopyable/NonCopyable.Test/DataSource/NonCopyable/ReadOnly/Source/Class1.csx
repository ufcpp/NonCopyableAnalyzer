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

class Program
{
    static Counter _c = new Counter();
    static readonly Counter _ro = new Counter();

    static void Main()
    {
        var c = new Counter();
        var v0 = c.Value;
        c.M();

        var v1 = _c.Value;
        _c.M();

        var v2 = _ro.Value; // ❌
        _ro.M(); // ❌

        ref var r = ref c;

        var v3 = r.Value;
        r.M();

        ref readonly var ro = ref c;

        var v4 = ro.Value; // ❌
        ro.M(); // ❌

        Func<int> a = c.M; // ❌
    }

    static void MIn(in Counter ro)
    {
        var v = ro.Value; // ❌
        ro.M(); // ❌
    }

    static void MRef(ref Counter r)
    {
        var v = r.Value;
        r.M();
    }
}