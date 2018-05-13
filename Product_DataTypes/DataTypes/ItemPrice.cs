using MassTransit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Product.Contracts.DataTypes
{
    public class ItemPrice
    {
        [Key]
        [Required]
        public Guid ItemPriceId { get; set; } = NewId.NextGuid();

        [Required]
        public double Value { get; set; }
    }
}
