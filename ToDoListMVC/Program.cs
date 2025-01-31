using ToDoListMVC.ToDo.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using ToDoListMVC.ToDo.Service.Abstracts;
using ToDoListMVC.ToDo.Service.Concretes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IGorevService,GorevService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BaseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Gorev}/{action=Index}/{id?}");



app.Run();