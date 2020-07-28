using FPLDQ.Entity;
using FPLDQ.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.IService
{
    /// <summary>
    /// 菜单接口
    /// </summary>
    public interface IMenu : IbaseService<Menu>
    {
        public List<Menu> getchildren(string id);

        public MenuModel getMenuModel(string id);

        public List<Menu> GetMenuModels();
    }
}
