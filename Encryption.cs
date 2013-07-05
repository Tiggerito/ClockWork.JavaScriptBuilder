using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;

namespace ClockWork.JavaScriptBuilder
{
	public sealed class Encryption
	{
		/// <summary>
		/// Utility to read a secure string which is encrypted in memory
		/// For best security, only read a secure string when necesary, i.e. writing
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string ReadSecureString(SecureString text)
		{
			IntPtr bstr = Marshal.SecureStringToBSTR(text);
			string s = Marshal.PtrToStringBSTR(bstr);

			Marshal.ZeroFreeBSTR(bstr);

			return s;
		}

		/// <summary>
		/// Encryts a string in memory
		/// For best security, convert a string to a secure string as soon as possible
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static SecureString CreateSecureString(string text)
		{
			SecureString ss = new SecureString();

			foreach (char c in text.ToCharArray())
			{
				ss.AppendChar(c);
			}

			ss.MakeReadOnly();

			return ss;
		}
	}
}
