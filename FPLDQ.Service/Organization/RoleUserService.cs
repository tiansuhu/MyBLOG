using FPLDQ.Entity;
using FPLDQ.IService;
using FPLDQ.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FPLDQ.Service
{
    class RoleUserService : baseService<RoleUser>, IRoleUser
    {
        public SimpleClient<RoleUser> Client = new SimpleClient<RoleUser>(BaseDB.GetClient());
        /// <summary>
        /// 增加角色和用户关系
        /// </summary>
        /// <param name="et"></param>
        /// <returns></returns>
        public bool add(RoleUser et)
        {
            return Client.Insert(et);
        }
        /// <summary>
        /// 删除角色和用户关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool delete(string id)
        {
            return Client.DeleteById(id); 
        }
        /// <summary>
        /// 获取角色和用户关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoleUser get(string id)
        {
            return Client.GetById(id);
        }
        /// <summary>
        /// 批量获取角色和用户关系
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public TableModel<RoleUser> getPageList(int pageIndex, int pageSize)
        {
            PageModel page = new PageModel { PageSize = pageSize, PageIndex = pageIndex };
            Expression<Func<RoleUser, bool>> ex = (it => 1 == 1);
            List<RoleUser> roles = Client.GetPageList(ex, page);
            TableModel<RoleUser> r = new TableModel<RoleUser>();
            r.Code = 0;
            r.Count = page.PageCount;
            r.Data = roles;
            r.Msg = "成功";
            return r;
        }
        /// <summary>
        /// 更新角色和用户关系
        /// </summary>
        /// <param name="et"></param>
        /// <returns></returns>
        public bool update(RoleUser et)
        {
            return Client.AsUpdateable(et).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand() > 0;
        }
    }
}
