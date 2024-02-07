using Microsoft.EntityFrameworkCore;
using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Repository;
using ToDoList.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IShoppingListRepository, ShoppingListRepository>();
builder.Services.AddScoped<IToDoListRepository, ToDoRepository>();
builder.Services.AddScoped<IPlannerRepository, PlannerRepository>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    
    endpoints.MapControllerRoute(
        name: "createDaily",
        pattern: "planner/create-daily",
        defaults: new { controller = "PlannerCreator", action = "DailyPlanner" }
    );

    endpoints.MapControllerRoute(
        name: "createWeekly",
        pattern: "planner/create-weekly",
        defaults: new { controller = "PlannerCreator", action = "WeeklyPlanner" }
    );

    endpoints.MapControllerRoute(
        name: "createMonthly",
        pattern: "planner/create-monthly",
        defaults: new { controller = "PlannerCreator", action = "MonthlyPlanner" }
    );

});

app.Run();
