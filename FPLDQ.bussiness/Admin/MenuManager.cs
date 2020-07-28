using FPLDQ.Entity;
using FPLDQ.IService;
using FPLDQ.Model;
using FPLDQ.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Bussiness.Admin
{
    public class MenuManager
    {
        private IMenu menuService = MenuFactory.CreateFactory().GetMenuService();

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool Add(Menu menu) {
            return menuService.add(menu);
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool Update(Menu menu) {
            return menuService.update(menu);
        }
        /// <summary>
        /// 删除菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id) {
            return menuService.delete(id);
        }

        public List<Menu> getChildren(string id) {
            return menuService.getchildren(id);
        }
        /// <summary>
        /// 加载所有的菜单
        /// </summary>
        /// <returns></returns>
        public List<MenuModel> GetMenuModels() {
            List<MenuModel> menus = new List<MenuModel>();
           
            //获取所有的菜单
            List<Menu> listmenus = menuService.GetMenuModels();
            menus = Loadchildren(listmenus);
            return menus;
        }

        /// <summary>
        /// 通过id获取菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Menu Get(string id) {
            return menuService.get(id);
        }

        


        #region  内部方法
        private List<MenuModel> Loadchildren (List<Menu> menus,string parentid="")
        {
            List<MenuModel> menuModels = new List<MenuModel>();
            if (string.IsNullOrEmpty(parentid))
            {
                List<Menu> menulist = menus.FindAll(o => string.IsNullOrEmpty(o.parentid));
                
                foreach (Menu menu in menulist)
                {
                    MenuModel menuModel = new MenuModel();
                    menuModel.menu = menu;
                    menuModel.Children = this.Loadchildren(menus, menu.id);
                    menuModels.Add(menuModel);
                }
            }
            else {
                List<Menu> menulist = menus.FindAll(o => o.parentid == parentid);
                foreach (Menu menu in menulist)
                {
                    MenuModel menuModel = new MenuModel();
                    menuModel.menu = menu;
                    menuModel.Children = this.Loadchildren(menus, menu.id);
                    menuModels.Add(menuModel);

                }
            }
            
            return menuModels; 
        }


        #endregion


        /// <summary>
        /// 初始化表单
        /// </summary>
        public void InitTable()
        {
            menuService.initTable();
        }
    }
}
