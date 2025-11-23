using tp3.Models;
using tp3.Models.Repositories;
var builder = WebApplication.CreateBuilder(args);

// 1. Add MVC
builder.Services.AddControllersWithViews();

// 2. Register repository
builder.Services.AddSingleton<IRepository<Employee>, EmployeeRepository>();


var app = builder.Build();

// 3. Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 4. Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
