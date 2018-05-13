using MassTransit;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Contracts.DataTypes
{
    public class Item
    {
        [Key]
        [Required]
        public Guid ItemId { get; set; } = NewId.NextGuid();

        [Required]
        public string Name { get; set; }

        public ItemDescription Description { get; set; }

        public ItemPrice Price { get; set; }
    }
}
