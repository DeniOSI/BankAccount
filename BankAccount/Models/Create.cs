using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankAccount.Models
{
    public class Create : IUser
    {
       
        public Account Account { get; set; }

        [Required]
        [Display(Name = "Ф.И.О")]
        [MaxLength(50, ErrorMessage = "Превышен допустимый размер поля")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Паспортные данные")]
        [MaxLength(50, ErrorMessage = "Превышен допустимый размер поля")]
        public string Passport { get; set; }

        [Display(Name = "Адрес")]
        [MaxLength(50, ErrorMessage ="Превышем максимальный размер поля")]
        public string Address { get; set; }

        [Display(Name= "Дата рождения в диапазоне 1700, 2000")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd.MM.yyyy}", ApplyFormatInEditMode=true)]
       
        public DateTime Bday { get ; set ; }

        [Required]
        [Display(Name = "Логин")]
        [StringLength(15, ErrorMessage = "Максимальная длина поля 15 символов")]
        
        public string Login { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Повторить пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get ; set ; }

        [Display(Name = "Дата регистрации")]
        [DataType(DataType.Date)]
      
        public DateTime DateRegistration { get ; set ; }

        [Required]
        [Display(Name ="Адресс электронной почты")]
        [DataType(DataType.EmailAddress)]
       
        public string Email { get ; set ; }

        [Required]
        [Display(Name = "Идентификационный номер")]
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Некоректный ИН")]
        public int INN { get ; set ; }

        [Required]
        [Display(Name = "Тип валюты")]
        public int CurrencyId { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"[7]{10}")]
        [Display(Name ="Номер телефона")]
        public string Phone { get ; set; }


       
        
    }
}