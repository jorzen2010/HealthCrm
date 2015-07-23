using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrmWeb.Models
{
   

    #region 单位添加模型
    public class GroupAddViewModel
    {
        [Required]
        [Display(Name = "单位名称")]
        public string GroupName { get; set; }

        [Required]
        [Display(Name = "单位简介")]
        public string GroupInfo { get; set; }

       
    
    }
    #endregion

    #region 单位更新模型
    public class GroupEditViewModel
    {
        [Required]
        [Display(Name = "单位名称")]
        public string GroupName { get; set; }

        [Required]
        [Display(Name = "单位简介")]
        public string GroupInfo { get; set; }


        public int GroupId { get; set; }

        

    }
    #endregion

}