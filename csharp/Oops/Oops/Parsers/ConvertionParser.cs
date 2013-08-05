using System;

namespace Oops
{
	public class ConvertionParser
	{
		public Convertion ParseConvertion(string convertionRaw) {
			var parseUtil = new ParseUtil(convertionRaw);

			var unitSource = ParseUnit(parseUtil);

			var equalChar = parseUtil.ReadToken();

			var standardRate = parseUtil.ReadToken();
			var standardUnit = parseUtil.ReadToken();

			// skip error handing

			var standardDecimal = decimal.Parse(standardRate);

			return new Convertion(unitSource, standardDecimal);
		}

		private Unit ParseUnit(ParseUtil parseUtil) {
			var rawSourceValue = parseUtil.ReadToken();
			var rawUnit = parseUtil.ReadToken();

			return new Unit(rawUnit);
		}
	}
}

