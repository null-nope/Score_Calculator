using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calculator.src
{
    internal class DataExport
    {
        private static string m_file_path = "C:\\Users\\Public\\Documents\\datasave.xlsx";
        public static void DataExportExcel()
        {
            Application excel = new Application();
            excel.Visible = false;

            bool result = File.Exists(m_file_path);
            if (!result)
            {
                Workbooks workbooks = excel.Workbooks;
        //Workbook workbook = workbooks.Add(XlSheetType.xlWorksheet);
                Workbook workbook = workbooks.Add();
                Sheets sheets = workbook.Worksheets;
                Worksheet sheet = (Worksheet)sheets[1];
                SetTitleRow(sheet);
                SetRow(sheet, 2);
                sheet.Columns.AutoFit();
                workbook.SaveAs(m_file_path);

                workbook.Close();
                workbooks.Close();
                excel.Quit();

                NAR(sheet);
                NAR(sheets);
                NAR(workbook);
                NAR(workbooks);
            }
            else
            {

                Workbooks workbooks_open = excel.Workbooks;
                Workbook workbook_open = workbooks_open.Open(m_file_path);
                Sheets sheets = workbook_open.Worksheets;
                Worksheet sheet_open = (Worksheet)sheets[1];
                InsertRow(sheet_open);
                SetRow(sheet_open, 2);
                sheet_open.Columns.AutoFit();
                workbook_open.Save();

                
                workbook_open.Close();
                workbooks_open.Close();
                excel.Quit();

                NAR(sheet_open);
                NAR(sheets);
                NAR(workbook_open);
                NAR(workbooks_open);
            }
            Kill(excel);
        }

        public static void InsertRow(Worksheet sheet)
        {
            //插入行
            object obj = Type.Missing;
            Microsoft.Office.Interop.Excel.Range xlsRow = (Microsoft.Office.Interop.Excel.Range)sheet.Rows[2, obj];
            xlsRow.Insert(XlInsertShiftDirection.xlShiftDown, obj);
        }

        public static void SetTitleRow(Worksheet sheet)
        {
            Data data = new Data();
            for (int i = 0; i < data.ITEM.Length; i++)
            {
                sheet.Cells[1, i + 1] = data.ITEM[i];
                sheet.Cells[1, i + 1].Font.Bold = true;
            }
            sheet.Cells.Font.Bold = false;
        }

        public static void SetRow(Worksheet sheet, int row)
        {            
            Data.PlayerRecord record = Data.GetPlayerRecord();
            sheet.Cells[row, 1] = record.player_name;
            sheet.Cells[row, 2] = record.team;
            sheet.Cells[row, 3] = record.difficulty;
            sheet.Cells[row, 4] = record.ending;
            sheet.Cells[row, 5] = record.ending_score;
            sheet.Cells[row, 6] = record.amount_6s;
            sheet.Cells[row, 7] = record.amount_5s;
            sheet.Cells[row, 8] = record.amount_4s;
            sheet.Cells[row, 9] = record.amount_kills;
            sheet.Cells[row, 10] = record.amount_enlightenment;
            sheet.Cells[row, 11] = record.on_route_score;
            sheet.Cells[row, 12] = record.emergency;
            sheet.Cells[row, 13] = record.emergency_score;
            sheet.Cells[row, 14] = record.special;
            sheet.Cells[row, 15] = record.special_score;
            sheet.Cells[row, 16] = record.amount_collections;
            sheet.Cells[row, 17] = record.collections_score;
            sheet.Cells[row, 18] = record.game_score;
            sheet.Cells[row, 19] = record.total_score;
        }

        public static void SetSavePath(string path)
        {
            m_file_path = path + "\\DataSave.xlsx";
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        //强制关闭
        public static bool Kill(Application excel)
        {
            try
            {
                IntPtr t = new IntPtr(excel.Hwnd);   //得到Excel的句柄
                int tag = 0;
                GetWindowThreadProcessId(t, out tag);   //获取本进程id
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(tag);   //获取此进程的引用
                p.Kill();     //关闭进程
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void NAR(object obj)
        {
            try
            {
                int intRel = 0;
                do
                {
                    intRel = Marshal.ReleaseComObject(obj);
                } while (intRel > 0);
            }
            catch (Exception ex)
            {

                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
