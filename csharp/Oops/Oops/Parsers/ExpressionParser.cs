using System;

namespace Oops
{
	public class ExpressionParser
	{
		public Expression ParseExpression(string expressionRaw) {
			var parseUtil = new ParseUtil(expressionRaw);
			
			var firstExpression = ParseValueExpression(parseUtil);
			Expression finalExpression = firstExpression;
			while (!parseUtil.EndOfLine) {
				var operatorRaw = parseUtil.ReadToken();
				var theOperator = Operator.Parse(operatorRaw);
				var rightExpression = ParseValueExpression(parseUtil);
				finalExpression = new OperatorExpression(firstExpression, theOperator, rightExpression); 
			}

			return finalExpression;
		}

		private ValueExpression ParseValueExpression(ParseUtil parseUtil){		
			var rawSourceValue = parseUtil.ReadToken();
			var rawSourceUnit = parseUtil.ReadToken();


			var sourceValueDecimal = decimal.Parse(rawSourceValue);
			var sourceUnit = Unit.Parse(rawSourceUnit);

			var sourceValue = new GenericValue(sourceValueDecimal, sourceUnit);

			return new ValueExpression(sourceValue);
		}
	}
}

