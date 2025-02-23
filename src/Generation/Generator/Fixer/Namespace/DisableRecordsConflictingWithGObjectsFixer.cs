using System;
using System.Collections.Generic;
using System.Linq;

namespace Generator.Fixer.Ns;

internal class DisableRecordsConflictingWithGObjectsFixer : Fixer<GirModel.Namespace>
{
    public void Fixup(GirModel.Namespace ns)
    {
        //If platform dependent classes / interfaces are not supported on a platform
        //but part of the platform's gir file a record is generated as a placeholder. 
        //To avoid generating the same type twice the placeholder record gets disabled.

        var supportedTypes = ns.Classes.Union<GirModel.ComplexType>(ns.Interfaces);

        var unsupportedRecords = ns.Records
            .Intersect(supportedTypes, new ComplexTypeComparer())
            .Cast<GirModel.Record>();

        foreach (var record in unsupportedRecords)
            Model.Record.Disable(record);
    }

    private class ComplexTypeComparer : IEqualityComparer<GirModel.ComplexType>
    {
        public bool Equals(GirModel.ComplexType? x, GirModel.ComplexType? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (ReferenceEquals(x, null))
                return false;

            if (ReferenceEquals(y, null))
                return false;

            return x.Namespace.Name.Equals(y.Namespace.Name) && x.Name == y.Name;
        }

        public int GetHashCode(GirModel.ComplexType obj)
        {
            return HashCode.Combine(obj.Namespace.Name, obj.Name);
        }
    }
}
