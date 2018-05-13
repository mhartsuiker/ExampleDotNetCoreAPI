using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.Contracts.Commands
{
    public class DeleteItemCommand
    {
        public DeleteItemCommand(Guid itemId)
        {
            ItemId = itemId;
        }

        [Required]
        public Guid ItemId { get; private set; }
    }
}
