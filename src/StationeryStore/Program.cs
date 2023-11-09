using StationeryStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Text;
using StationeryStore.Data.DAOs;
using StationeryStore.Services;
using AutoMapper;
using StationeryStore.Mappings;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddDbContextPool<ApplicationDbContext>(options => 
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();   
builder.Services.AddTransient<AuthService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddAutoMapper(typeof(CartProductProfile), typeof(ProductProfile), typeof(UserProfile), typeof(CategoryProfile));
builder.Services.AddAuthorization();

// builder.Services.AddTransient<AdministratorSeedData>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");
await AdministratorSeedData.EnsureSeedDataAsync(app);


app.Run();

