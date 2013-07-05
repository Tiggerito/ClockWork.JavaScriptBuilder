using System;
using System.Collections.Generic;
using System.Text;

namespace ClockWork.JavaScriptBuilder
{
	public class ScriptDocument
	{
		private ScriptLines _Content;
		public ScriptLines Content
		{
			get
			{
				if (_Content == null)
					_Content = new ScriptLines(this);
				return _Content;
			}
		}

		public void Render(ScriptWriter writer)
		{
			Content.Render(writer);
		}
	}
}
