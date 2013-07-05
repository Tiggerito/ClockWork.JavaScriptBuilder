using System;
using System.Data;
using System.Configuration;

using System.Collections.Generic;
using System.Text;

namespace ClockWork.JavaScriptBuilder.JavaScript
{
    /// <summary>
    /// Summary description for JsObject
    /// </summary>
    public class JsObject : JsList 
    {
        public JsObject(ScriptDocument sd) : base(sd) { }
        public JsObject(ScriptDocument sd, IEnumerable<object> lines) : base(sd, lines) { }
        public JsObject(ScriptDocument sd, params object[] lines) : base(sd, lines) { }

        protected override void OnInitialise()
        {
            base.OnInitialise();

            this.MultiLine = true;
            this.StartOnNewLine = true;

            this.SetWrapper("{", "}");
        }

		public JsProperty FindProperty(string name)
		{
			foreach (object o in this)
			{
				if (o is JsProperty)
				{
					if (((JsProperty)o).Name == name)
						return (JsProperty)o;
				}
				if (o is JsObject)
				{
					return ((JsObject)o).FindProperty(name);
				}
			}
			return null;
		}

		public object FindPropertyValue(string name)
		{
			JsProperty p = FindProperty(name);
			if (p != null)
				return p.Value;
			return null;
		}

		/// <summary>
		/// flatten out object in objects so they become one
		/// so we can combine objects/properties into resulting object 
		/// </summary>
		/// <returns></returns>
		protected override IEnumerable<object> GetRenderList()
		{
			List<object> toRender = new List<object>();

			AddToRenderList(toRender, this);

			return toRender;
		}

		private void AddToRenderList(List<object> dest, object o)
		{
			if (o is JsObject)
			{
				foreach (object p in (JsObject)o)
				{
					AddToRenderList(dest, p);
				}
			}
			else
				dest.Add(o);
		}

		//public static JsObject Join(ScriptDocument sd, params object[] objectsOrProperties)
		//{
		//    JsObject o = js.CreateObject();

		//    foreach (object po in objectsOrProperties)
		//    {
		//        if (po is JsProperty)
		//        {
		//            o.Add(po);
		//        }
		//        else if (po is JsObject)
		//        {
		//            foreach (object opo in (JsObject)po)
		//            {
		//                o.Add(opo);
		//            }
		//        }
		//    }
		//    return o;

		//}

        //public JsObject(IEnumerable<JsProperty> properties)
        //    : base(properties)
        //{

        //}

        //public JsObject(params JsProperty[] properties)
        //    : base(properties)
        //{
        //}

        public void Add(string name, object value)
        {
            this.Add(Js.CreateProperty(name, value));
        }

        //public override string GetJavaScript(bool multiLine, bool startOnNewLine)
        //{
        //    return
        //        this.StartString(multiLine && this.Count != 0, startOnNewLine) +
        //        "{" + JsIndent.Begin() + base.GetJavaScript(multiLine, true) + JsIndent.End() + this.LineSeperator(multiLine && this.Count != 0) + "}";

        //}

        //public override string GetJavaScript(bool multiLine, bool startOnNewLine)
        //{

        //    JsList properties = new JsList();

        //    foreach (JsProperty property in this)
        //    {
        //        if (property!=null)
        //            properties.Add(property);
        //    }

        //    properties.MultiLine = this.MultiLine;
        //    properties.StartOnNewLine = true;

        //    return
        //        this.StartString(multiLine && properties.Count != 0, startOnNewLine) +
        //        "{" + properties.ToJavaScript(1) + this.LineSeperator(multiLine && properties.Count != 0) + "}";
        //}
    }
}