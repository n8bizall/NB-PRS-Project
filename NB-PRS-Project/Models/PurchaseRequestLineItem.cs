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
    public class PurchaseRequestLineItem
    {
        public int Id { get; set; }

        [Required]
        public int PurchaseRequestId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    
        [DefaultValue(true)]
        public bool Active { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public int UpdatedByUser { get; set; }

        [JsonIgnore]
        public virtual PurchaseRequest PurchaseRequest { get; set; }

        public virtual Product Product { get; set; }

      
    }
}