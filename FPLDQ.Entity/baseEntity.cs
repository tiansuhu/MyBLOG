using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Entity
{
   public  class baseEntity
   {
        /// <summary>
        /// entity 的基类 
        /// </summary>
        //[SugarColumn(ColumnName = "id",IsNullable = false, IsPrimaryKey = true,)]
        [SugarColumn(ColumnName ="id",IsNullable = false, IsPrimaryKey = true)]
        public string id { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(ColumnName = "creater",IsNullable = true)]
        public string creater { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "creatertime", IsNullable = true)]
        public DateTime createrTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [SugarColumn(ColumnName = "modifier", IsNullable = true)]
        public string modifier { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [SugarColumn(ColumnName = "modifiedtime", IsNullable = true)]
        public DateTime modifiedTime { get; set; }
        /// <summary>
        /// 扩展字段1
        /// </summary>
        [SugarColumn(ColumnName = "extends1", IsNullable = true)]
        public string extends1 { get; set; }
        /// <summary>
        /// 扩展字段2
        /// </summary>
        [SugarColumn(ColumnName = "extends2", IsNullable = true)]
        public string extends2 { get; set; }
        /// <summary>
        /// 扩展字段3
        /// </summary>
        [SugarColumn(ColumnName = "extends3", IsNullable = true)]
        public string extends3 { get; set; }
        /// <summary>
        /// 扩展字段4
        /// </summary>
        [SugarColumn(ColumnName = "extends4", IsNullable = true)]
        public string extends4 { get; set; }
        /// <summary>
        /// 扩展字段5
        /// </summary>
        [SugarColumn(ColumnName = "extends5", IsNullable = true)]
        public string extends5 { get; set; }
        /// <summary>
        /// 扩展字段6
        /// </summary>
        [SugarColumn(ColumnName = "extends6", IsNullable = true)]
        public string extends6 { get; set; }
        /// <summary>
        /// 扩展字段7
        /// </summary>
        [SugarColumn(ColumnName = "extends7", IsNullable = true)]
        public string extends7 { get; set; }
        /// <summary>
        /// 扩展字段8
        /// </summary>
        [SugarColumn(ColumnName = "extends8", IsNullable = true)]
        public string extends8 { get; set; }
    }
}
