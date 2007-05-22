using System;
using System.Collections.Generic;
using System.Text;
using JSONSharp;

namespace JSONSharp.Values
{
    /// <summary>
    /// JSONNumberValue is very much like a C# number, except that octal and hexadecimal formats 
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

        /// <summary>
        /// Public constructor that accepts a value of type int
        /// </summary>
        /// <param name="value">int (System.Int32) value</param>
        public JSONNumberValue(int value)
            : this(value.ToString())
        {
        }

        /// <summary>
        /// Public constructor that accepts a value of type double
        /// </summary>
        /// <param name="value">double (System.Double) value</param>
        public JSONNumberValue(double value)
            : this(value.ToString(""))
        {
        }

        /// <summary>
        /// Public constructor that accepts a value of type decimal
        /// </summary>
        /// <param name="value">decimal (System.Decimal) value</param>
        public JSONNumberValue(decimal value)
            : this(value.ToString(""))
        {
        }

        /// <summary>
        /// Public constructor that accepts a value of type single
        /// </summary>
        /// <param name="value">single (System.Single) value</param>
        public JSONNumberValue(Single value)
            : this(value.ToString("E"))
        {
        }

        /// <summary>
        /// Public constructor that accepts a value of type byte
        /// </summary>
        /// <param name="value">byte (System.Byte) value</param>
        public JSONNumberValue(byte value)
            : this(value.ToString())
        {
        }

        /// <summary>
        /// Required override of ToString() method.
        /// </summary>
        /// <returns>contained numeric value, rendered as a string</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        /// Required override of the PrettyPrint() method.
        /// </summary>
        /// <returns>this.ToString()</returns>
        public override string PrettyPrint()
        {
            return this.ToString();
        }
    }

}
