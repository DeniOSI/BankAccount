using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankAccount.Models
{
    public class Operation
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Название операции")]
        [MaxLength(50, ErrorMessage ="Превышенна максимальная длина строки")]
        public string Name { get; set; }

        [Display(Name="Дата операции")]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required]
        [Display(Name = "Сумма операции")]
        public double Money { get; set; }

        [Required]
        [Display(Name ="Номер целевого счета")]
        public int NumberAccount { get; set; }

        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}