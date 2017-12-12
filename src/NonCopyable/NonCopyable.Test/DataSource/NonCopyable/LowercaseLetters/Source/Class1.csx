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

    public object A()
    {
        return new Counter();
    }

    public Counter B()
    {
        return new Counter();
    }

    public Counter C() => new Counter();
}

class Program
{
    Counter _c;
    static Counter _s = new Counter();

    static Counter RetVal() => _c;
    static ref Counter RetRef() => ref _c;
    static void Val(Counter c) { }
    static void In(in Counter c) { }
    static void Ref(ref Counter c) { }

    Counter _x = new Counter();
    Counter _y = _s;

    static void Main()
    {
        var c = new Counter();
        var copy = c;
        Val(c);
        Val(new Counter());
        In(c);
        In(in c);
        Ref(ref c);
    }
}