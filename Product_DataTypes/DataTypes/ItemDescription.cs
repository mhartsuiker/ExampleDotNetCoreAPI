using MassTransit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Product.Contracts.DataTypes
{
    public class ItemDescription
    {
        [Key]
        [Required]
        public Guid ItemDescriptionId { get; set; } = NewId.NextGuid();

        [Required]
        public string ShortText { get; set; }

        public string LongText { get; set; }
    }
}
