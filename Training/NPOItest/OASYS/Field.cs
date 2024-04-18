using System.Xml.Serialization;

[XmlType("Field")]
public class Field
{
    [XmlAttribute]
    public string Name;

    [XmlAttribute]
    public string RowLabel;

    [XmlAttribute]
    public string ColumnLabel;

}