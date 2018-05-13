using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Product.Contracts.Interfaces;
using System;

namespace Product.Contracts.Decorators
{
    public class LoggingCommandHandler<TCommand>: ICommandHandler<TCommand>
    {
        private readonly ILogger<TCommand> _logger;
        private readonly ICommandHandler<TCommand> _decorated;
 
        public LoggingCommandHandler(ILogger<TCommand> logger, ICommandHandler<TCommand> decorated)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
        }

        public void Handle(TCommand command)
        {
            _logger.LogDebug($"Command <{typeof(TCommand)}> called, <{JsonConvert.SerializeObject(command)}>.");
            _decorated.Handle(command);
        }
    }
}
