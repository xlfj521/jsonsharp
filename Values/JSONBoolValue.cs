using System;
using System.Collections.Generic;
using System.Text;
using JSONSharp;

namespace JSONSharp.Values
{
    public class JSONBoolValue : JSONValue
    {
        private string _value;

        public JSONBoolValue(bool value)
            : base()
        {
            this._value = value.ToString().ToLower();
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
