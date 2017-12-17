using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.GenericParameter)]
internal class NonCopyableAttribute : Attribute { }

[NonCopyable]
struct Counter
{
    private int _i;
    public Counter(int i) => _i = i;
    public void Count() => ++_i;
    public int Value => _i;
}

static class Ex1
{
    public static void ByVal<[NonCopyable] T>(this T x) { }

    public static T NoConstraint<T>(ref this T x) where T : struct
    {
        var t = x;
        return t;
    }

    public static T Constraint<[NonCopyable] T>(ref this T x) where T : struct
    {
        var t = x; // ❌
        return t; // ❌
    }
}

class Program
{
    static void Main()
    {
        var c = new Counter();

        c.ByVal(); // ❌
        c.NoConstraint(); // ❌
        c.Constraint();
    }
}