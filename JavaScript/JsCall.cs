using System;
using System.Data;
using System.Configuration;

using System.IO;

namespace ClockWork.JavaScriptBuilder.JavaScript
{
    /// <summary>
    /// Summary description for JsCall
    /// </summary>
	public class JsCall : JsScriptItem
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

        private string _Function;
        public string Function
        {
            get { return _Function; }
            set { _Function = value; }
        }

        private bool _New = false;
        public bool New
        {
            get { return _New; }
            set { _New = value; }
        }

        public JsCall(ScriptDocument sd, string function, JsList parameters)
            : base(sd)
        {
            Function = function;

            Parameters = parameters;

        }

        public JsCall(ScriptDocument sd, string function, params object[] parameters)
            : base(sd)
        {
            Function = function;
            Parameters = Js.CreateList(parameters);
        }


        protected override void OnRender(ScriptWriter writer, bool multiLine, bool startOnNewLine)
        {
            if (multiLine && startOnNewLine)
                writer.WriteNewLineAndIndent();

            if (New)
                writer.Write("new ");

            writer.Write(Function);
            writer.Write("(");
            Parameters.Render(writer, 1);

            if (multiLine && !Parameters.IsNothing())
                writer.WriteNewLineAndIndent();

            writer.Write(")");
        }

    }
}