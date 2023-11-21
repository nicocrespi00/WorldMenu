using BackendWM.Data;
using BackendWM.Entities;
using Core.Mapper;
using Core.Services;
using Core.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WorldMenuContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddAutoMapper(typeof(IngredienteMapper));
builder.Services.AddAutoMapper(typeof(PaisMapper));
builder.Services.AddAutoMapper(typeof(PlatoMapper));
builder.Services.AddValidatorsFromAssemblyContaining<IngredienteValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<PaisValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<PlatoValidator>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


builder.Services.AddTransient<IngredienteServicio>();
builder.Services.AddTransient<PaisServicio>();
builder.Services.AddTransient<PlatoServicio>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("AllowAngularDev");

app.UseAuthorization();

app.MapControllers();

app.Run();
