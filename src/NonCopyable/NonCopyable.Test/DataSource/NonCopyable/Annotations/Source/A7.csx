class Class1
{
    static void Main()
    {
        var c1 = new A7();
        var c2 = c1; // ❌
    }
}

[global::NonCopyable]
struct A7
{
}
