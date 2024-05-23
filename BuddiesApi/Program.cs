<<<<<<< Updated upstream
using BuddiesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
=======
using CodeBuddies.Data;
using Microsoft.EntityFrameworkCore;
>>>>>>> Stashed changes

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
<<<<<<< Updated upstream
builder.Services.AddDbContext<CategoryContext>(opt =>
    opt.UseSqlServer("data source=DESKTOP-IHEEE6U;initial catalog=Buddies6;trusted_connection=true;TrustServerCertificate=True;"));
=======
builder.Services.AddDbContext<DatabaseApplicationContext>(options =>
            options.UseSqlServer("Server=tcp:iss924.database.windows.net,1433;Initial Catalog=iss;Persist Security Info=False;User ID=gr924;Password=gR!12345678;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
>>>>>>> Stashed changes
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

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
