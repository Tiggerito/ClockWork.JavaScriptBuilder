using System;
using System.Collections.Generic;
using System.Text;

namespace ClockWork.JavaScriptBuilder.JavaScript
{
	public class JsScriptSet : ScriptSet 
	{

		public JsScriptSet(ScriptDocument sd) : base(sd) { }
        public JsScriptSet(ScriptDocument sd, IEnumerable<object> lines) : base(sd, lines) { }
		public JsScriptSet(ScriptDocument sd, params object[] lines) : base(sd, lines) { }


		private JsBuilder  _Js = null;
		public JsBuilder  Js
		{
			get {
				if (_Js == null)
					_Js = new JsBuilder(Sd);
				return _Js; 
			}
		}

		private string _SeperatorCondensed = null;
		public string SeperatorCondensed 
		{
			get { return _SeperatorCondensed; }
			set { _SeperatorCondensed = value; }
		}

		protected override void WriteSeperator(ScriptWriter writer)
		{
			if (writer is JsScriptWriter && ((JsScriptWriter)writer).Condensed && this.SeperatorCondensed != null)
				writer.Write(this.SeperatorCondensed);
			else
				base.WriteSeperator(writer);
		}
	}
}
