using System;
using System.Collections.Generic;
using System.Linq;
using Generator.Model;

namespace Generator.Renderer.Internal;

internal static class Constructors
{
    public static string Render(IEnumerable<GirModel.Constructor> constructors)
    {
        return constructors
            .Select(Render)
            .Join(Environment.NewLine);
    }

    private static string Render(GirModel.Constructor? constructor)
    {
        if (constructor is null)
            return string.Empty;

        try
        {
            return @$"
{DocComments.Render($"Calls native constructor {constructor.CIdentifier}.", DocComments.RenderVersion(constructor.Version))}
{DocComments.Render(constructor.Parameters)}
{DocComments.Render(constructor.ReturnType)}
{VersionAttribute.Render(constructor.Version)}
[DllImport(ImportResolver.Library, EntryPoint = ""{constructor.CIdentifier}"")]
public static extern {ReturnTypeRenderer.Render(constructor.ReturnType)} {Constructor.GetName(constructor)}({Parameters.Render(constructor.Parameters)}{Error.Render(constructor)});";
        }
        catch (Exception e)
        {
            Log.Warning($"Did not generate constructor '{Constructor.GetName(constructor)}' / '{constructor.CIdentifier}': {e.Message}");

            return string.Empty;
        }
    }
}
