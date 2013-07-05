using System;
using System.Data;
using System.Configuration;

using System.Collections.Generic;
using System.Text;

namespace ClockWork.JavaScriptBuilder.JavaScript
{
    /// <summary>
    /// Summary description for JsObject
    /// </summary>
    public class JsBlock : JsScriptSet 
    {
        public JsBlock(ScriptDocument sd) : base(sd) { }
        public JsBlock(ScriptDocument sd, IEnumerable<object> lines) : base(sd, lines) { }
		public JsBlock(ScriptDocument sd, params object[] lines) : base(sd, lines) { }

        protected override void OnInitialise()
        {
            base.OnInitialise();

			this.MultiLine = true;
			this.StartOnNewLine = true;
            this.SetWrapper("{", "}");
        }



    }
}