using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MySimpleServiceClient
{
	/// <summary>
	/// 用于调试时的一些工具方法
	/// </summary>
	public static class DebugUtils
	{
		/// <summary>
		/// 显示当前方法为止的调用线程调用堆栈。
		/// </summary>
		/// <returns></returns>
		public static List<string> GetStackTrace()
		{
			return GetStackTrace(1);
		}

		/// <summary>
		/// 显示当前线程的调用堆栈，并跳过一些靠前的堆栈。
		/// </summary>
		/// <param name="skip"></param>
		/// <returns></returns>
		public static List<string> GetStackTrace(int skip)
		{
			if( skip < 0 )
				throw new ArgumentOutOfRangeException("skip");

			StackTrace stack = new StackTrace();
			string[] frames = stack.ToString().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			return frames.Skip(skip + 1).ToList();
		}
	}
}
