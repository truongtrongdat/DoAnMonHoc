using DoAnMonHoc.Data;
using DoAnMonHoc.Services;
using DoAnMonHoc.ViewModel;
using DoAnMonHoc.Vnpay;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault")));


builder.Services.AddScoped<UserManager<AppUser>>();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddSingleton<IVnPayService, VnPayService>();
builder.Services.AddScoped<Helper>();

builder.Services.AddIdentity<AppUser, IdentityRole>(
	options =>
	{
		options.Password.RequiredUniqueChars = 0; // s? k� t? ??c nh?t l� 0 
		options.Password.RequireUppercase = false; // ko y�u c?u c� k� t? vi?t hoa
		options.Password.RequiredLength = 8;// �t nh?t 8
		options.Password.RequireLowercase = false; // vi?t th??ng
		options.Password.RequireNonAlphanumeric = false;//ko yc c� k� t? ??c bi?t trong mk
	})
	.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders(); // thi?t l?p Identity sd ENTITY FR ?? l?u tr? d? li?u ng??i d�ng
builder.Services.AddScoped<RoleManager<IdentityRole>>();                                                                          //AddDefaultTokenProviders : ?k c�c cung c?p m� th�ng b�o m?c ??nh (sd trong qu� tr�nh x�c th?c ng??i d�ng)
builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("AdminPolicy", policy =>
	{
		policy.RequireRole("admin");
	});
});
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
app.UseSession();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	 name: "areas",
	 pattern: "{area:exists}/{controller=AdminProduct}/{action=Index}/{id?}"
	 );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllers();
app.MapRazorPages();

app.Run();
