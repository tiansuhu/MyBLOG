using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Entity
{
    /// <summary>
    /// 用户组织关系表
    /// </summary>
    public class OrganizationUser:baseEntity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 组织id
        /// </summary>
        public string orgid { get; set; }
    }
}
