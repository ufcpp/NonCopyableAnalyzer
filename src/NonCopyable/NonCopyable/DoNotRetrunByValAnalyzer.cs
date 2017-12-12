using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NonCopyable
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DoNotRetrunByValAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "NoCopy02";
        internal const string Title = "return-by-value causes copy";
        internal const string MessageFormat = "The return type of '{0}' can't be non-copyable";
        internal const string Category = "Correction";

        internal static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Error, isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeFiedlDeclaration, SymbolKind.Method);
        }

        private void AnalyzeFiedlDeclaration(SymbolAnalysisContext context)
        {
            var m = (IMethodSymbol)context.Symbol;

            if (m.ReturnsByRef) return;

            var t = m.ReturnType;

            if (t.IsNonCopyable())
            {
                if (m.AssociatedSymbol is IPropertySymbol p)
                {
                    var node = p.DeclaringSyntaxReferences.First().GetSyntax();
                    var diagnostic = Diagnostic.Create(Rule, node.GetLocation(), p.Name);
                    context.ReportDiagnostic(diagnostic);
                }
                else
                {
                    var node = m.DeclaringSyntaxReferences.First().GetSyntax();
                    var diagnostic = Diagnostic.Create(Rule, node.GetLocation(), m.Name);
                    context.ReportDiagnostic(diagnostic);
                }
            }
        }
    }
}
