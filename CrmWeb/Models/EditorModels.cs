using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrmWeb.Models
{
    #region 网站管理员登陆模型
    public class EditorLoginViewModel
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
    public class EditorAddViewModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string EditorUserName { get; set; }

        [Required]
        [Display(Name = "姓名")]
        public string EditorRealName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string EditorPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("EditorPassword", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    
    }
    #endregion

    #region 网站管理员更新模型
    public class EditorEditViewModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string EditorUserName { get; set; }

        [Required]
        [Display(Name = "姓名")]
        public string EditorRealName { get; set; }

        public int EditorId { get; set; }

        

    }
    #endregion

}