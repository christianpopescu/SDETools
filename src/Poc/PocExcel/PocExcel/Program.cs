﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocExcel.ExcelTools;

namespace PocExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAddList();

            Console.Write("Press any key! ");
            Console.ReadKey();
        }

        private static void TestAddList()
        {
            MsExcel.GetInstance().Open(@"E:\Temp\ToDelete\FirstWorbook.xlsx");
            Workbook w = MsExcel.GetInstance().GetOpenWorkbookByName(@"FirstWorbook.xlsx");
            w.AddWorksheet("TestWs");
            List<List<string>> lls = new List<List<string>>();

            for (int i = 0; i < 10; i++)
            {
                var ls = new List<string>();
                for (int j = 0; j < 20; j++)
                    ls.Add((i + j).ToString());
                lls.Add(ls);
            }

            Worksheet ws = w.GetWorksheetByName("TestWs");
            ws.SetTable(lls, 5, 3);
            w.Save();
            w.Close();
        }

        private static void TestExcelUseSimple()
        {
            MsExcel.GetInstance().Open(@"E:\Temp\ToDelete\FirstWorbook.xlsx");
            Workbook w = MsExcel.GetInstance().GetOpenWorkbookByName(@"FirstWorbook.xlsx");

            if (w != null)
                Console.WriteLine(w.WorksheetExists("newWorksheet6"));

            Worksheet ws = w.GetWorksheetByName("newWorksheet6");
            ws.SetCellValue(10, 20, "toto");
            MsExcel.GetInstance()
                .SetDisplayAlerts(false); // TODO: to refactor added to allow delete worksheet when Excel not visible
            w.Save();
            w.Close();
        }
        private static void TestExcelUse()
        {
            MsExcel.GetInstance().Open(@"E:\Temp\ToDelete\FirstWorbook.xlsx");
            List<Workbook> lw = MsExcel.GetInstance().GetOpenWorkbooks();

            MsExcel.GetInstance()
                .SetDisplayAlerts(false); // TODO: to refactor added to allow delete worksheet when Excel not visible
            foreach (var w in lw)
            {
                Console.WriteLine(w.Name + "  " + w.FullName);
                if (!string.Equals(w.Name, "FirstWorbook.xlsx")) continue;
                w.AddWorksheet("newWorksheet6", true);
                var l = w.WorksheetList;
                foreach (var ws in l)
                {
                    Console.WriteLine("  " + ws.Name);
                    Console.WriteLine("   Rows = " + ws.RowsCount);
                    Console.WriteLine("   Columns = " + ws.RowsCount);

                    for (int r = 1; r <= 5; r++)
                    for (int c = 1; c <= 4; c++)
                        Console.WriteLine("    " + ws.GetCellValue(r, c));
                    ws.SetCellValue(10, 10, "Test2and Test3");
                    ws.SetCellFontStyle(10, 10, "bold", 2, 5);
                    ws.SetCellValue(10, 1, "Test23 and Test24");
                    ws.SetCellFontStyle(10, 1, "bold");
                    ws.SetCellColor(10, 1, System.Drawing.Color.Red, 2, 4);

                    ws.SetCellValue(9, 2, "Test23 and \n Test24");

                    //List<List<string>> lls = ws.GetTable(1, 1, 4, 2);
                    w.Save();
                    List<List<string>> lls = ws.GetTableType(1, 1, 5, 2);
                    foreach (var row in lls)
                    {
                        foreach (var col in row)
                            Console.Write(col + " | ");
                        Console.WriteLine();
                    }

                    List<List<dynamic>> lld = ws.GetTableDynamic(1, 1, 5, 2);
                    foreach (var row in lld)
                    {
                        foreach (var col in row)
                        {
                            dynamic d = col;
                            if (d == null)
                                Console.Write("null" + " | ");
                            else
                                Console.Write(d.GetType() + " | ");
                        }

                        Console.WriteLine();
                    }
                }

                w.Close();
            }
        }
    }
}
