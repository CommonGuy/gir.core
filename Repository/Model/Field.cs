﻿using System;
using System.Collections.Generic;
using Repository.Analysis;

namespace Repository.Model
{
    public class Field : Symbol, Type
    {
        public SymbolReference SymbolReference { get; }
        
        public Callback? Callback { get; }
        public Array? Array { get; }
        public bool Readable { get; }
        public bool Private { get; }

        /// <summary>
        /// Creates a new field.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="managedName"></param>
        /// <param name="symbolReference"></param>
        /// <param name="array"></param>
        /// <param name="callback">Optional: If set it is expected that the callback belongs to the given symbol reference.</param>
        /// <param name="readable"></param>
        /// <param name="private"></param>
        public Field(string name, string managedName, SymbolReference symbolReference, Array? array = null, Callback? callback = null, bool readable = true, bool @private = false) : base(name, name, managedName, managedName)
        {
            SymbolReference = symbolReference;
            Array = array;
            Callback = callback;
            Readable = readable;
            Private = @private;

            TryResolveSymbolReference();
        }

        private void TryResolveSymbolReference()
        {
            if (Callback is null)
                return;

            SymbolReference.ResolveAs(Callback);
        }

        public override IEnumerable<SymbolReference> GetSymbolReferences()
        {
            // If the callback is not null this means the symbol reference
            // of this field was already resolved automatically. Meaning we
            // do not return the symbol reference to the caller but the
            // symbol references of the callback instead.
            //
            // If the callback is null the symbol reference is still unresolved
            // and must be returned to get resolved.
            
            if (Callback is not null)
                return Callback.GetSymbolReferences();
            else
                return new List<SymbolReference>() { SymbolReference };
        }

        internal override bool GetIsResolved()
            => SymbolReference.IsResolved && (Callback?.GetIsResolved() ?? true);
    }
}
