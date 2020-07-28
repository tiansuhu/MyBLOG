using FPLDQ.Entity;
using FPLDQ.IService;
using FPLDQ.Model;
using FPLDQ.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Bussiness.Admin
{

   public  class OrganizationManager
    {
        private IOrganization orgService = OrganizationFactory.CreateFactory().GetorganizationService();

        /// <summary>
        /// 添加组织
        /// </summary>
        /// <param name="org"></param>
        /// <returns></returns>
        public bool Add(Organization org)
        {
            return orgService.add(org);
        }
        /// <summary>
        /// 添加组织和组织关系
        /// </summary>
        /// <param name="orgModel"></param>
        /// <returns></returns>
        public bool Add(OrgModel orgModel) {
            return orgService.add(orgModel);
        }

        /// <summary>
        /// 更新组织和组织关系
        /// </summary>
        /// <param name="orgModel"></param>
        /// <returns></returns>
        public bool Update(OrgModel orgModel) {
            return orgService.update(orgModel);
        }
         
        /// <summary>
        /// 通过id获取组织
        /// </summary>
        /// <param name="id">组织id</param>
        /// <returns></returns>
        public Organization Get(string id) {
            return orgService.get(id);
        }
        /// <summary>
        /// 获取组织的下级组织
        /// </summary>
        /// <param name="parentid">父级组织id</param>
        /// <returns></returns>
        public List<OrgModel> GetChilds(string parentid) {
            return orgService.GetOrgModels(parentid);
        }

        /// <summary>
        /// 初始化表
        /// </summary>
        public void InitTable()
        {
            orgService.initTable();
        }
    }
}
