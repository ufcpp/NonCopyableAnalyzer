using Microsoft.CodeAnalysis.Diagnostics;
using TestHelper;
using Xunit;

namespace NonCopyable.Test
{
    public class NonCopyable : ConventionCodeFixVerifier
    {
        [Fact] public void EmptySource() => VerifyCSharpByConvention();
        [Fact] public void Argument() => VerifyCSharpByConvention();
        [Fact] public void Conversion() => VerifyCSharpByConvention();
        [Fact] public void Assignment() => VerifyCSharpByConvention();
        [Fact] public void SymbolInitialize() => VerifyCSharpByConvention();
        [Fact] public void Invocation() => VerifyCSharpByConvention();
        [Fact] public void ObjectInitializer() => VerifyCSharpByConvention();

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer() => new NonCopyableAnalyzer();
    }
}
