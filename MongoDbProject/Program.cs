using Microsoft.Extensions.Options;
using MongoDbProject.Services.CategoryServices;
using MongoDbProject.Services.DiscountServices;
using MongoDbProject.Services.FeatureServices;
using MongoDbProject.Services.ProductServices;
using MongoDbProject.Services.SellingServices;
using MongoDbProject.Services.UserServices;
using MongoDbProject.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IDiscountService,DiscountService>();
builder.Services.AddScoped<ISellingService, SellingService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
	return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
// Add Session support
builder.Services.AddDistributedMemoryCache(); // Session için gerekli
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum süresi
    options.Cookie.HttpOnly = true; // Güvenlik için
    options.Cookie.IsEssential = true; // Çerez zorunlu mu
});



builder.Services.AddControllersWithViews();

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
app.UseSession();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
});

app.Run();
