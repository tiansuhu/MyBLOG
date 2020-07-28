using FPLDQ.IService;
using FPLDQ.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Bussiness.Admin
{
    public class OrganizationOrgManager
    {
        private IOrganizationOrg orgOrgService = OrganizationFactory.CreateFactory().GetOrganizationOrgService();

        /// <summary>
        /// 初始化表单
        /// </summary>
        public void InitTable()
        {
            orgOrgService.initTable();
        }

    }
}
