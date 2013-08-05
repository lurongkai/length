using System;
using System.Collections.Generic;
using System.IO;

namespace Oops
{
    public class LengthConvertionDirector
    {
        private readonly List<Expression> _expressionResult;
        private readonly IParser _parser;

        public LengthConvertionDirector(IParser parser)
        {
            _parser = parser;
            _expressionResult = new List<Expression>();
        }

        public void ParseFile(string filePath)
        {
            var sourcelines = File.ReadLines(filePath);

            foreach (string line in sourcelines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                if (ParseUtil.IsConvertion(line))
                {
                    ProcessConvertion(line);
                    continue;
                }
                if (ParseUtil.IsExpression(line))
                {
                    ProcessExpression(line);
                    continue;
                }

                throw new InvalidOperationException("what hell...");
            }
        }

        public void WriteFileResult(string resultFilePath)
        {
            using (var file = new FileStream(resultFilePath, FileMode.OpenOrCreate))
            {
                var resultFormatter = new ResultFomatter(_expressionResult);
                resultFormatter.FormatTo(file);
            }
        }

        private void ProcessConvertion(string raw)
        {
            Convertion convertion = _parser.ParseConvertion(raw);

            if (!ConvertionTable.Instance.ConvertionExist(convertion))
            {
                throw new InvalidOperationException("kidding?");
            }

            ConvertionTable.Instance.AddConvertion(convertion);
        }

        private void ProcessExpression(string line)
        {
            Expression expression = _parser.ParseExpression(line);
            _expressionResult.Add(expression);
        }
    }
}