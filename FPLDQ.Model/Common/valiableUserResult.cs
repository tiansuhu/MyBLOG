using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Model
{
    /// <summary>
    /// 验证用户结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class valiableUserResult<T>
    {
        /// <summary>
        /// 结果
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }
    }
}
