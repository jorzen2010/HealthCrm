using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrmWeb.Models
{
   

    #region 用户归档添加模型
    public class UserClassAddViewModel
    {
        [Required]
        [Display(Name = "用户归档")]
        public string UserClassName { get; set; }

      
       
    
    }
    #endregion

    #region 用户归档更新模型
    public class UserClassEditViewModel
    {
        [Required]
        [Display(Name = "用户归档")]
        public string UserClassName { get; set; }

        public int UserClassId { get; set; }

        

    }
    #endregion

}