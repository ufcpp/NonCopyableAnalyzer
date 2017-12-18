using System;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.GenericParameter)]
class NonCopyableAttribute : Attribute { }

[NonCopyable]
struct ByRefBool
{
    private bool _value;
    public ByRefBool(bool value) => _value = value;
    public static bool operator true(in ByRefBool x) => x._value;
    public static bool operator false(in ByRefBool x) => !x._value;
    public static ByRefBool operator &(in ByRefBool x, in ByRefBool y) => new ByRefBool(x._value & y._value);
    public static ByRefBool operator |(in ByRefBool x, in ByRefBool y) => new ByRefBool(x._value | y._value);
}

[NonCopyable]
struct ByValBool
{
    private bool _value;
    public ByValBool(bool value) => _value = value;
    public static bool operator true(ByValBool x) => x._value;
    public static bool operator false(ByValBool x) => !x._value;
    public static ByValBool operator &(ByValBool x, ByValBool y) => new ByValBool(x._value & y._value);
    public static ByValBool operator |(ByValBool x, ByValBool y) => new ByValBool(x._value | y._value);
}

class Class2
{
    static void Main(string[] args)
    {
        X(new ByRefBool(), new ByRefBool());
        X(new ByRefBool(true), new ByRefBool());
        X(new ByValBool(), new ByValBool());
        X(new ByValBool(true), new ByValBool());
    }

    static void X(in ByRefBool x, in ByRefBool y)
    {
        if (x) { }
        if (x & y) { }
        if (x & y) { }
        if (x && y) { }
        if (x || y) { }
    }

    static void X(in ByValBool x, in ByValBool y)
    {
        if (x) { } // ❌
        if (x & y) { } // ❌
        if (x & y) { } // ❌
        if (x && y) { } // ❌
        if (x || y) { } // ❌
    }
}
