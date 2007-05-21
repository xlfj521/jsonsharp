using System;
using System.Collections.Generic;
using System.Text;

namespace JSONSharp
{
    public abstract class JSONValueCollection : JSONValue
    {
        protected readonly string JSONVALUE_SEPARATOR = ",";

        internal JSONValueCollection()
        {
        }

        protected abstract string CollectionToPrettyPrint();
        protected abstract string CollectionToString();
        public override string ToString()
        {
            return this.BeginMarker + this.CollectionToString() + this.EndMarker;
        }
        public override string PrettyPrint()
        {
            return Environment.NewLine +
                "".PadLeft(JSONValue.CURRENT_INDENT, Convert.ToChar(base.HORIZONTAL_TAB)) +
                this.BeginMarker +
                Environment.NewLine +
                this.CollectionToPrettyPrint() +
                Environment.NewLine +
                "".PadLeft(JSONValue.CURRENT_INDENT, Convert.ToChar(base.HORIZONTAL_TAB)) +
                this.EndMarker;
        }
        protected abstract string BeginMarker { get; }
        protected abstract string EndMarker { get; }

    }
}
