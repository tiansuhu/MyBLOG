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
    class OrganizationService : baseService<Organization>, IOrganization
    {
        private SimpleClient<Organization> Client = new SimpleClient<Organization>(BaseDB.GetClient());
        public bool add(Organization et)
        {
            return Client.Insert(et);
        }

        public bool add(OrgModel model)
        {

            SqlSugarClient db = BaseDB.GetClient();
            try
            {
                //db.BeginTran();//开启事务
                //特别说明：在事务中，默认情况下是使用锁的，也就是说在当前事务没有结束前，其他的任何查询都需要等待
                //ReadCommitted：在正在读取数据时保持共享锁，以避免脏读，但是在事务结束之前可以更改数据，从而导致不可重复的读取或幻像数据。
                //db.BeginTran(System.Data.IsolationLevel.ReadCommitted); //重载指定事务的级别
                db.BeginTran();
                var res = db.Insertable<Organization>(model.organization).ExecuteCommand();
                var res1 = db.Insertable<OrganizationOrg>(new OrganizationOrg { orgid = model.organization.id, parentorgid = model.parentOrgId }).ExecuteCommand();
                db.CommitTran();//提交事务
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTran();//回滚
                return false;
            }
        }


        public bool delete(string id)
        {
            return Client.DeleteById(id);
        }

        public bool delete(OrgModel orgModel)
        {
            try
            {
                using (SqlSugarClient db = BaseDB.GetClient())
                {
                    db.BeginTran();//开始事物
                    db.Deleteable<Organization>(orgModel.organization).ExecuteCommand();
                    db.Deleteable<OrganizationOrg>().Where(orgo => orgo.orgid == orgModel.parentOrgId).ExecuteCommand();
                    db.CommitTran();//提交事务
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Organization get(string id)
        {
            return Client.GetById(id);
        }

        /// <summary>
        /// 通过code获取组织信息
        /// </summary>
        /// <param name="orgCode"></param>
        /// <returns></returns>
        public OrgModel getOrgModelByCode(string orgCode)
        {
            using (SqlSugarClient db = BaseDB.GetClient())
            {
                List<OrgModel> res = db.Queryable<Organization, OrganizationOrg>((o, oo) => new object[] {
                    JoinType.Left,o.id==oo.orgid})
                     .Where((o, oo) => o.orgCode == orgCode)
                     .Select((o, oo) => new OrgModel
                     {
                         organization = o,
                         parentOrgId = oo.parentorgid
                     }).ToList();

                if (res.Count > 0)
                {
                    return res[0];
                }
                else
                    return null;

            }

        }
        /// <summary>
        /// 通过id获取组织信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrgModel getOrgModelById(string id)
        {
            using (SqlSugarClient db = BaseDB.GetClient())
            {
                List<OrgModel> res = db.Queryable<Organization, OrganizationOrg>((o, oo) => new object[] {
                    JoinType.Left,o.id==oo.orgid})
                     .Where((o, oo) => o.id == id)
                     .Select((o, oo) => new OrgModel
                     {
                         organization = o,
                         parentOrgId = oo.parentorgid
                     }).ToList();

                if (res.Count > 0)
                {
                    return res[0];
                }
                else
                    return null;

            }
        }

        /// <summary>
        /// 通过父级id获取子集组织
        /// </summary>
        /// <param name="parentid">父级子集ID</param>
        /// <returns></returns>
        public List<OrgModel> GetOrgModels(string parentid)
        {
            //存在的时候 
            using (SqlSugarClient db = BaseDB.GetClient())
            {
                //当parentid为空的时候 获取根组织
                if (string.IsNullOrEmpty(parentid))
                {
                    List<OrgModel> res = db.Queryable<Organization>()
                        .Where(o => o.isroot == true)
                        .Select((o) => new OrgModel
                        {
                            organization = o,
                            parentOrgId = null
                        }).ToList();
                    if (res.Count > 0)
                    {
                        return res;
                    }
                    else
                        return null;
                }
                else
                {
                    List<OrgModel> res = db.Queryable<Organization, OrganizationOrg>((o, oo) => new object[] {
                    JoinType.Left,o.id==oo.orgid})
                        .Where((o, oo) => oo.parentorgid == parentid)
                        .Select((o, oo) => new OrgModel
                        {
                            organization = o,
                            parentOrgId = oo.parentorgid
                        }).ToList();

                    if (res.Count > 0)
                    {
                        return res;
                    }
                    else
                        return null;
                }


            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public TableModel<Organization> getPageList(int pageIndex, int pageSize)
        {
            PageModel page = new PageModel { PageSize = pageSize, PageIndex = pageIndex };
            Expression<Func<Organization, bool>> ex = (it => 1 == 1);
            List<Organization> Organizations = Client.GetPageList(ex, page);
            TableModel<Organization> r = new TableModel<Organization>();
            r.Code = 0;
            r.Count = page.PageCount;
            r.Data = Organizations;
            r.Msg = "成功";
            return r;
        }

        public bool update(Organization et)
        {
            return Client.AsUpdateable(et).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 更新组织信息
        /// </summary>
        /// <param name="orgModel"></param>
        /// <returns></returns>
        public bool update(OrgModel orgModel)
        {
            using (SqlSugarClient db = BaseDB.GetClient())
            {
                try
                {
                    //db.BeginTran();//开启事务
                    //特别说明：在事务中，默认情况下是使用锁的，也就是说在当前事务没有结束前，其他的任何查询都需要等待
                    //ReadCommitted：在正在读取数据时保持共享锁，以避免脏读，但是在事务结束之前可以更改数据，从而导致不可重复的读取或幻像数据。
                    //db.BeginTran(System.Data.IsolationLevel.ReadCommitted); //重载指定事务的级别
                    db.BeginTran();//开始事物
                    db.Updateable<Organization>(orgModel.organization);

                    //组织关系表不会发生变化 不需要处理
                    //Dictionary<string, Object> updatec = new Dictionary<string, object>();
                    // updatec.Add("",)
                    // db.Updateable<OrganizationOrg>(updatec).Where(org=>org.orgid == orgModel.parentOrgId);
                    db.CommitTran();//提交事务
                    return true;
                }
                catch (Exception ex)
                {
                    db.RollbackTran();//回滚
                    return false;
                }
            }
        }
    }
}
