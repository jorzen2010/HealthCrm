using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrmWeb.Models
{
    #region 网站管理员登陆模型
    public class DoctorLoginViewModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }


    }
    #endregion

    #region 网站管理员添加模型
    public class DoctorAddViewModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string DoctorUserName { get; set; }

        [Required]
        [Display(Name = "姓名")]
        public string DoctorRealName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string DoctorPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("DoctorPassword", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    
    }
    #endregion

    #region 网站管理员更新模型
    public class DoctorEditViewModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string DoctorUserName { get; set; }

        [Required]
        [Display(Name = "姓名")]
        public string DoctorRealName { get; set; }

        public int DoctorId { get; set; }

        

    }
    #endregion

}