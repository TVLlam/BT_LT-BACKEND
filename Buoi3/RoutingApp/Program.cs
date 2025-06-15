var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//cài ??t Route
//Cách 1: conventinal
app.MapControllerRoute(
    name:"gioi-thieu",
    pattern: "trang-chu/gioi-thieu",
    defaults: new { controller ="Home",  action = "About" });

app.Run();
