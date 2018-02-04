﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinqSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("***");
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                         orderby file.Length descending
                         select file;
            foreach(var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name} : {file.Length}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInforComparer());
            foreach(FileInfo file in files)
            {
                Console.WriteLine($"{file.Name} : {file.Length}");

            }
        }
    }

    public class FileInforComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
