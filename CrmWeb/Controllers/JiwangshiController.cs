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

        

        

    }
}