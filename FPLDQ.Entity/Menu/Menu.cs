using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Entity
{
    /// <summary>
    /// 菜单实体类
    /// </summary>
    [SugarTable("h_menu")]
    public class Menu : baseEntity
    {

        public string menuid { get; set; } //id

        [SugarColumn(IsNullable = true)]
        public string parentid { get; set; } //父级id

        public string displayName { get; set; }//菜单名称

        [SugarColumn(IsNullable = true)]
        public string ico { get; set; } //菜单图标
        public MenuType type { get; set; }//菜单类型

        [SugarColumn(IsNullable = true)]
        public string path { get; set; } //菜单路径

        public string name { get; set; }//菜单名称 
        [SugarColumn(IsNullable = true)]
        public string component { get; set; }//对应的页面
    }
}
