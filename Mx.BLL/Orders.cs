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
	///联盟订单
	/// </summary>
	public class Orders
    {
		private readonly DAL.Orders dal = new DAL.Orders();
       
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Model.Orders GetModel(int ID)
        {
            return dal.GetModel(p => p.ID == ID);
        }
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public Model.Orders GetModel(Expression<Func<Model.Orders, bool>> whereLambda)
        {
            return dal.GetModel(whereLambda);
        }
        
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.Orders model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Model.Orders model)
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
        public List<Model.Orders> GetList<Tkey>(int pageIndex, int pageSize, ref int total, Expression<Func<Model.Orders, bool>> whereLambda, Expression<Func<Model.Orders, Tkey>> orderLambda, bool isASC = true)
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
        public List<Model.Orders> GetList<Tkey>(int pageIndex, int pageSize, ref int total, OrdersCondition con, Expression<Func<Model.Orders, Tkey>> orderLambda, bool isASC = true)
        {
            Expression<Func<Model.Orders, bool>> whereLambda = Where(con);
            return dal.GetPagedList(pageIndex, pageSize, ref total, whereLambda, orderLambda, isASC);
        }
        
        protected Expression<Func<Model.Orders, bool>> Where(OrdersCondition con)
        {
            var searchPredicate = PredicateBuilder.True<Model.Orders>();
            if (con.isstat)
            {
                DateTime dt = DateTime.Parse("2020-07-01");
                searchPredicate = searchPredicate.And(m => m.CreateTime >= dt);
            }
            if (!string.IsNullOrEmpty(con.setName))
            {
                searchPredicate = searchPredicate.And(m => m.SetName == con.setName);
            }
            if (!string.IsNullOrEmpty(con.AdId))
            {
                searchPredicate = searchPredicate.And(m => m.AdID == con.AdId);
            }
            if (con.statStartTime.HasValue)
            {
                searchPredicate = searchPredicate.And(m => m.CreateTime >= con.statStartTime);
            }
            if (con.statEndTime.HasValue)
            {
                searchPredicate = searchPredicate.And(m => m.CreateTime <= con.statEndTime);
            }

            if (!string.IsNullOrEmpty(con.orderStatus))
            {
                searchPredicate = searchPredicate.And(m => m.OrderStatus == con.orderStatus);
            }            
            if (!string.IsNullOrEmpty(con.KeyWords))
            {
                searchPredicate = searchPredicate.And(m => m.ProductID.Contains(con.KeyWords) 
                    || m.ProductName.Contains(con.KeyWords));                
            }
            if (!string.IsNullOrEmpty(con.dateTime))
            {
                if (con.dateTime == "创建时间")
                {
                    if (con.startTime.HasValue)
                    {
                        searchPredicate = searchPredicate.And(m => m.CreateTime >= con.startTime);
                    }
                    if (con.endTime.HasValue)
                    {
                        searchPredicate = searchPredicate.And(m => m.CreateTime <= con.endTime);
                    }
                }
                else if (con.dateTime == "结算时间")
                {
                    if (con.startTime.HasValue)
                    {
                        searchPredicate = searchPredicate.And(m => m.SettlementTime >= con.startTime);
                    }
                    if (con.endTime.HasValue)
                    {
                        searchPredicate = searchPredicate.And(m => m.SettlementTime <= con.endTime);
                    }
                }                
            }
            if (!string.IsNullOrEmpty(con.realshouru))
            {
                if (con.realshouru == "1")
                {
                    searchPredicate = searchPredicate.And(m => m.realshouru>0 || m.realshouru==null);
                }
                else
                {
                    searchPredicate = searchPredicate.And(m => m.realshouru <= 0);
                }
            }


            return searchPredicate;
        }
         
    }
}
