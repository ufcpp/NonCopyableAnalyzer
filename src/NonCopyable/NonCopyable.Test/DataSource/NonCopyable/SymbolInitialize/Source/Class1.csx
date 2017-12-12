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
        Counter c3 = default(Counter);
        var c4 = c1;
        Counter c5 = c1;
    }

    static Counter _c1 = new Counter();
    static Counter _c2 = default;
    Counter _c3 = _c1;

    static void X(Counter c1 = default(Counter), Counter c2 = default, Counter c3 = new Counter()) { }

    public Counter C1 { get; } = _c1;
    public Counter C2 { get; set; } = _c1;
    public Counter C3 { get; private set; } = _c1;
    public Counter C4 { get; } = new Counter();
    public Counter C5 { get; set; } = default(Counter);
    public Counter C6 { get; private set; } = default;

    static void Ref()
    {
        var c1 = new Counter();
        ref Counter c2 = ref c1;
        ref readonly Counter c3 = ref c1;
    }
}
