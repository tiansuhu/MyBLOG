using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Entity
{
    /// <summary>
    /// 角色
    /// </summary>
    [SugarTable("h_role")]
    public class Role : baseEntity
    {
        /// <summary>
        /// 角色编码
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string roleCode{get;set;}

        /// <summary>
        /// 角色名称
        /// </summary>
        [SugarColumn(IsNullable =true)]
        public string roleName { get; set; }

    }
}
