using FPLDQ.Bussiness.Admin;
using FPLDQ.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.InitMyBLOG
{
    public class UserInit
    {
        private static UserManager manager = new UserManager();

        private static OrganizationUserManager orgUsrManager = new OrganizationUserManager();

        public static void init()
        {
            User user = new User();
            user.id = "dd9a2123-2151-43cf-b8f0-384dbf763740";
            user.createrTime = System.DateTime.Now;
            user.creater = "ad9a2123-2151-43cf-b8f0-384dbf763741";
            user.userCode = "Admin";
            user.userName = "Admin";
            user.isActivy = true;
            user.isAdmin = true;
            user.password = "NjcwQjE0NzI4QUQ5OTAyQUVDQkEzMkUyMkZBNEY2QkQ=";//000000加密后的数据
            //初始化表
            manager.InitTable();

            User vuser = manager.GetUserByID(user.id);//验证当前user是否已经存在
            if (vuser == null || string.IsNullOrEmpty(vuser.id)) 
            //不存在 就插入数据
            manager.AddUser(user);

        }

        public static void initOrgUser() {
            orgUsrManager.InitTable();//初始化表
            OrganizationUser orgu = new OrganizationUser();
            orgu.id = "bd9a2123-2151-43cf-b8f0-384dbf763742";
            orgu.createrTime = System.DateTime.Now;
            orgu.creater = "ad9a2123-2151-43cf-b8f0-384dbf763741";
            orgu.orgid = "od9a2123-2151-43cf-b8f0-384dbf763740";
            orgu.userid = "dd9a2123-2151-43cf-b8f0-384dbf763740";
            OrganizationUser vorguser = orgUsrManager.Get(orgu.id);//验证当前user是否已经存在
            if (vorguser == null || string.IsNullOrEmpty(vorguser.id))
            {
                //不存在 就插入数据
                bool res = orgUsrManager.Add(orgu);
            }
               

        }
    }
}
