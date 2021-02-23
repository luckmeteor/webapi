using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace webapi.Models
{
    public class Common
    {
        [Required(ErrorMessage ="f1为必填字段")]
        [MinLength(4,ErrorMessage ="最小长度为4")]
        public string filed1 { get; set; }
        [StringLength(5,ErrorMessage ="最大长度为5")]
        public string filed2 { get; set; }
        [Range(1,100)]
        public int filed3 { get; set; }
        [RegularExpression(@"^13[0-9]{9}$|14[0-9]{9}|15[0-9]{9}$|16[0-9]{9}$|17[0-9]{9}$|18[0-9]{9}$|19[0-9]{9}$",ErrorMessage = "The Value is not a phone number type")]
        public string phone { get; set; }
        public string filed5 { get; set; }
    }
}