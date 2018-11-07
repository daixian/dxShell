using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace dxShell
{
    class FilesInFolderListToFile
    {
        [Verb("listfile", HelpText = "输出文件夹下的所有文件.")]
        public class Options
        {
            [Option('d', "dir", Default = "./", Required = false, HelpText = "目标目录.")]
            public string dirpath { get; set; }

            [Option('p', "pattern", Default = "*.*", Required = false, HelpText = "文件通配符.")]
            public string pattern { get; set; }

            [Option('o', "out", Default = "outfile.txt", Required = false, HelpText = "输出文件名.")]
            public string outFile { get; set; }

            [Option('f', "format", Default = "{0}", Required = false, HelpText = "格式化符.")]
            public string format { get; set; }
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="opts"></param>
        public static void run(Options opts)
        {
            ListToFile(opts.dirpath, opts.pattern, opts.outFile, opts.format);

            FileInfo fi = new FileInfo(opts.outFile);
            Console.WriteLine(fi.FullName);
        }

        /// <summary>
        /// 把一个文件夹里的所有文件输出成一个文件
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="pattern"></param>
        /// <param name="outFile"></param>
        /// <param name="format"></param>
        public static void ListToFile(string dirPath, string pattern, string outFile, string format)
        {
            DirectoryInfo dif = new DirectoryInfo(dirPath);
            FileInfo[] files = dif.GetFiles(pattern, SearchOption.TopDirectoryOnly);

            FileStream fs = new FileStream(outFile, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            for (int i = 0; i < files.Length; i++)
            {
                sw.WriteLine(String.Format(format, files[i].Name));
            }

            sw.Flush();
            sw.Dispose();
            fs.Dispose();
        }
    }
}
