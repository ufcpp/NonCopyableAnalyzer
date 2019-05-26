using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using TestHelper;
using Xunit;

namespace NonCopyable.Test
{
    public class NonCopyable : ConventionCodeFixVerifier
    {
        [Fact] public void EmptySource() => VerifyCSharpByConvention();
        [Fact] public void Argument() => VerifyCSharpByConvention();
        [Fact] public void Return() => VerifyCSharpByConvention();
        [Fact] public void Property() => VerifyCSharpByConvention();
        [Fact] public void Conversion() => VerifyCSharpByConvention();
        [Fact] public void Assignment() => VerifyCSharpByConvention();
        [Fact] public void SymbolInitialize() => VerifyCSharpByConvention();
        [Fact] public void Invocation() => VerifyCSharpByConvention();
        [Fact] public void ObjectInitializer() => VerifyCSharpByConvention();
        [Fact] public void DeclPattern() => VerifyCSharpByConvention();
        [Fact] public void Operator() => VerifyCSharpByConvention();
        [Fact] public void ReadOnly() => VerifyCSharpByConvention();
        [Fact] public void Annotations() => VerifyCSharpByConvention();
        [Fact] public void This() => VerifyCSharpByConvention();
        [Fact] public void Nest() => VerifyCSharpByConvention();
        [Fact] public void Generics() => VerifyCSharpByConvention();
        [Fact] public void Interface() => VerifyCSharpByConvention();
        [Fact] public void DifferentAssembly() => VerifyCSharpByConvention();
        [Fact] public void VoidReturn() => VerifyCSharpByConvention();

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer() => new NonCopyableAnalyzer();

        protected override IEnumerable<MetadataReference> References
        {
            get
            {
                foreach (var r in base.References) yield return r;
                yield return MetadataReference.CreateFromFile(GetType().Assembly.Location);
            }
        }
    }
}
