using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATMWebApp.Models
{
    public class Conta
    {
        [Required]
        [Display(Name = "Numero de Conta")]
        public int Numero { get; set; }

        [Required]
        [Display(Name = "Primeiro Nome")]
        public string PrimeiroNome { get; set; }

        [Required]
        public string Apelido { get; set; }

        public decimal Saldo { get; set; } = 0;

        [Display(Name = "Data de Criação")]
        public DateTime Data { get; set; } = DateTime.Now;

    }

}