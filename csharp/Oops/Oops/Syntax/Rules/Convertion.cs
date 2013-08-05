using System;

namespace Oops
{
	public class Convertion : IEquatable<Convertion>
	{
		public Convertion(Unit sourceUnit, decimal standardUnitRate) {
			SourceUnit = sourceUnit;
			StandardUnitRate = standardUnitRate;
		}

        // for extend.
        public Unit SourceUnit { get; private set; }
        public decimal StandardUnitRate { get; private set; }

		public decimal ApplyTo(Value sourceValue){
            return sourceValue.Inner * StandardUnitRate;
		}

		public override int GetHashCode() {
            return SourceUnit.GetHashCode();
		}

		public override bool Equals(object obj) {
			if (obj == null)
			{
				return false;
			}

			var convertion = obj as Convertion;
			if (convertion == null)
			{
				return false;
			}

			return this.Equals(convertion);
		}

		public bool Equals(Convertion other) {
			return SourceUnit == other.SourceUnit;
		}
	}
}

