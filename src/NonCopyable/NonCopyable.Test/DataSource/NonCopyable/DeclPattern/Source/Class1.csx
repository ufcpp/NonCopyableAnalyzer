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

        if (c is Counter c1) { }

        switch (c)
        {
            case Counter c2:
                break;
        }
    }
}
