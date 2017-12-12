using Microsoft.CodeAnalysis.Diagnostics;
using TestHelper;
using Xunit;

namespace NonCopyable.Test
{
    public class DoNotUseReadOnlyField : ConventionCodeFixVerifier
    {
        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer() => new DoNotUseReadOnlyFieldAnalyzer();

        [Fact] public void NoError() => VerifyCSharpByConvention();
        [Fact] public void Error1() => VerifyCSharpByConvention();
        [Fact] public void Error2() => VerifyCSharpByConvention();
        [Fact] public void Error3() => VerifyCSharpByConvention();
        [Fact] public void Error4() => VerifyCSharpByConvention();
        [Fact] public void Error5() => VerifyCSharpByConvention();
        [Fact] public void Error6() => VerifyCSharpByConvention();
    }
}
