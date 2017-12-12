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
    static void Val(Counter c) { }
    static void In(in Counter c) { }
    static void Ref(ref Counter c) { }

    static void Main()
    {
        var c = new Counter();
        Val(c);
        Val(new Counter());
        In(c);
        In(in c);
        Ref(ref c);
    }
}