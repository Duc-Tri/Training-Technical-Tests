using System.Xml.Serialization;

[XmlType("DataSetTable")]
public class DataSetTable
{
    [XmlAttribute]
    public string Name;

    [XmlAttribute]
    public string Description;

    [XmlElement("Field")]
    public Field[] fields;

}