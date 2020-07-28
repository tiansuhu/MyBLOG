using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Entity
{
    /// <summary>
    /// 角色用户关系
    /// </summary>
    [SugarTable("h_role_user")]
    public class RoleUser:baseEntity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        [SugarColumn(IsNullable =false)]
        public string userid { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public string roleid { get; set; }
       
    }
}
