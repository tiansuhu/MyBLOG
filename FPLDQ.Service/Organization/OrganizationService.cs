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
    public class OrganizationService : baseService<Organization>, IOrganization
    {
        public SimpleClient<Organization> Client = new SimpleClient<Organization>(BaseDB.GetClient());
        public bool add(Organization et)
        {
            return Client.Insert(et);
        }

        public bool delete(string id)
        {
            return Client.DeleteById(id);
        }

        public Organization get(string id)
        {
            return Client.GetById(id);
        }

        public TableModel<Organization> getPageList(int pageIndex, int pageSize)
        {
            PageModel page = new PageModel { PageSize = pageSize, PageIndex = pageIndex };
            Expression<Func<Organization, bool>> ex = (it => 1 == 1);
            List<Organization> Organizations = Client.GetPageList(ex, page);
            TableModel<Organization> r = new TableModel<Organization>();
            r.Code = 0;
            r.Count = page.PageCount;
            r.Data = Organizations;
            r.Msg = "成功";
            return r;
        }

        public bool update(Organization et)
        {
            return Client.AsUpdateable(et).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand() > 0;
        }
    }
}
