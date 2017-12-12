using Microsoft.CodeAnalysis.Diagnostics;
using TestHelper;
using Xunit;

namespace NonCopyable.Test
{
    public class NonCopyableUnitTests : ConventionCodeFixVerifier
    {
        [Fact]
        public void EmptySource() => VerifyCSharpByConvention();

        [Fact]
        public void LowercaseLetters() => VerifyCSharpByConvention();

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer() => new NonCopyableAnalyzer();
    }
}
