using System;
using System.Collections.Generic;
using System.Text;

namespace ClockWork.JavaScriptBuilder.JavaScript
{
	public class JsQuote : JsScriptItem
    {
        public JsQuote(ScriptDocument sd, object text, bool doubleQuotes)
            : base(sd)
        {
            Text = text;
            DoubleQuotes = doubleQuotes;
            this.MultiLine = false;
            this.StartOnNewLine = false;
        }
        public JsQuote(ScriptDocument sd, object text)
			: this(sd, text, false)
        {
        }
        public JsQuote(ScriptDocument sd)
			: this(sd, null, false)
        {
        }

        private object _Text;
        public object Text
        {
            get { return _Text; }
            set { _Text = value; }
        }


        private bool _DoubleQuotes;
        public bool DoubleQuotes
        {
            get { return _DoubleQuotes; }
            set { _DoubleQuotes = value; }
        }

        protected override void OnRender(ScriptWriter writer, bool multiLine, bool startOnNewLine)
        {
            if (multiLine && startOnNewLine)
                writer.WriteNewLineAndIndent();

            string quote = this.DoubleQuotes ? "\"" : "'";
            if (Text == null)
                writer.Write(quote + quote);

			writer.Write(quote + JsScriptWriter.JsConvert(Text).ToString().Replace(quote, @"\" + quote) + quote);
        }



    }
}
