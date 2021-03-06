﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Mx.Model;
using Mx.Common;

namespace Mx.BLL
{
    /// <summary>
    ///collectgoods
    /// </summary>
    public class collectgoods
    {
        private readonly DAL.collectgoods dal = new DAL.collectgoods();

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.collectgoods GetModel(int id)
        {
            return dal.GetModel(p => p.id == id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public Model.collectgoods GetModel(Expression<Func<Model.collectgoods, bool>> whereLambda)
        {
            return dal.GetModel(whereLambda);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.collectgoods model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Model.collectgoods model)
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
        public List<Model.collectgoods> GetList<Tkey>(int pageIndex, int pageSize, ref int total, Expression<Func<Model.collectgoods, bool>> whereLambda, Expression<Func<Model.collectgoods, Tkey>> orderLambda, bool isASC = true)
        {
            return dal.GetPagedList(pageIndex, pageSize, ref total, whereLambda, orderLambda, isASC);
        }

        /// <summary>
        /// 删除一个对象实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            return dal.DelBy(p => p.id == id);
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
        public List<Model.collectgoods> GetList<Tkey>(int pageIndex, int pageSize, ref int total, collectgoodsCondition con, Expression<Func<Model.collectgoods, Tkey>> orderLambda, bool isASC = true)
        {
            Expression<Func<Model.collectgoods, bool>> whereLambda = Where(con);
            return dal.GetPagedList(pageIndex, pageSize, ref total, whereLambda, orderLambda, isASC);
        }

        protected Expression<Func<Model.collectgoods, bool>> Where(collectgoodsCondition con)
        {
            var searchPredicate = PredicateBuilder.True<Model.collectgoods>();
            if (!string.IsNullOrEmpty(con.goodsname))
            {
                searchPredicate = searchPredicate.And(m => m.goodsname.Contains(con.goodsname));
            }
            if (!string.IsNullOrEmpty(con.shopname))
            {
                searchPredicate = searchPredicate.And(m => m.shopname.Contains(con.shopname));
            }
            if (!string.IsNullOrEmpty(con.ifok))
            {
                searchPredicate = searchPredicate.And(m => m.ifok == con.ifok);
            }
            if (!string.IsNullOrEmpty(con.qudao))
            {
                searchPredicate = searchPredicate.And(m => m.qudao.Contains(con.qudao));
            }
            if (!string.IsNullOrEmpty(con.totalNum))
            {
                searchPredicate = searchPredicate.And(m => con.totalNum == "1" ? m.totalNum >= 10 : m.totalNum < 10);
            }
            if (!string.IsNullOrEmpty(con.type))
            {
                searchPredicate = searchPredicate.And(m => con.type == "1" ? m.perFace > 0 : m.totalNum <= 0);
            }
            
            return searchPredicate;
        }

    }
}
