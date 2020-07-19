using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Web;
using NPOI.XSSF.UserModel;
using System.Data;

namespace Mx.Common
{

    public class ExcelHelp<T>
    {
        public ExcelHelp()
        {
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="head">中文列名对照</param>
        /// <param name="fileName">文件名</param>
        public void getExcel(List<T> lists, Hashtable head, string fileName)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                MemoryStream ms = new MemoryStream();
                HSSFSheet sheet = workbook.CreateSheet() as HSSFSheet;
                HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;
                bool h = false;
                int j = 1;
                Type type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();

                foreach (T item in lists)
                {
                    HSSFRow dataRow = sheet.CreateRow(j) as HSSFRow;
                    int i = 0;
                    foreach (PropertyInfo column in properties)
                    {
                        if (!h)
                        {
                            headerRow.CreateCell(i).SetCellValue(head[column.Name] == null ? column.Name : head[column.Name].ToString());
                            dataRow.CreateCell(i).SetCellValue(column.GetValue(item, null) == null ? "" : column.GetValue(item, null).ToString());
                        }
                        else
                        {
                            dataRow.CreateCell(i).SetCellValue(column.GetValue(item, null) == null ? "" : column.GetValue(item, null).ToString());
                        }

                        i++;
                    }
                    h = true;
                    j++;
                }
                workbook.Write(ms);
                //FileStream dumpFile = new FileStream(workbookFile, FileMode.Create, FileAccess.ReadWrite);
                //ms.WriteTo(dumpFile);
                //ms.Flush();
                //ms.Position = 0;
                //dumpFile.Close();


                HttpContext curContext = HttpContext.Current;

                // 设置编码和附件格式  
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = Encoding.UTF8;
                curContext.Response.Charset = "";
                curContext.Response.AppendHeader("Content-Disposition",
                     "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));
                curContext.Response.BinaryWrite(ms.GetBuffer());
                ms.Close();
                ms.Dispose();
                curContext.Response.End();  

            }
            catch (Exception ee)
            {
                string see = ee.Message;
            }
        }


        public DataTable ImportExcel(string strFileName)
        {
            #region excel文件格式读取
            DataTable dt = new DataTable();
            ISheet sheet;
            try
            {
                using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                {
                    HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
                    sheet = hssfworkbook.GetSheetAt(0);
                }
            }
            catch
            {
                using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                {
                    XSSFWorkbook hssfworkbook = new XSSFWorkbook(file);
                    sheet = hssfworkbook.GetSheetAt(0);
                }
            }


            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString()+j);
            }
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {

                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    ICell cell = row.GetCell(j);
                    if (cell.CellType == CellType.Numeric)
                    {
                        //NPOI中数字和日期都是NUMERIC类型的，这里对其进行判断是否是日期类型
                        if (HSSFDateUtil.IsCellDateFormatted(cell))//日期类型
                        {
                            dataRow[j] = cell.DateCellValue;
                        }
                        else//其他数字类型
                        {
                            dataRow[j] = cell.NumericCellValue;
                        }
                    }
                    else if (cell.CellType == CellType.Blank)//空数据类型
                    {
                        dataRow[j] = "";
                    }
                    else if (cell.CellType == CellType.Formula)//公式类型
                    {
                        HSSFFormulaEvaluator eva = new HSSFFormulaEvaluator(sheet.Workbook);
                        dataRow[j] = eva.Evaluate(cell).StringValue;
                    }
                    else //其他类型都按字符串类型来处理
                    {
                        dataRow[j] = cell.StringCellValue;
                    }
                }
                dt.Rows.Add(dataRow);
            }
            #endregion
            return dt;
        }


        
        ///// <summary>
        ///// 导入Excel
        ///// </summary>
        ///// <param name="lists"></param>
        ///// <param name="head">中文列名对照</param>
        ///// <param name="workbookFile">Excel所在路径</param>
        ///// <returns></returns>
        //public List<T> fromExcel(Hashtable head, string workbookFile)
        //{
        //    try
        //    {
        //        HSSFWorkbook hssfworkbook;
        //        List<T> lists = new List<T>();
        //        using (FileStream file = new FileStream(workbookFile, FileMode.Open, FileAccess.Read))
        //        {
        //            hssfworkbook = new HSSFWorkbook(file);
        //        }
        //        HSSFSheet sheet = hssfworkbook.GetSheetAt(0) as HSSFSheet;
        //        IEnumerator rows = sheet.GetRowEnumerator();
        //        HSSFRow headerRow = sheet.GetRow(0) as HSSFRow;
        //        int cellCount = headerRow.LastCellNum;
        //        //Type type = typeof(T);
        //        PropertyInfo[] properties ;
        //        T t = default(T);
        //        for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
        //        {
        //            HSSFRow row = sheet.GetRow(i) as HSSFRow;
        //            t = Activator.CreateInstance <T>();  
        //            properties = t.GetType().GetProperties();
        //            foreach (PropertyInfo column in properties)
        //            {
        //                int j = headerRow.Cells.FindIndex(delegate(Cell c)
        //                        {
        //                            return c.StringCellValue==(head[column.Name] == null ? column.Name : head[column.Name].ToString());
        //                        });
        //                if (j>=0&&row.GetCell(j) != null)
        //                {
        //                    object value =valueType(column.PropertyType, row.GetCell(j).ToString());  
        //                    column.SetValue(t, value, null);
        //                }
        //            }
        //            lists.Add(t);
        //        }
        //        return lists;
        //    }
        //    catch (Exception ee)
        //    {
        //        string see = ee.Message;
        //        return null;
        //    }
        //}
        object valueType(Type t, string value)
        {
            object o = null;
            string strt = "String";
            if (t.Name == "Nullable`1")
            {
                strt = t.GetGenericArguments()[0].Name;
            }
            switch (strt)
            {
                case "Decimal":
                    o = decimal.Parse(value);
                    break;
                case "Int":
                    o = int.Parse(value);
                    break;
                case "Float":
                    o = float.Parse(value);
                    break;
                case "DateTime":
                    o = DateTime.Parse(value);
                    break;
                default:
                    o = value;
                    break;
            }
            return o;
        }
    }

}
