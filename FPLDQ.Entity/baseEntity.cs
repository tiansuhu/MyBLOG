using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.Entity
{
    public class baseEntity
    {
        private string _id = string.Empty;

        /// <summary>
        /// entity 的基类 
        /// </summary>
        //[SugarColumn(ColumnName = "id",IsNullable = false, IsPrimaryKey = true,)]
        [SugarColumn(ColumnName = "id", IsNullable = false, IsPrimaryKey = true)]
        public string id
        {
            get
            {
                if (string.IsNullOrEmpty(this._id))
                {
                    //如果为空的话 设置个默认的值
                    this._id = Guid.NewGuid().ToString().ToLower();
                }
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(ColumnName = "creater", IsNullable = true)]
        public string creater { get; set; }

        private DateTime _createtime;
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "creatertime", IsNullable = true)]
        public DateTime createrTime {
            get {
                //没有值就默认当前时间
                if (_createtime == null) {
                    _createtime = System.DateTime.Now;
                }
                return _createtime;
            }
            set {
                _createtime = value;
            }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        [SugarColumn(ColumnName = "modifier", IsNullable = true)]
        public string modifier { get; set; }

        private DateTime _modifiedtime;

        /// <summary>
        /// 修改时间
        /// </summary>
        [SugarColumn(ColumnName = "modifiedtime", IsNullable = true)]
        public DateTime modifiedTime {
            get {
                //没有值就默认当前时间
                if (_modifiedtime == null)
                {
                    _modifiedtime = System.DateTime.Now;
                }
                return _modifiedtime;
            }
            set {
                _modifiedtime = value;
            }
        }
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
