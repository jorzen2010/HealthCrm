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
    public class UserClassController : BaseController
    {
      
        #region 医生列表页
       
        public ActionResult UserClassIndex(int? p)
        {


            string strwhere = "UserClassId>0";
            string table = "CrmUserClass";

            Pager pager = new Pager();
            pager.PageSize = 20;
            pager.PageNo = p ?? 1;

            pager = UserClassBll.GetUserClassPager(pager, strwhere, table);
            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;


            return View(pager.Entity);
        }
        #endregion

        #region 医生添加
        public ActionResult UserClassAdd()
        {
            return View();

        }
        #endregion

        #region 医生编辑
        public ActionResult UserClassEdit(int UserClassId)
        {
            string table = "CrmUserClass";
            string strwhere="UserClassId="+UserClassId;
            UserClassDto userClassDto = UserClassBll.GetOneUserClassDto(table, strwhere);

            UserClassEditViewModel model = new UserClassEditViewModel();

            model.UserClassName = userClassDto.UserClassName;
            model.UserClassId = userClassDto.UserClassId;
            

            return View(model);

        }

        #endregion

        #region 医生新增动作
        [HttpPost]
        public ActionResult UserClassInsert(UserClassAddViewModel model)
        {
            UserClassDto userClassDto = new UserClassDto();

            userClassDto.UserClassName = model.UserClassName;
           
            UserClassBll.AddUserClass(userClassDto);

           return RedirectTo("/UserClass/UserClassIndex", "归档类别添加成功了");
           //return RedirectToAction("UserClassIndex");


        }
        #endregion

        #region 医生更新动作
        [HttpPost]
        public ActionResult UserClassUpdate(UserClassEditViewModel model)
        {
            string table = "CrmUserClass";
            string strwhere = "UserClassId=" + model.UserClassId;
            UserClassDto userClassDto = UserClassBll.GetOneUserClassDto(table,strwhere);

            userClassDto.UserClassName = model.UserClassName;

            UserClassBll.UpdateUserClassDto(userClassDto);


            return RedirectToAction("UserClassIndex");


        }

        #endregion

        #region 医生删除动作
        public ActionResult UserClassDelete(int UserClassId)
        {
            string table = "CrmUserClass";
            string strwhere = "UserClassId=" + UserClassId;
            UserClassBll.DeleteUserClassDto(table, strwhere);

            return RedirectToAction("UserClassIndex");

        }
        #endregion

    }
}