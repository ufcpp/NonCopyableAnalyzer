using System;

[AttributeUsage(AttributeTargets.Struct)]
internal class NonCopyableAttribute : Attribute { }

[NonCopyable]
struct Counter
{
    private int _i;
    public void Count() => ++_i;
    public int Value => _i;

    public static Counter operator +(Counter x, Counter y) => new Counter();
    public static bool operator ==(in Counter x, in Counter y) => new Counter();
}
