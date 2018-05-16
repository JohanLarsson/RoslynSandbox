namespace AnalyzerBox
{
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Diagnostics;

    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class PropertyAnalyzer : DiagnosticAnalyzer
    {
        public static readonly DiagnosticDescriptor Descriptor = new DiagnosticDescriptor(
            id: "TEST",
            title: "Key does not exist.",
            messageFormat: "Key does not exist.",
            category: "TEST",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Key does not exist.");

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(
            Descriptor);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(
                c =>
                    c.ReportDiagnostic(
                        Diagnostic.Create(
                            Descriptor,
                            ((PropertyDeclarationSyntax)c.Node).Identifier.GetLocation())),
                SyntaxKind.PropertyDeclaration);
        }
    }
}
