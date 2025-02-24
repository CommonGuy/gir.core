using System;
using System.IO;
using System.Xml.Serialization;

namespace GirLoader;

public static class StreamExtension
{
    public static Input.Repository DeserializeGirInputModel(this Stream stream)
    {
        var serializer = new XmlSerializer(
            type: typeof(Input.Repository),
            defaultNamespace: "http://www.gtk.org/introspection/core/1.0");

        var repository = (Input.Repository?) serializer.Deserialize(stream);

        if (repository is null)
            throw new Exception($"Could not deserialize from stream.");

        if (repository.Namespace == null)
            throw new Exception($"Repository does not define a namespace.");

        return repository;
    }
}
