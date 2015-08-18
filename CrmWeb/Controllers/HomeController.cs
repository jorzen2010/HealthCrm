using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrmWeb.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
           // return View();
            return RedirectToAction("UserIndex", "User", new { groupId = 0, userClass = 0, doctorId = System.Web.HttpContext.Current.Request.Cookies["DoctorId"].Value });

        }

        
    }
}