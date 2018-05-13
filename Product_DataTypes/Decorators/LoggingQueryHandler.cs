using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Product.Contracts.Interfaces;
using System;

namespace Product.Contracts.Decorators
{
    /// <summary>
    /// Static class to aid .Net Core DI in handling decorator pattern, wrapping the TQueryHandler in a
    /// LoggingQueryHandler
    /// See https://medium.com/@willie.tetlow/net-core-dependency-injection-decorator-workaround-664cd3ec1246
    /// </summary>
    public class LoggingQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> _decorated;
        private readonly ILogger<TQuery> _logger;

        public LoggingQueryHandler(ILogger<TQuery> logger, IQueryHandler<TQuery, TResult> decorated)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
        }

        public TResult Handle(TQuery query)
        {
            _logger.LogDebug($"Query <{typeof(TQuery)}> called, <{JsonConvert.SerializeObject(query)}>.");
            var result = _decorated.Handle(query);
            _logger.LogDebug($"Query result: {JsonConvert.SerializeObject(result)}.");
            return result;
        }
    }
}
