using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrmWeb.Models
{
    #region 健康信息添加模型
    public class HealthAddViewModel
    {
        [Required]
        [Display(Name = "姓名")]
        public int HealthUserId { get; set; }
        [Required]
        [Display(Name = "血型")]
        public string HealthXuexing { get; set; }
        [Required]
        [Display(Name = "血型RH阴性")]
        public string HealthRH { get; set; }
        [Required]
        [Display(Name = "医疗费用支付方式")]
        public string HealthFeiyong { get; set; }
        [Required]
        [Display(Name = "药物过敏史")]
        public string HealthGuomin { get; set; }
        [Required]
        [Display(Name = "暴露史")]
        public string HealthBaolou { get; set; }
        [Required]
        [Display(Name = "【既往史】疾病")]
        public string HealthJibing { get; set; }
        [Required]
        [Display(Name = "【既往史】手术")]
        public string HealthShoushu { get; set; }
        [Required]
        [Display(Name = "【既往史】外伤")]
        public string HealthWaishang { get; set; }
        [Required]
        [Display(Name = "【既往史】输血")]
        public string HealthShuxue { get; set; }
        [Required]
        [Display(Name = "【家族史】父亲")]
        public string HealthJiazuDady { get; set; }
        [Required]
        [Display(Name = "【家族史】母亲")]
        public string HealthJiazuMama { get; set; }
        [Required]
        [Display(Name = "【家族史】兄弟姐妹")]
        public string HealthJiazuXiongdi { get; set; }
        [Required]
        [Display(Name = "【家族史】子女")]
        public string HealthJiazuZinv { get; set; }
        [Required]
        [Display(Name = "遗传病史")]
        public string HealthYichuan { get; set; }
        [Required]
        [Display(Name = "残疾情况")]
        public string HealthCanji { get; set; }
        [Required]
        [Display(Name = "【生活环境】厨房排风设施")]
        public string HealthChufang { get; set; }
        [Required]
        [Display(Name = "【生活环境】燃料类型")]
        public string HealthRanliao { get; set; }
        [Required]
        [Display(Name = "【生活环境】饮水")]
        public string HealthYinshui { get; set; }
        [Required]
        [Display(Name = "【生活环境】厕所")]
        public string HealthCesuo { get; set; }
        [Required]
        [Display(Name = "【生活环境】禽畜栏")]
        public string HealthQichulan { get; set; }
    }
    #endregion

    #region 健康信息更新模型
    public class HealthEditViewModel
    {
        [Required]
        [Display(Name = "姓名")]
        public int HealthUserId { get; set; }
        [Required]
        [Display(Name = "血型")]
        public string HealthXuexing { get; set; }
        [Required]
        [Display(Name = "血型RH阴性")]
        public string HealthRH { get; set; }
        [Required]
        [Display(Name = "医疗费用支付方式")]
        public string HealthFeiyong { get; set; }
        [Required]
        [Display(Name = "药物过敏史")]
        public string HealthGuomin { get; set; }
        [Required]
        [Display(Name = "暴露史")]
        public string HealthBaolou { get; set; }
        [Required]
        [Display(Name = "【既往史】疾病")]
        public string HealthJibing { get; set; }
        [Required]
        [Display(Name = "【既往史】手术")]
        public string HealthShoushu { get; set; }
        [Required]
        [Display(Name = "【既往史】外伤")]
        public string HealthWaishang { get; set; }
        [Required]
        [Display(Name = "【既往史】输血")]
        public string HealthShuxue { get; set; }
        [Required]
        [Display(Name = "【家族史】父亲")]
        public string HealthJiazuDady { get; set; }
        [Required]
        [Display(Name = "【家族史】母亲")]
        public string HealthJiazuMama { get; set; }
        [Required]
        [Display(Name = "【家族史】兄弟姐妹")]
        public string HealthJiazuXiongdi { get; set; }
        [Required]
        [Display(Name = "【家族史】子女")]
        public string HealthJiazuZinv { get; set; }
        [Required]
        [Display(Name = "遗传病史")]
        public string HealthYichuan { get; set; }
        [Required]
        [Display(Name = "残疾情况")]
        public string HealthCanji { get; set; }
        [Required]
        [Display(Name = "【生活环境】厨房排风设施")]
        public string HealthChufang { get; set; }
        [Required]
        [Display(Name = "【生活环境】燃料类型")]
        public string HealthRanliao { get; set; }
        [Required]
        [Display(Name = "【生活环境】饮水")]
        public string HealthYinshui { get; set; }
        [Required]
        [Display(Name = "【生活环境】厕所")]
        public string HealthCesuo { get; set; }
        [Required]
        [Display(Name = "【生活环境】禽畜栏")]
        public string HealthQichulan { get; set; }

        public int HealthId { get; set; }
    }
    #endregion
}