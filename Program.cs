using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using WebCookingBook.DbContexts;
using WebCookingBook.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddControllers(); // Заменить на MVC
builder.Services.AddDbContext<ApplicationContext>(opt =>
{
    opt.UseSqlite("Data Source=CookingBookDB.db");
});
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// В старых версия .NET core используется связка промежуточного ПО из двух команд

app.UseRouting(); //   Выбирает наиболее лучший вариант конечной точки
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers()); // Добавляет выполнении конченых точек в конвейре

// В новых используется
//app.MapControllers(); 

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

