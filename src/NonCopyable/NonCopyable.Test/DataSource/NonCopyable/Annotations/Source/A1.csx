class Class1
{
    static void Main()
    {
        var c1 = new A1();
        var c2 = c1;
    }
}

[NonCopyable]
struct A1
{
}
