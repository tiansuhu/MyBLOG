using FPLDQ.Bussiness.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.InitMyBLOG
{
    /// <summary>
    /// 初始化 组织关系表
    /// </summary>
   public static class OrganizationOrgInit
    {
        
        private static OrganizationOrgManager manager = new OrganizationOrgManager();
        public static void init()
        {
           //初始化表
            manager.InitTable();
        }
       
    }
}
