using System;
using System.IO;

namespace Oops
{
    internal class MainClass
    {
        private const string ResultFileName = "output.txt";

        public static void Main(string[] args)
        {
            string filePath = args[0];
            if (!File.Exists(filePath))
            {
                throw new InvalidProgramException("guys, please give me file location");
            }

            IParser parser = new LengthUnitParser();
            var director = new LengthConvertionDirector(parser);

            director.ParseFile(filePath);

            string resultFilePath = GetResultFilePath(new FileInfo(filePath).Directory.FullName);
            if (File.Exists(resultFilePath))
            {
                File.Delete(resultFilePath);
            }

            director.WriteFileResult(resultFilePath);
        }

        private static string GetResultFilePath(string basePath)
        {
            return Path.Combine(basePath, ResultFileName);
        }
    }
}