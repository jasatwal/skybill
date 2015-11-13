using System;

namespace Sky
{
    public class Statement
    {
        private readonly DateTime generated;
        private readonly DateTime due;
        private readonly Period period;

        public DateTime Generated
        {
            get { return generated; }
        }

        public DateTime Due
        {
            get { return due; }
        }

        public Period Period
        {
            get { return period; }
        }

        public Statement(DateTime generated, DateTime due, Period period)
        {
            Check.Argument.IsNotNull(period, nameof(period));

            this.generated = generated;
            this.due = due;
            this.period = period;
        }
    }
}
