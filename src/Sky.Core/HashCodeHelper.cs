using System;
using System.Collections.Generic;

namespace Sky
{
    public class HashCodeHelper
    {
        public static int CombineHashCodes(IEnumerable<object> objects)
        {
            unchecked
            {
                var hash = 17;
                foreach (var obj in objects)
                    hash = hash * 23 + (obj?.GetHashCode()).GetValueOrDefault();
                return hash;
            }
        }
    }
}