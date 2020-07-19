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
	///淘礼金
	/// </summary>
    public class TljInfo
    {
        private readonly DAL.TljInfo dal = new DAL.TljInfo();

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Model.TljInfo GetModel(int ID)
        {
            return dal.GetModel(p => p.ID == ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public Model.TljInfo GetModel(Expression<Func<Model.TljInfo, bool>> whereLambda)
        {
            return dal.GetModel(whereLambda);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.TljInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Model.TljInfo model)
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
        public List<Model.TljInfo> GetList<Tkey>(int pageIndex, int pageSize, ref int total, Expression<Func<Model.TljInfo, bool>> whereLambda, Expression<Func<Model.TljInfo, Tkey>> orderLambda, bool isASC = true)
        {
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
        public List<Model.TljInfo> GetList<Tkey>(int pageIndex, int pageSize, ref int total, TljInfoCondition con, Expression<Func<Model.TljInfo, Tkey>> orderLambda, bool isASC = true)
        {
            Expression<Func<Model.TljInfo, bool>> whereLambda = Where(con);
            return dal.GetPagedList(pageIndex, pageSize, ref total, whereLambda, orderLambda, isASC);
        }

        protected Expression<Func<Model.TljInfo, bool>> Where(TljInfoCondition con)
        {
            var searchPredicate = PredicateBuilder.True<Model.TljInfo>();
            if (!string.IsNullOrEmpty(con.KeyWords))
            searchPredicate = searchPredicate.And(m => m.goodsname.Contains(con.KeyWords));
            if (!string.IsNullOrEmpty(con.KeyWords))
            searchPredicate = searchPredicate.Or(m => m.item_id.Contains(con.KeyWords));

            if (con.isstat)
            {
                searchPredicate = searchPredicate.And(m => m.dotime.HasValue == true);
            }
            if (con.statStartTime.HasValue)
            {
                searchPredicate = searchPredicate.And(m => m.dotime >= con.statStartTime);
            }
            if (con.statEndTime.HasValue)
            {
                searchPredicate = searchPredicate.And(m => m.dotime <= con.statEndTime);
            }

            if (con.startTime.HasValue)
            {
                searchPredicate = searchPredicate.And(m=>m.send_start_time>=con.startTime);
            }
            if (con.endTime.HasValue)
            {
                searchPredicate = searchPredicate.And(m => m.send_end_time <= con.endTime);
            }
            if (con.ifget.HasValue)
            {
                searchPredicate = searchPredicate.And(m => m.ifget == con.ifget);
            }
            if (!string.IsNullOrEmpty(con.Ifok))
            {
                searchPredicate = searchPredicate.And(m => m.ifok == con.Ifok);
            }
            if (!string.IsNullOrEmpty(con.Ifsingle))
            {
                searchPredicate = searchPredicate.And(m => con.Ifsingle == "1" ? m.total_num != 1 : m.total_num == 1);
               
            }
            return searchPredicate;
        }
         
    }
}
