using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Mx.BLL
{
    /// <summary>
    /// 业务层 父类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseBLL<T> where T : class,new()
    {
        protected DAL.BaseDAL<T> dal = new DAL.BaseDAL<T>();

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public T GetModel(Expression<Func<T, bool>> whereLambda)
        {
            return dal.GetModel(whereLambda);
        }
        
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(T model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(T model)
        {
            return dal.Modify(model);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="Tkey">类型</typeparam>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页数量</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <param name="total">总记录数量</param>
        /// <returns></returns>
        public List<T> GetList<Tkey>(int pageIndex, int pageSize, ref int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, Tkey>> orderLambda, bool isASC = true)
        {
            return dal.GetPagedList(pageIndex, pageSize, ref total, whereLambda, orderLambda, isASC);
        }
    }
}
