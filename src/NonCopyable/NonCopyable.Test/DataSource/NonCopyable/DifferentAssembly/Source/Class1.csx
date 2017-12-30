using NonCopyable.Test.TestTypes;

class Class1
{
    static void Main()
    {
        var x1 = new X();
        X x2 = x1;
    }
}

[NonCopyable]
struct X { }
