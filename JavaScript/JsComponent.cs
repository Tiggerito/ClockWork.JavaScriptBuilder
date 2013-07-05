using System;
using System.Data;
using System.Configuration;

using System.IO;

namespace ClockWork.JavaScriptBuilder.JavaScript
{
    /// <summary>
    /// Summary description for JsComponent
    /// </summary>
	public abstract class JsComponent : JsScriptItem
    {
		public JsComponent(ScriptDocument sd) : base(sd) { }

        private ScriptLines _Content = null;
        public ScriptLines Content
        {
            get
            {
                if (_Content==null)
                    _Content = Js.CreateScriptLines(Js);

                return _Content;
            }
        }
        private bool _Built = false;
        public void EnsureBuilt()
        {
            if (!_Built)
                Build();
        }

        public void Build()
        {
     //       _Content = Js.CreateMultiLine();
            _Built = true;
            OnBuild();
        }

        protected abstract void OnBuild();

        protected override void OnRender(ScriptWriter writer, bool multiLine, bool startOnNewLine)
        {
            EnsureBuilt();

            Content.Render(writer);
        }
    }
}