using NPOI.SS.UserModel;

public class IPX2OPCAnalog : IPX2OPCTable
{

    public IPX2OPCAnalog(SheetWrapper sheet) : base(sheet)
    {
        TableName = "analog";
    }

    public override void ConvertIPX2OPC()
    {
        Console.WriteLine("########## CONVERSION OF " + TableName);

        // tab Principale
        ConvertMainNames("RTU");

        // tab Entrée
        ConvertInputAddress();

        // tab Sortie
        ConvertOutputAddress();

        // tab OPCUA
        ConvertOPCUAFields();
    }

    private void ConvertOPCUAFields()
    {
        // code ISA ???
        List<ICell> cellsISA = sheetWrapper.FindCellsByLabel("Nature");

        // process column "Server Deadband"
        List<ICell> cellsServerDeadband = sheetWrapper.FindCellsByLabel("Server Deadband");

        // process column "Sample Interval (milliseconds)"
        List<ICell> cellsSampleInterval = sheetWrapper.FindCellsByLabel("Sample Interval (milliseconds)");

        // process column "Queue Size"
        List<ICell> cellsQueueSize = sheetWrapper.FindCellsByLabel("Queue Size");

        for (int i = cellsISA.Count - 1; i >= 0; i--)
        {
            Console.WriteLine("cell isa # " + cellsISA[i].StringCellValue);
            if (cellsISA[i].StringCellValue.Equals("TMP") ||
                cellsISA[i].StringCellValue.Equals("DBK2") ||
                cellsISA[i].StringCellValue.Equals("PAB"))
            {
                cellsServerDeadband[i].SetCellValue(0.1d); // use double, not float !!!
            }
            cellsSampleInterval[i].SetCellValue(50000);
            cellsQueueSize[i].SetCellValue(1);
        }
    }

    private void ConvertOutputAddress()
    {
        // process column "Configurer la sortie (oui?)"
        List<ICell> cellsConfig = sheetWrapper.FindCellsByLabel("Configurer la sortie (oui?)");

        List<ICell> cellsInputAddress = sheetWrapper.FindCellsByLabel("Adresse de la sortie");
        for (int i = cellsConfig.Count - 1; i >= 0; i--)
        {
            if (cellsConfig[i].StringCellValue.Equals("yes"))
            {
                cellsInputAddress[i].SetCellValue("1:ns=3;s=RTU/TR_x");
                Console.WriteLine("cell output address # " + cellsInputAddress[i].StringCellValue);
            }
        }
    }

    private void ConvertInputAddress()
    {
        // process column "Configurer l'entree (oui?)"
        List<ICell> cConfig = sheetWrapper.FindCellsByLabel("Configurer l'entree (oui?)");

        List<ICell> cInputAddress = sheetWrapper.FindCellsByLabel("Adresse de l'entree");
        for (int i = cConfig.Count - 1; i >= 0; i--)
        {
            if (cConfig[i].StringCellValue.Equals("yes"))
            {
                cInputAddress[i].SetCellValue("1:ns=3;s=RTU/TR_x");
                Console.WriteLine("cell input address # " + cInputAddress[i].StringCellValue);
            }
        }
    }


}