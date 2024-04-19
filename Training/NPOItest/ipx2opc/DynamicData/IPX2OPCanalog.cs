using NPOI.SS.UserModel;

public class IPX2OPCAnalog : IPX2OPCTable
{

    public IPX2OPCAnalog(ISheet sheet) : base(sheet)
    {
        TableName = "analog";
        sheetWrapper = new SheetWrapper(sheet);
    }

    // Parse all data 
    public override void ConvertIPX2OPC()
    {
        // tab Principale
        ConvertMODBUSNames();

        // tab Entrée
        ConvertMODBUSRegisters();
    }

    private void ConvertMODBUSRegisters()
    {
        // look for "Configurer l'entree (oui?)"
        List<ICell> cConfig = sheetWrapper.FindCellsByLabel("Configurer l'entree (oui?)");
        List<ICell> cInputAddress = sheetWrapper.FindCellsByLabel("Adresse de l'entree");
        for (int i = cConfig.Count - 1; i >= 0; i--)
        {
            if (cConfig[i].StringCellValue.Equals("yes"))
            {
                cInputAddress[i].SetCellValue("1:ns=3;s=RTU/TR_x");
                Console.WriteLine("cell address # " + cInputAddress[i].StringCellValue);
            }
        }
    }

    private void ConvertMODBUSNames()
    {
        // rtu : IPX -> OPC, add 10
        List<ICell> cellsRTU = sheetWrapper.FindCellsByLabel("RTU");
        Console.WriteLine("cellsRTU : " + cellsRTU.Count);
        foreach (var c in cellsRTU)
        {
            c.SetCellValue(IPX2OPCTable.ConvertRTUName(c.StringCellValue));
            Console.WriteLine("cell rtu # " + c.StringCellValue);
        }
    }

}