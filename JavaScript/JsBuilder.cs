using System;
using System.Collections.Generic;
using System.Text;

namespace ClockWork.JavaScriptBuilder.JavaScript
{
	public class JsBuilder : ScriptBuilder
	{

		public JsBuilder(ScriptDocument sd): base(sd) {}

		public JsQuote QS(string text)
		{
			return CreateQuoteSingle(text);
		}

		public JsQuote CreateQuoteSingle(string text)
		{
			return new JsQuote(this.Document, text, false);
		}

		public JsQuote QD(object text)
		{
			return CreateQuoteDouble(text);
		}
		public JsQuote CreateQuoteDouble(object text)
		{
			return new JsQuote(this.Document, text, true);
		}


		public JsCall CreateNewCall(ScriptFormat format, string className, params object[] items)
		{
			JsCall c = new JsCall(this.Document, className, items);
			c.New = true;
			c.SetFormat(format);
			return c;
		}
		public JsCall CreateNewCall(string className, params object[] items)
		{
			return CreateNewCall(ScriptFormat.None, className, items);
		}
		public JsCall N(ScriptFormat format, string className, params object[] items)
		{
			return CreateNewCall(format, className, items);
		}
		public JsCall N(string className, params object[] items)
		{
			return CreateNewCall(className, items);
		}


		public JsObject CreateObject(ScriptFormat format, params object[] properties)
		{
			JsObject o = new JsObject(this.Document, properties);
			o.SetFormat(format);
			return o;
		}
		public JsObject CreateObject(params object[] properties)
		{
			return CreateObject(ScriptFormat.None, properties);
		}
		public JsObject O(ScriptFormat format, params object[] properties)
		{
			return CreateObject(format, properties);
		}
		public JsObject O(params object[] properties)
		{
			return CreateObject(properties);
		}

		public JsProperty CreateProperty(ScriptFormat format, string name, object value)
		{
			JsProperty p = new JsProperty(this.Document, name, value);
			p.SetFormat(format);
			return p;
		}
		public JsProperty CreateProperty(string name, object value)
		{
			return CreateProperty(ScriptFormat.None, name, value);
		}
		public JsProperty P(ScriptFormat format, string name, object value)
		{
			return CreateProperty(format, name, value);
		}
		public JsProperty P(string name, object value)
		{
			return CreateProperty(name, value);
		}


		public JsArray CreateArray(ScriptFormat format, params object[] list)
		{
			JsArray a = new JsArray(this.Document, list);
			a.SetFormat(format);
			return a;
		}
		public JsArray CreateArray(params object[] list)
		{
			return CreateArray(ScriptFormat.None, list);
		}
		public JsArray A(ScriptFormat format, params object[] list)
		{
			return CreateArray(format, list);
		}

		public JsArray A(params object[] list)
		{
			return CreateArray(list);
		}





		public JsBlock CreateBlock(ScriptFormat format, params object[] lines)
		{
			JsBlock m = new JsBlock(this.Document, lines);
			m.SetFormat(format);
			return m;
		}
		public JsBlock CreateBlock(params object[] lines)
		{
			return CreateBlock(ScriptFormat.None, lines);
		}
		public JsBlock B(ScriptFormat format, params object[] lines)
		{
			return CreateBlock(format, lines);
		}
		public JsBlock B(params object[] lines)
		{
			return CreateBlock(lines);
		}


		public JsFunction CreateFunction(ScriptFormat format, JsList parameters, ScriptLines commands)
		{
			JsFunction f = new JsFunction(this.Document, parameters, commands);
			f.SetFormat(format);
			return f;
		}
		public JsFunction CreateFunction(JsList parameters, ScriptLines commands)
		{
			return CreateFunction(ScriptFormat.None, parameters, commands);
		}
		public JsFunction F(ScriptFormat format, JsList parameters, ScriptLines commands)
		{
			return CreateFunction(format, parameters, commands);
		}
		public JsFunction F(JsList parameters, ScriptLines commands)
		{
			return CreateFunction(parameters, commands);
		}


		public JsFunction CreateFunction(ScriptFormat format, ScriptLines commands)
		{
			JsFunction f = new JsFunction(this.Document, commands);
			f.SetFormat(format);
			return f;
		}
		public JsFunction CreateFunction(ScriptLines commands)
		{
			return CreateFunction(ScriptFormat.None, commands);
		}
		public JsFunction F(ScriptFormat format, ScriptLines commands)
		{
			return CreateFunction(format, commands);
		}
		public JsFunction F(ScriptLines commands)
		{
			return CreateFunction(commands);
		}



		public JsCall CreateCall(ScriptFormat format, string function, params object[] items)
		{
			JsCall c = new JsCall(this.Document, function, items);
			c.SetFormat(format);
			return c;
		}
		public JsCall CreateCall(string function, params object[] items)
		{
			return CreateCall(ScriptFormat.None, function, items);
		}
		public JsCall C(ScriptFormat format, string function, params object[] items)
		{
			return CreateCall(format, function, items);
		}
		public JsCall C(string function, params object[] items)
		{
			return CreateCall(function, items);
		}

		public JsList CreateList(ScriptFormat format, params object[] items)
		{
			JsList l = new JsList(this.Document, items);
			l.SetFormat(format);
			return l;
		}
		public JsList CreateList(params object[] items)
		{
			return CreateList(ScriptFormat.None, items);
		}
		public JsList L(ScriptFormat format, params object[] items)
		{
			return CreateList(format, items);
		}
		public JsList L(params object[] items)
		{
			return CreateList(items);
		}


		public ScriptSet CreateScriptSet(ScriptFormat format, params object[] items)
		{
			ScriptSet j = new ScriptSet(this.Document, items);
			j.SetFormat(format);
			return j;
		}
		public ScriptSet CreateScriptSet(params object[] items)
		{
			return CreateScriptSet(ScriptFormat.None, items);
		}
		public ScriptSet S(ScriptFormat format, params object[] items)
		{
			return CreateScriptSet(format, items);
		}
		public ScriptSet S(params object[] items)
		{
			return CreateScriptSet(items);
		}


		//public JsVariable CreateVariable(string name, string shortName)
		//{
		//    return new JsVariable(name, shortName);
		//}
		//public JsVariable V(string name, string shortName)
		//{
		//    return CreateVariable(name, shortName);
		//}





	}
}
