using System;

namespace NonCopyable.Test.TestTypes
{
    [AttributeUsage(AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public class NonCopyableAttribute : Attribute
    {
    }
}
