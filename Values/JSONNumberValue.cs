using System;
using System.Collections.Generic;
using System.Text;
using JSONSharp;

namespace JSONSharp.Values
{
    /// <summary>
    /// A JSON number is very much like a C# number, except that the octal and hexadecimal formats 
    /// are not used.
    /// </summary>
    public class JSONNumberValue : JSONValue
    {
        private string _value;

        internal JSONNumberValue(string value)
            : base()
        {
            this._value = value;
        }

        public JSONNumberValue(int value)
            : this(value.ToString())
        {
        }

        public JSONNumberValue(double value)
            : this(value.ToString(""))
        {
        }

        public JSONNumberValue(decimal value)
            : this(value.ToString(""))
        {
        }

        public JSONNumberValue(Single value)
            : this(value.ToString("E"))
        {
        }

        public JSONNumberValue(byte value)
            : this(value.ToString())
        {
        }

        public override string ToString()
        {
            return this._value;
        }

        public override string PrettyPrint()
        {
            return this.ToString();
        }
    }

}
