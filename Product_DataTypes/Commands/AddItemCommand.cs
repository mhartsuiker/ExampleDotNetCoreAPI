using MassTransit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.Contracts.Commands
{
    public class AddItemCommand
    {
        public AddItemCommand(string name, string shortDescription, string longDescription, double itemPrice)
        {
            Name = name;
            ShortText = shortDescription;
            LongText = longDescription;
            ItemPrice = itemPrice;
        }

        public Guid ItemId { get; set; } = NewId.NextGuid();

        [Required]
        public string Name { get; set; }

        public Guid ItemDescriptionId { get; set; } = NewId.NextGuid();

        [Required]
        public string ShortText { get; set; }

        public string LongText { get; set; }

        public Guid ItemPriceId { get; set; } = NewId.NextGuid();

        [Required]
        public double ItemPrice { get; set; }
    }
}
