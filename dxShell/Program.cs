using System;
using CommandLine;

namespace dxShell
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("dx shell! args=");
            for (int i = 0; i < args.Length; i++)
            {
                Console.Write(args[i] + " ");
            }
            Console.Write("\r\n");

            CommandLine.Parser.Default.ParseArguments<FilesInFolderListToFile.Options>(args)
            .MapResult(
            (FilesInFolderListToFile.Options opts) => RunFilesInFolderListToFile(opts),
            //(CommitOptions opts) => RunCommitAndReturnExitCode(opts),
            //(CloneOptions opts) => RunCloneAndReturnExitCode(opts),
            errs => 1);
        }

        /// <summary>
        /// 使用设置运行列出文件夹里所有文件
        /// </summary>
        /// <param name="opts">参数</param>
        /// <returns></returns>
        private static object RunFilesInFolderListToFile(FilesInFolderListToFile.Options opts)
        {
            Console.WriteLine("执行FilesInFolderListToFile！");
            FilesInFolderListToFile.run(opts);
            Console.WriteLine("执行完毕！");
            return 0;
        }
    }
}
