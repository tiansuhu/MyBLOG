using Microsoft.AspNetCore.Mvc;
using FPLDQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPLDQ.Entity;
using FPLDQ.Bussiness.Admin;
using Microsoft.AspNetCore.Authorization;

namespace FPLDQ.BLOG.Controllers.Admin
{
    /// <summary>
    /// 用户操作
    /// </summary>
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Policy = "Admin")]
    public class UserController: ControllerBase
    {
        private UserManager userManager = new UserManager();
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiResult<User> GetUserByID(string id) {
            ApiResult<User> ApiResult = new ApiResult<User>();
            User u = userManager.GetUserByID(id);
            ApiResult.Data = u;
            ApiResult.Code = ApiResultStatu.OK;
            ApiResult.Success = true;
            ApiResult.Msg = "成功";
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
