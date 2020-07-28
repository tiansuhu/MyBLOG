using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FPLDQ.Token;
using FPLDQ.Token.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace FPLDQ.BLOG.AuthHelper
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    /// <summary>
    /// 令牌操作类
    /// </summary>
    public class TokenAuth
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next"></param>
        public TokenAuth(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// 中间键执行方法
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext httpContext)
        {

            var headers = httpContext.Request.Headers;
            //检测是否包含'Authorization'请求头，如果不包含返回context进行下一个中间件，用于访问不需要认证的API
            if (!headers.ContainsKey("Authorization"))
            {
                //return httpContext.Response.WriteAsync("非法请求");
                return _next(httpContext);
            }
            var tokenStr = headers["Authorization"];
            try
            {
                string jwtStr = tokenStr.ToString().Substring("FPLDQBearer ".Length).Trim();
                //验证缓存中是否存在该jwt字符串
                if (!BLOGPIMemoryCache.Exists(jwtStr))
                {
                    Model.ApiResult<bool> apiResult = new Model.ApiResult<bool>();
                    apiResult.Code = Model.ApiResultStatu.Error;
                    apiResult.Data = false;
                    apiResult.Msg = "验证不通过,请求非法路径.";
                    apiResult.Success = false;
                    return httpContext.Response.WriteAsync(apiResult.ToString());
                }
                TokenModel tm = ((TokenModel)BLOGPIMemoryCache.Get(jwtStr));
                //提取tokenModel中的Sub属性进行authorize认证
                List<Claim> lc = new List<Claim>();
                Claim c = new Claim(tm.Sub + "Type", tm.Sub);
                lc.Add(c);
                ClaimsIdentity identity = new ClaimsIdentity(lc);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                httpContext.User = principal;
                return _next(httpContext);
            }
            catch (Exception ex)
            {
                Model.ApiResult<bool> apiResult = new Model.ApiResult<bool>();
                apiResult.Code = Model.ApiResultStatu.Error;
                apiResult.Data = false;
                apiResult.Msg = "token验证异常:" + ex.StackTrace + " 错误信息+"+ex.Message ;
                apiResult.Success = false;
                return httpContext.Response.WriteAsync(apiResult.ToString());
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
   /// <summary>
   /// 中间键方法类
   /// </summary>
    public static class TokenAuthExtensions
    {
        /// <summary>
        /// 建立
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseTokenAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenAuth>();
        }
    }
}
