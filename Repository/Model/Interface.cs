﻿using System.Collections.Generic;
using System.Linq;
using Repository.Analysis;

namespace Repository.Model
{
    public class Interface : Type
    {
        public Interface(Namespace @namespace, string nativeName, string managedName) : base(@namespace, nativeName, managedName)
        {
        }

        public override IEnumerable<ISymbolReference> GetSymbolReferences()
            => Enumerable.Empty<ISymbolReference>();
    }
}
