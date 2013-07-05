using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using ClockWork.JavaScriptBuilder.JavaScript;

namespace ClockWork.JavaScriptBuilder
{

    /// <summary>
	/// A ScriptItem that consists of a set/list/collection of things
    /// </summary>
	public  class ScriptSet : ScriptItem, IEnumerable<object>, IList<object>, ICollection<object>
    {

        protected List<object> _Items;

		#region Constructors
		public ScriptSet(ScriptDocument sd)
            : base(sd)
        {
			this._Items = new List<object>();
        }

		public ScriptSet(ScriptDocument sd, IEnumerable<object> items)
            : this(sd)
        {
			this._Items.AddRange(items);
        }

		public ScriptSet(ScriptDocument sd, params object[] items)
            : this(sd)
        {
			this._Items.AddRange(items);
		}

		#endregion

		#region Parameterised Adding
		public void InsertRange(params object[] lines)
        {
            this._Items.InsertRange(0, lines);
        }

		public void AddRange(params object[] lines)
        {
            this._Items.AddRange(lines);
		}

		#endregion

		#region IScriptItem 
		public override bool IsEmpty()
		{
			foreach (object o in this)
			{
				if (o != null)
				{
					if (o is IScriptItem)
					{
						if (!((IScriptItem)o).IsNothing())
							return false;
					}
					else
						return false;
				}
			}
			return true;
		}
		#endregion

		#region Registration Support
		private Dictionary<string, object> _Registry = null;

		/// <summary>
		/// Only add it if its not already been registered
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool RegisterItem(string name, object item)
		{
			if (_Registry == null)
				_Registry = new Dictionary<string, object>();
			else
			{
				if (_Registry.ContainsKey(name))
					return false;
			}

			_Registry.Add(name, item);

			this.Add(item);

			return true;

		}

		#endregion

		#region Rendering
		private string _Seperator = String.Empty;
		public virtual string Seperator
		{
			get { return _Seperator; }
			set { _Seperator = value; }
		}



		private string _Before = null;
		public string Before
		{
			get { return _Before; }
		}

		private string _After = null;
		public string After
		{
			get { return _After; }
		}

		public void SetWrapper(string before, string after)
		{
			_Before = before;
			_After = after;
		}

		protected virtual IEnumerable<object> GetRenderList()
		{
			return this;
		}

		protected virtual void WriteSeperator(ScriptWriter writer)
		{
			writer.Write(this.Seperator);
		}

		protected override void OnRender(ScriptWriter writer, bool multiLine, bool startOnNewLine)
		{
			string start = String.Empty;
			string end = String.Empty;

			if (Before != null)
			{
				if (startOnNewLine && multiLine && this.Count != 0)
					writer.WriteNewLineAndIndent();

				writer.Write(Before);
				writer.BeginIndent();
			}

			if (startOnNewLine && multiLine && !this.IsNothing())
				writer.WriteNewLineAndIndent();


			bool first = true;

			foreach (object line in GetRenderList())
			{
				if (line != null)
				{
					if (line is IScriptItem)
					{
						if (!((IScriptItem)line).IsNothing())
						{
							if (first)
								first = false;
							else
							{
								WriteSeperator(writer);

								if (multiLine)
									writer.WriteNewLineAndIndent();


							}

							((IScriptItem)line).Render(writer);
						}
					}
					else
					{
						if (first)
							first = false;
						else
						{
							WriteSeperator(writer);

							if (multiLine)
								writer.WriteNewLineAndIndent();
						}

						writer.Write(line);
					}
				}
			}

			if (Before != null)
			{
				writer.EndIndent();

				if (multiLine && this.Count != 0)
					writer.WriteNewLineAndIndent();

				writer.Write(After);
			}

		}

		public override bool IsNothing()
		{
			if (Before != null)
				return false;

			return IsEmpty();
		}

		#endregion

		#region IEnumerable<object> Members

		public IEnumerator<object> GetEnumerator()
        {
            return this._Items.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this._Items).GetEnumerator();
        }

        #endregion

		#region IList<object> Members

		public int IndexOf(object item)
        {
            return this._Items.IndexOf(item);
        }

		public void Insert(int index, object item)
        {
            this._Items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this._Items.RemoveAt(index);
        }

		public object this[int index]
        {
            get
            {
                return this._Items[index];
            }
            set
            {
                this._Items[index] = value;
            }
        }

        #endregion

		#region ICollection<object> Members


		public void Clear()
        {
            this._Items.Clear();
        }

		public bool Contains(object item)
        {
            return this._Items.Contains(item);
        }

		public void CopyTo(object[] array, int arrayIndex)
        {
            this._Items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this._Items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

		public bool Remove(object item)
        {
            return this._Items.Remove(item);
        }


		public void Add(object item)
        {
            this._Items.Add(item);
        }

        #endregion
    }
}
