using Microsoft.EntityFrameworkCore;

using TodoListData.Models;
using TodoListServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

Console.WriteLine(builder.Configuration.GetConnectionString("SqlServer"));

builder.Services.AddDbContext<TodoListContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServer"),
        x => x.MigrationsAssembly("TodoListData")
    )
);

builder.Services.AddTransient<TodoListService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapGet("api/test", () => new {Test = "hello"});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
