﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static System.Console;


namespace Lecture_6
{
    internal class FileSystemManager
    {
        static internal void GetFileSystemInfo()
        {
            //Tells respective machine path
            WriteLine("{0}  {1}", "Path.PathSeparator", Path.PathSeparator);
            //Tell machine's separator char
            WriteLine("{0}  {1}", "Path.DirectorySeparatorChar", Path.DirectorySeparatorChar);
            WriteLine("{0}  {1}", "Path.GetTempPath", Path.GetTempPath());

            WriteLine("{0}  {1}", "Directory.GetCurrentDirectory", Directory.GetCurrentDirectory());
            WriteLine("{0}  {1}", "Environment.CurrentDirectory", Environment.CurrentDirectory);
            WriteLine("{0}  {1}", "Environment.SystemDirectory", Environment.SystemDirectory);
            WriteLine("{0}  {1}", "Environment.OSVersion", Environment.OSVersion);
            WriteLine("{0}  {1}", "Environment.ProcessorCount", Environment.ProcessorCount);
        }
    }
}
