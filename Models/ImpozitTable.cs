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

    public partial class ImpozitTable
    {
        public int Id { get; set; }

        [Required]
        public decimal CASS { get; set; }

        [Required]
        public decimal CAS { get; set; }

        [Required]
        public decimal IMPOZIT { get; set; }
    }
}