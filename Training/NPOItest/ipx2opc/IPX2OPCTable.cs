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
    }

    public static string ConvertRTUName(string modbusName)
    {
        string opcName = modbusName.Replace("_IPX_", "_OPC_");
        int indexR = opcName.LastIndexOf("_R");
        
        // tryParse ?
        int num = int.Parse(opcName.Substring(indexR + 2, opcName.Length - indexR - 2));
        opcName = opcName.Substring(0, indexR) + (num + 10);
        Console.WriteLine($"ConvertRTUName # old new modbusName=[{modbusName}] opcName=[{opcName}]");

        return opcName;
    }

}