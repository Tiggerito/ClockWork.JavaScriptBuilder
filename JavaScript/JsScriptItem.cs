using System;
using System.Collections.Generic;
using System.Text;

namespace ClockWork.JavaScriptBuilder.JavaScript
{
	public abstract class JsScriptItem : ScriptItem
	{
		public JsScriptItem(ScriptDocument sd) : base(sd) { }



		private JsBuilder  _Js = null;
		public JsBuilder  Js
		{
			get {
				if (_Js == null)
					_Js = new JsBuilder(Sd);
				return _Js; 
			}
		}

	}
}
