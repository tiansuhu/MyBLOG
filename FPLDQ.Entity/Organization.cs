using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Entity
{
    /// <summary>
    /// 组织
    /// </summary>
    public class Organization:baseEntity
    {
        /// <summary>
        /// 组织代码
        /// </summary>
        public string orgCode { get; set; }
        /// <summary>
        /// 组织名称
        /// </summary>
        public string orgName { get; set; }
        /// <summary>
        /// 是否是根公司
        /// </summary>
        public bool isroot { get; set; }
    }
}
