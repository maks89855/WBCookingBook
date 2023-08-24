using Microsoft.EntityFrameworkCore;
using WebCookingBook.DbContexts;
using WebCookingBook.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddControllers(); // �������� �� MVC
builder.Services.AddDbContext<ApplicationContext>(opt =>
{
    opt.UseSqlite("Data Source=CookingBookDB.db");
});
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");
    //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); 
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.UseAuthorization();

//app.MapRazorPages();

app.Run();
