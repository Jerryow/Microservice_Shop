using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDentist.Common
{
    public class CommonEnums
    {
        #region ö��ֵת��

        ///// <summary>
        ///// �������ԣ�ö������ת��
        ///// </summary>
        ///// <param name="taskAttribute">��������ֵ</param>
        ///// <returns></returns>
        //public static string ConvertTaskAttribute(int? taskAttribute)
        //{
        //    if (taskAttribute == null)
        //        return "-";

        //    // ֵתö�� 
        //    TaskAttribute entityEnum = (TaskAttribute)taskAttribute;

        //    string enumName = Enum.GetName(typeof(TaskAttribute), entityEnum);

        //    return enumName;
        //}

        ///// <summary>
        ///// ����״̬��ö������ת��
        ///// </summary>
        ///// <param name="taskStatus">����״ֵ̬</param>
        ///// <returns></returns>
        //public static string ConvertTaskStatus(int? taskStatus)
        //{
        //    if (taskStatus == null)
        //        return "-";

        //    // ֵתö�� 
        //    TaskStatus entityEnum = (TaskStatus)taskStatus;

        //    string enumName = Enum.GetName(typeof(TaskStatus), entityEnum);

        //    return enumName;
        //}

        ///// <summary>
        ///// �û����ͣ�ö������ת��
        ///// </summary>
        ///// <param name="memberTypeID">����״ֵ̬</param>
        ///// <returns></returns>
        //public static string ConvertMemberTypeID(int? memberTypeID)
        //{
        //    if (memberTypeID == null)
        //        return "-";

        //    // ֵתö�� 
        //    MemberTypeID entityEnum = (MemberTypeID)memberTypeID;

        //    string enumName = Enum.GetName(typeof(MemberTypeID), entityEnum);

        //    return enumName;
        //}


        ///// <summary>
        ///// ������ͣ�ö������ת��
        ///// </summary>
        ///// <param name="type">����ֵ</param>
        ///// <returns></returns>
        //public static string ConvertExpensesType(int? type)
        //{
        //    if (type == null)
        //        return "-";

        //    // ֵתö�� 
        //    ExpensesType entityEnum = (ExpensesType)type;

        //    string enumName = Enum.GetName(typeof(ExpensesType), entityEnum);

        //    return enumName;
        //}

        ///// <summary>
        ///// �������ͣ�ö������ת��
        ///// </summary>
        ///// <param name="dateUnit">����ֵ</param>
        ///// <returns></returns>
        //public static string ConvertDateUnit(int? dateUnit)
        //{

        //    if (dateUnit == null)
        //        return "-";

        //    // ֵתö�� 
        //    DateUnit entityEnum = (DateUnit)dateUnit;

        //    string enumName = Enum.GetName(typeof(DateUnit), entityEnum);

        //    return enumName;
        //}

        #endregion

        #region ö��

        /// <summary>
        /// ���ݸ�ʽö��
        /// </summary>
        public enum EnumFormat
        {
            /// <summary>
            /// json���ݸ�ʽ
            /// </summary>
            Json,
            /// <summary>
            /// xml���ݸ�ʽ
            /// </summary>
            Xml
        }


        /// <summary>
        /// ������Ч��ö��
        /// </summary>
        public enum EnumValid
        {
            True = 1,
            False = 0
        }

        /// <summary>
        /// �Ա�ö��
        /// </summary>
        public enum EnumGender
        {
            δ֪ = 0,
            �� = 1,
            Ů = 2

        }

        /// <summary>
        /// �Ƿ�
        /// </summary>
        public enum EnumYesOrNo
        {
            �� = 0,
            �� = 1
        }



        #endregion


        #region  �Զ���ö��

        #region  �Զ���ö��

        public enum VerifyType
        {
            ���� = 10,
            �ʼ� = 20
        }

        public enum OrderStatus
        {
            ��Ч = -100,
            ��Ч��ʧЧ = 20,
            ��ǰ״̬��ʧЧ = 10,
            ��ȷ�� = 100,
            ������ = 200,
            �ѷ��� = 210,
            ����� = 600
        }

        public enum ClientType
        {
            С���� = 10,
            �̳Ǻ�̨ = 20,
            �����̨ = 30
        }

        public enum ImageType
        {
            ���� = 0,
            ��ͼ = 100,
            ϸ��ͼ = 200,
            �õ�Ƭ = 300,//���ڲ�Ʒ����
            Banner = 400//������ҳ
        }

        public enum PriceType
        {
            Ĭ���ۼ� = 100,
            ָ���ۼ� = 200,
            �г��� = 900,
            �ɱ��� = 1000,
            ����Ĭ�� = 10,
            ����ָ�� = 20,
            ���� = 0
        }

        public enum CartType
        {
            ���� = 100,
            ���� = 200
        }

        public enum BonusType
        {
            ���û��� = 100,
            ������� = 200
        }

        public enum BonusFollowType
        {
            ������Ʒ���� = 100,
            ֧�����򶳽� = 200,
            ���ֹ��򶳽� = 300,
            �һ��۳� = 400,
            ҽ������ = 500,
            ת���������� = 600
        }

        public enum OrderType
        {
            �ֽ� = 100,
            ���� = 200
        }

        public enum ProductType
        {
            �ֽ� = 100,
            ���� = 200
        }

        public enum OrderDeliveryType
        {
            ��� = 100,
            ���� = 200,
            �������� = 900
        }

        public enum ProductStockType
        {
            ���� = 0,
            �ܿ�� = 100,
            ���ۿ�� = 200,
            ������ = 300,
            �Զ����� = 500
        }

        public enum ShopImgType
        {
            ����ͼƬ = 1,
            ���� = 100,
            ������Ƭ = 200
        }

        public enum FeedbackType
        {
            ���� = 10,
            ����ͽ��� = 100,
            ���� = 200,
            ��ѯ = 300
        }

        public enum FeedbackStatus
        {
            ���� = 10,
            ������ = 100,
            ������ = 200,
            ��� = 300
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
                    tmp = "������Ч";
                    break;
                case 100:
                    tmp = "��ȷ��";
                    break;
                case 200:
                    tmp = "������";
                    break;
                case 210:
                    tmp = "�ѷ���";
                    break;
                case 600:
                    tmp = "�����";
                    break;
                default:
                    tmp = "����";
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
                    tmp = "������Ʒ����";
                    break;
                case 200:
                    tmp = "�������";
                    break;
                case 300:
                    tmp = "���ֹ��򶳽�";
                    break;
                case 400:
                    tmp = "�һ��۳�";
                    break;
                case 500:
                    tmp = "ҽ������";
                    break;
                case 600:
                    tmp = "ת����������";
                    break;
                default:
                    tmp = "����";
                    break;
            }
            return tmp;
        }
    }

    #endregion

}

