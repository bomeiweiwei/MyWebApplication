using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqStudyConsoleApplication
{
    class ExtensionMethods
    {
    }

    public static class Int32Extension
    {
        public static string FormatForMoney(this int value)
        {
            return value.ToString("$###,###,###,##0");
        }
    }

    public static class DoubleExtension
    {
        public static string FormatPercent(this double value)
        {
            return value.ToString("0.00%");
        }
    }
}
