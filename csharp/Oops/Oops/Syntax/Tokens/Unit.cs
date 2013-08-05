using System;
using Oops.Syntax.Tokens;

namespace Oops
{
    public class Unit : IEquatable<Unit>
    {
        public static Unit StandardUnit = new Unit("m");

        private readonly string _raw;

        public Unit(string raw)
        {
            _raw = raw;
        }

        public bool Equals(Unit other)
        {
            return UnitFix.FixUnit(_raw) == UnitFix.FixUnit(other._raw);
        }

        public static Unit Parse(string raw)
        {
            return new Unit(raw);
        }

        public override string ToString()
        {
            return _raw;
        }

        public override int GetHashCode()
        {
            return UnitFix.FixUnit(_raw).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var unit = obj as Unit;
            if (unit == null)
            {
                return false;
            }

            return Equals(unit);
        }
    }
}