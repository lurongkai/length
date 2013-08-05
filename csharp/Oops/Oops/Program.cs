using System;
using System.IO;

namespace Oops
{
	class MainClass
	{
		private const string ResultFileName = "output.txt";
		public static void Main(string[] args) {
			var filePath = args[0];
			//var filePath = @"input.txt";
			if (!File.Exists(filePath)) {
				throw new InvalidProgramException("guys, please give me file location");
			}

			IParser parser = new LengthUnitParser();
			var director = new LengthConvertionDirector(parser);

			director.ParseFile(filePath);

		    var resultFilePath = GetResultFilePath(new FileInfo(filePath).Directory.FullName);
		    if (File.Exists(resultFilePath))
		    {
		        File.Delete(resultFilePath);
		    }

            director.WriteFileResult(resultFilePath);
		}

		private static string GetResultFilePath(string basePath){
			return Path.Combine(basePath, ResultFileName);
		}
	}
}
