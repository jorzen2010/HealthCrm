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
    public class GroupController : BaseController
    {
      
        #region 医生列表页
       
        public ActionResult GroupIndex(int? p)
        {


            string strwhere = "GroupId>0";
            string table = "CrmGroup";

            Pager pager = new Pager();
            pager.PageSize = 20;
            pager.PageNo = p ?? 1;

            pager = GroupBll.GetGroupPager(pager, strwhere, table);
            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;


            return View(pager.Entity);
        }
        #endregion

        #region 医生添加
        public ActionResult GroupAdd()
        {
            return View();

        }
        #endregion

        #region 医生编辑
        public ActionResult GroupEdit(int GroupId)
        {
            string table = "CrmGroup";
            string strwhere="GroupId="+GroupId;
            GroupDto groupDto = GroupBll.GetOneGroupDto(table, strwhere);

            GroupEditViewModel model = new GroupEditViewModel();

            model.GroupName = groupDto.GroupName;
            model.GroupInfo = groupDto.GroupInfo;
            model.GroupId = groupDto.GroupId;
            

            return View(model);

        }

        #endregion

        #region 医生新增动作
        [HttpPost]
        public ActionResult GroupInsert(GroupAddViewModel model)
        {
            GroupDto groupDto = new GroupDto();

            groupDto.GroupName = model.GroupName;
            groupDto.GroupInfo = model.GroupInfo;
           
            GroupBll.AddGroup(groupDto);

           return RedirectTo("/Group/GroupIndex", "医生添加成功了");
           //return RedirectToAction("GroupIndex");


        }
        #endregion

        #region 医生更新动作
        [HttpPost]
        public ActionResult GroupUpdate(GroupEditViewModel model)
        {
            string table = "CrmGroup";
            string strwhere = "GroupId=" + model.GroupId;
            GroupDto groupDto = GroupBll.GetOneGroupDto(table,strwhere);

            groupDto.GroupName = model.GroupName;
            groupDto.GroupInfo = model.GroupInfo;

            GroupBll.UpdateGroupDto(groupDto);


            return RedirectToAction("GroupIndex");


        }

        #endregion

        #region 医生删除动作
        public ActionResult GroupDelete(int GroupId)
        {
            string table = "CrmGroup";
            string strwhere = "GroupId=" + GroupId;
            GroupBll.DeleteGroupDto(table, strwhere);

            return RedirectToAction("GroupIndex");

        }
        #endregion

    }
}