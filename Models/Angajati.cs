//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Web;

    public partial class Angajati
    {
        public int Id { get; set; }

        public byte[] Poza { get; set; }

        //[Required(ErrorMessage = "Poza este obligatorie.")]

        public HttpPostedFileBase ImageFile { get; set; }



        [Required(ErrorMessage = "Numele este obligatoriu.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Numele trebuie să conțină doar litere.")]
        public string Nume { get; set; }



        [Required(ErrorMessage = "Prenumele este obligatoriu.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Numele trebuie să conțină doar litere.")]
        public string Prenume { get; set; }



        [Required(ErrorMessage = "Funcția este obligatorie.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Numele trebuie să conțină doar litere.")]
        public string Funcție { get; set; }



        [RegularExpression(@"^\d+(\,\d+)?$", ErrorMessage = "Salariul trebuie să conțină doar cifre și poate avea o singură virgulă pentru zecimale.")]
        [Required(ErrorMessage = "Locul este obligatoriu.")]
        public decimal Salariu_de_baza { get; set; }


        [RegularExpression(@"^\d+(\,\d+)?$", ErrorMessage = "Salariul trebuie să conțină doar cifre și poate avea o singură virgulă pentru zecimale.")]
        [Display(Name = "Spor (%)")]
        [Range(0, 100, ErrorMessage = "Sporul trebuie să fie între 0 și 100")]
        [Required(ErrorMessage = "Locul este obligatoriu.")]
        public Nullable<decimal> Spor { get; set; }



        [RegularExpression(@"^\d+(\,\d+)?$", ErrorMessage = "Salariul trebuie să conțină doar cifre și poate avea o singură virgulă pentru zecimale.")]
        [Required(ErrorMessage = "Locul este obligatoriu.")]
        public Nullable<decimal> Premii_brute { get; set; }



        [RegularExpression(@"^\d+(\,\d+)?$", ErrorMessage = "Salariul trebuie să conțină doar cifre și poate avea o singură virgulă pentru zecimale.")]
        [Required(ErrorMessage = "Locul este obligatoriu.")]
        public Nullable<decimal> Rețineri { get; set; }


        public decimal Salariu_net { get; set; }


        public int ImpozitTableId { get; set; }
        public ImpozitTable Impozit { get; set; }
    }
}