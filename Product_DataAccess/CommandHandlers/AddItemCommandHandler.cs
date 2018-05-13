using Product.Contracts.Commands;
using Product.Contracts.DataTypes;
using Product.Contracts.Interfaces;
using System;

namespace Product.DataAccess.CommandHandlers
{
    public class AddItemCommandHandler : ICommandHandler<AddItemCommand>
    {
        private readonly ProductDataContext _context;

        public AddItemCommandHandler(ProductDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Handle(AddItemCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            using (var db = _context)
            {
                db.Item.Add(new Item
                {
                    ItemId = command.ItemId,
                    Name = command.Name,
                    Description = new ItemDescription
                    {
                        ItemDescriptionId = command.ItemDescriptionId,
                        ShortText = command.ShortText,
                        LongText = command.LongText
                    },
                    Price = new ItemPrice
                    {
                        ItemPriceId = command.ItemPriceId,
                        Value = command.ItemPrice
                    }
                });

                db.SaveChanges();
            }
        }
    }
}
