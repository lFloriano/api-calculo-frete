using CalculoFrete.Api.Configurations;
using CalculoFrete.Api.Configurations.AutoMapper;
using CalculoFrete.Core.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<ExceptionFilter>());
builder.AddSwagger(); ;
builder.AddAutoMapper();
builder.Services.RegisterServices();

var app = builder.Build();

app.SeedData();

if (app.Environment.IsDevelopment())
{
    app.UsarSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
