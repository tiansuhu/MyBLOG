using FPLDQ.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Model
{
    /// <summary>
    /// 菜单信息
    /// </summary>
    public class MenuModel
    {
        /// <summary>
        /// 菜单
        /// </summary>
        public Menu menu { get; set; }
        /// <summary>
        /// 菜单子集
        /// </summary>
        public List<MenuModel> Children { get; set; }
    }
}
