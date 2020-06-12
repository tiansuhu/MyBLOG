using FPLDQ.Entity;
using FPLDQ.IService;
using FPLDQ.Model;
using FPLDQ.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Bussiness.Admin
{
    /// <summary>
    /// user 操作服务
    /// </summary>
    public class UserManager
    {
        private IUser userService = new UserService();

        /// <summary>
        /// 获取userid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserByID(string id) {
            return userService.get(id);
        }

        /// <summary>
        /// 增加user
        /// </summary>
        /// <param name="user">user对象</param>
        /// <returns></returns>
        public bool AddUser(User user) {
            return userService.add(user);
        }

        /// <summary>
        /// 更新user 
        /// </summary>
        /// <param name="user">user对象</param>
        /// <returns></returns>
        public bool UpdateUser(User user) {
            return userService.update(user);
        }
        /// <summary>
        /// 删除user
        /// </summary>
        /// <param name="id">userid</param>
        /// <returns></returns>
        public bool DeleteUser(string id) {
            return userService.delete(id);
        }
        /// <summary>
        /// 初始化表
        /// </summary>
        public void InitTable() {
             userService.initTable();
        }
        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="userCode">用户账号</param>
        /// <param name="userPassword">用户密码</param>
        /// <returns></returns>
        public valiableUserResult<User> valiableUser(string userCode,string userPassword) {
            return userService.valiableUser(userCode, userPassword);
        }

        /// <summary>
        /// 给用户派发令牌
        /// </summary>
        /// <param name="u"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public string  getuserToken(User u, TimeSpan timeSpan) {
            return userService.getUserToken(u, timeSpan);
        }

        /// <summary>
        /// 销毁用户令牌
        /// </summary>
        /// <param name="token">令牌token</param>
        /// <returns></returns>
        public bool unInitUserToken(string token) {
            return userService.unInitUserToken(token);
        }
    }
}
