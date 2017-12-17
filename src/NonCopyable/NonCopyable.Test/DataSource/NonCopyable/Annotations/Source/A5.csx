class Class1
{
    static void Main()
    {
        var c1 = new A5();
        var c2 = c1; // ❌
    }
}

[X.NonCopyableAttribute]
struct A5
{
}
