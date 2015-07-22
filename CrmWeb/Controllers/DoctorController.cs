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
    public class DoctorController : BaseController
    {
      
        #region 医生列表页
       
        public ActionResult DoctorIndex(int? p)
        {


            string strwhere = "DoctorId>0";
            string table = "CrmDoctor";

            Pager pager = new Pager();
            pager.PageSize = 2;
            pager.PageNo = p ?? 1;

            pager = DoctorBll.GetDoctorPager(pager, strwhere, table);
            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;


            return View(pager.Entity);
        }
        #endregion

        #region 医生添加
        public ActionResult DoctorAdd()
        {
            return View();

        }
        #endregion

        #region 医生编辑
        public ActionResult DoctorEdit(int DoctorId)
        {
            string table = "CrmDoctor";
            string strwhere="DoctorId="+DoctorId;
            DoctorDto doctorDto = DoctorBll.GetOneDoctorDto(table, strwhere);

            DoctorEditViewModel model = new DoctorEditViewModel();

            model.DoctorUserName = doctorDto.DoctorUserName;
            model.DoctorRealName = doctorDto.DoctorRealName;
            model.DoctorId = doctorDto.DoctorId;
            

            return View(model);

        }

        #endregion

        #region 医生新增动作
        [HttpPost]
        public ActionResult DoctorInsert(DoctorAddViewModel model)
        {
            DoctorDto doctorDto = new DoctorDto();

            doctorDto.DoctorUserName = model.DoctorUserName;
            doctorDto.DoctorRealName = model.DoctorRealName;
            doctorDto.DoctorPassword = CommonTools.ToMd5(model.DoctorPassword);
            doctorDto.DoctorRegTime = System.DateTime.Now;

            DoctorBll.AddDoctor(doctorDto);

           return RedirectTo("/Doctor/DoctorIndex", "医生添加成功了");
           //return RedirectToAction("DoctorIndex");


        }
        #endregion

        #region 医生更新动作
        [HttpPost]
        public ActionResult DoctorUpdate(DoctorEditViewModel model)
        {
            string table = "CrmDoctor";
            string strwhere = "DoctorId=" + model.DoctorId;
            DoctorDto doctorDto = DoctorBll.GetOneDoctorDto(table,strwhere);

            doctorDto.DoctorUserName = model.DoctorUserName;
            doctorDto.DoctorRealName = model.DoctorRealName;
            doctorDto.DoctorRegTime = System.DateTime.Now;

            DoctorBll.UpdateDoctorDto(doctorDto);


            return RedirectToAction("DoctorIndex");


        }

        #endregion

        #region 医生删除动作
        public ActionResult DoctorDelete(int DoctorId)
        {
            string table = "CrmDoctor";
            string strwhere = "DoctorId=" + DoctorId;
            DoctorBll.DeleteDoctorDto(table, strwhere);

            return RedirectToAction("DoctorIndex");

        }
        #endregion

    }
}