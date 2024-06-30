﻿using System.Collections.Generic;

namespace GirLoader.Output;

public partial class Record : GirModel.Record
{
    GirModel.Function? GirModel.Record.TypeFunction => GetTypeFunction;
    GirModel.Method? GirModel.Record.CopyFunction => CopyFunction;
    GirModel.Method? GirModel.Record.FreeFunction => FreeFunction;
    IEnumerable<GirModel.Function> GirModel.Record.Functions => Functions;
    IEnumerable<GirModel.Method> GirModel.Record.Methods => Methods;
    IEnumerable<GirModel.Constructor> GirModel.Record.Constructors => Constructors;
    IEnumerable<GirModel.Field> GirModel.Record.Fields => Fields;
    bool GirModel.Record.Introspectable => Introspectable;
    bool GirModel.Record.Foreign => Foreign;
    bool GirModel.Record.Opaque => Opaque;
    bool GirModel.Record.Pointer => Pointer;
}
