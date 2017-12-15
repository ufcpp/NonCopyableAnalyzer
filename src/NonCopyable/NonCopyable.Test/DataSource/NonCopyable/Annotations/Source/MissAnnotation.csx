using NonCopyable = System.Attribute;

class Class1
{
    static void Main()
    {
        var c1 = new MissAnnotation();
        var c2 = c1;
    }
}

//todo: This "NonCopyable" is an alias and not actually NonCopyable attribute. However this struct is treated as a NonCopyable type.
[NonCopyable]
struct MissAnnotation
{
}
