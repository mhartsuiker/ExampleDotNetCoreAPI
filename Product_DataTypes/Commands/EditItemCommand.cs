using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.Contracts.Commands
{
    public class EditItemCommand
    {
        public EditItemCommand(Guid itemId, string name, string shortDescription, string longDescription, double itemPrice)
        {
            ItemId = itemId;
            Name = name;
            ShortText = shortDescription;
            LongText = longDescription;
            ItemPrice = itemPrice;
        }

        [Required]
        public Guid ItemId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortText { get; set; }

        public string LongText { get; set; }

        [Required]
        public double ItemPrice { get; set; }
    }
}
