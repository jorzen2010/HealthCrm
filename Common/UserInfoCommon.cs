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



        
    }
}
