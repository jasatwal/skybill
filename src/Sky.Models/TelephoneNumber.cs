using System.Collections.Generic;

namespace Sky
{
    public class TelephoneNumber : ValueObject
    {
        private readonly string value;

        public string Value
        {
            get { return value; }
        }

        public TelephoneNumber(string value)
        {
            Check.Argument.IsNotNullOrWhiteSpace(value, nameof(value));
            Check.Argument.IsNumeric(value, nameof(value));

            this.value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string (TelephoneNumber number)
        {
            return number.Value;
        }

        public static implicit operator TelephoneNumber(string value)
        {
            return new TelephoneNumber(value);
        }
    }
}
