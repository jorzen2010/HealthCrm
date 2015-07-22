using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CrmWeb.Models
{
    
    #region 模块添加模型
    public class UserAddViewModel
    {
        [Display(Name = "用户密码")]
        public string UserPassword { get; set; }
        [RegularExpression("^[\u4E00-\u9FA5]{2,4}$", ErrorMessage = "姓名必须是2-4个汉字")]
        [StringLength(4, MinimumLength = 2, ErrorMessage = "姓名必须是2-4个汉字")]
        [Required]
        [Display(Name = "姓名*")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "性别*")]
        public string UserSex { get; set; }
        [Required]
        [Display(Name = "出生日期*")]
        public DateTime UserBirthday { get; set; }
        [Required]
        [Display(Name = "身份证号码*")]
        public string UserNumber { get; set; }
        [Required]
        [Display(Name = "本人电话*")]
        public string UserTel { get; set; }
        [RegularExpression("^[\u4E00-\u9FA5]{2,4}$", ErrorMessage = "姓名必须是2-4个汉字")]
        [StringLength(4, MinimumLength = 2, ErrorMessage = "姓名必须是2-4个汉字")]
        [Required]
        [Display(Name = "联系人姓名*")]
        public string UserFirstPerson { get; set; }
        [Required]
        [Display(Name = "联系人电话*")]
        public string UserFirstPersonTel { get; set; }
        [Display(Name = "乡镇（街道）名称")]
        public string UserJiedaoName { get; set; }
        [Display(Name = "村（居）委会名称")]
        public string UserJuweihuiName { get; set; }
        [Display(Name = "常住类型*")]
        public string UserHuji { get; set; }
        [Display(Name = "民族*")]
        public string UserMinzu { get; set; }
        [Display(Name = "文化程度*")]
        public string UserWenhua { get; set; }
        [Display(Name = "职业*")]
        public string UserZhiye { get; set; }
        [Display(Name = "婚姻状况*")]
        public string UserHunyin { get; set; }
        
        [Display(Name = "责任医生")]
        public int UserDoctor { get; set; }
        [Display(Name = "所属组织")]
        public int UserGroup { get; set; }
        [Required]
        [Display(Name = "用户归档")]
        public string UserClass { get; set; }       
        [Display(Name = "现住址")]
        public string UserNowAddress { get; set; }
        [Display(Name = "户籍地址")]
        public string UserOldAddress { get; set; }
        [Display(Name = "工作单位")]
        public string UserJobGroup { get; set; }

        [Display(Name = "备注")]
        public string UserBeizhu { get; set; }

        [Display(Name = "自定义1")]
        public string UserDiy1 { get; set; }
        [Display(Name = "自定义2")]
        public string UserDiy2 { get; set; }
        [Display(Name = "自定义3")]
        public string UserDiy3 { get; set; }
        [Display(Name = "自定义4")]
        public string UserDiy4 { get; set; }
        [Display(Name = "自定义5")]
        public string UserDiy5 { get; set; }
        [Display(Name = "自定义6")]
        public string UserDiy6 { get; set; }
    
    }
    #endregion

    #region 模块添加模型
    public class UserEditViewModel
    {
        [Required]
        [Display(Name = "用户Id")]
        public int UserId { get; set; }
        [Display(Name = "用户密码")]
        public string UserPassword { get; set; }
        [RegularExpression("^[\u4E00-\u9FA5]{2,4}$", ErrorMessage = "姓名必须是2-4个汉字")]
        [StringLength(4, MinimumLength = 2, ErrorMessage = "姓名必须是2-4个汉字")]
        [Required]
        [Display(Name = "姓名")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "性别")]
        public string UserSex { get; set; }
        [Required]
        [Display(Name = "出生日期")]
        public DateTime UserBirthday { get; set; }
        [Required]
        [Display(Name = "身份证号码")]
        public string UserNumber { get; set; }
        [Required]
        [Display(Name = "本人电话")]
        public string UserTel { get; set; }
        [RegularExpression("^[\u4E00-\u9FA5]{2,4}$", ErrorMessage = "姓名必须是2-4个汉字")]
        [StringLength(4, MinimumLength = 2, ErrorMessage = "姓名必须是2-4个汉字")]
        [Required]
        [Display(Name = "联系人姓名")]
        public string UserFirstPerson { get; set; }
        [Required]
        [Display(Name = "联系人电话")]
        public string UserFirstPersonTel { get; set; }
        [Display(Name = "乡镇（街道）名称")]
        public string UserJiedaoName { get; set; }
        [Display(Name = "村（居）委会名称")]
        public string UserJuweihuiName { get; set; }
        [Display(Name = "常住类型")]
        public string UserHuji { get; set; }
        [Display(Name = "民族")]
        public string UserMinzu { get; set; }
        [Display(Name = "文化程度")]
        public string UserWenhua { get; set; }
        [Display(Name = "职业")]
        public string UserZhiye { get; set; }
        [Display(Name = "婚姻状况")]
        public string UserHunyin { get; set; }
        [Display(Name = "责任医生")]
        public int UserDoctor { get; set; }
        [Display(Name = "所属组织")]
        public int UserGroup { get; set; }
        [Required]
        [Display(Name = "用户归档")]
        public string UserClass { get; set; }
        [Display(Name = "现住址")]
        public string UserNowAddress { get; set; }
        [Display(Name = "户籍地址")]
        public string UserOldAddress { get; set; }
        [Display(Name = "工作单位")]
        public string UserJobGroup { get; set; }

        [Display(Name = "备注")]
        public string UserBeizhu { get; set; }

        [Display(Name = "自定义1")]
        public string UserDiy1 { get; set; }
        [Display(Name = "自定义2")]
        public string UserDiy2 { get; set; }
        [Display(Name = "自定义3")]
        public string UserDiy3 { get; set; }
        [Display(Name = "自定义4")]
        public string UserDiy4 { get; set; }
        [Display(Name = "自定义5")]
        public string UserDiy5 { get; set; }
        [Display(Name = "自定义6")]
        public string UserDiy6 { get; set; }
    

    }
    #endregion
   

}