using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Contracts.Commands;
using Product.Contracts.DataTypes;
using Product.Contracts.Extensions;
using Product.Contracts.Queries;
using Product.DataAccess;
using Product.DataAccess.CommandHandlers;
using Product.DataAccess.QueryHandlers;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace Product.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure localdb
            services.AddDbContext<ProductDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProductDataContext")));

            // Registration of QueryHandlers is handled by the static QueryHandlerRegistration class in the
            // the Product.Contracts project
            services.RegisterQueryHandler<RetrieveItemsQueryHandler, RetrieveItemsQuery, IList<Item>>();
            services.RegisterQueryHandler<RetrieveItemByIdQueryHandler, RetrieveItemByIdQuery, Item>();

            // Registration of CommandHandlers is handled by the static CommandHandlerRegistration class in the
            // the Product.Contracts project
            services.RegisterCommandHandler<AddItemCommandHandler, AddItemCommand>();
            services.RegisterCommandHandler<EditItemCommandHandler, EditItemCommand>();
            services.RegisterCommandHandler<DeleteItemCommandHandler, DeleteItemCommand>();

            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Product API", Version = "v1" });
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to server the Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API");
            });

            app.UseMvc();
        }
    }
}
