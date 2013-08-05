namespace Oops
{
    public class LengthUnitParser : IParser
    {
        private readonly ConvertionParser _convertionParser;
        private readonly ExpressionParser _expressionParser;

        public LengthUnitParser()
        {
            _convertionParser = new ConvertionParser();
            _expressionParser = new ExpressionParser();
        }

        public Expression ParseExpression(string expressionRaw)
        {
            return _expressionParser.ParseExpression(expressionRaw);
        }

        public Convertion ParseConvertion(string convertionRaw)
        {
            return _convertionParser.ParseConvertion(convertionRaw);
        }
    }
}