using FPLDQ.Bussiness.Admin;
using FPLDQ.Entity;
using FPLDQ.IService;
using FPLDQ.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.InitMyBLOG
{
    public static class OrganizationInit
    {
        private static OrganizationManager manager = new OrganizationManager();

        public static void init()
        {
            Organization org = new Organization();
            org.id = "dd9a2123-2151-43cf-b8f0-384dbf763740";
            org.createrTime = System.DateTime.Now;
            org.creater = "ad9a2123-2151-43cf-b8f0-384dbf763741";
            org.orgCode = "MyCompany";
            org.orgName = "我的公司";
            org.isroot = true;
            
            //初始化表
            manager.InitTable();
            
            //插入数据
            manager.Add(org);

        }
    }
}
