using System;
using System.Collections.Generic;
using System.Text;
using JSONSharp;
using JSONSharp.Values;

namespace JSONSharp.Collections
{
    /// <summary>
    /// A JSON object is an unordered set of name/value pairs. An object begins with "{" (left brace) 
    /// and ends with "}" (right brace). Each name is followed by ":" (colon) and the name/value pairs 
    /// are separated by "," (comma).
    /// </summary>
    public class JSONObjectCollection : JSONValueCollection
    {
        private Dictionary<JSONStringValue, JSONValue> _namevaluepairs;
        private readonly string NAMEVALUEPAIR_SEPARATOR = ":";

        public JSONObjectCollection(Dictionary<JSONStringValue, JSONValue> namevaluepairs)
            : base()
        {
            this._namevaluepairs = namevaluepairs;
        }

        public JSONObjectCollection()
            : base()
        {
            this._namevaluepairs = new Dictionary<JSONStringValue, JSONValue>();
        }

        public void Add(JSONStringValue name, JSONValue value)
        {
            if (!this._namevaluepairs.ContainsKey(name))
                this._namevaluepairs.Add(name, value);
        }

        protected override string CollectionToPrettyPrint()
        {
            JSONValue.CURRENT_INDENT++;
            List<string> output = new List<string>();
            List<string> nvps = new List<string>();
            foreach (KeyValuePair<JSONStringValue, JSONValue> kvp in this._namevaluepairs)
                nvps.Add("".PadLeft(JSONValue.CURRENT_INDENT, Convert.ToChar(base.HORIZONTAL_TAB)) + kvp.Key.PrettyPrint() + this.NAMEVALUEPAIR_SEPARATOR + kvp.Value.PrettyPrint());
            output.Add(string.Join(base.JSONVALUE_SEPARATOR + Environment.NewLine, nvps.ToArray()));
            JSONValue.CURRENT_INDENT--;
            return string.Join("", output.ToArray());
        }

        protected override string CollectionToString()
        {
            List<string> output = new List<string>();
            List<string> nvps = new List<string>();
            foreach (KeyValuePair<JSONStringValue, JSONValue> kvp in this._namevaluepairs)
                nvps.Add(kvp.Key.ToString() + this.NAMEVALUEPAIR_SEPARATOR + kvp.Value.ToString());
            output.Add(string.Join(base.JSONVALUE_SEPARATOR, nvps.ToArray()));
            return string.Join("", output.ToArray());
        }

        protected override string BeginMarker
        {
            get { return "{"; }
        }
        protected override string EndMarker
        {
            get { return "}"; }
        }

    }
}
