using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mx.Model
{
    public class AdminInfo
    {
        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        /// <summary>
        /// ID
        /// </summary>	
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 帐号
        /// </summary>		
        private string _username;
        /// <summary>
        /// 帐号
        /// </summary>	
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>		
        private string _userpwd;
        /// <summary>
        /// 密码
        /// </summary>	
        public string UserPwd
        {
            get { return _userpwd; }
            set { _userpwd = value; }
        }
        /// <summary>
        /// 管理员类型：管理员
        /// </summary>		
        private string _usertype;
        /// <summary>
        /// 管理员类型：管理员
        /// </summary>	
        public string UserType
        {
            get { return _usertype; }
            set { _usertype = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>		
        private string _remark;
        /// <summary>
        /// 备注
        /// </summary>	
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>		
        private DateTime _addtime;
        /// <summary>
        /// 添加时间
        /// </summary>	
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// 是否启用
        /// </summary>		
        private bool _enabled;
        /// <summary>
        /// 是否启用
        /// </summary>	
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

    }
}
