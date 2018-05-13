using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Contracts.Commands;
using Product.Contracts.DataTypes;
using Product.Contracts.Interfaces;
using Product.Contracts.Queries;

namespace Product.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class ItemsController : Controller
    {
        // Query handlers
        private readonly IQueryHandler<RetrieveItemsQuery, IList<Item>> _retrieveItemsQueryHandler;
        private readonly IQueryHandler<RetrieveItemByIdQuery, Item> _retrieveItemByIdQueryHandler;
        // Command handlers
        private readonly ICommandHandler<AddItemCommand> _addItemCommandHandler;
        private readonly ICommandHandler<EditItemCommand> _editItemCommandHandler;
        private readonly ICommandHandler<DeleteItemCommand> _deleteItemCommandHandler;

        public ItemsController(
            IQueryHandler<RetrieveItemsQuery, IList<Item>> retrieveItemsQueryHandler,
            IQueryHandler<RetrieveItemByIdQuery, Item> retrieveItemByIdQueryHandler,
            ICommandHandler<AddItemCommand> addItemCommandHandler,
            ICommandHandler<EditItemCommand> editItemCommandHandler,
            ICommandHandler<DeleteItemCommand> deleteItemCommandHandler)
        {
            _retrieveItemsQueryHandler = retrieveItemsQueryHandler ?? throw new ArgumentNullException(nameof(retrieveItemsQueryHandler));
            _retrieveItemByIdQueryHandler = retrieveItemByIdQueryHandler ?? throw new ArgumentNullException(nameof(retrieveItemByIdQueryHandler));
            _addItemCommandHandler = addItemCommandHandler ?? throw new ArgumentNullException(nameof(addItemCommandHandler));
            _editItemCommandHandler = editItemCommandHandler ?? throw new ArgumentNullException(nameof(editItemCommandHandler));
            _deleteItemCommandHandler = deleteItemCommandHandler ?? throw new ArgumentNullException(nameof(deleteItemCommandHandler));
        }

        // GET api/items
        [HttpGet]
        public IEnumerable<Item> RetrieveItems()
        {
            return _retrieveItemsQueryHandler.Handle(new RetrieveItemsQuery());
        }

        // GET api/items/01307ABC-B5BF-4437-895E-B784A7A7401C
        [HttpGet("{id}")]
        public Item RetrieveItemById(Guid id)
        {
            return _retrieveItemByIdQueryHandler.Handle(new RetrieveItemByIdQuery(id));
        }

        // Post api/items
        [HttpPost]
        public void AddItem(string itemname, string itemShortDescription, string itemLongDescription, double price)
        {
            _addItemCommandHandler.Handle(new AddItemCommand(itemname, itemShortDescription, itemLongDescription, price));
        }

        // Patch api/items
        [HttpPatch]
        public void EditItem(Guid itemId, string itemname, string itemShortDescription, string itemLongDescription, double price)
        {
            _editItemCommandHandler.Handle(new EditItemCommand(itemId, itemname, itemShortDescription, itemLongDescription, price));
        }

        // Delete api/items
        [HttpDelete]
        public void DeleteItem(Guid itemId)
        {
            _deleteItemCommandHandler.Handle(new DeleteItemCommand(itemId));
        }
    }
}