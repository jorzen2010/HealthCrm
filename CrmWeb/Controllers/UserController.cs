using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using QxsqBLL;
using CrmWeb.Models;
using QxsqDTO;

namespace CrmWeb.Controllers
{
    public class UserController : BaseController
    {
      
        #region 客户列表页
       
        public ActionResult UserIndex(int? p,int?groupId,int?userClass)
        {

            int GroupId = groupId ?? 0;
            int UserClass = userClass ?? 0;
            string strwhere = "1=1";
            if (GroupId > 0)
            {
                strwhere =strwhere+ " and UserGroup=" + GroupId;
            }
            if (UserClass > 0)
            {
                strwhere = strwhere + " and UserClass=" + UserClass;
            }
            string table = "CrmUser";

            Pager pager = new Pager();
            pager.PageSize = 20;
            pager.PageNo = p ?? 1;

            pager = UserBll.GetUserPager(pager, strwhere, table);
            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;


            return View(pager.Entity);
        }
        #endregion


        #region 客户列表页

        public ActionResult UserFenpei(int? p, int? groupId)
        {

            int GroupId = groupId ?? 0;
            string strwhere = "";
            if (GroupId == 0)
            {
                strwhere = "UserId>0";
            }
            else
            {
                strwhere = "UserGroup=" + GroupId;
            }
            string table = "CrmUser";

            Pager pager = new Pager();
            pager.PageSize = 20;
            pager.PageNo = p ?? 1;

            pager = UserBll.GetUserPager(pager, strwhere, table);
            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;

            ViewData["UserDoctorList"] = DoctorBll.GetFenpeiDoctorForSelect();

            return View(pager.Entity);
        }
        #endregion

        #region 客户更新动作
        [HttpPost]
        public ActionResult FenpeiUser()
        {
            if (string.IsNullOrEmpty(Request.Form["UserId"]) == true||string.IsNullOrEmpty(Request.Form["FenpeiDoctor"])==true)
            {
                return RedirectTo("/User/UserFenpei", "你尚未选择用户或医生，不能分配");
            }
            else
            { 
             string UserId = Request.Form["UserId"].ToString();
             int UserDoctor = int.Parse(Request.Form["FenpeiDoctor"].ToString());
             string[] UserIdList = UserId.Split(',');
             foreach (string userId in UserIdList)
             {
                 int FenpeiUserId = int.Parse(userId);
                 string table = "CrmUser";
                 string strwhere = "UserId=" + FenpeiUserId;
                 UserDto userDto = UserBll.GetOneUserDto(table, strwhere);
                 userDto.UserDoctor = UserDoctor;
                 UserBll.UpdateUserDto(userDto);
             
             }
             return RedirectTo("/User/UserFenpei", "成功分配！");
            }
           






            
          //   return Content(UserDoctor.ToString());
          //  return RedirectToAction("UserIndex");


        }

        #endregion


        #region 客户添加
        public ActionResult UserAdd()
        {
            ViewData["UserSexList"] = UserCommonBll.GetUserInfoForSelect("UserSex");
            ViewData["UserHujiList"] = UserCommonBll.GetUserInfoForSelect("UserHuji");
            ViewData["UserMinzuList"] = UserCommonBll.GetUserInfoForSelect("UserMinzu");
            ViewData["UserZhiyeList"] = UserCommonBll.GetUserInfoForSelect("UserZhiye");
            ViewData["UserHunyinList"] = UserCommonBll.GetUserInfoForSelect("UserHunyin");
            ViewData["UserWenhuaList"] = UserCommonBll.GetUserInfoForSelect("UserWenhua");
            ViewData["UserGroupList"] = GroupBll.GetGroupForSelect();
            ViewData["UserDoctorList"] = DoctorBll.GetDoctorForSelect(int.Parse(System.Web.HttpContext.Current.Request.Cookies["DoctorId"].Value));
            ViewData["UserClass"] = UserClassBll.GetUserClassDtoList("CrmUserClass", "1=1");
            return View();

        }
        #endregion

        #region 客户编辑
        public ActionResult UserEdit(int UserId)
        {

            string table = "CrmUser";
            string strwhere="UserId="+UserId;
            UserDto userDto = UserBll.GetOneUserDto(table, strwhere);

            UserEditViewModel model = new UserEditViewModel();

            model.UserId = userDto.UserId;
            model.UserPassword = userDto.UserPassword;
            model.UserName = userDto.UserName;
            model.UserSex = userDto.UserSex;
            model.UserBirthday = DateTime.Parse(userDto.UserBirthday.ToString());
            model.UserNumber = userDto.UserNumber;
            model.UserTel = userDto.UserTel;
            model.UserFirstPerson = userDto.UserFirstPerson;
            model.UserFirstPersonTel = userDto.UserFirstPersonTel;
            model.UserJiedaoName = userDto.UserJiedaoName;
            model.UserJuweihuiName = userDto.UserJuweihuiName;
            model.UserHuji = userDto.UserHuji;
            model.UserMinzu = userDto.UserMinzu;
            model.UserWenhua = userDto.UserWenhua;
            model.UserZhiye = userDto.UserZhiye;
            model.UserHunyin = userDto.UserHunyin;
            model.UserDoctor = userDto.UserDoctor;
            model.UserGroup = userDto.UserGroup;
            model.UserClass = userDto.UserClass;
            model.UserNowAddress = userDto.UserNowAddress;
            model.UserOldAddress = userDto.UserOldAddress;
            model.UserJobGroup = userDto.UserJobGroup;
            model.UserDiy1 = userDto.UserDiy1;
            model.UserDiy2 = userDto.UserDiy2;
            model.UserDiy3 = userDto.UserDiy3;
            model.UserDiy4 = userDto.UserDiy4;
            model.UserDiy5 = userDto.UserDiy5;
            model.UserDiy6 = userDto.UserDiy6;
            model.UserBeizhu = userDto.UserBeizhu;

            ViewData["UserSexList"] = UserCommonBll.GetUserInfoForSelect("UserSex");
            ViewData["UserHujiList"] = UserCommonBll.GetUserInfoForSelect("UserHuji");
            ViewData["UserMinzuList"] = UserCommonBll.GetUserInfoForSelect("UserMinzu");
            ViewData["UserZhiyeList"] = UserCommonBll.GetUserInfoForSelect("UserZhiye");
            ViewData["UserHunyinList"] = UserCommonBll.GetUserInfoForSelect("UserHunyin");
            ViewData["UserWenhuaList"] = UserCommonBll.GetUserInfoForSelect("UserWenhua");
            ViewData["UserGroupList"] = GroupBll.GetGroupForSelect();
            ViewData["UserDoctorList"] = DoctorBll.GetDoctorForSelect(int.Parse(System.Web.HttpContext.Current.Request.Cookies["DoctorId"].Value));
            ViewData["UserClass"] = UserClassBll.GetUserClassDtoList("CrmUserClass", "1=1");


            return View(model);

        }

        #endregion

        #region 客户新增动作
        [HttpPost]
        public ActionResult UserInsert(UserAddViewModel model)
        {
            UserDto userDto = new UserDto();

            userDto.UserPassword = model.UserPassword;
            userDto.UserName = model.UserName;
            userDto.UserSex = model.UserSex;
            userDto.UserBirthday = model.UserBirthday;
            userDto.UserNumber = model.UserNumber;
            userDto.UserTel = model.UserTel;
            userDto.UserFirstPerson = model.UserFirstPerson;
            userDto.UserFirstPersonTel = model.UserFirstPersonTel;
            userDto.UserJiedaoName = model.UserJiedaoName;
            userDto.UserJuweihuiName = model.UserJuweihuiName;
            userDto.UserHuji = model.UserHuji;
            userDto.UserMinzu = model.UserMinzu;
            userDto.UserWenhua = model.UserWenhua;
            userDto.UserZhiye = model.UserZhiye;
            userDto.UserHunyin = model.UserHunyin;
            userDto.UserDoctor = model.UserDoctor;
            userDto.UserGroup = model.UserGroup;
           // userDto.UserClass = model.UserClass;
           // userDto.UserClass = Request.Form["UserClass"];
            if (String.IsNullOrEmpty(Request.Form["UserClass"]))
            {
                userDto.UserClass = "11";

            }
            else
            {
                userDto.UserClass = Request.Form["UserClass"].ToString();
            }
            userDto.UserNowAddress = model.UserNowAddress;
            userDto.UserOldAddress = model.UserOldAddress;
            userDto.UserJobGroup = model.UserJobGroup;
            userDto.UserDiy1 = model.UserDiy1;
            userDto.UserDiy2 = model.UserDiy2;
            userDto.UserDiy3 = model.UserDiy3;
            userDto.UserDiy4 = model.UserDiy4;
            userDto.UserDiy5 = model.UserDiy5;
            userDto.UserDiy6 = model.UserDiy6;
            userDto.UserBeizhu = model.UserBeizhu;

           UserBll.AddUser(userDto);
           UserDto healthUser = UserBll.GetOneUserDto("CrmUser", "UserName='" + userDto.UserName + "' and UserNumber='" + userDto.UserNumber + "' and UserTel='"+userDto.UserTel+"'");

         // return RedirectTo("/User/UserIndex", "客户添加成功了");
           return Redirect("/Health/HealthAdd?userId=" + healthUser.UserId + "&userName=" + userDto.UserName);
          //  return Content();


        }
        #endregion

        #region 客户更新动作
        [HttpPost]
        public ActionResult UserUpdate(UserEditViewModel model)
        {
            string table = "CrmUser";
            string strwhere = "UserId=" + model.UserId;
            UserDto userDto = UserBll.GetOneUserDto(table,strwhere);
            userDto.UserPassword = model.UserPassword;
            userDto.UserName = model.UserName;
            userDto.UserSex = model.UserSex;
            userDto.UserBirthday = model.UserBirthday;
            userDto.UserNumber = model.UserNumber;
            userDto.UserTel = model.UserTel;
            userDto.UserFirstPerson = model.UserFirstPerson;
            userDto.UserFirstPersonTel = model.UserFirstPersonTel;
            userDto.UserJiedaoName = model.UserJiedaoName;
            userDto.UserJuweihuiName = model.UserJuweihuiName;
            userDto.UserHuji = model.UserHuji;
            userDto.UserMinzu = model.UserMinzu;
            userDto.UserWenhua = model.UserWenhua;
            userDto.UserZhiye = model.UserZhiye;
            userDto.UserHunyin = model.UserHunyin;
            userDto.UserDoctor = model.UserDoctor;
            userDto.UserGroup = model.UserGroup;

            if (String.IsNullOrEmpty(Request.Form["UserClass"]))
            {
                userDto.UserClass = "11";

            }
            else
            {
                userDto.UserClass = Request.Form["UserClass"].ToString();
            }
            userDto.UserNowAddress = model.UserNowAddress;
            userDto.UserOldAddress = model.UserOldAddress;
            userDto.UserJobGroup = model.UserJobGroup;
            userDto.UserDiy1 = model.UserDiy1;
            userDto.UserDiy2 = model.UserDiy2;
            userDto.UserDiy3 = model.UserDiy3;
            userDto.UserDiy4 = model.UserDiy4;
            userDto.UserDiy5 = model.UserDiy5;
            userDto.UserDiy6 = model.UserDiy6;
            userDto.UserBeizhu = model.UserBeizhu;



            UserBll.UpdateUserDto(userDto);


            return RedirectToAction("UserIndex");


        }

        #endregion

        #region 客户删除动作
        public ActionResult UserDelete(int UserId)
        {
            string table = "CrmUser";
            string strwhere = "UserId=" + UserId;
            UserBll.DeleteUserDto(table, strwhere);

            return RedirectToAction("UserIndex");

        }
        #endregion

    }
}