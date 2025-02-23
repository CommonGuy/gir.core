using System.Xml.Serialization;

namespace GirLoader.Input;

public class Method
{
    [XmlAttribute("name")]
    public string? Name { get; set; }

    [XmlAttribute("identifier", Namespace = "http://www.gtk.org/introspection/c/1.0")]
    public string? Identifier { get; set; }

    [XmlAttribute("throws")]
    public bool Throws { get; set; }

    [XmlAttribute("deprecated")]
    public bool Deprecated { get; set; }

    [XmlAttribute("deprecated-version")]
    public string? DeprecatedVersion { get; set; }

    [XmlElement("return-value")]
    public ReturnValue? ReturnValue { get; set; }

    [XmlElement("doc")]
    public Doc? Doc { get; set; }

    [XmlElement("doc-deprecated")]
    public Doc? DocDeprecated { get; set; }

    [XmlElement("parameters")]
    public Parameters? Parameters { get; set; }

    [XmlAttribute("moved-to")]
    public string? MovedTo { get; set; }

    [XmlAttribute("shadows")]
    public string? Shadows { get; set; }

    [XmlAttribute("shadowed-by")]
    public string? ShadowedBy { get; set; }

    [XmlAttribute("introspectable")]
    public bool Introspectable = true;

    [XmlAttribute("get-property", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
    public string? GetProperty { get; set; }

    [XmlAttribute("set-property", Namespace = "http://www.gtk.org/introspection/glib/1.0")]
    public string? SetProperty { get; set; }

    [XmlAttribute("version")]
    public string? Version { get; set; }

    public override string? ToString()
        => Name ?? Identifier ?? base.ToString();
}
