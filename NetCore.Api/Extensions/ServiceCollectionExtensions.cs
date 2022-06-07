using NetCore.Application.Application;
using NetCore.Application.Interfaces;
using NetCore.Domain.Common;
using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Repositories.DataConnector;
using NetCore.Domain.Interfaces.Service;
using NetCore.Domain.Services;
using NetCore.Infra.DataConnector;
using NetCore.Infra.Repositories;

namespace NetCore.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        //Add-Conexão BD
        string connectionString = builder.Configuration.GetConnectionString("OliConnection");
        builder.Services.AddScoped<IDbConnector>(db => new SqlConnector(connectionString));

        return builder;
    }

    public static WebApplicationBuilder AddDependencyinjection(this WebApplicationBuilder builder)
    {
        //Add-Dependency injection All
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IGeneretors, Generetors>();
        builder.Services.AddScoped<ITimeProvider, TimeProvider>();

        builder.Services.AddScoped<IClientApplication, ClientApplication>();
        builder.Services.AddScoped<IClientsService, ClientService>();
        builder.Services.AddScoped<IClientRepository, ClientRepository>();

        builder.Services.AddScoped<IOrdersApplication, OrdersApplication>();
        builder.Services.AddScoped<IOrdersService, OrdersService>();
        builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();

        builder.Services.AddScoped<IProductApplication, ProductApplication>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.Services.AddScoped<IUsersApplication, UsersApplication>();
        builder.Services.AddScoped<IUsersService, UsersService>();
        builder.Services.AddScoped<IUsersRepository, UsersRepository>();

        return builder;
    }
}