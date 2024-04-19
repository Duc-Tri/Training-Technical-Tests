using NPOI.XSSF.UserModel;

Console.WriteLine("OASYS DBEdit XML reader ====================");

DBEditSchemaWrapper.TestXMLDBEditSchema();

Console.WriteLine("NPOI tests ====================");

NPOITest.ReadExcel("ExcelOutput.xlsx");

NPOITest.WriteExcel("ExcelOutput.xlsx");

NPOITest.ReadExcel("emprise_poisson.xlsx", "analog");

XSSFWorkbook xssfWorkbook = NPOITest.ReadExcel("emprise_poisson.xlsx");

SheetWrapper sheetAnalog = new SheetWrapper(xssfWorkbook, "analog");


