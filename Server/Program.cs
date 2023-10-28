using Contracts.Repository;
using Contracts.Services;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => 
    //allows enums to showed as strings in swagger
        options.JsonSerializerOptions.Converters.Add( new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddScoped<IFileUploadService, CloudinaryFileUploadService>();
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    //whatever Db is used here wtih Efcoe
    options.UseCosmos(accountEndpoint: "https://localhost:8081",
        accountKey: "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
        databaseName: "CapitalPlacementRevision");
});
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
