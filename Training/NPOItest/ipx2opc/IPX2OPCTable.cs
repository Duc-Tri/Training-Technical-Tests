using NPOI.SS.UserModel;

public abstract class IPX2OPCTable
{
    protected ISheet npoiSheet; // useful ?
    protected SheetWrapper sheetWrapper;

    protected string TableName { get; set; }

    public abstract void ConvertIPX2OPC();

    public IPX2OPCTable(ISheet sheet)
    {
        npoiSheet = sheet;
        sheetWrapper = new SheetWrapper(sheet);
    }

    public IPX2OPCTable(SheetWrapper sw)
    {
        sheetWrapper = sw;
        npoiSheet = sheetWrapper.sheet;
    }


    private static string ConvertRTUName(string modbusName)
    {
        // RTU : _IPX_ -> _OPC_
        string opcName = modbusName.Replace("_IPX_", "_OPC_");

        // add 10 to _R
        int index_R = opcName.LastIndexOf("_R");

        // tryParse ?
        int num = int.Parse(opcName.Substring(index_R + 2, opcName.Length - index_R - 2));
        opcName = opcName.Substring(0, index_R + 2) + (num + 10);

        Console.WriteLine($"ConvertRTUName # old new modbusName=[{modbusName}] opcName=[{opcName}]");

        return opcName;
    }

    protected void ConvertMainNames(string RTUcolumn)
    {
        List<ICell> cellsRTU = sheetWrapper.FindCellsByLabel(RTUcolumn);
        Console.WriteLine("cellsRTU : " + cellsRTU.Count);
        foreach (var c in cellsRTU)
        {
            c.SetCellValue(IPX2OPCTable.ConvertRTUName(c.StringCellValue));
            Console.WriteLine("cell rtu # " + c.StringCellValue);
        }
    }

    protected void SetValueToColumn(string columnName, int value)
    {
        List<ICell> cells = sheetWrapper.FindCellsByLabel(columnName);
        Console.WriteLine("columnName : " + columnName + " #" + cells.Count);
        foreach (var c in cells)
        {
            c.SetCellValue(value);
            Console.WriteLine("cell # " + c.NumericCellValue);
        }
    }

    protected void SetValueToColumn(string columnName, string value)
    {
        List<ICell> cells = sheetWrapper.FindCellsByLabel(columnName);
        Console.WriteLine("columnName : " + columnName + " #" + cells.Count);
        foreach (var c in cells)
        {
            c.SetCellValue(value);
            Console.WriteLine("cell # " + c.StringCellValue);
        }
    }

}