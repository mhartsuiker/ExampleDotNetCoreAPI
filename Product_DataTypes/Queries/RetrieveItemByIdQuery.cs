using Product.Contracts.DataTypes;
using Product.Contracts.Interfaces;
using System;

namespace Product.Contracts.Queries
{
    public class RetrieveItemByIdQuery: IQuery<Item>
    {
        public RetrieveItemByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
