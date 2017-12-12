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
    void Ref1(ref Counter c) { }
    void In1(in Counter c) { }

    static void Ref2(ref Counter c) { }
    static void In1(in Counter c) { }
}
