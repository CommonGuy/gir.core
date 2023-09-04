﻿using Generator.Model;

namespace Generator.Generator.Public;

internal class RecordClass : Generator<GirModel.Record>
{
    private readonly Publisher _publisher;

    public RecordClass(Publisher publisher)
    {
        _publisher = publisher;
    }

    public void Generate(GirModel.Record record)
    {
        if (!Record.IsStandard(record))
            return;

        var source = Renderer.Public.RecordClass.Render(record);
        var codeUnit = new CodeUnit(
            Project: Namespace.GetCanonicalName(record.Namespace),
            Name: Record.GetPublicClassName(record),
            Source: source,
            IsInternal: false
        );

        _publisher.Publish(codeUnit);
    }
}
