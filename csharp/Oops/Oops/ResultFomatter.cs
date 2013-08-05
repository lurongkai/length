using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Oops
{
    public class ResultFomatter
    {
        private readonly List<Expression> _expressionResult;

        public ResultFomatter(List<Expression> expressionResult)
        {
            _expressionResult = expressionResult;
        }

        public void FormatTo(Stream stream)
        {
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer
                    .L("#I'm not here to participate competition, just for fun...@lurongkai")
                    .L();
                foreach (Expression expression in _expressionResult)
                {
                    writer.L(expression.Calculate().ToString());
                }
            }
        }
    }

    public static class TrickExtension
    {
        public static StreamWriter L(this StreamWriter sw)
        {
            return L(sw, "");
        }

        public static StreamWriter L(this StreamWriter sw, string content)
        {
            sw.WriteLine(content);
            return sw;
        }
    }
}