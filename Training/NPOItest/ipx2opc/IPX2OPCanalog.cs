using NPOI.SS.UserModel;

public class IPX2OPCanalog : IPX2OPCTable
{

    public IPX2OPCanalog(ISheet sheet) : base(sheet)
    {
        TableName = "analaog";
        sheetWrapper = new SheetWrapper(sheet);
    }

    // Parse all data 
    public override void ConvertIPX2OPC()
    {
        // rtu : IPX -> OPC, add 10
        List<ICell> cellsRTU = sheetWrapper.FindCellsByLabel("RTU");
        Console.WriteLine("cellsRTU : " + cellsRTU.Count);
        foreach (var c in cellsRTU)
        {
            Console.WriteLine("cell # " + c.StringCellValue);
            IPX2OPCTable.ConvertRTUName(c.StringCellValue);
        }

    }


}