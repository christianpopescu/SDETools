﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fr.vadc.FilesAndFoldersHelper
{
    /// <summary>
    /// Class       : FileAndFolderServices
    /// Description : Service that presents methods work with operating systems files and folders 
    /// </summary>
    public class FileAndFolderService
    {
        protected  List<IFileOrFolder> result = new List<IFileOrFolder>();

        public List<IFileOrFolder> GetListOfFilesAndFolders(string path, ElementSelection pSelection)
        {
            if (!Directory.Exists(path))
                throw( new DirectoryNotFoundException(path));
            result = new List<IFileOrFolder>();
            FolderRecursiveEnumeration(path, pSelection);
            return result;
        }

        private void FolderRecursiveEnumeration(String path, ElementSelection pSelection)
        {
            if (pSelection.HasFlag(ElementSelection.folder))
                foreach (var dir in Directory.EnumerateDirectories(path))
                    result.Add(Folder.ConstructFolder(dir));
            if (pSelection.HasFlag(ElementSelection.file))
                foreach (var file in Directory.EnumerateFiles(path))
                    result.Add(File.ConstructFile(file));
            foreach (var dir in Directory.EnumerateDirectories(path))
                FolderRecursiveEnumeration(dir, pSelection);

        }

    }
}
