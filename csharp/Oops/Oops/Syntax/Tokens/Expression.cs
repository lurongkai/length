namespace Oops
{
    public abstract class Expression
    {
        public abstract Value Calculate();
    }

    public class ValueExpression : Expression
    {
        public ValueExpression(Value value)
        {
            Inner = value;
        }

        public Value Inner { get; private set; }

        public override Value Calculate()
        {
            return Inner.ToStandard();
        }
    }

    public class OperatorExpression : Expression
    {
        private readonly Expression _left;
		private readonly Expression _right;
		private readonly Operator _operator;

        public OperatorExpression(Expression left, Operator theOperator, Expression right)
        {
            _left = left;
            _operator = theOperator;
            _right = right;
        }

        public override Value Calculate()
        {
            return _operator.Apply(_left.Calculate(), _right.Calculate());
        }
    }
}