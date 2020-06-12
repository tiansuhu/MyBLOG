using FPLDQ.IService;
using FPLDQ.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FPLDQ.Service
{
    public class baseService<T> 
    {
        /// <summary>
        /// 每个实例都需要实现初始化表
        /// </summary>
        public void initTable()
        {
            BaseDB.GetClient().CodeFirst.InitTables(typeof(T));
        }
    }
}
