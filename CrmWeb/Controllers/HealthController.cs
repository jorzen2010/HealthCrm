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
    public class HealthController : BaseController
    {
      
        #region 客户列表页
       
        public ActionResult HealthIndex(int? p)
        {


            string strwhere = "HealthId>0";
            string table = "CrmHealth";

            Pager pager = new Pager();
            pager.PageSize = 20;
            pager.PageNo = p ?? 1;

            pager = HealthBll.GetHealthPager(pager, strwhere, table);
            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;


            return View(pager.Entity);
        }
        #endregion

        #region 客户添加
        public ActionResult HealthAdd()
        {
            ViewData["HealthXuexingList"] = UserInfoCommon.HealthInfoList("HealthXuexing");
            ViewData["HealthRHList"] = UserInfoCommon.HealthInfoList("HealthRH");
            ViewData["HealthFeiyongList"] = UserInfoCommon.HealthInfoList("HealthFeiyong");
            return View();

        }
        #endregion

        #region 客户编辑
        public ActionResult HealthEdit(int HealthId)
        {
            string table = "CrmHealth";
            string strwhere="HealthId="+HealthId;
            HealthDto healthDto = HealthBll.GetOneHealthDto(table, strwhere);

            HealthEditViewModel model = new HealthEditViewModel();

            model.HealthId = healthDto.HealthId;
            model.HealthId = healthDto.HealthId;
            model.HealthUserId = healthDto.HealthUserId;
            model.HealthXuexing = healthDto.HealthXuexing;
            model.HealthRH = healthDto.HealthRH;
            model.HealthFeiyong = healthDto.HealthFeiyong;
            model.HealthGuomin = healthDto.HealthGuomin;
            model.HealthBaolou = healthDto.HealthBaolou;
            model.HealthJibing = healthDto.HealthJibing;
            model.HealthShoushu = healthDto.HealthShoushu;
            model.HealthWaishang = healthDto.HealthWaishang;
            model.HealthShuxue = healthDto.HealthShuxue;
            model.HealthJiazuDady = healthDto.HealthJiazuDady;
            model.HealthJiazuMama = healthDto.HealthJiazuMama;
            model.HealthJiazuXiongdi = healthDto.HealthJiazuXiongdi;
            model.HealthJiazuZinv = healthDto.HealthJiazuZinv;
            model.HealthYichuan = healthDto.HealthYichuan;
            model.HealthCanji = healthDto.HealthCanji;
            model.HealthChufang = healthDto.HealthChufang;
            model.HealthRanliao = healthDto.HealthRanliao;
            model.HealthYinshui = healthDto.HealthYinshui;
            model.HealthCesuo = healthDto.HealthCesuo;
            model.HealthQichulan = healthDto.HealthQichulan;



            return View(model);

        }

        #endregion

        #region 客户新增动作
        [HttpPost]
        public ActionResult HealthInsert2(HealthAddViewModel model)
        {
            HealthDto healthDto = new HealthDto();

            healthDto.HealthUserId = model.HealthUserId;
            healthDto.HealthXuexing = model.HealthXuexing;
            healthDto.HealthRH = model.HealthRH;
            healthDto.HealthFeiyong = model.HealthFeiyong;
            healthDto.HealthGuomin = model.HealthGuomin;
            healthDto.HealthBaolou = model.HealthBaolou;
            healthDto.HealthJibing = model.HealthJibing;
            healthDto.HealthShoushu = model.HealthShoushu;
            healthDto.HealthWaishang = model.HealthWaishang;
            healthDto.HealthShuxue = model.HealthShuxue;
            healthDto.HealthJiazuDady = model.HealthJiazuDady;
            healthDto.HealthJiazuMama = model.HealthJiazuMama;
            healthDto.HealthJiazuXiongdi = model.HealthJiazuXiongdi;
            healthDto.HealthJiazuZinv = model.HealthJiazuZinv;
            healthDto.HealthYichuan = model.HealthYichuan;
            healthDto.HealthCanji = model.HealthCanji;
            healthDto.HealthChufang = model.HealthChufang;
            healthDto.HealthRanliao = model.HealthRanliao;
            healthDto.HealthYinshui = model.HealthYinshui;
            healthDto.HealthCesuo = model.HealthCesuo;
            healthDto.HealthQichulan = model.HealthQichulan;

            HealthBll.AddHealth(healthDto);

           return RedirectTo("/Health/HealthIndex", "客户添加成功了");
           //return RedirectToAction("HealthIndex");


        }
        #endregion

        #region 客户新增动作
        [HttpPost]
        public ActionResult HealthInsert()
        {

            string content = Request.Form["healthXuexing"].ToString();
            string content2 = Request.Form["healthFeiyong"].ToString();



            return Content(content2);
            //return RedirectToAction("HealthIndex");


        }
        #endregion

        #region 客户更新动作
        [HttpPost]
        public ActionResult HealthUpdate(HealthEditViewModel model)
        {
            string table = "CrmHealth";
            string strwhere = "HealthId=" + model.HealthId;
            HealthDto healthDto = HealthBll.GetOneHealthDto(table,strwhere);
            healthDto.HealthId = model.HealthId;
            healthDto.HealthUserId = model.HealthUserId;
            healthDto.HealthXuexing = model.HealthXuexing;
            healthDto.HealthRH = model.HealthRH;
            healthDto.HealthFeiyong = model.HealthFeiyong;
            healthDto.HealthGuomin = model.HealthGuomin;
            healthDto.HealthBaolou = model.HealthBaolou;
            healthDto.HealthJibing = model.HealthJibing;
            healthDto.HealthShoushu = model.HealthShoushu;
            healthDto.HealthWaishang = model.HealthWaishang;
            healthDto.HealthShuxue = model.HealthShuxue;
            healthDto.HealthJiazuDady = model.HealthJiazuDady;
            healthDto.HealthJiazuMama = model.HealthJiazuMama;
            healthDto.HealthJiazuXiongdi = model.HealthJiazuXiongdi;
            healthDto.HealthJiazuZinv = model.HealthJiazuZinv;
            healthDto.HealthYichuan = model.HealthYichuan;
            healthDto.HealthCanji = model.HealthCanji;
            healthDto.HealthChufang = model.HealthChufang;
            healthDto.HealthRanliao = model.HealthRanliao;
            healthDto.HealthYinshui = model.HealthYinshui;
            healthDto.HealthCesuo = model.HealthCesuo;
            healthDto.HealthQichulan = model.HealthQichulan;



            HealthBll.UpdateHealthDto(healthDto);


            return RedirectToAction("HealthIndex");


        }

        #endregion

        #region 客户删除动作
        public ActionResult HealthDelete(int HealthId)
        {
            string table = "CrmHealth";
            string strwhere = "HealthId=" + HealthId;
            HealthBll.DeleteHealthDto(table, strwhere);

            return RedirectToAction("HealthIndex");

        }
        #endregion

    }
}