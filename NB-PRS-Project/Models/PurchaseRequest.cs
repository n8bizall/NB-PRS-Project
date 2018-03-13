using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static NB_PRS_Project.Models.Product;

namespace NB_PRS_Project.Models
{
    public class PurchaseRequest
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(255)]
        [Required]
        public string Justification { get; set; }

        [Required]           
        public string  DeliveryMode { get; set; }

        [Required]
        [StringLength(25)]
        public string Status { get; set; }

        [DecimalPrecision(10, 2)]
        public decimal Total { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Active { get; set; }

        public string ReasonForRejection { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getutcdate()")]
        [Required]
        public DateTime? DateCreated { get; set; }

       // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateUpdated { get; set; }

        public int? UpdatedByUser { get; set; }

        public virtual User User { get; set; }
        
        public virtual List<PurchaseRequestLineItem> prliList { get; set; }
    }
}