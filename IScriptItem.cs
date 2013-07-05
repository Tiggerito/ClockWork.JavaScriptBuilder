using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.IO;

namespace ClockWork.JavaScriptBuilder
{
    /// <summary>
    /// Summary description for IToJavaScript
    /// </summary>
	public interface IScriptItem
    {
		ScriptDocument Document { get;}

        void Render(ScriptWriter writer);
        void Render(ScriptWriter writer, int indents);

        bool IsNothing();
		bool IsEmpty();
    }
}
