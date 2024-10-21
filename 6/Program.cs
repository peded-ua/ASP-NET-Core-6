using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// ������ MVC �����
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ������������ ����������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ������������ �������� �� �������������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PizzaOrder}/{action=Register}/{id?}");

// ������ ����������
app.Run();
