﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fr.vadc.FilesAndFoldersHelper
{
    public class File : IFileOrFolder
    {
        public string FullName { get; set; }

        protected File(){}

        public static File CreateFile(String pFullName)
        {
            return new File() {FullName = pFullName};
        }
    }
}
