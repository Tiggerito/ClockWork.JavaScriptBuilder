using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security;

namespace ClockWork.JavaScriptBuilder.JavaScript
{
	/// <summary>
	/// Extends the ScriptWriter to support:
	/// Condensed writing
	/// 
	/// Also provides JsFormat() to convert data to valid javascript formats (e.g. booleans)  
	/// </summary>
    public class JsScriptWriter: ScriptWriter
    {

		public JsScriptWriter(TextWriter writer) : base(writer) {}
		public JsScriptWriter(Stream stream): base(stream) {}


#if DEBUG
        private bool _Condensed = false;
#else
        private bool _Condensed = true;
#endif

		/// <summary>
		/// If set, the writer will reduce the size of the script
		/// Defaults to true of not using DEBUG compilation option
		/// </summary>
        public bool Condensed
        {
            get { return _Condensed; }
            set { _Condensed = value; }
        }

		/// <summary>
		/// Add condensed support to stop new lines happening
		/// </summary>
        public override void WriteNewLine()
        {
			if (!Condensed)
				base.WriteNewLine();
        }

		/// <summary>
		/// Add condensed support to stop indenting happening
		/// </summary>
		public override void WriteIndent()
		{
			if (!Condensed)
				base.WriteIndent();
		}

		public override void Write(object o)
		{
			base.Write(JsConvert(o));
		}


		/// <summary>
		/// Utility to help format types for javascript
		/// e.g. booleans to true/false
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static object JsConvert(object o)
        {
            if (o is bool)
                return o.ToString().ToLower();

            if (o is DateTime)
                return ((DateTime)o).ToString("c"); // TODO: find out correct format?

			return ScriptWriter.Convert(o);
        }



  
    }
}
