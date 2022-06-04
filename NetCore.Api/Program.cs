using NetCore.Application.Application;
using NetCore.Application.Interfaces;
using NetCore.Application.Mapper;
using NetCore.Domain.Interfaces.Repositories;
using NetCore.Domain.Interfaces.Repositories.DataConnector;
using NetCore.Domain.Services;
using NetCore.Infra.DataConnector;
using NetCore.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// AddAutoMapper
builder.Services.AddAutoMapper(typeof(Core));

//Conexão com o banco de dados
string connectionString = builder.Configuration.GetConnectionString("OliConnection");

builder.Services.AddScoped<IDbConnector>(db => new SqlConnector(connectionString));

//Dependency injection UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Dependency injection All
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