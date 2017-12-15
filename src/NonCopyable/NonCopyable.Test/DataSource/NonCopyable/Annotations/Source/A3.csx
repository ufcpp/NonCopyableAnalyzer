namespace X
{
    class Class1
    {
        static void Main()
        {
            var c1 = new A3();
            var c2 = c1;
        }
    }

    [NonCopyable]
    struct A3
    {
    }
}
