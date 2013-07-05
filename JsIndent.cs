using System;
using System.Data;
using System.Configuration;


namespace ClockWork.JavaScriptBuilder
{
    /// <summary>
    /// Summary description for JsTabs
    /// this is not thread safe
    /// </summary>
    public class JsIndent : IDisposable
    {
        private static Int32 _IndentLevel;
        public static Int32 IndentLevel
        {
            get { return _IndentLevel; }
            set { _IndentLevel = value; }
        }

        private static string _IndentString = "\t";
        public static string IndentString
        {
            get { return _IndentString; }
            set { _IndentString = value; }
        }

        public static string Indent
        {
            get
            {
                if (Js.Condensed)
                    return String.Empty;

                // not very efficient

                string indent = String.Empty;

                for (int i = 0; i < IndentLevel; i++)
                    indent += IndentString;
                return indent;
            }
        }
        //   private static int count = 0;
        public static string Begin()
        {
            return Begin(1);
        }
        public static string Begin(int levels)
        {
            //    count++;
            IndentLevel += levels;
            //     return "%" + count +",+"+ IndentLevel + "%";
            return String.Empty;
        }
        public static string End()
        {
            return End(1);
        }
        public static string End(int levels)
        {
            if (IndentLevel >= levels)
                IndentLevel -= levels;
            else
                IndentLevel = 0;

            //      count++;

            //      return "%" + count +",-"+ IndentLevel + "%";

            return String.Empty;
        }

        public JsIndent()
        {
            IndentLevel++;
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            IndentLevel--;
        }

        #endregion
    }
}