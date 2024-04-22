using System.Xml.Serialization;

//[XmlRoot("DataSetTables"), XmlType("DataSetTables")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.telvent.com/DataSetSchema", IsNullable = false)]
public class DataSetTables
{
    //public List<DataSetTable> dataSetTables=new List<DataSetTable>();
    [XmlElement("DataSetTable")]
    public DataSetTable[] dataSetTables;

}
