using librarySampleMVC.Data;
using librarySampleMVC.Interface;
using librarySampleMVC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddRazorPages();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<IdentityDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Ibook, bookService>();
builder.Services.AddScoped<Igroup, groupService>();
builder.Services.AddScoped<Ipublisher, publishService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-7.0

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "bookRoute",
    pattern: "{controller}/{action}/{bookName}");
app.MapRazorPages();

app.Run();
