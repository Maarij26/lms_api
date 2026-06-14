using FluentValidation;
using LibraryManagementSystemAPI.Data;
using LibraryManagementSystemAPI.Repositories;
using LibraryManagementSystemAPI.Services;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystemAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Registering the dbcontext from sql connection string from appsettings.json
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")));
//Registering the repostiory to be injected in the service layer
builder.Services.AddScoped<IBookRepository, BookRepository>();
//Registering the services
builder.Services.AddScoped<IBookService, BookService>();

//It scans and registers all validators in the project automatically.
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookValidator>();


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
