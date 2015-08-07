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
        public ActionResult HealthAdd(int userId,string userName)
        {
            ViewData["HealthXuexingList"] = UserInfoCommon.HealthInfoList("HealthXuexing");
            ViewData["HealthRHList"] = UserInfoCommon.HealthInfoList("HealthRH");
            ViewData["HealthFeiyongList"] = UserInfoCommon.HealthInfoList("HealthFeiyong");
            ViewData["HealthGuominList"] = UserInfoCommon.HealthInfoList("HealthGuomin");
            ViewData["HealthBaolouList"] = UserInfoCommon.HealthInfoList("HealthBaolou");

            ViewData["HealthJibingList"] = UserInfoCommon.HealthInfoList("HealthJibing");

            ViewData["HealthCanjiList"] = UserInfoCommon.HealthInfoList("HealthCanji");
            ViewData["HealthJiazuList"] = UserInfoCommon.HealthInfoList("HealthJiazu");


            ViewData["HealthChufangList"] = UserInfoCommon.HealthInfoList("HealthChufang");
            ViewData["HealthRanliaoList"] = UserInfoCommon.HealthInfoList("HealthRanliao");
            ViewData["HealthYinshuiList"] = UserInfoCommon.HealthInfoList("HealthYinshui");
            ViewData["HealthCesuoList"] = UserInfoCommon.HealthInfoList("HealthCesuo");
            ViewData["HealthQichulanList"] = UserInfoCommon.HealthInfoList("HealthQichulan");
            ViewBag.userId = userId;
            ViewBag.userName = userName;
            return View();

        }
        #endregion

        #region 客户编辑
        public ActionResult HealthEdit(int HealthId)
        {
            string table = "CrmHealth";
            string strwhere = "HealthId=" + HealthId;
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

            ViewData["HealthXuexingList"] = UserInfoCommon.HealthInfoList("HealthXuexing");
            ViewData["HealthRHList"] = UserInfoCommon.HealthInfoList("HealthRH");
            ViewData["HealthFeiyongList"] = UserInfoCommon.HealthInfoList("HealthFeiyong");
            ViewData["HealthGuominList"] = UserInfoCommon.HealthInfoList("HealthGuomin");
            ViewData["HealthBaolouList"] = UserInfoCommon.HealthInfoList("HealthBaolou");

            ViewData["HealthJibingList"] = UserInfoCommon.HealthInfoList("HealthJibing");

            ViewData["HealthCanjiList"] = UserInfoCommon.HealthInfoList("HealthCanji");
            ViewData["HealthJiazuList"] = UserInfoCommon.HealthInfoList("HealthJiazu");


            ViewData["HealthChufangList"] = UserInfoCommon.HealthInfoList("HealthChufang");
            ViewData["HealthRanliaoList"] = UserInfoCommon.HealthInfoList("HealthRanliao");
            ViewData["HealthYinshuiList"] = UserInfoCommon.HealthInfoList("HealthYinshui");
            ViewData["HealthCesuoList"] = UserInfoCommon.HealthInfoList("HealthCesuo");
            ViewData["HealthQichulanList"] = UserInfoCommon.HealthInfoList("HealthQichulan");


            return View(model);

        }

        #endregion

        #region 客户新增动作
        [HttpPost]
        public ActionResult HealthInsert(HealthAddViewModel model)
        {
            HealthDto healthDto = new HealthDto();

            healthDto.HealthUserId = int.Parse(Request.Form["HealthUserId"].ToString());
            healthDto.HealthXuexing = Request.Form["HealthXuexing"].ToString();
            healthDto.HealthRH = Request.Form["HealthRH"].ToString();
            healthDto.HealthFeiyong = Request.Form["HealthFeiyong"].ToString();
            if (String.IsNullOrEmpty(Request.Form["HealthGuomin"]))
            {
                healthDto.HealthGuomin = "1 无";

            }
            else
            {
                healthDto.HealthGuomin = Request.Form["HealthGuomin"].ToString();
            }
            if (String.IsNullOrEmpty(Request.Form["HealthBaolou"]))
            {
                healthDto.HealthBaolou = "1 无";

            }

            else
            {
                healthDto.HealthBaolou = Request.Form["HealthBaolou"].ToString();
            }
            if (String.IsNullOrEmpty(Request.Form["HealthJibing"]))
            {
                healthDto.HealthJibing = "1 无";

            }
            else
            {
                healthDto.HealthJibing = Request.Form["HealthJibing"].ToString();

            }
            healthDto.HealthShoushu = Request.Form["HealthShoushu"].ToString();
            healthDto.HealthWaishang = Request.Form["HealthWaishang"].ToString();
            healthDto.HealthShuxue = Request.Form["HealthShuxue"].ToString();
            if (String.IsNullOrEmpty(Request.Form["HealthJiazuDady"]))
            {

                healthDto.HealthJiazuDady = "1 无";
            }
            else
            {
                healthDto.HealthJiazuDady = Request.Form["HealthJiazuDady"].ToString();
            }

            if (String.IsNullOrEmpty(Request.Form["HealthJiazuMama"]))
            {
                healthDto.HealthJiazuMama = "1 无";

            }
            else
            {
                healthDto.HealthJiazuMama = Request.Form["HealthJiazuMama"].ToString();
            }

            if (String.IsNullOrEmpty(Request.Form["HealthJiazuXiongdi"]))
            {

                healthDto.HealthJiazuXiongdi = "1 无";
            }
            else
            {
                healthDto.HealthJiazuXiongdi = Request.Form["HealthJiazuXiongdi"].ToString();

            }
            if (String.IsNullOrEmpty(Request.Form["HealthJiazuZinv"]))
            {
                healthDto.HealthJiazuZinv = "1 无";

            }
            else
            {
                healthDto.HealthJiazuZinv = Request.Form["HealthJiazuZinv"].ToString();
            }

            healthDto.HealthYichuan = Request.Form["HealthYichuan"].ToString();
            if (String.IsNullOrEmpty(Request.Form["HealthCanji"]))
            {

                healthDto.HealthCanji = "1 无";

            }
            else
            {
                healthDto.HealthCanji = Request.Form["HealthCanji"].ToString();
            }

            healthDto.HealthChufang = Request.Form["HealthChufang"].ToString();
            healthDto.HealthRanliao = Request.Form["HealthRanliao"].ToString();
            healthDto.HealthYinshui = Request.Form["HealthYinshui"].ToString();
            healthDto.HealthCesuo = Request.Form["HealthCesuo"].ToString();
            healthDto.HealthQichulan = Request.Form["HealthQichulan"].ToString();

            HealthBll.AddHealth(healthDto);

            return RedirectTo("/Health/HealthIndex", "客户身体信息添加成功了");
            //return RedirectToAction("HealthIndex");


        }
        #endregion

        #region 客户新增动作测试
        [HttpPost]
        public ActionResult HealthInsert1()
        {

            //  string content = Request.Form["healthXuexing"].ToString();
            //  string content2 = Request.Form["healthFeiyong"].ToString();
            //string content3 = Request.Form["healthJiazuDady"].ToString();



            // return Content(content3);
            return RedirectToAction("HealthIndex");


        }
        #endregion

        #region 客户更新动作
        [HttpPost]
        public ActionResult HealthUpdate()
        {
            string table = "CrmHealth";
            string strwhere = "HealthId=" + int.Parse(Request.Form["HealthId"].ToString());
            HealthDto healthDto = HealthBll.GetOneHealthDto(table, strwhere);
            healthDto.HealthId = int.Parse(Request.Form["HealthId"].ToString());
            healthDto.HealthUserId = int.Parse(Request.Form["HealthUserId"].ToString());
            healthDto.HealthXuexing = Request.Form["HealthXuexing"].ToString();
            healthDto.HealthRH = Request.Form["HealthRH"].ToString();
            healthDto.HealthFeiyong = Request.Form["HealthFeiyong"].ToString();
            if (String.IsNullOrEmpty(Request.Form["HealthGuomin"]))
            {
                healthDto.HealthGuomin = "1 无";

            }
            else
            {
                healthDto.HealthGuomin = Request.Form["HealthGuomin"].ToString();
            }
            if (String.IsNullOrEmpty(Request.Form["HealthBaolou"]))
            {
                healthDto.HealthBaolou = "1 无";

            }

            else
            {
                healthDto.HealthBaolou = Request.Form["HealthBaolou"].ToString();
            }
            if (String.IsNullOrEmpty(Request.Form["HealthJibing"]))
            {
                healthDto.HealthJibing = "1 无";

            }
            else
            {
                healthDto.HealthJibing = Request.Form["HealthJibing"].ToString();

            }
            healthDto.HealthShoushu = Request.Form["HealthShoushu"].ToString();
            healthDto.HealthWaishang = Request.Form["HealthWaishang"].ToString();
            healthDto.HealthShuxue = Request.Form["HealthShuxue"].ToString();
            if (String.IsNullOrEmpty(Request.Form["HealthJiazuDady"]))
            {

                healthDto.HealthJiazuDady = "1 无";
            }
            else
            {
                Request.Form["HealthJiazuDady"].ToString();
            }

            if (String.IsNullOrEmpty(Request.Form["HealthJiazuMama"]))
            {
                healthDto.HealthJiazuMama = "1 无";

            }
            else
            {
                Request.Form["HealthJiazuMama"].ToString();
            }

            if (String.IsNullOrEmpty(Request.Form["HealthJiazuXiongdi"]))
            {

                healthDto.HealthJiazuXiongdi = "1 无";
            }
            else
            {
                Request.Form["HealthJiazuXiongdi"].ToString();

            }
            if (String.IsNullOrEmpty(Request.Form["HealthJiazuZinv"]))
            {
                healthDto.HealthJiazuZinv = "1 无";

            }
            else
            {
                healthDto.HealthJiazuZinv = Request.Form["HealthJiazuZinv"].ToString();
            }

            healthDto.HealthYichuan = Request.Form["HealthYichuan"].ToString();
            if (String.IsNullOrEmpty(Request.Form["HealthCanji"]))
            {

                healthDto.HealthCanji = "1 无";

            }
            else
            {
                healthDto.HealthCanji = Request.Form["HealthCanji"].ToString();
            }

            healthDto.HealthChufang = Request.Form["HealthChufang"].ToString();
            healthDto.HealthRanliao = Request.Form["HealthRanliao"].ToString();
            healthDto.HealthYinshui = Request.Form["HealthYinshui"].ToString();
            healthDto.HealthCesuo = Request.Form["HealthCesuo"].ToString();
            healthDto.HealthQichulan = Request.Form["HealthQichulan"].ToString();



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


        #region 新增动作疾病详情
        [HttpPost]
        public void AjaxJibingInsert()
        {

            //  string content = Request.Form["healthXuexing"].ToString();
            //  string content2 = Request.Form["healthFeiyong"].ToString();
            // string content3 = Request.Form["healthJiazuDady"].ToString();

            int JiwangshiUserId = 0;
            string JiwangshiName = "";
            string JiwangshiClass = "既往史";
            DateTime JiwangshiTime = System.DateTime.Now;
            string JiwangshiJibingClass = "";

            JiwangshiUserId = int.Parse(Request.Form["JiwangshiUserId"].ToString());
            JiwangshiClass = Request.Form["JiwangshiClass"].ToString();
            JiwangshiName = Request.Form["JiwangshiName"].ToString();
            JiwangshiJibingClass = Request.Form["JiwangshiJibingClass"].ToString();
            JiwangshiTime = DateTime.Parse(Request.Form["JiwangshiTime"].ToString());


            JiwangshiDto jiwangshiDto = new JiwangshiDto();

            jiwangshiDto.JiwangshiUserId = JiwangshiUserId;
            jiwangshiDto.JiwangshiClass = JiwangshiClass;
            jiwangshiDto.JiwangshiName = JiwangshiName;
            jiwangshiDto.JiwangshiJibingClass = JiwangshiJibingClass;
            jiwangshiDto.JiwangshiTime = JiwangshiTime;

            JiwangshiBll.AddJiwangshi(jiwangshiDto);



            return;
            //return RedirectToAction("HealthIndex");


        }
        #endregion

        [ChildActionOnly]
        public ActionResult JiwangshiView(int userId, string jiwangshiClass)
        {
            string table = "CrmJiwangshi";

            string strwhere = "JiwangshiUserId=" + userId + " and JiwangshiClass='" + jiwangshiClass + "'";


            List<JiwangshiDto> jiwangshiDtoList = JiwangshiBll.GetJiwangshiDtoList(table, strwhere);


            ViewData["jiwangshiDto"] = jiwangshiDtoList;

            return View("_JiwangshiPartial");
        }

    }
}