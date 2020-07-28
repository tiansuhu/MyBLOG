using FPLDQ.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Service
{
    public class MenuFactory
    {
        private static MenuFactory menuFactory = new MenuFactory();

        public static MenuFactory CreateFactory() {
            return menuFactory;
        }

        #region Menu
        public IMenu GetMenuService() {
            return new MenuService();
        }
        #endregion 
    }
}
