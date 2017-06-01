using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankAccount.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Display(Name ="Название счета")]
        [MaxLength(50, ErrorMessage ="Максимальная длина превышенна")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Сумма на счету")]
        public double Money { get; set; }

        [Required]
        [Display(Name = "Номер счета")]
        public int NumberAccount { get; set; }

        //[Required]
        //[Display(Name = "Тип счета")]
        //public int TypeAccountId { get; set; }
        //public TypeAccount TypeAccount { get; set; }

        public Currency Currency { get; set; }

        [Required]
        [Display(Name = "Тип валюты")]
        public int CurrencyId { get; set; }

        

        [Display(Name ="Операции на счете")]
        public ICollection<Operation> Operations { get; set; }

        public Account()
        {
            Operations = new List<Operation>();
        }

    }
}