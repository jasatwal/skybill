using System;

namespace Sky
{
    public class Period
    {
        private readonly DateTime from;
        private readonly DateTime to;

        public DateTime From
        {
            get { return from; }
        }

        public DateTime To
        {
            get { return to; }
        }

        public Period(DateTime from, DateTime to)
        {
            Check.Argument.Date(to, nameof(to)).IsAfter(from, nameof(from));

            this.from = from;
            this.to = to;
        }
    }
}