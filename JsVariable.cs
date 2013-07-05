using System;
using System.Data;
using System.Configuration;


namespace ClockWork.JavaScriptBuilder
{
    /// <summary>
    /// Summary description for JsVariable
    /// </summary>
    public class JsVariable
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
        }

        private string _Namespace = null;
        public string Namespace
        {
            get { return _Namespace; }
        }

        private string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
        }



        private JsVariable()
        {
        }

        public JsVariable(string ns, string name, string shortName)
        {
            _Namespace = ns;
            _Name = name;
            _ShortName = shortName;
        }

        public JsVariable(string ns, string name)
            : this(ns, name, null)
        {
        }

        public JsVariable(string name)
            : this(null, name)
        {
        }





        protected string FullName(string ns, string name)
        {
            if (String.IsNullOrEmpty(ns))
                return name;
            else
                return ns + "." + name;
        }


        public override string ToString()
        {
            // TODO: support condensed variables
       //     if (Js.Condensed && !String.IsNullOrEmpty(ShortName))
      //          return FullName(Namespace, ShortName);
      //      else
                return FullName(Namespace, Name);
        }
    }
}