using System;
using System.Data;
using System.Configuration;
using System.IO;

namespace ClockWork.JavaScriptBuilder
{
	// Builder, Maker, Scriptor, Writer, Designer, Constructor, Scribe
	// Text, String, Script

    /// <summary>
    /// Summary description for JsBase
    /// </summary>
    public abstract class ScriptItem : IScriptItem
    {
        public ScriptItem(ScriptDocument sd)
        {
            _Sd = sd;

            this.OnInitialise();
        }

        public void SetFormat(ScriptFormat format)
        {
            switch (format)
            {
                case ScriptFormat.None:
                    break;
                case ScriptFormat.Inline:
                    this._StartOnNewLine = false;
                    this._MultiLine = false;
                    break;
                case ScriptFormat.MultiLine:
                    this._MultiLine = true;
                    this._StartOnNewLine = false;
                    break;
                case ScriptFormat.StartOnNewLine:
                    this._StartOnNewLine = true;
                    this._MultiLine = true;
                    break;
                default:
                    break;
            }
        }

        protected virtual void OnInitialise()
        {
        }

		private ScriptDocument _Sd;

		/// <summary>
		/// Short hand for Document. "Script Document"
		/// </summary>
		public ScriptDocument Sd
        {
			get { return _Sd; }
        }
		public ScriptDocument Document
		{
			get { return _Sd; }
		}


        private int _Indents = 0;
        public int Indents
        {
            get { return _Indents; }
            set { _Indents = value; }
        }

        private bool _MultiLine = false;
        public bool MultiLine
        {
            get { return _MultiLine; }
            set { _MultiLine = value; }
        }

        private bool _StartOnNewLine = false;
        public bool StartOnNewLine
        {
            get { return _StartOnNewLine; }
            set { _StartOnNewLine = value; }
        }

        public void Render(ScriptWriter writer)
        {
            Render(writer, null);
        }
        public void Render(ScriptWriter writer, int indents)
        {
            Render(writer, indents, null);
        }
        public void Render(ScriptWriter writer, bool? multiLine)
        {
            Render(writer, 0, multiLine);
        }
        public void Render(ScriptWriter writer, int indents, bool? multiLine)
        {
            Render(writer, indents, multiLine, null);
        }

        public void Render(ScriptWriter writer, int indents, bool? multiLine, bool? startOnNewLine)
        {
            bool realMultiLine = multiLine == null ? MultiLine : (bool)multiLine;
            bool realStartOnNewLine = startOnNewLine == null ? StartOnNewLine : (bool)startOnNewLine;

            if (realMultiLine) // don't indent if not multiline
            {
                writer.BeginIndent(Indents + indents);

                OnRender(writer, realMultiLine, realStartOnNewLine);

                writer.EndIndent(Indents + indents);
            }
            else
            {
                OnRender(writer, realMultiLine, realStartOnNewLine);
            }
        }



        protected abstract void OnRender(ScriptWriter writer, bool multiLine, bool startOnNewLine);


		/// <summary>
		/// If it will render as nothing
		/// </summary>
		/// <returns></returns>
		public virtual bool IsNothing()
		{
			return false;
		}

		/// <summary>
		/// for example a list with no  values
		/// used in JsIf testing to decide true or false
		/// </summary>
		/// <returns></returns>
		public virtual bool IsEmpty()
		{
			return false;
		}
    }
}
