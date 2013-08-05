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
        private readonly ValueExpression _left;
        private readonly Operator _operator;
        private readonly ValueExpression _right;

        public OperatorExpression(ValueExpression left, Operator theOperator, ValueExpression right)
        {
            _left = left;
            _operator = theOperator;
            _right = right;
        }

        public override Value Calculate()
        {
            return _operator.Apply(_left.Inner, _right.Inner);
        }
    }
}