//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnTap_LTDN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Diem
    {
        [Required]
        [Key, Column(Order = 0)]
        public int masv { get; set; }
        [Key, Column(Order = 1)]
        [Required]
        public string tenmh { get; set; }
        [Range(0,10)]
        [Required]
        public Nullable<decimal> diem1 { get; set; }
    
        public virtual SinhVien SinhVien { get; set; }
    }
}
