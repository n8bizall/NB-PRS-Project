using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NB_PRS_Project.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        [StringLength(50)]
        public string PartNumber { get; set; }

        [StringLength(150)]
        [Required]
        public string Name { get; set; }

     
        [DecimalPrecision(10, 2)]            //see selaed class info below
        public decimal Price { get; set; }

        [Required]
        [StringLength(255)]
        public string Unit { get; set; }

        [StringLength(255)]
        public string PhotoPath { get; set; }

      
        [DefaultValue(true)]
        public bool Active { get; set; }

        public DateTime? DateCreated { get; set; }

      
        public DateTime? DateUpdated { get; set; }

       
        public int? UpdatedByUser { get; set; }

        public virtual Vendor Vendor { get; set; }


        //this is how i am seeting decimal values
        [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
        public sealed class DecimalPrecisionAttribute : Attribute
        {
            public DecimalPrecisionAttribute(byte precision, byte scale)
            {
                Precision = precision;
                Scale = scale;

            }

            public byte Precision { get; set; }
            public byte Scale { get; set; }

        }



    }
}