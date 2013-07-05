using System;
using System.Data;
using System.Configuration;


namespace ClockWork.JavaScriptBuilder.JavaScript.ExtJs
{
    /// <summary>
    /// Summary description for ExtJsClass
    /// </summary>
    public class ExtJsClass : JsComponent
    {
        public ExtJsClass(ScriptDocument sd, string className, string baseClass)
			: base(sd)
        {
            ClassName = className;
            BaseClass = baseClass;
        }

		public string Namespace
		{
			get {
				int lastDot = ClassName.LastIndexOf(".");

				if (lastDot >= 0)
					return ClassName.Substring(0, lastDot);
				else
					return null;
			}
		}


        private string _ClassName;
        public string ClassName
        {
            get { return _ClassName; }
            set { _ClassName = value; }
        }

        private string _BaseClass;
        public string BaseClass
        {
            get { return _BaseClass; }
            set { _BaseClass = value; }
        }

        private JsObject _Apply ;
        public JsObject Apply
        {
            get { 
                if (_Apply==null)
					_Apply = Js.CreateObject();
                return _Apply; 
            }
            set { _Apply = value; }
        }

        private JsObject _ApplyIf;
        public JsObject ApplyIf
        {
            get {
                if (_ApplyIf == null)
					_ApplyIf = Js.CreateObject();
                return _ApplyIf; }
            set { _ApplyIf = value; }
        }

		protected ScriptItem BaseCall(string function, params object[] paremeters)
		{
			return Js.S(this.ClassName, ".superclass.", function, ".call(",Js.L("this",Js.L(paremeters)),");");
		}

		/// <summary>
		/// This is prefered as it is not parameter dependent. think its only good for Ext classes and maybe only component
		/// </summary>
		/// <param name="function"></param>
		/// <param name="paremeters"></param>
		/// <returns></returns>
		protected ScriptItem BaseApply(string function, params object[] paremeters)
		{
			return Js.S(this.ClassName, ".superclass.", function, ".apply(", Js.L("this", "arguments"), ");");
		}



        protected override void OnBuild()
        {
			ScriptLines constructor = Js.CreateScriptLines();

            Content.AddRange(
				Js.If(this.Namespace != null, Js.S("Ext.ns('", this.Namespace, "');")),
                Js.S(ClassName, " = ",
                    Js.F(
						Js.L("config"),
						Js.SL(
							"var config = config || {};",
							constructor,
							Js.If(this.Apply,
								Js.S(
									Js.C(
										"Ext.apply",
										"config",
										this.Apply
									),
									";"
								)
							),
							Js.If(this.ApplyIf,
								Js.S(
									Js.C(
										"Ext.applyIf",
										"config",
										this.ApplyIf
									),
									";"
								)
							),
							BaseCall("constructor", "config")
						//	Js.J(ClassName, ".superclass.constructor.call(this, config);")
							
						)
                    ),
                    ";"
                ),
                Js.S("Ext.extend(", ClassName, ",", BaseClass, ");"),
				Js.S(this.ClassName, ".create = function() {return new ", this.ClassName, "();};"),
				Js.S("Storm.registerClassConstructor('", this.ClassName, "', ", this.ClassName, ".create);")
            );
        }
        public override bool IsNothing()
        {
            return false;
        }

    }
}