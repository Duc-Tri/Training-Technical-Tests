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

IPX2OPCAnalog ipx2opcAnalog = new IPX2OPCAnalog(new SheetWrapper(xssfWorkbook, "analog"));
ipx2opcAnalog.ConvertIPX2OPC();

IPX2OPCRemote ipx2opcRemote = new IPX2OPCRemote(new SheetWrapper(xssfWorkbook, "remote"));
ipx2opcRemote.ConvertIPX2OPC();

NPOITest.WriteExcel(xssfWorkbook, "output_OPC_emprise_poisson.xlsx");