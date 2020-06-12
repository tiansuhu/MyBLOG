using FPLDQ.Bussiness.Admin;
using FPLDQ.Entity;
using FPLDQ.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPLDQ.BLOG.Controllers
{
    /// <summary>
    /// 登录页面
    /// </summary>
    [ApiController]
    [Route("api/admin/[controller]")]
    public class LoginController
    {
        private UserManager userManager = new UserManager();
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userCode">用户账号</param>
        /// <param name="userPassword">用户密码</param>
        /// <returns></returns>
        [HttpPost("LoginIn")]
        public ApiResult<LoginUserModel> Login(string userCode, string userPassword) {
            ApiResult<LoginUserModel> result = new ApiResult<LoginUserModel>();
            valiableUserResult<User> valiableUser =  userManager.valiableUser(userCode, userPassword);
            if (!valiableUser.success)
            {
                result.Code = ApiResultStatu.Error;
                result.Msg = valiableUser.Msg;
                result.Success = false;
                result.Data = null;
            }
            else
            {
                result.Code = ApiResultStatu.OK;
                result.Msg = valiableUser.Msg;
                result.Success = true;
                LoginUserModel loginUser = new LoginUserModel();
                loginUser.userCode = valiableUser.Data.userCode;
                loginUser.userId = valiableUser.Data.id;
                loginUser.userName = valiableUser.Data.userName;
                loginUser.userLoginTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                 //给用户派发令牌 30分钟过期
                loginUser.userToken = userManager.getuserToken(valiableUser.Data,new TimeSpan(0,30,0));
                result.Data = loginUser;
            }

            return result;
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="userCode">用户代码</param>
        /// <param name="token">用户令牌</param>
        /// <returns></returns>
        [HttpGet("LoginOut")]
        public ApiResult<bool> LoginOut(string userCode ,string token) {
            ApiResult<bool> apiResult = new ApiResult<bool>();
            if (string.IsNullOrEmpty(token))
            {
                apiResult.Code = ApiResultStatu.Error;
                apiResult.Msg = "token为空";
                apiResult.Success = false;
                apiResult.Data = false;
                return apiResult;
            }

            userManager.unInitUserToken(token);
            apiResult.Code = ApiResultStatu.OK;
            apiResult.Msg = userCode + "退出成功";
            apiResult.Success = true;
            apiResult.Data = true;
            return apiResult;

        }
    }
}
