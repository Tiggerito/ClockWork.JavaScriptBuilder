using System;
using System.Data;
using System.Configuration;

using System.Collections.Generic;
using System.IO;

namespace ClockWork.JavaScriptBuilder
{
    /// <summary>
    /// Summary description for JsDocument
    /// </summary>
	public class JsDocument : ScriptDocument
    {
        public JsDocument()
        {
        }



		//private JsVariableFactory _VariableFactory;
		//public JsVariableFactory VariableFactory
		//{
		//    get
		//    {
		//        if (_VariableFactory == null)
		//            _VariableFactory = new JsVariableFactory();
		//        return _VariableFactory;
		//    }

		//    set { _VariableFactory = value; }
		//}




        private JsMultiLine _Content;
        public JsMultiLine Content
        {
            get { 
                if (_Content==null)
                    _Content = new JsMultiLine(this);
                return _Content; 
            }
        }

        public void Render(ScriptWriter writer)
        {
            Content.Render(writer);
        }


        public JsQuote QS(string text)
        {
            return CreateQuoteSingle(text);
        }

        public JsQuote CreateQuoteSingle(string text)
        {
            return new JsQuote(this, text, false);
        }

        public JsQuote QD(object text)
        {
            return CreateQuoteDouble(text);
        }
        public JsQuote CreateQuoteDouble(object text)
        {
            return new JsQuote(this,text, true);
        }


        public JsCall CreateNewCall(JsFormat format, string className, params object[] items)
        {
            JsCall c = new JsCall(this, className, items);
            c.New = true;
            c.SetFormat(format);
            return c;
        }
        public JsCall CreateNewCall(string className, params object[] items)
        {
            return CreateNewCall(JsFormat.None, className, items);
        }
        public JsCall N(JsFormat format, string className, params object[] items)
        {
            return CreateNewCall(format, className, items);
        }
        public JsCall N(string className, params object[] items)
        {
            return CreateNewCall(className, items);
        }


        public JsObject CreateObject(JsFormat format, params object[] properties)
        {
            JsObject o =  new JsObject(this, properties);
            o.SetFormat(format);
            return o;
        }
        public JsObject CreateObject(params object[] properties)
        {
            return CreateObject(JsFormat.None, properties);
        }
        public JsObject O(JsFormat format, params object[] properties)
        {
            return CreateObject(format, properties);
        }
        public JsObject O(params object[] properties)
        {
            return CreateObject(properties);
        }

        public JsProperty CreateProperty(JsFormat format, string name, object value)
        {
            JsProperty p = new JsProperty(this, name, value);
            p.SetFormat(format);
            return p;
        }
        public JsProperty CreateProperty(string name, object value)
        {
            return CreateProperty(JsFormat.None, name, value);
        }
        public JsProperty P(JsFormat format, string name, object value)
        {
            return CreateProperty(format, name, value);
        }
        public JsProperty P(string name, object value)
        {
            return CreateProperty(name, value);
        }


        public JsArray CreateArray(JsFormat format, params object[] list)
        {
            JsArray a = new JsArray(this, list);
            a.SetFormat(format);
            return a;
        }
        public JsArray CreateArray(params object[] list)
        {
            return CreateArray(JsFormat.None, list);
        }
        public JsArray A(JsFormat format, params object[] list)
        {
            return CreateArray(format, list);
        }

        public JsArray A(params object[] list)
        {
            return CreateArray(list);
        }



        public JsMultiLine CreateMultiLine(JsFormat format, params object[] lines)
        {
            JsMultiLine m =  new JsMultiLine(this, lines);
            m.SetFormat(format);
            return m;
        }
        public JsMultiLine CreateMultiLine(params object[] lines)
        {
            return CreateMultiLine(JsFormat.None, lines);
        }
        public JsMultiLine ML(JsFormat format, params object[] lines)
        {
            return CreateMultiLine(format, lines);
        }
        public JsMultiLine ML(params object[] lines)
        {
            return CreateMultiLine(lines);
        }

		public JsBlock CreateBlock(JsFormat format, params object[] lines)
		{
			JsBlock m = new JsBlock(this, lines);
			m.SetFormat(format);
			return m;
		}
		public JsBlock CreateBlock(params object[] lines)
		{
			return CreateBlock(JsFormat.None, lines);
		}
		public JsBlock B(JsFormat format, params object[] lines)
		{
			return CreateBlock(format, lines);
		}
		public JsBlock B(params object[] lines)
		{
			return CreateBlock(lines);
		}


        public JsFunction CreateFunction(JsFormat format, JsList parameters, JsMultiLine commands)
        {
            JsFunction f =  new JsFunction(this, parameters, commands);
            f.SetFormat(format);
            return f;
        }
        public JsFunction CreateFunction(JsList parameters, JsMultiLine commands)
        {
            return CreateFunction(JsFormat.None, parameters, commands);
        }
        public JsFunction F(JsFormat format, JsList parameters, JsMultiLine commands)
        {
            return CreateFunction(format, parameters, commands);
        }
        public JsFunction F(JsList parameters, JsMultiLine commands)
        {
            return CreateFunction(parameters, commands);
        }


        public JsFunction CreateFunction(JsFormat format, JsMultiLine commands)
        {
            JsFunction f = new JsFunction(this, commands);
            f.SetFormat(format);
            return f;
        }
        public JsFunction CreateFunction(JsMultiLine commands)
        {
            return CreateFunction(JsFormat.None, commands);
        }
        public JsFunction F(JsFormat format, JsMultiLine commands)
        {
            return CreateFunction(format, commands);
        }
        public JsFunction F(JsMultiLine commands)
        {
            return CreateFunction(commands);
        }



        public JsCall CreateCall(JsFormat format, string function, params object[] items)
        {
            JsCall c =  new JsCall(this, function, items);
            c.SetFormat(format);
            return c;
        }
        public JsCall CreateCall(string function, params object[] items)
        {
            return CreateCall(JsFormat.None, function, items);
        }
        public JsCall C(JsFormat format, string function, params object[] items)
        {
            return CreateCall(format, function, items);
        }
        public JsCall C(string function, params object[] items)
        {
            return CreateCall(function, items);
        }

        public JsList CreateList(JsFormat format, params object[] items)
        {
            JsList l = new JsList(this, items);
            l.SetFormat(format);
            return l;
        }
        public JsList CreateList(params object[] items)
        {
            return CreateList(JsFormat.None, items);
        }
        public JsList L(JsFormat format, params object[] items)
        {
            return CreateList(format, items);
        }
        public JsList L(params object[] items)
        {
            return CreateList(items);
        }


        public JsJoin CreateJoin(JsFormat format, params object[] items)
        {
            JsJoin j = new JsJoin(this, items);
            j.SetFormat(format);
            return j;
        }
        public JsJoin CreateJoin(params object[] items)
        {
            return CreateJoin(JsFormat.None, items);
        }
        public JsJoin J(JsFormat format, params object[] items)
        {
            return CreateJoin(format, items);
        }
        public JsJoin J(params object[] items)
        {
            return CreateJoin(items);
        }


		//public JsVariable CreateVariable(string name, string shortName)
		//{
		//    return new JsVariable(name, shortName);
		//}
		//public JsVariable V(string name, string shortName)
		//{
		//    return CreateVariable(name, shortName);
		//}




		public JsIf If(object test, object trueValue, object falseValue)
        {
			return new JsIf(this, test, trueValue, falseValue);
        }

		public JsIf If(object test, object trueValue)
		{
			return  If(test, trueValue, null);
		}


    }
}