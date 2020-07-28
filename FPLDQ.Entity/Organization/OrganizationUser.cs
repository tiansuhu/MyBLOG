using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Entity
{
    /// <summary>
    /// 用户组织关系表
    /// </summary>
    [SugarTable("h_organization_user")]
    public class OrganizationUser:baseEntity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        [SugarColumn(ColumnName = "userid", IsNullable = false)]
        public string userid { get; set; }
        /// <summary>
        /// 组织id
        /// </summary>
        [SugarColumn(ColumnName = "orgid", IsNullable = false)]
        public string orgid { get; set; }
    }
}
