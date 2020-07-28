using FPLDQ.Entity;
using FPLDQ.IService;
using FPLDQ.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Service
{
     class OrganizationOrgService : baseService<OrganizationOrg>, IOrganizationOrg
    {
        public SimpleClient<OrganizationOrg> Client = new SimpleClient<OrganizationOrg>(BaseDB.GetClient());

        /// <summary>
        /// 增加组织关系表
        /// </summary>
        /// <param name="et"></param>
        /// <returns></returns>
        public bool add(OrganizationOrg organizationOrg)
        {
            return Client.Insert(organizationOrg);
        }
        /// <summary>
        /// 删除组织关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool delete(string id)
        {
            return Client.DeleteById(id);
        }
        /// <summary>
        /// 获取组织关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrganizationOrg get(string id)
        {
            return Client.GetById(id);
        }

        /// <summary>
        /// 分页获取组织关系
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public TableModel<OrganizationOrg> getPageList(int pageIndex, int pageSize)
        {
            //TODO:暂时不需要实现
            throw new NotImplementedException();
        }
        /// <summary>
        /// 更新组织关系
        /// </summary>
        /// <param name="et"></param>
        /// <returns></returns>
        public bool update(OrganizationOrg et)
        {
            //值为null的属性不更新
           return Client.AsUpdateable(et).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand() > 0;
        }
    }
}
