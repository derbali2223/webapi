using Exercices10.Models;
using Exercices10.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<derbali2223_5w6Context>(
      options => options.UseLazyLoadingProxies()
                        .UseMySql(builder.Configuration.GetConnectionString("MyDB"), ServerVersion.Parse("10.6.7-mariadb"))
    );

//ajout des quelques services pour l'injection de dépendances
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   /* app.UseSwagger();
    app.UseSwaggerUI();*/
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
