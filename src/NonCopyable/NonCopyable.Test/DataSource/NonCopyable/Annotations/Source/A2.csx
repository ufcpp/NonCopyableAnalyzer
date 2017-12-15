class Class1
{
    static void Main()
    {
        var c1 = new A2();
        var c2 = c1;
    }
}

[X.NonCopyable]
struct A2
{
}
