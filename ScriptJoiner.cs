using System;
using System.Data;
using System.Configuration;

using System.Collections.Generic;
using System.IO;

namespace ClockWork.JavaScriptBuilder
{
    /// <summary>
    /// A ScriptSet with render options to decide how the set is rendered 
    /// </summary>
    /// 
    public class ScriptJoiner : ScriptSet
    {

        public ScriptJoiner(ScriptDocument sd) : base(sd) { }
		public ScriptJoiner(ScriptDocument sd, IEnumerable<object> items) : base(sd, items) { }
		public ScriptJoiner(ScriptDocument sd, params object[] items) : base(sd, items) { }

        private string _Seperator = String.Empty;
        public string Seperator
        {
            get { return _Seperator; }
            set { _Seperator = value; }
        }

        private string _SeperatorCondensed = null;
        public string SeperatorCondensed
        {
            get { return _SeperatorCondensed; }
            set { _SeperatorCondensed = value; }
        }

        private string _Before = null;
        public string Before
        {
            get { return _Before; }
        }

        private string _After = null;
        public string After
        {
            get { return _After; }
        }

        public void SetWrapper(string before, string after)
        {
            _Before = before;
            _After = after;
        }

		protected virtual IEnumerable<object> GetRenderList()
		{
			return this;
		}

        protected override void OnRender(ScriptWriter writer, bool multiLine, bool startOnNewLine)
        {
            string start = String.Empty;
            string end = String.Empty;

            if (Before != null)
            {
                if (startOnNewLine && multiLine && this.Count != 0)
                    writer.WriteNewLineAndIndent();

                writer.Write(Before);
                writer.BeginIndent();
            }

            if (startOnNewLine && multiLine && !this.IsNothing())
                writer.WriteNewLineAndIndent();


            bool first = true;

			foreach (object line in GetRenderList())
            {
                if (line != null)
                {
                    if (line is IScriptItem)
                    {
                        if (!((IScriptItem)line).IsNothing())
                        {
                            if (first)
                                first = false;
                            else
                            {
								if (writer is JsScriptWriter && ((JsScriptWriter)writer).Condensed && this.SeperatorCondensed != null)
                                    writer.Write(this.SeperatorCondensed);
                                else
                                    writer.Write(this.Seperator);

                                if (multiLine)
                                    writer.WriteNewLineAndIndent();

 
                            }

                            ((IScriptItem)line).Render(writer);
                        }
                    }
                    else
                    {
                        if (first)
                            first = false;
                        else
                        {
							if (writer is JsScriptWriter && ((JsScriptWriter)writer).Condensed && this.SeperatorCondensed != null)
                                writer.Write(this.SeperatorCondensed);
                            else
                                writer.Write(this.Seperator);

                            if (multiLine)
                                writer.WriteNewLineAndIndent();
                        }

                        writer.Write(JsScriptWriter.JsFormat(line));
                    }
                }
            }

            if (Before != null)
            {
                writer.EndIndent();

                if (multiLine && this.Count != 0)
                    writer.WriteNewLineAndIndent();

                writer.Write(After);
            }

        }

        public override bool IsNothing()
        {
            if (Before != null)
                return false;

			return IsEmpty();
        }



    }
}