using FPLDQ.Entity;
using FPLDQ.IService;
using FPLDQ.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Bussiness.Admin
{
    public class OrganizationUserManager
    {
        private IOrganizationUser orgUserService = OrganizationFactory.CreateFactory().GetOrganizationUserService();

        /// <summary>
        /// 添加组织用户关系
        /// </summary>
        /// <param name="organizationUser"></param>
        /// <returns></returns>
        public bool Add(OrganizationUser organizationUser)
        {
            return orgUserService.add(organizationUser);
        }
        /// <summary>
        /// 通过id获取组织用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrganizationUser Get(string id) {
            return orgUserService.get(id);
        }

        /// <summary>
        /// 初始化组织用户关系表
        /// </summary>
        public void InitTable()
        {
            orgUserService.initTable();
        }

    }
}
