using FPLDQ.Entity;
using FPLDQ.Token;
using FPLDQ.Token.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPLDQ.BLOG.Controllers
{
    /// <summary>
    /// 当前用户信息
    /// </summary>
    public class ControlBase : ControllerBase
    {
        // public TokenModel CurrentUser = new TokenModel();

        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        protected TokenModel GetCurrentUser()
        {
            var headers = HttpContext.Request.Headers;
            //检测是否包含'Authorization'请求头，如果不包含返回context进行下一个中间件，用于访问不需要认证的API
            if (!headers.ContainsKey("Authorization"))
            {
                return null;
            }

            var tokenStr = headers["Authorization"];

            try
            {
                string jwtStr = tokenStr.ToString().Substring("Bearer ".Length).Trim();
                //验证缓存中是否存在该jwt字符串
                if (!BLOGPIMemoryCache.Exists(jwtStr))
                {
                    return null;
                }
                TokenModel tm = ((TokenModel)BLOGPIMemoryCache.Get(jwtStr));

                return tm;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



    }
}
