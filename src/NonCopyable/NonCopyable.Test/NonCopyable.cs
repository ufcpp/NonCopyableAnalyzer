using Microsoft.CodeAnalysis.Diagnostics;
using TestHelper;
using Xunit;

namespace NonCopyable.Test
{
    public class NonCopyable : ConventionCodeFixVerifier
    {
        [Fact] public void EmptySource() => VerifyCSharpByConvention();
        [Fact] public void LowercaseLetters() => VerifyCSharpByConvention();
        [Fact] public void Argument() => VerifyCSharpByConvention();
        [Fact] public void Conversion() => VerifyCSharpByConvention();

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer() => new NonCopyableAnalyzer();
    }
}
