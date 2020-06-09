using FPLDQ.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPLDQ.IService
{
    /// <summary>
    /// 基本接口类
    /// </summary>
    public interface IbaseService<T> 
    {

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        TableModel<T> getPageList(int pageIndex, int pageSize);

        /// <summary>
        /// 通过id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T get(long id);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="et"></param>
        /// <returns></returns>
        bool update(T et);

        /// <summary>
        /// 通过id 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool delete(long id);

        /// <summary>
        /// 增加实体
        /// </summary>
        /// <param name="et"></param>
        /// <returns></returns>
        bool add(T et);

    }
}
