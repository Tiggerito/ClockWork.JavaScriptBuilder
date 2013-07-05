using System;
using System.Data;
using System.Configuration;

using System.Collections.Generic;
using System.Text;

namespace ClockWork.JavaScriptBuilder
{
    /// <summary>
    /// Summary description for JsMultiLine
    /// </summary>
    /// 
	public class ScriptLines : ScriptSet
    {
        protected override void OnInitialise()
        {
            base.OnInitialise();

            this.Seperator = String.Empty;
            this.MultiLine = true;
            this.StartOnNewLine = true;
        }

        public ScriptLines(ScriptDocument sd) : base(sd) { }
        public ScriptLines(ScriptDocument sd, IEnumerable<object> lines) : base(sd, lines) { }
        public ScriptLines(ScriptDocument sd, params object[] lines) : base(sd, lines) { }


    }
}