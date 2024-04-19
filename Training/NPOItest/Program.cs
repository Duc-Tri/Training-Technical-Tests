using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

Console.WriteLine("OASYS DBEdit XML reader =================================");

DBEditSchemaWrapper.TestXMLDBEditSchema();


Console.WriteLine("NPOI tests ==============================================");

NPOITest.ReadExcel("ExcelOutput.xlsx");
NPOITest.TestWriteSomeCellsToExcel("ExcelOutput.xlsx");
NPOITest.ReadExcel("emprise_poisson.xlsx", "analog");


Console.WriteLine("ipx2opc tests ==============================================");

XSSFWorkbook xssfWorkbook = NPOITest.ReadExcel("emprise_poisson.xlsx");
SheetWrapper sheetAnalog = new SheetWrapper(xssfWorkbook, "analog");
IPX2OPCAnalog ipx2opcAnalog = new IPX2OPCAnalog(sheetAnalog.sheet);

ipx2opcAnalog.ConvertIPX2OPC();
NPOITest.WriteExcel(xssfWorkbook, "output_OPC_emprise_poisson.xlsx");