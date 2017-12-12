using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NonCopyable
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DoNotUseReadOnlyFieldAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "NoCopy01";
        internal const string Title = "readonly field causes copy";
        internal const string MessageFormat = "The type of the readonly field '{0}' can't be non-copyable";
        internal const string Category = "Correction";

        internal static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Error, isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeFiedlDeclaration, SymbolKind.Field);
        }

        private void AnalyzeFiedlDeclaration(SymbolAnalysisContext context)
        {
            var f = (IFieldSymbol)context.Symbol;

            if (!f.IsReadOnly)
                return;

            var t = f.Type;

            if (t.IsNonCopyable())
            {
                var node = f.DeclaringSyntaxReferences.First().GetSyntax();
                var diagnostic = Diagnostic.Create(Rule, node.GetLocation(), f.Name);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
