using FPLDQ.Entity;
using FPLDQ.IService;
using FPLDQ.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Bussiness.Admin
{

   public  class OrganizationManager
    {
        private IOrganization orgService = new OrganizationService();


        public bool Add(Organization org) {
            return orgService.add(org);
        }

        /// <summary>
        /// 初始化表
        /// </summary>
        public void InitTable()
        {
            orgService.initTable();
        }
    }
}
