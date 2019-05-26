using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

[AttributeUsage(AttributeTargets.Struct)]
internal class NonCopyableAttribute : Attribute { }

[NonCopyable]
struct X
{
    public void M() { }
}

class Program
{
    static void Main()
    {
        var x = new X();
        Action m = x.M;
        Action m1 = Main;
    }
}