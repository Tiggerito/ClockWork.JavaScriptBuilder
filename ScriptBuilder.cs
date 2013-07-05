using System;
using System.Collections.Generic;
using System.Text;

namespace ClockWork.JavaScriptBuilder
{
	public class ScriptBuilder
	{
		private ScriptDocument  _Document;
		public ScriptDocument  Document
		{
			get { return _Document; }
		}

		public ScriptBuilder(ScriptDocument sd)
		{
			_Document = sd;
		}

		public ScriptLines CreateScriptLines(ScriptFormat format, params object[] lines)
		{
			ScriptLines sl = new ScriptLines(this.Document, lines);
			sl.SetFormat(format);
			return sl;
		}
		public ScriptLines CreateScriptLines(params object[] lines)
		{
			return CreateScriptLines(ScriptFormat.None, lines);
		}
		public ScriptLines SL(ScriptFormat format, params object[] lines)
		{
			return CreateScriptLines(format, lines);
		}
		public ScriptLines SL(params object[] lines)
		{
			return CreateScriptLines(lines);
		}


		public ScriptIf If(object test, object trueValue, object falseValue)
		{
			return new ScriptIf(this.Document, test, trueValue, falseValue);
		}

		public ScriptIf If(object test, object trueValue)
		{
			return If(test, trueValue, null);
		}
	}
}
