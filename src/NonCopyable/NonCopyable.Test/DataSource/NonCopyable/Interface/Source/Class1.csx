using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Interface)]
internal class NonCopyableAttribute : Attribute { }

[NonCopyable]
interface INonCopyable { }
interface IChild : INonCopyable { }

struct S1 : INonCopyable { }
struct S2 : IChild { }

class Program
{
    static void X<T>(ref T x)
        where T : struct, INonCopyable
    {
        var t = x; // ❌
    }

    static void Main()
    {
        var s1 = new S1();
        var t1 = s1; // ❌
        X(ref s1);

        var s2 = new S2();
        var t2 = s2; // ❌
        X(ref s2);
    }
}