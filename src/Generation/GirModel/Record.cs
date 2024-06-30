﻿using System.Collections.Generic;

namespace GirModel;

public interface Record : ComplexType
{
    Function? TypeFunction { get; }
    Method? CopyFunction { get; }
    Method? FreeFunction { get; }
    IEnumerable<Function> Functions { get; }
    IEnumerable<Method> Methods { get; }
    IEnumerable<Constructor> Constructors { get; }
    IEnumerable<Field> Fields { get; }
    bool Introspectable { get; }
    bool Foreign { get; }
    bool Opaque { get; }
    bool Pointer { get; }
}
