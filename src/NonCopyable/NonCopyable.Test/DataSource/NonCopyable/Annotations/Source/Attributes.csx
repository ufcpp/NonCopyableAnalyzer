using System;

[AttributeUsage(AttributeTargets.Struct)]
internal class NonCopyableAttribute : Attribute { }

namespace X
{
    [AttributeUsage(AttributeTargets.Struct)]
    internal class NonCopyableAttribute : Attribute { }
}
