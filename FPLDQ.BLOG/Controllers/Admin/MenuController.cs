using FPLDQ.Bussiness.Admin;
using FPLDQ.Entity;
using FPLDQ.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPLDQ.BLOG.Controllers.Admin
{
    /// <summary>
    /// 菜单操作类
    /// </summary>
    [ApiController]
    [Route("api/admin/[controller]")]
    //[Authorize(Policy = "Admin")] 先注释权限验证
    public class MenuController: ControlBase
    {
        private MenuManager menuManager = new MenuManager();

        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetMenu")]
        public ApiResult<List<MenuModel>> GetMenu([FromBody] object valuse) {
            ApiResult<List<MenuModel>> apiResult = new ApiResult<List<MenuModel>>();
            apiResult.Code = ApiResultStatu.OK;
            apiResult.Data = menuManager.GetMenuModels();
            apiResult.Success = true;
            return apiResult;

        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="valuse"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public ApiResult<bool> AddMenu([FromBody] Menu valuse)
        {
            ApiResult<bool> apiResult = new ApiResult<bool>();
            valuse.creater = this.GetCurrentUser().Uid;
            valuse.createrTime = System.DateTime.Now;
            valuse.menuid = valuse.id;
            if (string.IsNullOrEmpty(valuse.parentid))
            {
                valuse.path = "/home/" + valuse.name;
            }
            else {
                Menu parentmenu = menuManager.Get(valuse.parentid);
                valuse.path  = parentmenu.path + "/" + valuse.name;
            }
            apiResult.Code = ApiResultStatu.OK;
            apiResult.Data = menuManager.Add(valuse);
            apiResult.Success = true;
            return apiResult;
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="valuse"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public ApiResult<bool> UpdateMenu([FromBody] Menu valuse)
        {
            ApiResult<bool> apiResult = new ApiResult<bool>();
            valuse.modifier = this.GetCurrentUser().Uid;
            valuse.modifiedTime = System.DateTime.Now;
            apiResult.Code = ApiResultStatu.OK;
            apiResult.Data = menuManager.Update(valuse);
            apiResult.Success = true;
            return apiResult;
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        public ApiResult<bool> DeleteMenu([FromBody] string id)
        {
            ApiResult<bool> apiResult = new ApiResult<bool>();
            if (menuManager.getChildren(id).Count > 0) {
                apiResult.Code = ApiResultStatu.Error;
                apiResult.Data = false;
                apiResult.Success = false;
                apiResult.Msg = "存在子菜单 不允许删除";
            }
            else {
                apiResult.Code = ApiResultStatu.OK;
                apiResult.Data = menuManager.Delete(id);
                apiResult.Success = true;
            }
            
            return apiResult;
        }
    }
}
