using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Entity
{
    /// <summary>
    /// 用户
    /// </summary>
    [SugarTable("h_user")]
    public class User : baseEntity
    {
        /// <summary>
        /// 用户Code
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public string userCode{ get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public string userName { get; set; }
        /// <summary>
        /// 用户QQ
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string userQQ { get; set; }
        /// <summary>
        /// 用户微信
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string userWeChat { get; set; }
        /// <summary>
        /// 用户手机
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string userPhone { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string userEmail { get; set; }
        /// <summary>
        /// 用户所属国
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string userCountry { get; set; }
        /// <summary>
        /// 用户所属省
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string userProvice { get; set; }
        /// <summary>
        /// 用户所属市
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string userCity { get; set; }
        /// <summary>
        /// 用户地址
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string userAddress { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public bool isAdmin { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public bool isActivy { get; set; }
        /// <summary>
        /// 称谓
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string appellation { get; set;}
        /// <summary>
        /// 生日
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime birthday { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public string password { get; set; }


    }
}
