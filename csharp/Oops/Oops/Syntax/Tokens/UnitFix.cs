using System;
using System.Collections.Generic;
using System.Linq;

namespace Oops.Syntax.Tokens
{
    public class UnitFix
    {
        private static readonly List<Tuple<string, string>> UnitFixList = new List<Tuple<string, string>>();

        static UnitFix()
        {
			UnitFixList.Add(new Tuple<string, string>("mile", "miles"));
			UnitFixList.Add(new Tuple<string, string>("yard", "yards"));
			UnitFixList.Add(new Tuple<string, string>("inch", "inches"));
			UnitFixList.Add(new Tuple<string, string>("foot", "feet"));
			UnitFixList.Add(new Tuple<string, string>("fath", "faths"));
			UnitFixList.Add(new Tuple<string, string>("furlong", "furlongs"));
        }

        public static string FixUnit(string raw)
        {
            Tuple<string, string> item = UnitFixList.FirstOrDefault(u => u.Item1 == raw || u.Item2 == raw);
            if (item != null)
            {
                return item.Item1;
            }

            return raw;
        }
    }
}