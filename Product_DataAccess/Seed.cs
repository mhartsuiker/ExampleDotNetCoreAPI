using MassTransit;
using Microsoft.EntityFrameworkCore;
using Product.Contracts.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product.DataAccess
{
    public class Seed
    {
        private ProductDataContext _context;

        public Seed(ProductDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Generate()
        {
            if (!_context.Item.Any())
            {
                _context.Add<Item>(new Item
                {
                    ItemId = NewId.NextGuid(),
                    Name = "Item 1",
                    Description = new ItemDescription
                    {
                        ItemDescriptionId = NewId.NextGuid(),
                        ShortText = "Item description 1",
                        LongText = "This is the long description"
                    },
                    Price = new ItemPrice
                    {
                        ItemPriceId = NewId.NextGuid(),
                        Value = 1.00
                    }
                });
                _context.Add<Item>(new Item
                {
                    ItemId = NewId.NextGuid(),
                    Name = "Item 2",
                    Description = new ItemDescription
                    {
                        ItemDescriptionId = NewId.NextGuid(),
                        ShortText = "Item description 2",
                        LongText = "This is the long description"
                    },
                    Price = new ItemPrice
                    {
                        ItemPriceId = NewId.NextGuid(),
                        Value = 2.00
                    }
                });
            }
            _context.SaveChanges();
        }
    }
}
