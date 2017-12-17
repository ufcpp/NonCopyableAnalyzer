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

class OtherClass
{
    Counter _c;
}

struct OtherStruct
{
    Counter _c; // ❌
}

[NonCopyable]
struct OtherNonCopyable
{
    Counter _c;
}
