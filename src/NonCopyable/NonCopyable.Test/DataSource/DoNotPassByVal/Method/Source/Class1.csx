using System;

[AttributeUsage(AttributeTargets.Struct)]
internal class NonCopyableAttribute : Attribute { }

[NonCopyable]
struct Counter
{
    private int _i;
    public void Count() => ++_i;
    public int Value => _i;
}

class Class1
{
    private Counter _c;
    void Set(Counter c) { }
    void Set(Counter c1, Counter c2) { }
    void Set(ref Counter r, Counter c) { }
}