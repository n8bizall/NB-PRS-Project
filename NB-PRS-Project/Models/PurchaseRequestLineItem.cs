using System;
using System.Collections.Generic;
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
        [Index(IsUnique = true)]
        public int PurchaseRequestId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [DecimalPrecision(10, 2)]
        public decimal Price { get; set; }

        [Required]
        [DecimalPrecision(10, 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal LineTotal
        { get; set; }
        //TODO make system calculate

        public virtual PurchaseRequest PurchaseRequest { get; set; }

        public virtual Product Product { get; set; }

    }
}