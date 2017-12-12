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
}
