using FPLDQ.Entity;
using FPLDQ.IService;
using FPLDQ.Model;
using FPLDQ.Token;
using FPLDQ.Token.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FPLDQ.Service
{
    public class UserService : baseService<User>, IUser
    {
        public SimpleClient<User> userClent = new SimpleClient<User>(BaseDB.GetClient());
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="et"></param>
        /// <returns></returns>
        public bool add(User et)
        {
            //添加用户的时候对用户密码进行加密操作。
            string userpassword = string.Empty;
            string md5str = Common.SecurityHelper.MD5("000000", Encoding.UTF8);
            userpassword = Common.SecurityHelper.Base64Encode(md5str);
            et.isActivy = true;//添加用户默认是激活状态
            et.password = userpassword;
            return userClent.Insert(et);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool delete(string id)
        {
            return userClent.DeleteById(id);
        }

        /// <summary>
        /// 通过id 获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User get(string id)
        {
            return userClent.GetById(id);
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
        /// <summary>
        /// 通过userCode 获取用户信息
        /// </summary>
        /// <param name="userCode">userCode</param>
        /// <returns></returns>
        public User getUserByCode(string userCode)
        {
            return userClent.AsQueryable().Where(item => item.userCode == userCode).First();
        }

        /// <summary>
        /// 通过usercode 获取用户信息
        /// </summary>
        /// <param name="userCode">userCode</param>
        /// <param name="isActivity">是否激活</param>
        /// <returns></returns>
        public User getUserByCode(string userCode, bool isActivity)
        {
            return userClent.AsQueryable().Where(item => item.userCode == userCode && item.isActivy == isActivity).First();
        }

        /// <summary>
        /// 给用户派发令牌 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public string getUserToken(User u, TimeSpan _timeSpan)
        {
            TokenModel m = new TokenModel();
            m.Uid = u.id;
            m.Uname = u.userCode;
            if (u.isAdmin)
            {
                m.Sub = "Admin";
            }

            else
            {
                m.Sub = "Client";
            }

            TimeSpan timeSpan = _timeSpan;
            string token = BLOGPIToken.IssueJWT(m, timeSpan, timeSpan);
            return token;

        }

        /// <summary>
        /// 销毁用户令牌
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool unInitUserToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException(nameof(token));
            }

            if (BLOGPIMemoryCache.Exists(token))
            {
                return BLOGPIMemoryCache.DeleteMemoryCache(token);
            }
            else
            {
                return true;
            }

        }



        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="et">用户实体</param>
        /// <returns></returns>
        public bool update(User et)
        {
            //不更新为null的列
            return userClent.AsUpdateable(et).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand() > 0;
        }

        public valiableUserResult<User> valiableUser(string userCode, string userPassword)
        {

            valiableUserResult<User> result = new valiableUserResult<User>();
            if (string.IsNullOrEmpty(userCode))
            {
                result.success = false;
                result.Msg = "用户账号为空";
                result.Data = null;
                return result;
            }
            if (string.IsNullOrEmpty(userPassword))
            {
                result.success = false;
                result.Msg = "用户密码为空";
                result.Data = null;
                return result;
            }

            User user = this.getUserByCode(userCode);
            if (user == null || string.IsNullOrEmpty(user.userCode))
            {
                result.success = false;
                result.Msg = "用户不存在";
                result.Data = null;

                return result;
            }
            if (string.IsNullOrEmpty(user.password))
            {
                result.success = false;
                result.Msg = "密码为空";
                result.Data = null;
                return result;
            }

            string md5str = Common.SecurityHelper.MD5(userPassword, Encoding.UTF8);
            string password = Common.SecurityHelper.Base64Encode(md5str);

            if (password != user.password)
            {
                result.success = false;
                result.Msg = "用户账号密码不正确";
                result.Data = user;
                return result;
            }

            result.success = true;
            result.Msg = "成功";
            result.Data = user;
            return result;

        }
    }
}
