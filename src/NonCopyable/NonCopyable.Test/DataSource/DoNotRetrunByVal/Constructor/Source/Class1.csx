using System;

[AttributeUsage(AttributeTargets.Struct)]
internal class NonCopyableAttribute : Attribute { }

[NonCopyable]
struct Counter
{
    private int _i;
    Counter(int i) { _i = i; }
    public void Count() => ++_i;
    public int Value => _i;
}
