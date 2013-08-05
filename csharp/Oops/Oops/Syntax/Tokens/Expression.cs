using System;

namespace Oops
{
	public abstract class Expression
	{
		public abstract Value Calculate();
	}

	public class ValueExpression : Expression
	{
		public ValueExpression(Value value) {
			this.Inner = value;
		}

		public Value Inner{ get; private set;}

		public override Value Calculate() {
			return Inner.ToStandard();
		}
	}

	public class OperatorExpression: Expression{
		private ValueExpression _left;
		private ValueExpression _right;
		private Operator _operator;

		public OperatorExpression(ValueExpression left, Operator theOperator, ValueExpression right) {
			this._left = left;
			this._operator = theOperator;
			this._right = right;
		}

		public override Value Calculate() {
			return _operator.Apply(_left.Inner, _right.Inner);
		}
	}
}

