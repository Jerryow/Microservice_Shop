using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDentist.Common
{
    public class CommonEnums
    {
        #region 枚举值转义

        ///// <summary>
        ///// 任务属性，枚举类型转换
        ///// </summary>
        ///// <param name="taskAttribute">任务属性值</param>
        ///// <returns></returns>
        //public static string ConvertTaskAttribute(int? taskAttribute)
        //{
        //    if (taskAttribute == null)
        //        return "-";

        //    // 值转枚举 
        //    TaskAttribute entityEnum = (TaskAttribute)taskAttribute;

        //    string enumName = Enum.GetName(typeof(TaskAttribute), entityEnum);

        //    return enumName;
        //}

        ///// <summary>
        ///// 任务状态，枚举类型转换
        ///// </summary>
        ///// <param name="taskStatus">任务状态值</param>
        ///// <returns></returns>
        //public static string ConvertTaskStatus(int? taskStatus)
        //{
        //    if (taskStatus == null)
        //        return "-";

        //    // 值转枚举 
        //    TaskStatus entityEnum = (TaskStatus)taskStatus;

        //    string enumName = Enum.GetName(typeof(TaskStatus), entityEnum);

        //    return enumName;
        //}

        ///// <summary>
        ///// 用户类型，枚举类型转换
        ///// </summary>
        ///// <param name="memberTypeID">任务状态值</param>
        ///// <returns></returns>
        //public static string ConvertMemberTypeID(int? memberTypeID)
        //{
        //    if (memberTypeID == null)
        //        return "-";

        //    // 值转枚举 
        //    MemberTypeID entityEnum = (MemberTypeID)memberTypeID;

        //    string enumName = Enum.GetName(typeof(MemberTypeID), entityEnum);

        //    return enumName;
        //}


        ///// <summary>
        ///// 帮费类型，枚举类型转换
        ///// </summary>
        ///// <param name="type">类型值</param>
        ///// <returns></returns>
        //public static string ConvertExpensesType(int? type)
        //{
        //    if (type == null)
        //        return "-";

        //    // 值转枚举 
        //    ExpensesType entityEnum = (ExpensesType)type;

        //    string enumName = Enum.GetName(typeof(ExpensesType), entityEnum);

        //    return enumName;
        //}

        ///// <summary>
        ///// 日期类型：枚举类型转换
        ///// </summary>
        ///// <param name="dateUnit">类型值</param>
        ///// <returns></returns>
        //public static string ConvertDateUnit(int? dateUnit)
        //{

        //    if (dateUnit == null)
        //        return "-";

        //    // 值转枚举 
        //    DateUnit entityEnum = (DateUnit)dateUnit;

        //    string enumName = Enum.GetName(typeof(DateUnit), entityEnum);

        //    return enumName;
        //}

        #endregion

        #region 枚举

        /// <summary>
        /// 数据格式枚举
        /// </summary>
        public enum EnumFormat
        {
            /// <summary>
            /// json数据格式
            /// </summary>
            Json,
            /// <summary>
            /// xml数据格式
            /// </summary>
            Xml
        }


        /// <summary>
        /// 数据有效性枚举
        /// </summary>
        public enum EnumValid
        {
            True = 1,
            False = 0
        }

        /// <summary>
        /// 性别枚举
        /// </summary>
        public enum EnumGender
        {
            未知 = 0,
            男 = 1,
            女 = 2

        }

        /// <summary>
        /// 是否
        /// </summary>
        public enum EnumYesOrNo
        {
            否 = 0,
            是 = 1
        }



        #endregion


        #region  自定义枚举

        #region  自定义枚举

        public enum VerifyType
        {
            短信 = 10,
            邮件 = 20
        }

        public enum OrderStatus
        {
            无效 = -100,
            有效期失效 = 20,
            当前状态已失效 = 10,
            待确认 = 100,
            待发货 = 200,
            已发货 = 210,
            已完成 = 600
        }

        public enum ClientType
        {
            小程序 = 10,
            商城后台 = 20,
            管理后台 = 30
        }

        public enum ImageType
        {
            所有 = 0,
            主图 = 100,
            细节图 = 200,
            幻灯片 = 300,//用于产品详情
            Banner = 400//用于首页
        }

        public enum PriceType
        {
            默认售价 = 100,
            指定售价 = 200,
            市场价 = 900,
            成本价 = 1000,
            积分默认 = 10,
            积分指定 = 20,
            所有 = 0
        }

        public enum CartType
        {
            常规 = 100,
            积分 = 200
        }

        public enum BonusType
        {
            可用积分 = 100,
            冻结积分 = 200
        }

        public enum BonusFollowType
        {
            购买商品赠送 = 100,
            支付购买冻结 = 200,
            积分购买冻结 = 300,
            兑换扣除 = 400,
            医生赠送 = 500,
            转发文章赠送 = 600
        }

        public enum OrderType
        {
            现金 = 100,
            积分 = 200
        }

        public enum ProductType
        {
            现金 = 100,
            积分 = 200
        }

        public enum OrderDeliveryType
        {
            快递 = 100,
            自提 = 200,
            无需配送 = 900
        }

        public enum ProductStockType
        {
            所有 = 0,
            总库存 = 100,
            可售库存 = 200,
            冻结库存 = 300,
            自定义库存 = 500
        }

        public enum ShopImgType
        {
            配置图片 = 1,
            海报 = 100,
            个人名片 = 200
        }

        public enum FeedbackType
        {
            所有 = 10,
            意见和建议 = 100,
            问题 = 200,
            咨询 = 300
        }

        public enum FeedbackStatus
        {
            所有 = 10,
            待受理 = 100,
            受理中 = 200,
            完成 = 300
        }

        public enum ReflectType
        {
            Token_Info_Agent,
            Weixin_Info_Agent,
            Bonus_Flow_Agent,
            Bonus_Flow_Relation_Agent,
            Bonus_Main_Agent,
            Delivery_Address_Agent,
            Follow_Product_Agent,
            Product_Collect_Agent,
            User_Detail_Agent,
            User_Main_Agent,
            User_Verify_Agent,
            User_Weixin_Agent,
            Default_Config_Agent,
            System_Config_Agent,
            System_User_Agent,
            Shop_Config_Agent,
            Shop_Content_Agent,
            Shop_Main_Agent,
            Shop_Status_Agent,
            Shop_User_Agent,
            Category_Image_Agent,
            Category_Main_Agent,
            Product_Category_Agent,
            Product_Comment_Agent,
            Product_Content_Agent,
            Product_Image_Agent,
            Product_Main_Agent,
            Product_Price_Agent,
            Product_Stock_Agent,
            Order_Delivery_Agent,
            Order_Item_Agent,
            Order_Main_Agent,
            Order_Return_Agent,
            Order_Return_Detail_Agent,
            Order_Status_Agent,
            Cart_Item_Agent,
            Cart_Main_Agent,
            External_Api_Agent,
            External_Log_Agent,
            Internal_Api_Agent,
            Internal_Log_Agent,
            Account_Bind_Agent,
            Account_Main_Agent,
            Account_Status_Agent,
            Account_Verify_Agent
        }

        #endregion



        public static string PrintOrderStatus(int status)
        {
            string tmp = string.Empty;

            switch (status)
            {
                case -100:
                    tmp = "订单无效";
                    break;
                case 100:
                    tmp = "待确认";
                    break;
                case 200:
                    tmp = "待发货";
                    break;
                case 210:
                    tmp = "已发货";
                    break;
                case 600:
                    tmp = "已完成";
                    break;
                default:
                    tmp = "待定";
                    break;
            }
            return tmp;
        }

        public static string PrintBonusFollowType(int type)
        {
            var tmp = string.Empty;
            switch (type)
            {
                case 100:
                    tmp = "购买商品赠送";
                    break;
                case 200:
                    tmp = "冻结积分";
                    break;
                case 300:
                    tmp = "积分购买冻结";
                    break;
                case 400:
                    tmp = "兑换扣除";
                    break;
                case 500:
                    tmp = "医生赠送";
                    break;
                case 600:
                    tmp = "转发文章赠送";
                    break;
                default:
                    tmp = "待定";
                    break;
            }
            return tmp;
        }
    }

    #endregion

}

