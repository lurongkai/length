namespace Oops
{
    public class ConvertionParser
    {
        public Convertion ParseConvertion(string convertionRaw)
        {
            var parseUtil = new ParseUtil(convertionRaw);

            Unit unitSource = ParseUnit(parseUtil);

            string equalChar = parseUtil.ReadToken();

            string standardRate = parseUtil.ReadToken();
            string standardUnit = parseUtil.ReadToken();

            // skip error handing

            decimal standardDecimal = decimal.Parse(standardRate);

            return new Convertion(unitSource, standardDecimal);
        }

        private Unit ParseUnit(ParseUtil parseUtil)
        {
            string rawSourceValue = parseUtil.ReadToken();
            string rawUnit = parseUtil.ReadToken();

            return new Unit(rawUnit);
        }
    }
}