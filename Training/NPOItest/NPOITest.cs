using System.Data;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Text.Json;
using System.Xml;

public static class NPOITest
{
    public static void ReadExcel(string filename, string sheetname)
    {
        DataTable dataTable = new DataTable();
        ISheet sheet;
        using (var stream = new FileStream(filename, FileMode.Open))
        {
            stream.Position = 0;
            XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
            sheet = xssWorkbook.GetSheet(sheetname);
            IRow headerRow = sheet.GetRow(0);

            int cellCount = headerRow.LastCellNum;
            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    continue;

                dataTable.Columns.Add(cell.ToString());
                Console.WriteLine($"HEADER CELL {j} = {cell}");
            }

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
                            Console.WriteLine($"CELL {i}:{j} = {cell_j}");
                        }
                    }
                }
                if (rowList.Count > 0)
                    dataTable.Rows.Add(rowList.ToArray());

                rowList.Clear();
            }
        }
    }

    public static void ReadExcel(string filename)
    {
        DataTable dataTable = new DataTable();
        ISheet sheet;
        using (var stream = new FileStream(filename, FileMode.Open))
        {
            stream.Position = 0;
            XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
            sheet = xssWorkbook.GetSheetAt(0);
            IRow headerRow = sheet.GetRow(0);

            int cellCount = headerRow.LastCellNum;
            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                    continue;

                dataTable.Columns.Add(cell.ToString());
                Console.WriteLine($"HEADER CELL {j} = {cell}");
            }

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
                            Console.WriteLine($"CELL {i}:{j} = {cell_j}");
                        }
                    }
                }
                if (rowList.Count > 0)
                    dataTable.Rows.Add(rowList.ToArray());

                rowList.Clear();
            }
        }
    }

    public static void WriteExcel(string filename)
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
}
