using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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

        public static string Object2JavaScriptJsonString(string fieldName, object obj)
        {
            return String.Format("var {0} = {1} ;", fieldName, JsonConvert.SerializeObject(obj, new JavaScriptDateTimeConverter()));
        }
	}
}
