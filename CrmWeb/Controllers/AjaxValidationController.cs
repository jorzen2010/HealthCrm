using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace CrmWeb.Controllers
{
    public class AjaxValidationController : Controller
    {
        //
        // GET: /AjaxValidation/
        public JsonResult ValidateIDCardNo(string UserNumber)
        {
            return Json(CommonTools.Verify(UserNumber), JsonRequestBehavior.AllowGet);
        }
	}


}