using System;
using System.Data;
using System.Configuration;
using System.IO;

namespace ClockWork.JavaScriptBuilder.JavaScript
{
    /// <summary>
    /// Summary description for JsFunction
    /// </summary>
	public class JsFunction : JsScriptItem
    {
        private JsList _Parameters;
        public JsList Parameters
        {
            get
            {
                if (_Parameters == null)
                    _Parameters = Js.CreateList();

                return _Parameters;
            }
            set { _Parameters = value; }
        }

		private ScriptLines _Commands;
		public ScriptLines Commands
        {
            get
            {
                if (_Commands == null)
                    _Commands = Js.CreateScriptLines();

                return _Commands;
            }
            set { _Commands = value; }
        }

        public JsFunction(ScriptDocument sd)
            :base(sd)
        {
        }
		public JsFunction(ScriptDocument sd, ScriptLines commands)
            : this(sd)
        {
            _Commands = commands;
        }
		public JsFunction(ScriptDocument sd, JsList parameters, ScriptLines commands)
			: this(sd, commands)
        {
            _Parameters = parameters;
        }


        protected override void OnRender(ScriptWriter writer, bool multiLine, bool startOnNewLine)
        {
            if (multiLine && startOnNewLine)
                writer.WriteNewLineAndIndent();

            writer.Write("function(");
            Parameters.Render(writer, 1);
            writer.Write(") {");
            Commands.Render(writer, 1);

            if (Commands.MultiLine && !Commands.IsNothing())
                writer.WriteNewLineAndIndent();

            writer.Write("}");
        }

    }
}