using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.Util
{
	public static class BasicTools
	{
		public static string NewGuid()
		{
			return Guid.NewGuid().ToString("N").ToLower();
		}
	}
}
