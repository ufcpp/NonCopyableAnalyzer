using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using TestHelper;
using Xunit;
using NonCopyable;

namespace NonCopyable.Test
{
    public class NonCopyableUnitTests : ConventionCodeFixVerifier
    {
        [Fact]
        public void EmptySource() => VerifyCSharpByConvention();

        [Fact]
        public void LowercaseLetters() => VerifyCSharpByConvention();

        protected override CodeFixProvider GetCSharpCodeFixProvider() => new NonCopyableCodeFixProvider();

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer() => new NonCopyableAnalyzer();
    }
}
