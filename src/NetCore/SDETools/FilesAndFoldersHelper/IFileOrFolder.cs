﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fr.vadc.FilesAndFoldersHelper
{
    public interface IFileOrFolder
    {
        public String FullName { get;  }

        public String Name { get; }

        public String DirectoryName { get; }

    }
}
