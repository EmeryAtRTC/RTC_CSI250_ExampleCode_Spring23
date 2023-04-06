//The builder creates the web app
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//This is where we add and configure services
//Services is a ServiceCollection
builder.Services.AddControllersWithViews();

//Create the webapplication
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
// This allows us to show a more detailed error message while we are in development
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//This allows us to use https
app.UseHttpsRedirection();
//This lets us serve static files. A static file is one that does not change
app.UseStaticFiles();

//This enables routing
app.UseRouting();
//Enables authorization
app.UseAuthorization();
//This specifies the default route
//The routing is /ControllerName/Action
//If you dont specify anything you go to /Home/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Retrive values from appsettings.json using the app object
string apikey = app.Configuration["SecretCode"];
Console.WriteLine($"Our api key is {apikey}");
//We run the web application
app.Run();
 