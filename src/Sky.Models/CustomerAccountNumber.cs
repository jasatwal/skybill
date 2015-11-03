using System.Collections.Generic;

namespace Sky
{
    public class CustomerAccountNumber : ValueObject
    {
        private readonly string value;

        public string Value
        {
            get { return value; }
        }

        public CustomerAccountNumber(string value)
        {
            Check.Argument.IsNotNullOrWhiteSpace(value, nameof(value));

            this.value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
