using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace J.Web.App_Code
{
    /// <summary>
    /// 用于返回给前台的json数据包
    /// </summary>
    public class ReturnObject
    {
        /// <summary>
        /// 返回的状态，1为执行成功，-1为执行出错
        /// </summary>
        public enum EReturnStatus
        {
            /// <summary>
            /// 执行成功
            /// </summary>
            success = 1,

            /// <summary>
            /// 执行出错
            /// </summary>
            error = -1
        }

        /// <summary>
        /// 执行状态
        /// </summary>
        public EReturnStatus status { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// 返回携带的值
        /// </summary>
        public Object data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}