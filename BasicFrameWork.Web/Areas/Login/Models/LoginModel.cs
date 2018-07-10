using System.ComponentModel.DataAnnotations;

namespace BasicFramework.Web.Areas.Login.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "必填")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "必填")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }
    }
}