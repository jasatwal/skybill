using System.Collections.Generic;

namespace Sky
{
    public class Money : ValueObject
    {
        public static readonly Money Zero = new Money(0M);

        private readonly decimal value;

        public decimal Value
        {
            get { return value; }
        }

        public Money(decimal value)
        {
            this.value = value;
        }

        public Money Add(Money money)
        {
            return new Money(Value + money.Value);
        }

        public Money Subtract(Money money)
        {
            return new Money(Value - money.Value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator decimal (Money money)
        {
            return money.Value;
        }

        public static implicit operator Money(decimal value)
        {
            return new Money(value);
        }
    }
}