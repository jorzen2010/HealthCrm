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
    public class JiwangsiController : BaseController
    {
      
        
        [HttpPost]
        #region 医生添加
        public ActionResult JiwangshiAdd()
        {
            var message = new Message();
            var json = new { message.MessageInfo, message.MessageStatus, message.MessageUrl };
            return Json(json, JsonRequestBehavior.AllowGet);

        }
        #endregion


        [ChildActionOnly]
        public ActionResult JiwangshiView(int userId,string jiwangshiClass)
        {
            string table = "CrmJiwangshi";

            string strwhere = "JiwangshiUserId=" + userId+" and JiwangshiClass='"+jiwangshiClass+"'";


            List<JiwangshiDto> jiwangshiDtoList = JiwangshiBll.GetJiwangshiDtoList(table, strwhere);


            ViewData["jiwangshiDto"] = jiwangshiDtoList;

            return View("_JiwangshiPartial");
        }
        

    }
}