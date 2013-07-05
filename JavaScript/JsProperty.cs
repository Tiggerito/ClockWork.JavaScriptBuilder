using System;
using System.Data;
using System.Configuration;

using System.IO;

namespace ClockWork.JavaScriptBuilder.JavaScript
{
    /// <summary>
    /// Summary description for JsProperty
    /// </summary>
	public class JsProperty : JsScriptItem
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private object _Value;

        public object Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public JsProperty(ScriptDocument sd, string name, object value)
            :base(sd)
        {
            _Name = name;
            _Value = value;
        }


        protected override void OnRender(ScriptWriter writer, bool multiLine, bool startOnNewLine)
        {
            if (multiLine && startOnNewLine)
                writer.WriteNewLineAndIndent();

            writer.Write(Name + ": ");

            if (Value is IScriptItem)
            {
                if (!((IScriptItem)Value).IsNothing())
                {
                    ((IScriptItem)Value).Render(writer);
                }
            }
            else
            {
				writer.Write(Value);
            }

        }

        public override bool IsNothing()
        {
            return Name == null;
        }

    }
}