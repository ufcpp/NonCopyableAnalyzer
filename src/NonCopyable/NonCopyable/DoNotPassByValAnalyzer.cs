using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NonCopyable
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DoNotPassByValAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "NoCopy03";
        internal const string Title = "pass-by-value causes copy";
        internal const string MessageFormat = "The parameter type of '{0}' can't be non-copyable";
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

            foreach (var param in m.Parameters)
            {
                if (param.RefKind != RefKind.None && param.RefKind != RefKind.Out) continue;

                var t = param.Type;

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
                        var node = param.DeclaringSyntaxReferences.First().GetSyntax();
                        var diagnostic = Diagnostic.Create(Rule, node.GetLocation(), param.Name);
                        context.ReportDiagnostic(diagnostic);
                    }
                }
            }
        }
    }
}
