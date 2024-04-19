using NPOI.SS.UserModel;

public class IPX2OPCanalog : IPX2OPCTable
{
    public IPX2OPCanalog(ISheet sheet) : base(sheet)
    {
        TableName = "analaog";
    }

    // Parse all data 
    public override void ConvertIPX2OPC()
    {
        // rtu : IPX -> OPC, add 10



    }
}