using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;

namespace NonCopyable
{
    public static class TypeExtensions
    {
        public static bool IsNonCopyable(this ITypeSymbol t)
        {
            if (t == null) return false;
            if (t.TypeKind != TypeKind.Struct && t.TypeKind != TypeKind.TypeParameter) return false;

            foreach (var decl in t.DeclaringSyntaxReferences)
            {
                var list = decl.GetSyntax().GetAttributes();
                if (list.Count == 0) return false;

                foreach (var al in list)
                {
                    foreach (var a in al.Attributes)
                    {
                        var str = a.ToString();
                        if (str.EndsWith("NonCopyable") || str.EndsWith("NonCopyableAttribute")) return true;
                    }
                }
            }

            return false;
        }

        private static SyntaxList<AttributeListSyntax> GetAttributes(this SyntaxNode syntax)
        {
            switch (syntax)
            {
                case StructDeclarationSyntax s:
                    return s.AttributeLists;
                case TypeParameterSyntax s:
                    return s.AttributeLists;
                default:
                    return default;
            }
        }
    }
}
