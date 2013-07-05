using System;
using System.Data;
using System.Configuration;

using System.Collections.Generic;

namespace ClockWork.JavaScriptBuilder.JavaScript
{
    /// <summary>
    /// Summary description for JsList
    /// </summary>
    public class JsList : JsScriptSet
    {
        protected override void OnInitialise()
        {
            base.OnInitialise();

            this.Seperator = ", ";
            this.SeperatorCondensed = ",";
            this.MultiLine = true;
        }

        public JsList(ScriptDocument sd) : base(sd) { }
        public JsList(ScriptDocument sd, IEnumerable<object> lines) : base(sd, lines) { }
        public JsList(ScriptDocument sd, params object[] lines) : base(sd, lines) { }
    }
}