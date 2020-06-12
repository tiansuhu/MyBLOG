using FPLDQ.Entity;
using FPLDQ.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.IService
{
    public interface IUser:IbaseService<User>
    {
        /// <summary>
        /// 通过userCode 获取user对象
        /// </summary>
        /// <param name="userCode">用户账号</param>
        /// <returns></returns>
        public User getUserByCode(string userCode);
        /// <summary>
        /// 通过userCode 获取user对象
        /// </summary>
        /// <param name="userCode">用户账号</param>
        /// <param name="isActivity">是否是激活的用户</param>
        /// <returns></returns>
        public User getUserByCode(string userCode, bool isActivity);

        /// <summary>
        /// 通过用户账号和密码验证用户是否合法
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public valiableUserResult<User> valiableUser(string userCode, string userPassword);

        /// <summary>
        /// 获取用户的令牌
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public string getUserToken(User u,TimeSpan timeSpan);

        /// <summary>
        /// 销毁用户令牌
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool unInitUserToken(string token);

    }
}
