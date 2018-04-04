using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NB_PRS_Project.Models
{
    public class Vendor
    {
        public int Id { get; set; }
     
        [Required]
        [Index(IsUnique = true)]
        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        [Required]
        public string Address { get; set; }

        [StringLength(255)]
        [Required]
        public string City { get; set; }

        [StringLength(2)]
        [Required]
        public string State { get; set; }

        [StringLength(5)]
        [Required]
        public string Zip { get; set; }

        [StringLength(12)]
        [Required]
        public string Phone { get; set; }

        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool IsPreApproved { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public DateTime? DateCreated { get; set; }
        
        public DateTime? DateUpdated { get; set; }

        [Required]
        public int? UpdatedByUser { get; set; }


    }
}