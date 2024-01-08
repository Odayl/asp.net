using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetFinal.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FoodDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FoodDBContext") ?? throw new InvalidOperationException("Connection string 'FoodDBContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<FoodDBContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("FoodDBContext")
    ));



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
    pattern: "{controller=Foods}/{action=Index}/{id?}");

app.Run();
