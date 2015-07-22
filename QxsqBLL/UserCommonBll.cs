using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using QxsqDTO;
using QxsqDAL;
using Common;

namespace QxsqBLL
{
    public class UserCommonBll
    {
        #region 用户属性以下拉框显示
        public static List<SelectListItem> GetUserInfoForSelect(string userInfoName)
        {


            List<string> userInfoList = UserInfoCommon.UserInfoList(userInfoName);

            List<SelectListItem> items = new List<SelectListItem>();



            foreach (string userinfo in userInfoList)
            {

                items.Add(new SelectListItem { Text = userinfo, Value = userinfo });
            }

            return items;
        }
        #endregion
    }
}
