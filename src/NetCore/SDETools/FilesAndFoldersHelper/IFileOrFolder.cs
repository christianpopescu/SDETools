﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fr.vadc.FilesAndFoldersHelper
{
    public interface IFileOrFolder<T>
    {
        public String Name { get; set; }
        public String FullName { get; set; }

        public T Data { get; set; }
    }
}
