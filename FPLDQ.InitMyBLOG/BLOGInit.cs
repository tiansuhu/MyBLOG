using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.InitMyBLOG
{
    public static class BLOGInit
    {
        /// <summary>
        /// 初始化数据
        /// </summary>
        public static void init() {

            OrganizationInit.init();//初始化组织表
            OrganizationOrgInit.init();//初始化组织关系表
            UserInit.init();//初始化用户
            UserInit.initOrgUser();//初始化用户组织关系表

            MenuInit.init();



        }
    }
}
