﻿using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Gir.Integration.CSharp.Gtk;

internal class CompositeTemplateGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new CompositeTemplateSyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext context)
    {
        if (!TryGetClassDeclarationSyntax(context, out ClassDeclarationSyntax? classDeclarationSyntax))
            return;

        object dataProvider = GetDataProvider(classDeclarationSyntax, context.Compilation);
        var template = GetTemplate(dataProvider);

        AddTemplateSourceToContext(context, template);
    }

    private static bool TryGetClassDeclarationSyntax(GeneratorExecutionContext context, [NotNullWhen(true)] out ClassDeclarationSyntax? classDeclarationSyntax)
    {
        var syntaxReceiver = context.SyntaxReceiver as CompositeTemplateSyntaxReceiver;
        classDeclarationSyntax = syntaxReceiver?.TemplateClass;

        return classDeclarationSyntax is not null;
    }

    private static object GetDataProvider(ClassDeclarationSyntax classDeclarationSyntax, Compilation compilation)
    {
        return new CompositeTemplateDataProvider(classDeclarationSyntax, compilation);
    }

    private static string GetTemplate(object dataProvider)
    {
        var templateProvider = new TemplateProvider();
        return templateProvider.Get("composite_template.sbntxt", dataProvider);
    }

    private static void AddTemplateSourceToContext(GeneratorExecutionContext context, string template)
    {
        context.AddSource("generated.cs", SourceText.From(template, Encoding.UTF8));
    }
}
