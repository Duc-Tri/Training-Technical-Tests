Console.WriteLine("NPOI tests ====================");

NPOITest.ReadExcel("ExcelOutput.xlsx");

NPOITest.WriteExcel("ExcelOutput.xlsx");

NPOITest.ReadExcel("emprise_poisson.xlsx", "grt_installation");

Console.WriteLine("OASYS DBEdit XML reader ====================");

DBEditSchemaWrapper.TestXMLDBEditSchema();