using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankAccount.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Ф.И.О.")]
        [MaxLength(50, ErrorMessage ="Превышенна максимальная длина записи")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Логин")]
        [MaxLength(50, ErrorMessage = "Превышенна максимальная длина записи")]
        public string Login { get; set; }

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

        [Required]
        [Display(Name = "Номер и серия паспорта")]
        [MaxLength(30, ErrorMessage = "Превышенна максимальная длина записи")]
        public string Passport { get; set; }

        [Required]
        [Display(Name = "идентификационный код")]
        public int INN { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd/mm/yyyy}", ApplyFormatInEditMode =true)]
        [DataType(DataType.Date)]
        public DateTime Bday { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateRegistration { get; set; }

        [Required]
        [Display(Name = "Тип учетной записи")]
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        [Required]
        [Display(Name = "Статус")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Required]
        [Display(Name = "Аккаунт")]
        public int? AccountId { get; set; }
        public Account Account { get; set; }



    }
}