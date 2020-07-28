using FPLDQ.Entity;
using FPLDQ.IService;
using FPLDQ.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FPLDQ.Service
{

    class MenuService : baseService<Menu>, IMenu
    {
        private SimpleClient<Menu> Client = new SimpleClient<Menu>(BaseDB.GetClient());
        public bool add(Menu et)
        {
            //TODO:添加
            return Client.Insert(et);
        }

        public bool delete(string id)
        {
            return Client.DeleteById(id);
        }

        public Menu get(string id)
        {
            return Client.GetById(id);
        }

        /// <summary>
        /// 获取菜单实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MenuModel getMenuModel(string id)
        {
            //MenuModel menuModel = new MenuModel();
            //menuModel.menu = this.get(id);
            //menuModel.Children = this.getchildren(id);
            //return menuModel;
            return null;
        }




        /// <summary>
        /// 获取子集菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Menu> getchildren(string id)
        {
            return Client.GetList(e => e.parentid == id);
        }

        public TableModel<Menu> getPageList(int pageIndex, int pageSize)
        {
            PageModel page = new PageModel { PageSize = pageSize, PageIndex = pageIndex };
            Expression<Func<Menu, bool>> ex = (it => 1 == 1);
            List<Menu>  menus = Client.GetPageList(ex, page);
            TableModel<Menu> r = new TableModel<Menu>();
            r.Code = 0;
            r.Count = page.PageCount;
            r.Data = menus;
            r.Msg = "成功";
            return r;
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="et"></param>
        /// <returns></returns>
        public bool update(Menu et)
        {
            return Client.AsUpdateable(et).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 加载菜单
        /// </summary>
        /// <returns></returns>
        public List<Menu> GetMenuModels()
        {
            return Client.AsQueryable().ToList();//获取所有的菜单
            //using (SqlSugarClient db = BaseDB.GetClient()) {
            //    //获取所有的数据
            //    return db.Queryable<Menu>().Select(o => new MenuModel
            //    {
            //        menu = o
            //    }).ToList();
            //}
            
        }
    }
}
