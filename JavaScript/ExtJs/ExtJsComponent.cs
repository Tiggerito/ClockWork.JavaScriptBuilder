using System;
using System.Data;
using System.Configuration;
using System.Web;


namespace ClockWork.JavaScriptBuilder.JavaScript.ExtJs
{
    /// <summary>
    /// Summary description for ExtJsComponent
    /// </summary>
    public class ExtJsComponent : ExtJsClass
    {

        public ExtJsComponent(ScriptDocument sd, string className, string baseClass, string id)
            : base(sd, className, baseClass)
        {
        }

		private string _Id;

		public string Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

        private JsObject _Object;
        public JsObject Object
        {
            get
            {
                if (_Object == null)
                    _Object = Js.CreateObject(); 
                return _Object;
            }
            set { _Object = value; }
        }

        private ScriptLines _InitComponentsStart;
		/// <summary>
		/// Before apply calls and base call
		/// </summary>
		public ScriptLines InitComponentsStart
        {
            get {
				if (_InitComponentsStart == null)
					_InitComponentsStart = Js.CreateScriptLines();
				return _InitComponentsStart; 
            }
			set { _InitComponentsStart = value; }
        }

		private ScriptLines _InitComponentsEnd;
		/// <summary>
		/// After apply calls and base call
		/// </summary>
		public ScriptLines InitComponentsEnd
		{
			get
			{
				if (_InitComponentsEnd == null)
					_InitComponentsEnd = Js.CreateScriptLines();
				return _InitComponentsEnd;
			}
			set { _InitComponentsStart = value; }
		}

        private string _RegistryName = null;
        public string RegistryName
        {
            get { return _RegistryName; }
            set { _RegistryName = value; }
        }


        protected override void OnBuild()
        {
            JsProperty initComponents = 
				Js.P("initComponent", 
					Js.F(
						Js.SL(

							InitComponentsStart,
							Js.If(this.Apply,
								Js.S(
									Js.C(
										"Ext.apply",
										"this",
										this.Apply
									),
									";"
								)
							),
							Js.If(this.ApplyIf,
								Js.S(
									Js.C(
										"Ext.applyIf",
										"this",
										Js.O(this.ApplyIf, Js.P("id",this.Id))
									),
									";"
								)
							),
							BaseApply("initComponent"),
							InitComponentsEnd
						//	this.ClassName + ".superclass.initComponent.call(this);"//,
						//	this.ClassName + ".superclass.initComponent.apply(this, arguments);"
						
						)
					)
				);

            Content.AddRange(
				Js.If(this.Namespace!=null, Js.S("Ext.ns('" , this.Namespace, "');")),
                Js.S(ClassName, " = ",
                    Js.C("Ext.extend",
                        Js.L(
                            BaseClass,
							Js.O(Object,initComponents)
                        )
                    ),
                    ";"
                ),
				Js.S(this.ClassName, ".create = function() {return new ", this.ClassName, "();};"),
				Js.S("Storm.registerClassConstructor('", this.ClassName, "', ", this.ClassName, ".create);")
            );

            if (!String.IsNullOrEmpty(this.RegistryName))
            {
                Content.Add("Ext.reg('" + this.RegistryName + "', " + this.ClassName + ");");
            }

        }
		//protected override void OnRender(ScriptWriter writer, bool multiLine, bool startOnNewLine)
		//{
		//    this.EnsureBuilt();

			

		//    base.OnRender(writer, multiLine, startOnNewLine);
		//}
    }
}