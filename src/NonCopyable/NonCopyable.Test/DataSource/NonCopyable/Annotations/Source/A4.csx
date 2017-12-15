class Class1
{
    static void Main()
    {
        var c1 = new A4();
        var c2 = c1;
    }
}

[NonCopyableAttribute]
struct A4
{
}
