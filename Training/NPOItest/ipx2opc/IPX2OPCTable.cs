using NPOI.SS.UserModel;

public abstract class IPX2OPCTable
{
    protected ISheet npoiSheet;

    protected string TableName { get; set; }


    public abstract void ConvertIPX2OPC();

    public IPX2OPCTable(ISheet sheet)
    {
        npoiSheet = sheet;
    }


}