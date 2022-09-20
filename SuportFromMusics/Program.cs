using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SingServices.Repository;
using Suport.Data.Repository;
using SuportFromMusics.Data;
using System.Security.Claims;
using UserServices.Repository;
using UserServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(Program));

#region AddScopeds
builder.Services.AddScoped<ISendEmail, SendPasswordWithEmail>();
builder.Services.AddScoped<ILogin, Login>();
builder.Services.AddScoped<IAddUser, AddUser>();
builder.Services.AddScoped<IGetSings, GetSings>();
builder.Services.AddScoped<IGetSingers, GetSingers>();
builder.Services.AddScoped<IGetUsers, GetUsers>();
#endregion 

#region Use SqlServer
builder.Services.AddDbContext<SuportContext>(options =>
{
    options.UseSqlServer("Data Source =.; Initial Catalog = SuportFromMusics_DB; Integrated Security = true");
});
#endregion

#region add Authentication

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Account/LogIn";
        option.LogoutPath = "/Account/LogOut";
        option.ExpireTimeSpan = TimeSpan.FromDays(365);
    });

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

//app.Use(async (Context, next) =>
//{
//    if (Context.Request.Path.StartsWithSegments("/AdminPanel"))
//    {
//#pragma warning disable CS8602 // Dereference of a possibly null reference.
//        if (!Context.User.Identity.IsAuthenticated)
//        {
//            Context.Response.Redirect("/Account/LogIn");
//        }
//        else if (!bool.Parse(Context.User.FindFirstValue("IsAdmin")))
//        {
//            Context.Response.Redirect("/Account/LogIn");
//        }
//#pragma warning restore CS8602 // Dereference of a possibly null reference.

//        await next.Invoke();
//    }
//});


app.MapRazorPages();

app.Run();
