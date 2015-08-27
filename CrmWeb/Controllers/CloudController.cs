using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using QxsqBLL;
using QxsqDAL;
using QxsqDTO;

namespace CrmWeb.Controllers
{
    public class CloudController : Controller
    {
        //
        // GET: /Cloud/
        public ActionResult Index(string imei, string tel, string user, string sys, string dia, string pul)
        {
            if (string.IsNullOrEmpty(imei) || string.IsNullOrEmpty(tel) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(sys) || string.IsNullOrEmpty(dia) || string.IsNullOrEmpty(pul))
            {
                return Content("OK" + System.DateTime.Now.ToString("yyyyMMddhhmmss"));
            }
            else
            { 
            CloudHealthDto cloudHealthDto = new CloudHealthDto();
            cloudHealthDto.CloudTel = tel;
            cloudHealthDto.CloudDiya = dia;
            cloudHealthDto.CloudGaoya = sys;
            cloudHealthDto.CloudMaibo = pul;
            cloudHealthDto.CloudUser = user;
            cloudHealthDto.CloudImei = imei;
            cloudHealthDto.CloudTime = System.DateTime.Now;
            
            CloudHealthBll.AddCloudHealth(cloudHealthDto);
            }
            


            return Content("OK"+System.DateTime.Now.ToString("yyyyMMddhhmmss"));
        }
       
	}
}