using FPLDQ.Entity;
using FPLDQ.IService;
using FPLDQ.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Service
{

    /// <summary>
    /// 实现组织用户关系
    /// </summary>
    class OrganizationUserService : baseService<OrganizationUser>, IOrganizationUser
    {
        public SimpleClient<OrganizationUser> Client = new SimpleClient<OrganizationUser>(BaseDB.GetClient());
        /// <summary>
        /// 添加组织用户关系
        /// </summary>
        /// <param name="et"></param>
        /// <returns></returns>
        public bool add(OrganizationUser et)
        {
            return Client.Insert(et);
        }

        public bool delete(string id)
        {
            return Client.DeleteById(id);
        }

        public OrganizationUser get(string id)
        {
            return Client.GetById(id);
        }

        public TableModel<OrganizationUser> getPageList(int pageIndex, int pageSize)
        {
            //TODO:暂时不实现
            throw new NotImplementedException();
        }

        public bool update(OrganizationUser et)
        {
            return Client.AsUpdateable(et).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand() > 0;
        }
    }
}
