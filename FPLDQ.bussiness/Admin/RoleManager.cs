using FPLDQ.Entity;
using FPLDQ.IService;
using FPLDQ.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Bussiness.Admin
{

    public class RoleManager
    {
        private IRole roleService = OrganizationFactory.CreateFactory().GetRoleService();

        /// <summary>
        /// 通过id获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetRoleByID(string id)
        {
            return roleService.get(id);
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool AddRole(Role r) {
            return roleService.add(r);
        }
        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool UpdateRole(Role r) {
            return roleService.update(r);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteRole(string id) {
            return roleService.delete(id);
        }
    }
}
