using System;

namespace Oops
{
	public abstract class Value
	{
		protected Value(decimal inner, Unit unit) {
			this.Inner = inner;
			this.Unit = unit;
		}

		public decimal Inner { get; private set;}
		public Unit Unit{ get; private set;}

		public abstract Value ToStandard();

		public override string ToString() {
			return string.Format("{0:f2} {1}", Inner, Unit);
		}
	}

	public class StandardValue : Value
	{
		public StandardValue(decimal inner): base(inner, Unit.StandardUnit){}

		public override Value ToStandard() {
			return this;
		}
	}

	public class GenericValue : Value
	{
		public GenericValue(decimal inner, Unit unit): base(inner, unit){}

		public override Value ToStandard() {
			var convertion = ConvertionTable.Instance.QueryStandardConvertion(this.Unit);
			return new StandardValue(convertion.ApplyTo(this));
		}
	}
}

