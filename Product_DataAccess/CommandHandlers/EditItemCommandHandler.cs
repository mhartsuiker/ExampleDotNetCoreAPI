using Microsoft.EntityFrameworkCore;
using Product.Contracts.Commands;
using Product.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product.DataAccess.CommandHandlers
{
    public class EditItemCommandHandler: ICommandHandler<EditItemCommand>
    {
        private readonly ProductDataContext _context;

        public EditItemCommandHandler(ProductDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Handle(EditItemCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            using (var db = _context)
            {
                var itemToEdit = db.Item.Include(i => i.Description)
                                        .Include(i => i.Price)
                                        .SingleOrDefault(i => i.ItemId == command.ItemId);

                if (itemToEdit != null)
                {
                    itemToEdit.Name = command.Name;
                    itemToEdit.Description.ShortText = command.ShortText;
                    itemToEdit.Description.LongText = command.LongText;
                    itemToEdit.Price.Value = command.ItemPrice;
                }
                db.SaveChanges();
            }
        }
    }
}
