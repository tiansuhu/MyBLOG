using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPLDQ.Model
{
    public class BaseDB
    {
        public static SqlSugarClient GetClient()
        {
            SqlSugarClient db = new SqlSugarClient(
                new ConnectionConfig()
                {
                    ConnectionString = BaseDBConfig.ConnectionString,
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                }
            );

            
            //执行前事件
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                //db.CodeFirst.InitTables(typeof(Entity.User));
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }
    }
}
