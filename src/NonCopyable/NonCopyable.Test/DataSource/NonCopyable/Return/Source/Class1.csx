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

    public static Counter Create1() => new Counter();
    public static Counter Create2() { return new Counter(); }

    public static IEnumerable<Counter> Create3()
    {
        yield return new Counter();
        yield return new Counter();
        yield return new Counter();
    }
}

class Program
{
    static Counter _c = new Counter();
    static Counter[] _ca = new Counter[1];
    public static Counter Create1() => _c; // ❌
    public static Counter Create2() { return _c; } // ❌

    public static IEnumerable<Counter> Create3()
    {
        yield return new Counter();
        yield return _c; // ❌
        yield return new Counter();
    }

    static void Main()
    {
        var cc1 = Counter.Create1();
        var cc2 = Counter.Create2();
        var cc3 = Counter.Create3();
        var c1 = Create1();
        var c2 = Create2();
        var c3 = Create3();

        var c4 = Enumerable.Range(0, 5).Select(_ => new Counter());
        var c5 = Enumerable.Range(0, 5).Select(_ => _c); // ❌

        var r = ref Ref();
        var v = Ref();
        
        var r = ref ArrayRef();
        var v = ArrayRef();
    }

    public static ref Counter Ref() { return ref _c; }
    public static ref Counter ArrayRef() { return ref _ca[0]; }
    public static Counter CreateCond() => true ? new Counter() : default;
    static readonly delegate* unmanaged<Counter> pointerBasedFactory;
    public static Counter CreatePointerBasedFactory() => pointerBasedFactory();
}