using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using JSONSharp;

namespace JSONSharp.Collections
{
    /// <summary>
    /// A JSON array is an ordered collection of values. An array begins with "[" (left bracket) and 
    /// ends with "]" (right bracket). Values are separated by "," (comma).
    /// </summary>
    public class JSONArrayCollection : JSONValueCollection
    {
        protected List<JSONValue> _values;

        public JSONArrayCollection(List<JSONValue> values)
            : base()
        {
            this._values = values;
        }

        public JSONArrayCollection()
            : base()
        {
            this._values = new List<JSONValue>();
        }

        public void Add(JSONValue value)
        {
            if (!this._values.Contains(value))
                this._values.Add(value);
        }

        protected override string CollectionToPrettyPrint()
        {
            JSONValue.CURRENT_INDENT++;
            List<string> output = new List<string>();
            List<string> nvps = new List<string>();
            foreach (JSONValue jv in this._values)
                nvps.Add("".PadLeft(JSONValue.CURRENT_INDENT, Convert.ToChar(base.HORIZONTAL_TAB)) + jv.PrettyPrint());
            output.Add(string.Join(base.JSONVALUE_SEPARATOR + Environment.NewLine, nvps.ToArray()));
            JSONValue.CURRENT_INDENT--;
            return string.Join("", output.ToArray());
        }

        protected override string CollectionToString()
        {
            List<string> output = new List<string>();
            List<string> nvps = new List<string>();
            foreach (JSONValue jv in this._values)
                nvps.Add(jv.ToString());

            output.Add(string.Join(base.JSONVALUE_SEPARATOR, nvps.ToArray()));
            return string.Join("", output.ToArray());
        }

        protected override string BeginMarker
        {
            get { return "["; }
        }
        protected override string EndMarker
        {
            get { return "]"; }
        }


    }
}
