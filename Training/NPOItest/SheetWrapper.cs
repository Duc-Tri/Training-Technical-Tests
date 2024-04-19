using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

public sealed class SheetWrapper
{
    public ISheet sheet;

    // headrow
    IRow headerRow;
    public string tabName;

    // 
    public SheetWrapper(ISheet s)
    {
        sheet = s;
        headerRow = s.GetRow(0);
        Console.WriteLine(headerRow.FirstCellNum + " * " + headerRow.LastCellNum);
    }

    public SheetWrapper(XSSFWorkbook xlsxFile, string tn) : this(xlsxFile.GetSheet(tn))
    {
        tabName = tn;
    }

    public List<ICell> FindCellsByLabel(string label)
    {
        List<ICell> cells = null;
        foreach (var c in headerRow.Cells)
        {
            if (c.StringCellValue.Equals(label)) // lower case ?
            {
                int cIndex = c.ColumnIndex;
                cells = new List<ICell>();
                for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {
                    cells.Add(sheet.GetRow(i).GetCell(cIndex));
                }
            }
        }

        return cells;
    }

}