namespace Domain.Object
{
    public abstract class QueryAttribute
    {
        public string name { get; set; }
        public abstract AttributeType type { get; }
    }

    public class StringAttribute : QueryAttribute
    {
        public string value { get; set; }
        public StringCondition condition { get; set; }
        public override AttributeType type { get; } = AttributeType.String;
    }

    public class DecimalAttribute : QueryAttribute
    {
        public decimal value { get; set; }
        public NumericCondition condition { get; set; }

        public override AttributeType type { get; } = AttributeType.Decimal;
    }

    public class IntegerAttribute : QueryAttribute
    {
        public int value { get; set; }
        public NumericCondition condition { get; set; }
        public override AttributeType type { get; } = AttributeType.Integer ;
    }

    public enum StringCondition
    {
        Equal,
        Contains
    }

    public enum NumericCondition
    {
        Equal,
        GreaterThan,
        SmallerThan
    }

    public enum PropertyAttribute
    {
        Name,
        Address,
        Price,
        CodeInternal,
        Year
    }

    public enum AttributeType
    {
        String,
        Decimal,
        Integer
    }
}
