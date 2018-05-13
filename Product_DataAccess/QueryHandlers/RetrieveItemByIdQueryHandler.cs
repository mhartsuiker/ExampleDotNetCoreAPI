using Microsoft.EntityFrameworkCore;
using Product.Contracts.DataTypes;
using Product.Contracts.Interfaces;
using Product.Contracts.Queries;
using System;
using System.Linq;

namespace Product.DataAccess.QueryHandlers
{
    public class RetrieveItemByIdQueryHandler: IQueryHandler<RetrieveItemByIdQuery, Item>
    {
        private readonly ProductDataContext _context;

        public RetrieveItemByIdQueryHandler(ProductDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Item Handle(RetrieveItemByIdQuery query)
        {
            using (var db = _context)
            {
                return db.Item
                    .Include(i => i.Description)
                    .Include(i => i.Price)
                    .SingleOrDefault(i => i.ItemId == query.Id);
            }
        }
    }
}
