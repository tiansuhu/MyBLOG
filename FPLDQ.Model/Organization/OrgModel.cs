using FPLDQ.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Model
{
    /// <summary>
    /// 组织实体类
    /// </summary>
   public class OrgModel
    {
        /// <summary>
        /// 组织信息
        /// </summary>
        public Organization organization { get;set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public string parentOrgId { get; set; }

    }
}
