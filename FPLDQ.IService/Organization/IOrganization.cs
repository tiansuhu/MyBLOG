using FPLDQ.Entity;
using FPLDQ.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.IService
{
    /// <summary>
    /// 组织类
    /// </summary>
    public interface IOrganization: IbaseService<Organization>
    {
        /// <summary>
        /// 添加组织
        /// </summary>
        /// <param name="orgModel"></param>
        /// <returns></returns>
        public bool add(OrgModel orgModel);
        /// <summary>
        /// 更新组织
        /// </summary>
        /// <param name="orgModel"></param>
        /// <returns></returns>
        public bool update(OrgModel orgModel);

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="orgModel"></param>
        /// <returns></returns>
        public bool delete(OrgModel orgModel);

        /// <summary>
        /// 通过id获取组织信息
        /// </summary>
        /// <param name="id">组织id</param>
        /// <returns></returns>
        public OrgModel getOrgModelById(string id);
        /// <summary>
        /// 通过code获取组织信息
        /// </summary>
        /// <param name="orgCode">组织Code</param>
        /// <returns></returns>
        public OrgModel getOrgModelByCode(string orgCode);
        /// <summary>
        /// 通过父级id获取组织的子集元素
        /// </summary>
        /// <param name="parentid"></param>
        /// <returns></returns>
        public List<OrgModel> GetOrgModels(string parentid);

    }
}
