using Microsoft.AspNetCore.Mvc;
using FPLDQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPLDQ.Entity;
using FPLDQ.Bussiness.Admin;
using Microsoft.AspNetCore.Authorization;
using FPLDQ.Token.Model;
using FPLDQ.Common;

namespace FPLDQ.BLOG.Controllers.Admin
{
    /// <summary>
    /// 用户操作
    /// </summary>
    [ApiController]
    [Route("api/admin/[controller]")]
    //[Authorize(Policy = "Admin")]    先注释权限验证
    public class UserController: ControlBase
    {
        private UserManager userManager = new UserManager();
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUserByID")]
        public ApiResult<User> GetUserByID(string id) {

            TokenModel m = this.GetCurrentUser();
            NLogHelp.WriteInfo("用户开始访问。。。");
            ApiResult<User> ApiResult = new ApiResult<User>();
            User u = userManager.GetUserByID(id);
            if (u == null)
            {
                ApiResult.Data = u;
                ApiResult.Code = ApiResultStatu.Error;
                ApiResult.Success = false;
                ApiResult.Msg = "该用户不存在";
            }
            else
            {
                ApiResult.Data = u;
                ApiResult.Code = ApiResultStatu.OK;
                ApiResult.Success = true;
                ApiResult.Msg = "成功";
            }
            
            return ApiResult;
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public ApiResult<bool> AddUser(User u) {
            ApiResult<bool> apiResult = new ApiResult<bool>();
            User user = u;
            user.id = System.Guid.NewGuid().ToString().ToLower();
            bool res  = userManager.AddUser(user);
            apiResult.Code = ApiResultStatu.OK;
            apiResult.Success = true;
            apiResult.Msg = "成功";
            apiResult.Data = res;
            return apiResult;

        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddUserModel")]
        public ApiResult<bool> AddUser(UserModel model) {
            //TODO:这个地方还是有问题的 没有和组织联系起来
            ApiResult<bool> apiResult = new ApiResult<bool>();
            model.user.id = Guid.NewGuid().ToString().ToLower();
            model.organizationUser.id = Guid.NewGuid().ToString().ToLower();
            apiResult.Success = userManager.AddUser(model);
            if (apiResult.Success)
            {
                apiResult.Code = ApiResultStatu.OK;
            }
            else
                apiResult.Code = ApiResultStatu.Error;
            return apiResult;
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        [HttpPost("UpdateUser")]
        public ApiResult<bool> UpdateUser(User u) {
            ApiResult<bool> apiResult = new ApiResult<bool>();
            User user = new User();
            user.userQQ = u.userQQ;
            user.id = u.id;
            bool res = userManager.UpdateUser(user);
            apiResult.Code = ApiResultStatu.OK;
            apiResult.Success = true;
            apiResult.Msg = "成功";
            apiResult.Data = res;
            return apiResult;
        }
        /// <summary>
        /// 初始化用户表
        /// </summary>
        /// <returns></returns>
        [HttpGet("InitUserTable")]
        public string InitUserTable() {
            userManager.InitTable();
            return "成功";
        }
    }
}
