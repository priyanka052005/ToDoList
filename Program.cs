var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Use middlewares
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Set up the default route for the app
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();
