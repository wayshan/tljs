using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Mx.Model;

namespace Mx.DAL
{
    public class Admin : BaseDAL<Model.Admin>
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        public AdminInfo AdminLogin(string userName, string userPwd)
        {            
            var model = db.Admins.Where(p => p.UserName == userName && p.UserPwd == userPwd).Select(p => new AdminInfo { 
                ID =p.ID,
                UserName =p.UserName,
                UserPwd =p.UserPwd,
                UserType= p.UserType,
                AddTime =p.AddTime.Value,
                Enabled=p.Enabled.Value,
                Remark = p.Remark,
                TbAccount = p.TbAccount
            }).FirstOrDefault();           
            return model;
        }
    }
}
