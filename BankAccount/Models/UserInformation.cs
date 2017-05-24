using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankAccount.Models
{
    public class UserInformation
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ф.И.О.")]
        [MaxLength(50, ErrorMessage = "Превышенна максимальная длина записи")]
        public String Name { get; set; }

        
        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [MaxLength(50, ErrorMessage = "Превышенна максимальная длина записи")]
        public string Password { get; set; }

        [Required]
        [NotMapped]
        [Display(Name = "Повтор пароля")]
        [MaxLength(50, ErrorMessage = "Превышенна максимальная длина записи")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "Превышенна максимальная длина записи")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Адрес")]
        [MaxLength(50, ErrorMessage = "Превышенна максимальная длина записи")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Номер телефона")]
        [MaxLength(50, ErrorMessage = "Превышенна максимальная длина записи")]
        public string Phone { get; set; }

      
        
    }
}