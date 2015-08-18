using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using QxsqBLL;
using CrmWeb.Models;
using QxsqDTO;
using Aspose.Words;
using Aspose.Words.Markup;
using Aspose.Words.Drawing;
using Aspose.Words.Tables;

namespace CrmWeb.Controllers
{
    public class UserController : BaseController
    {
      
        #region 客户列表页
       
        public ActionResult UserIndex(int? p,int?groupId,int?userClass,int?doctorId)
        {

            int GroupId = groupId ?? 0;
            int UserClass = userClass ?? 0;
            int DoctorId = doctorId ?? 0;
            string strwhere = "1=1";
            if (GroupId > 0)
            {
                strwhere =strwhere+ " and UserGroup=" + GroupId;
            }
            if (UserClass > 0)
            {

                strwhere = strwhere + " and charindex('" + UserClass+"',UserClass)>0";

            }
            if (DoctorId > 0)
            {

                strwhere = strwhere + " and UserDoctor=" + DoctorId;

            }
            string table = "CrmUser";

            Pager pager = new Pager();
            pager.PageSize = 20;
            pager.PageNo = p ?? 1;

            pager = UserBll.GetUserPager(pager, strwhere, table);
            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;

            ViewData["UserClass"] = UserClassBll.GetUserClassDtoList("CrmUserClass", "1=1");
            ViewData["UserGroupList"] = GroupBll.GetGroupDtoList("CrmGroup", "1=1");
            ViewData["DoctorList"] = DoctorBll.GetDoctorDtoList("CrmDoctor", "1=1");
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

        #region 客户分配动作
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

        #region 客户搜索
        public ActionResult UserSearch(string userName)
        {

            string table = "CrmUser";
            string strwhere = "UserName='" +userName+"'";
            List<UserDto> userDtoList = UserBll.GetUserDtoList(table,strwhere);
            ViewData["UserClass"] = UserClassBll.GetUserClassDtoList("CrmUserClass", "1=1");
            ViewData["UserGroupList"] = GroupBll.GetGroupDtoList("CrmGroup", "1=1");
            ViewBag.RecordCount=userDtoList.Count;
            return View(userDtoList);

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
            if (String.IsNullOrEmpty(Request.Form["UserDiy1"]))
            {
                userDto.UserDiy1 = "无";
            }
            else
            {
                userDto.UserDiy1 = Request.Form["UserDiy1"].ToString();
            }
            if (String.IsNullOrEmpty(Request.Form["UserDiy2"]))
            {
                userDto.UserDiy2 = "无";
            }
            else
            {
                userDto.UserDiy2 = Request.Form["UserDiy2"].ToString();
            }
            if (String.IsNullOrEmpty(Request.Form["UserDiy3"]))
            {
                userDto.UserDiy3 = "无";
            }
            else
            {
                userDto.UserDiy3 = Request.Form["UserDiy3"].ToString();
            }

            userDto.UserDiy4 = model.UserDiy4;
            userDto.UserDiy5 = model.UserDiy5;
            userDto.UserDiy6 = model.UserDiy6;
            userDto.UserBeizhu = model.UserBeizhu;

           UserBll.AddUser(userDto);
           UserDto healthUser = UserBll.GetOneUserDto("CrmUser", "UserName='" + userDto.UserName + "' and UserNumber='" + userDto.UserNumber + "' and UserTel='"+userDto.UserTel+"'");

         // return RedirectTo("/User/UserIndex?groupId=0&userClass=0", "客户添加成功了");
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
            if (String.IsNullOrEmpty(Request.Form["UserDiy1"]))
            {
                userDto.UserDiy1 = "无";
            }
            else
            {
                userDto.UserDiy1 = Request.Form["UserDiy1"].ToString();
            }
            if (String.IsNullOrEmpty(Request.Form["UserDiy2"]))
            {
                userDto.UserDiy2 = "无";
            }
            else
            {
                userDto.UserDiy2 = Request.Form["UserDiy2"].ToString();
            }
            if (String.IsNullOrEmpty(Request.Form["UserDiy3"]))
            {
                userDto.UserDiy3 = "无";
            }
            else
            {
                userDto.UserDiy3 = Request.Form["UserDiy3"].ToString();
            }

            userDto.UserDiy4 = model.UserDiy4;
            userDto.UserDiy5 = model.UserDiy5;
            userDto.UserDiy6 = model.UserDiy6;
            userDto.UserBeizhu = model.UserBeizhu;



            UserBll.UpdateUserDto(userDto);

          //  return Redirect("/Health/HealthAdd?userId=" + model.UserId + "&userName=" + userDto.UserName);
            return RedirectToAction("UserIndex", "User", new { groupId = 0, userClass = 0, doctorId = System.Web.HttpContext.Current.Request.Cookies["DoctorId"].Value });


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

        #region 客户导出动作
       
        public ActionResult UserImport(int userId)
        {
            string table = "CrmUser";
            string strwhere = "UserId=" + userId.ToString();
            string htable = "CrmHealth";
            string hstrwhere = "HealthUserId=" + userId.ToString();
            UserDto userDto = UserBll.GetOneUserDto(table, strwhere);
            HealthDto healthDto = HealthBll.GetOneHealthDto(htable, hstrwhere);
            string userClassInfo = "";
            string[] userClassId = userDto.UserClass.Split(',');

            foreach (string userClass in userClassId)
            {
                userClassInfo = userClassInfo + UserClassBll.GetOneUserClassDto("CrmUserClass", "UserClassId=" + userClass).UserClassName+" ";
            }

            string jiwangshiJibing = "";
            List<JiwangshiDto> jiwangshiJibingList = JiwangshiBll.GetJiwangshiDtoList("CrmJiwangshi", "JiwangshiUserId="+userId.ToString()+" and JiwangshiClass='疾病'");
            if (jiwangshiJibingList.Count == 0)
            {
                jiwangshiJibing = "无";
            }
            else
            {
                foreach (JiwangshiDto jiwangshiDto in jiwangshiJibingList)
                {
                    jiwangshiJibing=jiwangshiJibing+ jiwangshiDto.JiwangshiName+ jiwangshiDto.JiwangshiTime.ToString("yyyy年MM月dd日") + "||";
                }
               
            
            }

            string jiwangshiShoushu = "";
            List<JiwangshiDto> jiwangshiShoushuList = JiwangshiBll.GetJiwangshiDtoList("CrmJiwangshi", "JiwangshiUserId=" + userId.ToString() + " and JiwangshiClass='手术'");
            if (jiwangshiShoushuList.Count == 0)
            {
                jiwangshiShoushu = "无";
            }
            else
            {
                foreach (JiwangshiDto jiwangshiDto in jiwangshiShoushuList)
                {
                    jiwangshiShoushu = jiwangshiShoushu + jiwangshiDto.JiwangshiName + jiwangshiDto.JiwangshiTime.ToString("yyyy年MM月dd日") + "||";
                }


            }

            string jiwangshiWaishang = "";
            List<JiwangshiDto> jiwangshiWaishangList = JiwangshiBll.GetJiwangshiDtoList("CrmJiwangshi", "JiwangshiUserId=" + userId.ToString() + " and JiwangshiClass='外伤'");
            if (jiwangshiWaishangList.Count == 0)
            {
                jiwangshiWaishang = "无";
            }
            else
            {
                foreach (JiwangshiDto jiwangshiDto in jiwangshiWaishangList)
                {
                    jiwangshiWaishang = jiwangshiWaishang + jiwangshiDto.JiwangshiName + jiwangshiDto.JiwangshiTime.ToString("yyyy年MM月dd日") + "||";
                }


            }

            string jiwangshiShuxue = "";
            List<JiwangshiDto> jiwangshiShuxueList = JiwangshiBll.GetJiwangshiDtoList("CrmJiwangshi", "JiwangshiUserId=" + userId.ToString() + " and JiwangshiClass='输血'");
            if (jiwangshiShuxueList.Count == 0)
            {
                jiwangshiShuxue = "无";
            }
            else
            {
                foreach (JiwangshiDto jiwangshiDto in jiwangshiWaishangList)
                {
                    jiwangshiShuxue = jiwangshiShuxue + jiwangshiDto.JiwangshiName + jiwangshiDto.JiwangshiTime.ToString("yyyy年MM月dd日") + "||";
                }


            }




            try
            {
                string templateFile = Server.MapPath("~/jkda.docx");
                string saveDocFile = Server.MapPath("~/" + userDto.UserName + DateTime.Now.ToString("yyyyMMddhhmmss") + ".doc");

                Aspose.Words.Document doc = new Aspose.Words.Document(templateFile);

                #region 给普通标签赋值
                Bookmark markDesigner;

              


                if (doc.Range.Bookmarks["bianhao"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["bianhao"];
                    markDesigner.Text = userDto.UserRegTime.ToString("yyyyMMddhhmmss");
                }
                if (doc.Range.Bookmarks["UserClass"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserClass"];
                    markDesigner.Text = userClassInfo;
                }
                if (doc.Range.Bookmarks["UserName"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserName"];
                    markDesigner.Text = userDto.UserName;
                }
               
                if (doc.Range.Bookmarks["UserNowAddress"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserNowAddress"];
                    markDesigner.Text = userDto.UserNowAddress;
                }
                if (doc.Range.Bookmarks["UserOldAddress"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserOldAddress"];
                    markDesigner.Text = userDto.UserOldAddress;
                }
                
                if (doc.Range.Bookmarks["TheUserTel"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["TheUserTel"];
                    markDesigner.Text = userDto.UserTel;
                }
                if (doc.Range.Bookmarks["UserGroup"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserGroup"];
                    markDesigner.Text = GroupBll.GetOneGroupDto("CrmGroup","GroupId="+userDto.UserGroup).GroupName;
                }
                if (doc.Range.Bookmarks["UserDoctor"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserDoctor"];
                    markDesigner.Text = DoctorBll.GetOneDoctorDto("CrmDoctor","DoctorId="+userDto.UserDoctor).DoctorRealName;
                }
                if (doc.Range.Bookmarks["UserRegTime"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserRegTime"];
                    markDesigner.Text = userDto.UserRegTime.ToString("yyyy年MM月dd日");
                }


               
                if (doc.Range.Bookmarks["TheUserName"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["TheUserName"];
                    markDesigner.Text = userDto.UserName;
                }

                if (doc.Range.Bookmarks["Thebianhao"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["Thebianhao"];
                    markDesigner.Text = userDto.UserRegTime.ToString("yyyyMMddhhmmss");
                }

                if (doc.Range.Bookmarks["UserTel"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserTel"];
                    markDesigner.Text = userDto.UserTel;
                }
                if (doc.Range.Bookmarks["UserSex"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserSex"];
                    markDesigner.Text = userDto.UserSex;
                }
                if (doc.Range.Bookmarks["UserBirthday"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserBirthday"];
                    markDesigner.Text = userDto.UserBirthday.ToString("yyyy年MM月dd日");
                }
                if (doc.Range.Bookmarks["UserNumber"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserNumber"];
                    markDesigner.Text = userDto.UserNumber;
                }
                if (doc.Range.Bookmarks["UserJobGroup"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserJobGroup"];
                    markDesigner.Text = userDto.UserJobGroup;
                }
                if (doc.Range.Bookmarks["UserFirstTel"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserFirstTel"];
                    markDesigner.Text = userDto.UserFirstPersonTel;
                }
                if (doc.Range.Bookmarks["UserFirstPerson"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserFirstPerson"];
                    markDesigner.Text = userDto.UserFirstPerson;
                }
                if (doc.Range.Bookmarks["UserHuji"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserHuji"];
                    markDesigner.Text = userDto.UserHuji;
                }
                if (doc.Range.Bookmarks["UserMinzu"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserMinzu"];
                    markDesigner.Text = userDto.UserMinzu;
                }
                if (doc.Range.Bookmarks["UserWenhua"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserWenhua"];
                    markDesigner.Text = userDto.UserWenhua;
                }
                if (doc.Range.Bookmarks["UserZhiye"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserZhiye"];
                    markDesigner.Text = userDto.UserZhiye;
                }
                if (doc.Range.Bookmarks["UserHunyin"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserHunyin"];
                    markDesigner.Text = userDto.UserHunyin;
                }
                #endregion

                if (doc.Range.Bookmarks["HealthXuexing"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthXuexing"];
                    markDesigner.Text = healthDto.HealthXuexing;
                }
                if (doc.Range.Bookmarks["HealthRH"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthRH"];
                    markDesigner.Text = healthDto.HealthRH;
                }
                if (doc.Range.Bookmarks["HealthFeiyong"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthFeiyong"];
                    markDesigner.Text = healthDto.HealthFeiyong;
                }
                if (doc.Range.Bookmarks["HealthGuomin"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthGuomin"];
                    markDesigner.Text = healthDto.HealthGuomin;
                }
                if (doc.Range.Bookmarks["HealthBaolou"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthBaolou"];
                    markDesigner.Text = healthDto.HealthBaolou;
                }
                if (doc.Range.Bookmarks["HealthJibing"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthJibing"];
                    markDesigner.Text = jiwangshiJibing;
                }
                if (doc.Range.Bookmarks["HealthShoushu"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthShoushu"];
                    markDesigner.Text = jiwangshiShoushu;
                }
                if (doc.Range.Bookmarks["HealthWaishang"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthWaishang"];
                    markDesigner.Text = jiwangshiWaishang;
                }
                if (doc.Range.Bookmarks["HealthShuxue"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthShuxue"];
                    markDesigner.Text = jiwangshiShuxue;
                }
                if (doc.Range.Bookmarks["HealthJiazuDady"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthJiazuDady"];
                    markDesigner.Text = healthDto.HealthJiazuDady;
                }
                if (doc.Range.Bookmarks["HealthJiazuMama"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthJiazuMama"];
                    markDesigner.Text = healthDto.HealthJiazuMama;
                }
                if (doc.Range.Bookmarks["HealthJiazuXiongdi"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthJiazuXiongdi"];
                    markDesigner.Text = healthDto.HealthJiazuXiongdi;
                }
                if (doc.Range.Bookmarks["HealthJiazuZinv"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthJiazuZinv"];
                    markDesigner.Text = healthDto.HealthJiazuZinv;
                }
                if (doc.Range.Bookmarks["HealthYichuan"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthYichuan"];
                    markDesigner.Text = healthDto.HealthYichuan;
                }
                if (doc.Range.Bookmarks["HealthCanji"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthCanji"];
                    markDesigner.Text = healthDto.HealthCanji;
                }
                if (doc.Range.Bookmarks["HealthChufang"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthChufang"];
                    markDesigner.Text = healthDto.HealthChufang;
                }
                if (doc.Range.Bookmarks["HealthRanliao"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthRanliao"];
                    markDesigner.Text = healthDto.HealthRanliao;
                }
                if (doc.Range.Bookmarks["HealthYinshui"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthYinshui"];
                    markDesigner.Text = healthDto.HealthYinshui;
                }
                if (doc.Range.Bookmarks["HealthCesuo"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthCesuo"];
                    markDesigner.Text = healthDto.HealthCesuo;
                }
                if (doc.Range.Bookmarks["HealthQichulan"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthQichulan"];
                    markDesigner.Text = healthDto.HealthQichulan;
                }
                if (doc.Range.Bookmarks["UserDiy1"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserDiy1"];
                    markDesigner.Text = userDto.UserDiy1;
                }
                if (doc.Range.Bookmarks["UserDiy2"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["UserDiy2"];
                    markDesigner.Text = userDto.UserDiy2;
                }
                if (doc.Range.Bookmarks["HealthDiy3"] != null)
                {
                    markDesigner = doc.Range.Bookmarks["HealthDiy3"];
                    markDesigner.Text = userDto.UserDiy3;
                }


                doc.Save(saveDocFile);//保存
                ViewBag.msg = "生成成功,保存路径：<br />" + saveDocFile;
                //System.Diagnostics.Process.Start(saveDocFile);//打开文档
                return File(saveDocFile, "application/msword",userDto.UserName+DateTime.Now.ToString("yyyyMMddhhmmss") + ".doc");//输出到浏览器
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }

           // UserBll.UpdateUserDto(userDto);

          //  return File(saveDocFile, "application/msword", DateTime.Now.ToString("yyyyMMddhhmmss") + ".doc");//输出到浏览器

            //  return Redirect("/Health/HealthAdd?userId=" + model.UserId + "&userName=" + userDto.UserName);
          //  return RedirectToAction("UserIndex", "User", new { groupId = 0, userClass = 0, doctorId = System.Web.HttpContext.Current.Request.Cookies["DoctorId"].Value });
            return Content(ViewBag.msg);

        }

        #endregion

    }
}