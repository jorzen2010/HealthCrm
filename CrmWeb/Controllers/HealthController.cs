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

            healthDto.HealthUserId = model.HealthUserId;
            healthDto.HealthXuexing = model.HealthXuexing;
            healthDto.HealthRH = model.HealthRH;
            healthDto.HealthFeiyong = model.HealthFeiyong;
            if (String.IsNullOrEmpty(model.HealthGuomin))
            {
                model.HealthGuomin = "1 无";
            
            }
            healthDto.HealthGuomin = model.HealthGuomin;
            if (String.IsNullOrEmpty(model.HealthBaolou))
            {
                model.HealthBaolou = "1 无";

            }
            healthDto.HealthBaolou = model.HealthBaolou;
            if (String.IsNullOrEmpty(model.HealthJibing))
            {
                model.HealthJibing = "1 无";

            }
            healthDto.HealthJibing = model.HealthJibing;
            healthDto.HealthShoushu = model.HealthShoushu;
            healthDto.HealthWaishang = model.HealthWaishang;
            healthDto.HealthShuxue = model.HealthShuxue;
            if (String.IsNullOrEmpty(model.HealthJiazuDady))
            {
                model.HealthJiazuDady = "1 无";

            }
            healthDto.HealthJiazuDady = model.HealthJiazuDady;
            if (String.IsNullOrEmpty(model.HealthJiazuMama))
            {
                model.HealthJiazuMama = "1 无";

            }
            healthDto.HealthJiazuMama = model.HealthJiazuMama;
            if (String.IsNullOrEmpty(model.HealthJiazuXiongdi))
            {
                model.HealthJiazuXiongdi = "1 无";

            }
            healthDto.HealthJiazuXiongdi = model.HealthJiazuXiongdi;
            if (String.IsNullOrEmpty(model.HealthJiazuZinv))
            {
                model.HealthJiazuZinv = "1 无";

            }
            healthDto.HealthJiazuZinv = model.HealthJiazuZinv;
            healthDto.HealthYichuan = model.HealthYichuan;
            if (String.IsNullOrEmpty(model.HealthCanji))
            {
                model.HealthCanji = "1 无";

            }
            healthDto.HealthCanji = model.HealthCanji;
            healthDto.HealthChufang = model.HealthChufang;
            healthDto.HealthRanliao = model.HealthRanliao;
            healthDto.HealthYinshui = model.HealthYinshui;
            healthDto.HealthCesuo = model.HealthCesuo;
            healthDto.HealthQichulan = model.HealthQichulan;

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
        public ActionResult HealthUpdate(HealthEditViewModel model)
        {
            string table = "CrmHealth";
            string strwhere = "HealthId=" + model.HealthId;
            HealthDto healthDto = HealthBll.GetOneHealthDto(table,strwhere);
            healthDto.HealthUserId = model.HealthUserId;
            healthDto.HealthXuexing = model.HealthXuexing;
            healthDto.HealthRH = model.HealthRH;
            healthDto.HealthFeiyong = model.HealthFeiyong;
            if (String.IsNullOrEmpty(model.HealthGuomin))
            {
                model.HealthGuomin = "1 无";

            }
            healthDto.HealthGuomin = model.HealthGuomin;
            if (String.IsNullOrEmpty(model.HealthBaolou))
            {
                model.HealthBaolou = "1 无";

            }
            healthDto.HealthBaolou = model.HealthBaolou;
            if (String.IsNullOrEmpty(model.HealthJibing))
            {
                model.HealthJibing = "1 无";

            }
            healthDto.HealthJibing = model.HealthJibing;
            healthDto.HealthShoushu = model.HealthShoushu;
            healthDto.HealthWaishang = model.HealthWaishang;
            healthDto.HealthShuxue = model.HealthShuxue;
            if (String.IsNullOrEmpty(model.HealthJiazuDady))
            {
                model.HealthJiazuDady = "1 无";

            }
            healthDto.HealthJiazuDady = model.HealthJiazuDady;
            if (String.IsNullOrEmpty(model.HealthJiazuMama))
            {
                model.HealthJiazuMama = "1 无";

            }
            healthDto.HealthJiazuMama = model.HealthJiazuMama;
            if (String.IsNullOrEmpty(model.HealthJiazuXiongdi))
            {
                model.HealthJiazuXiongdi = "1 无";

            }
            healthDto.HealthJiazuXiongdi = model.HealthJiazuXiongdi;
            if (String.IsNullOrEmpty(model.HealthJiazuZinv))
            {
                model.HealthJiazuZinv = "1 无";

            }
            healthDto.HealthJiazuZinv = model.HealthJiazuZinv;
            healthDto.HealthYichuan = model.HealthYichuan;
            if (String.IsNullOrEmpty(model.HealthCanji))
            {
                model.HealthCanji = "1 无";

            }
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
            JiwangshiTime =DateTime.Parse(Request.Form["JiwangshiTime"].ToString());


            JiwangshiDto jiwangshiDto = new JiwangshiDto();

            jiwangshiDto.JiwangshiUserId = JiwangshiUserId;
            jiwangshiDto.JiwangshiClass = JiwangshiClass;
            jiwangshiDto.JiwangshiName = JiwangshiName;
            jiwangshiDto.JiwangshiJibingClass = JiwangshiJibingClass;
            jiwangshiDto.JiwangshiTime = JiwangshiTime;

            JiwangshiBll.AddJiwangshi(jiwangshiDto);



            return ;
            //return RedirectToAction("HealthIndex");


        }
        #endregion

    }
}