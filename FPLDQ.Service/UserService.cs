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
    public class UserService :BaseDB, IUser
    {
        public SimpleClient<User> userClent = new SimpleClient<User>(BaseDB.GetClient());
        public bool add(User et)
        {
            throw new NotImplementedException();
        }

        public bool delete(long id)
        {
            throw new NotImplementedException();
        }

        public User get(long id)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取用户分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public TableModel<User> getPageList(int pageIndex, int pageSize)
        {
            PageModel page = new PageModel { PageSize = pageSize, PageIndex = pageIndex };
            Expression<Func<User, bool>> ex = (it => 1 == 1);
            List<User> users = userClent.GetPageList(ex, page);
            TableModel<User> u = new TableModel<User>();
            u.Code = 0;
            u.Count = page.PageCount;
            u.Data = users;
            u.Msg = "成功";
            return u;
        }

        public bool update(User et)
        {

            throw new NotImplementedException();
        }
    }
}
