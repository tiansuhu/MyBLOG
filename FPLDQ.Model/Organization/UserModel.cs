using FPLDQ.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Model
{
    /// <summary>
    /// 用户对象
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public User user { get; set; }
        /// <summary>
        /// 用户关系
        /// </summary>
        public OrganizationUser organizationUser { get; set; }

        /// <summary>
        /// 验证当前用户
        /// </summary>
        /// <returns></returns>
        public bool ValiableUser()
        {
            if (this.user == null)
                return false;

            if (string.IsNullOrEmpty(this.user.userCode))
                return false;

            if (string.IsNullOrEmpty(this.user.userName))
                return false;
            if (string.IsNullOrEmpty(this.user.password))
                return false;

            return true;
        }
        /// <summary>
        /// 验证当前用户组织关系表是否为空
        /// </summary>
        /// <returns></returns>
        public bool ValiableOrganizationUser()
        {
            if (this.organizationUser == null)
                return false;

            if (string.IsNullOrEmpty(this.organizationUser.userid))
                return false;

            if (string.IsNullOrEmpty(this.organizationUser.orgid))
                return false;

            return true;
        }

    }
}
