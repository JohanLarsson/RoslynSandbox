namespace AnalyzerBox
{
    using System.Collections.Immutable;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CodeActions;
    using Microsoft.CodeAnalysis.CodeFixes;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public class ReverseNameFix : CodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds { get; } = ImmutableArray.Create(
            PropertyAnalyzer.Descriptor.Id);

        public sealed override FixAllProvider GetFixAllProvider() => null;

        public override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
            foreach (var diagnostic in context.Diagnostics)
            {
                var node = (IdentifierNameSyntax)root.FindNode(diagnostic.Location.SourceSpan);
                context.RegisterCodeFix(
                    CodeAction.Create(
                        "Reverse name",
                        _ => Task.FromResult(
                            context.Document.WithSyntaxRoot(
                                root.ReplaceNode(
                                    node,
                                    node.WithIdentifier(
                                        SyntaxFactory.ParseToken(
                                            new string(
                                                node.Identifier.ValueText.ToCharArray()
                                                    .Reverse()
                                                    .ToArray()))))))),
                    diagnostic);
            }
        }
    }
}