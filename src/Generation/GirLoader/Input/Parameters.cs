using System.Collections.Generic;
using System.Xml.Serialization;

namespace GirLoader.Input;

public class Parameters
{
    [XmlElement("instance-parameter")]
    public InstanceParameterInfo? InstanceParameter { get; set; }

    [XmlElement("parameter")]
    public List<Parameter> List { get; set; } = default!;
}
