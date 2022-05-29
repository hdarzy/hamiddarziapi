using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public static class StringExtentions
    {
        public static bool Hasvalue(this string value, bool ignoreWhiteSpace = true)
        {
            return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrWhiteSpace(value);
        }
        public static int ToInt (this string value)
        {
            return Convert.ToInt32(value);
        }
        public static Decimal ToDecimal(this string value)
        {
            return Convert.ToDecimal(value); 
        }


    }
}
