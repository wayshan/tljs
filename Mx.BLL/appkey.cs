using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Linq.Expressions;
using Mx.Model;
using Mx.Common;

namespace Mx.BLL
{
	/// <summary>
	///
	/// </summary>
    public class appkey
    {
        private readonly DAL.appkey dal = new DAL.appkey();
       
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Model.appkey GetModel(int ID)
        {
            return dal.GetModel(p => p.ID == ID);
        }
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public Model.appkey GetModel(Expression<Func<Model.appkey, bool>> whereLambda)
        {
            return dal.GetModel(whereLambda);
        }
        
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.appkey model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Model.appkey model)
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
        public List<Model.appkey> GetList<Tkey>(int pageIndex, int pageSize, ref int total, Expression<Func<Model.appkey, bool>> whereLambda, Expression<Func<Model.appkey, Tkey>> orderLambda, bool isASC = true)
        {
            return dal.GetPagedList(pageIndex, pageSize, ref total, whereLambda, orderLambda, isASC);
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
        public List<Model.appkey> GetList<Tkey>(int pageIndex, int pageSize, ref int total, appkeyCondition con, Expression<Func<Model.appkey, Tkey>> orderLambda, bool isASC = true)
        {
            Expression<Func<Model.appkey, bool>> whereLambda = Where(con);
            return dal.GetPagedList(pageIndex, pageSize, ref total, whereLambda, orderLambda, isASC);
        }

        /// <summary>
        /// 删除一个对象实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Delete(int ID)
        {
            return dal.DelBy(p => p.ID == ID);
        }


        protected Expression<Func<Model.appkey, bool>> Where(appkeyCondition con)
        {
            var searchPredicate = PredicateBuilder.True<Model.appkey>();

            return searchPredicate;
        }
         
    }
}
