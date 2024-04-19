using NPOI.SS.UserModel;

public class IPX2OPCRemote : IPX2OPCTable
{
    public IPX2OPCRemote(SheetWrapper sheet) : base(sheet)
    {
        TableName = "remote";
    }

    public override void ConvertIPX2OPC()
    {
        Console.WriteLine("########## CONVERSION OF " + TableName);

        // tab Principale
        ConvertMainNames("name");

        // tab Scrutation
        ConvertScrutation();

        // tab Programmateur RTU
        ConvertProgrammateurRTU();

        // tab Configuration des applications gaz
        ConvertConfigurationApplicationsGaz();

        // tab Gestion des alarmes
        ConvertGestionAlarmes();

        // tab CGL
        ConvertCGL();
    }

    private void ConvertScrutation()
    {
        //  process column "Duree d'une scrutation acceleree (sec)"
        SetValueToColumn("Duree d'une scrutation acceleree (sec)", 1);

        //  process column "Delai alarme non reponse RTU(sec"
        SetValueToColumn("Delai alarme non reponse RTU(sec", 2);

        //  process column "Illegal Msg Timeout (sec)"
        SetValueToColumn("Illegal Msg Timeout (sec)", 0);

        //  process column "Delai avant la scrutation(HH:MM:SS)"
        SetValueToColumn("Delai avant la scrutation(HH:MM:SS)", "00:00:10");

        //  process column "Delai sup sur non reponse RTU(HH:MM:SS)"
        SetValueToColumn("Delai sup sur non reponse RTU(HH:MM:SS)", "00:00:30");

        //  process column "Nbre de scrutation pour ALM Retour normal"
        SetValueToColumn("Nbre de scrutation pour ALM Retour normal", 0);

        //  process column "Appel secours banque Modem"
        SetValueToColumn("Appel secours banque Modem", "");

        //  process column "RTU serie duree max d'une scrutation(ms)"
        SetValueToColumn("RTU serie duree max d'une scrutation(ms)", 60000);

        // process column "Duree process avant debut scrutation(ms)"
        SetValueToColumn("Duree process avant debut scrutation(ms)", 100);

        // process column "Reessais lies driver specifique protocole"
        SetValueToColumn("Reessais lies driver specifique protocole", 0);

    }

    private void ConvertCGL()
    {

    }

    private void ConvertGestionAlarmes()
    {

    }

    private void ConvertConfigurationApplicationsGaz()
    {

    }

    private void ConvertProgrammateurRTU()
    {

    }

}