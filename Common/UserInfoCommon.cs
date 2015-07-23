using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UserInfoCommon
    {
        public static List<string> UserInfoList(string userInfo)
        {
            List<string> userInfoList = new List<string>();
            if (userInfo == "UserSex")
            {
                userInfoList.Add("未知的性别");
                userInfoList.Add("男");
                userInfoList.Add("女");
            
            }
            if (userInfo == "UserHuji")
            {
                userInfoList.Add("户籍");
                userInfoList.Add("非户籍");
            }
            if (userInfo == "UserMinzu")
            {
                userInfoList.Add("汉族");
                userInfoList.Add("满族");
                userInfoList.Add("朝鲜族");
                userInfoList.Add("蒙古族");
                userInfoList.Add("回族");
                userInfoList.Add("壮族");
                userInfoList.Add("维吾尔族");
                userInfoList.Add("其他民族");
            }

            if (userInfo == "UserWenhua")
            {
                userInfoList.Add("小学");
                userInfoList.Add("初中");
                userInfoList.Add("高中/技校/中专");
                userInfoList.Add("大学专科");
                userInfoList.Add("大学本科");
                userInfoList.Add("大学研究生");
                userInfoList.Add("大学博士及以上");
                userInfoList.Add("文盲及半文盲");
                userInfoList.Add("不详");
            }
            if (userInfo == "UserHunyin")
            {
                userInfoList.Add("未婚");
                userInfoList.Add("已婚");
                userInfoList.Add("丧偶");
                userInfoList.Add("离婚");
                userInfoList.Add("未说明的婚姻状况");
            }
            if (userInfo == "UserZhiye")
            {
                userInfoList.Add("国家机关、党群组织、企业、事业单位负责人");
                userInfoList.Add("专业技术人员");
                userInfoList.Add("办事人员和有关人员");
                userInfoList.Add("商业、服务人员");
                userInfoList.Add("农、林、牧、渔、水利业生产人员");
                userInfoList.Add("生产、运输设备操作人员及有关人员");
                userInfoList.Add("军人");
                userInfoList.Add("不便分类的其他从业人员");
            }
            return userInfoList;
        }

        public static List<string> HealthInfoList(string HealthInfo)
        {
            List<string> healthInfoList = new List<string>();
            if (HealthInfo == "HealthXuexing")
            {
                healthInfoList.Add("1 A型");
                healthInfoList.Add("2 B型");
                healthInfoList.Add("3 O型");
                healthInfoList.Add("4 AB型");
                healthInfoList.Add("5 不详");

            }
            if (HealthInfo == "HealthRH")
            {
                healthInfoList.Add("1 否");
                healthInfoList.Add("2 是");
                healthInfoList.Add("3 不详");
            }
            if (HealthInfo == "HealthFeiyong")
            {
                healthInfoList.Add("1 城镇职工基本医疗保险");
                healthInfoList.Add("2 城镇居民基本医疗保险");
                healthInfoList.Add("3 新型农村合作医疗");
                healthInfoList.Add("4 贫困救助");
                healthInfoList.Add("5 商业医疗保险");
                healthInfoList.Add("6 全公费");
                healthInfoList.Add("7 全自费");
                healthInfoList.Add("8 其他");
            }
            if (HealthInfo == "HealthGuomin")
            {
                healthInfoList.Add("1 无");
                healthInfoList.Add("2 青霉素");
                healthInfoList.Add("3 磺胺");
                healthInfoList.Add("4 链霉素");
                healthInfoList.Add("5 其他");
            }
            if (HealthInfo == "HealthBaolou")
            {
                healthInfoList.Add("1 无");
                healthInfoList.Add("2 化学品");
                healthInfoList.Add("3 毒物");
                healthInfoList.Add("4 射线");
            }
            if (HealthInfo == "HealthJibing")
            {
                healthInfoList.Add("1 无");
                healthInfoList.Add("2 高血压");
                healthInfoList.Add("3 糖尿病");
                healthInfoList.Add("4 冠心病");
                healthInfoList.Add("5 慢性阻塞性肺疾病");
                healthInfoList.Add("6 恶性肿瘤");
                healthInfoList.Add("7 脑卒中");
                healthInfoList.Add("8 重性精神疾病");
                healthInfoList.Add("9 结核病");
                healthInfoList.Add("10 肝炎");
                healthInfoList.Add("11 其他法定传染病");
                healthInfoList.Add("12 职业病");
                healthInfoList.Add("13 其他");
            }

            if (HealthInfo == "HealthJiazuDady")
            {
                healthInfoList.Add("1 无");
                healthInfoList.Add("2 高血压");
                healthInfoList.Add("3 糖尿病");
                healthInfoList.Add("4 冠心病");
                healthInfoList.Add("5 慢性阻塞性肺疾病");
                healthInfoList.Add("6 恶性肿瘤");
                healthInfoList.Add("7 脑卒中");
                healthInfoList.Add("8 重性精神疾病");
                healthInfoList.Add("9 结核病");
                healthInfoList.Add("10 肝炎");
                healthInfoList.Add("11 先天畸形");
                healthInfoList.Add("12 其他");
            }
            if (HealthInfo == "HealthCanji")
            {
                healthInfoList.Add("1 无残疾");
                healthInfoList.Add("2 视力残疾");
                healthInfoList.Add("3 听力残疾");
                healthInfoList.Add("4 言语残疾");
                healthInfoList.Add("5 肢体残疾");
                healthInfoList.Add("6 智力残疾");
                healthInfoList.Add("7 精神残疾");
                healthInfoList.Add("8 其他残疾");

            }

            if (HealthInfo == "HealthChufang")
            {
                healthInfoList.Add("1 无");
                healthInfoList.Add("2 油烟机");
                healthInfoList.Add("3 换气扇");
                healthInfoList.Add("4 烟囱");
            }

            if (HealthInfo == "HealthRanliao")
            {
                healthInfoList.Add("1 液化气");
                healthInfoList.Add("2 煤");
                healthInfoList.Add("3 天然气");
                healthInfoList.Add("4 沼气");
                healthInfoList.Add("5 柴火");
                healthInfoList.Add("6 其他");
            }

            if (HealthInfo == "HealthYinshui")
            {
                healthInfoList.Add("1 自来水");
                healthInfoList.Add("2 经净化过滤的水");
                healthInfoList.Add("3 井水");
                healthInfoList.Add("4 河湖水");
                healthInfoList.Add("5 塘水");
                healthInfoList.Add("6 其他");
            }
            if (HealthInfo == "HealthCesuo")
            {
                healthInfoList.Add("1 卫生厕所");
                healthInfoList.Add("2 一个或二格粪池式");
                healthInfoList.Add("3 马桶");
                healthInfoList.Add("4 露天粪坑");
                healthInfoList.Add("5 简易棚厕");

            }
            if (HealthInfo == "HealthQingchulan")
            {
                healthInfoList.Add("1 单设");
                healthInfoList.Add("2 室内");
                healthInfoList.Add("3 室外");

            }


            return healthInfoList;
        }



        
    }
}
