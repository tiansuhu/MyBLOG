using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Entity
{
    /// <summary>
    /// 组织关系表
    /// </summary>
    [SugarTable("h_organization_org")]
    public  class OrganizationOrg:baseEntity
    {
        /// <summary>
        /// 组织id
        /// </summary>
        public string orgid { get; set; }
        /// <summary>
        /// 上级组织id
        /// </summary>
        public string parentorgid { get; set; }
    }
}
