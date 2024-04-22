using System.Data;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Text.Json;
using System.Xml;

public static class NPOITest
{
    public static void ReadExcel(string filename, string sheetname = null)
    {
        DataTable dataTable = new DataTable();
        ISheet sheet;

        FileStream stream = null;
        try
        {
            stream = File.OpenRead(filename);
            if (stream == null || stream.Length < 1)
                return;

            stream.Position = 0;

            XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);

            sheet = (sheetname == null) ? xssWorkbook.GetSheetAt(0)
                                        : sheet = xssWorkbook.GetSheet(sheetname);

            IRow headerRow = sheet.GetRow(0);

            int cellCount = headerRow.LastCellNum;
            Console.Write("HEADER CELLS ");
            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    continue;

                dataTable.Columns.Add(cell.ToString());
                Console.Write($"{j}=[{cell}]");
            }
            Console.WriteLine();

            List<string> rowList = new List<string>();
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row == null || row.Cells.All(d => d.CellType == CellType.Blank))
                    continue;

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                    {
                        var cell_j = row.GetCell(j).ToString();
                        if (!string.IsNullOrEmpty(cell_j) && !string.IsNullOrWhiteSpace(cell_j))
                        {
                            rowList.Add(cell_j);
                            //Console.WriteLine($"CELL {i}:{j} = {cell_j}");
                            Console.Write($"{i}:{j}=[{cell_j}] / ");
                        }
                    }
                }
                Console.WriteLine();
                if (rowList.Count > 0)
                    dataTable.Rows.Add(rowList.ToArray());

                rowList.Clear();
            }

        }
        catch (Exception e)
        {

        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
    }

    public static XSSFWorkbook ReadExcel(string filename)
    {
        XSSFWorkbook xssWorkbook = null;
        DataTable dataTable = new DataTable();
        ISheet sheet;

        FileStream stream = null;
        try
        {
            stream = File.OpenRead(filename);
            if (stream == null || stream.Length < 1)
                return xssWorkbook;

            stream.Position = 0;
            xssWorkbook = new XSSFWorkbook(stream);
            sheet = xssWorkbook.GetSheetAt(0);
            IRow headerRow = sheet.GetRow(0);

            int cellCount = headerRow.LastCellNum;
            Console.Write("HEADER CELLS ");
            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    continue;

                dataTable.Columns.Add(cell.ToString());
                Console.Write($"{j}=[{cell}]");
            }
            Console.WriteLine();

            List<string> rowList = new List<string>();
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row == null || row.Cells.All(d => d.CellType == CellType.Blank))
                    continue;

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                    {
                        var cell_j = row.GetCell(j).ToString();
                        if (!string.IsNullOrEmpty(cell_j) && !string.IsNullOrWhiteSpace(cell_j))
                        {
                            rowList.Add(cell_j);
                            //Console.WriteLine($"CELL {i}:{j} = {cell_j}");
                            Console.Write($"{i}:{j}=[{cell_j}] / ");
                        }
                    }
                }
                Console.WriteLine();

                if (rowList.Count > 0)
                    dataTable.Rows.Add(rowList.ToArray());

                rowList.Clear();
            }
        }
        catch (Exception e)
        {

        }
        finally
        {
            if (stream != null)
                stream.Close();
        }

        return xssWorkbook;
    }

    public static void TestWriteSomeCellsToExcel(string filename)
    {
        List<User> users = new List<User>()
        {
            new User() { ID = "2001", Name = "DFGH", City = "city11", Country = "France" },
            new User() { ID = "2002", Name = "qsdf", City = "city12", Country = "Canada" },
            new User() { ID = "2003", Name = "VCXW", City = "city13", Country = "Spain" },
        };

        DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(users), (typeof(DataTable)));

        using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet excelSheet = workbook.CreateSheet("ma feuille à moi");

            List<string> columns = new List<string>();
            IRow row = excelSheet.CreateRow(0);

            int columnIndex = 0;
            foreach (System.Data.DataColumn column in table.Columns)
            {
                columns.Add(column.ColumnName);
                row.CreateCell(columnIndex).SetCellValue(column.ColumnName);
                columnIndex++;
            }

            int rowIndex = 1;
            foreach (DataRow dsrow in table.Rows)
            {
                row = excelSheet.CreateRow(rowIndex);
                int cellIndex = 0;
                foreach (string col in columns)
                {
                    row.CreateCell(cellIndex).SetCellValue(dsrow[col].ToString());
                    cellIndex++;
                }
                rowIndex++;
            }
            workbook.Write(fs);
        }
    }

    public static void WriteExcel(XSSFWorkbook workbook, string filename)
    {
        using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
        {
            workbook.Write(fs);
        }
    }
}
