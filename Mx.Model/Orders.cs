using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Mx.Model
{
    //联盟订单
    public class Orders
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
        /// 创建时间
        /// </summary>		
        private DateTime _createtime;
        /// <summary>
        /// 创建时间
        /// </summary>	
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// 点击时间
        /// </summary>		
        private DateTime _clicktime;
        /// <summary>
        /// 点击时间
        /// </summary>	
        public DateTime ClickTime
        {
            get { return _clicktime; }
            set { _clicktime = value; }
        }
        /// <summary>
        /// 商品信息
        /// </summary>		
        private string _productname;
        /// <summary>
        /// 商品信息
        /// </summary>	
        public string ProductName
        {
            get { return _productname; }
            set { _productname = value; }
        }
        /// <summary>
        /// 商品ID
        /// </summary>		
        private string _productid;
        /// <summary>
        /// 商品ID
        /// </summary>	
        public string ProductID
        {
            get { return _productid; }
            set { _productid = value; }
        }
        /// <summary>
        /// 所属店铺
        /// </summary>		
        private string _ownedshop;
        /// <summary>
        /// 所属店铺
        /// </summary>	
        public string OwnedShop
        {
            get { return _ownedshop; }
            set { _ownedshop = value; }
        }
        /// <summary>
        /// 商品数
        /// </summary>		
        private int _productcount;
        /// <summary>
        /// 商品数
        /// </summary>	
        public int ProductCount
        {
            get { return _productcount; }
            set { _productcount = value; }
        }
        /// <summary>
        /// 商品单价
        /// </summary>		
        private decimal _prounitprice;
        /// <summary>
        /// 商品单价
        /// </summary>	
        public decimal ProUnitPrice
        {
            get { return _prounitprice; }
            set { _prounitprice = value; }
        }
        /// <summary>
        /// 订单状态【订单付款、订单失效、订单结算】
        /// </summary>		
        private string _orderstatus;
        /// <summary>
        /// 订单状态【订单付款、订单失效、订单结算】
        /// </summary>	
        public string OrderStatus
        {
            get { return _orderstatus; }
            set { _orderstatus = value; }
        }
        /// <summary>
        /// 订单类型
        /// </summary>		
        private string _ordertype;
        /// <summary>
        /// 订单类型
        /// </summary>	
        public string OrderType
        {
            get { return _ordertype; }
            set { _ordertype = value; }
        }
        /// <summary>
        /// 付款金额
        /// </summary>		
        private decimal _paymoney;
        /// <summary>
        /// 付款金额
        /// </summary>	
        public decimal PayMoney
        {
            get { return _paymoney; }
            set { _paymoney = value; }
        }
        /// <summary>
        /// 效果预估
        /// </summary>		
        private decimal _effect;
        /// <summary>
        /// 效果预估
        /// </summary>	
        public decimal Effect
        {
            get { return _effect; }
            set { _effect = value; }
        }
        /// <summary>
        /// 结算时间
        /// </summary>		
        private DateTime _settlementtime;
        /// <summary>
        /// 结算时间
        /// </summary>	
        public DateTime SettlementTime
        {
            get { return _settlementtime; }
            set { _settlementtime = value; }
        }
        /// <summary>
        /// 佣金比率
        /// </summary>		
        private decimal _commissionrate;
        /// <summary>
        /// 佣金比率
        /// </summary>	
        public decimal CommissionRate
        {
            get { return _commissionrate; }
            set { _commissionrate = value; }
        }
        /// <summary>
        /// 佣金金额
        /// </summary>		
        private decimal _commissionmoney;
        /// <summary>
        /// 佣金金额
        /// </summary>	
        public decimal CommissionMoney
        {
            get { return _commissionmoney; }
            set { _commissionmoney = value; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>		
        private string _orderno;
        /// <summary>
        /// 订单编号
        /// </summary>	
        public string OrderNo
        {
            get { return _orderno; }
            set { _orderno = value; }
        }
        /// <summary>
        /// 来源媒体ID
        /// </summary>		
        private string _sourcemediaid;
        /// <summary>
        /// 来源媒体ID
        /// </summary>	
        public string SourceMediaID
        {
            get { return _sourcemediaid; }
            set { _sourcemediaid = value; }
        }
        /// <summary>
        /// 来源媒体名称
        /// </summary>		
        private string _sourcemedianame;
        /// <summary>
        /// 来源媒体名称
        /// </summary>	
        public string SourceMediaName
        {
            get { return _sourcemedianame; }
            set { _sourcemedianame = value; }
        }
        /// <summary>
        /// 广告位ID
        /// </summary>		
        private string _adid;
        /// <summary>
        /// 广告位ID
        /// </summary>	
        public string AdID
        {
            get { return _adid; }
            set { _adid = value; }
        }
        /// <summary>
        /// 广告位名称
        /// </summary>		
        private string _adname;
        /// <summary>
        /// 广告位名称
        /// </summary>	
        public string AdName
        {
            get { return _adname; }
            set { _adname = value; }
        }
        /// <summary>
        /// 本地结算状态【未结算、已结算】
        /// </summary>		
        private string _localsettlement;
        /// <summary>
        /// 本地结算状态【未结算、已结算】
        /// </summary>	
        public string LocalSettlement
        {
            get { return _localsettlement; }
            set { _localsettlement = value; }
        }
        /// <summary>
        /// 本地结算时间
        /// </summary>		
        private DateTime _localsettlementtime;
        /// <summary>
        /// 本地结算时间
        /// </summary>	
        public DateTime LocalSettlementTime
        {
            get { return _localsettlementtime; }
            set { _localsettlementtime = value; }
        }
        /// <summary>
        /// 账号明细ID
        /// </summary>		
        private int _accountid;
        /// <summary>
        /// 账号明细ID
        /// </summary>	
        public int AccountID
        {
            get { return _accountid; }
            set { _accountid = value; }
        }
        /// <summary>
        /// SetName
        /// </summary>		
        private string _setname;
        /// <summary>
        /// SetName
        /// </summary>	
        public string SetName
        {
            get { return _setname; }
            set { _setname = value; }
        }
        /// <summary>
        /// LockinTime
        /// </summary>		
        private string _lockintime;
        /// <summary>
        /// LockinTime
        /// </summary>	
        public string LockinTime
        {
            get { return _lockintime; }
            set { _lockintime = value; }
        }
        /// <summary>
        /// LastUpdatetime
        /// </summary>		
        private DateTime _lastupdatetime;
        /// <summary>
        /// LastUpdatetime
        /// </summary>	
        public DateTime LastUpdatetime
        {
            get { return _lastupdatetime; }
            set { _lastupdatetime = value; }
        }
        /// <summary>
        /// Robot_Uin
        /// </summary>		
        private string _robot_uin;
        /// <summary>
        /// Robot_Uin
        /// </summary>	
        public string Robot_Uin
        {
            get { return _robot_uin; }
            set { _robot_uin = value; }
        }
        /// <summary>
        /// Robot_Fid
        /// </summary>		
        private int _robot_fid;
        /// <summary>
        /// Robot_Fid
        /// </summary>	
        public int Robot_Fid
        {
            get { return _robot_fid; }
            set { _robot_fid = value; }
        }
        /// <summary>
        /// Robot_Fanlibili
        /// </summary>		
        private decimal _robot_fanlibili;
        /// <summary>
        /// Robot_Fanlibili
        /// </summary>	
        public decimal Robot_Fanlibili
        {
            get { return _robot_fanlibili; }
            set { _robot_fanlibili = value; }
        }
        /// <summary>
        /// Robot_Fanli
        /// </summary>		
        private decimal _robot_fanli;
        /// <summary>
        /// Robot_Fanli
        /// </summary>	
        public decimal Robot_Fanli
        {
            get { return _robot_fanli; }
            set { _robot_fanli = value; }
        }
        /// <summary>
        /// Robot_OwnShouRu
        /// </summary>		
        private decimal _robot_ownshouru;
        /// <summary>
        /// Robot_OwnShouRu
        /// </summary>	
        public decimal Robot_OwnShouRu
        {
            get { return _robot_ownshouru; }
            set { _robot_ownshouru = value; }
        }
        /// <summary>
        /// Robot_UpShouRu
        /// </summary>		
        private decimal _robot_upshouru;
        /// <summary>
        /// Robot_UpShouRu
        /// </summary>	
        public decimal Robot_UpShouRu
        {
            get { return _robot_upshouru; }
            set { _robot_upshouru = value; }
        }
        /// <summary>
        /// Robot_UpUpShouRu
        /// </summary>		
        private decimal _robot_upupshouru;
        /// <summary>
        /// Robot_UpUpShouRu
        /// </summary>	
        public decimal Robot_UpUpShouRu
        {
            get { return _robot_upupshouru; }
            set { _robot_upupshouru = value; }
        }
        /// <summary>
        /// Robot_IsComp
        /// </summary>		
        private int _robot_iscomp;
        /// <summary>
        /// Robot_IsComp
        /// </summary>	
        public int Robot_IsComp
        {
            get { return _robot_iscomp; }
            set { _robot_iscomp = value; }
        }
        /// <summary>
        /// Robot_Comptime
        /// </summary>		
        private DateTime _robot_comptime;
        /// <summary>
        /// Robot_Comptime
        /// </summary>	
        public DateTime Robot_Comptime
        {
            get { return _robot_comptime; }
            set { _robot_comptime = value; }
        }
        /// <summary>
        /// Robot_Fid_Time
        /// </summary>		
        private DateTime _robot_fid_time;
        /// <summary>
        /// Robot_Fid_Time
        /// </summary>	
        public DateTime Robot_Fid_Time
        {
            get { return _robot_fid_time; }
            set { _robot_fid_time = value; }
        }
        /// <summary>
        /// iflinshi
        /// </summary>		
        private int _iflinshi;
        /// <summary>
        /// iflinshi
        /// </summary>	
        public int iflinshi
        {
            get { return _iflinshi; }
            set { _iflinshi = value; }
        }
        /// <summary>
        /// OrderNo_trade_id
        /// </summary>		
        private string _orderno_trade_id;
        /// <summary>
        /// OrderNo_trade_id
        /// </summary>	
        public string OrderNo_trade_id
        {
            get { return _orderno_trade_id; }
            set { _orderno_trade_id = value; }
        }
        /// <summary>
        /// ifapi333
        /// </summary>		
        private int _ifapi333;
        /// <summary>
        /// ifapi333
        /// </summary>	
        public int ifapi333
        {
            get { return _ifapi333; }
            set { _ifapi333 = value; }
        }
        /// <summary>
        /// ifapi
        /// </summary>		
        private DateTime _ifapi;
        /// <summary>
        /// ifapi
        /// </summary>	
        public DateTime ifapi
        {
            get { return _ifapi; }
            set { _ifapi = value; }
        }
        /// <summary>
        /// ifweiqun
        /// </summary>		
        private int _ifweiqun;
        /// <summary>
        /// ifweiqun
        /// </summary>	
        public int ifweiqun
        {
            get { return _ifweiqun; }
            set { _ifweiqun = value; }
        }
        /// <summary>
        /// LUin
        /// </summary>		
        private string _luin;
        /// <summary>
        /// LUin
        /// </summary>	
        public string LUin
        {
            get { return _luin; }
            set { _luin = value; }
        }
        /// <summary>
        /// linshichuli
        /// </summary>		
        private int _linshichuli;
        /// <summary>
        /// linshichuli
        /// </summary>	
        public int linshichuli
        {
            get { return _linshichuli; }
            set { _linshichuli = value; }
        }
        /// <summary>
        /// tk_order_role
        /// </summary>		
        private string _tk_order_role;
        /// <summary>
        /// tk_order_role
        /// </summary>	
        public string tk_order_role
        {
            get { return _tk_order_role; }
            set { _tk_order_role = value; }
        }
        /// <summary>
        /// tb_paid_time
        /// </summary>		
        private string _tb_paid_time;
        /// <summary>
        /// tb_paid_time
        /// </summary>	
        public string tb_paid_time
        {
            get { return _tb_paid_time; }
            set { _tb_paid_time = value; }
        }
        /// <summary>
        /// tk_paid_time
        /// </summary>		
        private string _tk_paid_time;
        /// <summary>
        /// tk_paid_time
        /// </summary>	
        public string tk_paid_time
        {
            get { return _tk_paid_time; }
            set { _tk_paid_time = value; }
        }
        /// <summary>
        /// needchuli
        /// </summary>		
        private int _needchuli;
        /// <summary>
        /// needchuli
        /// </summary>	
        public int needchuli
        {
            get { return _needchuli; }
            set { _needchuli = value; }
        }
        /// <summary>
        /// Robot_OwnShouRu_new
        /// </summary>		
        private decimal _robot_ownshouru_new;
        /// <summary>
        /// Robot_OwnShouRu_new
        /// </summary>	
        public decimal Robot_OwnShouRu_new
        {
            get { return _robot_ownshouru_new; }
            set { _robot_ownshouru_new = value; }
        }
        /// <summary>
        /// iflijingcheck
        /// </summary>		
        private int _iflijingcheck;
        /// <summary>
        /// iflijingcheck
        /// </summary>	
        public int iflijingcheck
        {
            get { return _iflijingcheck; }
            set { _iflijingcheck = value; }
        }
        /// <summary>
        /// lijin
        /// </summary>		
        private decimal _lijin;
        /// <summary>
        /// lijin
        /// </summary>	
        public decimal lijin
        {
            get { return _lijin; }
            set { _lijin = value; }
        }
        /// <summary>
        /// realshouru
        /// </summary>		
        private decimal _realshouru;
        /// <summary>
        /// realshouru
        /// </summary>	
        public decimal realshouru
        {
            get { return _realshouru; }
            set { _realshouru = value; }
        }
        /// <summary>
        /// pic
        /// </summary>		
        private string _pic;
        /// <summary>
        /// pic
        /// </summary>	
        public string pic
        {
            get { return _pic; }
            set { _pic = value; }
        }

    }
}