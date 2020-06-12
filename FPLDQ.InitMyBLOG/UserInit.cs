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

            //插入数据
            manager.AddUser(user);

        }
    }
}
