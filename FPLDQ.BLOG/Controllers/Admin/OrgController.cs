using FPLDQ.Bussiness.Admin;
using FPLDQ.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPLDQ.BLOG.Controllers.Admin
{
    /// <summary>
    /// 组织操作
    /// </summary>
    [ApiController]
    [Route("api/admin/[controller]")]
    //[Authorize(Policy = "Admin")] 先注释权限验证
    public class OrgController : ControlBase
    {
        private OrganizationManager orgManager = new OrganizationManager();

        /// <summary>
        /// 添加组织
        /// </summary>
        /// <param name="org"></param>
        /// <returns></returns>
        [HttpPost("AddOrg")]
        public ApiResult<bool> AddOrg(OrgModel org)
        {
            ApiResult<bool> apiResult = new ApiResult<bool>();
            OrgModel orgnization= org;
            if (org.organization.isroot) {
                org.parentOrgId = "-1";
            }
            bool res = orgManager.Add(orgnization);
            apiResult.Code = res?ApiResultStatu.OK: ApiResultStatu.Error;
            apiResult.Success = res;
            apiResult.Data = res;
            return apiResult;
        }

        /// <summary>
        /// 获取组织信息
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpGet("GetOrgChilds")]
        public ApiResult<List<OrgModel>> getOrg(string parentId ="") {
            ApiResult<List<OrgModel>> apiResult = new ApiResult<List<OrgModel>>();
            List<OrgModel> orglist = orgManager.GetChilds(parentId);
            apiResult.Code = ApiResultStatu.OK;
            apiResult.Success = true;
            apiResult.Data = orglist;
            apiResult.Msg = "成功";
            return apiResult;
        }
    }
}
