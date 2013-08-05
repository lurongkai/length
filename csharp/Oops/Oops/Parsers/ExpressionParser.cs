namespace Oops
{
    public class ExpressionParser
    {
        public Expression ParseExpression(string expressionRaw)
        {
            var parseUtil = new ParseUtil(expressionRaw);

            ValueExpression firstExpression = ParseValueExpression(parseUtil);
            Expression finalExpression = firstExpression;
            while (!parseUtil.EndOfLine)
            {
                string operatorRaw = parseUtil.ReadToken();
                Operator theOperator = Operator.Parse(operatorRaw);
                ValueExpression rightExpression = ParseValueExpression(parseUtil);
                finalExpression = new OperatorExpression(firstExpression, theOperator, rightExpression);
            }

            return finalExpression;
        }

        private ValueExpression ParseValueExpression(ParseUtil parseUtil)
        {
            string rawSourceValue = parseUtil.ReadToken();
            string rawSourceUnit = parseUtil.ReadToken();


            decimal sourceValueDecimal = decimal.Parse(rawSourceValue);
            Unit sourceUnit = Unit.Parse(rawSourceUnit);

            var sourceValue = new GenericValue(sourceValueDecimal, sourceUnit);

            return new ValueExpression(sourceValue);
        }
    }
}