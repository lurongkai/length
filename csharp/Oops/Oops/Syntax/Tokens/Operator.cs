using System;

namespace Oops
{
	public abstract class Operator
	{
		public static Operator Plus = new PlusOperator();
		public static Operator Minus = new MinusOperator();

		protected string _raw;

		public abstract Value Apply(Value _left, Value _right);

		public override string ToString() {
			return _raw;
		}

		// should be a strategy style, but....ok, for simple
		public static Operator Parse(string operatorRaw) {
			switch (operatorRaw) {
				case("+"):
					return new PlusOperator();
				case("-"):
					return new MinusOperator();
				default:
					break;
			}

			throw new NotImplementedException("not supported yet.");
		}
	}

	public abstract class MathematicOperator : Operator
	{
		public override Value Apply(Value _left, Value _right) {
			var leftStandard = _left.ToStandard();
			var rightStandard = _right.ToStandard();

			var inner = GetOperatorAction()(leftStandard.Inner, rightStandard.Inner);
			return new StandardValue(inner);
		}

		public abstract Func<decimal, decimal, decimal> GetOperatorAction();
	}

	public class PlusOperator : MathematicOperator{
		public PlusOperator() {
			this._raw = "+";
		}

		public override Func<decimal, decimal, decimal> GetOperatorAction() {
			return (left, right) => left + right;
		}
	}

	public class MinusOperator : MathematicOperator{
		public MinusOperator() {
			this._raw = "-";
		}

		public override Func<decimal, decimal, decimal> GetOperatorAction() {
			return (left, right) => left - right;
		}
	}
}

