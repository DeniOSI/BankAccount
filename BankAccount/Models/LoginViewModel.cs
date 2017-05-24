using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankAccount.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        [MaxLength(50, ErrorMessage ="Превышен допустимый размер")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [MaxLength(50, ErrorMessage = "Превышен допустимый размер")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Запомнить меня?")]
        public bool Remember { get; set; }

    }
}