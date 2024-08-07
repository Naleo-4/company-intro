using Project.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Project.DataAccess.Repository.IRepository;
using Project.DataAccess.Repository;
using ProjectMVC.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddScoped<CategoryService>();
// builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(
// "server=localhost;port=3306;database=test;user=root;password="
// // builder.Configuration.GetConnectionString("DefaultConnection")
// ));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
