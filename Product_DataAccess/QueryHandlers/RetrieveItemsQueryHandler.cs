using Microsoft.EntityFrameworkCore;
using Product.Contracts.DataTypes;
using Product.Contracts.Interfaces;
using Product.Contracts.Queries;
using System.Collections.Generic;
using System.Linq;

namespace Product.DataAccess.QueryHandlers
{
    public class RetrieveItemsQueryHandler: IQueryHandler<RetrieveItemsQuery, IList<Item>>
    {
        private readonly ProductDataContext _context;

        public RetrieveItemsQueryHandler(ProductDataContext context)
        {
            _context = context;
        }

        public IList<Item> Handle(RetrieveItemsQuery query)
        {
            using (var db = _context)
            {
                return db.Item
                    .Include(i => i.Description)
                    .Include(i => i.Price)
                    .ToList();
            }
        }
    }
}
