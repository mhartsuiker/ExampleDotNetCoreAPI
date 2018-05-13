using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Product.Contracts.Decorators;
using Product.Contracts.Interfaces;

namespace Product.Contracts.Extensions
{
    public static class QueryHandlerRegistration
    {
        public static IServiceCollection RegisterQueryHandler<TQueryHandler, TQuery, TResult>(this IServiceCollection services) 
            where TQuery: IQuery<TResult> 
            where TQueryHandler: class, IQueryHandler<TQuery, TResult>
        {
            services.AddTransient<TQueryHandler>();
            services.AddTransient<IQueryHandler<TQuery, TResult>>(x =>
                new LoggingQueryHandler<TQuery, TResult>(x.GetService<ILogger<TQuery>>(), x.GetService<TQueryHandler>()));
            return services;
        }
    }
}
