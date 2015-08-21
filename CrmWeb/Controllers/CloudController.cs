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
            CloudHealthDto cloudHealthDto = new CloudHealthDto();
            cloudHealthDto.CloudTel = tel;
            cloudHealthDto.CloudDiya = dia;
            cloudHealthDto.CloudGaoya = sys;
            cloudHealthDto.CloudMaibo = pul;
            cloudHealthDto.CloudUser = user;
            cloudHealthDto.CloudImei = imei;
            cloudHealthDto.CloudTime = System.DateTime.Now;

            CloudHealthBll.AddCloudHealth(cloudHealthDto);


            return Content("添加成功");
        }
	}
}