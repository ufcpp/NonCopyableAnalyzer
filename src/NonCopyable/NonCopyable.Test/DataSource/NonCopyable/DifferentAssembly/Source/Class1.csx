using NonCopyable.Test.TestTypes;

class Class1
{
    static void Main()
    {
        var x1 = new X();
        X x2 = x1;

        var y1 = new MyNonCopyable();
        var y2 = y1;
    }
}

[NonCopyable]
struct X { }
