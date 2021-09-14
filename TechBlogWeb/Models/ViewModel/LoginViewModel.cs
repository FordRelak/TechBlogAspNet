using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogWeb.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Не указан логин")]
        [Display(Name ="Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }
}
