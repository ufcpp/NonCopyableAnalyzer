using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NonCopyable
{
    public static class TypeExtensions
    {
        public static bool IsNonCopyable(this ITypeSymbol t)
        {
            if (!t.IsValueType) return false;

            foreach (var decl in t.DeclaringSyntaxReferences)
            {
                if (!(decl.GetSyntax() is StructDeclarationSyntax s)) return false;

                foreach (var al in s.AttributeLists)
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
    }
}
