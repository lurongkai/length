using System;
using System.Collections.Generic;

namespace Oops
{
    public class ConvertionTable
    {
        public static ConvertionTable Instance = new ConvertionTable();
        private readonly Dictionary<Unit, Convertion> _convertionDict;

        private ConvertionTable()
        {
            _convertionDict = new Dictionary<Unit, Convertion>();
        }

        public Convertion QueryStandardConvertion(Unit unit)
        {
            if (!_convertionDict.ContainsKey(unit))
            {
                throw new InvalidOperationException("Specfied convertion not exists");
            }

            return _convertionDict[unit];
        }

        public bool ConvertionExist(Convertion convertion)
        {
            return !_convertionDict.ContainsKey(convertion.SourceUnit);
        }

        public void AddConvertion(Convertion convertion)
        {
            _convertionDict.Add(convertion.SourceUnit, convertion);
        }
    }
}