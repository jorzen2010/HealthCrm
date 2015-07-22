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
       
        public ActionResult UserIndex(int? p)
        {


            string strwhere = "UserId>0";
            string table = "JkptUser";

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

        #region 客户添加
        public ActionResult UserAdd()
        {
            ViewData["UserSexList"] = UserCommonBll.GetUserInfoForSelect("UserSex");
            ViewData["UserHujiList"] = UserCommonBll.GetUserInfoForSelect("UserHuji");
            ViewData["UserMinzuList"] = UserCommonBll.GetUserInfoForSelect("UserMinzu");
            ViewData["UserZhiyeList"] = UserCommonBll.GetUserInfoForSelect("UserZhiye");
            ViewData["UserHunyinList"] = UserCommonBll.GetUserInfoForSelect("UserHunyin");
            ViewData["UserWenhuaList"] = UserCommonBll.GetUserInfoForSelect("UserWenhua");
            return View();

        }
        #endregion

        #region 客户编辑
        public ActionResult UserEdit(int UserId)
        {
            string table = "JkptUser";
            string strwhere="UserId="+UserId;
            UserDto userDto = UserBll.GetOneUserDto(table, strwhere);

            UserEditViewModel model = new UserEditViewModel();

            model.UserId = userDto.UserId;
            model.UserPassword = userDto.UserPassword;
            model.UserName = userDto.UserName;
            model.UserSex = userDto.UserSex;
            model.UserBirthday = userDto.UserBirthday;
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
            userDto.UserClass = model.UserClass;
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

           return RedirectTo("/User/UserIndex", "客户添加成功了");
           //return RedirectToAction("UserIndex");


        }
        #endregion

        #region 客户更新动作
        [HttpPost]
        public ActionResult UserUpdate(UserEditViewModel model)
        {
            string table = "JkptUser";
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
            userDto.UserClass = model.UserClass;
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
            string table = "JkptUser";
            string strwhere = "UserId=" + UserId;
            UserBll.DeleteUserDto(table, strwhere);

            return RedirectToAction("UserIndex");

        }
        #endregion

    }
}