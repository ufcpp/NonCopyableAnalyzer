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

static class Class1
{
    private Counter _c;
    public static void Ref(ref this Counter c) { }
    public static void In(in this Counter c) { }
    public static void Val(this Counter c) { }
}