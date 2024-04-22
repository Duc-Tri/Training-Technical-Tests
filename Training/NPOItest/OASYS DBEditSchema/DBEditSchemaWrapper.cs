using System.Xml;
using System.Xml.Serialization;

public class DBEditSchemaWrapper
{
    private const string XML_FILE = "OASYS_DBEditSchema.xml";
    public static void TestXMLDBEditSchema()
    {
        // MARCHE PAS ---------------------
        //var xmlFile = new XmlTextReader(XML_FILE);
        //xmlFile.GetAttribute(0);
        //xmlFile.MoveToFirstAttribute();
        //xmlFile.MoveToNextAttribute();
        //Console.WriteLine(xmlFile.LocalName + xmlFile.Value);

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(XML_FILE);

        if (xmlDoc == null)
            return;

        XmlNode firstNode = xmlDoc.ChildNodes[0]; // DataSetTables
                                                  //string nodeName = firstNode.Name;

        XmlNode firstChildNode = firstNode.ChildNodes[0]; // DataSetTable
        if (firstChildNode == null)
            return;

        Console.WriteLine(" first node name = " + firstChildNode?.Name + " att = " + firstChildNode.Attributes["Name"].Value);

        //
        XmlSerializer serializer = new XmlSerializer(typeof(DataSetTables));
        DataSetTables dsTables;
        using (Stream reader = new FileStream(XML_FILE, FileMode.Open))
        {
            dsTables = (DataSetTables)serializer.Deserialize(reader);
            if (dsTables != null && dsTables.dataSetTables != null)
            {
                Console.WriteLine("nb=" + dsTables.dataSetTables.Length);
                foreach (var dst in dsTables.dataSetTables)
                {
                    Console.WriteLine($"DST name=[{dst.Name}] description=[{dst.Description}]");
                    if (dst.fields != null)
                    {
                        Console.WriteLine("\t==== FIELDS=" + dst.fields.Length);
                        foreach (var f in dst.fields)
                        {
                            Console.WriteLine($"\t\tfield name=[{f.Name}] rowlabel=[{f.RowLabel}]");
                        }
                    }
                }
            }

        }
    }

}