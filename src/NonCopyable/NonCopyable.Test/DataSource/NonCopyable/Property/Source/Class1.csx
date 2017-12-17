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

    public static Counter Property1 => new Counter();
    public static Counter Property2 { get { return new Counter(); } }
}

class Program
{
    static Counter _c = new Counter();
    public static Counter ValProperty => _c; // ❌
    public static ref Counter RefProperty => ref _c;

    static void Main()
    {
        var cc1 = Counter.Property1; // ❌
        var cc2 = Counter.Property2; // ❌
        var c1 = ValProperty; // ❌
        var c2 = RefProperty; // ❌
        ref var c3 = ref RefProperty;
    }
}