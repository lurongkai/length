using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oops.Syntax.Tokens
{
    public class UnitFix
    {
        private static List<Tuple<string, string>> UnitFixList = new List<Tuple<string, string>>();
        
        static UnitFix()
        {
            UnitFixList.Add(new Tuple<string, string>("inch", "inches"));
            UnitFixList.Add(new Tuple<string, string>("foot", "feet"));
            UnitFixList.Add(new Tuple<string, string>("mile", "miles"));
            UnitFixList.Add(new Tuple<string, string>("fath", "faths"));
        }

        public static string FixUnit(string raw)
        {
            var item = UnitFixList.FirstOrDefault(u => u.Item1 == raw || u.Item2 == raw);
            if (item != null)
            {
                return item.Item1;
            }

            return raw;
        }
    }
}
