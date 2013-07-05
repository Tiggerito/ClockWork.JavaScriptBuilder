using System;
using System.Data;
using System.Configuration;

using System.Collections.Generic;

namespace ClockWork.JavaScriptBuilder.JavaScript
{
    /// <summary>
    /// Summary description for JsArray
    /// </summary>
    public class JsArray : JsList
    {
        public JsArray(ScriptDocument sd) : base(sd) { }
        public JsArray(ScriptDocument sd, IEnumerable<object> lines) : base(sd, lines) { }
        public JsArray(ScriptDocument sd, params object[] lines) : base(sd, lines) { }

        protected override void OnInitialise()
        {
            base.OnInitialise();

            this.MultiLine = true;
            this.StartOnNewLine = true;

            this.SetWrapper("[", "]");
        }

        //public override string GetJavaScript(bool multiLine, bool startOnNewLine)
        //{
        //    return 
        //        this.StartString(multiLine && this.Count!=0, startOnNewLine) +
        //        "[" + JsIndent.Begin() + base.GetJavaScript(multiLine, true) + JsIndent.End() + this.LineSeperator(multiLine && this.Count != 0) + "]";

        //}
    }
}
