using FPLDQ.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Service
{
    public class OrganizationFactory
    {
        private static OrganizationFactory  organizationFactory = new OrganizationFactory();

        public static OrganizationFactory CreateFactory()
        {
            return organizationFactory;
        }

        #region Organizaiton
        /// <summary>
        /// 组织操作服务
        /// </summary>
        /// <returns></returns>
        public IOrganization GetorganizationService()
        {
            return new OrganizationService();
        }

        /// <summary>
        /// 组织关系操作服务
        /// </summary>
        /// <returns></returns>
        public IOrganizationOrg GetOrganizationOrgService()
        {
            return new OrganizationOrgService();
        }

        /// <summary>
        /// 组织用户关系操作服务
        /// </summary>
        /// <returns></returns>
        public IOrganizationUser GetOrganizationUserService()
        {
            return new OrganizationUserService();
        }

        /// <summary>
        /// 角色操作服务
        /// </summary>
        /// <returns></returns>
        public IRole GetRoleService()
        {
            return new RoleService();
        }

        /// <summary>
        /// 用户操作服务
        /// </summary>
        /// <returns></returns>
        public IUser GetUserService()
        {
            return new UserService();
        }
        #endregion
    }
}
