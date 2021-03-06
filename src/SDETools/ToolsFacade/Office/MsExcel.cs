﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ToolsFacade.Office
{
    public class MsExcel : OfficeInterop<Excel.Application>
    {
        private static MsExcel _instance;
        
        private static Excel.Application _excelApplication;

        private static readonly string _typeName = "Excel.Application";
        private static readonly string _processName = "EXCEL";
        private MsExcel()
        {
            TypeName = _typeName;
            ProcessName = _processName;
        }



        public static MsExcel GetInstance()
        {
            if (_instance != null) return _instance;
            _instance = new MsExcel();
            try
            {
                _excelApplication = BindToRunningProcessOrNew();
            }
            catch (Exception ex)
            {
                // todo log exception
                _instance = null;
            }
            return _instance;
        }

        protected static Excel.Application BindToRunningProcessOrNew() 
        {
            // Get the current process.
            Process currentProcess = Process.GetCurrentProcess();
 
            // Get all processes running on the local computer.
            Process[] localAll = Process.GetProcessesByName(_processName);
            Excel.Application application;
            if (localAll.Length > 0) application = Marshal.GetActiveObject(_typeName) as Excel.Application;
            else application = new Excel.Application();

            return application;
        }
    }
}
