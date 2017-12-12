using Microsoft.CodeAnalysis.Diagnostics;
using TestHelper;
using Xunit;

namespace NonCopyable.Test
{
    public class DoNotRetrunByVal : ConventionCodeFixVerifier
    {
        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer() => new DoNotRetrunByValAnalyzer();

        [Fact] public void RefMethod() => VerifyCSharpByConvention();
        [Fact] public void RefProperty() => VerifyCSharpByConvention();
        [Fact] public void Method() => VerifyCSharpByConvention();
        [Fact] public void Property() => VerifyCSharpByConvention();
    }
}
