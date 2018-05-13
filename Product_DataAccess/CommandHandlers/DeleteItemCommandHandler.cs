using Product.Contracts.Commands;
using Product.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product.DataAccess.CommandHandlers
{
    public class DeleteItemCommandHandler: ICommandHandler<DeleteItemCommand>
    {
        private readonly ProductDataContext _context;

        public DeleteItemCommandHandler(ProductDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Handle(DeleteItemCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            using (var db = _context)
            {
                var itemToDelete = db.Item.SingleOrDefault(i => i.ItemId == command.ItemId);
                db.Item.Remove(itemToDelete);
                db.SaveChanges();
            }
        }
    }
}
