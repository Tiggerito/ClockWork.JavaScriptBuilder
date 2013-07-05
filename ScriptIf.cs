using System;
using System.Data;
using System.Configuration;

using System.IO;

namespace ClockWork.JavaScriptBuilder
{
    /// <summary>
    /// Summary description for JsProperty
    /// </summary>
    public class ScriptIf : ScriptItem
    {

		private object _Test;
		public object Test
		{
			get { return _Test; }
			set { _Test = value; }
		}
		private object _TrueValue;
		public object TrueValue
		{
			get { return _TrueValue; }
			set { _TrueValue = value; }
		}

		private object _FalseValue;
		public object FalseValue
		{
			get { return _FalseValue; }
			set { _FalseValue = value; }
		}

		/// <summary>
		/// If test is IScriptItem then it tests against it being not nothing
		/// </summary>
		/// <param name="js"></param>
		/// <param name="test"></param>
		/// <param name="trueValue"></param>
		/// <param name="falseValue"></param>
		public ScriptIf(ScriptDocument sd, object test, object trueValue, object falseValue)
            :base(sd)
        {
			Test = test;
			FalseValue = falseValue;
			TrueValue = trueValue;

			StartOnNewLine = false;
			MultiLine = false;
        }

		public bool TestResult
		{
			get
			{
				bool result = false;

				if (Test == null)
				{
					result = false;
				}
				else if (Test is IScriptItem)
				{
					result = !((IScriptItem)Test).IsEmpty();
				}
				else
				{
					try
					{
						result = Convert.ToBoolean(Test);
					}
					catch
					{
						result = false;
					}
				}
				return result;
			}
		}

		public object Winner
		{
			get
			{
				return this.TestResult ? TrueValue : FalseValue;
			}
		}


        protected override void OnRender(ScriptWriter writer, bool multiLine, bool startOnNewLine)
        {
			object winner = this.Winner;

			if (winner is IScriptItem)
			{
				if (!((IScriptItem)winner).IsNothing())
				{
					((IScriptItem)winner).Render(writer);
				}
			}
			else if (winner !=null)
			{
				writer.Write(winner);
			}

        }

        public override bool IsEmpty()
        {
			object winner = this.Winner;

			if (winner is IScriptItem)
			{
				return ((IScriptItem)winner).IsEmpty();

			}
			else if (winner == null)
			{
				return true;
			}
			return false;
        }

		public override bool IsNothing()
		{
			object winner = this.Winner;

			if (winner is IScriptItem)
			{
				return ((IScriptItem)winner).IsNothing();
			}
			else if (winner == null)
			{
				return true;
			}
			return false;
		}

    }
}