using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky
{
    public static class Check
    {
        public static class Argument
        {
            [DebuggerStepThrough]
            public static void IsNotNull(object arg, string paramName)
            {
                if (arg == null)
                    throw new ArgumentNullException(paramName);
            }

            [DebuggerStepThrough]
            public static void IsNotNullOrWhiteSpace(string arg, string paramName)
            {
                IsNotNull(arg, paramName);
                if (String.IsNullOrWhiteSpace(arg))
                    throw new ArgumentException("Cannot be null or white space.", paramName);
            }

            [DebuggerStepThrough]
            public static void IsNumeric(string arg, string paramName)
            {
                if (arg != null && !arg.All(x => Char.IsNumber(x)))
                    throw new ArgumentException("Cannot contain non-numerical characters.", paramName);
            }

            public static void ArrayLenghtIsNotZero<T>(IEnumerable<T> arg, string paramName)
            {
                if (!arg.Any())
                    throw new ArgumentException("Array cannot be empty.", paramName);
            }

            [DebuggerStepThrough]
            public static DateArgument Date(DateTime date, string paramName)
            {
                return new DateArgument(date, paramName);
            }

            public class DateArgument
            {
                private readonly DateTime subjectDate;
                private readonly string subjectParamName;

                public DateArgument(DateTime subjectDate, string subjectParamName)
                {
                    this.subjectDate = subjectDate;
                    this.subjectParamName = subjectParamName;
                }

                [DebuggerStepThrough]
                public void IsAfter(DateTime date, string paramName)
                {
                    if (subjectDate < date)
                        throw new ArgumentException(String.Format("'{0}' cannot be after '{1}'.", subjectParamName, paramName), subjectParamName);
                }

                [DebuggerStepThrough]
                public void IsNotInFuture()
                {
                    if (subjectDate > DateTime.Now)
                        throw new ArgumentException("Cannot be in the future.", subjectParamName);
                }
            }
        }
    }
}
