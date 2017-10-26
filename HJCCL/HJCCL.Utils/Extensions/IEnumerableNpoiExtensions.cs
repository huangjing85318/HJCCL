using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using HJCCL.Utils.Npoi;
using System.Reflection;
using HJCCL.Utils.Config;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using HJCCL.Utils.Extensions;

namespace HJCCL.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class IEnumerableNpoiExtensions
    {

        #region 实体类 数据源
        /// <summary>
        /// 导出Excel内容
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="sheetName">工作表名称</param>
        /// <returns></returns>
        public static byte[] ToExcelContent<T>(this IEnumerable<T> source, string sheetName = "sheet0")
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            var book = source.ToWorkbook(null, sheetName);
            using (var ms = new MemoryStream())
            {
                book.Write(ms);
                return ms.ToArray();
            }
        }
        /// <summary>
        /// 导出Excel文件
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="excelFile">文件路径</param>
        /// <param name="sheetName">工作表名</param>
        public static void ToExcel<T>(this IEnumerable<T> source, string excelFile, string sheetName = "sheet0")
        where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (string.IsNullOrEmpty(excelFile))
            {
                throw new ArgumentNullException(nameof(excelFile));
            }
            string ext = Path.GetExtension(excelFile);
            if (ext.Equals(".xls"))
            {
                Excel.Setting.UserXlsx = false;
            }
            else if (ext.Equals(".xlsx"))
            {
                Excel.Setting.UserXlsx = true;
            }
            else
            {
                throw new NotSupportedException($"不是 Excel 文件扩展名（*.xls | *.xlsx） {excelFile}");
            }
            var book = source.ToWorkbook(excelFile, sheetName);
            // 将工作簿的流数据写入文件
            using (var stream = new FileStream(excelFile, FileMode.OpenOrCreate, FileAccess.Write))
            {
                book.Write(stream);
            }
        }
        /// <summary>
        /// 转换成工作簿
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="excelFile">文件路径</param>
        /// <param name="sheetName">工作表名</param>
        /// <returns></returns>
        internal static IWorkbook ToWorkbook<T>(this IEnumerable<T> source, string excelFile, string sheetName)
        {
            // 静态属性还是实例属性
            var properties =
            typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);
            // 获取Fluent配置
            bool fluentConfigEnabled = false;
            IFluentConfiguration fluentConfig;
            if (Excel.Setting.FluentConfigs.TryGetValue(typeof(T), out fluentConfig))
            {
                fluentConfigEnabled = true;
            }
            // 获取单元格设置
            var cellConfigs = new CellConfig[properties.Length];
            for (var i = 0; i < properties.Length; i++)
            {
                PropertyConfiguration pc;
                var property = properties[i];
                // 优先获取配置（高优先级），没有则获取属性
                if (fluentConfigEnabled && fluentConfig.PropertyConfigs.TryGetValue(property, out pc))
                {
                    cellConfigs[i] = pc.CellConfig;
                }
                else
                {
                    var attrs = property.GetCustomAttributes(typeof(NpoiColumnAttribute), true) as NpoiColumnAttribute[];
                    if (attrs != null && attrs.Length > 0)
                    {
                        cellConfigs[i] = attrs[0].CellConfig;
                    }
                    else
                    {
                        cellConfigs[i] = null;
                    }
                }
            }
            // 初始化工作簿
            var workbook = InitializeWorkbook(excelFile);
            // 创建工作表
            var sheet = workbook.GetOrCreateSheet(sheetName);
            // 缓存单元格样式
            var cellStyles = new Dictionary<int, ICellStyle>();
            // 标题行单元格样式
            var titleStyle = workbook.CreateCellStyle();
            titleStyle.Alignment = HorizontalAlignment.Center;
            titleStyle.VerticalAlignment = VerticalAlignment.Center;
            //titleStyle.FillPattern=FillPattern.Bricks;
            titleStyle.FillBackgroundColor = HSSFColor.Grey40Percent.Index;
            titleStyle.FillForegroundColor = HSSFColor.White.Index;
            var titleRow = sheet.GetOrCreateRow(0);
            var rowIndex = 1;
            foreach (var item in source)
            {
                var row = sheet.GetOrCreateRow(rowIndex);
                for (int i = 0; i < properties.Length; i++)
                {
                    var property = properties[i];
                    int index = i;
                    var config = cellConfigs[i];
                    if (config != null)
                    {
                        if (config.IsIgnored)
                        {
                            continue;
                        }
                        index = config.Index;
                    }
                    // 首次
                    if (rowIndex == 1)
                    {
                        //如果没有标题，则使用属性名称作为标题
                        var title = property.Name;
                        if (config != null)
                        {
                            if (!string.IsNullOrWhiteSpace(config.Title))
                            {
                                title = config.Title;
                            }
                            if (!string.IsNullOrWhiteSpace(config.Formatter))
                            {
                                try
                                {
                                    var style = workbook.CreateCellStyle();
                                    var dataFormat = workbook.CreateDataFormat();
                                    style.DataFormat = dataFormat.GetFormat(config.Formatter);
                                    cellStyles[i] = style;
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                                }
                            }
                            var titleCell = titleRow.GetOrCreateCell(index);
                            titleCell.CellStyle = titleStyle;
                            titleCell.SetCellValue(title);
                        }
                    }
                    var value = property.GetValue(item, null);
                    if (value == null)
                    {
                        continue;
                    }
                    var cell = row.GetOrCreateCell(index);
                    ICellStyle cellStyle;
                    if (cellStyles.TryGetValue(i, out cellStyle))
                    {
                        cell.CellStyle = cellStyle;
                    }
                    var unwrapType = property.PropertyType.UnwrapNullableType();
                    cell.SetCellValueExt(value, unwrapType, config.CustomEnum, config.Formatter);
                }
                rowIndex++;
            }
            // 合并单元格
            var mergableConfigs = cellConfigs.Where(c => c != null && c.AllowMerge).ToList();
            if (mergableConfigs.Any())
            {
                // 合并单元格样式
                var vStyle = workbook.CreateCellStyle();
                vStyle.VerticalAlignment = VerticalAlignment.Center;
                foreach (var config in mergableConfigs)
                {
                    object previous = null;
                    int rowspan = 0, row = 1;
                    for (row = 1; row < rowIndex; row++)
                    {
                        var value = sheet.GetRow(row).GetCellValue(config.Index);
                        if (object.Equals(previous, value) && value != null)
                        {
                            rowspan++;
                        }
                        else
                        {
                            if (rowspan > 1)
                            {
                                sheet.GetRow(row - rowspan).Cells[config.Index].CellStyle = vStyle;
                                sheet.AddMergedRegion(new CellRangeAddress(row - rowspan, row - 1, config.Index,
                                config.Index));
                            }
                            rowspan = 1;
                            previous = value;
                        }
                    }
                    // 什么情况下——>所有行都需要合并
                    if (rowspan > 1)
                    {
                        sheet.GetRow(row - rowspan).Cells[config.Index].CellStyle = vStyle;
                        sheet.MergeCell(row - rowspan, row - 1, config.Index, config.Index);
                    }
                }
            }
            if (rowIndex > 1)
            {
                var statisticsConfigs = new List<StatisticsConfig>();
                var filterConfigs = new List<FilterConfig>();
                var freezeConfigs = new List<FreezeConfig>();
                if (fluentConfigEnabled)
                {
                    statisticsConfigs.AddRange(fluentConfig.StatisticsConfigs);
                    filterConfigs.AddRange(fluentConfig.FilterConfigs);
                    freezeConfigs.AddRange(fluentConfig.FreezeConfigs);
                }
                else
                {
                    var statistics =
                    typeof(T).GetCustomAttributes(typeof(NpoiStatisticsAttribute), true) as NpoiStatisticsAttribute[];
                    if (statistics != null && statistics.Length > 0)
                    {
                        foreach (var item in statistics)
                        {
                            statisticsConfigs.Add(item.StatisticsConfig);
                        }
                    }
                    var freezes =
                    typeof(T).GetCustomAttributes(typeof(NpoiFreezeAttribute), true) as NpoiFreezeAttribute[];
                    if (freezes != null && freezes.Length > 0)
                    {
                        foreach (var item in freezes)
                        {
                            freezeConfigs.Add(item.FreezeConfig);
                        }
                    }
                    var filters =
                    typeof(T).GetCustomAttributes(typeof(NpoiFilterAttribute), true) as NpoiFilterAttribute[];
                    if (filters != null && filters.Length > 0)
                    {
                        foreach (var item in filters)
                        {
                            filterConfigs.Add(item.FilterConfig);
                        }
                    }
                }
                // 统计行
                foreach (var item in statisticsConfigs)
                {
                    var lastRow = sheet.CreateRow(rowIndex);
                    var cell = lastRow.CreateCell(0);
                    cell.SetCellValue(item.Name);
                    foreach (var column in item.Columns)
                    {
                        cell = lastRow.CreateCell(column);
                        cell.CellFormula =
                        $"{item.Formula}({GetCellPosition(1, column)}:{GetCellPosition(rowIndex - 1, column)})";
                    }
                    rowIndex++;
                }
                // 设置冻结窗格
                foreach (var item in freezeConfigs)
                {
                    sheet.CreateFreezePane(item.ColSplit, item.RowSplit, item.LeftMostColumn, item.TopRow);
                }
                // 设置自动筛选
                foreach (var item in filterConfigs)
                {
                    sheet.SetAutoFilter(new CellRangeAddress(item.FirstRow, item.LastRow ?? rowIndex, item.FirstCol,
                    item.LastCol));
                }
            }
            // 自动调整所有列
            for (int i = 0; i < properties.Length; i++)
            {
                sheet.AutoSizeColumn(i);
            }
            return workbook;
        }
        /// <summary>
        /// 初始化工作簿
        /// </summary>
        /// <param name="excelFile">Excel文件路径</param>
        /// <returns></returns>
        private static IWorkbook InitializeWorkbook(string excelFile)
        {
            var setting = Excel.Setting;
            if (setting.UserXlsx)
            {
                if (!string.IsNullOrWhiteSpace(excelFile) && File.Exists(excelFile))
                {
                    using (var file = new FileStream(excelFile, FileMode.Open, FileAccess.Read))
                    {
                        return new XSSFWorkbook(file);
                    }
                }
                return new XSSFWorkbook();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(excelFile) && File.Exists(excelFile))
                {
                    using (var file = new FileStream(excelFile, FileMode.Open, FileAccess.Read))
                    {
                        return new HSSFWorkbook(file);
                    }
                }
                var hssf = new HSSFWorkbook();
                if (setting.UseCreateInfo)
                {
                    var dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                    dsi.Company = setting.Compnay;
                    hssf.DocumentSummaryInformation = dsi;
                    var si = PropertySetFactory.CreateSummaryInformation();
                    si.Author = setting.Author;
                    si.Subject = setting.Subject;
                    hssf.SummaryInformation = si;
                }
                return hssf;
            }
        }
        /// <summary>
        /// 获取单元格位置
        /// </summary>
        /// <param name="row">行号</param>
        /// <param name="col">列号</param>
        /// <returns></returns>
        private static string GetCellPosition(int row, int col)
        {
            col = Convert.ToInt32('A') + col;
            row = row + 1;
            return (char)col + row.ToString();
        }

        /// <summary>
        /// 从Excel导入数据
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="excelFile">文件路径</param>
        /// <param name="sheetName">工作表名</param>
        public static void Import(Dictionary<string, string> cellheader, string sheetName = "sheet0")
        {

        }

        #endregion

        #region DataTable 数据源
        /// <summary>
        /// 导出Excel文件
        /// </summary>
        /// <typeparam name="dt">数据源</typeparam>
        /// <param name="excelFile">文件路径</param>
        /// <param name="sheetName">工作表名</param>
        public static void ToExcel(this DataTable dt, string excelFile, string sheetName = "sheet0")
        {
            using (MemoryStream ms = Export(dt, sheetName))
            {
                using (FileStream fs = new FileStream(excelFile, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }
        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        public static MemoryStream Export(DataTable dtSource, string strHeaderText)
        {
            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "NPOI";
                workbook.DocumentSummaryInformation= dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "HJCCL"; //填加xls文件作者信息
                si.ApplicationName = "使用NPOI封装类"; //填加xls文件创建程序信息
                si.LastAuthor = "努力做一个好人"; //填加xls文件最后保存者信息
                si.Comments = "交流学习,多多指教"; //填加xls文件作者信息
                si.Title = strHeaderText; //填加xls文件标题信息
                si.Subject = "HJCCL.Utils.Npoi扩展封装";//填加文件主题信息
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            var dateStyle = workbook.CreateCellStyle();
            var format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 表头及样式
                    {
                        var headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        var headStyle = workbook.CreateCellStyle();
                        var font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                    }
                    #endregion


                    #region 列头及样式
                    {
                        var headerRow = sheet.CreateRow(1);
                        var headStyle = workbook.CreateCellStyle();
                        var font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                    }
                    #endregion

                    rowIndex = 2;
                }
                #endregion


                #region 填充内容
                var dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    var newCell = dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                return ms;
            }
        }
        #endregion

    }
}
