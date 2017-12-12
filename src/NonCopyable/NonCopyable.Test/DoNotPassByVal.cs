using Microsoft.CodeAnalysis.Diagnostics;
using TestHelper;
using Xunit;

namespace NonCopyable.Test
{
    public class DoNotPassByVal : ConventionCodeFixVerifier
    {
        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer() => new DoNotPassByValAnalyzer();

        [Fact] public void RefMethod() => VerifyCSharpByConvention();
        [Fact] public void Method() => VerifyCSharpByConvention();
        [Fact] public void Property() => VerifyCSharpByConvention();
        [Fact] public void Operator() => VerifyCSharpByConvention();
        [Fact] public void ExtensionMethod() => VerifyCSharpByConvention();
    }
}
