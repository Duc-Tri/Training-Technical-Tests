using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

Console.WriteLine("NPOI tests ==============================================");

NPOITest.ReadExcel("ExcelOutput.xlsx");
NPOITest.TestWriteSomeCellsToExcel("ExcelOutput.xlsx");
NPOITest.ReadExcel("ExcelInput.xlsx", "analog");

Console.WriteLine("ipx2opc tests ==============================================");

XSSFWorkbook xssfWorkbook = NPOITest.ReadExcel("emprise_poisson.xlsx");

if (xssfWorkbook != null)
{
    NPOITest.WriteExcel(xssfWorkbook, "output_OPC_emprise_poisson.xlsx");
}
else
{
    Console.Error.WriteLine("XLS file is null");
}