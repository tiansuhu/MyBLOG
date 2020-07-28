using FPLDQ.Bussiness.Admin;
using FPLDQ.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.InitMyBLOG
{
    public static class MenuInit
    {
        private static MenuManager manager = new MenuManager();

        public static void init()
        {
           
            //初始化表
            manager.InitTable();

            Menu menu = new Menu();
            menu.id = "od9a2123-2151-43cf-b8f0-384dbf763740";
            menu.createrTime = System.DateTime.Now;
            menu.creater = "ad9a2123-2151-43cf-b8f0-384dbf763741";
            menu.menuid= "od9a2123-2151-43cf-b8f0-384dbf763740"; //id
            menu.displayName= "快乐";//菜单名称
            menu.ico= "el-icon-s-tools"; //菜单图标
            menu.type= MenuType.Link;//菜单类型
            menu.path= "/home/hello"; //菜单路径
            menu.name= "hello";//菜单名称 
            menu.component= "views/home/hello.vue";//对应的页面

            Menu menu1 = new Menu();
            menu1.id = "od9a2123-2151-43cf-b8f0-384dbf763741";
            menu.createrTime = System.DateTime.Now;
            menu.creater = "ad9a2123-2151-43cf-b8f0-384dbf763741"; 
            menu1.menuid= "od9a2123-2151-43cf-b8f0-384dbf763741"; //id
            menu1.displayName= "角色管理";//菜单名称
            menu1.ico= "el-icon-user-solid"; //菜单图标
            menu1.type= MenuType.Link;//菜单类型
            menu1.path= "/home/role"; //菜单路径
            menu1.name= "role";//菜单名称 
            menu1.component= "views/home/RoleManager/Role.vue";//对应的页面
            menu1.parentid =menu.id;


            Menu menu2 = new Menu();
            menu2.id = "od9a2123-2151-43cf-b8f0-384dbf763742";
            menu2.createrTime = System.DateTime.Now;
            menu2.creater = "ad9a2123-2151-43cf-b8f0-384dbf763741";
            menu2.menuid = "od9a2123-2151-43cf-b8f0-384dbf763742"; //id
            menu2.displayName = "组织管理";//菜单名称
            menu2.ico = "el-icon-user-solid"; //菜单图标
            menu2.type = MenuType.Link;//菜单类型
            menu2.path = "/home/organizaiton"; //菜单路径
            menu2.name = "organizaiton";//菜单名称 
            menu2.component = "views/home/OrgnizationManager/Orgnization.vue";//对应的页面
            menu2.parentid = menu.id;
            
            Menu menu3 = new Menu();
            menu3.id = "od9a2123-2151-43cf-b8f0-384dbf763743";
            menu3.createrTime = System.DateTime.Now;
            menu3.creater = "ad9a2123-2151-43cf-b8f0-384dbf763741";
            menu3.menuid = menu3.id; //id
            menu3.displayName = "菜单管理";//菜单名称
            menu3.ico = "el-icon-user-solid"; //菜单图标
            menu3.type = MenuType.Link;//菜单类型
            menu3.path = "/home/menuManager"; //菜单路径
            menu3.name = "menuManager";//菜单名称 
            menu3.component = "";//对应的页面
            menu3.parentid = menu.id;


            Menu menu3_2 = new Menu();
            menu3_2.id = "od9a2123-2151-43cf-b8f0-384dbf763732";
            menu3_2.createrTime = System.DateTime.Now;
            menu3_2.creater = "ad9a2123-2151-43cf-b8f0-384dbf763741";
            menu3_2.menuid= menu3_2.id; //id
            menu3_2.displayName= "菜单管理1";//菜单名称
            menu3_2.ico= "el-icon-user-solid"; //菜单图标
            menu3_2.type = MenuType.Link;//菜单类型
            menu3_2.path= "/home/menuManager/menuchildMamager"; //菜单路径
            menu3_2.name= "menuchildMamager_menuchildMamager";//菜单名称 
            menu3_2.component= "";//对应的页面
            menu3_2.parentid = menu3.id;

            Menu menu3_1 = new Menu();
            menu3_1.id = "od9a2123-2151-43cf-b8f0-384dbf763731";
            menu3_1.createrTime = System.DateTime.Now;
            menu3_1.creater = "ad9a2123-2151-43cf-b8f0-384dbf763741";
            menu3_1.menuid= menu3_1.id; //id
            menu3_1.displayName= "菜单列表";//菜单名称
            menu3_1.ico = "el-icon-user-solid"; //菜单图标
            menu3_1.type= MenuType.Link;//菜单类型
            menu3_1.path="/home/menuManager/menu"; //菜单路径
            menu3_1.name="menuManager";//菜单名称 
            menu3_1.component= "views/home/MenuManager/MenuList.vue";//对应的页面
            menu3_1.parentid = menu3.id;

            Menu menu3_2_1 = new Menu();
            menu3_2_1.id = "od9a2123-2151-43cf-b8f0-384dbf763321";
            menu3_2_1.createrTime = System.DateTime.Now;
            menu3_2_1.creater = "ad9a2123-2151-43cf-b8f0-384dbf763741";
            menu3_2_1.menuid = menu3_2_1.id; //id
            menu3_2_1.displayName= "菜单列表1";//菜单名称
            menu3_2_1.ico=  "el-icon-user-solid"; //菜单图标
            menu3_2_1.type=  MenuType.Link;//菜单类型
            menu3_2_1.path="/home/menuManager/menuchildMamager/menu"; //菜单路径
            menu3_2_1.name="menuchildMamager_menu";//菜单名称 
            menu3_2_1.component= "views/home/MenuManager/MenuList.vue";//对应的页面
            menu3_2_1.parentid = menu3_2.id;


//初始化表
            manager.InitTable();
            Menu vorg = manager.Get(menu.id);
            Menu vorg1 = manager.Get(menu1.id);//验证当前user是否已经存在
            Menu vorg2 = manager.Get(menu2.id);//验证当前user是否已经存在
            Menu vorg3 = manager.Get(menu3.id);//验证当前user是否已经存在
            Menu vorg3_1 = manager.Get(menu3_1.id);//验证当前user是否已经存在
            Menu vorg3_2 = manager.Get(menu3_2.id);//验证当前user是否已经存在
            Menu vorg3_2_1 = manager.Get(menu3_2_1.id);//验证当前user是否已经存在
            //不存在就初始化当前数据
            if (vorg == null || string.IsNullOrEmpty(vorg.id))
            {
                manager.Add(menu);
                Console.WriteLine("初始化菜单成功");
            }

            if (vorg1 == null || string.IsNullOrEmpty(vorg1.id))
            {
                manager.Add(menu1);
                Console.WriteLine("初始化菜单成功");
            }

            if (vorg2 == null || string.IsNullOrEmpty(vorg2.id))
            {
                manager.Add(menu2);
                Console.WriteLine("初始化菜单成功");
            }
            if (vorg3 == null || string.IsNullOrEmpty(vorg3.id))
            { 
                manager.Add(menu3); 
                Console.WriteLine("初始化菜单成功"); 
            }

            if (vorg3_1 == null || string.IsNullOrEmpty(vorg3_1.id))
            { 
                manager.Add(menu3_1);
                Console.WriteLine("初始化菜单成功"); 
            }
            if (vorg3_2 == null || string.IsNullOrEmpty(vorg3_2.id))
            { 
                manager.Add(menu3_2); 
                Console.WriteLine("初始化菜单成功"); 
            }
            if (vorg3_2_1 == null || string.IsNullOrEmpty(vorg3_2_1.id))
            { 
                manager.Add(menu3_2_1); 
                Console.WriteLine("初始化菜单成功"); 
            }

            }
    }
}
