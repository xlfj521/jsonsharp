using System;
using System.Collections.Generic;
using System.Text;

namespace JSONSharp
{
    /// <summary>
    /// A JSON value can be a string in double quotes, or a number, or true or false or null, or an 
    /// object or an array. These structures can be nested.
    /// </summary>
    public abstract class JSONValue
    {
        protected readonly string HORIZONTAL_TAB = "\t";
        public static int CURRENT_INDENT = 0;

        internal JSONValue()
        {
        }

        public abstract override string ToString();
        public abstract string PrettyPrint();
    }
}
