using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using WebCookingBook.DbContexts;
using WebCookingBook.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();

builder.Services.AddControllers()
    .AddNewtonsoftJson(opt =>
    {
        opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    })
    .AddXmlDataContractSerializerFormatters();

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
else
{
    app.UseExceptionHandler(opt =>
    {
        opt.Run(async context =>
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Oops, something went wrong");
        });
    });
}


app.UseRouting(); //   
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers()); 


//app.MapControllers(); 

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

