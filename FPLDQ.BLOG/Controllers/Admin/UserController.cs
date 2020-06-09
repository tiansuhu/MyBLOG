using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPLDQ.BLOG.Controllers.Admin
{
    /// <summary>
    /// 用户操作
    /// </summary>
    [ApiController]
    [Route("api/admin/[controller]")]
    public class UserController: ControllerBase
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetUser() {
            return "this is userinfo";
        }
        /// <summary>
        /// 通过名称获取用户
        /// </summary>
        /// <param name="name">用户名称</param>
        /// <returns></returns>
        [HttpGet("getUserbyName")]
        public string GetUser(string name) {
            return name;
        }
    }
}
