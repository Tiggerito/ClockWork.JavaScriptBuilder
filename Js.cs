using System;
using System.Data;
using System.Configuration;

using System.Collections.Generic;

namespace ClockWork.JavaScriptBuilder
{
    /// <summary>
    /// Summary description for JsHelper
    /// </summary>
    public class Js
    {
        public Js()
        {
        }
#if DEBUG
        private static bool _Condensed = false;
#else
    private static bool _Condensed = true;
#endif

        public static bool Condensed
        {
            get { return _Condensed; }
            set { _Condensed = value; }
        }

        public static string BeginIndent()
        {
            return JsIndent.Begin();
        }
        public static string EndIndent()
        {
            return JsIndent.End();
        }
        public static string Indent
        {
            get
            {
                return JsIndent.Indent;
            }
        }

        public static string NewLine
        {
            get
            {
                if (Js.Condensed)
                    return String.Empty;
                else
                    return Environment.NewLine;
            }
        }

        public static string QS(string text)
        {
            return QuoteSingle(text);
        }

        public static string QuoteSingle(string text)
        {
            if (text == null)
                return "''";

            return @"'" + text.ToString().Replace(@"'", @"\'") + @"'";
        }

        public static string QD(string text)
        {
            return QuoteDouble(text);
        }
        public static string QuoteDouble(string text)
        {
            if (text == null)
                return "\"\"";

            return @"""" + text.ToString().Replace(@"""", @"\""") + @"""";
        }

        public static JsCall New(string className, params object[] items)
        {
            JsCall c = new JsCall(className, items);
            c.New = true;
            return c;
        }
        public static JsCall N(string className, params object[] items)
        {
            return New(className, items);
        }

        public static JsCall NewInline(string className, params object[] items)
        {
            JsCall c = new JsCall(className, items);
            c.New = true;
            c.MultiLine = false;
            return c;
        }
        public static JsCall NI(string className, params object[] items)
        {
            return NewInline(className, items);
        }

        public static JsObject Object(params object[] properties)
        {
            return new JsObject(properties);
        }

        public static JsObject O(params object[] properties)
        {
            return Object(properties);
        }

        public static JsObject ObjectInline(params JsProperty[] properties)
        {
            JsObject o = new JsObject(properties);
            o.MultiLine = false;
            return o;
        }

        public static JsObject OI(params JsProperty[] properties)
        {
            return ObjectInline(properties);
        }

        public static JsProperty Property(string name, object value)
        {
            return new JsProperty(name, value);
        }
        public static JsProperty P(string name, object value)
        {
            return Property(name, value);
        }

        public static JsProperty PropertyInline(string name, object value)
        {
            JsProperty p = new JsProperty(name, value);
            p.MultiLine = false;
            return p;
        }
        public static JsProperty PI(string name, object value)
        {
            return PropertyInline(name, value);
        }

        public static JsArray Array(params object[] list)
        {
            return new JsArray(list);
        }

        public static JsArray A(params object[] list)
        {
            return Array(list);
        }

        public static JsMultiLine MultiLine(params object[] lines)
        {
            return new JsMultiLine(lines);
        }

        public static JsMultiLine ML(params object[] lines)
        {
            return MultiLine(lines);
        }
        //public static JsMultiLine MultiLineIndented(params object[] lines)
        //{
        //    JsMultiLine ml = new JsMultiLine(lines);
        //    ml.NewIndent = true;
        //    ml.StartOnNewLine = true;
        //    return ml;
        //}

        //public static JsMultiLine MLI(params object[] lines)
        //{
        //    return MultiLineIndented(lines);
        //}

        //public static JsFunction Function(string parameters, JsMultiLine commands)
        //{
        //    return new JsFunction(parameters, commands);
        //}
        //public static JsFunction F(string parameters, JsMultiLine commands)
        //{
        //    return Function(parameters, commands);
        //}
        public static JsFunction Function(JsList parameters, JsMultiLine commands)
        {
            return new JsFunction(parameters, commands);
        }
        public static JsFunction F(JsList parameters, JsMultiLine commands)
        {
            return Function(parameters, commands);
        }

        public static JsFunction Function(JsMultiLine commands)
        {
            return new JsFunction(commands);
        }
        public static JsFunction F(JsMultiLine commands)
        {
            return Function(commands);
        }

        public static JsFunction FunctionInline(JsList parameters, JsMultiLine commands)
        {
            JsFunction f = new JsFunction(parameters, commands);
            f.MultiLine = false;
            return f;
        }
        public static JsFunction FI(JsList parameters, JsMultiLine commands)
        {
            return FunctionInline(parameters, commands);
        }

        public static JsCall Call(string function, params object[] items)
        {
            return new JsCall(function, items);
        }
        public static JsCall C(string function, params object[] items)
        {
            return Call(function, items);
        }

        public static JsList List(params object[] items)
        {
            return new JsList(items);
        }
        public static JsList L(params object[] items)
        {
            return List(items);
        }

        public static JsList ListInline(params object[] items)
        {
            JsList l = new JsList(items);
            l.MultiLine = false;
            return l;
        }
        public static JsList LI(params object[] items)
        {
            return List(items);
        }

        public static JsJoin Join(params object[] items)
        {
            return new JsJoin(items);
        }
        public static JsJoin J(params object[] items)
        {
            return new JsJoin(items);
        }

        public static JsVariable Variable(string name, string shortName)
        {
            return new JsVariable(name, shortName);
        }
        public static JsVariable V(string name, string shortName)
        {
            return Variable(name, shortName);
        }
        public static object If(bool test, object ifTrue)
        {
            return If(test, ifTrue, null);
        }
        public static object If(bool test, object ifTrue, object ifFalse)
        {
            return test ? ifTrue : ifFalse;
        }

        public static string ToJavaScript(object o)
        {
            if (o == null)
                return null;

            if (o is bool)
                return o.ToString().ToLower();

            return o.ToString();
        }

    }
}
