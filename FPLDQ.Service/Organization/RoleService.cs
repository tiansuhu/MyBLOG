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
    class RoleService : baseService<Role>, IRole
    {
        SimpleClient<Role> roleClient = new SimpleClient<Role>(BaseDB.GetClient());
        public bool add(Role et)
        {
            return roleClient.Insert(et);
        }

        public bool delete(string id)
        {
            return roleClient.DeleteById(id);
        }

        public Role get(string id)
        {
            return roleClient.GetById(id);
        }

        public TableModel<Role> getPageList(int pageIndex, int pageSize)
        {
            PageModel page = new PageModel { PageSize = pageSize, PageIndex = pageIndex };
            Expression<Func<Role, bool>> ex = (it => 1 == 1);
            List<Role> roles = roleClient.GetPageList(ex, page);
            TableModel<Role> r = new TableModel<Role>();
            r.Code = 0;
            r.Count = page.PageCount;
            r.Data = roles;
            r.Msg = "成功";
            return r;
        }

        public bool update(Role et)
        {
            return roleClient.AsUpdateable(et).IgnoreColumns(ignoreAllNullColumns:true).ExecuteCommand()>0;
        }

    }
}
