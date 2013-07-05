using System;
using System.Data;
using System.Configuration;

namespace ClockWork.JavaScriptBuilder
{
    /// <summary>
    /// Summary description for JsVariableFactory
    /// </summary>
    public class JsVariableFactory
    {
        public JsVariableFactory()
        {
        }

        public JsVariableFactory(int index)
        {
            _Index = index;
        }

        public JsVariable Variable(string name)
        {
            return Variable(null, name);
        }
        public JsVariable Variable(string ns, string name)
        {
            return new JsVariable(ns, name, this.GetNextShortName());
        }

        private int _Index = 0;

        public int Index
        {
            get { return _Index; }
        }


        private string GetNextShortName()
        {
            lock (this)
            {
                string s = Thing(_Index);
                _Index++;

                return s;
            }
        }

        private const string _LetterSet = "abcdefghijklmnopqrstuvwxyz";

        private string Thing(int v)
        {
            if (v >= _LetterSet.Length)
            {
                int bv = (int)(v / _LetterSet.Length); // rounds down?

                return Thing(bv - 1) + _LetterSet[v - (bv * _LetterSet.Length)];
            }
            else
                return _LetterSet[v].ToString();
        }
    }
}
