using NetCore.Application.Application;
using NetCore.Application.Interfaces;
using NetCore.Application.Mapper;
using NetCore.Domain.Common;
using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Repositories.DataConnector;
using NetCore.Domain.Services;
using NetCore.Infra.DataConnector;
using NetCore.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Add-Controllers

builder.Services.AddControllers();


//Add-Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add-AutoMapper
builder.Services.AddAutoMapper(typeof(Core));


//Add-Conexão BD
string connectionString = builder.Configuration.GetConnectionString("OliConnection");
builder.Services.AddScoped<IDbConnector>(db => new SqlConnector(connectionString));


//Add-Dependency injection All
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IGeneretors, Generetors>();
builder.Services.AddScoped<ITimeProvider, TimeProvider>();

builder.Services.AddScoped<IClientApplication, ClientApplication>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();