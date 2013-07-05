using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security;
using System.Runtime.InteropServices;

namespace ClockWork.JavaScriptBuilder
{

	/// <summary>
	/// A writer that add the following to the normal TextWriter
	/// Indentation Control - tracks and adds indentation while writing
	/// </summary>
	public class ScriptWriter
	{
		protected TextWriter Writer = null;

		/// <summary>
		/// Create a Script Writer that writes to a TextWriter
		/// </summary>
		/// <param name="writer"></param>
		public ScriptWriter(TextWriter writer)
		{
			if (writer == null)
				throw new Exception("ScriptWriter does not like null TextWriters");
			Writer = writer;
		}
		/// <summary>
		/// Create a Script Writer that writes to a Stream
		/// </summary>
		/// <param name="stream"></param>
		public ScriptWriter(Stream stream)
		{
			if (stream == null)
				throw new Exception("ScriptWriter does not like null Streams");

			Writer = new StreamWriter(stream);
		}

		/// <summary>
		/// Closes the underying writer/stream
		/// </summary>
		public void Close()
		{
			this.Writer.Close();
		}

		/// <summary>
		/// Flush the underying writer/stream
		/// </summary>
		public void Flush()
		{
			this.Writer.Flush();
		}
		

		public virtual void Write(object o)
		{
			Writer.Write(Convert(o));
		}

		public static object Convert(object o)
		{
			if (o is SecureString)
			{
				return Encryption.ReadSecureString((SecureString)o);
			}

			return o;
		}

		private Int32 _CurrentIndentLevel;
		/// <summary>
		/// Tracks how many indentations we are currently at
		/// Increased by BeginIndent()
		/// Reduced by EndIndent()
		/// </summary>
		public Int32 CurrentIndentLevel
		{
			get { return _CurrentIndentLevel; }
			set { _CurrentIndentLevel = value; }
		}

		private string _IndentText = "\t";
		/// <summary>
		/// The string to use for each indentation
		/// Repeated fore each IndentLevel
		/// Default: a tab
		/// </summary>
		public string IndentText
		{
			get { return _IndentText; }
			set { _IndentText = value; }
		}

		private bool _IncludeIndentation = true;
		/// <summary>
		/// If we should Include indents when writing
		/// If false then IndentString is always empty
		/// </summary>
		public bool IncludeIndentation
		{
			get { return _IncludeIndentation; }
			set { _IncludeIndentation = value; }
		}

		/// <summary>
		/// The current string to use for indentation
		/// Empty of IncludeIndents is false
		/// otherwise IndentationLevel * IndentText
		/// </summary>
		public virtual string IndentString
		{
			get
			{
				string indent = String.Empty;

				if (IncludeIndentation)
				{
					// not very efficient
					for (int i = 0; i < CurrentIndentLevel; i++)
						indent += IndentText;
				}

				return indent;
			}
		}

		/// <summary>
		/// What to use for a new line
		/// </summary>
		public virtual string NewLine
		{
			get
			{
				return Environment.NewLine;
			}
		}

		/// <summary>
		/// Start a new line and indent to the required position
		/// Prefered way to move to the next line
		/// </summary>
		public virtual void WriteNewLineAndIndent()
		{
			WriteNewLine();
			WriteIndent();
		}

		/// <summary>
		/// Starts a new line.
		/// Should generaly be folled by a WriteIndent() so following text is in the correct position
		/// WriteNewLineAndIndent() may be preferable.
		/// </summary>
		public virtual void WriteNewLine()
		{
			this.Write(this.NewLine);
		}

		/// <summary>
		/// Adds the indent string
		/// Should always be after a newline to make sense 
		/// WriteNewLineAndIndent() may be preferable.
		/// </summary>
		public virtual void WriteIndent()
		{
			this.Write(this.IndentString);
		}


		/// <summary>
		/// Increase the indentation level by one
		/// BeginIndent() and EndIndent() should be used in pairs
		/// Preferably using a try finally pattern so as to avoid messed up formatting on errors
		/// </summary>
		public void BeginIndent()
		{
			BeginIndent(1);
		}
		/// <summary>
		/// Increase the indentation level by the supplied amount
		/// BeginIndent() and EndIndent() should be used in pairs
		/// Preferably using a try finally pattern so as to avoid messed up formatting on errors
		/// </summary>
		/// <param name="levels">How many indentations to add</param>
		public void BeginIndent(int levels)
		{
			CurrentIndentLevel += levels;
		}

		/// <summary>
		/// Decrease the indentation level by one
		/// BeginIndent() and EndIndent() should be used in pairs
		/// Preferably using a try finally pattern so as to avoid messed up formatting on errors
		/// </summary>
		public void EndIndent()
		{
			EndIndent(1);
		}

		/// <summary>
		/// Decrease the indentation level by the supplied amount
		/// BeginIndent() and EndIndent() should be used in pairs
		/// Preferably using a try finally pattern so as to avoid messed up formatting on errors
		/// </summary>
		/// <param name="levels">How many indentations to remove</param>
		public void EndIndent(int levels)
		{
			if (CurrentIndentLevel >= levels)
				CurrentIndentLevel -= levels;
			else
				CurrentIndentLevel = 0;
		}
	}
}

