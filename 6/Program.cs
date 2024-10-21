using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Додаємо MVC сервіс
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Налаштування середовища
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Налаштування маршруту за замовчуванням
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PizzaOrder}/{action=Register}/{id?}");

// Запуск застосунку
app.Run();
