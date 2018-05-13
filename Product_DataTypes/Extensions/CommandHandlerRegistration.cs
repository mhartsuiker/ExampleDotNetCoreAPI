using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Product.Contracts.Decorators;
using Product.Contracts.Interfaces;

namespace Product.DataAccess.CommandHandlers
{
    /// <summary>
    /// Static class to aid .Net Core DI in handling decorator pattern, wrapping the TCommandHandler in a
    /// LoggingCommandHandler
    /// See https://medium.com/@willie.tetlow/net-core-dependency-injection-decorator-workaround-664cd3ec1246
    /// </summary>
    public static class CommandHandlerRegistration
    {
        public static IServiceCollection RegisterCommandHandler<TCommandHandler, TCommand>(this IServiceCollection services)
            where TCommandHandler : class, ICommandHandler<TCommand>
        {
            services.AddTransient<TCommandHandler>();
            services.AddTransient<ICommandHandler<TCommand>>(x =>
                new LoggingCommandHandler<TCommand>(x.GetService<ILogger<TCommand>>(), x.GetService<TCommandHandler>()));
            return services;
        }
    }
}
